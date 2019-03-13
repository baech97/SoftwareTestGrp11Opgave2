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
        public iTrafficDataSorter _dataSorter;

        public SeperationChecker(iTrafficDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
            _dataSorter.DataSorted += OnDataSorted;
        }

        public void OnDataSorted(object sender, List<TrackDataContainer> e)
        {
            List<TrackDataContainer> tdcList = new List<TrackDataContainer>();


            // skriv seperation checker-kode herinde


            SeperationChecked?.Invoke(this, tdcList);
        }
    }
}
