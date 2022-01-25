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
using ZaliczenieLib;
using System.Threading;
using System.ComponentModel;

namespace AppWindow
{
    public partial class MainWindow : Window
    {
        private Thread t;
        private MeasurementTool m;
        public MainWindow()
        {
            InitializeComponent();
            m = new MeasurementTool();
            t = new Thread(new ThreadStart(Refresh));
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            m.Stop();
            t.Join();
        }
        private void Refresh()
        {
            while (true)
            {
                label.Content = m.GetMem().ToString();
            }
        }
    }
}
