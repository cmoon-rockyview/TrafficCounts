//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrafficCount.Domain
{
    using System;
    
    public partial class spTCAxlesDetails_Result
    {
        public string TimeCaptured { get; set; }
        public string Lane { get; set; }
        public Nullable<int> MotorCycles { get; set; }
        public Nullable<int> PassengerCars { get; set; }
        public Nullable<int> TwoAxleFourTires { get; set; }
        public Nullable<int> Buses { get; set; }
        public Nullable<int> TwoAxleSixTires { get; set; }
        public Nullable<int> ThreeAxleSingleUnitTruck { get; set; }
        public Nullable<int> FourOrMoreAxleSignleUnitTruck { get; set; }
        public Nullable<int> FourOrLessAxleSingleTrailerTruck { get; set; }
        public Nullable<int> FiveAxleSignleTrailerTruck { get; set; }
        public Nullable<int> SixOrMoreAxleSignleTrailerTruck { get; set; }
        public Nullable<int> FiveLessAxleMultiTrailerTruck { get; set; }
        public Nullable<int> SixAxleMultiTrailerTruck { get; set; }
        public Nullable<int> SevenMoreAxleMultiTrailerTruck { get; set; }
        public Nullable<int> TruckCount { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<double> SpMean { get; set; }
    }
}
