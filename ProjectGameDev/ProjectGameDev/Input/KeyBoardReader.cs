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
                    direction = new Vector2(0, -100);
                }
                Hero.IsGrounded = false;
                canMoveUp = true;
                canMoveRight = true; canMoveLeft = true;
            }

            direction *= 3;

            return direction;
        }
    }
}
