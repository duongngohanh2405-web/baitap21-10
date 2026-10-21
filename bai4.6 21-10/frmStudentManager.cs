using System.ComponentModel;
using System.Text;

namespace StudentManager;

public partial class frmStudentManager : Form
{
    // Ký tự phân cách CSV: ',' (chuẩn) hoặc ';' (Excel bản tiếng Việt thường dùng)
    private const char CsvSeparator = ',';

    private readonly BindingList<Student> _students = new();

    public frmStudentManager()
    {
        InitializeComponent();
        SetupData();
        SetupBinding();
        UpdateUiState();
        LoadAvatar();
    }

    // ---------------------------------------------------------------
    // Dữ liệu + Binding
    // ---------------------------------------------------------------
    private void SetupData()
    {
        _students.Add(new Student { StudentId = "SV001", FullName = "Nguyễn Văn An", Age = 20, Gender = "Nam" });
        _students.Add(new Student { StudentId = "SV002", FullName = "Trần Thị Bình", Age = 19, Gender = "Nữ" });
    }

    private void SetupBinding()
    {
        // BindingList<Student> -> BindingSource -> DataGridView
        bindingSource.DataSource = _students;
        dgvStudents.AutoGenerateColumns = true;
        dgvStudents.DataSource = bindingSource;

        dgvStudents.Columns[nameof(Student.StudentId)].HeaderText = "Mã SV";
        dgvStudents.Columns[nameof(Student.FullName)].HeaderText = "Họ tên";
        dgvStudents.Columns[nameof(Student.Age)].HeaderText = "Tuổi";
        dgvStudents.Columns[nameof(Student.Gender)].HeaderText = "Giới tính";
        dgvStudents.Columns[nameof(Student.AvatarPath)].HeaderText = "Ảnh đại diện";
        dgvStudents.Columns[nameof(Student.AvatarPath)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dgvStudents.Columns[nameof(Student.FullName)].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        // BindingSource -> các control nhập liệu (2 chiều)
        txtStudentId.DataBindings.Add("Text", bindingSource, nameof(Student.StudentId),
            false, DataSourceUpdateMode.OnPropertyChanged);

        txtFullName.DataBindings.Add("Text", bindingSource, nameof(Student.FullName),
            false, DataSourceUpdateMode.OnPropertyChanged);

        // Tuổi là int, TextBox là string -> bật formatting để tự chuyển đổi 2 chiều
        var ageBinding = new Binding("Text", bindingSource, nameof(Student.Age),
            true, DataSourceUpdateMode.OnPropertyChanged);
        ageBinding.BindingComplete += (s, e) =>
        {
            // Nhập sai định dạng số -> tô hồng ô Tuổi
            txtAge.BackColor = e.BindingCompleteState == BindingCompleteState.Success
                ? SystemColors.Window
                : Color.MistyRose;
        };
        txtAge.DataBindings.Add(ageBinding);

        cboGender.DataBindings.Add("SelectedItem", bindingSource, nameof(Student.Gender),
            true, DataSourceUpdateMode.OnPropertyChanged);

        // Đổi dòng đang chọn -> nạp lại ảnh
        bindingSource.CurrentChanged += (s, e) => LoadAvatar();
        bindingSource.ListChanged += (s, e) => UpdateUiState();
    }

    private void UpdateUiState()
    {
        bool hasData = bindingSource.Count > 0;
        grpInfo.Enabled = hasData;
        btnUpdate.Enabled = hasData;
        btnDelete.Enabled = hasData;
        btnExportCsv.Enabled = hasData;
    }

    // ---------------------------------------------------------------
    // Avatar
    // ---------------------------------------------------------------
    private void LoadAvatar()
    {
        var old = picAvatar.Image;
        picAvatar.Image = null;
        old?.Dispose();

        if (bindingSource.Current is Student s
            && !string.IsNullOrWhiteSpace(s.AvatarPath)
            && File.Exists(s.AvatarPath))
        {
            try
            {
                // Copy sang Bitmap để không khóa file ảnh trên đĩa
                using var img = Image.FromFile(s.AvatarPath);
                picAvatar.Image = new Bitmap(img);
            }
            catch (Exception ex) when (ex is OutOfMemoryException or ArgumentException)
            {
                // File không phải ảnh hợp lệ -> để trống
            }
        }
    }

    private void btnChooseImage_Click(object sender, EventArgs e)
    {
        if (bindingSource.Current is not Student student)
        {
            MessageBox.Show("Vui lòng chọn một sinh viên trước.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dlg = new OpenFileDialog
        {
            Title = "Chọn ảnh đại diện",
            Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
            CheckFileExists = true
        };

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        student.AvatarPath = dlg.FileName; // INotifyPropertyChanged -> lưới tự cập nhật
        LoadAvatar();
    }

    // ---------------------------------------------------------------
    // Thêm / Cập nhật / Xóa
    // ---------------------------------------------------------------
    private void btnAdd_Click(object sender, EventArgs e)
    {
        var student = new Student
        {
            StudentId = NextStudentId(),
            FullName = "Sinh viên mới",
            Age = 18,
            Gender = "Nam"
        };

        bindingSource.Add(student);
        bindingSource.Position = bindingSource.Count - 1; // chọn dòng vừa thêm

        txtFullName.Focus();
        txtFullName.SelectAll();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (bindingSource.Current is not Student current) return;

        bindingSource.EndEdit(); // chốt dữ liệu đang sửa trên các control

        if (string.IsNullOrWhiteSpace(current.StudentId))
        {
            Warn("Mã SV không được để trống.", txtStudentId);
            return;
        }
        if (string.IsNullOrWhiteSpace(current.FullName))
        {
            Warn("Họ tên không được để trống.", txtFullName);
            return;
        }
        if (current.Age is < 1 or > 120)
        {
            Warn("Tuổi phải nằm trong khoảng 1 - 120.", txtAge);
            return;
        }
        bool duplicated = _students.Any(x => !ReferenceEquals(x, current)
            && string.Equals(x.StudentId, current.StudentId, StringComparison.OrdinalIgnoreCase));
        if (duplicated)
        {
            Warn("Mã SV đã tồn tại.", txtStudentId);
            return;
        }

        bindingSource.ResetCurrentItem(); // làm mới dòng đang chọn trên lưới
        MessageBox.Show("Đã cập nhật thông tin sinh viên.", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (bindingSource.Current is not Student current) return;

        var confirm = MessageBox.Show($"Xóa sinh viên \"{current.FullName}\" ({current.StudentId})?",
            "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        bindingSource.RemoveCurrent();
        LoadAvatar();
    }

    private string NextStudentId()
    {
        int n = _students.Count + 1;
        string id;
        do
        {
            id = $"SV{n++:000}";
        } while (_students.Any(s => string.Equals(s.StudentId, id, StringComparison.OrdinalIgnoreCase)));
        return id;
    }

    private void Warn(string message, Control focusControl)
    {
        MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focusControl.Focus();
    }

    // ---------------------------------------------------------------
    // Xuất CSV
    // ---------------------------------------------------------------
    private void btnExportCsv_Click(object sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog
        {
            Title = "Xuất danh sách sinh viên",
            Filter = "CSV (*.csv)|*.csv",
            FileName = "DanhSachSinhVien.csv",
            DefaultExt = "csv",
            AddExtension = true,
            OverwritePrompt = true
        };

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(CsvSeparator, "StudentId", "FullName", "Age", "Gender", "AvatarPath"));

            foreach (var s in _students)
            {
                sb.AppendLine(string.Join(CsvSeparator,
                    CsvEscape(s.StudentId),
                    CsvEscape(s.FullName),
                    s.Age.ToString(),
                    CsvEscape(s.Gender),
                    CsvEscape(s.AvatarPath)));
            }

            // UTF-8 có BOM để Excel đọc đúng tiếng Việt
            File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

            MessageBox.Show($"Đã xuất {_students.Count} sinh viên ra:\n{dlg.FileName}", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            MessageBox.Show("Không thể ghi file: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>Bọc trong dấu ngoặc kép nếu chứa dấu phân cách, ngoặc kép hoặc xuống dòng.</summary>
    private static string CsvEscape(string value)
    {
        value ??= "";
        bool needQuote = value.Contains(CsvSeparator) || value.Contains('"')
                         || value.Contains('\n') || value.Contains('\r');
        return needQuote ? "\"" + value.Replace("\"", "\"\"") + "\"" : value;
    }
}
