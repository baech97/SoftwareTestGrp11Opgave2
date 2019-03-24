using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class SeperationChecker : iSeperationChecker
    {
        public event EventHandler<SeperationEvent> SeperationChecked;
        public iCalculateCourse _calculateCourse;
        public List<TrackDataContainer> DataRecivedList { get; set; }

        public SeperationChecker(iCalculateCourse calculateCourse)
        {
            _calculateCourse = calculateCourse;
            _calculateCourse.CourseCalculated += OnCourseCalculated;
        }

        public void OnCourseCalculated(object sender, ATMEvent e)
        {
            List<SeperationContainer> seperationList = new List<SeperationContainer>();
            DataRecivedList = new List<TrackDataContainer>();
            DataRecivedList = e._tdcList;

            for (int i = 0; i < DataRecivedList.Count; i++)
            {
                for (int j = i + 1; j < DataRecivedList.Count; j++)
                {
                    var dX = DataRecivedList[i].X - DataRecivedList[j].X;
                    var dY = DataRecivedList[i].Y - DataRecivedList[j].Y;
                    var d = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
                    var dA = Math.Abs(DataRecivedList[i].Altitude - DataRecivedList[j].Altitude);

                    if (dA < 300 && d < 5000)
                    {
                        SeperationContainer sc = new SeperationContainer();
                        sc.TrackTag1 = DataRecivedList[i].Tag;
                        sc.TrackTag2 = DataRecivedList[j].Tag;
                        sc.TimeStamp = DataRecivedList[i].Timestamp;
                        seperationList.Add(sc);
                    }
                }
            }

            SeperationEvent seperationEvent = new SeperationEvent(seperationList);
            SeperationChecked?.Invoke(this, seperationEvent);

        }
    }
}
