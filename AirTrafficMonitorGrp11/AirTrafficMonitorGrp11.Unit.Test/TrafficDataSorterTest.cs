﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitorGrp11.Unit.Test
{
    class TrafficDataSorterTest
    {
        private TrafficDataSorter _uut;
        private iTranspondanceDecoder _decoder;
        private List<TrackDataContainer> listReceived;

        [SetUp]

        public void SetUp()
        {
            _decoder = NSubstitute.Substitute.For<iTranspondanceDecoder>();

            _uut = new TrafficDataSorter(_decoder);
            _uut.DataSorted += (o, args) => { listReceived = args; };
        }

        [Test]

    }
}