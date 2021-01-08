using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectGameDev.Interfaces
{
    public interface IInputReader
    {
        public bool canMoveLeft { get; set; }
        public bool canMoveRight { get; set; }
        public bool canMoveUp { get; set; }
        public bool canMoveDown { get; set; }
        Vector2 ReadInput();
    }
}
