using CustomRandomizer.Logic;
using CustomRandomizer.Forms;

namespace CustomRandomizer.UserControls;

public partial class TableSelecterUserControl : UserControl
{
    private List<string> _usedResults = new(); 
    public TableSelecterUserControl()
    {
        InitializeComponent();
        LoadComboBox();
    }

    private void LoadComboBox()
    {
        TableNamesComboBox.Items.Clear();
        TableNamesComboBox.Items.AddRange(RandomizerForm.Tables.ToArray());
        TableNamesComboBox.SelectedIndex = 0;
    }

    private void RerollButton_Click(object sender, EventArgs e)
    {
        _usedResults.Add(ResultsLabel.Text);
        string output;
        do
        {
            output = RandomizeResults(TableNamesComboBox.SelectedItem.ToString());
        } while (!_usedResults.Contains(output));
        ResultsLabel.Text = output;
    }

    private void RemoveControlButton_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private string RandomizeResults(string tableName)
    {
        return RandomizerLogic.RunTable(RandomizerForm.Tables, tableName);
    }
}
