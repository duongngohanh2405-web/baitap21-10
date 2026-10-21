namespace MdiApp;

public partial class FormMain : Form
{
    private string _userName;

    public FormMain(string userName)
    {
        InitializeComponent();
        _userName = userName;

        ApplyIcons();
        ShowUser();
        UpdateClock();
        SetStatus("Sẵn sàng.");
    }

    // ---------------------------------------------------------------
    // Mở Form con: chưa mở -> tạo mới; đã mở -> chỉ Activate
    // ---------------------------------------------------------------
    private void OpenChild<T>() where T : ChildBase, new()
    {
        // Tìm trong danh sách MDI child xem đã có form kiểu T chưa
        var existing = MdiChildren.OfType<T>().FirstOrDefault();
        if (existing != null)
        {
            if (existing.WindowState == FormWindowState.Minimized)
                existing.WindowState = FormWindowState.Normal;

            existing.Activate(); // đưa lên trên cùng, KHÔNG mở lặp
            SetStatus($"Đã chuyển tới cửa sổ \"{existing.Text}\".");
            return;
        }

        // Cha -> Con: truyền dữ liệu (tên người dùng) qua thuộc tính
        var child = new T { MdiParent = this, CurrentUser = _userName };

        // Con -> Cha: đăng ký nhận thông điệp trạng thái
        child.StatusChanged += Child_StatusChanged;
        child.FormClosed += Child_FormClosed;

        child.Show();
        SetStatus($"Đã mở cửa sổ \"{child.Text}\".");
    }

    private void Child_StatusChanged(object sender, string message) => SetStatus(message);

    private void Child_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (sender is not ChildBase child) return;

        child.StatusChanged -= Child_StatusChanged;
        child.FormClosed -= Child_FormClosed;
        SetStatus($"Đã đóng cửa sổ \"{child.Text}\".");
    }

    // ---------------------------------------------------------------
    // StatusStrip
    // ---------------------------------------------------------------
    public void SetStatus(string message)
    {
        if (IsDisposed || Disposing) return;
        lblMessage.Text = message;
    }

    private void ShowUser() => lblUser.Text = $"Người dùng: {_userName}";

    private void UpdateClock() => lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

    private void timerClock_Tick(object sender, EventArgs e) => UpdateClock();

    // ---------------------------------------------------------------
    // Menu Hệ thống
    // ---------------------------------------------------------------
    private void menuLogout_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

        CloseAllChildren();
        Hide();

        using var login = new FormLogin();
        if (login.ShowDialog() == DialogResult.OK)
        {
            _userName = login.UserName;
            ShowUser();
            Show();
            SetStatus($"Xin chào {_userName}.");
        }
        else
        {
            Close();
        }
    }

    private void menuExit_Click(object sender, EventArgs e) => Close();

    // ---------------------------------------------------------------
    // Menu Danh mục + ToolStrip (dùng chung handler)
    // ---------------------------------------------------------------
    private void menuStudent_Click(object sender, EventArgs e) => OpenChild<FormStudent>();

    private void menuProduct_Click(object sender, EventArgs e) => OpenChild<FormProduct>();

    // Cha gọi hàm của Con đang hoạt động
    private void tsbRefresh_Click(object sender, EventArgs e)
    {
        if (ActiveMdiChild is ChildBase child)
            child.ReloadData();
        else
            SetStatus("Chưa có cửa sổ con nào đang mở.");
    }

    // ---------------------------------------------------------------
    // Menu Cửa sổ (cũng dùng cho ContextMenuStrip của FormMain)
    // ---------------------------------------------------------------
    private void menuCascade_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);

    private void menuTileH_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);

    private void menuTileV_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileVertical);

    private void menuCloseAll_Click(object sender, EventArgs e)
    {
        CloseAllChildren();
        SetStatus("Đã đóng tất cả cửa sổ con.");
    }

    private void CloseAllChildren()
    {
        foreach (var child in MdiChildren.ToArray())
            child.Close();
    }

    // ---------------------------------------------------------------
    // Icon tạo bằng code (không cần file ảnh)
    // ---------------------------------------------------------------
    private void ApplyIcons()
    {
        var studentIcon = CreateIcon("S", Color.SteelBlue);
        var productIcon = CreateIcon("P", Color.SeaGreen);
        var refreshIcon = CreateIcon("R", Color.DarkOrange);

        tsbStudent.Image = studentIcon;
        tsbProduct.Image = productIcon;
        tsbRefresh.Image = refreshIcon;
        menuStudent.Image = studentIcon;
        menuProduct.Image = productIcon;
    }

    private static Bitmap CreateIcon(string letter, Color color)
    {
        var bmp = new Bitmap(32, 32);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

        using var brush = new SolidBrush(color);
        g.FillEllipse(brush, 1, 1, 30, 30);

        using var font = new Font("Segoe UI", 16, FontStyle.Bold, GraphicsUnit.Pixel);
        using var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        g.DrawString(letter, font, Brushes.White, new RectangleF(0, 0, 32, 32), format);
        return bmp;
    }
}
