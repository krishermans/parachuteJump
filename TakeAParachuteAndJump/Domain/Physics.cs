using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAParachuteAndJump.Domain
{
    public static class Physics
    {
        public const double DeltaT = 0.003;
        public const double G = 9.81;
        
        public static double ToDIU(double meters)
        {
            return (meters - 4201.68) / -6.72 ;
        }

        public static double ToMeters(double diu)
        {
            return -6.72 * diu + 4201.68;
        }
    }
}
