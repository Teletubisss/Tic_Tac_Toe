
using System.Windows;


namespace TicTacToe
{
    public partial class MainWindow : Window    //dziedziczy po klasie Window; partial - podzielona na pare plikow
    {

        #region Private Members
        private Mark[] mResults;
        private bool mPlayer1Turn;
        private bool mGameEnded;
        #endregion

        #region Constructor

        public MainWindow()    //uruchamia sie przy otworzeniu okna
        {
            InitializeComponent();   //laduje interfejs graficzny z mainwindow.xaml

            NewGame();
        }

        #endregion

        private void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}