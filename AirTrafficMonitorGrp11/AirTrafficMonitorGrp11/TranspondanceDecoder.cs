﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        public event EventHandler <List<TrackDataContainer>> DataDecoded;

        public TranspondanceDecoder(ITransponderReceiver transponderReceiver)
        {
            _transponderReceiver = transponderReceiver;
            _transponderReceiver.TransponderDataReady += OnTransponderDataReady;
        }

        public void OnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            
            foreach (var data in e.TransponderData)
            {
                string[] inputFields;
                _tdc = new TrackDataContainer();

                inputFields = data.Split(';');
                _tdc.Tag = Convert.ToString(inputFields[0]);
                _tdc.X = Convert.ToInt32(inputFields[1]);
                _tdc.Y = Convert.ToInt32(inputFields[2]);
                _tdc.Altitude = Convert.ToInt32(inputFields[3]);
                _tdc.Timestamp = Convert.ToDateTime(inputFields[4]).ToString("yyyy-MM-dd HH:mm:ss.fff",CultureInfo.InvariantCulture);
                tdcList.Add(_tdc);
            }
            DataDecoded?.Invoke(this,tdcList);
        }
    }
}
