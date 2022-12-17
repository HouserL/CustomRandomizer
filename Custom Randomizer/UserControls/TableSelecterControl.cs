namespace CustomRandomizer.UserControls;
public partial class TableSelecterControl : UserControl
{
    private List<string> _usedResults = new();
    private List<TableModel> _tables;
    public TableSelecterControl()
    {
        InitializeComponent();
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
        ResultsLabel.Text = RandomizerLogic.RerunTable(_tables, _tables.FirstOrDefault(x => x.Name == TableNamesComboBox.Text), _usedResults);
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
}
