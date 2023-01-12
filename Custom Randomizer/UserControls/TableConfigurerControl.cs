namespace CustomRandomizer.UserControls;

public partial class TableConfigurerControl : UserControl
{
    private List<TableModel> _tables = new();
    private List<LoadOutModel> _loudOutModels = new();

    public TableConfigurerControl(List<TableModel> tables, List<LoadOutModel> loadOuts)
    {
        InitializeComponent();
        _tables = tables;
        _loudOutModels = loadOuts;
        LoadList();
    }

    private void AddNewTable_Click(object sender, EventArgs e)
    {
        var table = new TableModel();
        table.Name = "New Table";
        _tables.Add(table);
        AddTableItem(table);
        LoadList(table);
        UpdateDataSource();
        ResizeColumns();
    }

    private void AddTableItem(TableModel table)
    {
        table.TableItems.Add(new());
    }

    private void RemoveTable_Click(object sender, EventArgs e)
    {
        _tables.Remove(GetCurrentTable());
        LoadList();
    }
    
    private void AddRow_Click(object sender, EventArgs e)
    {
        AddTableItem(GetCurrentTable());
        UpdateDataSource();
        ResizeColumns();
    }

    private void RemoveRow_Click(object sender, EventArgs e)
    {
        if (_tables.FirstOrDefault(x => x.Name == ListBoxTables.Text).TableItems.Count == 0) return;
       
        GetCurrentTable().TableItems.RemoveAt(TableItemsDataGridView.CurrentCell.RowIndex);
        UpdateDataSource();
        ResizeColumns();
    }

    private void TestTable_Click(object sender, EventArgs e)
    {
        RichTextBoxResults.Text = string.Empty;
        try
        {
            for (int i = 0; i < Convert.ToInt16(TextBoxTestNumber.Text.ToString()); i++) //Run Table for x times based on text box.
            {
                RichTextBoxResults.Text += RandomizerLogic.RunTable(_tables, GetCurrentTable()) + " ";
            }
        }
        catch (Exception)
        {
            return;
        }
    }

    private TableModel GetCurrentTable(string tableName = null)
    {
        if (tableName == null) tableName = ListBoxTables.Text;
        return _tables.FirstOrDefault(x => x.Name == tableName);
    }

    private void ListBoxTables_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeSelectedTable();
        ResizeColumns();
    }

    private void EditName_CheckedChanged(object sender, EventArgs e)
    {
        var oldname = GetCurrentTable().Name;
        TextBoxTableName.ReadOnly = !TextBoxTableName.ReadOnly;
        if (TextBoxTableName.ReadOnly == false) return;
        GetCurrentTable().Name = TextBoxTableName.Text;
        LoadList(GetCurrentTable());
        //_loudOutModels.Where(x => x.Name == GetCurrentTable().Name).ToList().ForEach(y => y. //Tables.ForEach(x => x.Replace(oldname, TextBoxTableName.Text)));
        _loudOutModels.ForEach(x => x.UpdateTableNames(oldname, TextBoxTableName.Text));
        // Work on fixing this currently not updating names properly for _loudOutModels when going back to Table selector controls.
    }

    private void LoadList(TableModel table = null)
    {
        ListBoxTables.Items.Clear();
        ListBoxTables.Items.AddRange(_tables.Select(x => x.Name).OrderBy(x => x).ToArray());
        ListBoxTables.SelectedIndex = 0;
        if (table != null) ListBoxTables.SelectedItem = table.Name;
    }

    private void ChangeSelectedTable(TableModel table = null)
    {   
        if(table == null) table = _tables.FirstOrDefault(x => x.Name == ListBoxTables.Text);
        TableItemsDataGridView.DataSource = table.TableItems;
        TextBoxTableName.Text = table.Name;
        label2.Text = $@"Total number of chances in table is x out of {table.TableTotalValue}";
    }

    private void ResizeColumns()
    {
        TableItemsDataGridView.Columns[0].Width = 65;
        TableItemsDataGridView.Columns[1].Width = 220;
        TableItemsDataGridView.Columns[2].Width = 70;
    }

    private void UpdateDataSource()
    {
        TableItemsDataGridView.DataSource = null;
        TableItemsDataGridView.DataSource = GetCurrentTable().TableItems;
    }
}
