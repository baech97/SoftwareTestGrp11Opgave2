using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    class TrafficDataSorterTest
    {
        private iTranspondanceDecoder _decoder;
        private TrafficDataSorter _uut;
        private List<TrackDataContainer> listReceived;


        [SetUp]
        public void SetUp()
        {
            _decoder = NSubstitute.Substitute.For<iTranspondanceDecoder>();

            _uut = new TrafficDataSorter(_decoder);
            _uut.DataSorted += (o, args) => { listReceived = args; };


        }

        [Test]
        public void Track_in_airspace()
        {

            TrackDataContainer tdc1 = new TrackDataContainer();
            tdc1.X = 20000;
            tdc1.Y = 30000;
            tdc1.Altitude = 10000;

            //_decoder.DataDecoded += Raise.EventWith(this, new listReceived(tdc1));

            //Assert.That(_uut.OnDataDecoded());
        }

    }
}
