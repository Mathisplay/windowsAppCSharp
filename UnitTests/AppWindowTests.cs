using NUnit.Framework;
using AppWindow;
using System.Threading;

namespace UnitTests
{
    public class AppWindowTests
    {
        [Test]
        [Apartment(ApartmentState.STA)]
        public void CheckConstructor()
        {
            Assert.DoesNotThrow(() => new MainWindow());
        }
    }
}