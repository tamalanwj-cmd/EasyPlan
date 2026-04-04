using EasyPlan.Models;

namespace EasyPlan;

public partial class AddPage : ContentPage
{
    private string selectedColor = "#1E88FF";

    public AddPage()
    {
        InitializeComponent();

        blueBtn.BorderColor = Colors.White;
        blueBtn.BorderWidth = 3;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string subject = subjectEntry.Text ?? "";
        string location = locationEntry.Text ?? "";
        string time = timePicker.Time.ToString();

        DateTime? selectedDate = datePicker.Date;
        string date = selectedDate.HasValue
            ? selectedDate.Value.ToString("dd MMM yyyy")
            : "";

        string description = descriptionEditor.Text ?? "";

        ClassItem newClass = new ClassItem
        {
            Subject = subject,
            Location = location,
            Time = time,
            Date = date,
            Description = description,
            CardColor = selectedColor
        };

        ClassRepository.Classes.Add(newClass);
        ClassRepository.SaveClasses();

        await Navigation.PopAsync();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnColorSelected(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        selectedColor = button.BackgroundColor.ToArgbHex();

        redBtn.BorderWidth = 0;
        blueBtn.BorderWidth = 0;
        greenBtn.BorderWidth = 0;
        orangeBtn.BorderWidth = 0;
        purpleBtn.BorderWidth = 0;

        button.BorderColor = Colors.White;
        button.BorderWidth = 3;
    }
}