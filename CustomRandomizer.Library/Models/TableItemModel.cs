namespace CustomRandomizer.Library.Models;

public class TableItemModel
{
    public int Weight { get; set; }
    public string Value { get; set; } = string.Empty;
    public List<string> TableNames { get; set; } = new();
    public bool IsTable { get; set; } = false;
}

