using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe.App
{
    public partial class MainForm : Form
    {
        private bool checkTurn;
        private Button[,] buttons;
        public MainForm()
        {
            InitializeComponent();
            checkTurn = false;
            buttons = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 },
            };
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Enabled)
            {
                if (checkTurn)
                {
                    button.Image = Properties.Resources.tac;
                }
                else
                {
                    button.Image = Properties.Resources.tic;
                }
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Enabled)
            {
                button.Image = null;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (checkTurn)
            {
                button.Image = Properties.Resources.tac;
            }
            else
            {
                button.Image = Properties.Resources.tic;
            }
            checkTurn = !checkTurn;
            button.Enabled = false;
            FindWinner(buttons, true);
            FindWinner(buttons, false);
        }

        public void FindWinner(Button[,] buttons, bool alignment)
        {
            bool hasWinner = false;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                hasWinner = true;
                for (int j = 1; j < buttons.GetLength(1); j++)
                {
                    if (alignment)
                    {
                        if (buttons[i, 0].Enabled || buttons[i, j].Enabled
                         || buttons[i, 0].Image.Size != buttons[i, j].Image.Size)
                        {
                            hasWinner = false;
                            break;
                        }
                    }
                    else
                    {
                        if (buttons[0, i].Enabled || buttons[j, i].Enabled
                         || buttons[0, i].Image.Size != buttons[j, i].Image.Size)
                        {
                            hasWinner = false;
                            break;
                        }
                    }
                }
                ShowWinner(hasWinner);
            }

            for (int i = 1; i < buttons.GetLength(0); i++)
            {
                hasWinner = true;
                if (alignment)
                {
                    if (buttons[0, 0].Enabled || buttons[i, i].Enabled
                     || buttons[0, 0].Image.Size != buttons[i, i].Image.Size)
                    {
                        hasWinner = false;
                        break;
                    }
                }
                else
                {
                    if (buttons[0, buttons.GetLength(1) - 1].Enabled || buttons[i, buttons.GetLength(1) - 1 - i].Enabled
                     || buttons[0, buttons.GetLength(1) - 1].Image.Size != buttons[i, buttons.GetLength(1) - 1 - i].Image.Size)
                    {
                        hasWinner = false;
                        break;
                    }
                }
            }
            ShowWinner(hasWinner);
        }

        public void ShowWinner(bool hasWinner)
        {
            if (hasWinner)
            {
                string winner = "";
                if (checkTurn)
                {
                    winner = "X";
                }
                else
                {
                    winner = "O";
                }

                MessageBox.Show("Winner is -" + winner);
                return;
            }
            else
            {
                return;
            }
        }

        public void NewGame()
        {
            foreach (var button in buttons)
            {
                button.Image = null;
                button.Enabled = true;
                checkTurn = false;
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            foreach (var button in buttons)
            {
                button.Image = null;
                button.Enabled = true;
                checkTurn = false;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
