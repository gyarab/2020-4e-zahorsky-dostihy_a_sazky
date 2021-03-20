using BettingOnHorsesModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BettingOnHorsesModel.Model
{
    /// <summary>
    /// Třída představující stáj.
    /// </summary>
    public class Stable
    {
        /// <summary>
        /// Barva stáje.
        /// </summary>
        public string StableColor { get; set; }
        /// <summary>
        /// Metoda spočítá počet koní ve stáji.
        /// </summary>
        public int GetCountOfHorses(Board board)
        {
            return board.Where(x => x.GetType() == typeof(HorseCard) && ((HorseCard)x).Stable == this).Count();
        }
}

}
