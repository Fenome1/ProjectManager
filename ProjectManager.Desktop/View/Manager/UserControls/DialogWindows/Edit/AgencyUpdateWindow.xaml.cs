using System.Windows;
using System.Windows.Input;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;

public partial class AgencyUpdateWindow : Window
{
    public AgencyUpdateWindow(Agency agency)
    {
        InitializeComponent();
        NameTextBox.Text = agency.Name;
        DescriptionTextBox.Text = agency.Description;
    }

    private void AgreeButton_OnClick(object sender, RoutedEventArgs e)
    {
        DoPositiveCloseWindow();
    }

    private void TextBoxes_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Close();
            return;
        }

        if (e.Key != Key.Enter)
            return;

        DoPositiveCloseWindow();
    }

    private void NameTextBox_OnLoaded(object sender, RoutedEventArgs e)
    {
        NameTextBox.CaretIndex = NameTextBox.Text.Length;

        NameTextBox.SelectAll();

        NameTextBox.Focus();
    }

    private void DoPositiveCloseWindow()
    {
        DialogResult = true;
        Close();
    }
}