using System;
using System.Collections.Generic;
using System.Text;

namespace BettingOnHorsesLogic.Contracts
{
    /// <summary>
    /// Třída představující průběh hry.
    /// </summary>
    public class TurnResult
    {
        /// <summary>
        /// Kontroluje, zda-li hra skončila.
        /// </summary>
        public bool GameOver { get; set; }
        /// <summary>
        /// Kontroluje, zda-li hráč prošel startem.
        /// </summary>
        public bool StartPassing { get; set; }
    }
}
