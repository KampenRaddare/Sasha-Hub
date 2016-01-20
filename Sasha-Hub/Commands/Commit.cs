namespace Sasha_Hub.Commands
{
    internal static class Commit
    {
        internal static void Suicide()
        {
            System.Windows.MessageBox.Show("Sasha killed herself!", "Suicide!");
            System.Environment.Exit(1);
        }
    }
}
