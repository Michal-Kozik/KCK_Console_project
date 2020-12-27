using System;
using System.Collections.Generic;
using System.Text;

namespace KCK_Console_project
{
    class Resources
    {
        private int woodCurrentPhase;
        private int stoneCurrentPhase;
        private char woodCurrentSymbol;
        private char stoneCurrentSymbol;

        //konstruktor
        public Resources()
        {
            woodCurrentPhase = 0;
            woodCurrentSymbol = 'v';
            stoneCurrentPhase = 0;
            stoneCurrentSymbol = 's';
        }

        //gettery
        // 1 - drewno, 0 - kamien
        public int GetCurrentPhase(int which)
        {
            if (which == 1)
                return woodCurrentPhase;
            else
                return stoneCurrentPhase;
        }
        public char GetCurrentSymbol(int which)
        {
            if (which == 1)
                return woodCurrentSymbol;
            else
                return stoneCurrentSymbol;
        }

        //metody
        public void WoodNextPhase()
        {
            woodCurrentPhase += 1;
            woodCurrentPhase %= 3;
            switch (woodCurrentPhase)
            {
                case 0:
                    woodCurrentSymbol = 'v';
                    break;
                case 1:
                    woodCurrentSymbol = 'w';
                    break;
                default:
                    woodCurrentSymbol = 'W';
                    break;
            }
        }
        public void StoneNextPhase()
        {
            stoneCurrentPhase += 1;
            stoneCurrentPhase %= 3;
            switch (stoneCurrentPhase)
            {
                case 0:
                    stoneCurrentSymbol = 's';
                    break;
                case 1:
                    stoneCurrentSymbol = 'S';
                    break;
                default:
                    stoneCurrentSymbol = '$';
                    break;
            }
        }
    }
}
