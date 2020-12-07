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
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState newstate = Keyboard.GetState();
            KeyboardState oldstate = Keyboard.GetState();
            if (newstate.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
            }
            if (newstate.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
            }
            
            if (oldstate.IsKeyDown(Keys.Space))
            {
                direction = new Vector2(0, -5);
            }
            direction *= 3;
            oldstate = newstate;

            return direction;
        }
    }
}
