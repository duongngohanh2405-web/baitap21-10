namespace MdiApp;

public partial class FormProduct : ChildBase
{
    private readonly BindingSource _bs = new();

    public FormProduct()
    {
        InitializeComponent();

        _bs.DataSource = DataStore.Products;
        dgv.AutoGenerateColumns = true;
        dgv.DataSource = _bs;

        dgv.Columns[nameof(Product.ProductId)].HeaderText = "Mã SP";
        dgv.Columns[nameof(Product.ProductName)].HeaderText = "Tên sản phẩm";
        dgv.Columns[nameof(Product.ProductName)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgv.Columns[nameof(Product.Price)].HeaderText = "Đơn giá";
        dgv.Columns[nameof(Product.Price)].DefaultCellStyle.Format = "N0";
        dgv.Columns[nameof(Product.Quantity)].HeaderText = "Số lượng";
    }

    public override void ReloadData()
    {
        _bs.ResetBindings(false);
        ReportStatus($"[{CurrentUser}] Đã làm mới danh sách sản phẩm ({_bs.Count} dòng).");
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        string id = txtId.Text.Trim();
        string name = txtName.Text.Trim();

        if (id.Length == 0 || name.Length == 0)
        {
            Warn("Vui lòng nhập Mã SP và Tên sản phẩm.", id.Length == 0 ? txtId : txtName);
            return;
        }
        if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
        {
            Warn("Đơn giá phải là số không âm.", txtPrice);
            return;
        }
        if (!int.TryParse(txtQty.Text, out int qty) || qty < 0)
        {
            Warn("Số lượng phải là số nguyên không âm.", txtQty);
            return;
        }
        if (DataStore.Products.Any(p => string.Equals(p.ProductId, id, StringComparison.OrdinalIgnoreCase)))
        {
            Warn("Mã SP đã tồn tại.", txtId);
            return;
        }

        DataStore.Products.Add(new Product { ProductId = id, ProductName = name, Price = price, Quantity = qty });
        _bs.Position = _bs.Count - 1;

        txtId.Clear();
        txtName.Clear();
        txtPrice.Clear();
        txtQty.Clear();
        txtId.Focus();

        ReportStatus($"[{CurrentUser}] Đã thêm sản phẩm {id} - {name}.");
    }

    private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
        {
            dgv.ClearSelection();
            dgv.Rows[e.RowIndex].Selected = true;
            dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[Math.Max(e.ColumnIndex, 0)];
        }
    }

    private void ctxGrid_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        bool hasRow = _bs.Current != null;
        mnuDelete.Enabled = hasRow;
        mnuDetail.Enabled = hasRow;
    }

    private void mnuDelete_Click(object sender, EventArgs e)
    {
        if (_bs.Current is not Product p) return;

        var confirm = MessageBox.Show($"Xóa sản phẩm \"{p.ProductName}\" ({p.ProductId})?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        _bs.RemoveCurrent();
        ReportStatus($"[{CurrentUser}] Đã xóa sản phẩm {p.ProductId}.");
    }

    private void mnuRefresh_Click(object sender, EventArgs e) => ReloadData();

    private void mnuDetail_Click(object sender, EventArgs e)
    {
        if (_bs.Current is not Product p) return;

        MessageBox.Show($"Mã SP: {p.ProductId}\nTên: {p.ProductName}\nĐơn giá: {p.Price:N0}\nSố lượng: {p.Quantity}",
            "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ReportStatus($"[{CurrentUser}] Đang xem chi tiết sản phẩm {p.ProductId}.");
    }

    // ---------------- Nạp dữ liệu bất đồng bộ ----------------
    private async void btnLoad_Click(object sender, EventArgs e)
    {
        // LoadAsync tự xử lý try/catch/finally; await không chặn UI thread
        await LoadAsync("danh sách sản phẩm",
            (progress, ct) => DataService.LoadProductsAsync(progress, chkError.Checked, ct),
            list => DataStore.Replace(DataStore.Products, list));
    }

    private void btnCancelLoad_Click(object sender, EventArgs e) => CancelLoad();

    // Khóa / mở các nút theo trạng thái tác vụ
    protected override void OnLoadingStateChanged(bool loading)
    {
        btnLoad.Enabled = !loading;        // tránh bấm nạp trùng lặp
        btnCancelLoad.Enabled = loading;
        chkError.Enabled = !loading;
        btnAdd.Enabled = !loading;
    }

    // Cập nhật ProgressBar + Label phần trăm (chạy trên UI thread)
    protected override void OnProgressChanged(int percent)
    {
        progressBar.Value = Math.Clamp(percent, 0, 100);
        lblPercent.Text = $"{percent}%";
    }

    private static void Warn(string message, Control focus)
    {
        MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }
}
