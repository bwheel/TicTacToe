using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player1;
        private Player player2;
        private Player currentPlayer;
        private GameMode gameMode;
        private GameState gameState;

        private Button[,] board;
        public MainWindow()
        {
            gameMode = GameMode.AI;
            gameState = GameState.Setup;
            player1 = new Player("1", "X");
            player2 = new Player("2", "O");
            currentPlayer = player1;
            board = new Button[3,3];
            InitializeComponent();

            board[0,0] = btn_11;
            board[0,1] = btn_12;
            board[0,2] = btn_13;

            board[1,0] = btn_21;
            board[1,1] = btn_22;
            board[1,2] = btn_23;

            board[2,0] = btn_31;
            board[2,1] = btn_32;
            board[2,2] = btn_33;
        }

        private bool threeInRow()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0].Content.ToString() == currentPlayer.Move &&
                    board[i,1].Content.ToString() == currentPlayer.Move &&
                    board[i,2].Content.ToString() == currentPlayer.Move)
                {
                    return true;
                }
            }
            return false;
        }

        private bool threeInColumn()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0,i].Content.ToString() == currentPlayer.Move &&
                    board[1,i].Content.ToString() == currentPlayer.Move &&
                    board[2,i].Content.ToString() == currentPlayer.Move)
                {
                    return true;
                }
            }
            return false;
        }

        private bool threeInDiagonal()
        {
            if ((board[0,0].Content.ToString() == currentPlayer.Move &&
                 board[1,1].Content.ToString() == currentPlayer.Move &&
                 board[2,2].Content.ToString() == currentPlayer.Move) ||
                (board[0,2].Content.ToString() == currentPlayer.Move &&
                 board[1,1].Content.ToString() == currentPlayer.Move &&
                 board[2,0].Content.ToString() == currentPlayer.Move))
            {
                return true;
            }
            return false;
        }

        private void updateGame(Button btn)
        {
            updateButton(btn);
            
            if(threeInRow() || threeInColumn() || threeInDiagonal())
            {
                // Step 1. disable all buttons.
                enableAllButtons(false);

                // Step 2. update instruction
                lblInstructions.Content = $"Player {currentPlayer.Name} wins!";
                
            }
            else 
            {
                currentPlayer = (currentPlayer == player1) ? player2 : player1;
                lblInstructions.Content = $"Player {currentPlayer.Name} turn.";

                if(gameMode == GameMode.AI && currentPlayer == player2)
                {
                    Thread.Sleep(100);
                    Button guess = generateGuess();
                    updateGame(guess);
                }
            }
        }

        private Button generateGuess()
        {
            Random rng = new Random();
            Button guess = null;
            while (guess == null)
            {
                int x = rng.Next(0, 3);
                int y = rng.Next(0, 3);
                if(string.IsNullOrWhiteSpace(board[x,y].Content.ToString()))
                {
                    guess = board[x,y];
                }
            }
            return guess;
            
        }

        private void enableAllButtons(bool enabled)
        {
            btn_11.IsEnabled = enabled;
            btn_12.IsEnabled = enabled;
            btn_13.IsEnabled = enabled;
            btn_21.IsEnabled = enabled;
            btn_22.IsEnabled = enabled;
            btn_23.IsEnabled = enabled;
            btn_31.IsEnabled = enabled;
            btn_32.IsEnabled = enabled;
            btn_33.IsEnabled = enabled;
        }

        private void updateButton(Button btn)
        {
            btn.Content = currentPlayer.Move;
            btn.IsEnabled = false;
        }

        private void btn_11_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_11);
        }

        private void btn_12_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_12);
        }

        private void btn_13_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_13);
        }

        private void btn_21_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_21);
        }

        private void btn_22_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_22);
        }

        private void btn_23_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_23);
        }

        private void btn_31_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_31);
        }

        private void btn_32_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_32);
        }

        private void btn_33_Click(object sender, RoutedEventArgs e)
        {
            updateGame(btn_33);
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            enableAllButtons(true);
            clearAllButtons();
        }

        private void clearAllButtons()
        {
            btn_11.Content = string.Empty;
            btn_12.Content = string.Empty;
            btn_13.Content = string.Empty;

            btn_21.Content = string.Empty;
            btn_22.Content = string.Empty;
            btn_23.Content = string.Empty;

            btn_31.Content = string.Empty;
            btn_32.Content = string.Empty;
            btn_33.Content = string.Empty;
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void radBtnAiMode_Checked(object sender, RoutedEventArgs e)
        {
            btnNewGame_Click(null, null);
            gameMode = GameMode.AI;
        }

        private void radBtnTwoPlayerMode_Checked(object sender, RoutedEventArgs e)
        {
            btnNewGame_Click(null, null);
            gameMode = GameMode.TwoPlayer;
        }
    }
}
