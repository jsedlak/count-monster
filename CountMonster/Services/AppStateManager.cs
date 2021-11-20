using Blazored.LocalStorage;
using CountMonster.Model;

namespace CountMonster.Services
{
    public class AppStateManager
    {
        public static class StorageKeys
        {
            public static readonly string TrackedItems = "trackeditems";
            public static readonly string MetaData = "metadata";
        }

        private ILocalStorageService _storage;

        private DateTimeOffset _timerBase = DateTimeOffset.Now;

        private IEnumerable<TrackedItem> _trackedItems = new TrackedItem[] { };
        private AppMetaData _appMetaData = new AppMetaData();
        private bool _isInitialized = false;

        public AppStateManager(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public async Task SaveAsync()
        {
            await _storage.SetItemAsync(StorageKeys.TrackedItems, TrackedItems);
            await _storage.SetItemAsync(StorageKeys.MetaData, MetaData);
            NotifyStateChanged();
        }

        public async Task InitializeAsync()
        {
            if (await _storage.ContainKeyAsync(StorageKeys.TrackedItems))
            {
                TrackedItems = await _storage.GetItemAsync<TrackedItem[]>(StorageKeys.TrackedItems);

                await UpgradeAsync();
            }

            if(await _storage.ContainKeyAsync(StorageKeys.MetaData))
            {
                MetaData = await _storage.GetItemAsync<AppMetaData>(StorageKeys.MetaData);
            }
            else
            {
                MetaData = new AppMetaData();
                await _storage.SetItemAsync(StorageKeys.MetaData, MetaData);
            }

            IsInitialized = true;
        }

        private async Task UpgradeAsync()
        {
            var needsSave = false;
            foreach (var item in TrackedItems)
            {
                if (item.Version == 0)
                {
                    item.Version = 1;

                    Action<IEnumerable<TrackedRun>> updateNumbers = (input) =>
                    {
                        var copy = input.ToArray().Reverse();
                        var count = 1;
                        foreach (var item in copy)
                        {
                            item.Number = count;
                            count++;
                        }
                    };

                    updateNumbers(item.Runs);
                    updateNumbers(item.ArchivedRuns);
                    needsSave = true;
                }
            }

            if (needsSave)
            {
                await SaveAsync();
            }
        }

        public AppMetaData MetaData
        {
            get { return _appMetaData; }
            set
            {
                _appMetaData = value; 
                NotifyStateChanged();
            }
        }

        public IEnumerable<TrackedItem> TrackedItems
        {
            get { return _trackedItems; }
            set
            {
                _trackedItems = value;
                NotifyStateChanged();
            }
        }

        public DateTimeOffset TimerBase
        {
            get { return _timerBase; }
            set
            {
                _timerBase = value;
                NotifyStateChanged();
            }
        }

        public bool IsInitialized
        {
            get { return _isInitialized; }
            set
            {
                _isInitialized = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
