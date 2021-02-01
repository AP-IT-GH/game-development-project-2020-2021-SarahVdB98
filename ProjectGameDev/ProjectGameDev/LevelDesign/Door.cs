using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev.LevelDesign
{
    class Door :IGameObject
    {
        Texture2D doorTexture;

        public Vector2 positie;
        public Rectangle rect;
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        public Door(Texture2D texture, Vector2 vector2)
        {
            doorTexture = texture;
            positie = vector2;
            rect.Width = 550;
            rect.Height = 991;
            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 60, 90);
        }

        public void Update(GameTime gameTime)
        {
            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            _collisionRectangle.Width = 60;
            _collisionRectangle.Height = 90;
            CollisionRectangle = _collisionRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(doorTexture, positie, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }
    }
}
