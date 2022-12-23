namespace CustomRandomizer.Library.Models;

public class TableModel
{
    public string Name { get; set; } = string.Empty;
    public List<TableItemModel> TableItems { get; set; } = new();
    public int TableTotalValue
    {
        get
        {
            return this.TableItems.Select(x => x.Weight).ToList().Sum();
        }
    }
}
