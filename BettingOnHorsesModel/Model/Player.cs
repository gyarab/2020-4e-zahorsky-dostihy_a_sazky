using BettingOnHorsesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BettingOnHorsesModel.Model
{
    /// <summary>
    /// Třída představující hráče. 
    /// </summary>
    public class Player
    {
        public int Cash { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Index pole, na kterém se hráč nachází.
        /// </summary>
        public int BoardIndex { get; set; }
        /// <summary>
        /// Souřadnice pole, na kterém se hráč nachází.
        /// </summary>
        public Point BoardLocation { get; set; }
        public string Color { get; set; }
        /// <summary>
        /// Zda-li je hráč stále ve hře, nebo zda-li už prohrál.
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Pořadí hráče ve hře.
        /// </summary>
        public int GameIndex { get; set; }
        /// <summary>
        /// Zda-li hráč házel kostkou. True = házel, false = neházel.
        /// </summary>
        public bool DiceRolled { get; set; }
    }
}
