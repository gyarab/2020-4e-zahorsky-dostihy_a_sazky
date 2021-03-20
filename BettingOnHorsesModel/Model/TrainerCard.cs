using BettingOnHorsesModel.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingOnHorsesModel.Model
{
    /// <summary>
    /// Třída představující kartu trenéra, dědí z třídy Card.
    /// </summary>
    public class TrainerCard: Card
    {
        /// <summary>
        /// Konstruktor pro kartu trenéra. Přiřadí kartě obrázek, nastaví jméno na Trenér a cenu 40000.
        /// </summary>
        public TrainerCard()
        {
            this.Price = 4000;
            this.ImageName = @"pack://siteoforigin:,,,/Resources/trainer2.png";
        }
    }
}
