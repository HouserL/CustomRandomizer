using System.Windows.Forms;

namespace CustomRandomizer.Forms;
public partial class RandomizerForm : Form
{
    public List<TableModel> Tables = new();
    public List<LoadOutModel> LoadOuts = new();
    private readonly string _roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\Verdant Studios\";
    public RandomizerForm()
    {
        LoadTables();
        InitializeComponent();
        LoadLoadOuts();
    }

    private void LoadTables()
    {
        Tables = JsonConverter.ReadJsonFile<List<TableModel>>($@"{_roaming}Tables.json");
    }

    private void SaveTables()
    {
        JsonConverter.WriteToFile(Tables, $@"{_roaming}Tables.json");
    }

    private void LoadLoadOuts()
    {
        LoadOuts = JsonConverter.ReadJsonFile<List<LoadOutModel>>($@"{_roaming}LoadOuts.json");
        LoadLoadOutComboBox();
    }

    private void SaveLoadOuts()
    {
        JsonConverter.WriteToFile(LoadOuts, $@"{_roaming}LoadOuts.json");
        LoadLoadOutComboBox();
    }

    private void LoadLoadOutComboBox()
    {
        LoadoutComboBox.Items.Clear();
        LoadoutComboBox.Items.AddRange(LoadOuts.Select(x => x.Name).ToArray());
        LoadoutComboBox.SelectedIndex = 0;
    }

    private void AddTableSelector_Click(object sender, EventArgs e)
    {
        CreateTableSelector(string.Empty);
    }

    private void CreateTableSelector(string tableName)
    {
        TableSelecterControl tableSelecter = new(Tables);
        var count = this.Controls.OfType<TableSelecterControl>().ToList().Count; // Determine how many controls of this type there are.

        switch (count % 3) // Place the Control in  a column based on how many controls there are.
        {
            case 0: tableSelecter.Location = new System.Drawing.Point(10, (75 * (count / 3)) + 75); break;
            case 1: tableSelecter.Location = new System.Drawing.Point(445, (75 * (count / 3)) + 75); break;
            case 2: tableSelecter.Location = new System.Drawing.Point(880, (75 * (count / 3)) + 75); break;
        }
        tableSelecter.Name = "tableSelecter_" + (count + 1);
        tableSelecter.RemoveControlButton.Click += new EventHandler(DeleteButton_Click);
        this.Controls.Add(tableSelecter);
        if (tableName != string.Empty) tableSelecter.TableNamesComboBox.Text = tableName;
    }

    public void DeleteButton_Click(object sender, EventArgs e)
    {
        var button = (sender as Button);     //Reference the Button which was clicked.
        var index = int.Parse(button.Parent.Name.Split('_')[1]);    //Determine the Index of the Control.
        
        Controls.Remove(Controls.Find("tableSelecter_" + index, true)[0]);  //Find the Selecter using Index and remove it.
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>()) //Rearranging the Location controls.
        {
            var controlIndex = int.Parse(selecter.Name.Split('_')[1]);
            if (controlIndex > index) ReorderSelectors(selecter, controlIndex);
        }
    }

    private void ReorderSelectors(TableSelecterControl selecter, int controlIndex)
    {
        selecter.Name = "tableSelecter_" + (controlIndex - 1); // Rename control for future actions.
        switch (controlIndex % 3) // Check which Column the Control is in.
        {
            case 0: selecter.Left += -435; break;                       // Right Column
            case 1: selecter.Top += -75; selecter.Left += 870; break;  // Left Column
            case 2: selecter.Left += -435; break;                       // Center Column
        }
    }

    private void RerollAllFields_Click(object sender, EventArgs e)
    {
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>())
        {
            selecter.ResetSelection();
            selecter.RerollButton_Click(this, EventArgs.Empty);
        }
    }

    private void SaveLoadoutButton_Click(object sender, EventArgs e)
    {
        if (!Controls.OfType<TableSelecterControl>().Any()) return;
        LoadOutModel loadOutModel= new();
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>())
        {
            loadOutModel.Tables.Add(selecter.TableNamesComboBox.Text.ToString());
        }
        //change to C# from VB simple input box for name capture.
        loadOutModel.Name = Microsoft.VisualBasic.Interaction.InputBox("What would you like to name the loadout?","Save New Loud Out");

        LoadOuts.Add(loadOutModel);
        SaveLoadOuts(); 
    }

    private void UseLoadOutButton_Click(object sender, EventArgs e)
    {
        RemoveAllSelecters();
        var loutOutModel = LoadOuts.FirstOrDefault(x => x.Name == LoadoutComboBox.Text.ToString());
        foreach (var TableName in loutOutModel.Tables)
        {
            CreateTableSelector(TableName);
        }
        RerollAllFields_Click(sender, e);
    }

    private void RemoveAllSelecters()
    {
        while (Controls.OfType<TableSelecterControl>().Any())
        {
            Controls.Remove(Controls.OfType<TableSelecterControl>().First());
        }
        ResetFormSize();
    }

    private void ResetFormSize()
    {
        this.ClientSize = new System.Drawing.Size(618, 93);
        GC.Collect();
    }

    private void TableConfigurer_Click(object sender, EventArgs e)
    {
        if (AddTableSelector.Enabled) StartTableConfigure();
        else StopTableConfigure();
        return;
    }

    private void StartTableConfigure()
    {
        RemoveAllSelecters();

        TableConfigurerControl tableConfigurer = new(Tables);
        tableConfigurer.Location = new System.Drawing.Point(11, 75);
        tableConfigurer.Name = "TableConfig";
        this.Controls.Add(tableConfigurer);
        EnableButtons(false);
    }

    private void StopTableConfigure()
    {
        if (!Controls.OfType<TableConfigurerControl>().Any()) return;
        foreach (TableConfigurerControl control in Controls.OfType<TableConfigurerControl>())
        {
            Controls.Remove(Controls.OfType<TableConfigurerControl>().First());
        }
        ResetFormSize();
        Tables.OrderBy(x => x.Name);
        SaveTables();
        EnableButtons(true);
    }

    private void EnableButtons(bool IsEnabled)
    {
        this.AddTableSelector.Enabled = IsEnabled;
        this.UseLoadOutButton.Enabled = IsEnabled;
        this.SaveLoadoutButton.Enabled = IsEnabled;
        this.RerollAllFields.Enabled = IsEnabled;
    }
}
