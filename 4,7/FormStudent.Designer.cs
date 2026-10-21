namespace MdiApp;

partial class FormStudent
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblId = new System.Windows.Forms.Label();
        txtId = new System.Windows.Forms.TextBox();
        lblName = new System.Windows.Forms.Label();
        txtName = new System.Windows.Forms.TextBox();
        lblAge = new System.Windows.Forms.Label();
        txtAge = new System.Windows.Forms.TextBox();
        btnAdd = new System.Windows.Forms.Button();
        dgv = new System.Windows.Forms.DataGridView();
        ctxGrid = new System.Windows.Forms.ContextMenuStrip(components);
        mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
        mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
        mnuDetail = new System.Windows.Forms.ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        ctxGrid.SuspendLayout();
        SuspendLayout();
        //
        // lblId
        //
        lblId.AutoSize = true;
        lblId.Location = new System.Drawing.Point(12, 17);
        lblId.Name = "lblId";
        lblId.Text = "Mã SV:";
        //
        // txtId
        //
        txtId.Location = new System.Drawing.Point(60, 14);
        txtId.Name = "txtId";
        txtId.Size = new System.Drawing.Size(90, 23);
        txtId.TabIndex = 0;
        //
        // lblName
        //
        lblName.AutoSize = true;
        lblName.Location = new System.Drawing.Point(165, 17);
        lblName.Name = "lblName";
        lblName.Text = "Họ tên:";
        //
        // txtName
        //
        txtName.Location = new System.Drawing.Point(215, 14);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(170, 23);
        txtName.TabIndex = 1;
        //
        // lblAge
        //
        lblAge.AutoSize = true;
        lblAge.Location = new System.Drawing.Point(400, 17);
        lblAge.Name = "lblAge";
        lblAge.Text = "Tuổi:";
        //
        // txtAge
        //
        txtAge.Location = new System.Drawing.Point(440, 14);
        txtAge.Name = "txtAge";
        txtAge.Size = new System.Drawing.Size(50, 23);
        txtAge.TabIndex = 2;
        //
        // btnAdd
        //
        btnAdd.Location = new System.Drawing.Point(505, 12);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(100, 27);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Thêm";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // dgv
        //
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgv.BackgroundColor = System.Drawing.SystemColors.Window;
        dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.ContextMenuStrip = ctxGrid;
        dgv.Location = new System.Drawing.Point(12, 48);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new System.Drawing.Size(616, 360);
        dgv.TabIndex = 4;
        dgv.CellMouseDown += dgv_CellMouseDown;
        //
        // ctxGrid
        //
        ctxGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuDelete, mnuRefresh, mnuDetail });
        ctxGrid.Name = "ctxGrid";
        ctxGrid.Opening += ctxGrid_Opening;
        //
        // mnuDelete
        //
        mnuDelete.Name = "mnuDelete";
        mnuDelete.Text = "Xóa dòng";
        mnuDelete.Click += mnuDelete_Click;
        //
        // mnuRefresh
        //
        mnuRefresh.Name = "mnuRefresh";
        mnuRefresh.Text = "Làm mới dữ liệu";
        mnuRefresh.Click += mnuRefresh_Click;
        //
        // mnuDetail
        //
        mnuDetail.Name = "mnuDetail";
        mnuDetail.Text = "Xem chi tiết";
        mnuDetail.Click += mnuDetail_Click;
        //
        // FormStudent
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(640, 420);
        Controls.Add(lblId);
        Controls.Add(txtId);
        Controls.Add(lblName);
        Controls.Add(txtName);
        Controls.Add(lblAge);
        Controls.Add(txtAge);
        Controls.Add(btnAdd);
        Controls.Add(dgv);
        Name = "FormStudent";
        Text = "Quản lý Sinh viên";
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ctxGrid.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblId;
    private System.Windows.Forms.TextBox txtId;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblAge;
    private System.Windows.Forms.TextBox txtAge;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.DataGridView dgv;
    private System.Windows.Forms.ContextMenuStrip ctxGrid;
    private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
    private System.Windows.Forms.ToolStripMenuItem mnuDetail;
}
