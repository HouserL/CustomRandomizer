namespace CustomRandomizer.Forms;
public partial class RandomizerForm : Form
{
    public List<TableModel> Tables = new();
    public List<LoadOutModel> LoadOuts = new();
    private string _roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\Verdant Studios\";
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
        int count = this.Controls.OfType<TableSelecterControl>().ToList().Count; // Determine how many controls of this type there are.

        switch (count % 3) // Place the Control in  a column based on how many controls there are.
        {
            case 0: tableSelecter.Location = new System.Drawing.Point(11, (75 * (count / 3)) + 75); break;
            case 1: tableSelecter.Location = new System.Drawing.Point(530, (75 * (count / 3)) + 75); break;
            case 2: tableSelecter.Location = new System.Drawing.Point(1049, (75 * (count / 3)) + 75); break;
        }
        tableSelecter.Name = "tableSelecter_" + (count + 1);
        tableSelecter.RemoveControlButton.Click += new EventHandler(DeleteButton_Click);
        this.Controls.Add(tableSelecter);
        if (tableName != string.Empty) tableSelecter.TableNamesComboBox.Text = tableName;
    }

    public void DeleteButton_Click(object sender, EventArgs e)
    {
        Button button = (sender as Button);     //Reference the Button which was clicked.
        
        int index = int.Parse(button.Parent.Name.Split('_')[1]);    //Determine the Index of the Control.
        
        Controls.Remove(Controls.Find("tableSelecter_" + index, true)[0]);  //Find the Selecter using Index and remove it.
        
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>()) //Rearranging the Location controls.
        {
            int controlIndex = int.Parse(selecter.Name.Split('_')[1]);
            if (controlIndex > index)
            {
                selecter.Name = "tableSelecter_" + (controlIndex - 1); // Rename control for future actions.
                switch (controlIndex % 3) // Check which Column the Control is in.
                {
                    case 0: selecter.Left += -519; break;                       // Right Column
                    case 1: selecter.Top += -75; selecter.Left += 1038; break;  // Left Column
                    case 2: selecter.Left += -519; break;                       // Center Column
                }
            }
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
        while (Controls.OfType<TableSelecterControl>().Any())
        {
            Controls.Remove(Controls.OfType<TableSelecterControl>().First());
        }
        var loutOutModel = LoadOuts.FirstOrDefault(x => x.Name == LoadoutComboBox.Text.ToString());
        foreach (var TableName in loutOutModel.Tables)
        {
            CreateTableSelector(TableName);
        }
        RerollAllFields_Click(sender, e);
    }

    private void TableConfigurer_Click(object sender, EventArgs e)
    {

    }
}
