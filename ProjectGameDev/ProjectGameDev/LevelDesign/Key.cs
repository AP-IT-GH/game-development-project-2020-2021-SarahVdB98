using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev.LevelDesign
{
    public class Key : IGameObject
    {
        Texture2D enemyTexture;

        public Vector2 positie;
        public Rectangle rect;
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        public Key(Texture2D texture, Vector2 vector2)
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
            spriteBatch.Draw(enemyTexture, positie, null, Color.White, 0, new Vector2(0,0), 0.1f, SpriteEffects.None, 0);
        }
    }
}
