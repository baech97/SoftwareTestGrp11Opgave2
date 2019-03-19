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
        public event EventHandler<List<TrackDataContainer>> VelocityCalculated;

        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;
        private DateTime LastTime = DateTime.Now;
        private DateTime CurrentTime = DateTime.Now;
        private double timediff;
        private double Velocity;

        [SetUp]
        public SetUp()
        {

        }
    }
}
