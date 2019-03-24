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
        public List<SeperationContainer> DataRecivedList { get; set; }
        public List<string> TotalSeperationList = new List<string>();



        public PrintLog(iSeperationChecker seperationChecker)
        {
            _seperationChecker = seperationChecker;
            _seperationChecker.SeperationChecked += OnSeparationChecked;
        }

        public void OnSeparationChecked(object sender, SeperationEvent e)
        {
            DataRecivedList = new List<SeperationContainer>();
            DataRecivedList = e._SeperationList;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Log.txt"))
            {
              foreach (var data in DataRecivedList)
              {
                  string separation = "Involved tracks: " + data.TrackTag1 + " + " + data.TrackTag2;

                  if (!TotalSeperationList.Contains(separation))
                  {
                      file.WriteLine("!SEPARATION WARNING!\n" + separation + "   Time of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond);
                      TotalSeperationList.Add(separation);
                  }
              }
            }
        }
    }
}
