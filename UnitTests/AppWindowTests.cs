using NUnit.Framework;
using AppWindow;
using System.Threading;

namespace UnitTests
{
    public class AppWindowTests
    {
        MainWindow w;
        [Test]
        [Apartment(ApartmentState.STA)]
        public void CheckConstructor()
        {
            Assert.DoesNotThrow(() => new MainWindow());
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void LoadSettings()
        {
            w = new MainWindow();
            Assert.DoesNotThrow(() => w.LoadMessages());
        }
    }
}