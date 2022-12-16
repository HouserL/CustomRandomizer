﻿using CustomRandomizer.Models;
using System.Linq;

namespace CustomRandomizer.Logic;

public static class RandomizerLogic
{
    public static string RunTable(List<TableModel> tableList, string tableName)
    {
        string output = string.Empty;
        var table = tableList.Where(x => x.Name == tableName).FirstOrDefault();
        TableItemModel model = new();
        Random random = new((int)DateTime.Now.Ticks & 0x7FFFFFFF); // bases random number on current time
        int randomNumber = random.Next(table.TableTotalValue); //RandomNumberSeeded(table);
        int compare = new();
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
            output = RunTable(tableList, ReturnSingleString(tableList, model.Value));
        }
        return output;
    }
    internal static TableModel ReturnSingle(List<TableModel> tables, string tableName)
    {
        return tables.ToList().Where(x => x.Name.ToLower().Contains(tableName.ToLower())).FirstOrDefault();
    }
    internal static string ReturnSingleString(List<TableModel> tables, string tableName)
    {
        return tables.ToList().Where(x => x.Name.ToLower().Contains(tableName.ToLower())).FirstOrDefault().Name;
    }
    internal static List<TableModel> ReturnTables(List<TableModel> tables)
    {
        return tables.ToList();
    }
}
