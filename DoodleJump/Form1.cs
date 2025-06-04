using System.Diagnostics;
using System.Windows.Forms;

namespace DoodleJump
{
    public partial class Form1 : Form
    {
        Player player;
        private string _projectFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Init();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 15;
            timer1.Tick += Update;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            string playerSpritePath = Path.Combine(_projectFolderPath, $"Sprites\\IMG_3055.jpg");
            this.BackgroundImage = Image.FromFile(playerSpritePath);
            this.Width = 660;
            this.Height = 1200;
            this.Paint += new PaintEventHandler(OnRepaint);
        }

        public void Init()
        {
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 400));
            PlatformController.startPlatformPosY = 400;
            PlatformController.score = 0;
            PlatformController.GenerateStartSequence();
            PlatformController.bullets.Clear();
            PlatformController.enemies.Clear();
            PlatformController.bonuses.Clear();
            player = new Player();
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;
            //player.sprite = 
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.physics.dx = 20;
                    break;
                case "Left":
                    player.physics.dx = -20;
                    break;
                case "Space":
                    //player.sprite = 
                    PlatformController.CreateBullet(new PointF(player.physics.transform.position.X + player.physics.transform.size.Width / 2, 
                        player.physics.transform.position.Y));
                    break;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = "Score: " + PlatformController.score;

            if ((player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 200) || player.physics.StandartCollidePlayerWithObjects(true, false))
            {
                //PlatformController.Clear();
                Init();
            }

            player.physics.StandartCollidePlayerWithObjects(false, true);

            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    if (Math.Abs(PlatformController.bullets[i].physics.transform.position.Y - player.physics.transform.position.Y) > 500)
                    {
                        PlatformController.RemoveBullet(i);
                        continue;
                    }
                    PlatformController.bullets[i].MoveUp();
                }
            }

            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    if (PlatformController.enemies[i].physics.StandartCollide())
                    {
                        PlatformController.RemoveEnemy(i);
                        break;
                    }
                }
            }

            player.physics.ApplyPhysics();
            FollowPlayer();
            Invalidate();
        }

        public void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.bullets.Count; i++)
            {
                var bullet = PlatformController.bullets[i];
                bullet.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.enemies.Count; i++)
            {
                var enemy = PlatformController.enemies[i];
                enemy.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.bonuses.Count; i++)
            {
                var bonus = PlatformController.bonuses[i];
                bonus.physics.transform.position.Y += offset;
            }
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    PlatformController.platforms[i].DrawSprite(g);
                }
            }
            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    PlatformController.bullets[i].DrawSprite(g);
                }
            }
            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    PlatformController.enemies[i].DrawSprite(g);
                }
            }
            if (PlatformController.bonuses.Count > 0)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    PlatformController.bonuses[i].DrawSprite(g);
                }
            }
            player.DrawSprite(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
