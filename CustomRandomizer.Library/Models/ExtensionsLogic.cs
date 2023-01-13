namespace CustomRandomizer.Library.Models;

public static class ExtensionsLogic
{
    public static void UpdateTableNames(this LoadOutModel loadOutModel, string oldName, string newName)
    {
        for (int i = 0; i < loadOutModel.Tables.Count(); i++)
        {
            if (loadOutModel.Tables[i] != oldName) continue; 
            loadOutModel.Tables[i] = newName;
        }
    }
}
