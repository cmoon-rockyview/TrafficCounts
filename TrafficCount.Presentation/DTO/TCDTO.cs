using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace TrafficCount.Presentation
{
    public class TCDTO
    {
        public string DateOfCalc { get; set; }
        public int? Volume { get; set; }
        public int Percentile85 { get; set; }
        public int PercentageTrucks { get; set; }


        public TCDTO(string dateOfCalc, int? volume, string percentile85, string percentageTrucks)
        {
            this.DateOfCalc = dateOfCalc;
            this.Volume = volume;
            if (IsInteger(percentile85))
                this.Percentile85 = int.Parse(percentile85.Trim());
            else if (IsDouble(percentile85))
                this.Percentile85 = (int)Math.Round(double.Parse(percentile85.Trim()));
            else
                this.Percentile85 = 0;

            if (IsInteger(percentageTrucks))
                this.PercentageTrucks = int.Parse(percentageTrucks.Trim());
            else if (IsDouble(percentageTrucks))
                this.PercentageTrucks = (int)Math.Round(double.Parse(percentageTrucks.Trim()));
            else
                this.PercentageTrucks = 0;

        }

        private bool IsInteger(string Str)
        {
           
           int Num;
           bool isNum = int.TryParse(Str, out Num);
           return isNum;
           
        }

        private bool IsDouble(string Str)
        {

            double Num;
            bool isNum = double.TryParse(Str, out Num);
            return isNum;

        }
    }
}