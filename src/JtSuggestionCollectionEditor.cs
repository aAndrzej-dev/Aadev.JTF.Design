using System.ComponentModel;
using System.Drawing.Design;
using Aadev.JTF.Common;

namespace Aadev.JTF.Design;
internal class JtSuggestionCollectionEditor : UITypeEditor
{
    private JtSuggestionCollectionEditForm? editForm;
    public override object? EditValue(ITypeDescriptorContext? context, IServiceProvider provider, object? value)
    {
        editForm ??= new JtSuggestionCollectionEditForm();

        editForm.LoadCollection((IJtCommonSuggestionCollection?)value);

        editForm.ShowDialog();

        return editForm.GetSuggestionCollection();
    }
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext? context)
    {
        return UITypeEditorEditStyle.Modal;
    }
}
