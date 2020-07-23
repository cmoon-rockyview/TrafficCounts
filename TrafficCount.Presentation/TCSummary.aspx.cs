using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficCount.Presentation.ucHistory;

namespace TrafficCount.Presentation
{
    public partial class TCSummary : System.Web.UI.Page
    {
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static string[] FindDirection(string prefixText)
        {
            using ( TCService.TCSummaryClient db = new TCService.TCSummaryClient() )
            {
                return db.GetSiteID(prefixText);
            }
        }

    }
}