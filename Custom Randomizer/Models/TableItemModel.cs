namespace CustomRandomizer.Models;

public class TableItemModel
{
    public int Weight { get; set; }
    public string Value { get; set; } = string.Empty;
    public List<string> TableNames = new();
    public bool IsTable = false;

}
