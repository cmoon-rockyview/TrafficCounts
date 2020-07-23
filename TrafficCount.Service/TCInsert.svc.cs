using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TrafficCount.Domain;
using System.Data.Linq;

namespace TrafficCount.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TCInsert" in code, svc and config file together.
    public class TCInsert : ITCInsert
    {
        
        TrafficCountEntities dtTC = new TrafficCountEntities();

        public bool DelTCbySiteID(string siteID)
        {
            try
            {
                dtTC.spDelTCBySiteID(siteID);

                
                return true;
            }
            catch
            {                
                return false;
            }
        }


        public bool InsertTCSummary(string site, int twp, string location, DateTime timeStart, int numberOfVehicle, string postedLimit,
                        string percentile85, string percentageTrucks, string road1, string road2, string dir, string insertedBy)
        {
            try
            {

                TrafficCount.Domain.TCSummary ta = new Domain.TCSummary
                {
                    vchSiteID = site,
                    intTWP = twp,
                    vchLocation = location,
                    dteDateOfCount = timeStart,
                    intNumofVehicles = numberOfVehicle,
                    vchPostedLimit = postedLimit,
                    vch85Percentile = percentile85,
                    vchPercentageTrucks = percentageTrucks,
                    Road1 = road1,
                    Road2 = road2,
                    Dir = dir,
                    InsertUser = insertedBy
                    

                };

                dtTC.TCSummaries.Add(ta);
                dtTC.SaveChanges();

                return true;

            }
            catch
            {
                return false;

            }

        }



        public bool InsertTCAxlesSummary(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaputred, string location,
                                  int? motorCycles, int passengerCars, int? twoAxleFourTires, int? bues, int? twoAxlesSixTires,
                                  int? threeAxlesSingleUnitTruck, int? fourOrMoreAxleSingleUnitTruck, int? fourOrLessAxleSingleTrailer,
                                  int? fiveAleSingleTrailerTruck, int? sixOrMoreAxleSingleTrailerTruck, int? fiveLessAxleMultiTrailerTruck,
                                  int? sixAxleMultiTrailerTruck, int? sevenMoreAxleMultiTrailerTruck, double? spMean, double? vpp85)
        {
            try
            {

                TCAxlesSummary ta = new TCAxlesSummary
                {
                    SiteID = siteID,
                    Lane = lane,
                    Bound = bound,
                    TimeStart = timeStart,
                    TimeEnd = timeEnd,
                    TimeCaptured = timeCaputred,
                    Location = location,
                    MotorCycles = motorCycles,
                    Buses = bues,
                    PassengerCars = passengerCars,
                    TwoAxleFourTires = twoAxleFourTires,
                    TwoAxleSixTires = twoAxlesSixTires,
                    ThreeAxleSingleUnitTruck = threeAxlesSingleUnitTruck,
                    FourOrMoreAxleSignleUnitTruck = fourOrMoreAxleSingleUnitTruck,
                    FourOrLessAxleSingleTrailerTruck = fourOrLessAxleSingleTrailer,
                    FiveAxleSignleTrailerTruck = fiveAleSingleTrailerTruck,
                    SixOrMoreAxleSignleTrailerTruck = sixOrMoreAxleSingleTrailerTruck,
                    FiveLessAxleMultiTrailerTruck = fiveLessAxleMultiTrailerTruck,
                    SixAxleMultiTrailerTruck = sixAxleMultiTrailerTruck,
                    SevenMoreAxleMultiTrailerTruck = sevenMoreAxleMultiTrailerTruck,
                    SpMean = spMean,
                    Vpp85 = vpp85

                };

                dtTC.TCAxlesSummaries.Add(ta);
                dtTC.SaveChanges();


                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool InsertTCSpeedSummary(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaputred, string location,
                                         int sp0To10, int sp10To20, int sp20To30, int sp30To40, int sp40To50,
                                         int sp50To60, int sp60To70, int sp70To80, int sp80To90, int sp90To100,
                                         int sp100To110, int sp110To120, int sp120To130, int sp130To140, int sp140To150,
                                         int sp150To160, int sp160To200, double spMean, double vpp85)
        {

            try
            {

                TCSpeedSummary ts = new TCSpeedSummary
                {

                    SiteID = siteID,
                    Lane = lane,
                    Bound = bound,
                    TimeStart = timeStart,
                    TimeEnd = timeEnd,
                    TimeCaptured = timeCaputred,
                    Location = location,
                    Sp0To10 = sp0To10,
                    Sp10To20 = sp10To20,
                    Sp20To30 = sp20To30,
                    Sp30To40 = sp30To40,
                    Sp40To50 = sp40To50,
                    Sp50To60 = sp50To60,
                    Sp60To70 = sp60To70,
                    Sp70To80 = sp70To80,
                    Sp80To90 = sp80To90,
                    Sp90To100 = sp90To100,
                    Sp100To110 = sp100To110,
                    Sp110To120 = sp110To120,
                    Sp120To130 = sp120To130,
                    Sp130To140 = sp130To140,
                    Sp140To150 = sp140To150,
                    Sp150To160 = sp150To160,
                    Sp160To200 = sp160To200,
                    SpMean = spMean,
                    Vpp85 = vpp85

                };

                dtTC.TCSpeedSummaries.Add(ts);
                dtTC.SaveChanges();


                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool InsertTCAxlesDetails(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaptured, string location,
                                  int? motorCycles, int passengerCars, int? twoAxleFourTires, int? bues, int? twoAxlesSixTires,
                                  int? threeAxlesSingleUnitTruck, int? fourOrMoreAxleSingleUnitTruck, int? fourOrLessAxleSingleTrailer,
                                  int? fiveAleSingleTrailerTruck, int? sixOrMoreAxleSingleTrailerTruck, int? fiveLessAxleMultiTrailerTruck,
                                  int? sixAxleMultiTrailerTruck, int? sevenMoreAxleMultiTrailerTruck, double? spMean, double? vpp85)
        {
            try
            {

                TCAxlesDetail ta = new TCAxlesDetail
                {
                    SiteID = siteID,
                    Lane = lane,
                    Bound = bound,
                    TimeStart = timeStart,
                    TimeEnd = timeEnd,
                    TimeCaptured = timeCaptured,
                    Location = location,
                    MotorCycles = motorCycles,
                    Buses = bues,
                    PassengerCars = passengerCars,
                    TwoAxleFourTires = twoAxleFourTires,
                    TwoAxleSixTires = twoAxlesSixTires,
                    ThreeAxleSingleUnitTruck = threeAxlesSingleUnitTruck,
                    FourOrMoreAxleSignleUnitTruck = fourOrMoreAxleSingleUnitTruck,
                    FourOrLessAxleSingleTrailerTruck = fourOrLessAxleSingleTrailer,
                    FiveAxleSignleTrailerTruck = fiveAleSingleTrailerTruck,
                    SixOrMoreAxleSignleTrailerTruck = sixOrMoreAxleSingleTrailerTruck,
                    FiveLessAxleMultiTrailerTruck = fiveLessAxleMultiTrailerTruck,
                    SixAxleMultiTrailerTruck = sixAxleMultiTrailerTruck,
                    SevenMoreAxleMultiTrailerTruck = sevenMoreAxleMultiTrailerTruck,
                    SpMean = spMean,
                    Vpp85 = vpp85

                };

                dtTC.TCAxlesDetails.Add(ta);
                dtTC.SaveChanges();


                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool InsertTCSpeedDetails(string siteID, string lane, string bound, DateTime timeStart, DateTime timeEnd, string timeCaptured, string location,
                                         int sp0To10, int sp10To20, int sp20To30, int sp30To40, int sp40To50,
                                         int sp50To60, int sp60To70, int sp70To80, int sp80To90, int sp90To100,
                                         int sp100To110, int sp110To120, int sp120To130, int sp130To140, int sp140To150,
                                         int sp150To160, int sp160To200, double spMean, double vpp85)
        {

            try
            {

                TCSpeedDetail ts = new TCSpeedDetail
                {

                    SiteID = siteID,
                    Lane = lane,
                    Bound = bound,
                    TimeStart = timeStart,
                    TimeEnd = timeEnd,
                    TimeCaptured = timeCaptured,
                    Location = location,
                    Sp0To10 = sp0To10,
                    Sp10To20 = sp10To20,
                    Sp20To30 = sp20To30,
                    Sp30To40 = sp30To40,
                    Sp40To50 = sp40To50,
                    Sp50To60 = sp50To60,
                    Sp60To70 = sp60To70,
                    Sp70To80 = sp70To80,
                    Sp80To90 = sp80To90,
                    Sp90To100 = sp90To100,
                    Sp100To110 = sp100To110,
                    Sp110To120 = sp110To120,
                    Sp120To130 = sp120To130,
                    Sp130To140 = sp130To140,
                    Sp140To150 = sp140To150,
                    Sp150To160 = sp150To160,
                    Sp160To200 = sp160To200,
                    SpMean = spMean,
                    Vpp85 = vpp85

                };

                dtTC.TCSpeedDetails.Add(ts);
                dtTC.SaveChanges();


                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool InsertTCSummary(string site, int twp, string location, DateTime timeStart, int numberOfVehicle, string postedLimit, string percentile85, string percentageTrucks, string road1, string road2, string dir)
        {
            throw new NotImplementedException();
        }
    }
}
