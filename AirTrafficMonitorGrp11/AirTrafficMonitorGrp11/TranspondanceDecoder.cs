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
        TrackDataContainer _tdc;
        

        public TranspondanceDecoder(ITransponderReceiver transponderReceiver)
        {
            _transponderReceiver = transponderReceiver;
            _transponderReceiver.TransponderDataReady += OnTransponderDataReady;
        }

        public void OnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            string[] inputFields;
            foreach (var data in e.TransponderData)
            {
                _tdc = new TrackDataContainer();
                inputFields = data.Split(';');
                _tdc.Tag = Convert.ToString(inputFields[0]);
                _tdc.X = Convert.ToInt32(inputFields[1]);
                _tdc.Y = Convert.ToInt32(inputFields[2]);
                _tdc.Altitude = Convert.ToInt32(inputFields[3]);
                _tdc.Timestamp = Convert.ToDateTime(inputFields[4]);
            }
        }

        public void Decode(string transponderData)
        {

        }
    }
}
