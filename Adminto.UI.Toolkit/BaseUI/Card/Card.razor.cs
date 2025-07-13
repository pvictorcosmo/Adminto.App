using Microsoft.AspNetCore.Components;

namespace Adminto.UI.Toolkit.BaseUI.Card;

public partial class Card : ComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public string Title { get; set; }
}