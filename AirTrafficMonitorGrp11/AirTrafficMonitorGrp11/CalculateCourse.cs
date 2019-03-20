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
        public event EventHandler<List<TrackDataContainer>> CourseCalculated;

        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;

        private double Course;
        //
        private List<TrackDataContainer> LastFlightData = new List<TrackDataContainer>();
        private List<TrackDataContainer> CurrentFlightData = new List<TrackDataContainer>();  

        public CalculateCourse(iCalculateVelocity calculateVelocity) 
        {
            _calculateVelocity = calculateVelocity;
            _calculateVelocity.VelocityCalculated += Calculate;
            LastFlightData = new List<TrackDataContainer>();
        }

        //event

        public void Calculate(object sender, List<TrackDataContainer> e)
        {
            CurrentFlightData = new List<TrackDataContainer>();
            CurrentFlightData = e;


            foreach (var flight in CurrentFlightData)
            {
                OnVelocityCalculated(flight);
            }

            LastFlightData = CurrentFlightData;

            //CurrentFlightData.Add(data);

        }

        public void OnVelocityCalculated(TrackDataContainer currentFlights)   
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            foreach (var lastFlight in LastFlightData)
            {
                if (lastFlight.Tag == currentFlights.Tag)
                {
                    LastPosition_X = lastFlight.X;
                    LastPosition_Y = lastFlight.Y;
                    CurrentPosition_X = currentFlights.X;
                    CurrentPosition_Y = currentFlights.Y;

                    //udregning
                    Course = 90 - Math.Atan((CurrentPosition_Y - LastPosition_Y) / (CurrentPosition_X - LastPosition_X)) * (180 * Math.PI);

                    Course = Convert.ToInt32(Course);

                    CourseCalculated?.Invoke(this, tdcList);


                }
            }
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
