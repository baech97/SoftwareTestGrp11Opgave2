using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    class TrafficDataSorterTest
    {
        private iTranspondanceDecoder _decoder;
        private TrafficDataSorter _uut;

        [SetUp]
        public void SetUp()
        {
            _decoder = NSubstitute.Substitute.For<iTranspondanceDecoder>();
            _uut = new TrafficDataSorter(_decoder);
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

            _decoder.DataDecoded += Raise.EventWith(this, new ATMEvent(dataList));

            Assert.That(_uut.DataRecivedList, Is.EqualTo(dataList));
        }

        [TestCase(10000, 20000, 10000)]
        [TestCase(20000, 10000, 10000)]
        [TestCase(20000, 30000, 500)]
        [TestCase(90000, 30000, 10000)]
        [TestCase(20000, 90000, 10000)]
        [TestCase(20000, 30000, 20000)]
        public void Track_inside_airspace(int s1, int s2, int s3) 
        {
            List<TrackDataContainer> dataList = new List<TrackDataContainer>();
            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = s1;
            container.Y = s2;
            container.Altitude = s3;
            container.Timestamp = DateTime.Now;

            dataList.Add(container);
            Assert.That(_uut.SortData(dataList), Is.EqualTo(dataList));
        }

        [TestCase(9999, 20000, 10000)]
        [TestCase(20000, 9999, 10000)]
        [TestCase(20000,30000, 499)]
        [TestCase(90001, 30000, 10000)]
        [TestCase(20000, 90001, 10000)]
        [TestCase(20000, 30000, 20001)]
        public void Track_outside_airspace(int s1, int s2, int s3)
        {
            List<TrackDataContainer> dataList = new List<TrackDataContainer>();
            TrackDataContainer container = new TrackDataContainer();

            container.Tag = "ATR423";
            container.X = s1;
            container.Y = s2;
            container.Altitude = s3;
            container.Timestamp = DateTime.Now;

            dataList.Add(container);
            Assert.That(_uut.SortData(dataList), Is.Not.EqualTo(dataList));
        }
    }
}
