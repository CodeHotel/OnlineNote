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
using Microsoft.Xaml.Behaviors.Core;
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
        private AdTXT selection = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdTXT newtext = new AdTXT();
            a1.Children.Add(newtext);
            boxarr[boxindex] = newtext;
            boxarr[boxindex].init(400 + 10 * boxindex, 400 + 10 * boxindex, 500 + 10 * boxindex, 500 + 10 * boxindex);
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

        
        private void outer_mouse_down(object sender, RoutedEventArgs e)
        {
            int temp = -1;
            for (int i = 0; i < boxindex; i++)
            {
                if (e.Source != boxarr[i])
                {
                    boxarr[i].SelVarChange = AdTXT.SelectMode.NON;
                }
                else
                {
                    temp = i;
                    selection = boxarr[i];
                }
            }
            if (temp != -1)
            {
                for (int f = 0; f < boxindex; f++)
                {
                    if (f != temp)
                    {
                        boxarr[f].SelVarChange = AdTXT.SelectMode.NON;
                    }
                }
                if (boxarr[temp].SelVarChange == AdTXT.SelectMode.MOV)
                {
                    TBin.Focus();
                    Keyboard.Focus(TBin);
                }
            }
            else
            {
                TBin.Focus();
                Keyboard.Focus(TBin);
            }
        }
        private void simplemousedown(object sender, RoutedEventArgs e)
        {
            if (e.Source == selection)
            {
                TBin.Focus();
                Keyboard.Focus(TBin);
            }
        }

        private void KeyManager(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Delete && selection != null && selection.SelVarChange == AdTXT.SelectMode.MOV)
            {
                a1.Children.Remove(selection);
            }
        }


    }

}
