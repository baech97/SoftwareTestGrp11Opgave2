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
        private List<SeperationContainer> seperationList = new List<SeperationContainer>();
        public List<SeperationContainer> DataRecivedList { get; set; }


        public PrintLog(iSeperationChecker seperationChecker)
        {
            _seperationChecker = seperationChecker;
            _seperationChecker.SeperationChecked += OnSeparationChecked;
        }

        private void OnSeparationChecked(object sender, SeperationEvent e)
        {
            DataRecivedList = e._SeperationList;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Log.txt"))
            {
                foreach (var data in DataRecivedList)
                {
                    foreach (var element in seperationList)
                    {
                        if (data.TrackTag1 != element.TrackTag1 && data.TrackTag2 != element.TrackTag2)
                        {
                            file.WriteLine("Time of occurance: " + data.TimeStamp + ":" + data.TimeStamp.Millisecond + "\nInvolved tracks: " + data.TrackTag1 + " and " + data.TrackTag2 + "\n");
                            seperationList.Add(data);
                        }
                    }


                }
            }
        }
    }
}
