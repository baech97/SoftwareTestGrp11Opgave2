using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    class PrintConsole : iPrintConsole
    {
        public iCalculate _calculate;
        public iSeperationChecker _seperationChecker;

        public PrintConsole(iCalculate calculate, iSeperationChecker seperationChecker)
        {
            _calculate = calculate;
            _seperationChecker = seperationChecker;
            _calculate.DataCalculated += OnDataCalculated;
            _seperationChecker.SeperationChecked += OnSeparationChecked;

        }

        private void OnSeparationChecked(object sender, List<TrackDataContainer> e)
        {
            foreach (var data in e)
            {
                Console.WriteLine(data);
                // ikke færdig endnu.
            }
        }

        private void OnDataCalculated(object sender, List<TrackDataContainer> e)
        {
            foreach (var data in e)
            {
                Console.WriteLine("Tag: " + data.Tag + "\nCurrent position: " + data.X + " meters -" + data.Y + " meters \nCurrent altitude: " + data.Altitude + " meters \nCurrent horizontal velocity: " + data.Velocity + " m/s \nCurrent compass course: " + data.Course + "degrees from north");
            }
        }

    }
}
