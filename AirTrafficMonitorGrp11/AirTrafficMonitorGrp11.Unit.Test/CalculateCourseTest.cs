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
        private ICalculateCourse _calculateCourse;

        [SetUp]
        public void SetUp()
        {
            _calculateCourse = NSubstitute.Substitute.For<ICalculateCourse>()
        }


        [Test]
        public void Course_is_90()
        {

        }

    }
}
