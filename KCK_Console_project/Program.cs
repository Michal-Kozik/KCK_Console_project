using System;

namespace KCK_Console_project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            GameConsole game = new GameConsole();
            game.menu();
            game.run();
        }
    }
}
