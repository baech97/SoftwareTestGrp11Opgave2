using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class SeperationChecker : iSeperationChecker
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
            List<string> seperationList = new List<string>();

            for (int i = 0; i < e.Count; i++)
            {
                for (int j = i+1; j < e.Count; j++)
                {
                    if (e[i].Altitude - e[j].Altitude <= 300)
                    {


                        if (e[i].X - e[j].X <= 5000 && e[i].Y - e[j].Y <= 5000)
                        {
                            
                        }
                    }
                }
            }
            
            if (seperationList.Count != 0)
            {
                //SeperationChecked?.Invoke(this, seperationList);
            }
        }
    }
}
