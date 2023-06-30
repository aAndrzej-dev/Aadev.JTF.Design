using Aadev.JTF.Common;
using Aadev.JTF.CustomSources;
using Aadev.JTF.CustomSources.Declarations;

namespace Aadev.JTF.Design;
internal partial class JtSuggestionCollectionEditForm : Form
{
    private IJtCommonSuggestionCollection? jtSuggestionCollection;

    public JtSuggestionCollectionEditForm()
    {
        InitializeComponent();

    }

    protected override void OnShown(EventArgs e)
    {
        cbCustomSource.Items.Clear();
        lbSuggestions.Items.Clear();



        if (jtSuggestionCollection is null)
        {
            rbCustomSource.Checked = false;
            rbInline.Checked = true;
            return;
        }

        cbCustomSource.Items.AddRange(jtSuggestionCollection.SourceProvider.EnumerateCustomSources().OfType<CustomSourceDeclaration>().Where(x => x.Type == Aadev.JTF.CustomSources.CustomSourceType.SuggestionCollection).Select(x => $"@{x.Id.Value}").ToArray());


        if (!jtSuggestionCollection.DynamicSourceId.IsEmpty)
        {
            rbCustomSource.Checked = true;
            rbInline.Checked = false;
            cbCustomSource.Text = jtSuggestionCollection.DynamicSourceId.ToString();
            return;
        }

        if (jtSuggestionCollection.Base is CustomSource cs && cs.IsDeclared)
        {
            rbInline.Checked = false;
            rbCustomSource.Checked = true;
            cbCustomSource.Text = cs.Declaration.Name;
            return;
        }


        rbInline.Checked = true;
        rbCustomSource.Checked = false;
        foreach (IJtCommonSuggestionCollectionChild item in jtSuggestionCollection.Suggestions)
        {
            lbSuggestions.Items.Add(item);
        }

        base.OnShown(e);
    }
    public void LoadCollection(IJtCommonSuggestionCollection? jtSuggestionCollection)
    {

        this.jtSuggestionCollection = jtSuggestionCollection;


    }


    internal IJtCommonSuggestionCollection? GetSuggestionCollection() => jtSuggestionCollection;

    private void RbCustomSource_CheckedChanged(object sender, EventArgs e)
    {
        if (jtSuggestionCollection is null)
            return;
        if (rbCustomSource.Checked)
        {
            cbCustomSource.Enabled = true;
            lbSuggestions.Enabled = false;
            btnAddCollection.Enabled = false;
            btnAddSuggestion.Enabled = false;
            btnRemove.Enabled = false;
        }
        else
        {
            jtSuggestionCollection.DynamicSourceId = JtSourceReference.Empty;
            cbCustomSource.Enabled = false;
            lbSuggestions.Enabled = true;
            btnAddCollection.Enabled = true;
            btnAddSuggestion.Enabled = true;
            if (lbSuggestions.SelectedIndex >= 0)
            {
                btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
            }
        }
    }
    private void LbSuggestions_DrawItem(object sender, DrawItemEventArgs e)
    {
        Graphics g = e.Graphics;
        if (e.Index == -1)
            return;
        if ((e.State & DrawItemState.Selected) != 0)
        {
            using SolidBrush brush = new SolidBrush(lbSuggestions.Enabled ? SystemColors.Highlight : Color.DarkGray);
            g.FillRectangle(brush, e.Bounds);
        }
        else if (e.Index % 2 == 1)
        {
            using SolidBrush brush = new SolidBrush(Color.FromArgb(245, 245, 245));
            g.FillRectangle(brush, e.Bounds);
        }
        else
        {
            using SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            g.FillRectangle(brush, e.Bounds);
        }

        using SolidBrush displayNameBrush = new SolidBrush((lbSuggestions.Enabled || (e.State & DrawItemState.Selected) != 0) ? e.ForeColor : Color.FromArgb(50, 50, 50));
        using SolidBrush valueBrush = new SolidBrush((e.State & DrawItemState.Selected) != 0 ? Color.LightGray : Color.Gray);
        using Font valueFont = new Font(Font.FontFamily, 8, FontStyle.Regular);
        string valueText;
        string? itemText;

        if (lbSuggestions.Items[e.Index] is IJtCommonSuggestion suggestion)
        {
            valueText = $"({suggestion.StringValue})";
            itemText = lbSuggestions.GetItemText(suggestion);
        }
        else if (lbSuggestions.Items[e.Index] is IJtCommonSuggestionCollection collection)
        {
            valueText = string.Empty;

            if (!collection.DynamicSourceId.IsEmpty)
            {
                itemText = $"Suggestion Collection [Dynamic ({collection.DynamicSourceId})]";
            }
            else if (collection.Base?.IsDeclared is true)
            {
                itemText = $"Suggestion Collection [External ({collection.Base.Declaration.Name})]";
            }
            else
            {
                itemText = "Suggestion Collection";
            }
        }
        else
        {
            valueText = string.Empty;
            itemText = string.Empty;
        }


        SizeF textSize = g.MeasureString(itemText, Font);
        SizeF valueTextSize = g.MeasureString(valueText, valueFont);

        g.DrawString(itemText, base.Font, displayNameBrush, new PointF(16, e.Bounds.Top + (e.Bounds.Height / 2) - (textSize.Height / 2)));
        g.DrawString(valueText, valueFont, valueBrush, new PointF(32 + textSize.Width, e.Bounds.Top + (e.Bounds.Height / 2) - (valueTextSize.Height / 2)));

    }
    private void RbCustomSource_Click(object sender, EventArgs e)
    {
        rbInline.Checked = false;
        rbCustomSource.Checked = true;
    }

    private void RbInline_Click(object sender, EventArgs e)
    {
        rbInline.Checked = true;
        rbCustomSource.Checked = false;
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        if (jtSuggestionCollection is null)
            return;
        if (lbSuggestions.SelectedIndex == -1)
            return;

        IJtCommonSuggestionCollectionChild si = (IJtCommonSuggestionCollectionChild)lbSuggestions.Items[lbSuggestions.SelectedIndex];
        jtSuggestionCollection.Suggestions.Remove(si);
        lbSuggestions.Items.Remove(si);
    }

    private void BtnAddCollection_Click(object sender, EventArgs e)
    {
        if (jtSuggestionCollection is null)
            return;
        IJtCommonSuggestionCollection collection = jtSuggestionCollection.AddNewSuggestionCollection();

        lbSuggestions.Items.Add(collection);
        lbSuggestions.SelectedItem = collection;
    }

    private void BtnAddSuggestion_Click(object sender, EventArgs e)
    {
        if (jtSuggestionCollection is null)
            return;
        bool autoPaste = false;
        bool autoCreate = false;
        while (true)
        {
            using CreateNewSuggestionForm cnsf = new CreateNewSuggestionForm();
            cnsf.AutoPaste = autoPaste;
            cnsf.AutoCreate = autoCreate;
            if (cnsf.ShowDialog() == DialogResult.OK)
            {
                autoPaste = cnsf.AutoPaste;
                autoCreate = cnsf.AutoCreate;
                try
                {
                    IJtCommonSuggestion suggestion = jtSuggestionCollection.AddNewSuggestion(Convert.ChangeType(cnsf.SuggestionValue, jtSuggestionCollection.SuggestionType), cnsf.SuggestionDisplayName);
                    lbSuggestions.Items.Add(suggestion);
                    lbSuggestions.SelectedItem = suggestion;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                break;
            }
        }
    }


    private void LbSuggestions_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (jtSuggestionCollection is null)
            return;
        int index = lbSuggestions.IndexFromPoint(e.Location);
        if (index != ListBox.NoMatches)
        {
            if (lbSuggestions.Items[index] is IJtCommonSuggestionCollection collection)
            {
                using JtSuggestionCollectionEditForm scef = new JtSuggestionCollectionEditForm();
                scef.LoadCollection(collection);

                scef.ShowDialog();
            }
            else if (lbSuggestions.Items[index] is IJtCommonSuggestion suggestion)
            {
                using CreateNewSuggestionForm cnsf = new CreateNewSuggestionForm(suggestion);
                if (cnsf.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        suggestion.SetValue(Convert.ChangeType(cnsf.SuggestionValue, jtSuggestionCollection.SuggestionType));
                        suggestion.DisplayName = cnsf.SuggestionDisplayName;
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }

    private void TxtCustomSource_Leave(object sender, EventArgs e)
    {
        if (jtSuggestionCollection is null)
            return;
        JtSourceReference newId = cbCustomSource.Text;
        switch (newId.Type)
        {
            case JtSourceReferenceType.None:
            case JtSourceReferenceType.Local:
            case JtSourceReferenceType.Direct:
                break;
            case JtSourceReferenceType.Dynamic:
                jtSuggestionCollection.DynamicSourceId = newId;
                break;
            case JtSourceReferenceType.External:
                jtSuggestionCollection.DynamicSourceId = JtSourceReference.Empty;

                IJtSuggestionCollectionSource? b = (IJtSuggestionCollectionSource?)jtSuggestionCollection.SourceProvider.GetCustomSource(newId);

                if (b is null)
                {
                    MessageBox.Show(this, "Invalid custom source id or that source is different type", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbCustomSource.SelectAll();
                }
                else
                {
                    jtSuggestionCollection.Base = b;
                }

                break;
            default:
                break;
        }
    }

    private void LbSuggestions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lbSuggestions.Enabled && lbSuggestions.SelectedIndex >= 0)
        {
            btnRemove.Enabled = true;
        }
        else
        {
            btnRemove.Enabled = false;
        }
    }
}
