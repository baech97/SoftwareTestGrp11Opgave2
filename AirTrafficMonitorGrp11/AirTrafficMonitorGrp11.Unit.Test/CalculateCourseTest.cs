//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace AirTrafficMonitorGrp11.Unit.Test
//{
//    [TestFixture]
//    class CalculateCourseTest
//    {
//        private CalculateCourse _uut;
//        private iCalculateCourse _calculateCourse;
//        private iCalculateVelocity _velocity;
//        private List<TrackDataContainer> listReceived;
//        private List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();



//        private int LastPosition_X;
//        private int LastPosition_Y;
//        private int CurrentPosition_X;
//        private int CurrentPosition_Y;


//        [SetUp]
//        public void SetUp()
//        {
//            _calculateCourse = NSubstitute.Substitute.For<iCalculateCourse>();

//            _uut = new CalculateCourse(_velocity);
//            _uut.CourseCalculated += (o, args) => { listReceived = args; };
//        }


//        [Test]
//        public void Course_is_120()
//        {
//           _uut.;
            
//        }

//        [Test]
//        public void Course_is_90()
//        {

//            LastPosition_X = 1000;
//            LastPosition_Y = 1000;
//            CurrentPosition_X = 2000;
//            CurrentPosition_Y = 2000;

//            Assert.That(_uut.OnVelocityCalculated() Is.EqualTo(45));

//        }

//    }
//}
