using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficCount.Presentation.TCService;

namespace TrafficCount.Presentation.ucSummary
{
    public partial class LocationMap : System.Web.UI.UserControl
    {

        //string sSiteID = string.Empty;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    BasicInfo basicInfo = (BasicInfo)Page.FindControl("BasicInfo1");
        //    sSiteID = ((TextBox)basicInfo.FindControl("txtSiteID")).Text;

        //    if (sSiteID != string.Empty)
        //        FindLocationBySite(sSiteID);
        //}



        //public void FindLocationBySite(string siteID)
        //{
        //    string sLocation = string.Empty;

        //    using (TCSummaryClient TC = new TCSummaryClient())
        //    {
        //        sLocation = TC.GetXYBySite(siteID);
        //    }

        //    if (sLocation != string.Empty)
        //    {

        //        string sX = sLocation.Substring(0, sLocation.IndexOf(",") - 1).Trim();
        //        string sY = sLocation.Substring(sLocation.IndexOf(",") + 1, sLocation.Length - (sLocation.IndexOf(",") + 1)).Trim();

        //        string sFunction = "ZoomToSensor(" + sX + "," + sY + ")";

        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", sFunction, true);

        //    }

        //}


        //public void FindLocation(string firstRoad, string secondRoad, string dir)
        //{
        //    string sLocation = string.Empty;

        //    using (TCSummaryClient TC = new TCSummaryClient())
        //    {
        //        sLocation = TC.GetXY(firstRoad, secondRoad, dir);
        //    }

        //    if (sLocation != string.Empty)
        //    {

        //        string sX = sLocation.Substring(0, sLocation.IndexOf(",") - 1).Trim();
        //        string sY = sLocation.Substring(sLocation.IndexOf(",") + 1, sLocation.Length - (sLocation.IndexOf(",") + 1)).Trim();

        //        string sFunction = "ZoomToSensor(" + sX + "," + sY + ")";

        //        Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", sFunction, true);

        //    }
        //}

    }
}