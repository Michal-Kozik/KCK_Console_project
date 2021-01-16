using System;

namespace KCK_Console_project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resume = true;
            while (resume)
            {
                GameConsole game = new GameConsole();
                game.menu();
                game.run();
                resume = game.End();
            }
        }
    }
}
