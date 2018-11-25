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
using System.Windows.Shapes;

namespace BoxGames
{
    /// <summary>
    /// Interaction logic for Vertical.xaml
    /// </summary>
    public partial class Vertical : Window
    {
        System.Windows.Threading.DispatcherTimer vertTimer = new System.Windows.Threading.DispatcherTimer();

        // set up single Random for game use
        public class RandomHolder
        {
            private static Random _instance;
            public static Random Instance
            {
                get { return _instance ?? (_instance = new Random()); }
            }
        }

        int RowMax = 24;
        int ColMax = 12;
        int Score = 0;
        int Tick = 0;

        public Vertical()
        {
            InitializeComponent();

            SetupVertGame();
        }

        private void SetupVertGame()
        {
            try
            {
                // Reset in case a successive run
                vertTimer.Stop();
                Tick = 0;
                Score = 0;
                gridVertBoard.Children.Clear();

                // Set Current Game score to 0, fetch high score
                tbVertYourScore.Text = "0";
                tbVertHighScore.Text = Properties.Settings.Default.VerticalHigh;

                // Loop through grid adding rectangles in bottom row
                for (int c = 0; c < ColMax; c++)    // Column Loop
                {
                    Rectangle rectLoop = new Rectangle();
                    rectLoop.Fill = MainGame.GetAColor();
                    rectLoop.MouseDown += rectLoop_MouseDown;
                    gridVertBoard.Children.Add(rectLoop);
                    Grid.SetColumn(rectLoop, c);
                    Grid.SetRow(rectLoop, RowMax - 1);
                }


                // Setup and Start Timer
                vertTimer.Tick += new EventHandler(vertTimer_Tick);
                vertTimer.Interval = new TimeSpan(0, 0, 2);
                vertTimer.Start();
            }
            catch (Exception x)
            {
                MainWindow.errorReporting("Vert Game Setup", x.Message);
            }
        }

        private void rectLoop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var MainG = new MainGame();
                Rectangle rClick = sender as Rectangle;                 // The Clicked Rectangle

                int mCount = MainG.RectLinks(rClick, gridVertBoard);    // Count matches - fill match / select table
                if (mCount >= 1)                                        // There is at least 2 - remove them and add points
                {
                    foreach (Rectangle rect in MainG.rEcts)             // remove the detected connecting matches
                    {
                        gridVertBoard.Children.Remove(rect);
                    }
                    MainG.CompactGrid(gridVertBoard);                   // run compact routine to lower blocks
                    Score = Score + (mCount * (mCount - 1));            // the more boxes at one time, the higher the score
                    tbVertYourScore.Text = Score.ToString();            // update display
                }

                gridVertBoard.UpdateLayout();
            }
            catch (Exception x)
            {
                MainWindow.errorReporting("Vert Game Mouse Down", x.Message);
            }
        }

        private void vertTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Tick = Tick + 1;
                // Get progressively faster...
                vertTimer.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(2000 - (Tick * 10)));

                // Get any child that is rectangle and check to see if there are any
                // in the top row
                List<Rectangle> LoopRect = gridVertBoard.Children.OfType<Rectangle>().ToList();
                LoopRect = LoopRect.OrderByDescending(x => Grid.GetRow(x)).ToList();
                foreach (Rectangle forRect in LoopRect)
                {
                    if (Grid.GetRow(forRect) == 0)
                    {
                        MessageBox.Show("You hit the top! Score: " + Score.ToString());
                        vertTimer.Stop();
                        if (Convert.ToInt32(Properties.Settings.Default.VerticalHigh) < Score)
                        {
                            Properties.Settings.Default.VerticalHigh = Score.ToString();
                            Properties.Settings.Default.Save();
                        }
                        break;
                    }
                    else
                    {
                        // Move everything up one row
                        Grid.SetRow(forRect, Grid.GetRow(forRect) - 1);
                    }
                }

                // Loop through grid adding rectangles in bottom row to start
                for (int c = 0; c < ColMax; c++)    // Column Loop
                {
                    Rectangle rectLoop = new Rectangle();
                    rectLoop.Fill = MainGame.GetAColor();
                    rectLoop.MouseDown += rectLoop_MouseDown;
                    gridVertBoard.Children.Add(rectLoop);
                    Grid.SetColumn(rectLoop, c);
                    Grid.SetRow(rectLoop, RowMax - 1);
                }

                gridVertBoard.UpdateLayout();
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("Vert Game Timer Tick", x.Message);
            }
        }

        private void butVertRestart_Click(object sender, RoutedEventArgs e)
        {
            SetupVertGame();
        }

        private void butVertExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
