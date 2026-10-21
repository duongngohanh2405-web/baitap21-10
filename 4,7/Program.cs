namespace MdiApp;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        using var login = new FormLogin();
        if (login.ShowDialog() != DialogResult.OK) return;

        Application.Run(new FormMain(login.UserName));
    }
}
