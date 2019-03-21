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
        private double Course;

        //
        private List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();
        private List<TrackDataContainer> CurrentFlightData;

        public CalculateCourse(iCalculateVelocity calculateVelocity)
        {
            _calculateVelocity = calculateVelocity;
            _calculateVelocity.VelocityCalculated += OnVelocityCalculated;
            
        }

        //event

        public void OnVelocityCalculated(object sender, ATMEvent e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            CurrentFlightData = new List<TrackDataContainer>();
            CurrentFlightData = e._tdcList;
            
          
                tdcList = Calculate(CurrentFlightData);
            

            LastFlightData = CurrentFlightData;

            if (LastFlightData.Count != 0)
            {
                ATMEvent atmEvent = new ATMEvent(tdcList);
                CourseCalculated?.Invoke(this, atmEvent);
            }
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

                        //udregning
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

        //
        //public CalculateCourse(iCalculateVelocity calculateVelocity)
        //{
        //    _calculateVelocity = calculateVelocity;
        //    _calculateVelocity.VelocityCalculated += OnVelocityCalculated;
        //}

        //public void OnVelocityCalculated(object sender, List<TrackDataContainer> e)
        //{
        //    List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
        //    foreach (var data in e)
        //    {
        //        CurrentPosition_X = data.X;
        //        CurrentPosition_Y = data.Y;

        //        if (LastPosition_X == 0)
        //        {
        //            Course = 90 - Math.Atan((CurrentPosition_Y - LastPosition_Y) / (CurrentPosition_X - LastPosition_X)) * (180 * Math.PI);
        //            data.Course = Convert.ToInt32(Course);
        //            tdcList.Add(data);
        //        }

        //        LastPosition_X = data.X;
        //        LastPosition_Y = data.Y;
        //    }

        //    CourseCalculated?.Invoke(this, tdcList);
        //}
    }
}
