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

        [Test]
        public void Velocity_is_300()
        {
            List<TrackDataContainer> CurrentFlight = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlight = new List<TrackDataContainer>();

            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ATR423";

            container1.X = 20000;
            container2.X = 20000;

            container1.Y = 20000;
            container2.Y = 30000;

            container1.Timestamp = new DateTime(2000,10,10,10,10,1);
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            //Beregn
            LastFlight.Add(container1);
            CurrentFlight.Add(container2);

            _uut.LastFlightData = LastFlight;

            _dataSorter.DataSorted += Raise.EventWith(this, new ATMEvent(CurrentFlight));

            Assert.That(_uut.Velocity, Is.EqualTo(10000));
        }

        [Test]
        public void Test_get_velocity()
        {
            _uut.Velocity = 100;
            Assert.AreEqual(_uut.Velocity,100);
        }
    }
}
