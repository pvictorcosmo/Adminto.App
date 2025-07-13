using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Adminto.UI.Toolkit.Charts.Area.SplineAreaChart;

public partial class SplineAreaChart : ComponentBase
{
    [Parameter] public ChartSeries[] Series { get; set; } = [];

    [Parameter] public string[] Colors { get; set; } = [];
    private IJSObjectReference? _module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var series = new[]
            {
                new ChartSeries
                {
                    name = "STOCK ABC",
                    prices = new[] { 10000.0, 12000.0, 15000.0 },
                    dates = new[] { "Jan", "Feb", "Mar" }
                },
                new ChartSeries
                {
                    name = "STOCK XYZ",
                    prices = new[] { 8000.0, 9000.0, 10000.0 },
                    dates = new[] { "2024-01-01", "2024-02-01", "2024-03-01" }
                }
            };

            var colors = new[] { "#5b69bc", "#35b8e0" };
            _module = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
                "./_content/Adminto.UI.Toolkit/js/components/chart-apex-area.js");
            await JsRuntime.InvokeVoidAsync("loadSplineAreaCharts", series, colors
            );
            await JsRuntime.InvokeVoidAsync("loadThemeConfig");
        }
    }
}

public class ChartSeries
{
    public string name { get; set; } = "";
    public double[] prices { get; set; } = [];
    public string[] dates { get; set; } = [];
}