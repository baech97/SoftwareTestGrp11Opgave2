using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class SeperationContainer
    {
        public SeperationContainer()
        {
            TrackTag1 = "";
            TrackTag2 = "";
            TimeStamp = DateTime.MinValue;
        }

        public string TrackTag1 { get; set; }
        public string TrackTag2 { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
