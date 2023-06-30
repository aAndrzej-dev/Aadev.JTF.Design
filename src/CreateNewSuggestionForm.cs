using Aadev.JTF.Common;
using static Aadev.JTF.Design.PInvoke;
namespace Aadev.JTF.Design;
internal partial class CreateNewSuggestionForm : Form
{
    public string SuggestionValue => txtValue.Text;
    public string SuggestionDisplayName => txtDisplayName.Text;
    public CreateNewSuggestionForm()
    {
        InitializeComponent();
    }
    public CreateNewSuggestionForm(IJtCommonSuggestion suggestion)
    {
        InitializeComponent();
        txtValue.Text = suggestion.StringValue;
        txtDisplayName.Text = suggestion.DisplayName;

        btnCreate.Text = "Save";
        Text = "Edit Suggestion";
    }
    private void BtnCreate_Click(object sender, EventArgs e)
    {
        Create();
    }

    private void Create()
    {
        if (txtValue.Text.StartsWith(' ') || txtValue.Text.EndsWith(" "))
        {
            DialogResult dr = MessageBox.Show(this, "Value starts or ends with space. Do you want to trim it?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
            {
                txtValue.Text = txtValue.Text.TrimStart().TrimEnd();
            }
            else if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        DialogResult = DialogResult.OK;
    }

    private void BtnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
    private string oldName = string.Empty;
    private void TxtName_TextChanged(object sender, EventArgs e)
    {
        if (txtDisplayName.Text == oldName)
        {
            txtDisplayName.Text = txtValue.Text;
        }

        oldName = txtValue.Text;
    }


    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case 0x308:
                if (cbAutoPaste.Checked)
                {
                    txtValue.Text = Clipboard.GetText();
                    if (cbAutoCreate.Checked)
                    {
                        Create();
                    }
                }

                break;
            default:
                break;
        }

        base.WndProc(ref m);

    }

    internal bool AutoPaste { get => cbAutoPaste.Checked; set => cbAutoPaste.Checked = value; }
    internal bool AutoCreate { get => cbAutoCreate.Checked; set => cbAutoCreate.Checked = value; }

    private IntPtr? nextClipboard;
    private void CbAutoPaste_CheckedChanged(object sender, EventArgs e)
    {
        if (cbAutoPaste.Checked)
        {
            nextClipboard = SetClipboardViewer(Handle);
            cbAutoCreate.Enabled = true;
        }
        else
        {
            if (nextClipboard is IntPtr v)
            {
                ChangeClipboardChain(Handle, v);
            }

            cbAutoCreate.Enabled = false;
        }
    }
}
