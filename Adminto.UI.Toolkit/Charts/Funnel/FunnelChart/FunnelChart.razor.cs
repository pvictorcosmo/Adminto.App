using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Adminto.UI.Toolkit.Charts.Funnel.FunnelChart;

public partial class FunnelChart : ComponentBase
{
    [Parameter] public IEnumerable<decimal> Numbers { get; set; } = Enumerable.Empty<decimal>();

    [Parameter] public IEnumerable<string> Labels { get; set; } = Enumerable.Empty<string>();

    [Parameter] public IEnumerable<string> Colors { get; set; } = Enumerable.Empty<string>();

    private IJSObjectReference? _module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
                "./_content/Adminto.UI.Toolkit/js/components/chart-apex-funnel.js");

            await JsRuntime.InvokeVoidAsync("loadFunnelCharts",
                Numbers.ToArray(),
                Labels.ToArray(),
                Colors.ToArray()
            );
            await JsRuntime.InvokeVoidAsync("loadThemeConfig");
        }
    }
}