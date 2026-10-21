namespace StudentManager;

partial class frmStudentManager
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
        bindingSource = new System.Windows.Forms.BindingSource(components);
        dgvStudents = new System.Windows.Forms.DataGridView();
        grpInfo = new System.Windows.Forms.GroupBox();
        picAvatar = new System.Windows.Forms.PictureBox();
        btnChooseImage = new System.Windows.Forms.Button();
        lblStudentId = new System.Windows.Forms.Label();
        txtStudentId = new System.Windows.Forms.TextBox();
        lblFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lblAge = new System.Windows.Forms.Label();
        txtAge = new System.Windows.Forms.TextBox();
        lblGender = new System.Windows.Forms.Label();
        cboGender = new System.Windows.Forms.ComboBox();
        btnAdd = new System.Windows.Forms.Button();
        btnUpdate = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        btnExportCsv = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
        grpInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
        SuspendLayout();
        //
        // dgvStudents
        //
        dgvStudents.AllowUserToAddRows = false;
        dgvStudents.AllowUserToDeleteRows = false;
        dgvStudents.AllowUserToResizeRows = false;
        dgvStudents.BackgroundColor = System.Drawing.SystemColors.Window;
        dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudents.Location = new System.Drawing.Point(12, 12);
        dgvStudents.MultiSelect = false;
        dgvStudents.Name = "dgvStudents";
        dgvStudents.ReadOnly = true;
        dgvStudents.RowHeadersVisible = false;
        dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvStudents.Size = new System.Drawing.Size(520, 420);
        dgvStudents.TabIndex = 0;
        //
        // grpInfo
        //
        grpInfo.Controls.Add(picAvatar);
        grpInfo.Controls.Add(btnChooseImage);
        grpInfo.Controls.Add(lblStudentId);
        grpInfo.Controls.Add(txtStudentId);
        grpInfo.Controls.Add(lblFullName);
        grpInfo.Controls.Add(txtFullName);
        grpInfo.Controls.Add(lblAge);
        grpInfo.Controls.Add(txtAge);
        grpInfo.Controls.Add(lblGender);
        grpInfo.Controls.Add(cboGender);
        grpInfo.Location = new System.Drawing.Point(548, 12);
        grpInfo.Name = "grpInfo";
        grpInfo.Size = new System.Drawing.Size(360, 420);
        grpInfo.TabIndex = 1;
        grpInfo.TabStop = false;
        grpInfo.Text = "Thông tin sinh viên";
        //
        // picAvatar
        //
        picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        picAvatar.Location = new System.Drawing.Point(105, 25);
        picAvatar.Name = "picAvatar";
        picAvatar.Size = new System.Drawing.Size(150, 170);
        picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picAvatar.TabIndex = 0;
        picAvatar.TabStop = false;
        //
        // btnChooseImage
        //
        btnChooseImage.Location = new System.Drawing.Point(105, 202);
        btnChooseImage.Name = "btnChooseImage";
        btnChooseImage.Size = new System.Drawing.Size(150, 30);
        btnChooseImage.TabIndex = 1;
        btnChooseImage.Text = "Chọn ảnh...";
        btnChooseImage.UseVisualStyleBackColor = true;
        btnChooseImage.Click += btnChooseImage_Click;
        //
        // lblStudentId
        //
        lblStudentId.AutoSize = true;
        lblStudentId.Location = new System.Drawing.Point(15, 255);
        lblStudentId.Name = "lblStudentId";
        lblStudentId.Size = new System.Drawing.Size(42, 15);
        lblStudentId.TabIndex = 2;
        lblStudentId.Text = "Mã SV:";
        //
        // txtStudentId
        //
        txtStudentId.Location = new System.Drawing.Point(95, 252);
        txtStudentId.Name = "txtStudentId";
        txtStudentId.Size = new System.Drawing.Size(250, 23);
        txtStudentId.TabIndex = 3;
        //
        // lblFullName
        //
        lblFullName.AutoSize = true;
        lblFullName.Location = new System.Drawing.Point(15, 292);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new System.Drawing.Size(45, 15);
        lblFullName.TabIndex = 4;
        lblFullName.Text = "Họ tên:";
        //
        // txtFullName
        //
        txtFullName.Location = new System.Drawing.Point(95, 289);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new System.Drawing.Size(250, 23);
        txtFullName.TabIndex = 5;
        //
        // lblAge
        //
        lblAge.AutoSize = true;
        lblAge.Location = new System.Drawing.Point(15, 329);
        lblAge.Name = "lblAge";
        lblAge.Size = new System.Drawing.Size(33, 15);
        lblAge.TabIndex = 6;
        lblAge.Text = "Tuổi:";
        //
        // txtAge
        //
        txtAge.Location = new System.Drawing.Point(95, 326);
        txtAge.Name = "txtAge";
        txtAge.Size = new System.Drawing.Size(250, 23);
        txtAge.TabIndex = 7;
        //
        // lblGender
        //
        lblGender.AutoSize = true;
        lblGender.Location = new System.Drawing.Point(15, 366);
        lblGender.Name = "lblGender";
        lblGender.Size = new System.Drawing.Size(60, 15);
        lblGender.TabIndex = 8;
        lblGender.Text = "Giới tính:";
        //
        // cboGender
        //
        cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboGender.FormattingEnabled = true;
        cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
        cboGender.Location = new System.Drawing.Point(95, 363);
        cboGender.Name = "cboGender";
        cboGender.Size = new System.Drawing.Size(250, 23);
        cboGender.TabIndex = 9;
        //
        // btnAdd
        //
        btnAdd.Location = new System.Drawing.Point(548, 445);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(84, 32);
        btnAdd.TabIndex = 2;
        btnAdd.Text = "Thêm";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // btnUpdate
        //
        btnUpdate.Location = new System.Drawing.Point(640, 445);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(84, 32);
        btnUpdate.TabIndex = 3;
        btnUpdate.Text = "Cập nhật";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        //
        // btnDelete
        //
        btnDelete.Location = new System.Drawing.Point(732, 445);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(84, 32);
        btnDelete.TabIndex = 4;
        btnDelete.Text = "Xóa";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // btnExportCsv
        //
        btnExportCsv.Location = new System.Drawing.Point(824, 445);
        btnExportCsv.Name = "btnExportCsv";
        btnExportCsv.Size = new System.Drawing.Size(84, 32);
        btnExportCsv.TabIndex = 5;
        btnExportCsv.Text = "Xuất CSV";
        btnExportCsv.UseVisualStyleBackColor = true;
        btnExportCsv.Click += btnExportCsv_Click;
        //
        // frmStudentManager
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(920, 490);
        Controls.Add(dgvStudents);
        Controls.Add(grpInfo);
        Controls.Add(btnAdd);
        Controls.Add(btnUpdate);
        Controls.Add(btnDelete);
        Controls.Add(btnExportCsv);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "frmStudentManager";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản lý Sinh viên";
        ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
        grpInfo.ResumeLayout(false);
        grpInfo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.BindingSource bindingSource;
    private System.Windows.Forms.DataGridView dgvStudents;
    private System.Windows.Forms.GroupBox grpInfo;
    private System.Windows.Forms.PictureBox picAvatar;
    private System.Windows.Forms.Button btnChooseImage;
    private System.Windows.Forms.Label lblStudentId;
    private System.Windows.Forms.TextBox txtStudentId;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblAge;
    private System.Windows.Forms.TextBox txtAge;
    private System.Windows.Forms.Label lblGender;
    private System.Windows.Forms.ComboBox cboGender;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnExportCsv;
}
