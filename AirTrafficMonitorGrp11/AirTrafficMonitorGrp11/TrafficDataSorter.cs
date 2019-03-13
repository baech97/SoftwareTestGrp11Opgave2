using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11
{
    class TrafficDataSorter : iTrafficDataSorter
    {
        private iTranspondanceDecoder _decoder;
        public event EventHandler<List<TrackDataContainer>> DataSorted;

        public TrafficDataSorter(iTranspondanceDecoder decoder)
        {
            _decoder = decoder;
            _decoder.DataDecoded += OnDataDecoded;
        }


        public void OnDataDecoded(object sender, List<TrackDataContainer> e)
        {
            foreach (var data in e)
            {
                //if ()
                {
                    
                }
            }
        }
    }
}
