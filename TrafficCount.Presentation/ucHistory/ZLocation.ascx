<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZLocation.ascx.cs" Inherits="TrafficCount.Presentation.ucHistory.ZLocation" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
  
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="initial-scale=1, maximum-scale=1, user-scalable=no">
<title></title>
<link href="http://localhost/TC/css/Location.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="http://localhost/TC/CSS/esri.css">



<script type="text/javascript" src="http://js.arcgis.com/3.7/"></script>

    <script type="text/C#" runat="server">      

         string sSiteID = string.Empty;

         string sFirstRoad = string.Empty;
         string sSecondRoad = string.Empty;
         string sDir = string.Empty;
         
         
         string sX = string.Empty;
         string sY = string.Empty;
         protected void Page_Load(object sender, EventArgs e)
         {
             try
             {
         
                 
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

                 TrafficCount.Presentation.ucHistory.SearchWidget searchWidget = (TrafficCount.Presentation.ucHistory.SearchWidget)Page.FindControl("SearchWidget1");

                 sSiteID = ((Label)searchWidget.FindControl("lblSite")).Text;
                 sFirstRoad = ((Label)searchWidget.FindControl("lblFirstRoad")).Text;
                 sSecondRoad = ((Label)searchWidget.FindControl("lblSecondRoad")).Text;
                 sDir = ((Label)searchWidget.FindControl("lblDir")).Text;                         

              

                 if (sSiteID != string.Empty)
                     FindLocationBySite(sSiteID);
                 else if (sFirstRoad != string.Empty && sSecondRoad != string.Empty && sDir != string.Empty)
                     FindLocationByRoads(sFirstRoad, sSecondRoad, sDir);
                 

             }
             catch (Exception ex)
             {
                 Response.Write(ex.ToString());
             }
         }


         public void FindLocationByRoads(string firstRoad, string secondRoad, string dir)
         {
             try
             {

                 string sLocation = string.Empty;

                 using (TrafficCount.Presentation.TCService.TCSummaryClient TC = new TrafficCount.Presentation.TCService.TCSummaryClient())
                 {
                     sLocation = TC.GetXY(firstRoad, secondRoad, dir);
                 }

                 if (sLocation != null)
                 {

                     sX = sLocation.Substring(0, sLocation.IndexOf(",") - 1).Trim();
                     sY = sLocation.Substring(sLocation.IndexOf(",") + 1, sLocation.Length - (sLocation.IndexOf(",") + 1)).Trim();      
                     

                 }
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

                 if (!(sLocation == string.Empty && sLocation == null))
                 {

                     sX = sLocation.Substring(0, sLocation.IndexOf(",") - 1).Trim();
                     sY = sLocation.Substring(sLocation.IndexOf(",") + 1, sLocation.Length - (sLocation.IndexOf(",") + 1)).Trim();        

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

            var Aerials = new Tiled("http://gws.mdrockyview.ab.ca/arcgis/rest/services/Aerials/Aerials2016/MapServer");
            var Roadnet = new Tiled("http://GISMO.mdrockyview.ab.ca/arcgis/rest/services/Transportation/Roads/MapServer");
            var BaseMap = new Tiled("http://GISMO.mdrockyview.ab.ca/arcgis/rest/services/BaseMaps/BaseMapElements/MapServer");

            //Dyanmic Map
            var Sensors = new Dyanmic("http://GISMO.mdrockyview.ab.ca/arcgis/rest/services/Transportation/TrafficCountSensors/MapServer");

            Map.addLayers([Aerials, Roadnet, Sensors]);
            //dom.byId("checkRubberBandZoom").value = map.isRubberBandZoom;

//            Map.autoResize = true;
//            Map.isKeyboardNavigation;
//            Map.isRubberBandZoom = true;
//            Map.enableRubberBandZoom();


            if (Xpoint && Ypoint) {
                ZoomToSensorT(Xpoint, Ypoint);
            }


            function ZoomToSensorT(ZoomX, ZoomY) {

                var pt = new Point(ZoomX, ZoomY, new SpatialReference({ wkid: 3776 }));
                Map.centerAndZoom(pt, 3);

            }



        }); 
    
    </script>

</head>

<body > 
    <div  id="map" style="width:800px;Height:600px">
    </div>
</body>
