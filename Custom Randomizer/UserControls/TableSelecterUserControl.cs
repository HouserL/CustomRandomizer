using CustomRandomizer.Logic;
using CustomRandomizer.Forms;

namespace Custom_Randomizer.UserControls;

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
    }

    private void RerollButton_Click(object sender, EventArgs e)
    {
        _usedResults.Add(ResultsLabel.Text);
    }

    private void RemoveControlButton_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void RandomizeResults(string tableName)
    {
        RandomizerLogic.RunTable(tableName, RandomizerForm.Tables);
    }
}
