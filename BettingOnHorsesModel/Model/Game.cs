using BettingOnHorsesModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BettingOnHorsesModel.Model
{
    /// <summary>
    /// Třída představující hru.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Seznam hráčů, kterí jsou ve hře.
        /// </summary>
        public IList<Player> Players { get; set; }
        /// <summary>
        /// Status nám říká, zda-li je hra pořád aktivní.
        /// </summary>
        public GameStatus Status { get; set; }
        /// <summary>
        /// Hrací plocha.
        /// </summary>
        public Board Board { get; set; }
        /// <summary>
        /// Hráč, který je na tahu.
        /// </summary>
        public Player PlayerOnTurn { get; set; }    
        public IList<Player> PlayersByPosition { get { return this.Players.OrderBy(o => -o.BoardIndex).ToList(); } }
    }
}
