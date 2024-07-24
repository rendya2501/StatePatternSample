namespace Heater;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // 例外時にメッセージボックスを表示する
        Application.ThreadException += Application_ThreadException;
        Application.Run(new Form1());
    }

    /// <summary>
    /// 例外時にメッセージボックスを表示する
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message);
    }
}