using System.ComponentModel;

namespace MdiApp;

public class Student
{
    public string StudentId { get; set; } = "";
    public string FullName { get; set; } = "";
    public int Age { get; set; }
}

public class Product
{
    public string ProductId { get; set; } = "";
    public string ProductName { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

/// <summary>Kho dữ liệu dùng chung trong bộ nhớ: đóng/mở lại form con vẫn giữ dữ liệu.</summary>
public static class DataStore
{
    public static BindingList<Student> Students { get; } = new()
    {
        new Student { StudentId = "SV001", FullName = "Nguyễn Văn An", Age = 20 },
        new Student { StudentId = "SV002", FullName = "Trần Thị Bình", Age = 19 },
        new Student { StudentId = "SV003", FullName = "Lê Hoàng Cường", Age = 21 },
    };

    public static BindingList<Product> Products { get; } = new()
    {
        new Product { ProductId = "SP001", ProductName = "Bàn phím cơ", Price = 850000, Quantity = 15 },
        new Product { ProductId = "SP002", ProductName = "Chuột không dây", Price = 320000, Quantity = 40 },
        new Product { ProductId = "SP003", ProductName = "Màn hình 24 inch", Price = 3200000, Quantity = 8 },
    };
}
