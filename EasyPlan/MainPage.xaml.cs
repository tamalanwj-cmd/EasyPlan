using EasyPlan.Models;

namespace EasyPlan;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        scheduleList.ItemsSource = ClassRepository.Classes;
    }

    private async void GoToAddPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        ClassItem selectedClass = (ClassItem)button.CommandParameter;

        ClassRepository.Classes.Remove(selectedClass);
        ClassRepository.SaveClasses();
    }
}