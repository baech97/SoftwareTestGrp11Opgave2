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
        private iTrafficDataSorter _dataSorter;
        private SeperationChecker _uut;

        [SetUp]
        public void SetUp()
        {
            _dataSorter = NSubstitute.Substitute.For<iTrafficDataSorter>();
            _uut = new SeperationChecker(_dataSorter);
        }

        

    }
}
