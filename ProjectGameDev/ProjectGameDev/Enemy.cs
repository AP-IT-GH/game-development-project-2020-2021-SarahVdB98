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
        Vector2 origin;
        Vector2 velocity;
        public Rectangle rect;
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        bool right;
        float distance;
        float oldDistance;
        

        public Enemy(Texture2D texture , Vector2 vector2, float newDistance)
        {
            enemyTexture = texture;
            positie = vector2;
            distance = newDistance;
            oldDistance = distance;
            rect.Width = 550;
            rect.Height = 991;
            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 10, 10);
        }
        float mousedistance;
        public void Update(GameTime gameTime)
        {
            positie += velocity;

           // origin = new Vector2(enemyTexture.Width / 2, enemyTexture.Height / 2);

           // if (distance <= 0)
           // {
           //     right = true;
           //     velocity.X = 1f;
           // }
           // else if(distance <= oldDistance)
           // {
           //     right = false;
           //     velocity.X = -1;
           // }
           // if (right){distance += 1;} else {distance -= 1;}

           //// MouseState mouse = Mouse.GetState();
           // mousedistance = 1000 - positie.X;

           // if (mousedistance >= -200 && mousedistance <=200)
           // {
           //     if (mousedistance <-1)
           //     {
           //         velocity.X = -1f;
           //     }
           //     else if(mousedistance > 1)
           //     {
           //         velocity.X = 1f;
           //     }
           //     else if (mousedistance == 0)
           //     {
           //         velocity.X = 0f;
           //     }
           // }

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
