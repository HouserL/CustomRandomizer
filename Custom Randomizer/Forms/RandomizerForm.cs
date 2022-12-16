using CustomRandomizer.Models;

namespace CustomRandomizer.Forms;

public partial class RandomizerForm : Form
{
    public static List<TableModel> Tables { get; private set; } = new();
    public RandomizerForm()
    {
        InitializeComponent();
        LoadTables();
    }

    private void LoadTables()
    {

    }

    private void AddTableSelector_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}
