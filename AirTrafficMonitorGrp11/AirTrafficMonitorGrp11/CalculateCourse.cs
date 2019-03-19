using System;
using System.Collections.Generic;
using System.Linq;
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

        public CalculateCourse(iCalculateVelocity calculateVelocity)
        {
            _calculateVelocity = calculateVelocity;
            _calculateVelocity.VelocityCalculated += OnVelocityCalculated;
        }

        public void OnVelocityCalculated(object sender, List<TrackDataContainer> e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();
            foreach (var data in e)
            {
                CurrentPosition_X = data.X;
                CurrentPosition_Y = data.Y;

                if (LastPosition_X == 0)
                {
                    Course = 90 - Math.Atan((CurrentPosition_Y - LastPosition_Y) / (CurrentPosition_X - LastPosition_X)) * (180 * Math.PI);
                    data.Course = Convert.ToInt32(Course);
                    tdcList.Add(data);
                }

                LastPosition_X = data.X;
                LastPosition_Y = data.Y;
            }

            CourseCalculated?.Invoke(this, tdcList);
        }
    }
}
