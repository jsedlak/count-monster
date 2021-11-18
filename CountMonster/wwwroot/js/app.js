window.app = {
    charts: {},
    chart: function (elementId, type, labels, datasets) {
        if (window.app.charts[elementId]) {
            window.app.charts[elementId].chart.data.labels = labels;
            window.app.charts[elementId].chart.data.datasets = datasets;
            window.app.charts[elementId].chart.update();
            return;
        }

        const ctx = document.getElementById(elementId).getContext('2d');

        const myChart = new Chart(ctx, {
            type: type, // 'bar',
            data: {
                labels: labels, // ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
                datasets: datasets
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });

        window.app.charts[elementId] = { chart: myChart };


    },
    copyText: function (text) {
        navigator.clipboard.writeText(text).then(function () { })
            .catch(function (error) {
                alert(error);
            });
    },
    outsideClickHandler: {
        addEvent: function (elementId, dotnetHelper) {
            window.addEventListener("click", (e) => {
                var element = document.getElementById(elementId);

                if (!element) {
                    return;
                }

                if (!element.contains(e.target)) {
                    dotnetHelper.invokeMethodAsync("InvokeClickOutside");
                }
            });
        }
    }
};

