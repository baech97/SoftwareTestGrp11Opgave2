﻿using System;
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
    class TranspondanceDecoderTest
    {
        private ITransponderReceiver _receiver;
        private TranspondanceDecoder _uut;

        [SetUp]
        public void SetUp()
        {
            _receiver = NSubstitute.Substitute.For<ITransponderReceiver>();
            _uut = new TranspondanceDecoder(_receiver);
        }

        [Test]
        public void TestReception()
        {
            List<string> testData = new List<string>();
            testData.Add("ATR423;39045;12932;14000;20151006213456789");
            testData.Add("BCD123;10005;85890;12000;20151006213456789");
            testData.Add("XYZ987;25059;75654;4000;20151006213456789");

            _receiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(testData));

            

        }
    }
}
