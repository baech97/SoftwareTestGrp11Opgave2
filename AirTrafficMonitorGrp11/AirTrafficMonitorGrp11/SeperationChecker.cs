using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class SeperationChecker : iSeperationChecker
    {
        public event EventHandler<List<SeperationContainer>> SeperationChecked;
        public iTrafficDataSorter _dataSorter;

        public SeperationChecker(iTrafficDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
            _dataSorter.DataSorted += OnDataSorted;
        }

        public void OnDataSorted(object sender, List<TrackDataContainer> e)
        {
            List<SeperationContainer> seperationList = new List<SeperationContainer>();

            for (int i = 0; i < e.Count; i++)
            {
                for (int j = i+1; j < e.Count; j++)
                {
                    var dX = Math.Abs(e[i].X - e[j].X);
                    var dY = Math.Abs( e[i].Y - e[j].Y);
                    var d = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
                    var dA = Math.Abs(e[i].Altitude - e[j].Altitude);

                    if (dA < 30000)
                    {
                        if (dX <= 50000 && dY < 50000)
                        {
                            if (d < 50000)
                            {
                                SeperationContainer sc = new SeperationContainer();
                                sc.TrackTag1 = e[i].Tag;
                                sc.TrackTag2 = e[j].Tag;
                                sc.TimeStamp = e[i].Timestamp;
                                seperationList.Add(sc);
                            }
                        }
                    }
                }
            }
            
            if (seperationList.Count != 0)
            {
                SeperationChecked?.Invoke(this, seperationList);
            }
        }
    }
}
