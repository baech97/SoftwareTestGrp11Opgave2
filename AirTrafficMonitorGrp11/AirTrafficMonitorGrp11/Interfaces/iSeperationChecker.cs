using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    interface iSeperationChecker
    {
        event EventHandler<List<TrackDataContainer>> SeperationChecked;
    }
}
