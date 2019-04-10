using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    class NEWTrafficDataSorterTest
    {
        private TrafficDataSorter _uut;
        private ATMEvent _event;
        private iTranspondanceDecoder _decoder;

        [SetUp]
        public void Setup()
        {
            _event = null;
            _decoder = NSubstitute.Substitute.For<iTranspondanceDecoder>();
            _uut = new TrafficDataSorter(_decoder);

            _uut.DataSorted +=
                (o, args) => { _event = args; };
        }

        [Test]
        public void EventFired()
        {
            List<TrackDataContainer> list = new List<TrackDataContainer>();

            TrackDataContainer container = new TrackDataContainer();
            container.Tag = "ATR423";
            container.X = 20000;
            container.Y = 10000;
            container.Altitude = 10000;
            container.Timestamp = DateTime.Now;

            TrackDataContainer container2 = new TrackDataContainer();
            container2.Tag = "ATR423";
            container2.X = 10000;
            container2.Y = 20000;
            container2.Altitude = 10000;
            container2.Timestamp = DateTime.Now;

            list.Add(container);
            list.Add(container2);

            _decoder.DataDecoded += Raise.EventWith(new ATMEvent(list));

            Assert.That(_event, Is.Not.Null);
        }
    }
}
