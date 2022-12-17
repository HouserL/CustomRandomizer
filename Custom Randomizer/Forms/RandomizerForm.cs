namespace CustomRandomizer.Forms;
public partial class RandomizerForm : Form
{
    public static List<TableModel> Tables = new();
    public List<LoadOutModel> LoadOuts = new();
    public RandomizerForm()
    {
        LoadTables();
        InitializeComponent();
    }
    private void LoadTables()
    {
        Tables = JsonConverter.ReadJsonFile<List<TableModel>>($@".\Tables.json");
    }
    private void AddTableSelector_Click(object sender, EventArgs e)
    {
        TableSelecterControl tableSelecter = new();
        int count = this.Controls.OfType<TableSelecterControl>().ToList().Count; // Determine how many controls of this type there are.
     
        switch (count % 3) // Place the Control in  a column based on how many controls there are.
        {
            case 0: tableSelecter.Location = new System.Drawing.Point(11, (75 * (count / 3)) + 75); break;
            case 1: tableSelecter.Location = new System.Drawing.Point(530, (75 * (count / 3)) + 75); break;
            case 2: tableSelecter.Location = new System.Drawing.Point(1049, (75 * (count / 3)) + 75); break;
        }
        tableSelecter.Name = "tableSelecter_" + (count + 1);
        tableSelecter.RemoveControlButton.Click += new EventHandler(btnDelete_Click);
        this.Controls.Add(tableSelecter);
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
        Button button = (sender as Button);     //Reference the Button which was clicked.
        
        int index = int.Parse(button.Parent.Name.Split('_')[1]);    //Determine the Index of the Control.
        
        Controls.Remove(Controls.Find("tableSelecter_" + index, true)[0]);  //Find the Selecter using Index and remove it.
        
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>()) //Rearranging the Location controls.
        {
            int controlIndex = int.Parse(selecter.Name.Split('_')[1]);
            if (controlIndex > index)
            {
                selecter.Name = "tableSelecter_" + (controlIndex - 1);
                switch (controlIndex % 3) // Check which Column the Control is in.
                {
                    case 0: selecter.Left += -519; break;                       // Right Column
                    case 1: selecter.Top += -75; selecter.Left += 1038; break;  // Left Column
                    case 2: selecter.Left += -519; break;                       // Center Column
                }
            }
            selecter.Name = "tableSelecter_" + (controlIndex - 1); // Rename Control for furture rearranging.
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
        LoadOutModel loadOutModel= new LoadOutModel();
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>())
        {
            loadOutModel.Tables.Add(selecter.TableNamesComboBox.Items[selecter.TableNamesComboBox.SelectedIndex].ToString());
        }
        loadOutModel.Name = "Test1";
        SaveLoadOuts();
    }
    private void SaveLoadOuts()
    {

    }
}
