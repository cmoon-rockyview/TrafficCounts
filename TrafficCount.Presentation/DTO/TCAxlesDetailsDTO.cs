using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficCount.Presentation.DTO
{
    public class TCAxlesDetailsDTO
    {
      public string SiteID {get; set;}
      public string Lane {get; set;}
      public string Bound {get; set;}
      public string TimeCaptured {get; set;}
      public string Location {get; set;}
      public int? MotorCycles { get; set; }
      public int? PassengerCars { get; set; }
      public int? TwoAxleFourTires { get; set; }
      public int? Buses { get; set; }
      public int? TwoAxleSixTires { get; set; }
      public int? ThreeAxleSingleUnitTruck { get; set; }
      public int? FourOrMoreAxleSignleUnitTruck { get; set; }
      public int? FourOrLessAxleSingleTrailerTruck { get; set; }
      public int? FiveAxleSignleTrailerTruck { get; set; }
      public int? SixOrMoreAxleSignleTrailerTruck { get; set; }
      public int? FiveLessAxleMultiTrailerTruck { get; set; }
      public int? SixAxleMultiTrailerTruck { get; set; }
      public int? SevenMoreAxleMultiTrailerTruck { get; set; }
      public int? Total { get; set; }      
      public double SpMean { get; set; }
      public double Vpp85 { get; set; }

      

    }
}