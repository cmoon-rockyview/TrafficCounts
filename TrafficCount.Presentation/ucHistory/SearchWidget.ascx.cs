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
using System.Web.UI.DataVisualization.Charting;
using TrafficCount.Presentation.DTO;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace TrafficCount.Presentation.ucHistory
{
    public partial class SearchWidget : System.Web.UI.UserControl
    {
        TCSummaryClient _proxy = new TCSummaryClient();

        //Pages to bind data
        private ChartMap chartMap;
        private AttTable attTable;
        
        private Chart chTCVolume;
        private Chart chTCPercentile;
        private GridView grvHistory;

        private Panel pnlContent;
        private Panel pnlChart;
        private Panel pnlGridView;

        private string _InsertedBy { get; set; }
      

        private void SetControls()
        {
            chartMap = (ChartMap)Page.FindControl("chartMap1");
            attTable = (AttTable)Page.FindControl("AttTable1");

            pnlContent = (Panel)Page.FindControl("pnlContent");
            pnlChart = (Panel)Page.FindControl("pnlChart");
            pnlGridView = (Panel)Page.FindControl("pnlGridView");
            
            chTCVolume = (Chart)chartMap.FindControl("ChartTrafficVolume");
            chTCPercentile = (Chart)chartMap.FindControl("ChartTrafficPercentile85");
            grvHistory = (GridView)attTable.FindControl("gvTCHistory");

            acSecondRoad.ContextKey = txtFirstRoad.Text;
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetControls();
            _InsertedBy = System.Web.HttpContext.Current.User.Identity.Name;

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["Site"] != null && !IsPostBack)
                {
                    SetControls();
                    txtSite.Text = Request.QueryString["Site"];
                    tabSearch.ActiveTabIndex = 1;
                    SearchByCriterion(true);
                    txtSite.Text = string.Empty;
                }
                else if (Request.QueryString["FirstRoad"] !=null && Request.QueryString["SecondRoad"] !=null && Request.QueryString["Dir"] !=null && !IsPostBack)
                {
                    SetControls();
                    tabSearch.ActiveTabIndex = 0;
                    txtFirstRoad.Text = Request.QueryString["FirstRoad"];
                    txtSecondRoad.Text = Request.QueryString["SecondRoad"];
                    txtDir.Text = Request.QueryString["Dir"];
                    SearchByCriterion(false);
                }


                lblSite.Text = txtSite.Text;
                lblFirstRoad.Text = txtFirstRoad.Text;
                lblSecondRoad.Text = txtSecondRoad.Text;
                lblDir.Text = txtDir.Text;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        //Extra Text should empty or integer.
        private bool IsNumericOrEmpty(string Str)
        {
            if (Str == string.Empty)
                return true;
            else
            {
                int Num;
                bool isNum = int.TryParse(Str, out Num);
                return isNum;
            }
        }

        private bool CheckUserName()
        {

            return true;

            //string sUserName = System.Web.HttpContext.Current.User.Identity.Name.ToUpper().ToString().Replace(@"ROCKYVIEW\", "");

            //if (_proxy.GetUserNameByLogin(sUserName).Count() > 0)
            //{
                
            //    return true;
            //}
            //else
            //{
            //    lblResult.Text = "You do not have permission to upload the XML file.\n Please contact GIS department";
            //    return false;
            //}
                

        }

        private bool CheckTextBox()
        {
            bool bTextBox = true;
            if (txtFirstRoad.Text == string.Empty || txtSecondRoad.Text == string.Empty || txtDir.Text == string.Empty)
            {
                lblResult.Text = "Road Names and Direction are not specified \n Please Search first and try it";
                tabPnlUpload.Enabled = false;
                bTextBox = false;
            }
           

            if (!IsNumericOrEmpty(txtExtraNum.Text.Trim()))
            {
                lblResult.Text = "Extra Number is not numeric. \n Please Enter Integer Number";
                bTextBox = false;
            }

            return bTextBox;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            try
            {

                bool bImportUser = CheckUserName();
                //bool bImportUser = true;
                bool bImportTextBox = CheckTextBox();

                if (bImportUser == true && bImportTextBox == true)
                {
                    #region                
                    string filePath = string.Empty;
                    if (FileUploader.HasFile && FileUploader.FileName.ToUpper().Contains(".XML"))
                    {
                        filePath = @"\\mdrockyview.ab.ca\gis\Operations\TrafficCount\XML\" + FileUploader.FileName;
                        FileUploader.SaveAs(filePath);

                        lblResult.Text = ImportTrafficXML(filePath);

                        if (lblResult.Text.Contains("Successfully Imported XML file to Database"))
                        {                            
                            SearchByCriterion(false);
                            lblResult.Text = "Successfully Imported XML file to Database";
                        }                 

                    }
                    else
                    {
                        lblResult.Text = "No xml file is selected. Please check the file";
                    }
                    #endregion
                }
         





            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
                       
           

        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (tabSearch.ActiveTabIndex == 0)
            {
                SearchByCriterion(false);
            }
            else if (tabSearch.ActiveTabIndex == 1)
            {
                SearchByCriterion(true);
            }
                
        }

        public void SearchByCriterion(bool SiteOrLocation)
        {

            try
            {

                List<TCDTO> TCDTOs = new List<TCDTO>();
                int CNT = 0;
                
                #region //GridView Binding
                
                //Search By Site ID
                if (SiteOrLocation)
                {

                    if (_proxy.GetTCSummaryBySite(txtSite.Text).Count() > 0)
                    {
                        CNT = _proxy.GetTCSummaryBySite(txtSite.Text).Count();

                        TCDTOs = (from n in _proxy.GetTCSummaryBySite(txtSite.Text)
                                  select new TCDTO(n.Date, n.NumofVolume, n.Percentile85, n.PercentageTrucks)).ToList();

                        grvHistory.DataSource = _proxy.GetTCSummaryBySite(txtSite.Text);
                        grvHistory.DataBind();

                        pnlContent.Visible = true;
                        pnlGridView.Visible = true;                        

                        txtFirstRoad.Text = _proxy.GetTCSummaryBySite(txtSite.Text).FirstOrDefault().Road1;
                        txtSecondRoad.Text = _proxy.GetTCSummaryBySite(txtSite.Text).FirstOrDefault().Road2;
                        txtDir.Text = _proxy.GetTCSummaryBySite(txtSite.Text).FirstOrDefault().Dir;                
                        
                    }
                    else
                    {
                        pnlContent.Visible = false;
                        pnlGridView.Visible = false;                        
                    }
                }

                //Search by First Road, Seocond Road , and Direction
                else 
                {
                   

                    if (_proxy.GetTCSummaryByLoc(txtFirstRoad.Text, txtSecondRoad.Text, txtDir.Text).Count() > 0)
                    {
                        CNT = _proxy.GetTCSummaryByLoc(txtFirstRoad.Text, txtSecondRoad.Text, txtDir.Text).Count();

                        TCDTOs = (from n in _proxy.GetTCSummaryByLoc(txtFirstRoad.Text, txtSecondRoad.Text, txtDir.Text)
                                  select new TCDTO(n.Date, n.NumofVolume, n.Percentile85, n.PercentageTrucks)).ToList();

                        grvHistory.DataSource = _proxy.GetTCSummaryByLoc(txtFirstRoad.Text, txtSecondRoad.Text, txtDir.Text);
                        grvHistory.DataBind();

                        pnlContent.Visible = true;
                        pnlGridView.Visible = true;                       

                    }
                    else
                    {
                        pnlContent.Visible = false;
                        pnlGridView.Visible = false;                        
                    }
                }

                lblResult.Text = "There are " + CNT.ToString() + " Record(s) for this site";

                if (txtFirstRoad.Text == string.Empty || txtSecondRoad.Text == string.Empty || txtDir.Text == string.Empty)
                    tabPnlUpload.Enabled = false;
                else
                    //Only when FirstRoad, SeocondRoad, Direction are available, user can import xml file to DB.
                    tabPnlUpload.Enabled = true;

                #endregion

                #region //Chart Binding
                if (TCDTOs.Count() > 1)
                {
                    pnlChart.Visible = true;
                    //Consulted following web page
                    //http://www.4guysfromrolla.com/articles/072209-1.aspx
                    chTCVolume.Series["TrafficVolume"].XValueMember = "DateOfCalc";
                    chTCVolume.Series["TrafficVolume"].YValueMembers = "Volume";
                    chTCVolume.DataSource = TCDTOs;
                    chTCVolume.DataBind();

                    chTCPercentile.Series["TrafficPercentile85"].XValueMember = "DateOfCalc";
                    chTCPercentile.Series["TrafficPercentile85"].YValueMembers = "Percentile85";
                    chTCPercentile.DataSource = TCDTOs;
                    chTCPercentile.DataBind();

                }
                else
                {
                    pnlChart.Visible = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }        

        private string ImportTrafficXML(string file)
        {
            try
            {
                                
                TCInsert.TCInsertClient tcInsert = new TCInsert.TCInsertClient();

                XDocument xdoc = XDocument.Load(file);

                //Import Header
                var ds = xdoc.Descendants("Header").Descendants("Dataset").First();
                var pf = xdoc.Descendants("Header").Descendants("Profile").First();

                //Import Data
                var sStep = xdoc.Descendants("Data").Descendants("Step");
                var sTotal = xdoc.Descendants("Data").Descendants("Total");

                //Site ID
                string sSiteID = ds.Element("SiteName").Value ?? string.Empty;                   

                string sNorthOrEast = ds.Element("Direction").Value ?? string.Empty;
                string sLocation = ds.Element("Description").Value ?? string.Empty;
                //Import Location 

                if (sLocation.Contains("&"))
                    sLocation = sLocation == string.Empty ? string.Empty : sLocation.Substring(0, sLocation.IndexOf("&"));

                //Start and End Time
                DateTime dFilterStart = DateTime.Parse(pf.Element("FilterStart").Value);
                DateTime dFilterEnd = DateTime.Parse(pf.Element("FilterEnd").Value);
                TimeSpan ts =  dFilterEnd - dFilterStart;

                double hours = ts.TotalHours;

                if (txtExtraNum.Text != string.Empty)
                    sSiteID = sSiteID + "." + txtExtraNum.Text;

                bool bImportSiteID = true;

                if (_proxy.GetTCSummaryOneBySite(sSiteID).Count() > 0)
                {
                    bImportSiteID = false;
                    Response.Write( "Fail to import the XML file" + sSiteID + " has duplicate Site IDs. Please check " + sSiteID);
                    return "Fail to import the XML file. " + sSiteID + " has duplicate Site IDs. Please check " + sSiteID;

                }

                bool bImportMultiDays = true;
                if (ts.TotalHours > 24)
                {
                    bImportMultiDays = false;
                    //the dates are more than 1 days, it does not import the xml.
                    Response.Write("Fail to import the XML file. " + "The time gap between start and end time is more than 24 hours in the XML file. Please filter the time in the XML file");
                    return "Fail to import the XML file. " + "The time gap between start and end time is more than 24 hours in the XML file. Please filter the time in the XML file";
                    
                                     
                }

                if (bImportSiteID == true && bImportMultiDays == true)
                {
                    #region // if XML file has only single date, the code imports information


                    //PostedLimit
                    int iPostedTime = pf.Element("PostedLimit").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(pf.Element("PostedLimit").Value) ? pf.Element("PostedLimit").Value : "0");


                    //Extra Nubmer for the same site number
                    
                    #region //Data


                    foreach (var da in sStep)
                    {
                        
                        if (da.Element("F00") !=null)
                        {
                            string sTimeCaptured = da.Element("F00").Value ?? string.Empty;
                            string sLane = da.Element("F01").Value ?? string.Empty;
                            string sBound = Utility.returnBound(sNorthOrEast, sLane);

                            #region // Import AxlesDetails
                            int iMotorCycles = da.Element("F02").IsEmpty ? 0
                               : int.Parse(Information.IsNumeric(da.Element("F02").Value) ? da.Element("F02").Value : "0");
                            int iPassengerVehicle = da.Element("F03").IsEmpty ? 0
                               : int.Parse(Information.IsNumeric(da.Element("F03").Value) ? da.Element("F03").Value : "0");
                            int iTwoAxleFourTires = da.Element("F04").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F04").Value) ? da.Element("F04").Value : "0");
                            int iBuses = da.Element("F05").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F05").Value) ? da.Element("F05").Value : "0");
                            int iTwoAxleSixTires = da.Element("F06").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F06").Value) ? da.Element("F06").Value : "0");
                            int iThreeAxleSingleUnitTruck = da.Element("F07").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F07").Value) ? da.Element("F07").Value : "0");
                            int iFourOrMoreAxleSignleUnitTruck = da.Element("F08").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F08").Value) ? da.Element("F08").Value : "0");
                            int iFourOrLessAxleSingleTrailerTruck = da.Element("F09").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F09").Value) ? da.Element("F09").Value : "0");
                            int iFiveAxleSignleTrailerTruck = da.Element("F10").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F10").Value) ? da.Element("F10").Value : "0");
                            int iSixOrMoreAxleSignleTrailerTruck = da.Element("F11").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F11").Value) ? da.Element("F11").Value : "0");
                            int iFiveLessAxleMultiTrailerTruck = da.Element("F12").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F12").Value) ? da.Element("F12").Value : "0");
                            int iSixAxleMultiTrailerTruck = da.Element("F13").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F13").Value) ? da.Element("F13").Value : "0");
                            int iSevenMoreAxleMultiTrailerTruck = da.Element("F14").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F14").Value) ? da.Element("F14").Value : "0");

                            double iSpMean = da.Element("F36").IsEmpty ? 0
                                : double.Parse(Information.IsNumeric(da.Element("F36").Value) ? da.Element("F36").Value : "0");
                            double iVpp85 = da.Element("F37").IsEmpty ? 0
                                : double.Parse(Information.IsNumeric(da.Element("F37").Value) ? da.Element("F37").Value : "0");



                            tcInsert.InsertTCAxlesDetails(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured, sLocation,
                                                          iMotorCycles, iPassengerVehicle, iTwoAxleFourTires, iBuses, iTwoAxleSixTires,
                                                          iThreeAxleSingleUnitTruck, iFourOrMoreAxleSignleUnitTruck, iFourOrLessAxleSingleTrailerTruck,
                                                          iFiveAxleSignleTrailerTruck, iSixOrMoreAxleSignleTrailerTruck, iFiveLessAxleMultiTrailerTruck,
                                                          iSixAxleMultiTrailerTruck, iSevenMoreAxleMultiTrailerTruck, iSpMean, iVpp85);
                            #endregion

                            #region //Import SpeedDetails
                            int iSP0To10 = da.Element("F15").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F15").Value) ? da.Element("F15").Value : "0");
                            int iSP10To20 = da.Element("F16").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F16").Value) ? da.Element("F16").Value : "0");
                            int iSP20To30 = da.Element("F17").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F17").Value) ? da.Element("F17").Value : "0");
                            int iSP30To40 = da.Element("F18").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F18").Value) ? da.Element("F18").Value : "0");
                            int iSP40To50 = da.Element("F19").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F19").Value) ? da.Element("F19").Value : "0");
                            int iSP50To60 = da.Element("F20").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F20").Value) ? da.Element("F20").Value : "0");
                            int iSP60To70 = da.Element("F21").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F21").Value) ? da.Element("F21").Value : "0");
                            int iSP70To80 = da.Element("F22").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F22").Value) ? da.Element("F22").Value : "0");
                            int iSP80To90 = da.Element("F23").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F23").Value) ? da.Element("F23").Value : "0");
                            int iSP90To100 = da.Element("F24").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F24").Value) ? da.Element("F24").Value : "0");
                            int iSP100To110 = da.Element("F25").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F25").Value) ? da.Element("F25").Value : "0");
                            int iSP110To120 = da.Element("F26").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F26").Value) ? da.Element("F26").Value : "0");
                            int iSP120To130 = da.Element("F27").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F27").Value) ? da.Element("F27").Value : "0");
                            int iSP130To140 = da.Element("F28").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F28").Value) ? da.Element("F28").Value : "0");
                            int iSP140To150 = da.Element("F29").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F29").Value) ? da.Element("F29").Value : "0");
                            int iSP150To160 = da.Element("F30").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F30").Value) ? da.Element("F30").Value : "0");
                            int iSP160To170 = da.Element("F31").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F31").Value) ? da.Element("F31").Value : "0");
                            int iSP170To180 = da.Element("F32").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F32").Value) ? da.Element("F32").Value : "0");
                            int iSP180To190 = da.Element("F33").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F33").Value) ? da.Element("F33").Value : "0");
                            int iSP190To200 = da.Element("F34").IsEmpty ? 0
                                : int.Parse(Information.IsNumeric(da.Element("F34").Value) ? da.Element("F34").Value : "0");


                            int iSP160To200 = iSP160To170 + iSP170To180 + iSP180To190 + iSP190To200;


                            tcInsert.InsertTCSpeedDetails(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured, sLocation,
                                                            iSP0To10, iSP10To20, iSP20To30, iSP30To40, iSP40To50, iSP50To60, iSP60To70,
                                                            iSP70To80, iSP80To90, iSP90To100, iSP100To110, iSP110To120, iSP120To130, iSP130To140,
                                                            iSP140To150, iSP150To160, iSP160To200, iSpMean, iVpp85);
                            #endregion
                        }





                    }

                    #endregion

                    #region //Total

                    int iTotal = 0;
                    int iTruckCount = 0;
                    double dTruckPercentage = 0.0;
                    double dPercentage85 = 0.0;

                    foreach (var dt in sTotal)
                    {
                        string sTimeCaptured = dt.Element("F00").Value ?? string.Empty;
                        sTimeCaptured = sTimeCaptured.Contains("--") ? "All Time" : sTimeCaptured;

                        string sLane = dt.Element("F01").Value ?? string.Empty;
                        sLane = sLane.Contains("-") ? "AB" : sLane;

                        string sBound = Utility.returnBound(sNorthOrEast, sLane);

                        #region //Import AxlesSummary
                        int iMotorCycles = dt.Element("F02").IsEmpty ? 0
                           : int.Parse(Information.IsNumeric(dt.Element("F02").Value) ? dt.Element("F02").Value : "0");
                        int iPassengerVehicle = dt.Element("F03").IsEmpty ? 0
                           : int.Parse(Information.IsNumeric(dt.Element("F03").Value) ? dt.Element("F03").Value : "0");
                        int iTwoAxleFourTires = dt.Element("F04").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F04").Value) ? dt.Element("F04").Value : "0");
                        int iBuses = dt.Element("F05").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F05").Value) ? dt.Element("F05").Value : "0");
                        int iTwoAxleSixTires = dt.Element("F06").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F06").Value) ? dt.Element("F06").Value : "0");
                        int iThreeAxleSingleUnitTruck = dt.Element("F07").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F07").Value) ? dt.Element("F07").Value : "0");
                        int iFourOrMoreAxleSignleUnitTruck = dt.Element("F08").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F08").Value) ? dt.Element("F08").Value : "0");
                        int iFourOrLessAxleSingleTrailerTruck = dt.Element("F09").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F09").Value) ? dt.Element("F09").Value : "0");
                        int iFiveAxleSignleTrailerTruck = dt.Element("F10").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F10").Value) ? dt.Element("F10").Value : "0");
                        int iSixOrMoreAxleSignleTrailerTruck = dt.Element("F11").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F11").Value) ? dt.Element("F11").Value : "0");
                        int iFiveLessAxleMultiTrailerTruck = dt.Element("F12").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F12").Value) ? dt.Element("F12").Value : "0");
                        int iSixAxleMultiTrailerTruck = dt.Element("F13").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F13").Value) ? dt.Element("F13").Value : "0");
                        int iSevenMoreAxleMultiTrailerTruck = dt.Element("F14").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F14").Value) ? dt.Element("F14").Value : "0");

                        double iSpMean = dt.Element("F36").IsEmpty ? 0
                            : double.Parse(Information.IsNumeric(dt.Element("F36").Value) ? dt.Element("F36").Value : "0");
                        double iVpp85 = dt.Element("F37").IsEmpty ? 0
                            : double.Parse(Information.IsNumeric(dt.Element("F37").Value) ? dt.Element("F37").Value : "0");
                        int iTotalNum = dt.Element("F35").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F35").Value) ? dt.Element("F35").Value : "0");


                        tcInsert.InsertTCAxlesSummary(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured,
                                                      sLocation, iMotorCycles, iPassengerVehicle, iTwoAxleFourTires, iBuses,
                                                      iTwoAxleSixTires, iThreeAxleSingleUnitTruck, iFourOrMoreAxleSignleUnitTruck,
                                                      iFourOrLessAxleSingleTrailerTruck, iFiveAxleSignleTrailerTruck, iSixOrMoreAxleSignleTrailerTruck,
                                                      iFiveLessAxleMultiTrailerTruck, iSixAxleMultiTrailerTruck, iSevenMoreAxleMultiTrailerTruck, iSpMean, iVpp85);
                        #endregion

                        #region //Import SpeedSummary
                        int iSP0To10 = dt.Element("F15").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F15").Value) ? dt.Element("F15").Value : "0");
                        int iSP10To20 = dt.Element("F16").IsEmpty ? 0
                           : int.Parse(Information.IsNumeric(dt.Element("F16").Value) ? dt.Element("F16").Value : "0");
                        int iSP20To30 = dt.Element("F17").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F17").Value) ? dt.Element("F17").Value : "0");
                        int iSP30To40 = dt.Element("F18").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F18").Value) ? dt.Element("F18").Value : "0");
                        int iSP40To50 = dt.Element("F19").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F19").Value) ? dt.Element("F19").Value : "0");
                        int iSP50To60 = dt.Element("F20").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F20").Value) ? dt.Element("F20").Value : "0");
                        int iSP60To70 = dt.Element("F21").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F21").Value) ? dt.Element("F21").Value : "0");
                        int iSP70To80 = dt.Element("F22").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F22").Value) ? dt.Element("F22").Value : "0");
                        int iSP80To90 = dt.Element("F23").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F23").Value) ? dt.Element("F23").Value : "0");
                        int iSP90To100 = dt.Element("F24").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F24").Value) ? dt.Element("F24").Value : "0");
                        int iSP100To110 = dt.Element("F25").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F25").Value) ? dt.Element("F25").Value : "0");
                        int iSP110To120 = dt.Element("F26").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F26").Value) ? dt.Element("F26").Value : "0");
                        int iSP120To130 = dt.Element("F27").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F27").Value) ? dt.Element("F27").Value : "0");
                        int iSP130To140 = dt.Element("F28").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F28").Value) ? dt.Element("F28").Value : "0");
                        int iSP140To150 = dt.Element("F29").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F29").Value) ? dt.Element("F29").Value : "0");
                        int iSP150To160 = dt.Element("F30").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F30").Value) ? dt.Element("F30").Value : "0");
                        int iSP160To170 = dt.Element("F31").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F31").Value) ? dt.Element("F31").Value : "0");
                        int iSP170To180 = dt.Element("F32").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F32").Value) ? dt.Element("F32").Value : "0");
                        int iSP180To190 = dt.Element("F33").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F33").Value) ? dt.Element("F33").Value : "0");
                        int iSP190To200 = dt.Element("F34").IsEmpty ? 0
                            : int.Parse(Information.IsNumeric(dt.Element("F34").Value) ? dt.Element("F34").Value : "0");


                        int iSP160To200 = iSP160To170 + iSP170To180 + iSP180To190 + iSP190To200;


                        tcInsert.InsertTCSpeedSummary(sSiteID, sLane, sBound, dFilterStart, dFilterEnd, sTimeCaptured,
                                                      sLocation, iSP0To10, iSP10To20, iSP20To30, iSP30To40, iSP40To50, iSP50To60,
                                                      iSP60To70, iSP70To80, iSP80To90, iSP90To100, iSP100To110, iSP110To120, iSP120To130,
                                                      iSP130To140, iSP140To150, iSP150To160, iSP160To200, iSpMean, iVpp85);

                        #endregion

                        #region //Calculate Total
                        if (sTimeCaptured == "All Time")
                        {
                            iTotal += iTotalNum;

                            iTruckCount +=
                            (iTwoAxleSixTires + iThreeAxleSingleUnitTruck + iFourOrMoreAxleSignleUnitTruck
                             + iFourOrLessAxleSingleTrailerTruck + iFiveAxleSignleTrailerTruck + iSixOrMoreAxleSignleTrailerTruck +
                             iFiveLessAxleMultiTrailerTruck + iSixAxleMultiTrailerTruck + iSevenMoreAxleMultiTrailerTruck);

                            dPercentage85 += (iTotalNum * iVpp85);

                        }
                        #endregion


                    }
                    #endregion

                    #region //Calculate Summarized data
                    dPercentage85 = Math.Round(dPercentage85 / (double)iTotal);
                    dTruckPercentage = Math.Round(((double)iTruckCount / (double)iTotal * 100));
                    tcInsert.InsertTCSummary(sSiteID, 0, sLocation, dFilterStart, iTotal, iPostedTime.ToString() + "KM/H",
                                             dPercentage85.ToString(), dTruckPercentage.ToString()
                                            , txtFirstRoad.Text, txtSecondRoad.Text, txtDir.Text, _InsertedBy);

                    #endregion

                    Response.Write("Successfully Imported XML file to Database");
                    return "Successfully Imported XML file to Database";
                    


                    #endregion //

                }
                else
                {
                    return "Fail to Import XML. Please check your XML file structure";
                }
                    

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                
                return "Fail to Import XML. Please check your XML file structure";

            }
        }

        protected void tabSearch_ActiveTabChanged(object sender, System.EventArgs e)
        {

            try
            {

                //if (tabSearch.ActiveTabIndex == 2)
                //    btnSearch.Enabled = false;
                //else
                //    btnSearch.Enabled = true;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void txtFirstRoad_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                acSecondRoad.ContextKey = txtFirstRoad.Text;
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

    }
}