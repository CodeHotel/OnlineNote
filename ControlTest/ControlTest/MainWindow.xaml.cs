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
using ControlTest.CustomControls;
//
namespace ControlTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AdTXT[] boxarr = new AdTXT[100];
        public int boxindex = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdTXT newtext = new AdTXT();
            a1.Children.Add(newtext);
            boxarr[boxindex] = newtext;
            boxindex++;
        }


        private void outer_mouse_up(object sender, MouseButtonEventArgs e)
        {
            
            for (int i = 0; i < boxindex; i++)
            {
                boxarr[i].TxtMouseUp(sender, e);
            }
            
        }

        private void outer_mouse_move(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < boxindex; i++)
            {
                boxarr[i].Movement_Regulator(sender, e);
            }
            
        }

        /*
        private void outer_mouse_down(object sender, MouseEventArgs e)
        {
            
            for (int i = 0; i < boxindex; i++)
            {
                boxarr[i].Selected = AdTXT.SelectMode.NON;
                boxarr[i].CtrlsShown(false);
            }
        }
        */


    }

}
