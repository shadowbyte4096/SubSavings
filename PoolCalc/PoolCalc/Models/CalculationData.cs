using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolCalc.Models
{
    public class CalculationData
    {
        public double initialAmount;
        public double increase;
        public double max;
        public TimeSpan frequency;
        public DateTime dateStarted;
        public DateTime dateFinished;
    }
}
