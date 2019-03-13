using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    class SeperationChecker : iSeperationChecker
    {
        public event EventHandler<List<TrackDataContainer>> SeperationChecked;
        public iCalculate _calculate;

        public SeperationChecker(iCalculate calculate)
        {
            _calculate = calculate;
            _calculate.DataCalculated += OnDataCalculated;
        }

        public void OnDataCalculated(object sender, List<TrackDataContainer> e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();


            // skriv seperation checker-kode herinde


            SeperationChecked?.Invoke(this, tdcList);
        }
    }
}
