using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDev.Animation;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev
{
    class Brick: ICollision
    {
        public Texture2D BrickTexture { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Positie { get; set; }


        public Brick(Texture2D brick, Vector2 vector2)
        {
            BrickTexture = brick;
            Positie = vector2;
            CollisionRectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 10, 25);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(BrickTexture, Positie, Color.White);
        }

        public void Update()
        {
            //
        }
    }
}
