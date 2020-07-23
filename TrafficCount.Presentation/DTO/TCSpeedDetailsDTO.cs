using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficCount.Presentation.DTO
{
    public class TCSpeedDetailsDTO
    {
        public string SiteID { get; set; }
        public string Lane { get; set; }
        public string Bound { get; set; }
        public string TimeCaptured { get; set; }
        public string Location { get; set; }

        public int? sp0To10 { get; set; }
        public int? sp10To20 { get; set; }
        public int? sp20To30 { get; set; }
        public int? sp30To40 { get; set; }
        public int? sp40To50 { get; set; }
        public int? sp50To60 { get; set; }
        public int? sp60To70 { get; set; }
        public int? sp70To80 { get; set; }
        public int? sp80To90 { get; set; }
        public int? sp90To100 { get; set; }
        public int? sp100To110 { get; set; }
        public int? sp110To120 { get; set; }
        public int? sp120To130 { get; set; }
        public int? sp130To140 { get; set; }
        public int? sp140To150 { get; set; }
        public int? sp150To160 { get; set; }
        public int? sp160To200 { get; set; }    
        public int? Total { get; set; }        
        public double SpMean { get; set; }
        public double Vpp85 { get; set; }
    }
}