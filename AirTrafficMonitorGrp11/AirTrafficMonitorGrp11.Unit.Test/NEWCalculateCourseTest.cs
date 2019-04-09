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
    class NEWCalculateCourseTest
    {
        private CalculateCourse _uut;
        private ATMEvent _event;
        private iCalculateVelocity _velocity;

        [SetUp]
        public void Setup()
        {
            _event = null;
            _velocity = NSubstitute.Substitute.For<iCalculateVelocity>();
            _uut = new CalculateCourse(_velocity);

            _uut.CourseCalculated +=
                (o, args) => { _event = args; };
        }

        [Test]
        public void EventFired()
        {
            List<TrackDataContainer> list = new List<TrackDataContainer>();

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

            list.Add(container);
            list.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list));

            Assert.That(_event, Is.Not.Null);
        }

        [Test]
        public void CorrectCourseCalculated()
        {
            List<TrackDataContainer> lastflightlist = new List<TrackDataContainer>();
            List<TrackDataContainer> currentflightlist = new List<TrackDataContainer>();

            

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 10000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;
            container.Velocity = 280;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 20000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;
            container2.Velocity = 280;

            currentflightlist.Add(container);
            lastflightlist.Add(container2);

            _uut.LastFlightData = lastflightlist;

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(currentflightlist));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(135));
        }
    }
}
    
