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

namespace BoxGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void butStartClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clear winClear = new Clear();
                winClear.Show();
            }
            catch (Exception x)
            {
                errorReporting("Start Clear Game Routine", x.Message);
            }
        }

        private void butStartTimed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Timed winTimed = new Timed();
                winTimed.Show();
            }
            catch (Exception x)
            {
                errorReporting("Start Timed Game Routine", x.Message);
            }
        }

        private void butStartVert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vertical winVert = new Vertical();
                winVert.Show();
            }
            catch (Exception x)
            {
                errorReporting("Start Vertical Game Routine", x.Message);
            }
        }

        public static void errorReporting(string txtRoutine, string txtMessage)
        {
            // central error reporting - currently just to screen
            MessageBox.Show("Error in " + txtRoutine + " : " + txtMessage);
        }
    }
}
