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
    }
}
