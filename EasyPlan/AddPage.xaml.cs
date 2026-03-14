namespace EasyPlan;

public partial class AddPage : ContentPage
{
    //Add new class schedule
    public AddPage()
    {
        //Runs Constructor
        InitializeComponent();
    }
    //Save button press to execute method
    private void OnSaveClicked(object sender, EventArgs e)
    {
        //Get user input
        string subject = subjectEntry.Text ?? "";
        string location = locationEntry.Text ?? "";
        //Get Time
        string time = timePicker.Time.ToString();

        //Display confirmation
        statusLabel.Text = $"Saved: {subject} - {location} - {time}";
    }

    //Go back when back button press 
    private async void OnBackClicked(object sender, EventArgs e)
    {
        //Go back to previous page
        await Navigation.PopAsync();
    }
}