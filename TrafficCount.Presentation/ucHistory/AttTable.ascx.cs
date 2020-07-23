using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficCount.Presentation.TCInsert;
namespace TrafficCount.Presentation.ucHistory
{
    public partial class AttTable : System.Web.UI.UserControl
    {
        Label lblResult;
        SearchWidget searchWidget;
        Label lblFirstRoad;
        Label lblSecondRoad;
        Label lblDir;

        private void SetControls()
        {
            
            searchWidget = (SearchWidget)Page.FindControl("SearchWidget1");
            lblResult = (Label)searchWidget.FindControl("lblResult");

            lblFirstRoad = (Label)searchWidget.FindControl("lblFirstRoad");
            lblSecondRoad = (Label)searchWidget.FindControl("lblSecondRoad");
            lblDir = (Label)searchWidget.FindControl("lblDir");


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetControls();
                        
        }
        protected void gvTCHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string sUserName = System.Web.HttpContext.Current.User.Identity.Name.ToUpper().ToString().Replace(@"ROCKYVIEW\", "");

                TCService.TCSummaryClient _proxy = new TCService.TCSummaryClient();                

                if (_proxy.GetUserNameByLogin(sUserName).Count() > 0)
                {
                                    
                    string siteID = e.Values["SiteID"].ToString();

                    using (TCInsertClient tc = new TCInsertClient())
                    {                        
                        tc.DelTCbySiteID(siteID);                      
                    }
                
                    gvTCHistory.DataSource = _proxy.GetTCSummaryByLoc(lblFirstRoad.Text, lblSecondRoad.Text, lblDir.Text);
                    gvTCHistory.DataBind();

                    lblResult.Text = siteID + " is deleted successfully";
                    Response.Write(siteID + " is deleted successfully");

                    //Page.Response.Redirect("TCHistory.aspx?Site=" + siteID);

                    
                }
                else
                {
                    lblResult.Text = "You do not have permission to delete the record. Please contact GIS Department";
                    Response.Write("You do not have permission to delete the record. Please contact GIS Department");
                }

                

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }
    }
}