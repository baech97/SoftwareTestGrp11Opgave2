using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    class CalculateCourseTest
    {
        private iCalculateVelocity _receiver;
        private CalculateCourse _uut;

        [SetUp]
        public void SetUp()
        {
            _receiver = NSubstitute.Substitute.For<iCalculateVelocity>();
            _uut = new CalculateCourse(_receiver);
        }

        [Test]
        public void NE_Course_is_45()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 20000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 10000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);
            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(45));
        }

        [Test]
        public void SE_Course_is_135()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();
            TrackDataContainer container = new TrackDataContainer();

            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 10000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 20000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(135));
        }

        [Test]
        public void SW_Course_is_225()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 10000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 20000;
            container2.Y = 20000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(225));
        }

        [Test]
        public void NW_Course_is_315()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 20000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 20000;
            container2.Y = 10000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(315));
        }

        [Test]
        public void North_Course_is_0()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 20000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 10000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(0));
        }

        [Test]
        public void South_Course_is_180()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 10000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 20000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(180));
        }

        [Test]
        public void East_Course_is_90()
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 10000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 10000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(90));
        }

        [Test]
        public void West_Course_is_270() 
        {
            List<TrackDataContainer> CurrentFlights = new List<TrackDataContainer>();
            List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 10000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 20000;
            container2.Y = 10000;

            CurrentFlights.Add(container);
            LastFlightData.Add(container2);

            _uut.LastFlightData = LastFlightData;
            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));
            Assert.That(_uut.Course, Is.EqualTo(270));
        }

    }
}
