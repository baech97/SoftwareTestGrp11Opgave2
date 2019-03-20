using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    [TestFixture]
    public class CalculateVelocityTest
    {
        
        private iTrafficDataSorter _dataSorter;
        private CalculateVelocity _uut;
        private List<TrackDataContainer> _recievedEvents;
        [SetUp]
        public void SetUp()
        {
            _dataSorter = NSubstitute.Substitute.For<iTrafficDataSorter>();
            _uut = new CalculateVelocity(_dataSorter);
            _uut.VelocityCalculated += (o, args) => { _recievedEvents = args; };
            _recievedEvents = null;

        }

        [Test]
        public void Is_Event_raised()
        {
            List<string> testdata = new List<string>();
            _uut.OnDataSorted(_recievedEvents);
        }
    }
}
