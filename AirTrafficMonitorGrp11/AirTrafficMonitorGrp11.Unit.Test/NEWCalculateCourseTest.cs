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
        public void SE_CorrectCourseCalculated_135()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 10000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 20000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(135));
        }

        [Test]
        public void NE_CorrectCourseCalculated_45()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 20000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(45));
        }

        [Test]
        public void SW_CorrectCourseCalculated_225()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 10000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 20000;
            container2.Y = 20000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(225));
        }

        [Test]
        public void NW_CorrectCourseCalculated_315()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 20000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 20000;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(315));
        }

        [Test]
        public void N_CorrectCourseCalculated_0()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 20000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(0));
        }

        [Test]
        public void S_CorrectCourseCalculated_180()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 10000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 20000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(180));
        }

        [Test]
        public void E_CorrectCourseCalculated_90()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 10000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(90));
        }

        [Test]
        public void W_CorrectCourseCalculated_270()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 10000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 20000;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(270));
        }

        [Test]
        public void CorrectCourseCalculated_1()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 20000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 9750;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(1));
        }

        [Test]
        public void CorrectCourseCalculated_359()
        {
            List<TrackDataContainer> list1 = new List<TrackDataContainer>();
            List<TrackDataContainer> list2 = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 10000;
            container.Y = 20000;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10250;
            container2.Y = 10000;

            list1.Add(container);
            list2.Add(container2);

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list2));

            _velocity.VelocityCalculated += Raise.EventWith(new ATMEvent(list1));

            Assert.That(_event._tdcList[0].Course, Is.EqualTo(359));
        }
    }
}
    
