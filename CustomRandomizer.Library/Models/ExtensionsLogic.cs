namespace CustomRandomizer.Library.Models;

public static class ExtensionsLogic
{
    public static void UpdateTableNames(this LoadOutModel loadOutModel, string oldName, string newName)
    {
        var x = 0;
        loadOutModel.Tables.Where(t => t.Contains(oldName)).ToList().ForEach(x => x = newName);
    }
}
