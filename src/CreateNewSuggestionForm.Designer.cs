namespace Aadev.JTF.Design;

partial class CreateNewSuggestionForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        txtValue = new TextBox();
        btnCreate = new Button();
        btnCancel = new Button();
        label2 = new Label();
        txtDisplayName = new TextBox();
        cbAutoPaste = new CheckBox();
        cbAutoCreate = new CheckBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 15);
        label1.Name = "label1";
        label1.Size = new Size(35, 15);
        label1.TabIndex = 0;
        label1.Text = "Value";
        // 
        // txtValue
        // 
        txtValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtValue.Location = new Point(96, 12);
        txtValue.Name = "txtValue";
        txtValue.Size = new Size(376, 23);
        txtValue.TabIndex = 0;
        txtValue.TextChanged += TxtName_TextChanged;
        // 
        // btnCreate
        // 
        btnCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCreate.Location = new Point(397, 86);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(75, 23);
        btnCreate.TabIndex = 2;
        btnCreate.Text = "Create";
        btnCreate.UseVisualStyleBackColor = true;
        btnCreate.Click += BtnCreate_Click;
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(316, 86);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 3;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += BtnCancel_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 44);
        label2.Name = "label2";
        label2.Size = new Size(78, 15);
        label2.TabIndex = 0;
        label2.Text = "Display name";
        // 
        // txtDisplayName
        // 
        txtDisplayName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtDisplayName.Location = new Point(96, 41);
        txtDisplayName.Name = "txtDisplayName";
        txtDisplayName.Size = new Size(376, 23);
        txtDisplayName.TabIndex = 1;
        // 
        // cbAutoPaste
        // 
        cbAutoPaste.AutoSize = true;
        cbAutoPaste.Location = new Point(12, 89);
        cbAutoPaste.Name = "cbAutoPaste";
        cbAutoPaste.Size = new Size(83, 19);
        cbAutoPaste.TabIndex = 4;
        cbAutoPaste.Text = "Auto Paste";
        cbAutoPaste.UseVisualStyleBackColor = true;
        cbAutoPaste.CheckedChanged += CbAutoPaste_CheckedChanged;
        // 
        // cbAutoCreate
        // 
        cbAutoCreate.AutoSize = true;
        cbAutoCreate.Location = new Point(101, 89);
        cbAutoCreate.Name = "cbAutoCreate";
        cbAutoCreate.Size = new Size(89, 19);
        cbAutoCreate.TabIndex = 5;
        cbAutoCreate.Text = "Auto Create";
        cbAutoCreate.UseVisualStyleBackColor = true;
        // 
        // CreateNewSuggestionForm
        // 
        AcceptButton = btnCreate;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(484, 121);
        Controls.Add(cbAutoCreate);
        Controls.Add(cbAutoPaste);
        Controls.Add(btnCancel);
        Controls.Add(btnCreate);
        Controls.Add(txtDisplayName);
        Controls.Add(label2);
        Controls.Add(txtValue);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MaximumSize = new Size(500, 160);
        MinimizeBox = false;
        MinimumSize = new Size(500, 160);
        Name = "CreateNewSuggestionForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "New Suggestion";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox txtValue;
    private Button btnCreate;
    private Button btnCancel;
    private Label label2;
    private TextBox txtDisplayName;
    private CheckBox cbAutoPaste;
    private CheckBox cbAutoCreate;
}