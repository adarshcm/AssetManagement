var LeafMap = function () {
    var self = this,
        LeafIcon = '',
        map = '',
        control = '',
        geolay = '',
        markers = {},
        div = '',
        command = '',
        searchLayer = '',
        controlSearch ='';

    self.init = function (config) {
        self.container = config.container;
        LeafIcon = L.Icon.extend({
            options: {
                iconSize: [15, 15]
            }
        });

        div = L.DomUtil.create('div', 'marker');
        div.innerHTML = '<input type="radio" id="All" name="marker" value="All" checked><label for="All">All</label><br>';
        div.className = 'polaroidOnMap';

        command = L.control({
            position: 'topleft'
        });
        
        
    };

    self.draw = function () {
        var osmUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
            mbUrl = 'https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpandmbXliNDBjZWd2M2x6bDk3c2ZtOTkifQ._QA7i5Mpkd_m30IGElHziw',
            osm = new L.TileLayer(osmUrl),
            grayscale = L.tileLayer(mbUrl, {
                id: 'mapbox.light'
            }),
            streets = L.tileLayer(mbUrl, {
                id: 'mapbox.streets'
            });

        map = L.map(self.container, {
            minZoom: 12,
            attributionControl: false,
            layers: [osm],
            scrollWheelZoom: false,
        });

        L.geoJson(overlay, {
            filter: function (feature) {
                return feature.properties.NAME_2 === "Mandya" ? false : true;
            },
            style: {
                color: '#ffffff',
                'weight': 1,
                fillColor: '#ffffff',
                fillOpacity: 0.7
            }
        }).addTo(map);

        L.geoJson(mapOverlayTaluk, {
            filter: function (feature) {
                return feature.properties.NAME_3 === "Shrirangapattana" ? false : true;
            },
            style: {
                color: '#ffffff',
                'weight': 1,
                fillColor: '#ffffff',
                fillOpacity: 0.7
            }
        }).addTo(map);

        geolay = L.geoJson(mapOverlayTaluk, {
            filter: function (feature) {
                return feature.properties.NAME_3 === "Shrirangapattana" ? true : false;
            },
            style: {
                color: 'black',
                'weight': 1.5,
                fillColor: 'none',
                fillOpacity: 0
            },
            onEachFeature: onEachFeature
        }).addTo(map);

        var baseLayers = {
            "Grayscale": grayscale,
            "Streets": streets,
            "OSM": osm
        };

        control = L.control.layers(baseLayers).addTo(map);

        L.control.coordinates({
           position:"bottomleft", //optional default "bootomright"
           decimals:6, //optional default 4
           decimalSeperator:".", //optional default "."
           labelTemplateLat:"Latitude: {y}", //optional default "Lat: {y}"
           labelTemplateLng:"Longitude: {x}", //optional default "Lng: {x}"
           enableUserInput:false, //optional default true
           useDMS:false, //optional default false
           useLatLngOrder: true, //ordering of labels, default false-> lng-lat
           markerType: L.marker, //optional default L.marker
           markerProps: {}, //optional default {},
        }).addTo(map);

        L.control.coordinates({
           position: "bottomright", //optional default "bootomright"
           decimals: 6, //optional default 4
           decimalSeperator: ".", //optional default "."
           labelTemplateLat: "N: {y}", //optional default "Lat: {y}"
           labelTemplateLng: "E: {x}", //optional default "Lng: {x}"
           enableUserInput: false, //optional default true
           useDMS: true, //optional default false
           useLatLngOrder: true, //ordering of labels, default false-> lng-lat
           markerType: L.marker, //optional default L.marker
           markerProps: {}, //optional default {},
        }).addTo(map);

        var options = { position: 'topright'}
        //var measureControl = new L.Control.Measure(options);
        //measureControl.addTo(map);

        L.Control.measureControl(options).addTo(map);

        L.control.scale().addTo(map);

        map.setView({
                lat: 12.386766,
                lng: 76.735690
            }, 12)
            .setMaxBounds(geolay.getBounds());
    };

    self.renderMarker = function (markerObj, callback) {
        var markerName, marker = new L.featureGroup();
            //iconObj = new LeafIcon({
            //    iconUrl: markerObj.icon
            //});

        markerObj.markerData.forEach(function (e) {
            L.marker(e.co_ordinates.reverse(), {
                icon: new LeafIcon({
                        iconUrl: e.icon
                }),
                title : e.name
                }).bindPopup(e.name)
                .on('mouseover', function (e) {
                    this.openPopup();
                }).on('mouseout', function (e) {
                    this.closePopup();
                }).addEventListener("click", function () {
                    callback(this);
                }, e).addTo(marker);
        });

        markers[markerObj.name] = marker;
        console.log(marker);

        //        control.addOverlay(marker, markerObj.name).addTo(map);

        //var command = L.control({
        //    position: 'topleft'
        //});

        command.onAdd = function (map) {
            div.innerHTML = div.innerHTML + '<input type="radio" id="' + markerObj.name + '" name="marker" value="' + markerObj.name + '"><label for="' + markerObj.name + '">' + markerObj.name + '</label><br>';
            return div;
        };

        command.addTo(map);
        
        //searchLayer = L.layerGroup();
        //controlSearch = new L.Control.Search({
        //    position: 'topright'
        //   , layer: marker
        //   , initial: false
        //   , zoom: 15
        //});
        document.getElementById('All').addEventListener('click', handleCommand, false);
        for (markerName in markers) {
            //searchLayer.addLayer(markers[markerName]);
            //console.log(markers[markerName]);
            document.getElementById(markerName).addEventListener('click', handleCommand, false);
        }

        var tempObj = {checked:true,id:'All'}
        handleCommand.apply(tempObj);
        //console.log(markers);

//        if (controlSearch !== '') {
  //          map.removeControl(controlSearch);
    //    }
        
        //searchLayer.addTo(map);
        
        

       // map.addControl(controlSearch);

    };

    function onEachFeature(feature, layer) {
        layer.on({
            click: zoomToFeature
        });
    }

    function zoomToFeature(e) {
        map.fitBounds(e.target.getBounds());
    }

    // add the event handler
    function handleCommand() {
        if (this.checked) {
            if (this.id === 'All') {
                for (markerName in markers) {
                    if (!map.hasLayer(markers[markerName])) {
                        map.addLayer(markers[markerName])
                    }
                }
                map.fitBounds(geolay.getBounds());
            } else {
                for (markerName in markers) {
                    if (markerName !== this.id) {
                        map.removeLayer(markers[markerName])
                    }
                }
                if (!map.hasLayer(markers[this.id])) {
                    map.addLayer(markers[this.id])
                        .fitBounds(markers[this.id].getBounds());
                } else {
                    map.fitBounds(markers[this.id].getBounds());
                }
            }

        } else {
            if (this.id === 'All') {
                for (markerName in markers) {
                    map.removeLayer(markers[markerName])
                }
                map.fitBounds(geolay.getBounds());
            } else {
                map.removeLayer(markers[this.id])
                    .fitBounds(geolay.getBounds());
            }
        }
    }
};