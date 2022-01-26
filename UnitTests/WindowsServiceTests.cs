using NUnit.Framework;
using WindowsService;
using System;
using System.Threading;

namespace UnitTests
{
    public class WindowsServiceTests
    {
        [Test]
        public void CheckConstructor()
        {
            Assert.DoesNotThrow(() => new Service1());
        }
        Service1 s;
        [SetUp]
        public void Setup()
        {
            s = new Service1();
        }

        [Test]
        public void CheckMem()
        {
            s.CheckMem(new AutoResetEvent(false));
        }
    }
}