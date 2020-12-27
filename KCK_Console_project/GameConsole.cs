using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Windows.Input;
using System.Linq;

namespace KCK_Console_project
{
    class GameConsole
    {
        public static int wood = 1000;
        public static int stone = 1000;
        public static int hp = 100;
        public static int score = 0;
        //20 FPS
        private static int woodFrames = 0;
        private static int stoneFrames = 0;
        private static int enemyFrames = 0;
        private int collected;

        public void run()
        {
            GameConsoleRender render = new GameConsoleRender();
            GameBoard board = new GameBoard();
            Hero hero = new Hero();
            Resources resources = new Resources();
            List<Enemy> enemyList = new List<Enemy>();
            List<Enemy> enemiesUnderWall = new List<Enemy>();
            for (int i = 0; i < 10; i++)
                enemiesUnderWall.Add(null);
            List<Turret> turretList = new List<Turret>();
            for (int i = 0; i < 10; i++)
                turretList.Add(null);

            Console.Clear();
            board.CreateBoard();
            board.PrintBoard();
            render.HeroPrint(hero);
            Console.SetCursorPosition(0, 16);
            Console.Write("Drewno - " + wood);
            Console.SetCursorPosition(0, 17);
            Console.Write("Kamien - " + stone);
            Console.SetCursorPosition(0, 18);
            Console.Write("HP: " + hp);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 19);
            Console.Write("Zycie przeciwnikow ===== Amunicja ========");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 20);
                Console.Write("Przeciwnik " + i + " : " + 0 + "     ");
                Console.SetCursorPosition(25, i + 20);
                Console.Write("Wiezyczka nr " + i + ": " + 0 + "     ");
            }
            //testowanie
            //Enemy enemy = new Enemy();
            //enemyList.Add(enemy);
            //render.EnemyPrint(enemy);

            while (true)
            {
                //zliczanie klatek
                if (woodFrames < 202)
                    woodFrames += 1;
                if (stoneFrames < 202)
                    stoneFrames += 1;
                enemyFrames %= 201;
                enemyFrames += 1;
                //nasluchiwanie sterowania
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.DownArrow:
                            hero.MoveDown();
                            render.MoveDownRender(hero, resources);
                            break;
                        case ConsoleKey.UpArrow:
                            hero.MoveUp();
                            render.MoveUpRender(hero, resources);
                            break;
                        case ConsoleKey.LeftArrow:
                            hero.MoveLeft();
                            render.MoveHorizontalRender(hero, resources);
                            break;
                        case ConsoleKey.RightArrow:
                            hero.MoveRight();
                            render.MoveHorizontalRender(hero, resources);
                            break;
                        case ConsoleKey.Enter:
                            collected = hero.Collect(resources);
                            render.CollectRender(hero, resources);
                            //budowanie
                            if (hero.GetY() == 11 && hero.CanPlace(turretList) == true)
                            {
                                Turret turret = new Turret(hero);
                                turretList.RemoveAt(hero.GetX());
                                turretList.Insert(hero.GetX(), turret);
                                render.AddTurret(turret, board.GetBoard());
                                wood -= Turret.GetBuildCost();
                                stone -= Turret.GetBuildCost();
                                render.UpdateResources();
                                render.RefreshAmmo(turret);
                            }
                            //ulepszanie
                            else if (hero.GetY() == 11 && hero.CanUpgrade(turretList) == true)
                            {
                                if (turretList.ElementAt(hero.GetX()) != null)
                                {
                                    Turret t = turretList.ElementAt(hero.GetX());
                                    wood -= t.GetUpgradeCost();
                                    stone -= t.GetUpgradeCost();
                                    t.Upgrade();
                                    render.UpdateResources();
                                    render.AddTurret(t, board.GetBoard());
                                    render.RefreshAmmo(t);
                                }
                            }
                            break;
                    }
                }

                //poruszanie sie przeciwnikow i tworzenie
                if (enemyFrames % 50 == 0)
                {
                    //renderowanie pola z przeciwnikami
                    if (enemyList.Count > 0)
                        foreach (Enemy e in enemyList)
                        {
                            e.Move(board.GetBoard());
                            if (e.GetY() == 9)
                            {
                                enemiesUnderWall.RemoveAt(e.GetX());
                                enemiesUnderWall.Insert(e.GetX(), e);
                            }

                        }
                    render.EnemyMoveAll(enemyList, board.GetBoard());

                    //tworzenie nowego przeciwnika
                    if (enemyFrames == 200)
                    {
                        Enemy e = new Enemy();
                        enemyList.Add(e);
                        render.EnemyPrint(e, board.GetBoard());
                    }
                }

                //zadawanie obrazen przeciwnikom
                if (enemyFrames % 20 == 0)
                {
                    List<Enemy> pom = new List<Enemy>();
                    bool shouldRefresh = false;
                    foreach (Enemy e in enemiesUnderWall)
                    {
                        //jesli na scianie stoi wiezyczka przed przeciwnikiem
                        if (e != null && turretList.ElementAt(e.GetX()) != null)
                        {
                            Turret t = turretList.ElementAt(e.GetX());
                            e.Hit(t.GetDmg());
                            //wiezyczka traci pocisk
                            t.Shot();
                            //jesli wiezyczka nie ma juz naboi
                            if (t.GetAmmo() <= 0)
                            {
                                turretList.RemoveAt(e.GetX());
                                turretList.Insert(e.GetX(), null);
                                render.UpdateWall(t, board.GetBoard());
                            }
                        }
                        //jesli hp przeciwnika spadnie do 0
                        //pomocnicza lista do usuwania przeciwnikow
                        if (e != null && e.GetHP() <= 0)
                        {
                            pom.Add(e);
                            shouldRefresh = true;
                            score += 250;
                            Console.SetCursorPosition(0, 15);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Punkty: " + score);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    render.ShowDmgDealt(enemiesUnderWall, turretList);
                    if (shouldRefresh == true)
                    {
                        foreach (Enemy e in pom)
                        {
                            enemiesUnderWall.RemoveAt(e.GetX());
                            enemiesUnderWall.Insert(e.GetX(), null);
                            enemyList.Remove(e);
                        }
                        render.DeleteRefresh(enemiesUnderWall, board.GetBoard());
                    }
                }

                //zadawanie obrazen przez przeciwnikow
                if (enemyFrames % 100 == 0)
                {
                    foreach (Enemy e in enemyList)
                    {
                        if (e.GetY() == 9)
                        {
                            hp -= e.GetDmg();
                            Console.SetCursorPosition(0, 18);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("HP: " + hp + ' ');
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                }


                //czy zebrano zasoby
                if (collected == 0)
                {
                    stoneFrames = 0;
                    collected = 2;
                }
                else if (collected == 1)
                {
                    woodFrames = 0;
                    collected = 2;
                }


                //generowanie zasobow
                if (woodFrames == 100 || woodFrames == 200)
                {
                    resources.WoodNextPhase();
                    Console.SetCursorPosition(0, 14);
                    Console.Write(resources.GetCurrentSymbol(1));
                }
                if (stoneFrames == 100 || stoneFrames == 200)
                {
                    resources.StoneNextPhase();
                    Console.SetCursorPosition(9, 14);
                    Console.Write(resources.GetCurrentSymbol(0));
                }

                //czekanie
                Thread.Sleep(50);
            }
        }

        public void menu()
        {
            Console.WriteLine("1. opcja");
            Console.WriteLine("2. opcja");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("Wybrano 1.");
                            return;
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("Wybrano 2.");
                            return;
                        case ConsoleKey.Spacebar:
                            Console.WriteLine("WCISNIETO SPACJE");
                            Thread.Sleep(2000);
                            return;
                    }
                }
            }
        }
    }
}
