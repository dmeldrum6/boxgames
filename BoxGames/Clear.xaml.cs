using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace BoxGames
{
    /// <summary>
    /// Interaction logic for Clear.xaml
    /// </summary>
    public partial class Clear : Window
    {
        // set up single Random for game use
        public class RandomHolder
        {
            private static Random _instance;
            public static Random Instance
            {
                get { return _instance ?? (_instance = new Random()); }
            }
        }

        int RowMax = 12;
        int ColMax = 28;
        int Score = 0;

        public Clear()
        {
            InitializeComponent();

            SetupClearGame();
        }

        private void SetupClearGame()
        {
            try
            {
                // Set Current Game score to 0, fetch high score
                tbClearYourScore.Text = "0";
                tbClearHighScore.Text = Properties.Settings.Default.ClearHigh;

                // Loop through grid adding rectangles in every cell
                for (var r = 0; r < RowMax; r++)        // Row Loop
                {
                    for (var c = 0; c < ColMax; c++)    // Column Loop
                    {
                        Rectangle rectLoop = new Rectangle();
                        rectLoop.Fill = MainGame.GetAColor();
                        rectLoop.MouseDown += rectLoop_MouseDown;
                        gridClearBoard.Children.Add(rectLoop);
                        Grid.SetColumn(rectLoop, c);
                        Grid.SetRow(rectLoop, r);
                    }
                }
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Setup Clear Game", x.Message);
            }
        }
        
        private void rectLoop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var MainG = new MainGame();
                Rectangle rClick = sender as Rectangle;                 // The Clicked Rectangle

                int mCount = MainG.RectLinks(rClick, gridClearBoard);   // Count matches - fill match / select table
                if (mCount >= 1)                                        // There is at least 2 - remove them and add points
                {
                    foreach (Rectangle rect in MainG.rEcts)             // remove the detected connecting matches
                    {
                        gridClearBoard.Children.Remove(rect);
                    }
                    MainG.CompactGrid(gridClearBoard);                  // run compact routine to lower blocks
                    Score = Score + (mCount * (mCount - 1));            // the more boxes at one time, the higher the score
                    tbClearYourScore.Text = Score.ToString();           // update display
                }
                int MovesLeft = MainG.AnyMovesLeft(gridClearBoard);

                if (MovesLeft == 0)                                     // If no moves are left - end the game
                {
                    MessageBox.Show("No More Moves! Score: " + Score.ToString());
                    if (Convert.ToInt32(Properties.Settings.Default.ClearHigh) < Score)
                    {
                        Properties.Settings.Default.ClearHigh = Score.ToString();
                        Properties.Settings.Default.Save();
                    }
                }
                gridClearBoard.UpdateLayout();
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Clear Game Mouse Down", x.Message);
            }
        }

        private void butClearExit_Click(object sender, RoutedEventArgs e)
        {
            // Close this Window
            this.Close();
        }

        private void butClearRestart_Click(object sender, RoutedEventArgs e)
        {
            // Reset a new game
            SetupClearGame();
        }

        private void winClear_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Refocus the Game Menu Window
            if (null != this.Owner)
            {
                this.Owner.Activate();
            }
        }

    }
}
