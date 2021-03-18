using BettingOnHorsesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BettingOnHorsesModel.Model
{
    /// <summary>
    /// Třída předsatvující hrací plochu.
    /// </summary>
    public class Board : List<Card>
    {
        /// <summary>
        /// Kostka.
        /// </summary>
        private Random Dice { get; set; }
        /// <summary>
        /// Konstruktor, který připraví kostku.
        /// </summary>
        public Board()
        {
            Dice = new Random();
        }
        /// <summary>
        /// Metoda, která zajistí házení kostkou.
        /// </summary>
        public int DiceRoll()
        {            
            return Dice.Next(1, 6);
        }
        /// <summary>
        /// Metoda vrátí souřadnice pro kartu nebo hráče podle indexu, který je předán v paramteru.
        /// </summary>
        public static Point GetLocation(int boardIndex)
        {            
            if (boardIndex <= 7)
            {
                return new Point(boardIndex + 1, 1);
            }

            if (boardIndex > 7 && boardIndex <= 13)
            {
                return new Point(8, boardIndex - 6);
            }

            if (boardIndex == 14)
            {
                return new Point(8, 8);
            }

            if (boardIndex == 15)
            {
                return new Point(7, 8);
            }

            if (boardIndex == 16)
            {
                return new Point(6, 8);
            }

            if (boardIndex == 17)
            {
                return new Point(5, 8);
            }

            if (boardIndex == 18)
            {
                return new Point(4, 8);
            }

            if (boardIndex == 19)
            {
                return new Point(3, 8);
            }

            if (boardIndex == 20)
            {
                return new Point(2, 8);
            }

            if (boardIndex == 21)
            {
                return new Point(1, 8);
            }

            if (boardIndex == 22)
            {
                return new Point(1, 7);
            }

            if (boardIndex == 23)
            {
                return new Point(1, 6);
            }

            if (boardIndex == 24)
            {
                return new Point(1, 5);
            }

            if (boardIndex == 25)
            {
                return new Point(1, 4);
            }

            if (boardIndex == 26)
            {
                return new Point(1, 3);
            }

            if (boardIndex == 27)
            {
                return new Point(1, 2);
            }

            return new Point(0, 0);
        }
    }
}
