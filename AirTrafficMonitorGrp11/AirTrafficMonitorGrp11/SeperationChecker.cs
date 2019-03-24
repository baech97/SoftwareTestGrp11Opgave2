using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    public class SeperationChecker : iSeperationChecker
    {
        public event EventHandler<SeperationEvent> SeperationChecked;
        public iTrafficDataSorter _dataSorter;
        public List<TrackDataContainer> DataRecivedList { get; set; }

        public SeperationChecker(iTrafficDataSorter dataSorter)
        {
            _dataSorter = dataSorter;
            _dataSorter.DataSorted += OnDataSorted;
        }

        public void OnDataSorted(object sender, ATMEvent e)
        {
            List<SeperationContainer> seperationList = new List<SeperationContainer>();
            DataRecivedList = new List<TrackDataContainer>();
            DataRecivedList = e._tdcList;

            for (int i = 0; i < DataRecivedList.Count; i++)
            {
                for (int j = i+1; j < DataRecivedList.Count; j++)
                {
                    var dX = Math.Abs(DataRecivedList[i].X - DataRecivedList[j].X);
                    var dY = Math.Abs( DataRecivedList[i].Y - DataRecivedList[j].Y);
                    var d = Math.Sqrt(Math.Pow(dX, 2) + Math.Pow(dY, 2));
                    var dA = Math.Abs(DataRecivedList[i].Altitude - DataRecivedList[j].Altitude);

                    if (dA < 300)
                    {
                        if (dX <= 5000 && dY < 5000)
                        {
                            if (d < 5000)
                            {
                                SeperationContainer sc = new SeperationContainer();
                                sc.TrackTag1 = DataRecivedList[i].Tag;
                                sc.TrackTag2 = DataRecivedList[j].Tag;
                                sc.TimeStamp = DataRecivedList[i].Timestamp;

                                seperationList.Add(sc);
                            }
                        }
                    }
                }
            }

            if (seperationList.Count != 0)
            {
                SeperationEvent seperationEvent = new SeperationEvent(seperationList);
                SeperationChecked?.Invoke(this, seperationEvent);
            }
        }
    }
}
