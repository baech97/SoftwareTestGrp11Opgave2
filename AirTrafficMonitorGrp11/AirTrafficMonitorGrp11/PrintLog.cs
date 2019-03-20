using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class PrintLog : iPrintLog
    {
        public iSeperationChecker _seperationChecker;

        public PrintLog(iSeperationChecker seperationChecker)
        {
            _seperationChecker = seperationChecker;
            _seperationChecker.SeperationChecked += OnSeparationChecked;
        }

        private void OnSeparationChecked(object sender, List<SeperationContainer> e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Log.txt"))
            {
                foreach (var data in e)
                {
                    file.WriteLine("Time of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond + "\nInvolved tracks: "+ data.TrackTag1 + " and " + data.TrackTag2 + "\n" );
                }
            }
        }
    }
}
 