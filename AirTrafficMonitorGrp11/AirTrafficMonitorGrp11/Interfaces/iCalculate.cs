using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    interface iCalculate
    {
        event EventHandler<List<TrackDataContainer>> DataCalculated;
    }
}
