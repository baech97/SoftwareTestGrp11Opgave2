using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    class PrintLog : iPrintLog
    {
        public void EtEllerAndet()
        {
            // Opret forbindelse til SeperationChecker, tag  alt indholdet fra denne liste, og læg det ind i filen
            SeperationChecker

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Log.txt"))
            {
                foreach (var data in COLLECTION)
                {
                    file.WriteLine("TEKST" + data);
                }
            }
        }
    }
}
