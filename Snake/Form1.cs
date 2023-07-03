using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; //for JPG compression
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rng = new Random();

        bool goLeft, goRight, goUp, goDown;

        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.direction != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.direction != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.direction != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.direction != "up")
            {
                goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapshot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "I scored: " + score + " in Steve's Snake Game! Can you beat it?";
            caption.Font = new Font("Comic Sans MS", 12, FontStyle.Bold);
            caption.ForeColor = Color.LightBlue;
            caption.AutoSize = false;
            caption.Width = pictureBox.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            pictureBox.Controls.Add(caption); 

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = "SteveSnakeSnapshot";
            saveDialog.DefaultExt = "jpg";
            saveDialog.Filter = "JPG Image File | *.jpg";
            saveDialog.ValidateNames = true;

            if (saveDialog.ShowDialog() == DialogResult.OK) //if SAVE clicked
            {
                int width = Convert.ToInt32(pictureBox.Width);
                int height = Convert.ToInt32(pictureBox.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureBox.DrawToBitmap(bmp, new Rectangle(0,0,width,height));
                bmp.Save(saveDialog.FileName, ImageFormat.Jpeg);
                pictureBox.Controls.Remove(caption); // so you can go back to playing
            }



        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            //setting the directions
            if (goLeft)
            {
                Settings.direction = "left";
            }
            if (goRight)
            {
                Settings.direction = "right";

            }
            if (goDown)
            {
                Settings.direction = "down";
            }
            if (goUp)
            {
                Settings.direction = "up";
            }
            // end of direction-setting.

            for (int i = Snake.Count-1; i >= 0; i--)
            {
                if (i==0) //head
                {
                    


                    //actual movement of head.
                    switch(Settings.direction)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                    }
                    // set boundaries
                    if (Snake[i].X < 0) Snake[i].X = maxWidth;
                    if (Snake[i].X > maxWidth) Snake[i].X = 0;
                    if (Snake[i].Y < 0) Snake[i].Y = maxHeight;
                    if (Snake[i].Y > maxHeight) Snake[i].Y = 0;

                    //Check if collide with food
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    //CHeck for collision with self.
                    //Starting with j = 0 causes the game to detect
                    //a collision between the head and itself. D'oh.
                    for (int j = 1; j < Snake.Count; j++)
                    {

                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }

                }
                else //body just follows head
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            //clear frame and redraw with new [moved] stuff
            pictureBox.Invalidate();




        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics; //link paint event to canvas
            Brush snakeColor;
            //Draw & Color Snake
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0) snakeColor = Brushes.Black;
                else snakeColor = Brushes.DarkGreen;

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                        Snake[i].X * Settings.width,
                        Snake[i].Y * Settings.height,
                        Settings.width,
                        Settings.height
                    ));
            }

            //Draw and color food
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                        food.X * Settings.width,
                        food.Y * Settings.height,
                        Settings.width,
                        Settings.height
                    ));

        }

        private void RestartGame()
        {
            maxWidth = pictureBox.Width / Settings.width - 1;
            maxHeight = pictureBox.Height / Settings.height - 1;

            Snake.Clear();

            startBtn.Enabled = false;
            snapBtn.Enabled = false;
            score = 0;
            scoreTxt.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // adding head part to the list

            for (int i = 0; i < 10; i++) 
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = rng.Next(2, maxWidth), Y = rng.Next(2, maxHeight) };

            gameTimer.Start();

        }

        private void EatFood()
        {
            //increment score
            score++;
            scoreTxt.Text = "Score: " + score;


            //create new body segment
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);

            //create new foot item
            food = new Circle { X = rng.Next(2, maxWidth), Y = rng.Next(2, maxHeight) };
        }

        private void GameOver()
        {
            gameTimer.Stop();
            startBtn.Enabled = true;
            snapBtn.Enabled = true;
            if (score > highScore)
            {
                highScore = score;
                highScoreTxt.Text = "High Score: " + Environment.NewLine + highScore;
                highScoreTxt.ForeColor = Color.Maroon;
                highScoreTxt.TextAlign = HorizontalAlignment.Center;
            }
        }



    }
}
