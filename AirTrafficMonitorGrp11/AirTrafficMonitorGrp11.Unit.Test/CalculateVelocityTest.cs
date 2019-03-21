using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    public class CalculateVelocityTest
    {

        private iTrafficDataSorter _dataSorter;
        private CalculateVelocity _uut;

        [SetUp]
        public void SetUp()
        {
            _dataSorter = NSubstitute.Substitute.For<iTrafficDataSorter>();
            _uut = new CalculateVelocity(_dataSorter);
        }

        [TestCase(20000, 30000)]
        public void TestReception(int s1, int s2)
        {
            List<TrackDataContainer> CurrentFlight = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlight = new List<TrackDataContainer>();

            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ATR423";

            container1.X = s1;
            container2.X = s2;

            container1.Y = s1;
            container2.Y = s2;

            container1.Altitude = 10000;
            container2.Altitude = 10000;

            // Ændre datetime tidspunkterne
            container1.Timestamp = DateTime.Now;
            container2.Timestamp = DateTime.Today;

            //Beregn
            CurrentFlight.Add(container1);
            LastFlight.Add(container2);
            _uut.Calculate(CurrentFlight);



            Assert.That(_uut.Calculate());

            _dataSorter.DataSorted += Raise.EventWith(this, new ATMEvent(dataList));

            Assert.That(_uut.VelocityCalculated, Is.EqualTo(dataList));
        }
    }
}
