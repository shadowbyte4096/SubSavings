using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolCalc.Enums
{
    public enum VariableTypes
    {
        [Description("Initial AMount")]
        Initial,
        [Description("Max")]
        Max,
        [Description("Increase")]
        Increase,
        [Description("Frequency")]
        Frequency,
        [Description("Date Finished")]
        DateFinished,
        [Description("Date Started")]
        DateStarted
    }
}
