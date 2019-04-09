using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitorGrp11
{
    public class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            iTranspondanceDecoder decoder = new TranspondanceDecoder(receiver);
            iTrafficDataSorter dataSorter = new TrafficDataSorter(decoder);
            iCalculateVelocity calculateVelocity = new CalculateVelocity(dataSorter);
            iCalculateCourse calculateCourse = new CalculateCourse(calculateVelocity);
            iSeperationChecker separationChecker = new SeperationChecker(calculateCourse);
            
            PrintConsole printConsole = new PrintConsole(calculateCourse, separationChecker);
            PrintLog printLog = new PrintLog(separationChecker);

            while (true)
            Thread.Sleep(1000);
        }
    }
}
