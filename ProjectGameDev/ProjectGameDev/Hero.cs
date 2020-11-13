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
    class Hero : IGameObject
    {
        Texture2D heroTexture;
        Animatie animatieR;
        Animatie animatieL;
        Animatie animatieStand;
        Animatie currentAnimation;
        private Vector2 positie;
        IInputReader inputReader;

        public Hero(Texture2D texture, IInputReader reader)
        {
            heroTexture = texture;
            animatieR = new Animatie();
            for (int i = 0; i < 2560; i+=256)
            {
                animatieR.AddFrame(new AnimationFrame(new Rectangle(i, 256, 256, 256)));
            }

            animatieL = new Animatie();
            for (int j = 0; j < 2560; j+=256)
            {
                animatieL.AddFrame(new AnimationFrame(new Rectangle(j, 768, 256, 256)));
            }

            animatieStand = new Animatie();
            animatieStand.AddFrame(new AnimationFrame(new Rectangle(768, 0, 256, 256)));
            positie = new Vector2(10, 250);
            this.inputReader = reader;
            
        }

       public void Update(GameTime gameTime)
        {
            KeyboardState stateKey = Keyboard.GetState();
            var direction = inputReader.ReadInput();
            
            direction *= 4;
            positie += direction;
            if (stateKey.IsKeyDown(Keys.Right))
            {
                currentAnimation = animatieR;
            }
            else if (stateKey.IsKeyDown(Keys.Left))
            {
                currentAnimation = animatieL;
            }
            else
            {
                currentAnimation = animatieStand;
            }
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, positie, currentAnimation.CurrentFrame.SourceRectangle , Color.White,0,new Vector2(0,0), 0.4f, SpriteEffects.None,0);
        }
    }
}
