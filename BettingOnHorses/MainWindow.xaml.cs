using BettingOnHorses.Services;
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
    /// Třída představující hlavní okno aplikace.
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly GameService _gameservice;
        public readonly UIService _uiservice;

        public Game CurrentGame { get; set; }

        /// <summary>
        /// Konstruktor, který připraví instance GameService a UIService.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            _gameservice = new GameService();
            _uiservice = new UIService();
        }

        /// <summary>
        /// Metoda, která po kliknutí na tlačítko nová hra zavolá metodu CreateGame, pro přípravu hry 
        /// a poté metodu DrawBoard pro vakreslení hrací plochy.
        /// </summary>
        private void ButtonNewGame_Click(object sender, RoutedEventArgs e)
        {
            CurrentGame = _gameservice.CreateGame(2);
            _uiservice.DrawBoard(CurrentGame, ref GridMain);
        }
    }
}
