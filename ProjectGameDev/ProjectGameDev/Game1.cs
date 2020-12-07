using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Input;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectGameDev
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private Texture2D brickTexture;
        private Brick[] brickArr = new Brick[5];
        
        Hero hero;
        CollisionManager collisionManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            collisionManager = new CollisionManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("trump_walk");
            brickTexture = Content.Load<Texture2D>("wall");

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            
            hero = new Hero(texture, new KeyBoardReader());
            int Xpos = 120;
            for (int i = 0; i < 5; i++)
            {
                brickArr[i] = new Brick(brickTexture, new Vector2(Xpos, 200));
                Xpos += 50;
            }
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            hero.Update(gameTime);
            for (int i = 0; i < brickArr.Length; i++)
            {
                brickArr[i].Update();
                if (collisionManager.CheckCollision(hero.CollisionRectangle, brickArr[i].CollisionRectangle))
                {
                    if (hero.positie.Y < brickArr[i].Positie.Y - 50)
                    {
                        hero.positie.Y = brickArr[i].Positie.Y - 90;
                    }
                    else if (hero.positie.Y > brickArr[i].Positie.Y - 50)
                    {
                        hero.positie.Y += 14;
                    }
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            hero.Draw(_spriteBatch);
            for (int i = 0; i < brickArr.Length; i++)
            {
                brickArr[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
