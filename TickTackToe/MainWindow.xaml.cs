using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TickTackToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player1;
        private Player player2;
        private Player currentPlayer;
        public MainWindow()
        {
            player1 = new Player("1", "X");
            player2 = new Player("2", "O");
            currentPlayer = player1;
            InitializeComponent();
        }

        private void updateGame(Button btn)
        {
            updateButton(btn);

            if ((btn_11.Content.ToString() == currentPlayer.Move && btn_12.Content.ToString() == currentPlayer.Move && btn_13.Content.ToString() == currentPlayer.Move) || // row 1
               (btn_21.Content.ToString() == currentPlayer.Move && btn_22.Content.ToString() == currentPlayer.Move && btn_23.Content.ToString() == currentPlayer.Move) || // row 2
               (btn_31.Content.ToString() == currentPlayer.Move && btn_32.Content.ToString() == currentPlayer.Move && btn_33.Content.ToString() == currentPlayer.Move) || // row 3
               (btn_11.Content.ToString() == currentPlayer.Move && btn_21.Content.ToString() == currentPlayer.Move && btn_31.Content.ToString() == currentPlayer.Move) || // col 1
               (btn_12.Content.ToString() == currentPlayer.Move && btn_22.Content.ToString() == currentPlayer.Move && btn_32.Content.ToString() == currentPlayer.Move) || // col 2
               (btn_13.Content.ToString() == currentPlayer.Move && btn_23.Content.ToString() == currentPlayer.Move && btn_33.Content.ToString() == currentPlayer.Move) || // col 3
               (btn_11.Content.ToString() == currentPlayer.Move && btn_22.Content.ToString() == currentPlayer.Move && btn_33.Content.ToString() == currentPlayer.Move) || // diagonal top-left to bottom-right
               (btn_13.Content.ToString() == currentPlayer.Move && btn_22.Content.ToString() == currentPlayer.Move && btn_31.Content.ToString() == currentPlayer.Move))   // diagonal top-right to bottom-left
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
            }
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
    }
}
