using CustomRandomizer.Models;
using CustomRandomizer.Logic;
using System.Linq;

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
        int count = this.Controls.OfType<TableSelecterControl>().ToList().Count;
     
        switch (count % 3)
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
        //Reference the Button which was clicked.
        Button button = (sender as Button);
        //Determine the Index of the Control.
        int index = int.Parse(button.Parent.Name.Split('_')[1]);
        //Find the Selecter using Index and remove it.
        Controls.Remove(Controls.Find("tableSelecter_" + index, true)[0]);
        //Rearranging the Location controls.
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>())
        {
            int controlIndex = int.Parse(selecter.Name.Split('_')[1]);
            if (controlIndex > index)
            {
                selecter.Name = "tableSelecter_" + (controlIndex - 1);
                switch (controlIndex % 3)
                {
                    case 0:
                        selecter.Left += -519; break;
                    case 1:
                        selecter.Top += -75;
                        selecter.Left += 1038; break;
                    case 2:
                        selecter.Left += -519; break;
                }
            }
            selecter.Name = "tableSelecter_" + (controlIndex - 1);
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


    }
}
