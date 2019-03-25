using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class CalculateCourse : iCalculateCourse
    {
        private iCalculateVelocity _calculateVelocity;
        public event EventHandler<ATMEvent> CourseCalculated;
        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;
        public double Course { get; set; }
       
        public List<TrackDataContainer> LastFlightData { get; set; } = new List<TrackDataContainer>();
        private List<TrackDataContainer> CurrentFlightData;

        public CalculateCourse(iCalculateVelocity calculateVelocity)
        {
            _calculateVelocity = calculateVelocity;
            _calculateVelocity.VelocityCalculated += OnVelocityCalculated;
            LastFlightData = new List<TrackDataContainer>();
        }

        public void OnVelocityCalculated(object sender, ATMEvent e)
        {
            List<TrackDataContainer> trackList = new List<TrackDataContainer>();

            CurrentFlightData = new List<TrackDataContainer>();
            CurrentFlightData = e._tdcList;
            trackList = Calculate(CurrentFlightData);
            LastFlightData = CurrentFlightData;
            
            ATMEvent atmEvent = new ATMEvent(trackList);
            CourseCalculated?.Invoke(this, atmEvent);
        }

        public List<TrackDataContainer> Calculate(List<TrackDataContainer> currentFlights)
        {
            List<TrackDataContainer> list = new List<TrackDataContainer>();
            foreach (var lastFlight in LastFlightData)
            {
                foreach (var currentFlight in currentFlights)
                {

                    if (lastFlight.Tag == currentFlight.Tag)
                    {
                        LastPosition_X = lastFlight.X;
                        LastPosition_Y = lastFlight.Y;
                        CurrentPosition_X = currentFlight.X;
                        CurrentPosition_Y = currentFlight.Y;
                        
                        var dX = CurrentPosition_X - LastPosition_X;
                        var dY = CurrentPosition_Y - LastPosition_Y;

                        if (dX == 0)
                        {
                            if (CurrentPosition_Y > LastPosition_Y)
                            {
                                Course = 0;
                            }
                            else if (LastPosition_Y > CurrentPosition_Y)
                            {
                                Course = 180;
                            }
                        }
                        if (dX > 0)
                        {
                            Course = 90 - Math.Atan(dY / dX) * (180 / Math.PI);
                        }

                        else if (dX < 0)
                        {
                            Course = 270 - Math.Atan(dY / dX) * (180 / Math.PI);
                        }

                        lastFlight.Course = Convert.ToInt32(Course);

                        list.Add(lastFlight);
                    }
                }
            }
            return list;
        }
    }
}
