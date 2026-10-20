namespace GymMSWF
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) =>
                MessageBox.Show(e.Exception.Message, "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Run(new LogInForm());
        }
    }
}