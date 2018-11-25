using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace BoxGames
{
    class MainGame
    {
        public List<Rectangle> rEcts = new List<Rectangle>();
        public List<Rectangle> rectsToCheck = new List<Rectangle>();
        public List<Rectangle> rectsChecked = new List<Rectangle>();

        public static LinearGradientBrush gradRed = new LinearGradientBrush(Colors.Red, Colors.LightPink, new Point(0,0), new Point(1,1));
        public static LinearGradientBrush gradYellow = new LinearGradientBrush(Colors.Orange, Colors.LightGoldenrodYellow, new Point(0,0), new Point(1,1));
        public static LinearGradientBrush gradBlue = new LinearGradientBrush(Colors.Blue, Colors.LightBlue, new Point(0,0), new Point(1,1));
        public static LinearGradientBrush gradGreen = new LinearGradientBrush(Colors.Green, Colors.LightGreen, new Point(0,0), new Point(1,1));

        public static LinearGradientBrush GetAColor()
        {
            // Get a color routine - grabs a random number (only 4 possibilities currently)
            // and sets up the reply gradient based on the selected number with the switch

            int pick = Clear.RandomHolder.Instance.Next(0, 4);

            switch (pick.ToString())
            {
                case "0":
                    return gradRed;
                case "1":
                    return gradYellow;
                case "2":
                    return gradBlue;
                case "3":
                    return gradGreen;
                default:
                    return gradRed;
            }
        }

        public void CheckRect(Rectangle cRect, Grid cGrid)
        {
            try
            {
                int rCol = Grid.GetColumn(cRect);
                int rRow = Grid.GetRow(cRect);

                if (!rEcts.Contains(cRect))
                {
                    rEcts.Add(cRect);
                }

                // Check -1 Row / +1 Row / -1 Column / +1 Column
                // if it's a match and hasn't already been checked, add it to the To Check list
                if (rRow > 0)   // Not the top row
                {
                    Rectangle rUp = GetRect(cGrid, rRow - 1, rCol);
                    if (rUp != null && rUp.Fill == cRect.Fill && !rectsChecked.Contains(rUp)) { rectsToCheck.Add(rUp); }
                }

                if (rRow < cGrid.RowDefinitions.Count - 1)   // Not the bottom row
                {
                    Rectangle rDown = GetRect(cGrid, rRow + 1, rCol);
                    if (rDown != null && rDown.Fill == cRect.Fill && !rectsChecked.Contains(rDown)) { rectsToCheck.Add(rDown); }
                }

                if (rCol > 0)   // Not the left most column
                {
                    Rectangle rLeft = GetRect(cGrid, rRow, rCol - 1);
                    if (rLeft != null && rLeft.Fill == cRect.Fill && !rectsChecked.Contains(rLeft)) { rectsToCheck.Add(rLeft); }
                }

                if (rCol < cGrid.ColumnDefinitions.Count - 1)  // Not the right most column
                {
                    Rectangle rRight = GetRect(cGrid, rRow, rCol + 1);
                    if (rRight != null && rRight.Fill == cRect.Fill && !rectsChecked.Contains(rRight)) { rectsToCheck.Add(rRight); }
                }

                // Add to Checked list
                rectsChecked.Add(cRect);
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("MainGame CheckRect", x.Message);
            }
        }

        public static Rectangle GetRect(Grid grid, int row, int column)
        {
            try
            {
                // Given a Grid, Row and Column - get the rectangle at that position and return it
                foreach (Rectangle childRect in grid.Children)
                {
                    if (Grid.GetRow(childRect) == row && Grid.GetColumn(childRect) == column)
                    {
                        return childRect;
                    }
                }
                return null;
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("MainGame GetRect", x.Message);
                return null;
            }
        }

        public int RectLinks(Rectangle cRect, Grid cGrid)
        {
            try
            {
                // This takes a rectangle as input and checks to see if
                // it has any matches next to it returning the count

                rEcts.Clear();                                  // rEcts holds the confirmed matches
                rectsToCheck.Clear();                           // rectsToCheck holds discovered matches to check around them
                rectsChecked.Clear();                           // rectsChecked holds already checked items this round

                rectsToCheck.Add(cRect);                        // Adds to the To Check list to seed the process
                int checker = rectsToCheck.Count;               // Uses the To Check list as the basis of the loop

                while (checker > 0)
                {
                    Rectangle loopRect = rectsToCheck.First();  // Get the first record
                    CheckRect(loopRect, cGrid);                 // Check it
                    rectsToCheck.Remove(loopRect);              // Remove that one from the list
                    checker = rectsToCheck.Count;               // Update the counter
                }

                return rEcts.Count() - 1;                       // Return Match Count minus one for the source rectangle
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("MainGame RectLinks", x.Message);
                return 0;
            }
        }

        public void CompactGrid(Grid cGrid)
        {
            try
            {
                // Need to do this for all rows
                for (int i = 0; i < cGrid.RowDefinitions.Count() - 1; i++)
                {
                    // Get any child that is rectangle and check to see if there is a rectangle
                    // underneath it. If there is not, move this rectangle down one row.
                    List<Rectangle> LoopRect = cGrid.Children.OfType<Rectangle>().ToList();
                    LoopRect = LoopRect.OrderByDescending(x => Grid.GetRow(x)).ToList();

                    foreach (Rectangle forRect in LoopRect)
                    {
                        int rCol = Grid.GetColumn(forRect);
                        int rRow = Grid.GetRow(forRect);

                        if (rRow < cGrid.RowDefinitions.Count() - 1)        // This is RowMax-1 to start one row up from the bottom
                        {
                            Rectangle rCheck = GetRect(cGrid, rRow + 1, rCol);
                            if (rCheck == null)     // There is an empty space beneath this block
                            {
                                Grid.SetRow(forRect, rRow + 1);
                            }
                        }
                    }
                }

                // ColSlide
                // Count bottom row empty spaces
                int emptyCount = 0;
                for (int i = 0; i < cGrid.ColumnDefinitions.Count() - 1; i++)
                {
                    Rectangle rCheck = GetRect(cGrid, cGrid.RowDefinitions.Count() - 1, i);
                    if (rCheck == null)     // There is an empty space
                    {
                        emptyCount = emptyCount + 1;
                    }
                }

                // do this for each empty bottom space, in case they are contiguous
                for (int j = 0; j <= emptyCount; j++)
                {
                    // Compact Empty Columns sliding left
                    for (int i = 0; i < cGrid.ColumnDefinitions.Count(); i++)
                    {
                        // check bottom slot of column, if it's empty, slide everything one column left
                        List<Rectangle> LoopRect = cGrid.Children.OfType<Rectangle>().ToList();
                        int rCol = i;
                        int rRow = cGrid.RowDefinitions.Count() - 1;
                        Rectangle rCheck = GetRect(cGrid, rRow, rCol);

                        if (rCheck == null)
                        {
                            foreach (Rectangle forRect in LoopRect)
                            {
                                if (Grid.GetColumn(forRect) > rCol)
                                {
                                    Grid.SetColumn(forRect, Grid.GetColumn(forRect) - 1);
                                }
                            }
                        }
                    }
                }
                cGrid.UpdateLayout();
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("MainGame CompactGrid", x.Message);
            }
        }

        public int AnyMovesLeft(Grid cGrid)
        {
            try
            {
                int MovesLeft = 0;

                // Get any child that is rectangle and check to see if there are any
                // moves available for that block
                List<Rectangle> LoopRect = cGrid.Children.OfType<Rectangle>().ToList();
                LoopRect = LoopRect.OrderByDescending(x => Grid.GetRow(x)).ToList();

                foreach (Rectangle forRect in LoopRect)
                {
                    MovesLeft = MovesLeft + RectLinks(forRect, cGrid);
                }
                return MovesLeft;
            }
            catch(Exception x)
            {
                MainWindow.errorReporting("MainGame AnyMovesLeft", x.Message);
                return 0;
            }
        }


    }
}
