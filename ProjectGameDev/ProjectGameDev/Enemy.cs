using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Animation;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev
{
    class Enemy
    {
        Texture2D enemyTexture;

        public Vector2 positie;
        public Vector2 startPos;
        public Vector2 Velocity;
        public Rectangle rect;
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        public Enemy(Texture2D texture)
        {
            enemyTexture = texture;
            positie = new Vector2(200, 356);
            startPos = new Vector2(200, 356);
            rect.Width = 550;
            rect.Height = 991;
            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 10, 10);
        }

        public void Update(GameTime gameTime)
        {
            
            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            _collisionRectangle.Width = 10;
            _collisionRectangle.Height = 10;
            CollisionRectangle = _collisionRectangle;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemyTexture, positie, rect, Color.White, 0, new Vector2(0, 0), 0.1f, SpriteEffects.None, 0);

        }


    }
}
