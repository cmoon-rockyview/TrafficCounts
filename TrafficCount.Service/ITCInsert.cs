using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace TrafficCount.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITCInsert" in both code and config file together.
    [ServiceContract]
    public interface ITCInsert
    {

        [OperationContract]
        bool DelTCbySiteID(string siteID);


        [OperationContract]
        bool InsertTCAxlesDetails(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd,  string timeCaptured, string location,
                                  int? motorCycles, int passengerCars, int? twoAxleFourTires, int? bues, int? twoAxlesSixTires,
                                  int? threeAxlesSingleUnitTruck, int? fourOrMoreAxleSingleUnitTruck, int? fourOrLessAxleSingleTrailer,
                                  int? fiveAleSingleTrailerTruck, int? sixOrMoreAxleSingleTrailerTruck, int? fiveLessAxleMultiTrailerTruck,
                                  int? sixAxleMultiTrailerTruck, int? sevenMoreAxleMultiTrailerTruck, double? spMean, double? vpp85);

        [OperationContract]
        bool InsertTCSpeedDetails(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaptured, string location,
                                  int sp0To10, int sp10To20, int sp20To30, int sp30To40, int sp40To50,
                                  int sp50To60, int sp60To70, int sp70To80, int sp80To90, int sp90To100,
                                  int sp100To110, int sp110To120, int sp120To130, int sp130To140, int sp140To150,
                                  int sp150To160, int sp160To200, double spMean, double Vpp85);


        [OperationContract]
        bool InsertTCAxlesSummary(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaptured, string location,
                                  int? motorCycles, int passengerCars, int? twoAxleFourTires, int? bues, int? twoAxlesSixTires,
                                  int? threeAxlesSingleUnitTruck, int? fourOrMoreAxleSingleUnitTruck, int? fourOrLessAxleSingleTrailer,
                                  int? fiveAleSingleTrailerTruck, int? sixOrMoreAxleSingleTrailerTruck, int? fiveLessAxleMultiTrailerTruck,
                                  int? sixAxleMultiTrailerTruck, int? sevenMoreAxleMultiTrailerTruck, double? spMean, double? vpp85);

        [OperationContract]
        bool InsertTCSpeedSummary(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaptured, string location,
                                  int sp0To10, int sp10To20, int sp20To30, int sp30To40, int sp40To50,
                                  int sp50To60, int sp60To70, int sp70To80, int sp80To90, int sp90To100,
                                  int sp100To110, int sp110To120, int sp120To130, int sp130To140, int sp140To150,
                                  int sp150To160, int sp160To200, double spMean, double Vpp85);

        [OperationContract]
        bool InsertTCSummary(string site,int twp, string location, DateTime timeStart, int numberOfVehicle, string postedLimit, 
                             string percentile85, string percentageTrucks, string road1, string road2, string dir , string insertedBy);

        

    }
}
