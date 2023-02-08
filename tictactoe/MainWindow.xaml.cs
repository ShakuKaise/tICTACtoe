using Microsoft.Windows.Themes;
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

namespace tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        Button[] buttons;
        Button RandomBtn;
        bool player = true;
        bool win;
        int stage = 0;
        int EnableCells;

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            stage = 0;
            player = ChangePlayer(player);
            buttons = new Button[9] {btn11, btn12, btn13, btn21, btn22, btn23, btn31, btn32, btn33};
            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (player)
            {
                button.Content = 'X';
                button.IsEnabled = false;
            }
            else
            {
                button.Content = 'O';
                button.IsEnabled = false;
            }
            
            if (CheckWin()) Win(buttons); // моя просто не понимать почему победа детектится через раз

            if (stage < 4)
            {
                RandomAI(player);
            }
            if (CheckWin()) Win(buttons);

            EnableCells = 0;
            foreach (Button btn in buttons)
            {
                if (!btn.IsEnabled) EnableCells++;
            }
            if (EnableCells == 9 & !win) MessageBox.Show("Ничья");
            stage++;
        }
        private void RandomAI(bool player)
        {
            buttons = new Button[9] { btn11, btn12, btn13, btn21, btn22, btn23, btn31, btn32, btn33 };
            while (true)
            {
                RandomBtn = buttons[rnd.Next(9)];
                if (RandomBtn.IsEnabled) break;
            }
            if (player)
            {
                RandomBtn.Content = "O";
            }
            else
            {
                RandomBtn.Content = "X";
            }
            RandomBtn.IsEnabled = false;
        }
        private bool CheckWin()
        {
            buttons = new Button[9] {btn11, btn12, btn13, btn21, btn22, btn23, btn31, btn32, btn33};
            
            win = false;
            
            if (btn11.Content == btn12.Content && btn12.Content == btn13.Content & btn11.Content != "")
            {
                MessageBox.Show($"Победили {btn11.Content}");
                win = true;
            }
            else if (btn21.Content == btn22.Content && btn22.Content == btn23.Content & btn21.Content != "")
            {
                MessageBox.Show($"Победили {btn21.Content}");
                win = true;
            }
            else if (btn31.Content == btn32.Content && btn32.Content == btn33.Content & btn31.Content != "")
            {
                MessageBox.Show($"Победили {btn31.Content}");
                win = true;
            }
            else if (btn11.Content == btn21.Content && btn21.Content == btn31.Content & btn11.Content != "")
            {
                MessageBox.Show($"Победили {btn11.Content}");
                win = true;
            }
            else if (btn12.Content == btn22.Content && btn22.Content == btn32.Content & btn12.Content != "")
            {
                MessageBox.Show($"Победили {btn21.Content}");
                win = true;
            }
            else if (btn13.Content == btn23.Content && btn23.Content == btn33.Content & btn13.Content != "")
            {
                MessageBox.Show($"Победили {btn31.Content}");
                win = true;
            }
            else if (btn11.Content == btn22.Content && btn22.Content == btn33.Content & btn11.Content != "")
            {
                MessageBox.Show($"Победили {btn11.Content}");
                win = true;
            }
            else if (btn13.Content == btn22.Content && btn22.Content == btn31.Content & btn13.Content != "")
            {
                MessageBox.Show($"Победили {btn11.Content}");
                win = true;
            }
            return win;
        }
        private bool ChangePlayer(bool player)
        {
            if (player)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Win(Button[] buttons)
        {
            foreach (Button btn in buttons)
            {
                btn.IsEnabled = false;
            }
        }
    }
}
