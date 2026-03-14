namespace EasyPlan;

public partial class App : Application
{
    // Constructor runs when the application starts
public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Set MainPage as the first page
        return new Window(new NavigationPage(new MainPage()));
    }
}