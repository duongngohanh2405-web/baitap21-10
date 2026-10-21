namespace MdiApp;

/// <summary>
/// Lớp cơ sở cho mọi MDI Child. Định nghĩa "hợp đồng" giao tiếp với Form cha:
///  - Con -> Cha : sự kiện StatusChanged (cha lắng nghe và hiển thị lên StatusStrip).
///  - Cha -> Con : thuộc tính CurrentUser (cha gán khi tạo) và hàm ReloadData() (cha gọi).
/// </summary>
public class ChildBase : Form
{
    /// <summary>Con phát thông điệp; FormMain đăng ký nhận để cập nhật StatusStrip.</summary>
    public event EventHandler<string> StatusChanged;

    /// <summary>Tên người dùng đang đăng nhập, do FormMain truyền xuống.</summary>
    public string CurrentUser { get; set; } = "";

    protected void ReportStatus(string message) => StatusChanged?.Invoke(this, message);

    /// <summary>Cha có thể yêu cầu con nạp lại dữ liệu (lớp con override).</summary>
    public virtual void ReloadData() { }
}
