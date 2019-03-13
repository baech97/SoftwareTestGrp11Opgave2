using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    class CalculateCourse : iCalculate
    {
        private iTrafficDataSorter _dataSorter;
        public event EventHandler<List<TrackDataContainer>> DataCalculated;
        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;

        private double Course;

        public CalculateCourse(iTrafficDataSorter dataSorter)
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

                if ( LastPosition_X!= null)
                {
                    Course = 90 - (Math.Atan((CurrentPosition_Y - LastPosition_Y) / (CurrentPosition_X - LastPosition_X)) * (180 * Math.PI));
                    data.Course = Convert.ToInt32(Course);
                    tdcList.Add(data);
                }

                LastPosition_X = data.X;
                LastPosition_Y = data.Y;
            }

            DataCalculated?.Invoke(this, tdcList);
        }
    }
}
