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
        
        Hero hero;
        Brick brick;
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
            brick = new Brick(brickTexture, new Vector2(120, 200));
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            
            // TODO: Add your update logic here
            hero.Update(gameTime);
            brick.Update();
            if (collisionManager.CheckCollision(hero.CollisionRectangle, brick.CollisionRectangle))
            {
                if (hero.positie.X < brick.Positie.X-50)
                {
                    hero.positie.X -= 3;
                }
                else if (hero.positie.X > brick.Positie.X)
                {
                    hero.positie.X += 3;
                }
                else if (hero.positie.Y < brick.Positie.Y-50)
                {
                    hero.positie.Y = brick.Positie.Y-90;
                }
                else if (hero.positie.Y > brick.Positie.Y-50)
                {
                    hero.positie.Y += 14;
                }
            }
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            hero.Draw(_spriteBatch);
            brick.Draw(_spriteBatch);
            _spriteBatch.End();
            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
