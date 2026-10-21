namespace MdiApp;

public partial class FormLogin : Form
{
    public string UserName { get; private set; } = "";

    public FormLogin()
    {
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtUser.Text.Trim();
        if (user.Length == 0)
        {
            MessageBox.Show("Vui lòng nhập tên người dùng.", "Đăng nhập",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUser.Focus();
            return;
        }

        UserName = user;
        DialogResult = DialogResult.OK;
    }
}
