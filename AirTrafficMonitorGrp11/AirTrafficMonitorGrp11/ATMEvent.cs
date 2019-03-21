using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class ATMEvent : EventArgs
    {
        public List<TrackDataContainer> _tdcList { get; set; }

        public ATMEvent(List<TrackDataContainer> tdcList)
        {
            _tdcList = tdcList;
        }
    }
}
