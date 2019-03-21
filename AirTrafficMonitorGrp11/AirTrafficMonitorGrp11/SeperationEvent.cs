using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class SeperationEvent : EventArgs
    {
        public List<SeperationContainer> _SeperationList { get; set; }

        public SeperationEvent(List<SeperationContainer> seperationList)
        {
            _SeperationList = seperationList;
        }
    }
}
