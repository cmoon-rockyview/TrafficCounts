


function (ZoomX, ZoomY) {

    require(["esri/map", "esri/layers/ArcGISTiledMapServiceLayer", "esri/layers/ArcGISDynamicMapServiceLayer", "esri/geometry/Point",
            "esri/SpatialReference", "dojo/dom", "dojo/domReady!"],
    function (Map, Tiled, Dyanmic, Point, SpatialReference, dom) {
        var Map = new Map("map");

        var Aerials = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Aerials/Aerials2012/MapServer");
        var Roadnet = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Transportation/Roads/MapServer");
        var BaseMap = new Tiled("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/BaseMaps/BaseMapElements/MapServer");

        //Dyanmic Map
        var Sensors = new Dyanmic("http://gismo.mdrockyview.ab.ca/arcgis/rest/services/Transportation/TrafficCountSensor/MapServer");

        Map.addLayers([Aerials, Roadnet, Sensors]);
        //dom.byId("checkRubberBandZoom").value = map.isRubberBandZoom;          

        var pt = new Point(ZoomX, ZoomY, new SpatialReference({ wkid: 3776 }));
        Map.centerAndZoom(pt, 3);


    });


}




