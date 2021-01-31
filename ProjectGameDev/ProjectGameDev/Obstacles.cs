using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev
{
    abstract class Obstacles
    {
        public Rectangle CollisionRectangle { get; set; }
        public Vector2 Positie { get; set; }

        public Texture2D texture { get; set; }

        public Obstacles(Texture2D obstakel, Vector2 vector2)
        {
             texture = obstakel;
            Positie = vector2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Positie, Color.White);
        }
    }
}
