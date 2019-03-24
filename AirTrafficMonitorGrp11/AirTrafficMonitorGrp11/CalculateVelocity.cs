using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class CalculateVelocity : iCalculateVelocity
    {
        private iTrafficDataSorter _dataSorter;
        public event EventHandler<ATMEvent> VelocityCalculated;

        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;
        private DateTime LastTime;
        private DateTime CurrentTime;
        private double timediff;
        public double Velocity { get; set; }


        public List<TrackDataContainer> LastFlightData { get; set; } = new List<TrackDataContainer>();
        private List<TrackDataContainer> CurrentFlightData;


        public CalculateVelocity(iTrafficDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
            _dataSorter.DataSorted += OnDataSorted;
            LastFlightData = new List<TrackDataContainer>();
        }

        public void OnDataSorted(object sender, ATMEvent e)
        {
           
                List<TrackDataContainer> trackList = new List<TrackDataContainer>();
                CurrentFlightData = new List<TrackDataContainer>();
                CurrentFlightData = e._tdcList;
                trackList = Calculate(CurrentFlightData);
                LastFlightData = CurrentFlightData;

            if (trackList.Count != 0)
            {
                ATMEvent atmEvent = new ATMEvent(trackList);
                VelocityCalculated?.Invoke(this, atmEvent);
            }
                
        }

        public List<TrackDataContainer> Calculate(List<TrackDataContainer> currentFlights)
        {
            List<TrackDataContainer> list = new List<TrackDataContainer>();
            foreach (var LastFlight in LastFlightData)
            {
                foreach (var currentFlight in currentFlights)
                {
                    if (LastFlight.Tag == currentFlight.Tag)
                    {
                        LastPosition_X = LastFlight.X;
                        LastPosition_Y = LastFlight.Y;
                        LastTime = LastFlight.Timestamp;

                        CurrentPosition_X = currentFlight.X;
                        CurrentPosition_Y = currentFlight.Y;
                        CurrentTime = currentFlight.Timestamp;




                        TimeSpan ts = CurrentTime - LastTime;
                        timediff = ts.TotalMilliseconds;

                        Velocity = (Math.Sqrt(Math.Pow(CurrentPosition_X - LastPosition_X, 2) + Math.Pow(CurrentPosition_Y - LastPosition_Y, 2)) / timediff) * 1000;

                        LastFlight.Velocity = Convert.ToInt32(Velocity);

                        list.Add(LastFlight);
                    }
                }
            }

            return list;
        }
    }
}
