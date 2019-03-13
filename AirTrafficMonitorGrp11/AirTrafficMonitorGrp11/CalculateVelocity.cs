using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitorGrp11
{
    class CalculateVelocity : iCalculate
    {
        private int LastPosition_X;
        private int LastPosition_Y;
        private int CurrentPosition_X;
        private int CurrentPosition_Y;
        private DateTime LastTime = DateTime.UtcNow;
        private DateTime CurrentTime = DateTime.Now;
        private double timediff;

        private double Velocity;


        public void CalculateVelocity()
        {
            Velocity = (CurrentTime - LastTime) *
                       ((CurrentPosition_X - LastPosition_X) ^ 2 + (CurrentPosition_Y - LastPosition_Y) ^ 2);

            timediff = CurrentTime - LastTime;

        }

       
    }
}
