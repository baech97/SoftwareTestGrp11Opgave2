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
        private CalculateVelocity _uut;
        private iCalculateCourse _calculateCourse;
        private iTrafficDataSorter _trafficDataSorter;

        [SetUp]
        public void SetUp()
        {
            _calculateCourse = NSubstitute.Substitute.For<iCalculateCourse>();
            _uut = new CalculateVelocity(_trafficDataSorter);
        }


        [Test]
        public void Course_is_90()
        {
            List<string> testData = new List<string>();
            
        }

    }
}
