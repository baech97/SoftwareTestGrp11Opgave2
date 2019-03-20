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

        public PrintConsole(iCalculateCourse calculateCourse, iSeperationChecker seperationChecker)
        {
            _calculateCourse = calculateCourse;
            _seperationChecker = seperationChecker;
            _calculateCourse.CourseCalculated += OnCourseCalculated;
            _seperationChecker.SeperationChecked += OnSeparationChecked;

        }

        private void OnSeparationChecked(object sender, List<SeperationContainer> e)
        {
            foreach (var data in e)
            {
                Console.WriteLine("Time of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond + "\nInvolved tracks: "+ data.TrackTag1 + " and " + data.TrackTag2 + "\n" );
            }
        }

        private void OnCourseCalculated(object sender, List<TrackDataContainer> e)
        {
            foreach (var data in e)
            {
                Console.WriteLine("Tag: " + data.Tag + "\nCurrent position:  X: " + data.X + " meters, Y: " + data.Y + " meters \nCurrent altitude: " + data.Altitude + " meters \nCurrent horizontal velocity: " + data.Velocity + " m/s \nCurrent compass course: " + data.Course + "degrees from north\n" + "Timestamp: " + data.Timestamp + ":" + data.Timestamp.Millisecond + "\n");
            }
        }

    }
}
