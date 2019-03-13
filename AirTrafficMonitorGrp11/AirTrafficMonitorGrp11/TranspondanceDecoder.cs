using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11
{
    class TranspondanceDecoder : iTranspondanceDecoder
    {
        private ITransponderReceiver _transponderReceiver;

        public TranspondanceDecoder(ITransponderReceiver transponderReceiver)
        {
            _transponderReceiver = transponderReceiver;
            _transponderReceiver.TransponderDataReady += OnTransponderDataReady;
        }

        public void OnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var data in e.TransponderData)
            {
                
            }
        }

        public void Decode(string transponderData)
        {

        }
    }
}
