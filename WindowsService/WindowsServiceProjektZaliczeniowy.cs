using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Thread t;
        private long memNow;
        EventLog log;
        DriveInfo drive;
        public Service1()
        {
            memNow = 0;
            log = new EventLog("MemProjLog");
            log.Source = "Service";
            InitializeComponent();
        }

        void CheckMem()
        {
            drive = new DriveInfo("C");
            if (drive.IsReady)
            {
                memNow = drive.AvailableFreeSpace;
            }
            else
            {
                memNow = -1;
            }
        }

        protected override void OnStart(string[] args)
        {
            t = new Thread(new ThreadStart(CheckMem));
            t.Start();
        }

        protected override void OnStop()
        {
            t.Join();
            log.WriteEntry(memNow.ToString(), EventLogEntryType.Information);
        }
    }
}
