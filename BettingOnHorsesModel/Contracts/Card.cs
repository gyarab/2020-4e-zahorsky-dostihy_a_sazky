using BettingOnHorsesModel.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BettingOnHorsesModel.Contracts
{
    /// <summary>
    /// Třída představující kartu.
    /// </summary>
    public abstract class Card
    {
        public string Title { get; set; }
        public int Price { get; set; }
        /// <summary>
        /// Cena, kterou zaplatí hráč, který na kartu stoupl vlastníkovi.
        /// </summary>
        public int InspectionPrice { get; set; }
        public string ImageName { get; set; }
        /// <summary>
        /// Index pole, na kterém se karta nachází.
        /// </summary>
        public int BoardIndex { get; set; }
        /// <summary>
        /// Souřadnice pole, na kterém se karta nachází.
        /// </summary>
        public Point BoardLocation { get; set; }
        /// <summary>
        /// Vlastník karty.
        /// </summary>
        public Player Owner { get; set; }
        public Game Game { get; set; }

    }
}
