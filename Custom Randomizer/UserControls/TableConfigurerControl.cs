namespace CustomRandomizer.UserControls;

public partial class TableConfigurerControl : UserControl
{
    private List<TableModel> _tables = new();

    public TableConfigurerControl(List<TableModel> tables)
    {
        InitializeComponent();
        _tables = tables;
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

    private TableModel GetCurrentTable()
    {
        return _tables.FirstOrDefault(x => x.Name == ListBoxTables.Text);
    }

    private void ListBoxTables_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeSelectedTable();
        ResizeColumns();
    }

    private void EditName_CheckedChanged(object sender, EventArgs e)
    {
        TextBoxTableName.ReadOnly = !TextBoxTableName.ReadOnly;
        GetCurrentTable().Name = TextBoxTableName.Text;
        LoadList();
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
