namespace EasyPlan.Models;

public class ClassItem
{
    public string Subject { get; set; } = "";
    public string Location { get; set; } = "";
    public string Time { get; set; } = "";
    public string Date { get; set; } = "";
    public string Description { get; set; } = "";
    public string CardColor { get; set; } = "#1E88FF";

    // ✅ ADD THIS (CRITICAL FIX)
    public string Priority { get; set; } = "Low";
}