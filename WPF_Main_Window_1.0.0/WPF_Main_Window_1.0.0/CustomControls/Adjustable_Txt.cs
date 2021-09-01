using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Main_Window_1._0._0.CustomControls
{
    public class Adjustable_Txt:Control
    {
        static Adjustable_Txt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Adjustable_Txt), new FrameworkPropertyMetadata(typeof(Adjustable_Txt)));

        }
    }
}
