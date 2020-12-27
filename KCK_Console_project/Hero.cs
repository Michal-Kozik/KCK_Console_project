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

        //konstruktor
        public Hero()
        {
            posX = 5;
            posY = 13;
            GameBoard.board[posY, posX] = 'O';
        }

        //gettery
        public int GetX()
        {
            return posX;
        }
        public int GetY()
        {
            return posY;
        }

        //poruszanie sie
        public void MoveLeft()
        {
            //zeby nie wyjsc za sciane
            if (posX == 0)
                return;
            //zeby nie wejsc na drewno
            if (posX == 1 && posY == 14)
                return;
            this.posX -= 1;
        }
        public void MoveRight()
        {
            //zeby nie wyjsc za sciane
            if (posX == 9)
                return;
            //zeby nie wejsc na kamien
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
            //zeby nie wyjsc za sciane
            if (posY == 14)
                return;
            //zeby nie wejsc na drewno
            if (posX == 0 && posY == 13)
                return;
            //zeby nie wejsc na kamien
            if (posX == 9 && posY == 13)
                return;
            this.posY += 1;
        }

        // 0 - zebrano kamien
        // 1 - zebrano drewno
        // 2 - nie zebrano nic
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

        //czy mozna postawic wiezyczke
        public bool CanPlace(List<Turret> turretList)
        {
            //stoi jakas wiezyczka
            /*foreach (Turret turret in turretList)
            {
                if (turret.GetX() == posX)
                {
                    return false;
                }
            }*/
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
        //czy mozna ulepszyc wiezyczke
        public bool CanUpgrade(List<Turret> turretList)
        {
            //stoi jakas wiezyczka
            /*foreach (Turret turret in turretList)
            {
                if (turret.GetX() == posX)
                {
                    if (GameConsole.wood >= turret.GetUpgradeCost() && GameConsole.stone >= turret.GetUpgradeCost())
                        return true;
                    else
                        return false;
                }
            }*/
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
