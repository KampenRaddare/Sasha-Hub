namespace Sasha_Hub.Commands
{
    internal static class Commit
    {
        internal static void Suicide()
        {
            System.Windows.MessageBox.Show("Sasha killed herself!", "Suicide!");
            System.Environment.Exit(1);
        }

        internal static void Sudoku()
        {
            System.Windows.MessageBox.Show("Sasha committed Sudoku!", "Sudoku!");
            System.Environment.Exit(1);
        }
    }
}
