using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Adminto.UI.Toolkit.Charts.Area.BasicAreaChart;

public partial class BasicAreaChart : ComponentBase
{
    [Parameter] public IEnumerable<decimal> Prices { get; set; } = Enumerable.Empty<decimal>();

    [Parameter] public IEnumerable<string> Dates { get; set; } = Enumerable.Empty<string>();

    [Parameter] public IEnumerable<string> Colors { get; set; } = Enumerable.Empty<string>();
    private IJSObjectReference? _module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
                "./_content/Adminto.UI.Toolkit/js/components/chart-apex-area.js");
            await JsRuntime.InvokeVoidAsync("loadBasicAreaCharts",
                Prices.ToArray(),
                Dates.ToArray(),
                Colors.ToArray()
            );
            await JsRuntime.InvokeVoidAsync("loadThemeConfig");
        }
    }
}