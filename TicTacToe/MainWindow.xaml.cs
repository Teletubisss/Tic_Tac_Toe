
using System.Windows;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;


namespace TicTacToe
{
    public partial class MainWindow : Window    //dziedziczy po klasie Window; partial - podzielona na pare plikow
    {

        #region Private Members    
        private Mark[] mResults; //tablica z tym (deklaruje ze bedzie, ale jeszcze nie istnieje - jest null), ktore pola maja jakie oznaczenie - typ Mark(przechowuje te nought, cross, free) - tablice moga byc rodzajami - noramlne, enumy i klasy
        private bool mPlayer1Turn;  //czyja kolejka
        private bool mGameEnded;  //czy gra nadal trwa
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
            mResults = new Mark[9];  //tworzymy tablice, ktora jest typu Mark[] i ma dlugosc 9 i przypisujemy ja do mResults

            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = Mark.Free; 
            }

            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEnded = false;
        }
    }
}