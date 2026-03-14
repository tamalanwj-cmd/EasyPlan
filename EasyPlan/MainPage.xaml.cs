namespace EasyPlan;

public partial class MainPage : ContentPage
{
    //Main Dashboard
    public MainPage()
    {
        //Load UI
        InitializeComponent();
    }
    //Clicked + button and trigger method
    private async void GoToAddPage(object sender, EventArgs e)
    {
        //Go to addpage screen
        await Navigation.PushAsync(new AddPage());
    }
}