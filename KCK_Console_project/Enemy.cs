using System;
using System.Collections.Generic;
using System.Text;

namespace KCK_Console_project
{
    class Enemy
    {
        private int hp;
        private int dmg;
        private int speed;

        private int posX;
        private int posY;

        // Konstruktor.
        public Enemy()
        {
            hp = 300;
            dmg = 10;
            speed = 1;

            Random rnd = new Random();
            posX = rnd.Next(10);
            posY = 0;
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
        public int GetDmg()
        {
            return dmg;
        }
        public int GetHP()
        {
            return hp;
        }

        // Settery.
        public void SetHP(int hp)
        {
            this.hp = hp;
        }

        // Metody.
        public void Move(char[,] board)
        {
            // Jezeli wyszedl by za sciane.
            if (posY + speed >= 10)
                return;
            // Jezeli przed nim stoi inny przeciwnik.
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
