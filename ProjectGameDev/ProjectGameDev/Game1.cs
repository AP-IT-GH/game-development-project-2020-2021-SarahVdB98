using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Input;
using ProjectGameDev.Interfaces;
using ProjectGameDev.LevelDesign;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
        private Texture2D keyTexture;
        private Texture2D background;
        private Texture2D doorTexture;
        public static GameState gameState;


        Hero hero;
        Enemy enemy;
        Enemy enemy2;
        Level2 level;
        Level2 level2;
        CollisionManager collisionManager;
        Camera camera;
        Camera camera2;
        Door door;
        public static Key key;
        public static Key key2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.Components.Add(new MyControls(this));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            collisionManager = new CollisionManager();
            camera = new Camera(GraphicsDevice.Viewport);

            camera2 = new Camera(GraphicsDevice.Viewport);
            gameState = new GameState();

            if (CollisionManager.hasAccessLevelTwo)
            {
                level2 = new Level2(Content);
                level2.CreateWorld();
            }
            else
            {
                level = new Level2(Content);
                level.CreateWorld();
            }

            base.Initialize();
        }

        //private void LoadNextLevel()
        //{
        //    // Unloads the content for the current level before loading the next one.
        //    if (level != null)
        //        Content.Unload();
        //        level2 = new Level2(Content);
        //    Content.RootDirectory = "Content";
        //}

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            if (!CollisionManager.hasAccessLevelTwo)
            {
                gameState = GameState.Start;
            }
            texture = Content.Load<Texture2D>("trump_walk");
            enemyTexture = Content.Load<Texture2D>("6-63763_politics-kim-jong-un-kim-jong-un-png");
            background = Content.Load<Texture2D>("background4");
            keyTexture = Content.Load<Texture2D>("key");
            doorTexture = Content.Load<Texture2D>("door-closed");



            InitializeGameObjects2();
        }

        private void InitializeGameObjects()
        {
            hero = new Hero(texture, new KeyBoardReader(), new Vector2(150,550 /*584f*/));
            enemy = new Enemy(enemyTexture, new Vector2(945, 181));
            enemy2 = new Enemy(enemyTexture, new Vector2(2155, 566));
            key = new Key(keyTexture, new Vector2(870, 220));
            key2 = new Key(keyTexture, new Vector2(2040, 45));
            door = new Door(doorTexture, new Vector2(4096, 577));

        }

        private void InitializeGameObjects2()
        {
            hero = new Hero(texture, new KeyBoardReader(), new Vector2(150, 550 /*584f*/));
            enemy = new Enemy(enemyTexture, new Vector2(561, 566));
            enemy2 = new Enemy(enemyTexture, new Vector2(2155, 566));
            key = new Key(keyTexture, new Vector2(830, 80));
            key2 = new Key(keyTexture, new Vector2(2040, 45));
            door = new Door(doorTexture, new Vector2(4096, 577));

        }

        protected override void Update(GameTime gameTime)
        {
            if (CollisionManager.hasKeyTwo)
            {
                doorTexture = Content.Load<Texture2D>("door-open");
                door = new Door(doorTexture, new Vector2(4096, 577));
            }
            if (CollisionManager.hasAccessLevelTwo)
            {
                gameState = GameState.Game;
            }

            Debug.WriteLine(hero.positie);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            
            
            collisionManager.collisionAction(level, hero);
            if (CollisionManager.hasAccessLevelTwo)
            {
                collisionManager.collisionAction(level2, hero);
            }
            collisionManager.collisionAction(hero, enemy);
            collisionManager.collisionAction(hero, key);
            //collisionManager.collisionAction(hero, key2);

            collisionManager.collisionAction(hero, door);
            door.Update(gameTime);

            //collisionManager.collisionAction(hero, enemy2);


            hero.Update(gameTime);
            enemy.Update(gameTime);
            enemy2.Update(gameTime);
            camera.Update(gameTime, hero);
            key.Update(gameTime);
            key2.Update(gameTime);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            _spriteBatch.End();

            if (gameState == GameState.Start)
            {
                
            }
            if (gameState == GameState.Game)
            {
                
                if (CollisionManager.hasAccessLevelTwo)
                {
                    //LoadNextLevel();
                    Initialize();
                    InitializeGameObjects();
                    LoadContent();
                    CollisionManager.hasKeyTwo = false;
                    _spriteBatch.Begin(SpriteSortMode.Deferred,
                     BlendState.AlphaBlend,
                     null, null, null, null,
                     camera.transform);

                   
                    //_spriteBatch.Begin();

                   // GraphicsDevice.Clear(Color.CornflowerBlue);
                    _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

                    _spriteBatch.End();
                    _spriteBatch.Begin();
                    key.Draw(_spriteBatch);
                    key2.Draw(_spriteBatch);
                    door.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);
                    level2.DrawWorld(_spriteBatch);
                    Update(gameTime);

                    _spriteBatch.End();
                }

                else
                {

                    _spriteBatch.Begin(SpriteSortMode.Deferred,
              BlendState.AlphaBlend,
              null, null, null, null,
              camera.transform);

                    key.Draw(_spriteBatch);
                    //key2.Draw(_spriteBatch);
                    door.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);
                    //enemy2.Draw(_spriteBatch);
                    level.DrawWorld(_spriteBatch);
                    _spriteBatch.End();
                }
                
                
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
            if (gameState == GameState.Restart)
            {
                gameState = new GameState();
                gameState = GameState.Start;
            }
            if (gameState == GameState.End)
            {
                Exit();
            }
            base.Draw(gameTime);
        }
    }
}
