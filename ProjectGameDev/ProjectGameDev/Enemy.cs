using Microsoft.Xna.Framework;
using System.Timers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Animation;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjectGameDev
{
    public class Enemy
    {
        Texture2D enemyTexture;

        public Vector2 positie;
        Vector2 origin = new Vector2(0,0);
        public Rectangle rect;
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;        

        public Enemy(Texture2D texture , Vector2 vector2)
        {
            enemyTexture = texture;
            positie = vector2;
            rect.Width = 550;
            rect.Height = 991;
            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 10, 10);
        }
        public void Update(GameTime gameTime)
        {
            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            _collisionRectangle.Width = 25;
            _collisionRectangle.Height = 25;
            CollisionRectangle = _collisionRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(enemyTexture, positie, null, Color.White, 0, origin, 0.1f, SpriteEffects.None, 0);
        }


    }
}
