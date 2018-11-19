using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private CellTypes[] board;
        private bool HumanTurn;
        private bool GameEnded;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            //clears all cell contents
            board = new CellTypes[9];

            HumanTurn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //code for human turn
            if (HumanTurn)
            {
                if (GameEnded)
                {
                    NewGame();
                    return;
                }

                //casts the sender to a button
                var button = (Button)sender;

                //finds the button's position in the array
                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);

                var index = column + (3 * row);

                //don't do anything if the cell already contains a value
                if (board[index] != CellTypes.Free)
                {
                    return;
                }

                //sets the cell value to cross (human)
                board[index] = CellTypes.Cross;

                //sets the button text to "X"
                button.Content = "X";

                //moves the game onto AI turn
                HumanTurn = false;
            }

            //code for AI turn
            if (!HumanTurn)
            {
                Button02.Content = "O";
            }

            
        }

        private void CheckForWin()
        {
            if (board[0] !=
        }
    }
}
