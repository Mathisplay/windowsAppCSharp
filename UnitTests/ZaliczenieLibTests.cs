using NUnit.Framework;
using ZaliczenieLib;
using System.Diagnostics;

namespace UnitTests
{
    public class ZaliczenieLibTests
    {
        MeasurementTool m;
        EventLog log;
        [Test]
        public void CheckConstructor()
        {
            Assert.DoesNotThrow(() => new MeasurementTool());
        }

        [OneTimeSetUp]
        public void Setup()
        {
            m = new MeasurementTool();
        }

        [Test]
        public void BytesToKilobytes()
        {
            Assert.AreEqual(m.BytesToKilobytes(1024), 1);
        }
        [Test]
        public void BytesToMegabytes()
        {
            Assert.AreEqual(m.BytesToMegabytes(1048576), 1);
        }
        [Test]
        public void BytesToGigabytes()
        {
            Assert.AreEqual(m.BytesToGigabytes(1073741824), 1);
        }
        [Test]
        public void BytesToKilobytesDoublePrecision()
        {
            Assert.AreNotEqual(m.BytesToKilobytes(1023), 1);
        }
        [Test]
        public void BytesToMegabytesDoublePrecision()
        {
            Assert.AreNotEqual(m.BytesToMegabytes(1048575), 1);
        }
        [Test]
        public void BytesToGigabytesDoublePrecision()
        {
            Assert.AreNotEqual(m.BytesToGigabytes(1073741823), 1);
        }
        [OneTimeTearDown]
        public void Cleanup()
        {

        }

        [SetUp]
        public void Setup2()
        {
            m = new MeasurementTool();
            log = new EventLog();
            log.Log = "MemProjLog";
            log.Source = "Service";
            log.WriteEntry("12345", EventLogEntryType.Information);
            log.WriteEntry("123", EventLogEntryType.Information);
        }

        [Test]
        public void GetValueWhenSomethingInLogs()
        {
            Assert.AreEqual(m.GetMem(), 123);
        }
        [Test]
        public void GetValueWhenNothingInLogs()
        {
            log.Clear();
            Assert.AreEqual(m.GetMem(), -1);
        }
    }
}