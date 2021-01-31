using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjectGameDev.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev.Input
{
    public class KeyBoardReader : IInputReader
    {
        public bool canMoveLeft { get; set; } = true;
        public bool canMoveRight { get; set; } = true;
        public bool canMoveUp { get; set; } = true;
        public bool canMoveDown { get; set; } = false;

        public static Vector2 Velocity;

        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                if (canMoveLeft)
                {
                    direction = new Vector2(-1, 0);
                }
                canMoveLeft = true;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                if (canMoveRight)
                {
                    direction = new Vector2(1, 0);
                }
                canMoveRight = true;                
            }

            if (state.IsKeyDown(Keys.Space) && Hero.IsGrounded)
            {
                Hero.IsGrounded = false;
                if (canMoveUp)
                {
                    direction = new Vector2(0,-1);
                    Velocity.Y = -8f;
                   
                }
                CollisionManager.collided = false;
            }
            if (!Hero.IsGrounded)
            {
                Velocity.Y += 0.12f;
            }
            if (Hero.IsGrounded)
            {
                Velocity.Y = 0;
            }

            direction.X *= 3;
            direction.Y += Velocity.Y;

            return direction;
        }
    }
}
