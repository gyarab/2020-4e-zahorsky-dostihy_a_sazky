using BettingOnHorsesLogic.Services;
using BettingOnHorsesModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BettingOnHorses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly GameService _gameservice;
        public Game CurrentGame { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            _gameservice = new GameService();
        }

        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame = _gameservice.CreateGame(2);

            foreach( var card in CurrentGame.GameBoard)
            {
                var lbPrice = new Label { Content = card.Price, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment  = VerticalAlignment.Center, Foreground = Brushes.Red };
                var lbTitle = new Label { Content = card.Title, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Foreground = Brushes.Red };
                var imgIcon = new Image { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center, Source = new BitmapImage(new Uri($"{card.ImageName}", UriKind.RelativeOrAbsolute)) };

                Panel.SetZIndex(lbTitle, 2);
                Panel.SetZIndex(lbPrice, 2);
                Panel.SetZIndex(imgIcon, 1);

                Grid.SetColumn(lbTitle, card.BoardLocation.X);
                Grid.SetRow(lbTitle, card.BoardLocation.Y);
                GridMain.Children.Add(lbTitle);


                Grid.SetColumn(lbPrice, card.BoardLocation.X);
                Grid.SetRow(lbPrice, card.BoardLocation.Y);
                GridMain.Children.Add(lbPrice);

                Grid.SetColumn(imgIcon, card.BoardLocation.X);
                Grid.SetRow(imgIcon, card.BoardLocation.Y);
                GridMain.Children.Add(imgIcon);
            }


        }


    }
}
