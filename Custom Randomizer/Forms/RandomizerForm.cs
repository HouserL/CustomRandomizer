using CustomRandomizer.Models;
using CustomRandomizer.Logic;
using System.Linq;

namespace CustomRandomizer.Forms;

public partial class RandomizerForm : Form
{
    public static List<TableModel> Tables = new();
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
        //if (count % 2 != 0)
        //{
            tableSelecter.Location = new System.Drawing.Point(10, (70 * (count)) + 70);// Change x to 535 figure out how to run 2 rows. change count to be count / 2
        //}
        //else
        //{
        //    tableSelecter.Location = new System.Drawing.Point(10, (70 * (count / 2)) + 70);
        //}
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
        bool side = (index % 2 == 0);
        //Find the Selecter using Index and remove it.
        Controls.Remove(Controls.Find("tableSelecter_" + index, true)[0]);

        //Rearranging the Location controls.
        foreach (TableSelecterControl selecter in Controls.OfType<TableSelecterControl>())
        {
            int controlIndex = int.Parse(selecter.Name.Split('_')[1]);
            bool check = (controlIndex % 2 == 0);
            if (controlIndex > index)
            {
                selecter.Top = selecter.Top - 70;
                selecter.Name = "tableSelecter_" + (controlIndex - 1);
            }
            //else if (controlIndex > index && side == true)
            //{
            //    selecter.Left += -525;
            //    selecter.Name = "tableSelecter_" + (controlIndex - 1);
            //}
            //else if (controlIndex > index && side == false)
            //{
            //    selecter.Left += 525;
            //    selecter.Name = "tableSelecter_" + (controlIndex - 1);
            //}
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
}
