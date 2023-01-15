using System.Diagnostics;
using System.Windows.Forms;

namespace CustomRandomizer.UserControls;

public partial class TableConfigurerControl : UserControl
{
    private List<TableModel> _tables = new();
    private List<LoadOutModel> _loadOutModels = new();

    public TableConfigurerControl(List<TableModel> tables, List<LoadOutModel> loadOuts)
    {
        InitializeComponent();
        _tables = tables;
        _loadOutModels = loadOuts;
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
        var results = MessageBox.Show("This might cause some tables to not work any more. Would you like to remove any tables linked to this one as a result?",
                                                "Delete Table", MessageBoxButtons.YesNoCancel);
        if (results == DialogResult.Cancel) return;
        if(results == DialogResult.Yes) 
        {
            _tables.ForEach(x => x.CheckTables(GetCurrentTable().Name));
            _loadOutModels.ForEach(x => x.RemoveTable(GetCurrentTable().Name));
            //do something
        }
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
        var newname = TextBoxTableName.Text;
        TextBoxTableName.ReadOnly = !TextBoxTableName.ReadOnly;
        if (TextBoxTableName.ReadOnly == false) return;
        GetCurrentTable().Name = TextBoxTableName.Text;
        LoadList(GetCurrentTable());
        _loadOutModels.ForEach(x => x.UpdateTableNames(oldname, newname));
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
