using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TrafficCount.Domain;
using System.Data;
using System.Data.Linq;
using System.Data.Entity;

namespace TrafficCount.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TCSummary" in code, svc and config file together.
    public class TCSummary : ITCSummary
    {
        TrafficCountEntities dtTC = new TrafficCountEntities();

        public string[] GetUserNameByLogin(string login)
        {
            return dtTC.UserNames.Where(s => s.Login == login).Select(s => s.Login).ToArray();
        }

        public List<spTCSummaryByLoc_Result> GetTCSummaryByLoc(string Road1, string Road2, string Dir)
        {
            var query = dtTC.spTCSummaryByLoc(Road1, Road2, Dir);
            return query.ToList();
        }

        public List<spTCSummaryBySite_Result> GetTCSummaryBySite(string SiteID)
        {
            var query = dtTC.spTCSummaryBySite(SiteID);
            return query.ToList();
        }
        public List<spTCSummaryOneBySite_Result> GetTCSummaryOneBySite(string SiteID)
        {
            var query = dtTC.spTCSummaryOneBySite(SiteID);
            return query.ToList();
        }


        public List<spTCAxlesSummaryBySite_Result> GetTCAxlesSummaryBySite(string SiteID)
        {
            var query = dtTC.spTCAxlesSummaryBySite(SiteID);

            
            return query.ToList();
        }


        public List<spTCSpeedSummaryBySite_Result> GetTCSpeedSummaryBySite(string SiteID)
        {
            var query = dtTC.spTCSpeedSummaryBySite(SiteID);
            return query.ToList();
        }



        public List<spTCAxlesDetails_Result> GetTCAxlesDetailsBySite(string SiteID, DateTime dateCaptured)
        {
            var query = dtTC.spTCAxlesDetails(SiteID, dateCaptured).Distinct();
            return query.ToList();
        }


        public List<spTCSpeedDetails_Result> GetTCSpeedDetailsBySite(string SiteID , DateTime dateCaptured)
        {
            var query = dtTC.spTCSpeedDetails(SiteID, dateCaptured).Distinct();
            return query.ToList();
        }


        public string[] GetRoad1(string RoadName)
        {
                       

            var Query = dtTC.spFindRoad1(RoadName);
            return Query.ToArray();
        }


        public string[] GetRoad2(string RoadName1, string RoadName2)
        {
            var Query = dtTC.spFindRoad2(RoadName1, RoadName2);
            return Query.ToArray();
        }


        public string[] GetSiteID(string siteID)
        {
            var Query = dtTC.spFindSite(siteID);
            return Query.ToArray();
        }

        public string GetXY(string firstName, string secondName, string dir)
        {
            try
            {

                string XY = string.Empty;


                var Sensor = dtTC.TrafficCountSensors.Where(s => s.road_1 == firstName && s.road_2 == secondName && s.direction == dir).FirstOrDefault();

                if (Sensor.Shape != null)
                    XY = Sensor.Shape.XCoordinate.ToString() + " , " + Sensor.Shape.YCoordinate.ToString();
                else
                    return String.Empty;


                return XY;
            }

            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        public string GetXYBySite(string siteID)
        {
            try
            {

                string XY = string.Empty;

                var Sensor = dtTC.TCSummaries.Where(s => s.vchSiteID == siteID).FirstOrDefault();

                if (Sensor.Shape != null)
                    XY = Sensor.Shape.XCoordinate.ToString() + " , " + Sensor.Shape.YCoordinate.ToString();
                else
                    return String.Empty;

                XY = Sensor.Shape.XCoordinate.ToString() + " , " + Sensor.Shape.YCoordinate.ToString();



                return XY;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }





    }
}
