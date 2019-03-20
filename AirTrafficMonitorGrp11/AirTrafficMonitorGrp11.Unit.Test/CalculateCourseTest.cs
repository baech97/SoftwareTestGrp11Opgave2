using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    class CalculateCourseTest
    {
        private CalculateCourse _uut;
        private iCalculateCourse _calculateCourse;
        private iCalculateVelocity _velocity;
        private List<TrackDataContainer> listReceived;

        [SetUp]
        public void SetUp()
        {
            _calculateCourse = NSubstitute.Substitute.For<iCalculateCourse>();

            _uut = new CalculateCourse(_velocity);
            _uut.CourseCalculated += (o, args) => { listReceived = args; };
        }


        [Test]
        public void Course_is_90()
        {
            List<TrackDataContainer> tdcList = new List <TrackDataContainer>();
            TrackDataContainer tdc = new TrackDataContainer();
            tdc.Y = 4000;
            tdc.X = 2000;
            
            
            

            tdcList.Add(tdc);
            
            Assert.That(_uut.OnVelocityCalculated(_velocity, tdcList) Is.EqualTo(45));
            
        }

    }
}
