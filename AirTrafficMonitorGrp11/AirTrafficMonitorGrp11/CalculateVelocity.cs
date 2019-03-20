﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class CalculateVelocity : iCalculateVelocity
    {

        private iTrafficDataSorter _dataSorter;
        public event EventHandler<List<TrackDataContainer>> VelocityCalculated;

        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;
        private DateTime LastTime;
        private DateTime CurrentTime;
        private double timediff;
        private double Velocity;

        public CalculateVelocity(iTrafficDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
            _dataSorter.DataSorted += OnDataSorted;
        }

        public void OnDataSorted(object sender, List<TrackDataContainer> e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            foreach (var data in e)
            {
                CurrentPosition_X = data.X;
                CurrentPosition_Y = data.Y;
                CurrentTime = data.Timestamp;

                TimeSpan ts = CurrentTime - LastTime;
                timediff = ts.Milliseconds;

                Velocity = timediff * (Math.Sqrt((CurrentPosition_X - LastPosition_X) ^ 2) + ((CurrentPosition_Y - LastPosition_Y) ^ 2));
                data.Velocity = Velocity;
                tdcList.Add(data);


                LastPosition_X = data.X;
                LastPosition_Y = data.Y;
                LastTime = data.Timestamp;
            }

            VelocityCalculated?.Invoke(this, tdcList);

        }
    }
}
