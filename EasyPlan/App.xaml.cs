using EasyPlan.Models;

namespace EasyPlan;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Load saved classes
        ClassRepository.LoadClasses();

        MainPage = new NavigationPage(new MainPage());
    }
}