using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficCount.Presentation.DTO
{
    public class TCAxlesDTO
    {
        public string Axles { get; set; }
        public int LaneA { get; set; }
        public int LaneB { get; set; }
        public int Total { get; set; }

        public TCAxlesDTO(string axles, int laneA, int laneB, int total)
        {
            this.Axles = axles;
            this.LaneA = laneA;
            this.LaneB = laneB;
            this.Total = total;
        }

        public TCAxlesDTO(string axles, int? laneA, int? laneB)
        {
            Axles = axles;
            LaneA = laneA == null ? 0 : (int)laneA;
            LaneB = laneB == null ? 0 : (int)laneB;
            Total = LaneA + LaneB;
        }
    }
}