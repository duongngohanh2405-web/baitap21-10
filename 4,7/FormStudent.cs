namespace MdiApp;

public partial class FormStudent : ChildBase
{
    private readonly BindingSource _bs = new();

    public FormStudent()
    {
        InitializeComponent();

        _bs.DataSource = DataStore.Students;
        dgv.AutoGenerateColumns = true;
        dgv.DataSource = _bs;

        dgv.Columns[nameof(Student.StudentId)].HeaderText = "Mã SV";
        dgv.Columns[nameof(Student.FullName)].HeaderText = "Họ tên";
        dgv.Columns[nameof(Student.FullName)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgv.Columns[nameof(Student.Age)].HeaderText = "Tuổi";
    }

    // Cha gọi hàm này (nút "Làm mới" trên ToolStrip của FormMain)
    public override void ReloadData()
    {
        _bs.ResetBindings(false);
        ReportStatus($"[{CurrentUser}] Đã làm mới danh sách sinh viên ({_bs.Count} dòng).");
    }

    // ---------------- Thêm ----------------
    private void btnAdd_Click(object sender, EventArgs e)
    {
        string id = txtId.Text.Trim();
        string name = txtName.Text.Trim();

        if (id.Length == 0 || name.Length == 0)
        {
            Warn("Vui lòng nhập Mã SV và Họ tên.", id.Length == 0 ? txtId : txtName);
            return;
        }
        if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 120)
        {
            Warn("Tuổi phải là số từ 1 đến 120.", txtAge);
            return;
        }
        if (DataStore.Students.Any(s => string.Equals(s.StudentId, id, StringComparison.OrdinalIgnoreCase)))
        {
            Warn("Mã SV đã tồn tại.", txtId);
            return;
        }

        DataStore.Students.Add(new Student { StudentId = id, FullName = name, Age = age });
        _bs.Position = _bs.Count - 1;

        txtId.Clear();
        txtName.Clear();
        txtAge.Clear();
        txtId.Focus();

        // Con -> Cha: báo thao tác thành công
        ReportStatus($"[{CurrentUser}] Đã thêm sinh viên {id} - {name}.");
    }

    // ---------------- Menu ngữ cảnh ----------------
    private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        // Chuột phải: chọn luôn dòng được bấm
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
        if (_bs.Current is not Student s) return;

        var confirm = MessageBox.Show($"Xóa sinh viên \"{s.FullName}\" ({s.StudentId})?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        _bs.RemoveCurrent();
        ReportStatus($"[{CurrentUser}] Đã xóa sinh viên {s.StudentId}.");
    }

    private void mnuRefresh_Click(object sender, EventArgs e) => ReloadData();

    private void mnuDetail_Click(object sender, EventArgs e)
    {
        if (_bs.Current is not Student s) return;

        MessageBox.Show($"Mã SV: {s.StudentId}\nHọ tên: {s.FullName}\nTuổi: {s.Age}",
            "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ReportStatus($"[{CurrentUser}] Đang xem chi tiết sinh viên {s.StudentId}.");
    }

    private static void Warn(string message, Control focus)
    {
        MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }
}
