using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev
{
    //https://www.youtube.com/watch?v=pin8_ZfBgq0&t=514s
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime, Hero trump)
        {
            center = new Vector2(trump.positie.X + (trump.CollisionRectangle.Width / 2) -400, 0);
            transform = Matrix.CreateScale(new Vector3(1,1,0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y,0 ));
        }
    }
}
