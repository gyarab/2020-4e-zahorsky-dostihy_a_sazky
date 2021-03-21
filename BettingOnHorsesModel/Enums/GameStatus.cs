using System;
using System.Collections.Generic;
using System.Text;

namespace BettingOnHorsesModel.Enums
{
    /// <summary>
    /// Výčtový typ představující status hry. Zda-li je hra aktivní, nebo neaktivní a zda-li už skončila.
    /// </summary>
    public enum GameStatus
    {
        pause,
        active,
        over
    }
}
