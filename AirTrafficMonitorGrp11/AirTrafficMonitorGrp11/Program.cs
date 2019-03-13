using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            TranspondanceDecoder td = new TranspondanceDecoder(receiver);

            //Test af hente ting fra containeren
            TrackDataContainer tdc = new TrackDataContainer();
            Console.WriteLine(tdc.Altitude);
            //

            while (true)
                Thread.Sleep(1000);
        }
    }
}
