using System.Windows;
using System.Windows.Input;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Create;

public partial class CreateObjectDialogWindow : Window
{
    public CreateObjectDialogWindow(string winTitle = "Создать")
    {
        InitializeComponent();
        Title = winTitle;
        InputTextBox.Focus();
    }

    public string EnteredText { get; private set; }

    private void ObjectNameTextBox_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Close();
            return;
        }

        if (e.Key != Key.Enter)
            return;

        EnteredText = InputTextBox.Text;
        DialogResult = true;
        Close();
    }
}