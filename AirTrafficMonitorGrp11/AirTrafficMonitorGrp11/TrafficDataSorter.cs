using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11
{
    public class TrafficDataSorter : iTrafficDataSorter
    {
        private iTranspondanceDecoder _decoder;
        public event EventHandler<ATMEvent> DataSorted;
        public List<TrackDataContainer> DataRecivedList { get; set; }

        public TrafficDataSorter(iTranspondanceDecoder decoder)
        {
            _decoder = decoder;
            _decoder.DataDecoded += OnDataDecoded;
        }

        public void OnDataDecoded(object sender, ATMEvent e)
        {
            DataRecivedList = new List<TrackDataContainer>();
            DataRecivedList = e._tdcList;
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            tdcList = SortData(DataRecivedList);

            if (tdcList.Count != 0)
            {
                ATMEvent atmEvent = new ATMEvent(tdcList);
                DataSorted?.Invoke(this, atmEvent);
            }
           

        }

        public List<TrackDataContainer> SortData(List<TrackDataContainer> trackList)
        {
            List<TrackDataContainer> list = new List<TrackDataContainer>();
            foreach (var data in trackList)
            {
                if (data.X >= 10000 && data.X <= 90000)
                {
                    if (data.Y >= 10000 && data.Y <= 90000)
                    {
                        if (data.Altitude >= 500 && data.Altitude <= 20000)
                        {
                            list.Add(data);
                        }
                    }
                }
            }
            return list;
        }
    }
}
