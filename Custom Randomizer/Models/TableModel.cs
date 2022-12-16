using System.Linq;

namespace CustomRandomizer.Models;

public class TableModel
{
    public string Name { get; set; } = string.Empty;
    public List<TableItemModel> TableItems { get; set; } = new();

    public int TableTotalValue
    {
        get
        {
            ////Get total number of Values in a table
            //int output = 0;
            //for (int i = 0; i < TableItems.Count; i++)
            //{
            //    output += TableItems[i].Weight;
            //}
            //return output;
            //return this.TableItems.Where(x => x.Weight > 0).Sum();
            return this.TableItems.Select(x => x.Weight).ToList().Sum();
        }
    }


}
