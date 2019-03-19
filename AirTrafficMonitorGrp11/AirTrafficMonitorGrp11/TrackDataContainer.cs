using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class TrackDataContainer
    {
        public TrackDataContainer()
        {
            Tag = "";
            X = 0;
            Y = 0;
            Altitude = 0;
            Timestamp = DateTime.Now;
            Velocity = 0;
            Course = 0;
        }
        public string Tag {get; set; }
        public int X { get; set; }
        public int Y { get;set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }
        public double Velocity { get; set; }
        public int Course { get; set; }
    }
}
