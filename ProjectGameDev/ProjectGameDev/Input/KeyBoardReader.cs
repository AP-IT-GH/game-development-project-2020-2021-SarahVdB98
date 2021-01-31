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

        Vector2 Velocity;

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
                if (canMoveUp)
                {
                    direction += new Vector2(0, -1);
                    Velocity.Y = -6f;
                    Hero.IsGrounded = false;
                }
            }
            if (!Hero.IsGrounded)
            {
                Velocity.Y += 0.15f;
            }
            if (Hero.IsGrounded)
            {
                Velocity.Y = 0;
            }
            //if (Hero.position.Y > 360f)
            //{
            //    Hero.IsGrounded = true;
            //}

            //direction += Velocity;
            direction.X *= 3;

            return direction;
        }
    }
}
