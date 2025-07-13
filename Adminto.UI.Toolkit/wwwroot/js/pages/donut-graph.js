window.loadDonutGraph = function ({
                                      elementId = "data-visits-chart",
                                      series = [65, 14, 10, 45],
                                      labels = ["Direct", "Social", "Marketing", "Affiliates"],
                                      defaultColors = ["#5b69bc", "#35b8e0", "#10c469", "#fa5c7c", "#e3eaef"],
                                      height = 277,
                                      legendFontSize = "14px",
                                      legendOffsetX = 0,
                                      legendOffsetY = 7
                                  } = {}) {
    const el = document.querySelector(`#${elementId}`);
    if (!el) {
        console.warn(`Elemento #${elementId} não encontrado.`);
        return;
    }

    // Tenta obter as cores do atributo data-colors
    let colors = defaultColors;
    const dataColors = el.getAttribute("data-colors");
    if (dataColors) {
        colors = dataColors.split(",");
    }

    const options = {
        chart: {
            height: height,
            type: "donut",
        },
        series: series,
        labels: labels,
        colors: colors,
        legend: {
            show: true,
            position: "bottom",
            horizontalAlign: "center",
            verticalAlign: "middle",
            floating: false,
            fontSize: legendFontSize,
            offsetX: legendOffsetX,
            offsetY: legendOffsetY,
        },
        stroke: {
            show: false,
        }
    };

    const chart = new ApexCharts(el, options);
    chart.render();
};
