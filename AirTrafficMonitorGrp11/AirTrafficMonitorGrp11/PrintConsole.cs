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

        private void OnSeparationChecked(object sender, List<TrackDataContainer> e)
        {
            foreach (var data in e)
            {
                Console.WriteLine("Time of occurance: " + data.Timestamp + "Tag of the involved track: "+ data.Tag );
                // ikke færdig endnu.
            }
        }

        private void OnCourseCalculated(object sender, List<TrackDataContainer> e)
        {
            foreach (var data in e)
            {
                Console.WriteLine("Tag: " + data.Tag + "\nCurrent position: " + data.X + " meters -" + data.Y + " meters \nCurrent altitude: " + data.Altitude + " meters \nCurrent horizontal velocity: " + data.Velocity + " m/s \nCurrent compass course: " + data.Course + "degrees from north");
            }
        }

    }
}
