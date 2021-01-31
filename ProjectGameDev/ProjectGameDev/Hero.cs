using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Animation;
using ProjectGameDev.Input;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev
{
    class Hero : IGameObject, ICollision, ITransform
    {
        Texture2D heroTexture;
        Animatie animatieR;
        Animatie animatieL;
        Animatie animatieStand;
        Animatie jump;
        Animatie currentAnimation;

        public bool canMoveLeft { get; set; } = true;
        public bool canMoveRight { get; set; } = true;
        public bool canMoveUp { get; set; } = true;
        public bool canMoveDown { get; set; } = false;

        public static bool IsGrounded = true;

        public Vector2 position { get; set; }
        public Vector2 positie;
        public Vector2 startPos;

        public IInputReader inputReader;

        float gravity = 0.1f;
        public Rectangle CollisionRectangle { get; set; }

        private Rectangle _collisionRectangle;

        public Hero(Texture2D texture, IInputReader reader)
        {
            heroTexture = texture;
            startPos = new Vector2(150, 584f);
            positie = startPos;
            position = positie;
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


            CollisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 102, 102);

            this.inputReader = reader;
            currentAnimation = animatieStand;

        }


        public void Update(GameTime gameTime)
        {
            
            KeyboardState stateKey = Keyboard.GetState();
            
            var direction = inputReader.ReadInput();
            positie += direction;

            
            

            if (positie.Y < 700)
            {
                if (positie.Y <= 584)
                {
                    if (CollisionManager.collided)
                    {
                        IsGrounded = true;

                    }
                    else
                    {
                        IsGrounded = false;
                    }
                }
                else
                {
                    IsGrounded = true;
                }
                positie.Y += gravity;
                gravity += 0.1f;
                if (gravity > 2f)
                {
                    gravity = 2f;
                }
                if (positie.Y > 750)
                {
                    Game1.gameState = GameState.Dead;
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
                IsGrounded = false;
            }
            else if (currentAnimation == jump && positie.Y < startPos.Y)
            {
                if (CollisionManager.collided)
                {
                    IsGrounded = true;

                }
                else
                {
                    IsGrounded = false;
                    positie.Y += gravity;
                    gravity += 0.1f;
                    if (gravity > 2f)
                    {
                        gravity = 2f;
                    }
                }
               
            }
            else
            {
                currentAnimation = animatieStand;
            }

            currentAnimation.Update(gameTime);
            _collisionRectangle.X = (int)positie.X;
            _collisionRectangle.Y = (int)positie.Y;
            _collisionRectangle.Width = 70;
            _collisionRectangle.Height = 90;
            CollisionRectangle = _collisionRectangle;

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, positie, currentAnimation.CurrentFrame.SourceRectangle , Color.White,0,new Vector2(0,0), 0.4f, SpriteEffects.None,0);
        }

        
    }
}
