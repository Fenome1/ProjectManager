using System.Windows;
using System.Windows.Input;
using ProjectManager.Desktop.Models;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Edit;

public partial class ObjectiveUpdateWindow : Window
{
    public ObjectiveUpdateWindow(Objective objective)
    {
        InitializeComponent();
        NameTextBox.Text = objective.Name;
        DescriptionTextBox.Text = objective.Description;
    }

    private void AgreeButton_OnClick(object sender, RoutedEventArgs e)
    {
        DoPositiveCloseWindow();
    }

    private void NameTextBox_OnLoaded(object sender, RoutedEventArgs e)
    {
        NameTextBox.CaretIndex = NameTextBox.Text.Length;

        NameTextBox.SelectAll();

        NameTextBox.Focus();
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

    private void DoPositiveCloseWindow()
    {
        DialogResult = true;
        Close();
    }
}