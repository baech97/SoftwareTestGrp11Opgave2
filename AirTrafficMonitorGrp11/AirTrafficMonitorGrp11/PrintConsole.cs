using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class PrintConsole : iPrintConsole
    {
        public iCalculateCourse _calculateCourse;
        public iSeperationChecker _seperationChecker;
        public List<SeperationContainer> SeperationDataRecivedList { get; set; }
        public List<TrackDataContainer> TrackDataRecivedList { get; set; }


        public PrintConsole(iCalculateCourse calculateCourse, iSeperationChecker seperationChecker)
        {
            _calculateCourse = calculateCourse;
            _seperationChecker = seperationChecker;
            _calculateCourse.CourseCalculated += OnCourseCalculated;
            _seperationChecker.SeperationChecked += OnSeparationChecked;

        }

        public void OnSeparationChecked(object sender, SeperationEvent e)
        {
            SeperationDataRecivedList = new List<SeperationContainer>();
            SeperationDataRecivedList = e._SeperationList;

            foreach (var data in SeperationDataRecivedList)
            {
                Console.WriteLine("!SEPARATION WARNING!\nTime of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond + "   Involved tracks: "+ data.TrackTag1 + " and " + data.TrackTag2 + "\n");
            }
        }

        public void OnCourseCalculated(object sender, ATMEvent e)
        {
            TrackDataRecivedList = new List<TrackDataContainer>();
            TrackDataRecivedList = e._tdcList;

            foreach (var data in TrackDataRecivedList)
            {
                Console.WriteLine("Tag: " + data.Tag + " - Position: X: " + data.X + " meters, Y: " + data.Y + " meters - Current altitude: " + data.Altitude + " meters\nVelocity: " + data.Velocity + " m/s - Course: " + data.Course + "degrees from north - " + "Timestamp: " + data.Timestamp + ":" + data.Timestamp.Millisecond + "\n");
            }
        }

    }
}
