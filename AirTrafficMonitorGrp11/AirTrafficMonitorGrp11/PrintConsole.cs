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

        private void OnSeparationChecked(object sender, SeperationEvent e)
        {
            SeperationDataRecivedList = e._SeperationList;

            foreach (var data in SeperationDataRecivedList)
            {
                Console.WriteLine("Time of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond + "\nInvolved tracks: "+ data.TrackTag1 + " and " + data.TrackTag2 + "\n" );
            }
        }

        private void OnCourseCalculated(object sender, ATMEvent e)
        {
            TrackDataRecivedList = e._tdcList;

            foreach (var data in TrackDataRecivedList)
            {
                Console.WriteLine("Tag: " + data.Tag + "\nCurrent position:  X: " + data.X + " meters, Y: " + data.Y + " meters \nCurrent altitude: " + data.Altitude + " meters \nCurrent horizontal velocity: " + data.Velocity + " m/s \nCurrent compass course: " + data.Course + "degrees from north\n" + "Timestamp: " + data.Timestamp + ":" + data.Timestamp.Millisecond + "\n");
            }
        }

    }
}
