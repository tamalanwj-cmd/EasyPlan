using EasyPlan.Models;

namespace EasyPlan;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // bind once
        scheduleList.ItemsSource = ClassRepository.Classes;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // RELOAD FROM FILE EVERY TIME
        ClassRepository.LoadClasses();

        // FORCE UI REFRESH
        scheduleList.ItemsSource = null;
        scheduleList.ItemsSource = ClassRepository.Classes;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
    }

    private async void OnItemTapped(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as ClassItem;

        if (item == null)
            return;

        await Navigation.PushAsync(new DetailsPage(item));

        ((CollectionView)sender).SelectedItem = null;
    }
    //delete button
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        ClassItem item = (ClassItem)button.CommandParameter;

        bool confirm = await DisplayAlert("Delete", "Are you sure?", "Yes", "No");

        if (!confirm)
            return;

        ClassRepository.Classes.Remove(item);
        ClassRepository.SaveClasses();
    }
}