using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficCount.Presentation.DTO;
using TrafficCount.Presentation.TCService;
using Microsoft.VisualBasic;


namespace TrafficCount.Presentation
{
    
    
    public class Utility
    {
              
        public static string returnBound(string mainBound, string subBound)
        {
            // North and South Bound
            if (mainBound == "1")
            {
                if (subBound == "AB" || subBound == "P" || subBound.Contains("-"))                
                    return "Northbound";                
                else
                    return "Southbound";
                
                
            }
            //East and West Bound
            else if (mainBound == "2" )
            {
                if (subBound == "AB" || subBound == "P" || subBound.Contains("-"))
                    return "Eastbound";
                else
                    return "Westbound";

            }
            else
            {
                return string.Empty;
            }

        }

        //private string returnTimeCapture(string firstTime)
        //{
        //    string fixedTime;

        //    if (firstTime.Substring(0, 1) == "0")
        //    {
        //        firstTime = firstTime.Substring(1, firstTime.Length - 1);

        //    }
        //    else
        //    {

        //    }
        //}

        //public static bool ImportTrafficXML(string file)
        //{
        //    try
        //    {
        //        TCInsert.TCInsertClient tcInsert = new TCInsert.TCInsertClient();
                
        //        XDocument xdoc = XDocument.Load(file);

        //        //Import Header
        //        var ds = xdoc.Descendants("Header").Descendants("Dataset").First();
        //        var pf = xdoc.Descendants("Header").Descendants("Profile").First();
        //        //Import Data
        //        var sStep = xdoc.Descendants("Data").Descendants("Step");
        //        var sTotal = xdoc.Descendants("Data").Descendants("Total");         

        //        //Site ID
        //        string sSiteID = ds.Element("SiteName").Value??string.Empty;
        //        string sNorthOrEast = ds.Element("Direction").Value??string.Empty;
        //        string sLocation = ds.Element("Description").Value??string.Empty;
        //        //Import Location 
        //        sLocation = sLocation==string.Empty?string.Empty:sLocation.Substring(0, sLocation.IndexOf("&"));

        //        //Start and End Time
        //        DateTime dFilterStart = DateTime.Parse(pf.Element("FilterStart").Value);
        //        DateTime dFilterEnd = DateTime.Parse(pf.Element("FilterEnd").Value);

        //        //PostedLimit
        //        int iPostedTime = pf.Element("PostedLimit").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(pf.Element("PostedLimit").Value) ? pf.Element("PostedLimit").Value : "0");

      

        //        #region //Data

                
        //        foreach (var da in sStep)
        //        {                    
        //             string sTimeCaptured = da.Element("F00").Value??string.Empty;
        //             string sLane = da.Element("F01").Value ?? string.Empty;
        //             string sBound = returnBound(sNorthOrEast, sLane);

        //             #region // Import AxlesDetails
        //             int iMotorCycles = da.Element("F02").IsEmpty? 0 
        //                :int.Parse(Information.IsNumeric(da.Element("F02").Value) ? da.Element("F02").Value : "0");
        //             int iPassengerVehicle = da.Element("F03").IsEmpty ? 0 
        //                :int.Parse(Information.IsNumeric(da.Element("F03").Value) ? da.Element("F03").Value : "0");
        //             int iTwoAxleFourTires = da.Element("F04").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F04").Value)?da.Element("F04").Value:"0");
        //             int iBuses = da.Element("F05").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F05").Value) ? da.Element("F05").Value : "0");
        //             int iTwoAxleSixTires = da.Element("F06").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F06").Value) ? da.Element("F06").Value : "0");
        //             int iThreeAxleSingleUnitTruck = da.Element("F07").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F07").Value) ? da.Element("F07").Value : "0");
        //             int iFourOrMoreAxleSignleUnitTruck = da.Element("F08").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F08").Value) ? da.Element("F08").Value : "0");
        //             int iFourOrLessAxleSingleTrailerTruck = da.Element("F09").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F09").Value) ? da.Element("F09").Value : "0");
        //             int iFiveAxleSignleTrailerTruck = da.Element("F10").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F10").Value) ? da.Element("F10").Value : "0");
        //             int iSixOrMoreAxleSignleTrailerTruck = da.Element("F11").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F11").Value) ? da.Element("F11").Value : "0");
        //             int iFiveLessAxleMultiTrailerTruck = da.Element("F12").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F12").Value) ? da.Element("F12").Value : "0");
        //             int iSixAxleMultiTrailerTruck = da.Element("F13").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F13").Value) ? da.Element("F13").Value : "0");
        //             int iSevenMoreAxleMultiTrailerTruck = da.Element("F14").IsEmpty? 0 
        //                 :int.Parse(Information.IsNumeric(da.Element("F14").Value) ? da.Element("F14").Value : "0");

        //             double iSpMean = da.Element("F36").IsEmpty? 0 
        //                 :double.Parse(Information.IsNumeric(da.Element("F36").Value) ? da.Element("F36").Value : "0");
        //             double iVpp85 = da.Element("F37").IsEmpty? 0 
        //                 :double.Parse(Information.IsNumeric(da.Element("F37").Value) ? da.Element("F37").Value : "0");

                     

        //            tcInsert.InsertTCAxlesDetails(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured, sLocation,
        //                                          iMotorCycles, iPassengerVehicle, iTwoAxleFourTires, iBuses, iTwoAxleSixTires,
        //                                          iThreeAxleSingleUnitTruck, iFourOrMoreAxleSignleUnitTruck, iFourOrLessAxleSingleTrailerTruck,
        //                                          iFiveAxleSignleTrailerTruck, iSixOrMoreAxleSignleTrailerTruck, iFiveLessAxleMultiTrailerTruck,
        //                                          iSixAxleMultiTrailerTruck, iSevenMoreAxleMultiTrailerTruck, iSpMean, iVpp85);
        //        #endregion                                   
     
        //             #region //Import SpeedDetails
        //            int iSP0To10 = da.Element("F15").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F15").Value) ? da.Element("F15").Value : "0");
        //            int iSP10To20 = da.Element("F16").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F16").Value) ? da.Element("F16").Value : "0");
        //            int iSP20To30 = da.Element("F17").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F17").Value) ? da.Element("F17").Value : "0");
        //            int iSP30To40 = da.Element("F18").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F18").Value) ? da.Element("F18").Value : "0");
        //            int iSP40To50 = da.Element("F19").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F19").Value) ? da.Element("F19").Value : "0");
        //            int iSP50To60 = da.Element("F20").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F20").Value) ? da.Element("F20").Value : "0");
        //            int iSP60To70 = da.Element("F21").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F21").Value) ? da.Element("F21").Value : "0");
        //            int iSP70To80 = da.Element("F22").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F22").Value) ? da.Element("F22").Value : "0");
        //            int iSP80To90 = da.Element("F23").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F23").Value) ? da.Element("F23").Value : "0");
        //            int iSP90To100 = da.Element("F24").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F24").Value) ? da.Element("F24").Value : "0");
        //            int iSP100To110 = da.Element("F25").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F25").Value) ? da.Element("F25").Value : "0");
        //            int iSP110To120 = da.Element("F26").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F26").Value) ? da.Element("F26").Value : "0");
        //            int iSP120To130 = da.Element("F27").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F27").Value) ? da.Element("F27").Value : "0");
        //            int iSP130To140 = da.Element("F28").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F28").Value) ? da.Element("F28").Value : "0");
        //            int iSP140To150 = da.Element("F29").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F29").Value) ? da.Element("F29").Value : "0");
        //            int iSP150To160 = da.Element("F30").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F30").Value) ? da.Element("F30").Value : "0");
        //            int iSP160To170 = da.Element("F31").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F31").Value) ? da.Element("F31").Value : "0");
        //            int iSP170To180 = da.Element("F32").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F32").Value) ? da.Element("F32").Value : "0");
        //            int iSP180To190 = da.Element("F33").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F33").Value) ? da.Element("F33").Value : "0");
        //            int iSP190To200 = da.Element("F34").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(da.Element("F34").Value) ? da.Element("F34").Value : "0");
                    

        //            int iSP160To200 = iSP160To170 + iSP170To180 + iSP180To190 + iSP190To200;


        //            tcInsert.InsertTCSpeedDetails(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured, sLocation,
        //                                            iSP0To10, iSP10To20, iSP20To30, iSP30To40, iSP40To50, iSP50To60, iSP60To70,
        //                                            iSP70To80, iSP80To90, iSP90To100, iSP100To110, iSP110To120, iSP120To130, iSP130To140,
        //                                            iSP140To150, iSP150To160, iSP160To200, iSpMean, iVpp85);
        //        #endregion

                 

        //        }
                
        //        #endregion               

        //        #region //Total

        //        int iTotal = 0;
        //        int iTruckCount = 0;
        //        double dTruckPercentage = 0.0;
        //        double dPercentage85 = 0.0;

        //        foreach (var dt in sTotal)
        //        {


        //            string sTimeCaptured = dt.Element("F00").Value ?? string.Empty;
        //            sTimeCaptured = sTimeCaptured.Contains("--") ? "All Time" : sTimeCaptured;

        //            string sLane = dt.Element("F01").Value??string.Empty;
        //            sLane = sLane.Contains("-") ? "AB" : sLane;

        //            string sBound = returnBound(sNorthOrEast, sLane);

        //            #region //Import AxlesSummary
        //            int iMotorCycles = dt.Element("F02").IsEmpty ? 0
        //               : int.Parse(Information.IsNumeric(dt.Element("F02").Value) ? dt.Element("F02").Value : "0");
        //            int iPassengerVehicle = dt.Element("F03").IsEmpty ? 0
        //               : int.Parse(Information.IsNumeric(dt.Element("F03").Value) ? dt.Element("F03").Value : "0");
        //            int iTwoAxleFourTires = dt.Element("F04").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F04").Value) ? dt.Element("F04").Value : "0");
        //            int iBuses = dt.Element("F05").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F05").Value) ? dt.Element("F05").Value : "0");
        //            int iTwoAxleSixTires = dt.Element("F06").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F06").Value) ? dt.Element("F06").Value : "0");
        //            int iThreeAxleSingleUnitTruck = dt.Element("F07").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F07").Value) ? dt.Element("F07").Value : "0");
        //            int iFourOrMoreAxleSignleUnitTruck = dt.Element("F08").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F08").Value) ? dt.Element("F08").Value : "0");
        //            int iFourOrLessAxleSingleTrailerTruck = dt.Element("F09").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F09").Value) ? dt.Element("F09").Value : "0");
        //            int iFiveAxleSignleTrailerTruck = dt.Element("F10").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F10").Value) ? dt.Element("F10").Value : "0");
        //            int iSixOrMoreAxleSignleTrailerTruck = dt.Element("F11").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F11").Value) ? dt.Element("F11").Value : "0");
        //            int iFiveLessAxleMultiTrailerTruck = dt.Element("F12").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F12").Value) ? dt.Element("F12").Value : "0");
        //            int iSixAxleMultiTrailerTruck = dt.Element("F13").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F13").Value) ? dt.Element("F13").Value : "0");
        //            int iSevenMoreAxleMultiTrailerTruck = dt.Element("F14").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F14").Value) ? dt.Element("F14").Value : "0");

        //            double iSpMean = dt.Element("F36").IsEmpty ? 0
        //                : double.Parse(Information.IsNumeric(dt.Element("F36").Value) ? dt.Element("F36").Value : "0");
        //            double iVpp85 = dt.Element("F37").IsEmpty ? 0
        //                : double.Parse(Information.IsNumeric(dt.Element("F37").Value) ? dt.Element("F37").Value : "0");
        //            int iTotalNum = dt.Element("F35").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F35").Value) ? dt.Element("F35").Value : "0");
                    

        //            tcInsert.InsertTCAxlesSummary(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured,
        //                                          sLocation, iMotorCycles, iPassengerVehicle, iTwoAxleFourTires, iBuses,
        //                                          iTwoAxleSixTires, iThreeAxleSingleUnitTruck, iFourOrMoreAxleSignleUnitTruck,
        //                                          iFourOrLessAxleSingleTrailerTruck, iFiveAxleSignleTrailerTruck, iSixOrMoreAxleSignleTrailerTruck,
        //                                          iFiveLessAxleMultiTrailerTruck, iSixAxleMultiTrailerTruck, iSevenMoreAxleMultiTrailerTruck, iSpMean,iVpp85);
        //            #endregion

        //            #region //Import SpeedSummary
        //            int iSP0To10 = dt.Element("F15").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F15").Value) ? dt.Element("F15").Value : "0");
        //            int iSP10To20 = dt.Element("F16").IsEmpty ? 0
        //               : int.Parse(Information.IsNumeric(dt.Element("F16").Value) ? dt.Element("F16").Value : "0");
        //            int iSP20To30 = dt.Element("F17").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F17").Value) ? dt.Element("F17").Value : "0");
        //            int iSP30To40 = dt.Element("F18").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F18").Value) ? dt.Element("F18").Value : "0");
        //            int iSP40To50 = dt.Element("F19").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F19").Value) ? dt.Element("F19").Value : "0");
        //            int iSP50To60 = dt.Element("F20").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F20").Value) ? dt.Element("F20").Value : "0");
        //            int iSP60To70 = dt.Element("F21").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F21").Value) ? dt.Element("F21").Value : "0");
        //            int iSP70To80 = dt.Element("F22").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F22").Value) ? dt.Element("F22").Value : "0");
        //            int iSP80To90 = dt.Element("F23").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F23").Value) ? dt.Element("F23").Value : "0");
        //            int iSP90To100 = dt.Element("F24").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F24").Value) ? dt.Element("F24").Value : "0");
        //            int iSP100To110 = dt.Element("F25").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F25").Value) ? dt.Element("F25").Value : "0");
        //            int iSP110To120 = dt.Element("F26").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F26").Value) ? dt.Element("F26").Value : "0");
        //            int iSP120To130 = dt.Element("F27").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F27").Value) ? dt.Element("F27").Value : "0");
        //            int iSP130To140 = dt.Element("F28").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F28").Value) ? dt.Element("F28").Value : "0");
        //            int iSP140To150 = dt.Element("F29").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F29").Value) ? dt.Element("F29").Value : "0");
        //            int iSP150To160 = dt.Element("F30").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F30").Value) ? dt.Element("F30").Value : "0");
        //            int iSP160To170 = dt.Element("F31").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F31").Value) ? dt.Element("F31").Value : "0");
        //            int iSP170To180 = dt.Element("F32").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F32").Value) ? dt.Element("F32").Value : "0");
        //            int iSP180To190 = dt.Element("F33").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F33").Value) ? dt.Element("F33").Value : "0");
        //            int iSP190To200 = dt.Element("F34").IsEmpty ? 0
        //                : int.Parse(Information.IsNumeric(dt.Element("F34").Value) ? dt.Element("F34").Value : "0");


        //            int iSP160To200 = iSP160To170 + iSP170To180 + iSP180To190 + iSP190To200;


        //            tcInsert.InsertTCSpeedSummary(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured,
        //                                          sLocation, iSP0To10, iSP10To20, iSP20To30, iSP30To40, iSP40To50, iSP50To60,
        //                                          iSP60To70, iSP70To80, iSP80To90, iSP90To100, iSP100To110, iSP110To120, iSP120To130,
        //                                          iSP130To140, iSP140To150, iSP150To160, iSP160To200, iSpMean, iVpp85);

        //            #endregion
                    
        //            #region //Calculate Total
        //            if (sTimeCaptured == "All Time")
        //            {
        //                iTotal += iTotalNum;

        //                iTruckCount +=
        //                (iTwoAxleSixTires + iThreeAxleSingleUnitTruck + iFourOrMoreAxleSignleUnitTruck
        //                 + iFourOrLessAxleSingleTrailerTruck + iFiveAxleSignleTrailerTruck + iSixOrMoreAxleSignleTrailerTruck +
        //                 iFiveLessAxleMultiTrailerTruck + iSixAxleMultiTrailerTruck + iSevenMoreAxleMultiTrailerTruck);

        //                dPercentage85 += (iTotalNum * iVpp85);

        //            }
        //            #endregion


        //        }
        //        #endregion

        //        #region //Calculate Summarized data
        //        dPercentage85 = Math.Round(dPercentage85 / (double)iTotal, 2);
        //        dTruckPercentage = Math.Round(((double)iTruckCount / (double)iTotal * 100), 2);
        //        tcInsert.InsertTCSummary(sSiteID, 0, sLocation, dFilterStart, iTotal, iPostedTime.ToString() + "KM/H", 
        //                                 dPercentage85.ToString()  , dTruckPercentage.ToString(),  , "", "");

        //        #endregion

        //        return true;

        //    }
        //    catch (NotImplementedException ex)
        //    {
        //        string a = ex.Message.ToString();
        //        return false;

        //    }



        //}
        
    }
}