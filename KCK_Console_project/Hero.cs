using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace KCK_Console_project
{
    class Hero
    {
        private int posX;
        private int posY;

        // Konstruktor.
        public Hero()
        {
            posX = 5;
            posY = 13;
            GameBoard.board[posY, posX] = 'O';
        }

        // Gettery.
        public int GetX()
        {
            return posX;
        }
        public int GetY()
        {
            return posY;
        }

        // Poruszanie sie.
        public void MoveLeft()
        {
            // Zeby nie wyjsc za sciane.
            if (posX == 0)
                return;
            // Zeby nie wejsc na drewno.
            if (posX == 1 && posY == 14)
                return;
            this.posX -= 1;
        }
        public void MoveRight()
        {
            // Zeby nie wyjsc za sciane.
            if (posX == 9)
                return;
            // Zeby nie wejsc na kamien.
            if (posX == 8 && posY == 14)
                return;
            this.posX += 1;
        }
        public void MoveUp()
        {
            if (posY == 11)
                return;
            this.posY -= 1;
        }
        public void MoveDown()
        {
            // Zeby nie wyjsc za sciane.
            if (posY == 14)
                return;
            // Zeby nie wejsc na drewno.
            if (posX == 0 && posY == 13)
                return;
            // Zeby nie wejsc na kamien.
            if (posX == 9 && posY == 13)
                return;
            this.posY += 1;
        }

        // 0 - zebrano kamien.
        // 1 - zebrano drewno.
        // 2 - nie zebrano nic.
        public int Collect(Resources res)
        {
            if (posX == 1 && posY == 14)
            {
                if (res.GetCurrentPhase(1) != 2)
                    return 2;
                GameConsole.wood += 50;
                res.WoodNextPhase();
                return 1;
            }
            if (posX == 8 && posY == 14)
            {
                if (res.GetCurrentPhase(0) != 2)
                    return 2;
                GameConsole.stone += 50;
                res.StoneNextPhase();
                return 0;
            }
            return 2;
        }

        // Czy mozna postawic wiezyczke.
        public bool CanPlace(List<Turret> turretList)
        {
            if (turretList.ElementAt(posX) == null)
            {
                if (GameConsole.wood >= Turret.GetBuildCost() && GameConsole.stone >= Turret.GetBuildCost())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        // Czy mozna ulepszyc wiezyczke.
        public bool CanUpgrade(List<Turret> turretList)
        {
            if (turretList.ElementAt(posX) != null)
            {
                Turret t = turretList.ElementAt(posX);
                if (GameConsole.wood >= t.GetUpgradeCost() && GameConsole.stone >= t.GetUpgradeCost())
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
