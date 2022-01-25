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
using System.Windows.Threading;
using System.ComponentModel;

namespace AppWindow
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer t;
        private MeasurementTool m;
        private long startMem;
        public MainWindow()
        {
            InitializeComponent();
            m = new MeasurementTool();
            t = new DispatcherTimer();
            startMem = m.GetMem();
            t.Interval = TimeSpan.FromSeconds(0.1);
            t.Tick += Refresh;
            t.Start();
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            m.Stop();
            t.Stop();
        }
        private void Refresh(object sender, EventArgs e)
        {
            label.Content = Math.Round(m.BytesToGigabytes(m.GetMem()), 3).ToString() + "GB";
            label4.Content = Math.Round(m.BytesToKilobytes(startMem - m.GetMem()), 3).ToString() + "kB";
        }
    }
}
