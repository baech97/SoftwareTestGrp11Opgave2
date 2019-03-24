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
        public List<SeperationContainer> TotalSeperationList = new List<SeperationContainer>();



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
                    if (!TotalSeperationList.Contains(data.TrackTag1))
                    {
                        
                    }
                    foreach (var element in TotalSeperationList)
                    {
                        if (data.TrackTag1 != element.TrackTag1 && data.TrackTag2 != element.TrackTag2)
                        {
                            file.WriteLine("Time of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond + "\nInvolved tracks: " + data.TrackTag1 + " and " + data.TrackTag2 + "\n");
                            TotalSeperationList.Add(data);
                        }
                    }


                }
            }
        }
    }
}
