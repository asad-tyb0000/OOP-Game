using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gamedll;
namespace GravityGame
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            if (Form1.game.GetCurrentPlayersCount() == 0)
                StatusLabel.Text = "YOU LOST";
            if (Form1.game.GetCurrentEnemiesCount() == 0)
                StatusLabel.Text = "YOU WON";
            ScoreLabel.Text = (Form1.Score).ToString();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
