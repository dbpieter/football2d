using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMTproject1
{
    public partial class Form1 : Form
    {

        private Game game;
        private Timer timer;
        private Graphics bufferGraphics;
        private Graphics screenGraphics;
        private Bitmap backBuffer;

        private const double MAXFPS = 100d;
        private bool paused;
        private bool demo;
        private uint time;
        private float schaalX;
        private float schaalY;

        public Form1()
        {
            demo = false;
            InitializeComponent();
            Init(4,false);
        }

        public void Init(uint players,bool hasBigPlayer)
        {
            time = 0;
            paused = false;
            backBuffer = new Bitmap(screen.Width, screen.Height);
            screenGraphics = screen.CreateGraphics();

            bufferGraphics = Graphics.FromImage(backBuffer);
            bufferGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //anti-aliasing
            bufferGraphics.ResetTransform();
            schaalX = screen.Width / 5.5f;
            schaalY = screen.Height / 4.0f;
            bufferGraphics.ScaleTransform(schaalX, -schaalY);
            bufferGraphics.TranslateTransform(screen.Width / (schaalX * 2f), -screen.Height / (schaalY * 2f)); // oorsprong in centrum

            game = new Game(bufferGraphics, (int)(1000 / MAXFPS),players,hasBigPlayer);

            timer = new Timer();
            timer.Interval = (int)(1000 / MAXFPS);
            timer.Tick += new EventHandler(TimerCallBack);
            timer.Start();

            accellerationTrackBar.Value = (int)game.getAccelerationX() * 10;
            maxSpeedTrackBar.Value = (int)game.getMaxSpeed() * 10;
            restitutionTrackBar.Value = (int) (game.Restitution*100.0);
        }

        public void restart(uint players,bool hasBigPlayer)
        {
            bool aa = bufferGraphics.SmoothingMode == System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            timer.Stop();
            Init(players,hasBigPlayer);

            if (aa)
            {
                bufferGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            game.AI = checkBox1.Checked;
        }

        public void TimerCallBack(object sender, EventArgs args)
        {
            if (!paused)
            {
                bufferGraphics.Clear(Color.Green);
                time += (uint)timer.Interval;
                game.doStep();
                if (time % 100 == 0)
                {
                    updateGuiStats();
                }
                screenGraphics.DrawImage(backBuffer, new Rectangle(0, 0, screen.Width, screen.Height), new Rectangle(0, 0, screen.Width, screen.Height), GraphicsUnit.Pixel);
            }
        }

        private void updateGuiStats()
        {
            if (game.Players.Length >= 4)
            {
                s1SpeedTxt.Text = game.Players[0].Speed.Length.ToString();
                s2SpeedTxt.Text = game.Players[1].Speed.Length.ToString();
                s3SpeedTxt.Text = game.Players[2].Speed.Length.ToString();
                s4SpeedTxt.Text = game.Players[3].Speed.Length.ToString();
            }
            blueScore.Text = game.BlueScore.ToString();
            redScore.Text = game.RedScore.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                paused = false;
                pauzeButton.Text = "Pauze";
            }
            else
            {
                paused = true;
                pauzeButton.Text = "Ga Verder";
            }
        }

        private void antialiasingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (antialiasingCheckBox.Checked)
            {
                bufferGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            else
            {
                bufferGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            demo = false;
            restart(4,false);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (demo)
            {
                game.AI = false;
                return;
            }
            if (checkBox1.Checked)
            {
                game.AI = true;
            }
            else
            {
                game.AI = false;
            }
        }

        private void demoButton_Click(object sender, EventArgs e)
        {
            demo = true;
            checkBox1.Checked = false;
            restart(50,true);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int val = maxSpeedTrackBar.Value;
            game.setMaxSpeed((val/10.0f));
        }

        private void accellerationTrackBar_Scroll(object sender, EventArgs e)
        {
            int val = accellerationTrackBar.Value;
            game.setAcceleration((val/10.0f));
        }

        private void restitutionTrackBar_Scroll(object sender, EventArgs e)
        {
            int val = restitutionTrackBar.Value;
            game.Restitution = val/100.0f;
        }


 
    }
}
