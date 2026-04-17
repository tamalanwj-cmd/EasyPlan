using EasyPlan.Models;

namespace EasyPlan;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // LOAD DATA ON START
        ClassRepository.LoadClasses();

        MainPage = new NavigationPage(new MainPage());
    }
}