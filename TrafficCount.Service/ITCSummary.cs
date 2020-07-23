using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TrafficCount.Domain;


namespace TrafficCount.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITCSummary" in both code and config file together.
    [ServiceContract]
    public interface ITCSummary
    {
        [OperationContract]
        string[] GetUserNameByLogin(string login);

        [OperationContract]
        List<spTCAxlesDetails_Result> GetTCAxlesDetailsBySite(string SiteID , DateTime dateCaptured);

        [OperationContract]
        List<spTCSpeedDetails_Result> GetTCSpeedDetailsBySite(string SiteID , DateTime dateCaptured);

        [OperationContract]
        List<spTCSummaryByLoc_Result> GetTCSummaryByLoc(string Road1, string Road2, string Dir);

        [OperationContract]
        List<spTCSummaryBySite_Result> GetTCSummaryBySite(string SiteID);

        [OperationContract]
        List<spTCSummaryOneBySite_Result> GetTCSummaryOneBySite(string SiteID);

        [OperationContract]
        List<spTCAxlesSummaryBySite_Result> GetTCAxlesSummaryBySite(string SiteID);

        [OperationContract]
        List<spTCSpeedSummaryBySite_Result> GetTCSpeedSummaryBySite(string SiteID);

        [OperationContract]
        string[] GetRoad1(string RoadName);

        [OperationContract]
        string[] GetRoad2(string RoadName1, string RoadName2);

        [OperationContract]
        string[] GetSiteID(string siteID);

        [OperationContract]
        string GetXY(string firstName, string secondName, string dir);


        [OperationContract]
        string GetXYBySite(string siteID);


      
    }
}
