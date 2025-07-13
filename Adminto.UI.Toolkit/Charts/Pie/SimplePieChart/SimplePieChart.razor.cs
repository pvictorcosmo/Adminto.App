using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Adminto.UI.Toolkit.Charts.Pie.SimplePieChart;

public partial class SimplePieChart : ComponentBase
{
    [Parameter] public IEnumerable<decimal> Numbers { get; set; } = Enumerable.Empty<decimal>();

    [Parameter] public IEnumerable<string> Labels { get; set; } = Enumerable.Empty<string>();

    [Parameter] public IEnumerable<string> Colors { get; set; } = Enumerable.Empty<string>();

    [Parameter] public TypePieChart PieType { get; set; } = TypePieChart.Normal;
    private IJSObjectReference? _module;
    

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
                "./_content/Adminto.UI.Toolkit/js/components/chart-apex-pie.js");
            await JsRuntime.InvokeVoidAsync("loadPieCharts",
                Numbers.ToArray(),
                Labels.ToArray(),
                Colors.ToArray()
            );
            await JsRuntime.InvokeVoidAsync("loadThemeConfig");
        }
    }
}

public static class TypePieChartExtensions
{
    public static string GetText(this TypePieChart type)
    {
        return type switch
        {
            TypePieChart.Normal => "simple-pie",
            TypePieChart.Donut => "simple-donut",
            TypePieChart.DonutGradient => "gradient-donut",
            _ => ""
        };
    }
}

public enum TypePieChart
{
    Normal,
    Donut,
    DonutGradient
}