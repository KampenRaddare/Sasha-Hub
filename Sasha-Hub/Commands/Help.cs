namespace Sasha_Hub.Commands
{
    internal static class Help
    {
        internal static void OpenWindow()
        {
            // Open the help window to no specific command section
            HelpWindow HALP = new HelpWindow();
            HALP.Show();
        }

        internal static void OpenWindow(string command)
        {
            // Open the help window to specific command section
            System.Windows.MessageBox.Show("No help for you, you little bitch.");
        }
    }
}