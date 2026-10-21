namespace MdiApp;

/// <summary>
/// Lớp cơ sở cho mọi MDI Child.
///  - Con -> Cha : sự kiện StatusChanged (cha hiển thị lên StatusStrip).
///  - Cha -> Con : CurrentUser, ReloadData().
///  - LoadAsync<T>: khung nạp dữ liệu bất đồng bộ + báo tiến trình + khóa/mở nút.
/// </summary>
public class ChildBase : Form
{
    public event EventHandler<string> StatusChanged;

    public string CurrentUser { get; set; } = "";

    protected void ReportStatus(string message) => StatusChanged?.Invoke(this, message);

    public virtual void ReloadData() { }

    // ---------------------------------------------------------------
    // Async loading
    // ---------------------------------------------------------------
    private CancellationTokenSource _cts;

    protected bool IsLoading => _cts != null;

    /// <summary>Lớp con override: khóa/mở nút Nạp, nút Hủy... theo trạng thái.</summary>
    protected virtual void OnLoadingStateChanged(bool loading) { }

    /// <summary>Lớp con override: cập nhật ProgressBar + Label phần trăm.</summary>
    protected virtual void OnProgressChanged(int percent) { }

    protected void CancelLoad() => _cts?.Cancel();

    protected async Task LoadAsync<T>(
        string what,
        Func<IProgress<int>, CancellationToken, Task<List<T>>> loader,
        Action<List<T>> apply)
    {
        if (_cts != null) return; // đang nạp rồi -> không chạy trùng

        _cts = new CancellationTokenSource();
        OnLoadingStateChanged(true);   // Enabled = false cho nút nạp
        OnProgressChanged(0);
        ReportStatus($"[{CurrentUser}] Đang nạp {what}... 0%");

        // Progress<int> được tạo trên UI thread -> callback tự chạy lại trên UI thread
        var progress = new Progress<int>(percent =>
        {
            if (IsDisposed) return;
            OnProgressChanged(percent);
            ReportStatus($"[{CurrentUser}] Đang nạp {what}... {percent}%");
        });

        try
        {
            // await: UI thread được giải phóng, form vẫn kéo thả / bấm menu được
            List<T> data = await loader(progress, _cts.Token);
            if (IsDisposed) return;

            apply(data);                      // chạy lại trên UI thread
            OnProgressChanged(100);
            ReportStatus($"[{CurrentUser}] Nạp {what} hoàn tất: {data.Count} dòng (100%).");
            MessageBox.Show($"Nạp {what} hoàn tất ({data.Count} dòng).", "Hoàn tất",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (OperationCanceledException)
        {
            if (IsDisposed) return;
            OnProgressChanged(0);
            ReportStatus($"[{CurrentUser}] Đã hủy nạp {what}.");
        }
        catch (Exception ex)
        {
            if (IsDisposed) return;
            OnProgressChanged(0);
            ReportStatus($"[{CurrentUser}] Lỗi khi nạp {what}: {ex.Message}");
            MessageBox.Show("Có lỗi khi nạp dữ liệu:\n" + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _cts?.Dispose();
            _cts = null;
            if (!IsDisposed)
                OnLoadingStateChanged(false); // Enabled = true cho nút nạp (dù thành công, hủy hay lỗi)
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        _cts?.Cancel(); // đóng form giữa chừng -> dừng tác vụ ngầm
        base.OnFormClosing(e);
    }
}
