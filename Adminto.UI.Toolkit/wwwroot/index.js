(function () {
    const base = "_content/Adminto.UI.Toolkit";

    const styles = [
        {href: `${base}/css/vendor.min.css`},
        {href: `${base}/css/app.min.css`, id: "app-style"},
        {href: `${base}/css/icons.min.css`}
    ];

    for (const {href, id} of styles) {
        const link = document.createElement("link");
        link.rel = "stylesheet";
        link.href = href;
        link.type = "text/css";
        if (id) link.id = id;
        document.head.appendChild(link);
    }

    const scripts = [
        "https://cdn.jsdelivr.net/npm/apexcharts",
        `${base}/vendor/daterangepicker/moment.min.js`,
        `${base}/vendor/dayjs/dayjs.min.js`,
        `${base}/vendor/dayjs/plugin/quarterOfYear.js`,

        `${base}/js/vendor.min.js`,
        `${base}/js/app.js`,
        `${base}/js/config.js`,
        
        "https://apexcharts.com/samples/assets/series1000.js",
        "https://apexcharts.com/samples/assets/github-data.js",
        "https://apexcharts.com/samples/assets/irregular-data-series.js"
    ];

    for (const src of scripts) {
        const script = document.createElement("script");
        script.src = src;
        script.defer = true;
        document.head.appendChild(script);
    }
})();
