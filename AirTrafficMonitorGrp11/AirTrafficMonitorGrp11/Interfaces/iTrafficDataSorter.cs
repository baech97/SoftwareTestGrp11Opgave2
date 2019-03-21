using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public interface iTrafficDataSorter
    {
        event EventHandler<ATMEvent> DataSorted;
    }
}
