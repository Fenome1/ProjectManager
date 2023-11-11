using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectManager.Desktop.View.Manager.UserControls.DialogWindows.Special;

public partial class DeadlineSelectWindow : Window
{
    public DeadlineSelectWindow(DateTime? deadlineDate)
    {
        InitializeComponent();
        DateObjectiveInit(deadlineDate);
    }

    public DateTime? DeadlineDate { get; private set; }

    public void DateObjectiveInit(DateTime? currentObjectiveDateTime)
    {
        if (currentObjectiveDateTime is null)
        {
            DeadlinePicker.SelectedDate = DateTime.Today;
            return;
        }

        DeadlinePicker.SelectedDate = currentObjectiveDateTime;
    }


    private void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        DeadlineDate = DeadlinePicker.SelectedDate;

        if (DeadlineDate is null)
        {
            Close();
            return;
        }

        DialogResult = true;
        Close();
    }

    private void DeadlinePicker_OnSelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
    {
        Mouse.Capture(null);
    }
}