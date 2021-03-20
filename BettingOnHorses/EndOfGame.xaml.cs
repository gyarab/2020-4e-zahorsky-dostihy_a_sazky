using BettingOnHorsesLogic.Services;
using BettingOnHorsesModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BettingOnHorses
{
    /// <summary>
    /// Interaction logic for EndOfGame.xaml
    /// Třída představující okno s pořadím hráčů na konci hry.
    /// </summary>
    public partial class EndOfGame : Window
    {
        private readonly GameService _gameservice;
        public EndOfGame(Game game)
        {
            InitializeComponent();
            _gameservice = new GameService();

            StackPanel spEnd = new StackPanel { VerticalAlignment = VerticalAlignment.Center };

            var lbEnd = new Label { Content = "Konec hry!", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Foreground = Brushes.Sienna, FontWeight = FontWeights.Bold, FontSize = 30 };
            var lbThank = new Label { Content = "Děkuji, že jste hráli.", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Foreground = Brushes.Sienna, FontWeight = FontWeights.Bold, FontSize = 20 };

            spEnd.Children.Add(lbEnd);
            spEnd.Children.Add(lbThank);

            Grid.SetColumn(spEnd, 0);
            Grid.SetRow(spEnd, 0);
            GridEndOfGame.Children.Add(spEnd);

            //Vypíšeme seřazené hráče            
            for (int i = 0; i < game.PlayersByPosition.Count; i++)
            {
                StackPanel spPlayerInfo = new StackPanel();
                spPlayerInfo.VerticalAlignment = VerticalAlignment.Center;

                var lbPlayerTitle = new Label { Content = "Na " + (i+1) + ". místě se umístil hráč: " + game.PlayersByPosition[i].Name, HorizontalAlignment = HorizontalAlignment.Center, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(game.PlayersByPosition[i].Color), FontWeight = FontWeights.Bold };
                var lbPlayerCash = new Label { Content = "Peníze: " + game.PlayersByPosition[i].Cash, HorizontalAlignment = HorizontalAlignment.Center, Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(game.PlayersByPosition[i].Color), FontWeight = FontWeights.Bold };

                lbPlayerTitle.Margin = new Thickness(-5);
                lbPlayerCash.Margin = new Thickness(-5);

                spPlayerInfo.Children.Add(lbPlayerTitle);
                spPlayerInfo.Children.Add(lbPlayerCash);

                Grid.SetColumn(spPlayerInfo, 0);
                Grid.SetRow(spPlayerInfo, i+1);
                GridEndOfGame.Children.Add(spPlayerInfo);
            }
        }
    }
}
