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
            mem = -1;
        }
        public void Start()
        {
            ServiceController service = new ServiceController("ProjektZaliczeniowy");
            if (service.Status.Equals(ServiceControllerStatus.Stopped) || service.Status.Equals(ServiceControllerStatus.StopPending))
            {
                service.Start();
            }
        }
        public long GetMem()
        {
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
        public void Stop()
        {
            ServiceController service = new ServiceController("ProjektZaliczeniowy");
            if (service.Status.Equals(ServiceControllerStatus.Running))
            {
                service.Stop();
            }
        }
        public double BytesToKilobytes(double memory)
        {
            return memory / 1024.0;
        }
        public double BytesToMegabytes(double memory)
        {
            return BytesToKilobytes(memory) / 1024.0;
        }
        public double BytesToGigabytes(double memory)
        {
            return BytesToMegabytes(memory) / 1024.0;
        }
    }
}
