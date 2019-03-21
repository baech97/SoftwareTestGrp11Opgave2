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
        private List<TrackDataContainer> DataRecivedList;


        [SetUp]
        public void SetUp()
        {
            _decoder = NSubstitute.Substitute.For<iTranspondanceDecoder>();
            _uut = new TrafficDataSorter(_decoder);

            _uut.DataSorted += (o, args) => { DataRecivedList = args; };
        }

        [Test]
        public void TestReception()
        {
            TrackDataContainer dataList = new TrackDataContainer();
            dataList.X = 20000;
            dataList.Y = 30000;
            dataList.Altitude = 10000;

            DataRecivedList.Add(dataList);
            
            //Make the source raise the event
            Assert.That(_uut.DataRecivedList, Is.Not.Null);

            Assert.That(_uut.DataRecivedList, Is.EqualTo(dataList));
        }

    }
}
