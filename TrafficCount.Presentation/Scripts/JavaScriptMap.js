﻿var Map;


require(["esri/map", "esri/layers/ArcGISTiledMapServiceLayer", "esri/layers/ArcGISDynamicMapServiceLayer", "esri/geometry/Point",
                 "esri/SpatialReference", "dojo/dom", "dojo/domReady!"],
        function (Map, Tiled, Dyanmic, Point, SpatialReference, dom) {
            Map = new Map("map");

            var Aerials = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Aerials/Aerials2012/MapServer");
            var Roadnet = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Transportation/Roads/MapServer");
            var BaseMap = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/BaseMaps/BaseMapElements/MapServer");

            //Dyanmic Map
            var Sensors = new Dyanmic("http://localhost:6080/arcgis/rest/services/Transportation/TrafficCountSensor/MapServer");

            Map.addLayers([Aerials, Roadnet, Sensors]);
            //dom.byId("checkRubberBandZoom").value = map.isRubberBandZoom;

                      

            //ZoomToSensor("-14806.104500000365, 5691710.8411");


            function ZoomToSensor(Zoom) {
                        
                var pt = new Point(Zoom, new SpatialReference({ wkid: 3776 }));
                Map.centerAndZoom(pt, 3);               

            }



        });



//      var map, dialog;
//      require([
//        "esri/map", "esri/layers/FeatureLayer",
//        "esri/symbols/SimpleFillSymbol", "esri/symbols/SimpleLineSymbol", 
//        "esri/renderers/SimpleRenderer", "esri/graphic", "esri/lang",
//        "dojo/_base/Color", "dojo/number", "dojo/dom-style", 
//        "dijit/TooltipDialog", "dijit/popup", "dojo/domReady!"
//      ], function(
//        Map, FeatureLayer,
//        SimpleFillSymbol, SimpleLineSymbol,
//        SimpleRenderer, Graphic, esriLang,
//        Color, number, domStyle, 
//        TooltipDialog, dijitPopup
//      ) {
//        map = new Map("mapDiv", {
//          basemap: "streets",
//          center: [-80.94, 33.646],
//          zoom: 8,
//          slider: false
//        });
//        
//        var southCarolinaCounties = new FeatureLayer("http://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/3", {
//          mode: FeatureLayer.MODE_SNAPSHOT,
//          outFields: ["NAME", "POP2000", "POP2007", "POP00_SQMI", "POP07_SQMI"]
//        });
//        southCarolinaCounties.setDefinitionExpression("STATE_NAME = 'South Carolina'");

//        var symbol = new SimpleFillSymbol(
//          SimpleFillSymbol.STYLE_SOLID, 
//          new SimpleLineSymbol(
//            SimpleLineSymbol.STYLE_SOLID, 
//            new Color([255,255,255,0.35]), 
//            1
//          ),
//          new Color([125,125,125,0.35])
//        );
//        southCarolinaCounties.setRenderer(new SimpleRenderer(symbol));
//        map.addLayer(southCarolinaCounties);

//        map.infoWindow.resize(245,125);
//        
//        dialog = new TooltipDialog({
//          id: "tooltipDialog",
//          style: "position: absolute; width: 250px; font: normal normal normal 10pt Helvetica;z-index:100"
//        });
//        dialog.startup();
//        
//        var highlightSymbol = new SimpleFillSymbol(
//          SimpleFillSymbol.STYLE_SOLID, 
//          new SimpleLineSymbol(
//            SimpleLineSymbol.STYLE_SOLID, 
//            new Color([255,0,0]), 3
//          ), 
//          new Color([125,125,125,0.35])
//        );

//        //close the dialog when the mouse leaves the highlight graphic
//        map.on("load", function(){
//          map.graphics.enableMouseEvents();
//          map.graphics.on("mouse-out", closeDialog);
//          
//        });
//                
//        //listen for when the onMouseOver event fires on the countiesGraphicsLayer
//        //when fired, create a new graphic with the geometry from the event.graphic and add it to the maps graphics layer
//        southCarolinaCounties.on("mouse-over", function(evt){
//          var t = "<b>${NAME}</b><hr><b>2000 Population: </b>${POP2000:NumberFormat}<br>"
//            + "<b>2000 Population per Sq. Mi.: </b>${POP00_SQMI:NumberFormat}<br>"
//            + "<b>2007 Population: </b>${POP2007:NumberFormat}<br>"
//            + "<b>2007 Population per Sq. Mi.: </b>${POP07_SQMI:NumberFormat}";
//  
//          var content = esriLang.substitute(evt.graphic.attributes,t);
//          var highlightGraphic = new Graphic(evt.graphic.geometry,highlightSymbol);
//          map.graphics.add(highlightGraphic);
//          
//          dialog.setContent(content);

//          domStyle.set(dialog.domNode, "opacity", 0.85);
//          dijitPopup.open({
//            popup: dialog, 
//            x: evt.pageX,
//            y: evt.pageY
//          });
//        });
//    
//        function closeDialog() {
//          map.graphics.clear();
//          dijitPopup.close(dialog);
//        }

//      });


// 