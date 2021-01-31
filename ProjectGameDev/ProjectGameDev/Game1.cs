using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Input;
using ProjectGameDev.Interfaces;
using ProjectGameDev.LevelDesign;
using System;
using System.Collections.Generic;
using System.Diagnostics;
public enum GameState
{
    Start,
    Uitleg,
    Pause,
    Game,
    Dead,
    Restart,
    End
}

namespace ProjectGameDev
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private Texture2D enemyTexture;
        private Texture2D background;
        public static GameState gameState;


        Hero hero;
        Enemy enemy;
        Level level;
        CollisionManager collisionManager;
        Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.Components.Add(new MyControls(this));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            collisionManager = new CollisionManager();
            camera = new Camera(GraphicsDevice.Viewport);
            gameState = new GameState();
            level = new Level(Content);
            level.CreateWorld();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameState = GameState.Start;
            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("trump_walk");
            enemyTexture = Content.Load<Texture2D>("6-63763_politics-kim-jong-un-kim-jong-un-png");
            background = Content.Load<Texture2D>("background2");


            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(texture, new KeyBoardReader());
            enemy = new Enemy(enemyTexture);
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            collisionManager.collisionAction(hero, enemy);
            collisionManager.collisionAction(level, hero);

            hero.Update(gameTime);
            enemy.Update(gameTime);
            camera.Update(gameTime, hero);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            _spriteBatch.End();


            _spriteBatch.Begin(SpriteSortMode.Deferred,
               BlendState.AlphaBlend,
               null, null, null, null,
               camera.transform);
            if (gameState == GameState.Start)
            {
                
            }
            if (gameState == GameState.Game)
            {
                hero.Draw(_spriteBatch);
                enemy.Draw(_spriteBatch);
                level.DrawWorld(_spriteBatch);
            }
            if (gameState == GameState.Uitleg)
            {
            }
            if (gameState == GameState.Dead)
            {
            }
            if (gameState == GameState.Pause)
            {
            }
            _spriteBatch.End();
            if (gameState == GameState.Restart)
            {
                Initialize();
                LoadContent();
            }
            if (gameState == GameState.End)
            {
                Exit();
            }

            base.Draw(gameTime);
        }
    }
}
