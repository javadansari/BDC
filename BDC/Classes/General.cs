using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDC.Classes
{
    public class General
    {
        public string FurnaceHeatDuty { get; set; } = "-";
        public string EvaporatorHeatTransferCorrelation { get; set; } = "-";
        public string EconomizerHeatTransferCorrelation { get; set; } = "-";
        public string SuperheaterHeatTransferCorrelation { get; set; } = "-";

        // Properties related to Burner
        public string NumberOfBurners { get; set; } = "-";

        // Properties related to Drum
        public string DrumID { get; set; } = "-";
        public string DrumShellLength { get; set; } = "-";
        public string DrumNormalLevel { get; set; } = "-";
        public string DrumHeadType { get; set; } = "-";

        // Properties related to Stack
        public string StackID { get; set; } = "-";
        public string StackHeight { get; set; } = "-";

        // Properties related to Deaerator
        public string DeaeratorPressure { get; set; } = "-";
        public string DeaeratorStaticHead { get; set; } = "-";

        // Properties related to Pump TDH Curve
        public string PumpA3 { get; set; } = "-";
        public string PumpA2 { get; set; } = "-";
        public string PumpA1 { get; set; } = "-";
        public string PumpA0 { get; set; } = "-";
    }
}
