using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    interface iCalculateCourse
    {
        event EventHandler<List<TrackDataContainer>> CourseCalculated;
    }
}
