using CustomRandomizer.Forms;
using CustomRandomizer.Logic;
using CustomRandomizer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomRandomizer.UserControls;

public partial class TableSelecterControl : UserControl
{
    private List<string> _usedResults = new();
    private List<TableModel> _tables;
    public TableSelecterControl()
    {
        InitializeComponent();
        //if (!this.DesignMode) return; //Delete this before running code.
        _tables = RandomizerForm.Tables;
        LoadComboBox();
    }

    private void LoadComboBox()
    {
        TableNamesComboBox.Items.Clear();
        TableNamesComboBox.Items.AddRange(_tables.Select(x => x.Name).ToArray());
        TableNamesComboBox.SelectedIndex = 0;
    }

    public void RerollButton_Click(object sender, EventArgs e)
    {
        ResultsLabel.Text = Test(_tables.Where(x => x.Name == TableNamesComboBox.Text).FirstOrDefault());
    }

    public void RemoveControlButton_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
    private void TableNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ResetSelection();
    }

    public void ResetSelection()
    {
        _usedResults.Clear();
    }
    private string Test(TableModel table)
    {
        string output;
        do
        {
            output = RandomizerLogic.RunTable(_tables, table);
            if(_usedResults.Count == table.TableItems.Count) _usedResults.Clear();
        } while (_usedResults.Contains(output));
       
        _usedResults.Add(output);
        return output;//RandomizerLogic.RunTable(_tables, table);
    }
}
