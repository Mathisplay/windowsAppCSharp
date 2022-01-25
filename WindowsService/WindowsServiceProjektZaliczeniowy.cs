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
        private Timer t;
        private long memNow;
        private EventLog log;
        private DriveInfo drive;
        private AutoResetEvent autoEvent;
        public Service1()
        {
            memNow = -1;
            log = new EventLog("MemProjLog");
            log.Source = "Service";
            autoEvent = new AutoResetEvent(true);
            InitializeComponent();
        }

        void CheckMem(Object stateInfo)
        {
            drive = new DriveInfo("C");
            if (drive.IsReady)
            {
                memNow = drive.AvailableFreeSpace;
                log.WriteEntry(memNow.ToString(), EventLogEntryType.Information);
            }
        }

        protected override void OnStart(string[] args)
        {
            t = new Timer(CheckMem, autoEvent, 0, 5000);
        }

        protected override void OnStop()
        {
            t.Dispose();
        }
    }
}
