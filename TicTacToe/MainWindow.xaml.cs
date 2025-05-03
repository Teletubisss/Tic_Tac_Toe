
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

        private void Button_Click(object sender, RoutedEventArgs e) //funkcja, ktora sie wywola przy nacisnieciu - object sender (objekt, na ktory sendujemy), RoutedEventArgs e (potem uzywamt)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;    //przypisujemy Button do sendera, i przypisujemy go do zmiennej button
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + (row * 3);

            if (mResults[index] != Mark.Free)
            {
                return;
            }

            if (mPlayer1Turn)
            {
                mResults[index] = Mark.Cross;
            }
            else
            {
                mResults[index] = Mark.Nought;
            }
            //mResults[index] = mPlayer1Turn ? Mark.Cross : Mark.Nought - robi to samo, jesli mPl1 to cross, jesli nie to nought

            button.Content = mPlayer1Turn ? "X" : "O";

            if (mPlayer1Turn)
                mPlayer1Turn = false;
            else
            {
                button.Foreground = Brushes.Red;
                mPlayer1Turn = true;
            }
            //mPlayer1Turn ^= true;

            CheckIfWin();
        }
        private void CheckIfWin()
        {
            if (mResults[0] != Mark.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Foreground = Button1_0.Foreground = Button2_0.Foreground = Brushes.Green;
            }
            if (mResults[3] != Mark.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;
                Button0_1.Foreground = Button1_1.Foreground = Button2_1.Foreground = Brushes.Green;
            }
            if (mResults[6] != Mark.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;
                Button0_2.Foreground = Button1_2.Foreground = Button2_2.Foreground = Brushes.Green;
            }
            if (mResults[0] != Mark.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Foreground = Button0_1.Foreground = Button0_2.Foreground = Brushes.Green;
            }
            if (mResults[1] != Mark.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;
                Button1_0.Foreground = Button1_1.Foreground = Button1_2.Foreground = Brushes.Green;
            }
            if (mResults[2] != Mark.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Foreground = Button2_1.Foreground = Button2_2.Foreground = Brushes.Green;
            }
            if (mResults[0] != Mark.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Foreground = Button1_1.Foreground = Button2_2.Foreground = Brushes.Green;
            }
            if (mResults[2] != Mark.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Foreground = Button1_1.Foreground = Button0_2.Foreground = Brushes.Green;
            }

            if (!mResults.Any(result => result == Mark.Free))
            {
                mGameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Foreground = Brushes.Orange;
                });
            }

        }
    }
}