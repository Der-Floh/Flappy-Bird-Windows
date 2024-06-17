namespace Flappy_Bird_Windows.Forms;

public sealed partial class TapToStartForm : Form
{
    public TapToStartForm()
    {
        InitializeComponent();
    }

    private void TapToStartForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
}
