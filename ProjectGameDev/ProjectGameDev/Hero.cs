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
        Animatie jump;
        Animatie currentAnimation;
        private Vector2 positie;
        private Vector2 startPos;
        IInputReader inputReader;
        float gravity = 0.1f;

        public Hero(Texture2D texture, IInputReader reader)
        {
            heroTexture = texture;
            positie = new Vector2(0, 250);
            startPos = new Vector2(0, 250);
            
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

            jump = new Animatie();
            jump.AddFrame(new AnimationFrame(new Rectangle(1536, 256, 256, 256)));

            this.inputReader = reader;
            currentAnimation = animatieStand;


        }

       public void Update(GameTime gameTime)
        {
            KeyboardState stateKey = Keyboard.GetState();
            
            var direction = inputReader.ReadInput();
            positie += direction;

            if (positie.Y < startPos.Y)
            {
                positie.Y += gravity;
                gravity += 0.1f;
                if (gravity > 2f)
                {
                    gravity = 2f;
                }
            }
            if (stateKey.IsKeyDown(Keys.Right))
            {
                currentAnimation = animatieR;
            }
            else if (stateKey.IsKeyDown(Keys.Left))
            {
                currentAnimation = animatieL;
            }
            else if (stateKey.IsKeyDown(Keys.Space))
            {
                currentAnimation = jump;
            }
            else if (currentAnimation == jump && positie.Y < startPos.Y)
            {
                    positie.Y += gravity;
                    gravity += 0.1f;
                    if (gravity > 2f)
                    {
                        gravity = 2f;
                    }
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
