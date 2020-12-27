using System;
using System.Collections.Generic;
using System.Text;

namespace KCK_Console_project
{
    class Enemy
    {
        /*
         * - Wsadzic przeciwnikow do listy
         * - foreachem przechodze po liscie
         * - dla kazdego przeciwnika wykona sie Move()
         * - przeciwnicy beda ustawiac sie w kolejki 
         */

        private int hp;
        private int dmg;
        private int speed;

        private int posX;
        private int posY;

        //konstruktor
        public Enemy()
        {
            hp = 300;
            dmg = 10;
            speed = 1;

            Random rnd = new Random();
            posX = rnd.Next(10);
            posY = 0;
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
        public int GetDmg()
        {
            return dmg;
        }
        public int GetHP()
        {
            return hp;
        }

        //settery
        public void SetHP(int hp)
        {
            this.hp = hp;
        }

        //metody
        public void Move(char[,] board)//board[15, 10]
        {
            //jezeli wyszedl by za sciane
            if (posY + speed >= 10)
                return;
            //jezeli przed nim stoi inny przeciwnik
            if (board[posY + speed, posX] == '@')
                return;

            posY += speed;
        }
        public void Hit(int dmg)
        {
            hp -= dmg;

        }

    }
}
