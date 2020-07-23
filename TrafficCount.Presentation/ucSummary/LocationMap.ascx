
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocationMap.ascx.cs" Inherits="TrafficCount.Presentation.ucSummary.LocationMap" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">



  
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
<title></title>
<link rel="stylesheet" href="http://localhost/TC/CSS/esri.css">


<script type="text/javascript" src="http://js.arcgis.com/3.7/"></script>



     <script type="text/C#" runat="server">      

         string sSiteID = string.Empty;
         string sX = string.Empty;
         string sY = string.Empty;
         protected void Page_Load(object sender, EventArgs e)
         {
             try
             {
                 TrafficCount.Presentation.ucSummary.BasicInfo basicInfo = (TrafficCount.Presentation.ucSummary.BasicInfo)Page.FindControl("BasicInfo1");
                 sSiteID = ((TextBox)basicInfo.FindControl("txtSiteID")).Text;
             }
             catch (Exception ex)
             {
                 Response.Write(ex.ToString());
             }
             
         }

         protected void Page_Prerender(object sender, EventArgs e)
         {
             try
             {

                 if (Request.QueryString["Site"] != null && !IsPostBack && sSiteID == string.Empty)
                 {
                     
                     sSiteID = Request.QueryString["Site"];
                     
                 }

                 if (sSiteID != string.Empty)
                     FindLocationBySite(sSiteID);

             }
             catch (Exception ex)
             {
                 Response.Write(ex.ToString());
             }
         }
         
         
         //
         public void FindLocationBySite(string siteID)
         {
             try
             {

                 string sLocation = string.Empty;

                 using (TrafficCount.Presentation.TCService.TCSummaryClient TC = new TrafficCount.Presentation.TCService.TCSummaryClient())
                 {
                     sLocation = TC.GetXYBySite(siteID);
                 }

                 if (!(sLocation == string.Empty || sLocation == null))
                 {

                     sX = sLocation.Substring(0, sLocation.IndexOf(",") - 1).Trim();
                     sY = sLocation.Substring(sLocation.IndexOf(",") + 1, sLocation.Length - (sLocation.IndexOf(",") + 1)).Trim();

                     //string sFunction = "ZoomToSensor(" + sX + "," + sY + ")";
                     //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", sFunction, true);

                 }
             }
             catch (Exception ex)
             {
                 Response.Write(ex.ToString());
             }

         }
      
        
    </script>

    <script type="text/javascript" >
        var Xpoint = '<%= sX %>'
        var Ypoint = '<%= sY %>'
        require(["esri/map", "esri/layers/ArcGISTiledMapServiceLayer", "esri/layers/ArcGISDynamicMapServiceLayer", "esri/geometry/Point",
                 "esri/SpatialReference", "dojo/dom", "dojo/domReady!"],

        function (Map, Tiled, Dyanmic, Point, SpatialReference, dom) {
            var Map = new Map("map");

            var Aerials = new Tiled("http://gws.mdrockyview.ab.ca/arcgis/rest/services/Aerials/Aerials2012/MapServer");
            var Roadnet = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Transportation/Roads/MapServer");
            var BaseMap = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/BaseMaps/BaseMapElements/MapServer");

            //Dyanmic Map
            var Sensors = new Dyanmic("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Transportation/TrafficCountSensors/MapServer");

            Map.addLayers([Aerials, Roadnet, Sensors]);
            //dom.byId("checkRubberBandZoom").value = map.isRubberBandZoom;


            if (Xpoint && Ypoint) {
                ZoomToSensorT(Xpoint, Ypoint);
            }
            

            function ZoomToSensorT(ZoomX, ZoomY) {

                var pt = new Point(ZoomX, ZoomY, new SpatialReference({ wkid: 3776 }));
                Map.centerAndZoom(pt, 3);

            }



        });


        
    
    
    </script>


<script type="text/javascript">
    function ZoomToSensor(ZoomX, ZoomY) {

        require(["esri/map", "esri/layers/ArcGISTiledMapServiceLayer", "esri/layers/ArcGISDynamicMapServiceLayer", "esri/geometry/Point",
                 "esri/SpatialReference", "dojo/dom", "dojo/domReady!"],
            function (Map, Tiled, Dyanmic, Point, SpatialReference, dom) {
                var Map = new Map("map");

                var Aerials = new Tiled("http://gws.mdrockyview.ab.ca/arcgis/rest/services/Aerials/Aerials2012/MapServer");
                var Roadnet = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Transportation/Roads/MapServer");
                var BaseMap = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/BaseMaps/BaseMapElements/MapServer");

                //Dyanmic Map
                var Sensors = new Dyanmic("http://localhost:6080/arcgis/rest/services/Transportation/TrafficCountSensor/MapServer");

                Map.addLayers([Aerials, Roadnet, Sensors]);
                //dom.byId("checkRubberBandZoom").value = map.isRubberBandZoom;          

                var pt = new Point(ZoomX, ZoomY, new SpatialReference({ wkid: 3776 }));
                Map.centerAndZoom(pt, 3);

            });


    }
        
</script>

</head>

<body style="height:100%;">
    
    <div style="width:750px;Height:400px;" align="center" id="map" >        
        
    </div>
    
</body>

