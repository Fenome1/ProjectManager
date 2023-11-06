using System.Windows;
using System.Windows.Controls;

namespace ProjectManager.Desktop.View.Manager.UserControls;

public partial class ObjectiveItemControl : UserControl
{
    public ObjectiveItemControl()
    {
        InitializeComponent();
    }

    private void OpenObjectiveContextMenu_OnClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var contextMenu = button.ContextMenu;

        if (contextMenu != null)
        {
            contextMenu.PlacementTarget = button;
            contextMenu.IsOpen = true;
        }
    }
}