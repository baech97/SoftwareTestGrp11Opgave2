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
            List<SeperationContainer> calculatedList = new List<SeperationContainer>();
            DataRecivedList = new List<TrackDataContainer>();
            DataRecivedList = e._tdcList;
            calculatedList = CheckSeperation(DataRecivedList);
            

            SeperationEvent seperationEvent = new SeperationEvent(calculatedList);
            SeperationChecked?.Invoke(this, seperationEvent);

        }

        public List<SeperationContainer> CheckSeperation(List<TrackDataContainer> list)
        {
            List<SeperationContainer> seperationList = new List<SeperationContainer>();

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    var dX = list[i].X - list[j].X;
                    var dY = list[i].Y - list[j].Y;
                    var d = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
                    var dA = Math.Abs(list[i].Altitude - list[j].Altitude);

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

            return seperationList;
        }
    }
}
