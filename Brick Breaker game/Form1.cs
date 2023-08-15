using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brick_Breaker_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Ball_x = 4;
        int Ball_y = 4;
        int score = 0;

        private void Game_over()
        {
            if (score > 17)
            {
                timer1.Stop();
                MessageBox.Show("Вы победили...");
            }
            if (ball.Top + ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Игра окончена. Вы проиграли...");
            }
        }

        private void Get_Score()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "block")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        Ball_y = -Ball_y;
                        score++;
                        lbl_score.Text = "Счёт : " + score;
                    }
                }
            }
        }

        private void Ball_Movment()
        {
            ball.Left += Ball_x;
            ball.Top += Ball_y;
            if (ball.Left + ball.Width > ClientSize.Width || ball.Left < 0)
            {
                Ball_x = -Ball_x;
            }
            if (ball.Top < 0 || ball.Bounds.IntersectsWith(player.Bounds))
            {
                Ball_y = -Ball_y;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //перемещение платформы влево и вправо
        {
            if (e.KeyCode == Keys.Left && player.Left > 4) // движение влево, от левой границы 4 пикселя
            {
                player.Left -= 5; //шаг перемещения
            }
            if (e.KeyCode == Keys.Right && player.Right < 481) // движение вправо, длина 481 от левой границы до правой 
            {
                player.Left += 6; //шаг перемещения
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball_Movment();
            Get_Score();
            Game_over();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обИгреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Классическая аркадная игра.", "Brick Breaker");
        }
    }
}
