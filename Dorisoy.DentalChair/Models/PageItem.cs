using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorisoy.DentalChair;

public partial class PageItem : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string icon;

    [ObservableProperty]
    private string iconActive;

    [ObservableProperty]
    private View pageContent;

    [ObservableProperty]
    private bool isSelected;

}


public partial class ShellPage : ObservableObject
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string icon;

    [ObservableProperty]
    private string flyoutIcon;

    [ObservableProperty]
    private string route;
}

