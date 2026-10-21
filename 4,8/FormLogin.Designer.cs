namespace MdiApp;

partial class FormLogin
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
        lblUser = new System.Windows.Forms.Label();
        txtUser = new System.Windows.Forms.TextBox();
        btnLogin = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();
        //
        // lblUser
        //
        lblUser.AutoSize = true;
        lblUser.Location = new System.Drawing.Point(15, 23);
        lblUser.Name = "lblUser";
        lblUser.Size = new System.Drawing.Size(95, 15);
        lblUser.TabIndex = 0;
        lblUser.Text = "Tên người dùng:";
        //
        // txtUser
        //
        txtUser.Location = new System.Drawing.Point(120, 20);
        txtUser.Name = "txtUser";
        txtUser.Size = new System.Drawing.Size(180, 23);
        txtUser.TabIndex = 1;
        txtUser.Text = "admin";
        //
        // btnLogin
        //
        btnLogin.Location = new System.Drawing.Point(130, 70);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new System.Drawing.Size(80, 30);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Đăng nhập";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        //
        // btnCancel
        //
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnCancel.Location = new System.Drawing.Point(220, 70);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(80, 30);
        btnCancel.TabIndex = 3;
        btnCancel.Text = "Thoát";
        btnCancel.UseVisualStyleBackColor = true;
        //
        // FormLogin
        //
        AcceptButton = btnLogin;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new System.Drawing.Size(320, 120);
        Controls.Add(lblUser);
        Controls.Add(txtUser);
        Controls.Add(btnLogin);
        Controls.Add(btnCancel);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormLogin";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Đăng nhập";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblUser;
    private System.Windows.Forms.TextBox txtUser;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnCancel;
}
