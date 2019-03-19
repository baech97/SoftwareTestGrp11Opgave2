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

        [SetUp]
        public void SetUp()
        {
            _calculateCourse = NSubstitute.Substitute.For<iCalculateCourse>();
            _uut = new CalculateCourse(_trafficDataSorter);


        }


        [Test]
        public void Course_is_90()
        {
            TrackDataContainer tdc = new TrackDataContainer();
            tdc.X = 2000;
            tdc.Y = 4000;
            
            Assert.That(_uut.OnVelocityCalculated(this,tdc) Is.EqualTo(45));
            
        }

    }
}
