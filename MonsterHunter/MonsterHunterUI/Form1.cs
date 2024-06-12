using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using gamedll;


namespace GravityGame
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer pl = new System.Media.SoundPlayer();
        public static Game game;
        public static int Score;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            pl.SoundLocation ="bgvoice.wav";
            pl.Play();
            if(pl.IsLoadCompleted)
            {
                pl.PlayLooping();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFormFunc();
           
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                game.FirePlayer(Properties.Resources.fire_removebg_preview);
            }
            game.RemoveGameObject();
            game.update();
            Score = ((game.GetEnemiesCount() - game.GetCurrentEnemiesCount()) * 100);
            label3.Text = Score.ToString();
            if (game.GetCurrentEnemiesCount() == 0 || game.GetCurrentPlayersCount() == 0)
            { 
                this.Close();
                Form gameover = new GameOver();
                gameover.Show();
            }
        }


        private void loadFormFunc()
        {
            game = Game.GetGameInstance(this);

            System.Drawing.Point boundary = new System.Drawing.Point(this.Width - 100, this.Height - 200);

            game.addGameObject(Properties.Resources.p101_removebg_preview, GameObjectType.Player, 100, 80, new KeyBoardMovement(10, boundary));

            game.addGameObject(Properties.Resources.p1_removebg_preview, GameObjectType.Enemy, 900, 10, new VerticalMov(10, boundary, Direction.Down));
            game.addGameObject(Properties.Resources.enemy, GameObjectType.Enemy, 400, 400, new HorizontalMov(6, boundary, Direction.Left));
            game.addGameObject(Properties.Resources.enemy1, GameObjectType.Enemy, 850, 600, new ZigZagMovement(10, boundary));
            game.addGameObject(Properties.Resources.enemy2, GameObjectType.Enemy, 600, 10, new VerticalMov(7, boundary, Direction.Down));

            CollisionDetection collisionDetection1 = new CollisionDetection(GameObjectType.Player, GameObjectType.Enemy, CollisionAction.DecreaseHealth);
            CollisionDetection collisionDetection2 = new CollisionDetection(GameObjectType.PlayerFire, GameObjectType.Enemy, CollisionAction.Kill);
            CollisionDetection collisionDetection3 = new CollisionDetection(GameObjectType.EnemyFire, GameObjectType.Player, CollisionAction.DecreasePlayerHealthByBullet);
            game.AddCollisionDetection(collisionDetection1);
            game.AddCollisionDetection(collisionDetection2);
            game.AddCollisionDetection(collisionDetection3);
        }

        private void Enemyfiring_Tick(object sender, EventArgs e)
        {
            game.FireEnemy(Properties.Resources.efire);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
