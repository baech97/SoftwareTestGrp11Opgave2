using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture()]
    class ConsolePrintTest
    {
        private iCalculateCourse _Course;
        private iSeperationChecker _seperationChecker;
        private PrintConsole _uut;

        [SetUp]
        public void SetUp()
        {
            _Course = NSubstitute.Substitute.For<iCalculateCourse>();
            _seperationChecker = NSubstitute.Substitute.For<iSeperationChecker>();
            _uut = new PrintConsole(_Course,_seperationChecker);
        }

        [Test]
        public void Tets_Reception_For_TrackDataContainer()
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();

            TrackDataContainer trackDataContainer = new TrackDataContainer();
            trackDataContainer.Tag = "ATR213";
            trackDataContainer.X = 20000;
            trackDataContainer.Y = 30000;
            trackDataContainer.Altitude = 10000;
            trackDataContainer.Course = 123;
            trackDataContainer.Velocity = 700;
            trackDataContainer.Timestamp = DateTime.Now;

            tdcList.Add(trackDataContainer);

            _Course.CourseCalculated += Raise.EventWith(this, new ATMEvent(tdcList));

            Assert.That(_uut.TrackDataRecivedList, Is.EqualTo(tdcList));
        }

        [Test]
        public void Tets_Reception_For_SeperationContainer()
        {
            List<SeperationContainer> scList = new List<SeperationContainer>();

            SeperationContainer seperationContainer = new SeperationContainer();
            seperationContainer.TrackTag1 = "IBD214";
            seperationContainer.TrackTag2 = "BDD153";
            seperationContainer.TimeStamp = DateTime.Now;
        
            scList.Add(seperationContainer);

            _seperationChecker.SeperationChecked += Raise.EventWith(this, new SeperationEvent(scList));

            Assert.That(_uut.SeperationDataRecivedList, Is.EqualTo(scList));
        }

    }
    
}
