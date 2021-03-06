﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using System.Linq;

namespace KCK_Console_project
{
    class GameConsoleRender
    {
        private string myHero = "O";
        private int posX;
        private int posY;

        public void HeroPrint(Hero hero)
        {
            posX = hero.GetX();
            posY = hero.GetY();
            Console.SetCursorPosition(0, posY);
            Console.WriteLine(myHero.PadLeft(posX + 1, '.') + new string('.', 9 - posX));
        }

        public void InfoPrint()
        {
            string text;                                        //
            Console.SetCursorPosition(20, 15);                   //
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write("/" + new string('-', 30) + "\\");    //

            Console.SetCursorPosition(20, 16);
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write("|");                                 //
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Punkty: " + GameConsole.score);
            text = "Punkty: " + GameConsole.score;              //
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write(new string(' ', 30 - text.Length) + "|"); //

            Console.SetCursorPosition(20, 17);
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write("|");                                 //
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Drewno - " + GameConsole.wood);
            text = "Drewno - " + GameConsole.wood;              //
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write(new string(' ', 30 - text.Length) + "|"); //

            Console.SetCursorPosition(20, 18);
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write("|");                                 //
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Kamien - " + GameConsole.stone);
            text = "Kamien - " + GameConsole.stone;              //
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write(new string(' ', 30 - text.Length) + "|"); //

            Console.SetCursorPosition(20, 19);
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write("|");                                 //
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("HP: " + GameConsole.hp);
            text = "HP: " + GameConsole.hp;                     //
            Console.ForegroundColor = ConsoleColor.Magenta;     //
            Console.Write(new string(' ', 30 - text.Length) + "|"); //

            Console.SetCursorPosition(20, 20);
            Console.Write("\\" + new string('-', 30) + "/");    //

            Console.SetCursorPosition(20, 0);
            Console.Write("/" + new string('-', 46) + "\\");

            Console.SetCursorPosition(20, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Zycie przeciwnikow ==== Amunicja ========");
            text = "Zycie przeciwnikow ==== Amunicja ========";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(new string(' ', 46 - text.Length) + "|");

            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(20, i + 2);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Przeciwnik " + i + " : " + 0 + "     ");
                Console.SetCursorPosition(45, i + 2);
                Console.Write("Wiezyczka nr " + i + ": " + 0 + "     ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("|");
            }

            Console.SetCursorPosition(20, 12);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\\" + new string('-', 46) + "/");
            
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void MoveHorizontalRender(Hero hero, Resources resources)
        {
            posX = hero.GetX();
            posY = hero.GetY();
            if (posY == 14)
            {
                Console.SetCursorPosition(0, posY);
                Console.WriteLine(resources.GetCurrentSymbol(1) + myHero.PadLeft(posX, '.') + new string('.', 8 - posX) + resources.GetCurrentSymbol(0));
            }
            else
            {
                Console.SetCursorPosition(0, posY);
                Console.WriteLine(myHero.PadLeft(posX + 1, '.') + new string('.', 9 - posX));
            }
        }

        public void MoveUpRender(Hero hero, Resources resources)
        {
            posX = hero.GetX();
            posY = hero.GetY();
            if (posY == 13)
            {
                Console.SetCursorPosition(0, posY + 1);
                Console.WriteLine(resources.GetCurrentSymbol(1) + new string('.', 8) + resources.GetCurrentSymbol(0));
            }
            else
            {
                Console.SetCursorPosition(0, posY + 1);
                Console.WriteLine(new string('.', 10));
            }
            Console.SetCursorPosition(0, posY);
            Console.WriteLine(myHero.PadLeft(posX + 1, '.') + new string('.', 9 - posX));
        }

        public void MoveDownRender(Hero hero, Resources resources)
        {
            posX = hero.GetX();
            posY = hero.GetY();
            Console.SetCursorPosition(0, posY - 1);
            Console.WriteLine(new string('.', 10));
            if (posY == 14)
            {
                Console.SetCursorPosition(0, posY);
                Console.WriteLine(resources.GetCurrentSymbol(1) + myHero.PadLeft(posX, '.') + new string('.', 8 - posX) + resources.GetCurrentSymbol(0));
            }
            else
            {
                Console.SetCursorPosition(0, posY);
                Console.WriteLine(myHero.PadLeft(posX + 1, '.') + new string('.', 9 - posX));
            }
        }

        public void CollectRender(Hero hero, Resources resources)
        {
            posX = hero.GetX();
            posY = hero.GetY();
            // Drewno.
            if (posX == 1 && posY == 14)
            {
                string text;
                Console.SetCursorPosition(0, 14);
                Console.Write(resources.GetCurrentSymbol(1));
                // Wyswietlenie wyniku.
                Console.SetCursorPosition(20, 17);
                Console.ForegroundColor = ConsoleColor.Magenta;     //
                Console.Write("|");                                 //
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Drewno - " + GameConsole.wood + "     ");
                text = "Drewno - " + GameConsole.wood + "     ";    //
                Console.ForegroundColor = ConsoleColor.Magenta;     //
                Console.Write(new string(' ', 30 - text.Length) + "|"); //
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
            // Kamien.
            if (posX == 8 && posY == 14)
            {
                string text;
                Console.SetCursorPosition(9, 14);
                Console.Write(resources.GetCurrentSymbol(0));
                // Wyswietleniue wyniku.
                Console.SetCursorPosition(20, 18);
                Console.ForegroundColor = ConsoleColor.Magenta;     //
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Kamien - " + GameConsole.stone + "     ");
                text = "Kamien - " + GameConsole.stone + "     ";    //
                Console.ForegroundColor = ConsoleColor.Magenta;     //
                Console.Write(new string(' ', 30 - text.Length) + "|"); //
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
        }

        public void UpdateResources()
        {
            string text;
            Console.SetCursorPosition(20, 17);
            Console.ForegroundColor = ConsoleColor.Magenta; //
            Console.Write("|");                             //
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Drewno - " + GameConsole.wood + "     ");
            text = "Drewno - " + GameConsole.wood + "     ";//
            Console.ForegroundColor = ConsoleColor.Magenta; //
            Console.Write(new string(' ', 30 - text.Length) + "|"); //

            Console.SetCursorPosition(20, 18);
            Console.ForegroundColor = ConsoleColor.Magenta; //
            Console.Write("|");                             //
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Kamien - " + GameConsole.stone + "     ");
            text = "Kamien - " + GameConsole.stone + "     ";//
            Console.ForegroundColor = ConsoleColor.Magenta; //
            Console.Write(new string(' ', 30 - text.Length) + "|"); //

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void UpdateWall(Turret turret, char[,] board)
        {
            posX = turret.GetX();
            posY = turret.GetY();
            board[10, posX] = '#';
            Console.SetCursorPosition(0, 10);
            for (int i = 0; i < 10; i++)
                Console.Write(board[10, i]);
        }

        public void EnemyPrint(Enemy enemy, char[,] board)
        {
            posX = enemy.GetX();
            posY = enemy.GetY();
            board[posY, posX] = '@';
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 10; i++)
                Console.Write(board[0, i]);
        }

        public void EnemyMoveAll(List<Enemy> enemies, char[,] board)
        {
            foreach (Enemy e in enemies)
            {
                board[e.GetY() - 1, e.GetX()] = '.';
                board[e.GetY(), e.GetX()] = '@';
            }
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < 10; y++)    // KOLUMNY
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < 10; x++)    // WIERSZE
                {
                    Console.Write(board[y, x]);
                }
            }
        }

        public void DeleteRefresh(List<Enemy> enemiesUnderWall, char[,] board)
        {
            for (int i = 0; i < 10; i++)
                board[9, i] = '.';
            foreach (Enemy e in enemiesUnderWall)
            {
                if (e != null)
                    board[9, e.GetX()] = '@';
            }
            Console.SetCursorPosition(0, 9);
            for (int i = 0; i < 10; i++)
                Console.Write(board[9, i]);
        }

        public void AddTurret(Turret turret, char[,] board)
        {
            posX = turret.GetX();
            posY = turret.GetY();
            board[10, posX] = turret.GetLevelChar();
            Console.SetCursorPosition(0, 10);
            for (int i = 0; i < 10; i++)
                Console.Write(board[10, i]);
        }

        public void ShowDmgDealt(List<Enemy> enemiesUnderWall, List<Turret> turrets)
        {
            foreach (Enemy e in enemiesUnderWall)
            {
                int magazine;
                if (e != null)
                {
                    if (e.GetHP() < 0)
                        e.SetHP(0);
                    if (turrets.ElementAt(e.GetX()) == null)
                        magazine = 0;
                    else
                        magazine = turrets.ElementAt(e.GetX()).GetAmmo();
                    Console.SetCursorPosition(20, e.GetX() + 2);
                    Console.ForegroundColor = ConsoleColor.Magenta;     //
                    Console.Write("|");                                 //
                    Console.ForegroundColor = ConsoleColor.Gray;        //
                    Console.Write("Przeciwnik " + e.GetX() + " : " + e.GetHP() + "     ");
                    Console.SetCursorPosition(45, e.GetX() + 2);
                    Console.Write("Wiezyczka nr " + e.GetX() + ": " + magazine + "     ");
                    Console.ForegroundColor = ConsoleColor.Magenta;     //
                    Console.Write("|");                                 //
                    Console.ForegroundColor = ConsoleColor.Gray;        //
                }
            }
        }

        public void RefreshAmmo(Turret turret)
        {
            Console.SetCursorPosition(45, turret.GetX() + 2);
            Console.Write("Wiezyczka nr " + turret.GetX() + ": " + turret.GetAmmo() + "     ");
        }
    }
}
