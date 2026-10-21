namespace MdiApp;

partial class FormProduct
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
        lblPrice = new System.Windows.Forms.Label();
        txtPrice = new System.Windows.Forms.TextBox();
        lblQty = new System.Windows.Forms.Label();
        txtQty = new System.Windows.Forms.TextBox();
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
        lblId.Text = "Mã SP:";
        //
        // txtId
        //
        txtId.Location = new System.Drawing.Point(58, 14);
        txtId.Name = "txtId";
        txtId.Size = new System.Drawing.Size(70, 23);
        txtId.TabIndex = 0;
        //
        // lblName
        //
        lblName.AutoSize = true;
        lblName.Location = new System.Drawing.Point(138, 17);
        lblName.Name = "lblName";
        lblName.Text = "Tên:";
        //
        // txtName
        //
        txtName.Location = new System.Drawing.Point(170, 14);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(160, 23);
        txtName.TabIndex = 1;
        //
        // lblPrice
        //
        lblPrice.AutoSize = true;
        lblPrice.Location = new System.Drawing.Point(342, 17);
        lblPrice.Name = "lblPrice";
        lblPrice.Text = "Đơn giá:";
        //
        // txtPrice
        //
        txtPrice.Location = new System.Drawing.Point(398, 14);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new System.Drawing.Size(85, 23);
        txtPrice.TabIndex = 2;
        //
        // lblQty
        //
        lblQty.AutoSize = true;
        lblQty.Location = new System.Drawing.Point(495, 17);
        lblQty.Name = "lblQty";
        lblQty.Text = "SL:";
        //
        // txtQty
        //
        txtQty.Location = new System.Drawing.Point(522, 14);
        txtQty.Name = "txtQty";
        txtQty.Size = new System.Drawing.Size(50, 23);
        txtQty.TabIndex = 3;
        //
        // btnAdd
        //
        btnAdd.Location = new System.Drawing.Point(585, 12);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(100, 27);
        btnAdd.TabIndex = 4;
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
        dgv.Size = new System.Drawing.Size(676, 360);
        dgv.TabIndex = 5;
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
        // FormProduct
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(700, 420);
        Controls.Add(lblId);
        Controls.Add(txtId);
        Controls.Add(lblName);
        Controls.Add(txtName);
        Controls.Add(lblPrice);
        Controls.Add(txtPrice);
        Controls.Add(lblQty);
        Controls.Add(txtQty);
        Controls.Add(btnAdd);
        Controls.Add(dgv);
        Name = "FormProduct";
        Text = "Quản lý Sản phẩm";
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
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.TextBox txtPrice;
    private System.Windows.Forms.Label lblQty;
    private System.Windows.Forms.TextBox txtQty;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.DataGridView dgv;
    private System.Windows.Forms.ContextMenuStrip ctxGrid;
    private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
    private System.Windows.Forms.ToolStripMenuItem mnuDetail;
}
