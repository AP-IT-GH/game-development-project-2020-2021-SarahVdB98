using Microsoft.Xna.Framework;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev
{
    //https://www.youtube.com/watch?v=N9whx5Cozog

    class MyControls : ControlManager
    {
        public MyControls(Game game) : base (game)
        {

        }
        public override void InitializeComponent()
        {
            var btn1 = new Button()
            {
                Text = "START",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(450, GraphicsDeviceManager.DefaultBackBufferWidth / 2)

            };
            btn1.Clicked += Btn1_Clicked;
            Controls.Add(btn1);

            var btn2 = new Button()
            {
                Text = "UITLEG",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(450, (GraphicsDeviceManager.DefaultBackBufferWidth / 2)-70)
            };
            btn2.Clicked += Btn2_Clicked;
            Controls.Add(btn2);

            var btn3 = new Button()
            {
                Text = "<--",
                Size = new Vector2(50, 50),
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Location = new Vector2(60, 10),
                IsVisible = false

            };
            btn3.Clicked += Btn3_Clicked;
            Controls.Add(btn3);

            var btn4 = new Button()
            {
                Text = "||",
                Size = new Vector2(50, 50),
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                Location = new Vector2(10, 10),
                IsVisible = false

            };
            btn4.Clicked += Btn4_Clicked;
            Controls.Add(btn4);

            var btn5 = new Button()
            {
                Text = "CONTINUE",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(575, 15),
                IsVisible = false

            };
            btn5.Clicked += Btn5_Clicked;
            Controls.Add(btn5);

            var btn6 = new Button()
            {
                Text = "STOP",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(575, 165),
                IsVisible = false
            };
            btn6.Clicked += Btn6_Clicked;
            Controls.Add(btn6);

            var btn7 = new Button()
            {
                Text = "RESTART",
                Size = new Vector2(200, 50),
                BackgroundColor = Color.ForestGreen,
                Location = new Vector2(575, 90),
                IsVisible = false
            };
            btn7.Clicked += Btn7_Clicked;
            Controls.Add(btn7);
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Game1.gameState = GameState.Game;
            Controls[0].IsVisible = false;
            Controls[1].IsVisible = false;
            Controls[2].IsVisible = false;
            Controls[3].IsVisible = true;
            Controls[4].IsVisible = false;
            Controls[5].IsVisible = false;
            Controls[6].IsVisible = false;

        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Game1.gameState = GameState.Uitleg;
            Controls[0].IsVisible = false;
            Controls[1].IsVisible = false;
            Controls[2].IsVisible = true;
            Controls[3].IsVisible = false;
            Controls[4].IsVisible = false;
            Controls[5].IsVisible = false;
            Controls[6].IsVisible = false;

        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
           
            Game1.gameState = GameState.Start;
            Controls[0].IsVisible = true;
            Controls[1].IsVisible = true;
            Controls[2].IsVisible = false;
            Controls[3].IsVisible = false;
            Controls[4].IsVisible = false;
            Controls[5].IsVisible = false;
            Controls[6].IsVisible = false;

        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Game1.gameState = GameState.Pause;
            Controls[0].IsVisible = false;
            Controls[1].IsVisible = false;
            Controls[2].IsVisible = false;
            Controls[3].IsVisible = false;
            Controls[4].IsVisible = true;
            Controls[5].IsVisible = true;
            Controls[6].IsVisible = true;
        }
        private void Btn5_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            Game1.gameState = GameState.Game;
            Controls[0].IsVisible = false;
            Controls[1].IsVisible = false;
            Controls[2].IsVisible = false;
            Controls[3].IsVisible = true;
            Controls[4].IsVisible = false;
            Controls[5].IsVisible = false;
            Controls[6].IsVisible = false;

        }

        private void Btn6_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Controls[0].IsVisible = false;
            Controls[1].IsVisible = false;
            Controls[2].IsVisible = false;
            Controls[3].IsVisible = true;
            Controls[4].IsVisible = false;
            Controls[5].IsVisible = false;
            Controls[6].IsVisible = false;
            Game1.gameState = GameState.End;
        }

        private void Btn7_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Game1.gameState = GameState.Restart;
            Controls[0].IsVisible = true;
            Controls[1].IsVisible = true;
            Controls[2].IsVisible = false;
            Controls[3].IsVisible = false;
            Controls[4].IsVisible = false;
            Controls[5].IsVisible = false;
            Controls[6].IsVisible = false;
            
        }

    }
}
