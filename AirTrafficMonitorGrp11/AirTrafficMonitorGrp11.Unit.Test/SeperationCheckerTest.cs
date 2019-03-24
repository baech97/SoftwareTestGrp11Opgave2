using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    public class SeperationCheckerTest
    {
        private iCalculateCourse _calculateCourse; 
        private SeperationChecker _uut; 

        [SetUp]
        public void SetUp()
        {
            _calculateCourse = NSubstitute.Substitute.For<iCalculateCourse>();
            _uut = new SeperationChecker(_calculateCourse);
        }

        [Test]
        public void TestReception()
        {
            List<TrackDataContainer> dataList = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 30000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            dataList.Add(container);

            _calculateCourse.CourseCalculated += Raise.EventWith(this, new ATMEvent(dataList));

            Assert.That(_uut.DataRecivedList, Is.EqualTo(dataList));
        }

        [Test]
        public void Seperation_Occurence_Detected()  
        {
            List<TrackDataContainer> List = new List<TrackDataContainer>();
            List<SeperationContainer> SeperationList = new List<SeperationContainer>();


            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ILP123"; 

            container1.X = 5000;
            container1.Y = 1000;
            container1.Altitude = 5000;
            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);

            container2.X = 5050;
            container2.Y = 1050;
            container2.Altitude = 5000;
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            List.Add(container1);
            List.Add(container2);
            
            _calculateCourse.CourseCalculated += Raise.EventWith(this, new ATMEvent(List));
            SeperationList = _uut.CheckSeperation(List);

            Assert.That(SeperationList.Count, Is.EqualTo(1));
        }

        [Test]
        public void Seperation_Occurence_NotDetected()
        {
            List<TrackDataContainer> List = new List<TrackDataContainer>();
            List<SeperationContainer> SeperationList = new List<SeperationContainer>();


            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ILP123";

            container1.X = 5000;
            container1.Y = 1000;
            container1.Altitude = 5000;
            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);

            container2.X = 70000;
            container2.Y = 70000;
            container2.Altitude = 5000;
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            List.Add(container1);
            List.Add(container2);

            _calculateCourse.CourseCalculated += Raise.EventWith(this, new ATMEvent(List));
            SeperationList = _uut.CheckSeperation(List);

            Assert.That(SeperationList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Several_Seperation_Occurence_Detected()
        {
            List<TrackDataContainer> List = new List<TrackDataContainer>();
            List<SeperationContainer> SeperationList = new List<SeperationContainer>();


            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();
            TrackDataContainer container3 = new TrackDataContainer();
            TrackDataContainer container4 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ILP123";
            container3.Tag = "SUT389";
            container4.Tag = "DEN123";

            container1.X = 5000;
            container1.Y = 1000;
            container1.Altitude = 5000;
            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);

            container2.X = 5050;
            container2.Y = 1050;
            container2.Altitude = 5000;
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            container3.X = 70000;
            container3.Y = 70000;
            container3.Altitude = 5000;
            container3.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            container4.X = 70050;
            container4.Y = 70050;
            container4.Altitude = 5000;
            container4.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            List.Add(container1);
            List.Add(container2);
            List.Add(container3);
            List.Add(container4);

            _calculateCourse.CourseCalculated += Raise.EventWith(this, new ATMEvent(List));
            SeperationList = _uut.CheckSeperation(List);

            Assert.That(SeperationList.Count, Is.EqualTo(2));
        }

        [Test]
        public void CloseDistance_FarAltitude_Occurence_NotDetected() 
        {
            List<TrackDataContainer> List = new List<TrackDataContainer>();
            List<SeperationContainer> SeperationList = new List<SeperationContainer>();


            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ILP123";

            container1.X = 5000;
            container1.Y = 1000;
            container1.Altitude = 5000;
            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);

            container2.X = 5050;
            container2.Y = 1050;
            container2.Altitude = 17000;
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            List.Add(container1);
            List.Add(container2);

            _calculateCourse.CourseCalculated += Raise.EventWith(this, new ATMEvent(List));
            SeperationList = _uut.CheckSeperation(List);

            Assert.That(SeperationList.Count, Is.EqualTo(0));
        }

        [Test]
        public void FarDistance_CloseAltitude_Occurence_NotDetected() 
        {
            List<TrackDataContainer> List = new List<TrackDataContainer>();
            List<SeperationContainer> SeperationList = new List<SeperationContainer>();


            TrackDataContainer container1 = new TrackDataContainer();
            TrackDataContainer container2 = new TrackDataContainer();

            container1.Tag = "ATR423";
            container2.Tag = "ILP123";

            container1.X = 5000;
            container1.Y = 1000;
            container1.Altitude = 5000;
            container1.Timestamp = new DateTime(2000, 10, 10, 10, 10, 1);

            container2.X = 70000;
            container2.Y = 70000;
            container2.Altitude = 5050;
            container2.Timestamp = new DateTime(2000, 10, 10, 10, 10, 2);

            List.Add(container1);
            List.Add(container2);

            _calculateCourse.CourseCalculated += Raise.EventWith(this, new ATMEvent(List));
            SeperationList = _uut.CheckSeperation(List);

            Assert.That(SeperationList.Count, Is.EqualTo(0));
        }



    }
}
