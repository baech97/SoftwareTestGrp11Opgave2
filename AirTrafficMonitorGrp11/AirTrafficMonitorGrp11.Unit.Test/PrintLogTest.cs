using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    class PrintLogTest
    {
        private iSeperationChecker _seperationChecker;
        private PrintLog _uut;

        [SetUp]
        public void SetUp()
        {
            _seperationChecker = NSubstitute.Substitute.For<iSeperationChecker>();
            _uut = new PrintLog(_seperationChecker);
        }

        [Test]
        public void Test_Reception_For_SeperationContainer()
        {
            List<SeperationContainer> scList = new List<SeperationContainer>();

            SeperationContainer seperationContainer = new SeperationContainer();
            seperationContainer.TrackTag1 = "IBD214";
            seperationContainer.TrackTag2 = "BDD153";
            seperationContainer.TimeStamp = DateTime.Now;

            scList.Add(seperationContainer);

            _seperationChecker.SeperationChecked += Raise.EventWith(this, new SeperationEvent(scList));

            Assert.That(_uut.DataRecivedList, Is.EqualTo(scList));



        }
       
    }
}
