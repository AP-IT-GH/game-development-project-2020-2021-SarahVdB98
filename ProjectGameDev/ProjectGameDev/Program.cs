using System;

namespace ProjectGameDev
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using ( var game = new Game1())
                game.Run();
        }
    }
}
