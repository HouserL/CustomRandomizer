namespace CustomRandomizer.Library.Logic;

public static class RandomizerLogic
{
    public static string RunTable(List<TableModel> tableList, TableModel table)
    {
        var output = string.Empty;
        TableItemModel model = new();
        Random random = new((int)DateTime.Now.Ticks & 0x7FFFFFFF); // bases random number on current time
        var randomNumber = random.Next(table.TableTotalValue); //RandomNumberSeeded(table);
        var compare = 0;
        for (int i = 0; i < table.TableItems.Count; i++)
        {
            compare += table.TableItems[i].Weight;
            if (compare > randomNumber)
            {
                model = table.TableItems[i];
                output = model.Value;
                break;
            }
        }
        if (model.IsTable)
        {
            output = RunTable(tableList, tableList.FirstOrDefault(x => x.Name.ToString() == model.Value));

        }
        return output;
    }
    public static string RerunTable(List<TableModel> tables, TableModel table, List<string> usedResults)
    {
        string output;
        do
        {
            output = RunTable(tables, table);
            if (usedResults.Count == table.TableItems.Count)
            {
                usedResults.Clear();

            }
        } while (usedResults.Contains(output));

        usedResults.Add(output);
        return output;//RandomizerLogic.RunTable(_tables, table);
    }
}
