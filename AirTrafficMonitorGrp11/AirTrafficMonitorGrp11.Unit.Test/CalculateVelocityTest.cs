//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using NSubstitute;

//namespace AirTrafficMonitorGrp11.Unit.Test
//{
//    [TestFixture]
//    public class CalculateVelocityTest
//    {

//        private iTrafficDataSorter _dataSorter;
//        private CalculateVelocity _uut;
//        private List<TrackDataContainer> _recievedEvents;
//        [SetUp]
//        public void SetUp()
//        {
//            _dataSorter = NSubstitute.Substitute.For<iTrafficDataSorter>();
//            _uut = new CalculateVelocity(_dataSorter);
//            _uut.VelocityCalculated += (o, args) => { _recievedEvents = args; };
//            _recievedEvents = null;

//        }

//        [Test]
//        public void Is_Event_raised()
//        {
//            List<string> testdata = new List<string>();
//            //testdata.Add();
//            testdata.Add("BCD123;10005;85890;12000;20151006213456789");
//            testdata.Add("XYZ987;25059;75654;4000;20151006213456789");

//            //_dataSorter


//        }
//    }
//}
