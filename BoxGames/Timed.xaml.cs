using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace BoxGames
{
    /// <summary>
    /// Interaction logic for Timed.xaml
    /// </summary>
    public partial class Timed : Window
    {
        System.Windows.Threading.DispatcherTimer gTimer = new System.Windows.Threading.DispatcherTimer();

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
        int Tick = 0;

        public Timed()
        {
            InitializeComponent();

            SetupTimedGame();
        }

        private void SetupTimedGame()
        {
            try
            {
                // Reset in case a successive run
                gTimer.Stop();
                Tick = 0;
                Score = 0;
                gridTimedBoard.Children.Clear();

                // Set Current Game score to 0, fetch high score
                tbTimedYourScore.Text = "0";
                tbTimedHighScore.Text = Properties.Settings.Default.TimedHigh;

                // Loop through grid adding rectangles in every cell
                for (int r = 0; r < RowMax; r++)        // Row Loop
                {
                    for (int c = 0; c < ColMax; c++)    // Column Loop
                    {
                        Rectangle rectLoop = new Rectangle();
                        rectLoop.Fill = MainGame.GetAColor();
                        rectLoop.MouseDown += rectLoop_MouseDown;
                        gridTimedBoard.Children.Add(rectLoop);
                        Grid.SetColumn(rectLoop, c);
                        Grid.SetRow(rectLoop, r);
                    }
                }

                // Setup and Start Timer
                gTimer.Tick += new EventHandler(gTimer_Tick);
                gTimer.Interval = new TimeSpan(0, 0, 1);
                gTimer.Start();
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Timed Game Setup", x.Message);
            }
        }

        private void rectLoop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var MainG = new MainGame();
                Rectangle rClick = sender as Rectangle;                 // The Clicked Rectangle

                int mCount = MainG.RectLinks(rClick, gridTimedBoard);   // Count matches - fill match / select table
                if (mCount >= 1)                                        // There is at least 2 - remove them and add points
                {
                    foreach (Rectangle rect in MainG.rEcts)             // remove the detected connecting matches
                    {
                        gridTimedBoard.Children.Remove(rect);
                    }
                    MainG.CompactGrid(gridTimedBoard);                  // run compact routine to lower blocks
                    Score = Score + (mCount * (mCount - 1));            // the more boxes at one time, the higher the score
                    tbTimedYourScore.Text = Score.ToString();           // update display
                }

                ReFill();                                               // refill routine fills the board back in

                int MovesLeft = MainG.AnyMovesLeft(gridTimedBoard);

                if (MovesLeft == 0)                                     // If no moves are left - end the game
                {
                    gTimer.Stop();
                    MessageBox.Show("No More Moves! Score: " + Score.ToString());
                    if (Convert.ToInt32(Properties.Settings.Default.TimedHigh) < Score)
                    {
                        Properties.Settings.Default.TimedHigh = Score.ToString();
                        Properties.Settings.Default.Save();
                    }
                }
                gridTimedBoard.UpdateLayout();
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Time Game Mouse Down", x.Message);
            }
        }

        private void gTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // countdown end if it's 0
                Tick = Tick + 1;
                tbTimeLeft.Text = (60 - Tick).ToString();

                if (Tick == 60)
                {
                    gTimer.Stop();
                    MessageBox.Show("Time is up! Score: " + Score.ToString());
                    if (Convert.ToInt32(Properties.Settings.Default.TimedHigh) < Score)
                    {
                        Properties.Settings.Default.TimedHigh = Score.ToString();
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Timed Game Timer Tick", x.Message);
            }
        }

        private void ReFill()
        {
            try
            {
                // ColMax columns and RowMax rows
                for (int r = 0; r < RowMax; r++)        // Row Loop
                {
                    for (int c = 0; c < ColMax; c++)    // Column Loop
                    {
                        Rectangle rCheck = MainGame.GetRect(gridTimedBoard, r, c);
                        if (rCheck == null)     // There is an empty space here
                        {
                            Rectangle rectLoop = new Rectangle();
                            rectLoop.Fill = MainGame.GetAColor();
                            rectLoop.MouseDown += rectLoop_MouseDown;
                            gridTimedBoard.Children.Add(rectLoop);
                            Grid.SetColumn(rectLoop, c);
                            Grid.SetRow(rectLoop, r);
                        }
                    }
                }
                gridTimedBoard.UpdateLayout();
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Timed Refill", x.Message);
            }
        }

        private void butTimedRestart_Click(object sender, RoutedEventArgs e)
        {
            SetupTimedGame();
        }

        private void butTimedExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
