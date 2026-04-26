using EasyPlan.Models;

namespace EasyPlan;

public partial class DetailsPage : ContentPage
{
    private ClassItem currentItem;

    public DetailsPage(ClassItem item)
    {
        InitializeComponent();

        currentItem = item;

        subjectLabel.Text = item.Subject;
        locationLabel.Text = item.Location;
        timeLabel.Text = item.Time;
        dateLabel.Text = item.Date;
        descriptionLabel.Text = item.Description;
    }
    //backbutton
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // EDIT BUTTON to details page
    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage(currentItem));
    }
}