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
        public void Course_is_45()
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
            _uut.Calculate(CurrentFlights);


            _receiver.VelocityCalculated += Raise.EventWith(this, new ATMEvent(CurrentFlights));

            Assert.That(_uut.Course, Is.EqualTo(45));
        }


        //private CalculateCourse _uut;
        //private iCalculateCourse _calculateCourse;
        //private iCalculateVelocity _velocity;
        //private List<TrackDataContainer> listReceived;
        //private List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();



        //private int LastPosition_X;
        //private int LastPosition_Y;
        //private int CurrentPosition_X;
        //private int CurrentPosition_Y;


        //[SetUp]
        //public void SetUp()
        //{
        //    _calculateCourse = NSubstitute.Substitute.For<iCalculateCourse>();

        //    _uut = new CalculateCourse(_velocity);
        //    _uut.CourseCalculated += (o, args) => { listReceived = args; };
        //}


        //[Test]
        //public void Course_is_120()
        //{
        //    _uut.;

        //}

    }
}
