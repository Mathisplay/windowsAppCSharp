using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceProcess;

namespace ZaliczenieLib
{
    public class MeasurementTool
    {
        private long mem;
        public MeasurementTool()
        {
            mem = 0;
        }
        public long GetMem()
        {
            ServiceController service = new ServiceController("ProjektZaliczeniowy");
            if (service.Status.Equals(ServiceControllerStatus.Stopped) || service.Status.Equals(ServiceControllerStatus.StopPending))
            {
                service.Start();
            }
            EventLog log = new EventLog();
            log.Log = "MemProjLog";
            EventLogEntryCollection e;
            if(EventLog.Exists("MemProjLog"))
            {
                e = log.Entries;
                if(e.Count != 0)
                {
                    mem = Convert.ToInt64(e[e.Count - 1].Message);
                    log.Source = "Service";
                    log.Clear();
                }
            }
            return mem;
        }
    }
}
