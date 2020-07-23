using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficCount.Presentation.TCService;
using System.Data;
using System.Data.Linq;
using System.Data.Entity;

namespace TrafficCount.Presentation
{
    public partial class TCHistory : System.Web.UI.Page
    {                       

        #region //Autocomplete Methods
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static string[] FindSite(string prefixText)
        {
            using (TCService.TCSummaryClient db = new TCService.TCSummaryClient())
            {
                return db.GetSiteID(prefixText);
            }
        }
        #endregion


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static string[] FindFirstRoad(string prefixText)
        {            
            using (TCService.TCSummaryClient db = new TCService.TCSummaryClient())
            {
                return db.GetRoad1(prefixText);
            }
        }

        

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static string[] FindSecondRoad(string contextKey, string prefixText)
        {                        

            using (TCService.TCSummaryClient db = new TCService.TCSummaryClient())
            {
                return db.GetRoad2(contextKey, prefixText);
            }
        }
    }
}