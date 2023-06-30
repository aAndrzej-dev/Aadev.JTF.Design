namespace Aadev.JTF.Design;

partial class JtSuggestionCollectionEditForm
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
        rbCustomSource = new RadioButton();
        rbInline = new RadioButton();
        cbCustomSource = new ComboBox();
        lbSuggestions = new ListBox();
        btnSave = new Button();
        btnAddSuggestion = new Button();
        btnAddCollection = new Button();
        btnRemove = new Button();
        SuspendLayout();
        // 
        // rbCustomSource
        // 
        rbCustomSource.AutoCheck = false;
        rbCustomSource.AutoSize = true;
        rbCustomSource.Location = new Point(12, 12);
        rbCustomSource.Name = "rbCustomSource";
        rbCustomSource.Size = new Size(125, 19);
        rbCustomSource.TabIndex = 0;
        rbCustomSource.TabStop = true;
        rbCustomSource.Text = "Use custom source";
        rbCustomSource.UseVisualStyleBackColor = true;
        rbCustomSource.CheckedChanged += RbCustomSource_CheckedChanged;
        rbCustomSource.Click += RbCustomSource_Click;
        // 
        // rbInline
        // 
        rbInline.AutoCheck = false;
        rbInline.AutoSize = true;
        rbInline.Location = new Point(12, 37);
        rbInline.Name = "rbInline";
        rbInline.Size = new Size(138, 19);
        rbInline.TabIndex = 1;
        rbInline.TabStop = true;
        rbInline.Text = "Use inline declaration";
        rbInline.UseVisualStyleBackColor = true;
        rbInline.Click += RbInline_Click;
        // 
        // txtCustomSource
        // 
        cbCustomSource.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cbCustomSource.Location = new Point(143, 11);
        cbCustomSource.Name = "txtCustomSource";
        cbCustomSource.Size = new Size(645, 23);
        cbCustomSource.TabIndex = 2;
        cbCustomSource.Leave += TxtCustomSource_Leave;
        // 
        // lbSuggestions
        // 
        lbSuggestions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lbSuggestions.DrawMode = DrawMode.OwnerDrawFixed;
        lbSuggestions.IntegralHeight = false;
        lbSuggestions.ItemHeight = 24;
        lbSuggestions.Location = new Point(12, 62);
        lbSuggestions.Name = "lbSuggestions";
        lbSuggestions.Size = new Size(776, 334);
        lbSuggestions.TabIndex = 3;
        lbSuggestions.DrawItem += LbSuggestions_DrawItem;
        lbSuggestions.SelectedIndexChanged += LbSuggestions_SelectedIndexChanged;
        lbSuggestions.MouseDoubleClick += LbSuggestions_MouseDoubleClick;
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSave.Location = new Point(713, 415);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(75, 23);
        btnSave.TabIndex = 4;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += BtnSave_Click;
        // 
        // btnAddSuggestion
        // 
        btnAddSuggestion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnAddSuggestion.Location = new Point(12, 415);
        btnAddSuggestion.Name = "btnAddSuggestion";
        btnAddSuggestion.Size = new Size(125, 23);
        btnAddSuggestion.TabIndex = 6;
        btnAddSuggestion.Text = "Add Suggestion";
        btnAddSuggestion.UseVisualStyleBackColor = true;
        btnAddSuggestion.Click += BtnAddSuggestion_Click;
        // 
        // btnAddCollection
        // 
        btnAddCollection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnAddCollection.Location = new Point(143, 415);
        btnAddCollection.Name = "btnAddCollection";
        btnAddCollection.Size = new Size(125, 23);
        btnAddCollection.TabIndex = 7;
        btnAddCollection.Text = "Add Collection";
        btnAddCollection.UseVisualStyleBackColor = true;
        btnAddCollection.Click += BtnAddCollection_Click;
        // 
        // btnRemove
        // 
        btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnRemove.Location = new Point(274, 415);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(75, 23);
        btnRemove.TabIndex = 7;
        btnRemove.Text = "Remove";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += BtnRemove_Click;
        // 
        // JtSuggestionCollectionEditForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnRemove);
        Controls.Add(btnAddCollection);
        Controls.Add(btnAddSuggestion);
        Controls.Add(btnSave);
        Controls.Add(lbSuggestions);
        Controls.Add(cbCustomSource);
        Controls.Add(rbInline);
        Controls.Add(rbCustomSource);
        Name = "JtSuggestionCollectionEditForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Suggestions Collection Editor";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RadioButton rbCustomSource;
    private RadioButton rbInline;
    private ComboBox cbCustomSource;
    private ListBox lbSuggestions;
    private Button btnSave;
    private Button btnAddSuggestion;
    private Button btnAddCollection;
    private Button btnRemove;
}