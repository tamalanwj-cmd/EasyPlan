using EasyPlan.Models;

namespace EasyPlan;

public partial class AddPage : ContentPage
{
    private string selectedColor = "#1E88FF";
    private string selectedPriority = "Low"; //  DEFAULT PRIORITY
    private ClassItem? editingItem;

    public AddPage(ClassItem? item = null)
    {
        InitializeComponent();

        if (item != null)
        {
            editingItem = item;

            subjectEntry.Text = item.Subject;
            locationEntry.Text = item.Location;
            descriptionEditor.Text = item.Description;

            selectedColor = item.CardColor;
            selectedPriority = item.Priority; // LOAD PRIORITY

            if (DateTime.TryParse(item.Date, out DateTime parsedDate))
                datePicker.Date = parsedDate;
        }

        blueBtn.BorderColor = Colors.White;
        blueBtn.BorderWidth = 3;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string subject = subjectEntry.Text ?? "";
        string location = locationEntry.Text ?? "";

        TimeSpan t = timePicker.Time ?? TimeSpan.Zero;
        string time = $"{t.Hours:D2}:{t.Minutes:D2}";

        DateTime d = datePicker.Date ?? DateTime.Now;
        string date = $"{d.Day:D2} {d:MMM} {d.Year}";

        string description = descriptionEditor.Text ?? "";

        if (editingItem != null)
        {
            editingItem.Subject = subject;
            editingItem.Location = location;
            editingItem.Time = time;
            editingItem.Date = date;
            editingItem.Description = description;
            editingItem.CardColor = selectedColor;
            editingItem.Priority = selectedPriority; // SAVE PRIORITY
        }
        else
        {
            ClassItem newClass = new ClassItem
            {
                Subject = subject,
                Location = location,
                Time = time,
                Date = date,
                Description = description,
                CardColor = selectedColor,
                Priority = selectedPriority // SAVE PRIORITY
            };

            ClassRepository.Classes.Add(newClass);

            // 🔥 DEBUG (optional)
            await DisplayAlert("Saved", $"Total items: {ClassRepository.Classes.Count}", "OK");
        }

        ClassRepository.SaveClasses();
        await Navigation.PopToRootAsync();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnColorSelected(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        selectedColor = button.BackgroundColor.ToHex();

        redBtn.BorderWidth = 0;
        blueBtn.BorderWidth = 0;
        greenBtn.BorderWidth = 0;
        orangeBtn.BorderWidth = 0;
        purpleBtn.BorderWidth = 0;

        button.BorderColor = Colors.White;
        button.BorderWidth = 3;
    }

    //  ADD THIS priority buttons
    private void OnPrioritySelected(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        selectedPriority = button.Text;
    }
}