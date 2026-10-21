using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentManager;

/// <summary>
/// Đối tượng sinh viên. Cài đặt INotifyPropertyChanged để khi đổi dữ liệu bằng code
/// (ví dụ gán AvatarPath) thì DataGridView / control liên kết tự cập nhật.
/// </summary>
public class Student : INotifyPropertyChanged
{
    private string _studentId = "";
    private string _fullName = "";
    private int _age = 18;
    private string _gender = "Nam";
    private string _avatarPath = "";

    public string StudentId
    {
        get => _studentId;
        set => SetField(ref _studentId, value);
    }

    public string FullName
    {
        get => _fullName;
        set => SetField(ref _fullName, value);
    }

    public int Age
    {
        get => _age;
        set => SetField(ref _age, value);
    }

    public string Gender
    {
        get => _gender;
        set => SetField(ref _gender, value);
    }

    public string AvatarPath
    {
        get => _avatarPath;
        set => SetField(ref _avatarPath, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
