using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficCount.Presentation.DTO
{
    public class TCSpeedDTO
    {
        public string Speed { get; set; }
        public int LaneA { get; set; }
        public int LaneB { get; set; }
        public int Total { get; set; }


        public TCSpeedDTO(string speed, int? laneA, int? laneB)
        {
            Speed = speed;
            LaneA = laneA == null ? 0 : (int)laneA;
            LaneB = laneB == null ? 0 : (int)laneB;
            Total = LaneA + LaneB;
        }

     

    }
}