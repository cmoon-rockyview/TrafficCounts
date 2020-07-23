using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficCount.Presentation.DTO;
using TrafficCount.Presentation.ucSummary;


namespace TrafficCount.Presentation.ucSummary
{
    public partial class BasicInfo : System.Web.UI.UserControl
    {
        TCService.TCSummaryClient _proxy = new TCService.TCSummaryClient();

        //Pages to bind data
        AxlesInfo axlesInfo;
        SpeedInfo speedInfo;

        AxlesDetailed axlesDetailed;
        SpeedDetailed speedDetailed;
        LocationMap locationMap;

       

        private GridView grvAxles;
        private GridView grvSpeed;

        private GridView grvAxlesDetailed;
        private GridView grvSpeedDetailed;

        private Panel pnlInfo;

        private void SetControls()
        {
            try
            {

                axlesInfo = (AxlesInfo)Page.FindControl("AxlesInfo1");
                speedInfo = (SpeedInfo)Page.FindControl("SpeedInfo1");

                axlesDetailed = (AxlesDetailed)Page.FindControl("AxlesDetailed1");
                speedDetailed = (SpeedDetailed)Page.FindControl("SpeedDetailed1");

                locationMap = new LocationMap();

                grvAxles = (GridView)axlesInfo.FindControl("grvAxles");
                grvSpeed = (GridView)speedInfo.FindControl("grvSpeed");

                grvAxlesDetailed = (GridView)axlesDetailed.FindControl("grvAxlesDetailed");
                grvSpeedDetailed = (GridView)speedDetailed.FindControl("grvSpeedDetailed");

                pnlInfo = (Panel)Page.FindControl("pnlInfo");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {          
            SetControls();            
        }
        protected void Page_Prerender(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["Site"] != null && !IsPostBack)
                {
                    SetControls();
                    txtSiteID.Text = Request.QueryString["Site"];
                    RunQuery();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


        protected void btnSiteID_Click(object sender, EventArgs e)
        {            
            RunQuery();           
        }

        
        private void RunQuery()
        {
            try
            {
                var TCSum1 = _proxy.GetTCSummaryOneBySite(txtSiteID.Text).FirstOrDefault();
                string site = string.Empty;

                if (TCSum1 != null)
                {
                    site = TCSum1.SiteID;
                    lblLocation.Text = "Location : " + TCSum1.Location;
                    lblDate.Text = "Date : " + TCSum1.Date;
                    lblLegalDesc.Text = "(Legal: " + TCSum1.LegalDesc + ")";
                    lblLengthOfCount.Text = "Length of Count: " + "24 HR";
                    lblTwp.Text = TCSum1.TWP.ToString();
                    lblPostedSpeed.Text = "Posted Speed : " + TCSum1.PostedLimit;

                    lblTotalTrafficVolume.Text = "Grand Toal : " + TCSum1.NumofVolume.ToString();
                    lblPercentile85.Text = "85 Percentile : " + TCSum1.Percentile85 + " KM/H";
                    lblTruckPercentage.Text = "Truck Percentage : " + TCSum1.PercentageTrucks + " %";
                    hlkHistory.NavigateUrl = TCSum1.LinkToHistory;                    

                    SearchAxlesBySiteID(txtSiteID.Text);

                    SearchSpeedBySiteID(txtSiteID.Text);                    

                    SearchDetailedBySiteID(txtSiteID.Text, DateTime.Parse(TCSum1.Date));

                }
                else
                {
                    lblLocation.Text = "There is no information by the Site Number";
                    lblLegalDesc.Text = string.Empty;

                    pnlBasicInfo.Visible = false;
                    pnlInfo.Visible = false;
                }                        


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            
            
        }

                  

        private void SearchDetailedBySiteID(string SiteID ,DateTime dateCaputred)
        {
            try
            {
                //Ininitialize Gridview
                grvAxlesDetailed.DataSource = null;
                grvAxlesDetailed.DataBind();

                grvAxlesDetailed.DataSource = _proxy.GetTCAxlesDetailsBySite(SiteID, dateCaputred).Distinct();
                grvAxlesDetailed.DataBind();

                //Ininitialize Gridview
                grvSpeedDetailed.DataSource = null;
                grvSpeedDetailed.DataBind();

                grvSpeedDetailed.DataSource = _proxy.GetTCSpeedDetailsBySite(SiteID, dateCaputred).Distinct();
                grvSpeedDetailed.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }


        }

        private void SearchAxlesBySiteID(string SiteID)
        {

            try
            {

                pnlBasicInfo.Visible = true;
                pnlInfo.Visible = true;

                //Intitialize the Gridview
                grvAxles.DataSource = null;
                grvAxles.DataBind();


                //Set Axles 
                #region
                var axleLane1s = _proxy.GetTCAxlesSummaryBySite(SiteID)
                                       .Where(s => s.Lane.Contains("AB") || s.Lane.ToUpper() == "P" 
                                              && s.TimeCaptured.Contains("All Time") );
                var axleLane2s = _proxy.GetTCAxlesSummaryBySite(txtSiteID.Text)
                                       .Where(s => s.Lane.Contains("BA") || s.Lane.ToUpper() == "S"
                                              && s.TimeCaptured.Contains("All Time"));

                

                if (axleLane1s.Count() > 0 && axleLane2s.Count() > 0)
                {


                    pnlBasicInfo.Visible = true;
                    pnlInfo.Visible = true;

                    var axleLane1 = axleLane1s.FirstOrDefault();
                    var axleLane2 = axleLane2s.FirstOrDefault();

                    
                    lblLaneA.Text = "Lane-A : " + axleLane1.Bound;
                    lblLaneB.Text = "Lane-B : " + axleLane2.Bound;
                    

                    List<TCAxlesDTO> TCAxlesInfoList = new List<TCAxlesDTO>();

                    int[] iAxlesLanes1 = { axleLane1.MotorCycles.Value, axleLane1.PassengerCars.Value, axleLane1.TwoAxleFourTires.Value, axleLane1.Buses.Value,axleLane1.TwoAxleSixTires.Value
                                           ,axleLane1.ThreeAxleSingleUnitTruck.Value, axleLane1.FourOrMoreAxleSignleUnitTruck.Value, axleLane1.FourOrLessAxleSingleTrailerTruck.Value
                                           ,axleLane1.FiveAxleSignleTrailerTruck.Value, axleLane1.SixAxleMultiTrailerTruck.Value, axleLane1.SixOrMoreAxleSignleTrailerTruck.Value, axleLane1.FiveLessAxleMultiTrailerTruck.Value
                                           ,axleLane1.SixAxleMultiTrailerTruck.Value, axleLane1.SevenMoreAxleMultiTrailerTruck.Value
                                  };
                    int[] iAxlesLanes2 = {axleLane2.MotorCycles.Value, axleLane2.PassengerCars.Value, axleLane2.TwoAxleFourTires.Value, axleLane2.Buses.Value 
                                          ,axleLane2.TwoAxleSixTires.Value, axleLane2.ThreeAxleSingleUnitTruck.Value, axleLane2.FourOrMoreAxleSignleUnitTruck.Value, axleLane2.FourOrLessAxleSingleTrailerTruck.Value
                                          ,axleLane2.FiveAxleSignleTrailerTruck.Value, axleLane2.SixAxleMultiTrailerTruck.Value, axleLane2.SixOrMoreAxleSignleTrailerTruck.Value, axleLane2.FiveLessAxleMultiTrailerTruck.Value
                                          ,axleLane2.SixAxleMultiTrailerTruck.Value, axleLane2.SevenMoreAxleMultiTrailerTruck.Value
                                  };

                    string[] strAxles = {"(1) MOTORCYCLES", "(2) PASSENGER CARS" , "(3) 2 AXLE 4 TIRES" , "(4) BUSES", "(5) 2 AXLE 6 TIRES", 
                                 "(6) 3 AXLE SINGLE UNIT TRUCK", "(7) 4 OR MORE AXLE SINGLE UNIT TRUCK", "(8) 4 OR LESS AXLE SINGLE TRAILER TRUCK",
                                 "(9) 5 AXLE SINGLE TRAILER TRUCK", "(10) 6 OR MORE AXLE SINGLE TRAILER TRUCK", "(11) 5 / LESS AXLE MULTI TRAILER TRUCK",
                                 "(12) 6 AXLE MULTI TRAILER TRUCK", "(13) 7 / MORE AXLE MULTI TRAILER TRUCK"};


                    for (int i = 0; i < strAxles.Length; i++)
                    {
                        TCAxlesInfoList.Add(new TCAxlesDTO
                        (
                            strAxles[i],
                            iAxlesLanes1[i],
                            iAxlesLanes2[i]

                        )

                        );

                    }

                                        
                    grvAxles.DataSource = TCAxlesInfoList;
                    grvAxles.DataBind();

                    


                }
                #endregion

            }

            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private void SearchSpeedBySiteID(string SiteID)
        {
            try
            {

                //Initialize the Gridview
                grvSpeed.DataSource = null;
                grvSpeed.DataBind();

                var speedLane1s = _proxy.GetTCSpeedSummaryBySite(SiteID)
                                        .Where(s => s.Lane.Contains("AB") || s.Lane.ToUpper() == "P"
                                               && s.TimeCaptured.Contains("All Time"));
                var speedLane2s = _proxy.GetTCSpeedSummaryBySite(SiteID)
                                        .Where(s => s.Lane.Contains("BA") || s.Lane.ToUpper() == "S"
                                               && s.TimeCaptured.Contains("All Time"));

                if (speedLane1s.Count() > 0 && speedLane2s.Count() > 0)
                {
                    var speedLane1 = speedLane1s.FirstOrDefault();
                    var speedLane2 = speedLane2s.FirstOrDefault();

                    List<TCSpeedDTO> TCSpeedDTOs = new List<TCSpeedDTO>();

                    string[] strSpeed = { "0-10", "10-20", "20-30", "30-40", "40-50", "50-60", "60-70", "70-80", "80-90", "90-100", 
                                      "100-110", "110-120", "120-130", "130-140", "140-150", "150-160", "160-200" , "Total" };

                    int?[] iSpeedLanes1 = { speedLane1.Sp0To10.Value, speedLane1.Sp10To20.Value, speedLane1.Sp20To30.Value, speedLane1.Sp30To40.Value, 
                                      speedLane1.Sp40To50.Value, speedLane1.Sp50To60.Value, speedLane1.Sp60To70.Value, speedLane1.Sp70To80.Value,
                                      speedLane1.Sp80To90.Value,speedLane1.Sp90To100.Value,speedLane1.Sp100To110.Value,speedLane1.Sp110To120.Value,
                                      speedLane1.Sp120To130.Value,speedLane1.Sp130To140.Value,speedLane1.Sp140To150.Value, speedLane1.Sp150To160.Value,
                                      speedLane1.Sp160To200.Value , speedLane1.Total};

                    int?[] iSpeedLanes2 = {speedLane2.Sp0To10.Value, speedLane2.Sp10To20.Value, speedLane2.Sp20To30.Value, speedLane2.Sp30To40.Value, 
                                      speedLane2.Sp40To50.Value, speedLane2.Sp50To60.Value, speedLane2.Sp60To70.Value, speedLane2.Sp70To80.Value,
                                      speedLane2.Sp80To90.Value,speedLane2.Sp90To100.Value,speedLane2.Sp100To110.Value,speedLane2.Sp110To120.Value,
                                      speedLane2.Sp120To130.Value,speedLane2.Sp130To140.Value,speedLane2.Sp140To150.Value,speedLane2.Sp150To160.Value,
                                      speedLane2.Sp160To200.Value, speedLane2.Total };


                    for (int i = 0; i < strSpeed.Length; i++)
                    {
                        TCSpeedDTOs.Add(new TCSpeedDTO(strSpeed[i], iSpeedLanes1[i], iSpeedLanes2[i]));
                    }

            

                    grvSpeed.DataSource = TCSpeedDTOs;
                    grvSpeed.DataBind();

                    
                    

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }




        }

    }
}