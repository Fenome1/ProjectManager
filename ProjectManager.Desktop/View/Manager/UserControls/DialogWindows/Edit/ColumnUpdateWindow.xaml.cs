using System.Windows;
using System.Windows.Input;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;

public partial class ColumnUpdateWindow : Window
{
    public ColumnUpdateWindow(Column column)
    {
        InitializeComponent();
        NameTextBox.Text = column.Name;
    }

    private void InputTextBox_OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Close();
            return;
        }

        if (e.Key != Key.Enter)
            return;

        DialogResult = true;
        Close();
    }

    private void NameTextBox_OnLoaded(object sender, RoutedEventArgs e)
    {
        NameTextBox.CaretIndex = NameTextBox.Text.Length;

        NameTextBox.SelectAll();

        NameTextBox.Focus();
    }
}