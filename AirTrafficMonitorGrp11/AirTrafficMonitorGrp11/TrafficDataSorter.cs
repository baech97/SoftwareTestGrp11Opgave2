﻿using System;
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
        public event EventHandler<List<TrackDataContainer>> DataSorted;

        public TrafficDataSorter(iTranspondanceDecoder decoder)
        {
            _decoder = decoder;
            _decoder.DataDecoded += OnDataDecoded;
        }


        public void OnDataDecoded(object sender, List<TrackDataContainer> e)
        {
            
            
                List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
                foreach (var data in e)
                {
                    if (data.X > 10000 && data.X < 90000)
                    {
                        if (data.Y > 10000 && data.Y < 90000)
                        {
                            if (data.Altitude > 500 && data.Altitude < 20000)
                            {
                                tdcList.Add(data);
                            }
                        }
                    }
                }

            if (tdcList.Count != 0)
            {
                DataSorted?.Invoke(this, tdcList);
            }
                     
        }
    }
}
