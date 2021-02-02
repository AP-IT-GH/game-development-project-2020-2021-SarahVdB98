using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
    ClearLevel,
    Dead,
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
        private Texture2D deadTexture;
        private Texture2D keyTexture;
        private Texture2D background;
        private Texture2D doorTexture;
        private Texture2D titleTexture;
        private Texture2D uitlegTexture;
        public static GameState gameState;
        bool isDrawnLvlTwo = false;

        Hero hero;
        
        Enemy enemy;
        public static Enemy enemy2;
        Enemy enemy3;
        Enemy enemy4;
        Level level;
        Level2 level2;
        CollisionManager collisionManager;
        Camera camera;
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

            gameState = new GameState();

            level = new Level(Content);
            level.CreateWorld();

            level2 = new Level2(Content);
            level2.CreateWorld();
           
          

            base.Initialize();
        }
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
            titleTexture = Content.Load<Texture2D>("RunningForPresident");
            uitlegTexture = Content.Load<Texture2D>("uitleg3");
            deadTexture = Content.Load<Texture2D>("dood");



            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
           

                hero = new Hero(texture, new KeyBoardReader(), new Vector2(150,584));
                enemy = new Enemy(enemyTexture, new Vector2(945, 181));
                enemy2 = new Enemy(enemyTexture, new Vector2(2155, 566));
                key = new Key(keyTexture, new Vector2(870, 220));
                key2 = new Key(keyTexture, new Vector2(2040, 45));
                door = new Door(doorTexture, new Vector2(4096, 577));

            if (CollisionManager.hasAccessLevelTwo)
            {
                hero = new Hero(texture, new KeyBoardReader(), new Vector2(150, 577));
                enemy = new Enemy(enemyTexture, new Vector2(561, 566));
                enemy2 = new Enemy(enemyTexture, new Vector2(1050, 566));
                enemy3 = new Enemy(enemyTexture, new Vector2(1150, 566));
                enemy4 = new Enemy(enemyTexture, new Vector2(1250, 566));
                key = new Key(keyTexture, new Vector2(830, 80));
                key2 = new Key(keyTexture, new Vector2(-100, -100));
            }


        }


        protected override void Update(GameTime gameTime)
        {
            if (CollisionManager.hasKeyTwo)
            {
                doorTexture = Content.Load<Texture2D>("door-open");
                door = new Door(doorTexture, new Vector2(4096, 577));
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            collisionManager.collisionAction(hero, enemy);
            collisionManager.collisionAction(hero, enemy2);
            collisionManager.collisionAction(hero, key);
            collisionManager.collisionAction(hero, key2);

            collisionManager.collisionAction(hero, door);

            collisionManager.collisionAction(hero, enemy2);


            if (CollisionManager.hasAccessLevelTwo)
            {
                collisionManager.collisionAction(level2, hero);
            }
            else
            {
                collisionManager.collisionAction(level, hero);
            }
            door.Update(gameTime);
            enemy.Update(gameTime);
            enemy2.Update(gameTime);
            if (enemy3 != null)
            {
                collisionManager.collisionAction(hero, enemy3);
                enemy3.Update(gameTime);
            }
            if (enemy4 != null)
            {
                collisionManager.collisionAction(hero, enemy4);
                enemy4.Update(gameTime);
            }

            key.Update(gameTime);
            key2.Update(gameTime);
            hero.Update(gameTime);            
            camera.Update(gameTime, hero);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(titleTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.End();


            if (gameState == GameState.Game)
            {

                _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                _spriteBatch.End();

               
                if (!CollisionManager.hasAccessLevelTwo)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
                    key.Draw(_spriteBatch);
                    key2.Draw(_spriteBatch);
                    door.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);
                    enemy2.Draw(_spriteBatch);
                    level.DrawWorld(_spriteBatch);
                    _spriteBatch.End();
                }
                else 
                {
                    gameState = GameState.ClearLevel;
                }
                
            }
            if (gameState == GameState.Uitleg)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(uitlegTexture, new Vector2(0, 0), Color.White);
                _spriteBatch.End();
            }
            if (gameState == GameState.Dead)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(deadTexture, new Vector2(0, 0), Color.White);
                _spriteBatch.End();
            }
            if (gameState == GameState.ClearLevel)
            {
                if (CollisionManager.hasAccessLevelTwo)
                {
                    if (!isDrawnLvlTwo)
                    {
                        Content.Unload();
                        Initialize();
                        LoadContent();
                        isDrawnLvlTwo = true;
                        _spriteBatch.Begin();
                        _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                        _spriteBatch.End();
                        CollisionManager.hasKeyOne = false;
                        CollisionManager.hasKeyTwo = false;
                    }
                    _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
                   
                    level2.DrawWorld(_spriteBatch);
                    key.Draw(_spriteBatch);
                    key2.Draw(_spriteBatch);
                    door.Draw(_spriteBatch);
                    hero.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);
                    enemy2.Draw(_spriteBatch);
                    enemy3.Draw(_spriteBatch);
                    enemy4.Draw(_spriteBatch);
                    _spriteBatch.End();
                    if (CollisionManager.hasAccessLevelTwo && CollisionManager.hasKeyTwo)
                    {
                        gameState = GameState.End;
                    }
                    else
                    {

                        gameState = GameState.Game;
                    }

                }
            }

            if (gameState == GameState.End)
            {
                Exit();
            }
            base.Draw(gameTime);
        }
    }
}
