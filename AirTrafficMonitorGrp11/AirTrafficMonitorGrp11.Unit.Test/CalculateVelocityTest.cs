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
        public void Velocity_is_1000()
        {
            List<TrackDataContainer> CurrentFlight = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlight = new List<TrackDataContainer>();

            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ATR423";

            container1.X = 2000;
            container2.X = 2000;

            container1.Y = 2000;
            container2.Y = 3000;

            container1.Timestamp = new DateTime(2000,10,10,10,10,1);
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            LastFlight.Add(container1);
            CurrentFlight.Add(container2);

            _uut.LastFlightData = LastFlight;
            _dataSorter.DataSorted += Raise.EventWith(this, new ATMEvent(CurrentFlight));
            Assert.That(_uut.Velocity, Is.EqualTo(1000));
        }

        [Test]
        public void Velocity_is_5000()
        {
            List<TrackDataContainer> CurrentFlight = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlight = new List<TrackDataContainer>();

            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ATR423";

            container1.X = 1000;
            container2.X = 5000;

            container1.Y = 1000;
            container2.Y = 4000;

            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            LastFlight.Add(container1);
            CurrentFlight.Add(container2);

            _uut.LastFlightData = LastFlight;
            _dataSorter.DataSorted += Raise.EventWith(this, new ATMEvent(CurrentFlight));
            Assert.That(_uut.Velocity, Is.EqualTo(5000));
        }

        [Test]
        public void Velocity_reverse_direction_is_5000()
        {
            List<TrackDataContainer> CurrentFlight = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlight = new List<TrackDataContainer>();

            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ATR423";

            container1.X = 4000;
            container2.X = 1000;

            container1.Y = 5000;
            container2.Y = 1000;

            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            LastFlight.Add(container1);
            CurrentFlight.Add(container2);

            _uut.LastFlightData = LastFlight;
            _dataSorter.DataSorted += Raise.EventWith(this, new ATMEvent(CurrentFlight));
            Assert.That(_uut.Velocity, Is.EqualTo(5000));
        }

        [Test]
        public void Velocity_is_0()
        {
            List<TrackDataContainer> CurrentFlight = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlight = new List<TrackDataContainer>();

            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ATR423";

            container1.X = 1000;
            container2.X = 1000;

            container1.Y = 1000;
            container2.Y = 1000;

            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            LastFlight.Add(container1);
            CurrentFlight.Add(container2);

            _uut.LastFlightData = LastFlight;
            _dataSorter.DataSorted += Raise.EventWith(this, new ATMEvent(CurrentFlight));
            Assert.That(_uut.Velocity, Is.EqualTo(0));
        }
    }
}
