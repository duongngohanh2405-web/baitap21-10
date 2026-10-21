namespace MdiApp;

/// <summary>Giả lập nạp dữ liệu lớn từ CSDL / file bằng tác vụ ngầm.</summary>
public static class DataService
{
    private const int TotalRows = 100;
    private const int DelayPerRowMs = 30; // ~3 giây cho 100 dòng

    private static readonly string[] Ho = { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng" };
    private static readonly string[] Dem = { "Văn", "Thị" };
    private static readonly string[] Ten = { "An", "Bình", "Cường", "Dung", "Hải", "Khoa", "Lan", "Minh" };
    private static readonly string[] Items =
        { "Bàn phím", "Chuột", "Màn hình", "Tai nghe", "Webcam", "Laptop", "USB", "Loa" };

    public static async Task<List<Student>> LoadStudentsAsync(
        IProgress<int> progress, bool simulateError = false, CancellationToken ct = default)
    {
        // Task.Run: đẩy công việc nặng sang thread của ThreadPool, UI thread không bị chặn
        return await Task.Run(() =>
        {
            var list = new List<Student>();
            for (int i = 1; i <= TotalRows; i++)
            {
                ct.ThrowIfCancellationRequested();
                Thread.Sleep(DelayPerRowMs); // giả lập đọc CSDL (có thể thay bằng await Task.Delay)

                if (simulateError && i == 60)
                    throw new IOException("Mất kết nối tới cơ sở dữ liệu (giả lập lỗi).");

                list.Add(new Student
                {
                    StudentId = $"SV{i:000}",
                    FullName = $"{Ho[i % Ho.Length]} {Dem[i % Dem.Length]} {Ten[i % Ten.Length]}",
                    Age = 18 + i % 8
                });

                progress?.Report(i * 100 / TotalRows); // báo % về UI thread
            }
            return list;
        }, ct);
    }

    public static async Task<List<Product>> LoadProductsAsync(
        IProgress<int> progress, bool simulateError = false, CancellationToken ct = default)
    {
        return await Task.Run(() =>
        {
            var list = new List<Product>();
            for (int i = 1; i <= TotalRows; i++)
            {
                ct.ThrowIfCancellationRequested();
                Thread.Sleep(DelayPerRowMs);

                if (simulateError && i == 60)
                    throw new IOException("Mất kết nối tới cơ sở dữ liệu (giả lập lỗi).");

                list.Add(new Product
                {
                    ProductId = $"SP{i:000}",
                    ProductName = $"{Items[i % Items.Length]} mẫu {i}",
                    Price = 100000 + i * 15000,
                    Quantity = 5 + i % 30
                });

                progress?.Report(i * 100 / TotalRows);
            }
            return list;
        }, ct);
    }
}
