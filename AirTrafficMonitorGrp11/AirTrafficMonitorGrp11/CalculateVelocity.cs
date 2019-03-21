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
        private double Velocity;


        private List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();
        private List<TrackDataContainer> CurrentFlightData;


        public CalculateVelocity(iTrafficDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
            _dataSorter.DataSorted += OnDataSorted;
            
        }

        public void OnDataSorted(object sender, ATMEvent e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            CurrentFlightData = new List<TrackDataContainer>();
            CurrentFlightData = e._tdcList;


            foreach (var flight in CurrentFlightData)
            {
                tdcList = Calculate(flight);
            }

            LastFlightData = CurrentFlightData;

            if (LastFlightData.Count !=0)
            {
                ATMEvent atmEvent = new ATMEvent(tdcList);
                VelocityCalculated?.Invoke(this, atmEvent);
            }
        }

        public List<TrackDataContainer> Calculate(TrackDataContainer currentFligts)
        {
            List<TrackDataContainer> list = new List<TrackDataContainer>();
            foreach (var LastFlight in LastFlightData)
            {
                if (LastFlight.Tag == currentFligts.Tag)
                {
                    LastPosition_X = LastFlight.X;
                    LastPosition_Y = LastFlight.Y;
                    LastTime = LastFlight.Timestamp;

                    CurrentPosition_X = currentFligts.X;
                    CurrentPosition_Y = currentFligts.Y;
                    CurrentTime = currentFligts.Timestamp;


                    

                    TimeSpan ts = CurrentTime - LastTime;
                    timediff = ts.TotalMilliseconds;
                    
                    Velocity =  (Math.Sqrt(Math.Pow(CurrentPosition_X - LastPosition_X, 2) + Math.Pow(CurrentPosition_Y - LastPosition_Y, 2))/ timediff)*1000;

                    Velocity = Convert.ToInt32(Velocity);

                    LastFlight.Velocity = Convert.ToInt32(Velocity);

                    list.Add(LastFlight);



                }
            }

            return list;
        }
    }
}
