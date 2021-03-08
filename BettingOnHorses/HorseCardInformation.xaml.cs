using BettingOnHorses.Services;
using BettingOnHorsesLogic.Services;
using BettingOnHorsesModel.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BettingOnHorses
{
    /// <summary>
    /// Interaction logic for HorseCardInformation.xaml
    /// Třída představující okno s kartou koně.
    /// </summary>
    public partial class HorseCardInformation : Window
    {
        private readonly UIService uiservice;
        private readonly GameService _gameservice;

        public HorseCardInformation(Game game, HorseCard card, Grid grid)
        {
            InitializeComponent();
            uiservice = new UIService();
            _gameservice = new GameService();

            var lbTitle = new Label { Content = card.Title, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
            var lbPrice = new Label { Content = card.Price, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
            var lbBetPrice = new Label { Content = card.BetCost, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
            var imgIcon = new Image { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Source = new BitmapImage(new Uri($"{card.ImageName}", UriKind.RelativeOrAbsolute)) };

            //Pokud má vlastníka, vypíše jeho jméno, pokud nemá, vypíše --- 
            if (card.Owner != null)
            {
                var lbOwner = new Label { Content = card.Owner.Name, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
                Grid.SetColumn(lbOwner, 1);
                Grid.SetRow(lbOwner, 3);
                GridHorseCardInformation.Children.Add(lbOwner);
            }
            else
            {
                var lbOwner = new Label { Content = "---", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
                Grid.SetColumn(lbOwner, 1);
                Grid.SetRow(lbOwner, 3);
                GridHorseCardInformation.Children.Add(lbOwner);
            }

            //Pokud jsou na kartě žetony, vypíše se jejich počet, pokud je jich více než 4 (tedy karta má hlavní dostih), vypíše se Hlavní dostih.
            //Pokud na koni žádné dostihy nejsou, vypíše se ---
            if(card.NumberOfBets != 0 && card.NumberOfBets <= 4)
            {
                var lbBets = new Label { Content = card.NumberOfBets, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
                Grid.SetColumn(lbBets, 1);
                Grid.SetRow(lbBets, 4);
                GridHorseCardInformation.Children.Add(lbBets);
            }
            else if(card.NumberOfBets == 5)
            {
                var lbBets = new Label { Content = "Hlavní dostih", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
                Grid.SetColumn(lbBets, 1);
                Grid.SetRow(lbBets, 4);
                GridHorseCardInformation.Children.Add(lbBets);
            }
            else
            {
                var lbBets = new Label { Content = "---", HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, FontWeight = FontWeights.Bold, FontSize = 27, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(card.Stable.StableColor) };
                Grid.SetColumn(lbBets, 1);
                Grid.SetRow(lbBets, 4);
                GridHorseCardInformation.Children.Add(lbBets);
            }

            Grid.SetColumn(lbTitle, 1);
            Grid.SetRow(lbTitle, 1);
            GridHorseCardInformation.Children.Add(lbTitle);

            Grid.SetColumn(lbPrice, 1);
            Grid.SetRow(lbPrice, 2);
            GridHorseCardInformation.Children.Add(lbPrice);
               
            Grid.SetColumn(lbBetPrice, 1);
            Grid.SetRow(lbBetPrice, 5);
            GridHorseCardInformation.Children.Add(lbBetPrice);

            Grid.SetColumn(imgIcon, 1);
            Grid.SetRow(imgIcon, 0);
            GridHorseCardInformation.Children.Add(imgIcon);

            //Pokud je hráč na tahu vlastníkem karty, zobrazí se mu tlačítko prodat kartu
            if (card.Owner == game.PlayerOnTurn) 
            {
                var buttonSell = new Button { Content = "Prodat", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Background = Brushes.LightGray, FontWeight = FontWeights.Bold, Foreground = Brushes.Black };

                Grid.SetColumn(buttonSell, 1);
                Grid.SetRow(buttonSell, 6);
                GridHorseCardInformation.Children.Add(buttonSell);

                buttonSell.Padding = new Thickness(8);

                //Přiřazení tagu tlačítka prodat, abychom mohli využít game, card a grid v metodě SellCard 
                buttonSell.Tag = new { Game = game, Card = card, Grid = grid };
                //Přidání metody po kliknuhí na tlačítko
                buttonSell.Click += SellCard;               

                //Pokud hráč vlastní všechny koně ze stáje, stojí na koni a ještě nemá zakoupen hlavní dostih, zobrazí se mu tlačítko pro koupi žetonů
                if (_gameservice.IsStableComplete(game, card) && card.NumberOfBets < 5 && card.BoardIndex == game.PlayerOnTurn.BoardIndex){
                    var buttonBet = new Button { Content = "Koupit dostih", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Background = Brushes.LightGray, FontWeight = FontWeights.Bold, Foreground = Brushes.Black };

                    Grid.SetColumn(buttonBet, 0);
                    Grid.SetRow(buttonBet, 6);
                    GridHorseCardInformation.Children.Add(buttonBet);

                    buttonBet.Padding = new Thickness(8);

                    //Přiřazení tagu tlačítka prodat, abychom mohli využít game, card a grid v metodě BuyBet 
                    buttonBet.Tag = new { Game = game, Card = card, Grid = grid };
                    //Přidání metody po kliknuhí na tlačítko
                    buttonBet.Click += BuyBet;
                }
            }

            //Pokud na kartě stojí hráč, který je na tahu a karta ještě nemá vlastníka, zobrazí se mu tlačítko koupit kartu
            if (card.BoardIndex == game.PlayerOnTurn.BoardIndex && card.Owner == null)
            {
                var buttonBuy = new Button { Content = "Koupit", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Background = Brushes.LightGray, FontWeight = FontWeights.Bold, Foreground = Brushes.Black };
                Grid.SetColumn(buttonBuy, 0);
                Grid.SetRow(buttonBuy, 6);
                GridHorseCardInformation.Children.Add(buttonBuy);

                buttonBuy.Padding = new Thickness(8);

                //Přiřazení tagu tlačítka koupit, abychom mohli využít game, card a grid v metodě BuyCard 
                buttonBuy.Tag = new { Game = game, Card = card, Grid = grid };
                //Přidání metody po kliknuhí na tlačítko
                buttonBuy.Click += BuyCard;
            }
        }

        /// <summary>
        /// Metoda pro koupi karty. Pokud má hráč finance na koupi karty, koupí jí a znovu se vykreslí aktuální herní plocha, 
        /// pokud nemá dostatek financí, vypíše se hláška.
        /// </summary>
        public void BuyCard(object sender, EventArgs e)
        {
            //Vezmeme informace z tagu
            var send = (Button)sender;
            var card = ((dynamic)send.Tag).Card;
            Game game = ((dynamic)send.Tag).Game;
            Grid grid = ((dynamic)send.Tag).Grid;

            if (game.PlayerOnTurn.Cash >= card.Price)
            {     
                card.Owner = game.PlayerOnTurn;
                game.PlayerOnTurn.Cash -= card.Price;

                uiservice.DrawBoard(game, ref grid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kartu koupit nemůžete. Nemáte dostatek financí.", "Koupě karty se nezdařila");
            }
        }

        /// <summary>
        /// Metoda pro prodej karty. Vlastník karty je nastaven na null, hráči jsou přičteny peníze, případně i za dostihy, 
        /// které na koni byly a znovu se vykreslí aktuální herní plocha.
        /// </summary>
        public void SellCard(object sender, EventArgs e)
        {
            //Vezmeme informace z tagu
            var send = (Button)sender;
            var card = ((dynamic)send.Tag).Card;
            Game game = ((dynamic)send.Tag).Game;
            Grid grid = ((dynamic)send.Tag).Grid;

            game.PlayerOnTurn.Cash += card.Price/2;
            game.PlayerOnTurn.Cash += (card.NumberOfBets * card.BetCost)/2;
            card.Owner = null;

            //Nezapomeneme nastavit hodnoty dostihů na výchozí hodnoty
            card.NumberOfBets = 0;

            uiservice.DrawBoard(game, ref grid);
            this.Close();
        }

        /// <summary>
        /// Metoda pro koupení zetonů (dostihů) na kartu koně. Vlastník koupí žeton, pokud má dostatek financí, 
        /// znovu se vykreslí aktuální hrací plocha, nebo se vypíše hláška.
        /// </summary>
        public void BuyBet(object sender, EventArgs e)
        {
            //Vezmeme informace z tagu
            var send = (Button)sender;
            var card = ((dynamic)send.Tag).Card;
            Game game = ((dynamic)send.Tag).Game;
            Grid grid = ((dynamic)send.Tag).Grid;

            //Pokud na ještě nejsou 4 dostihy a vlastník má na dostih finance, koupí si žeton
            if (game.PlayerOnTurn.Cash >= card.BetCost && card.NumberOfBets < 4)
            {     
                card.NumberOfBets ++;
                game.PlayerOnTurn.Cash -= card.BetCost;

                uiservice.DrawBoard(game, ref grid);
                this.Close();
            }
            //Pokud jsou na koni 4 dostihy a má na zakoupení dalšího dostihu finance, zakoupí hlavní dostih (žeton)
            else if (game.PlayerOnTurn.Cash >= card.BetCost && card.NumberOfBets == 4)
            {    
                card.NumberOfBets++;
                game.PlayerOnTurn.Cash -= card.BetCost;

                uiservice.DrawBoard(game, ref grid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Dostih nemůžete koupit. Nemáte dostatek financí.", "Koupě dostihu se nezdařila");
            }
        }
    }
}
