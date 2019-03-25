using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11
{
    public class TranspondanceDecoder : iTranspondanceDecoder
    {
        private ITransponderReceiver _transponderReceiver;
        public event EventHandler<ATMEvent> DataDecoded;
        public List<string> DataRecivedList { get; set; }

        public TranspondanceDecoder(ITransponderReceiver transponderReceiver)
        {
            _transponderReceiver = transponderReceiver;
            _transponderReceiver.TransponderDataReady += OnTransponderDataReady;
        }

        public void OnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            DataRecivedList = e.TransponderData;

            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();

            foreach (var data in e.TransponderData)
            {
                string[] inputFields;
                TrackDataContainer _tdc = new TrackDataContainer();
                inputFields = data.Split(';');
                _tdc.Tag = Convert.ToString(inputFields[0]);
                _tdc.X = Convert.ToInt32(inputFields[1]);
                _tdc.Y = Convert.ToInt32(inputFields[2]);
                _tdc.Altitude = Convert.ToInt32(inputFields[3]);
                _tdc.Timestamp =
                    DateTime.ParseExact(inputFields[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                tdcList.Add(_tdc);
            }

            if (tdcList.Count != 0)
            {
                ATMEvent atmEvent = new ATMEvent(tdcList);
                DataDecoded?.Invoke(this, atmEvent);
            }
        }
    }
}
