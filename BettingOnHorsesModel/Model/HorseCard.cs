using BettingOnHorsesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingOnHorsesModel.Model
{
    /// <summary>
    /// Třída představující kartu koně, dědí z třídy Card.
    /// </summary>
    public class HorseCard: Card
    {
        /// <summary>
        /// Zařezení do stáje.
        /// </summary>
        public Stable Stable { get; set; }
        /// <summary>
        /// Cena za koupi dostihu.
        /// </summary>
        public int BetCost { get; set; }
        /// <summary>
        /// Počet dostihů na koni.
        /// </summary>
        public int NumberOfBets { get; set; }
        /// <summary>
        /// Zda-li je na něm umístěn hlavní dostih. True = ano, False = ne.
        /// </summary>
        public bool HasMainBet { get { return NumberOfBets == 5; } }
        /// <summary>
        /// List hodnot, které zaplatí hráč vlstníhovi karty, pokud na ní stoupne. Hodnoty jsou seřazeny od ceny za 1. dostih po cenu za hravní dostih.
        /// </summary>
        public IList<int> BetPrice { get; set; }

        /// <summary>
        /// Konstruktor pro kartu koně. Přiřadí kartě obrázek, nastaví počet dostihů na 0 a zda-li má hlavní dostih nastaví na false. 
        /// </summary>
        public HorseCard()
        {
            this.ImageName = @"pack://siteoforigin:,,,/Resources/horse2.png";
            this.NumberOfBets = 0;
        }
    }
}
