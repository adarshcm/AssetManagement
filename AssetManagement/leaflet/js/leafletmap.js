var LeafMap = function () {
    var self = this,
        LeafIcon = '',
        map = '',
        control = '',
        geolay = '',
        markers = {},
        div = '',
        command = '',
        searchControl = '',
        searchLayer = '',
        circle = '',
        tempMarkers = [];

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
            position: "bottomleft", //optional default "bootomright"
            decimals: 6, //optional default 4
            decimalSeperator: ".", //optional default "."
            labelTemplateLat: "Latitude: {y}", //optional default "Lat: {y}"
            labelTemplateLng: "Longitude: {x}", //optional default "Lng: {x}"
            enableUserInput: false, //optional default true
            useDMS: false, //optional default false
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

        var options = {
            position: 'topright',
            activeColor: 'red',
            completedColor: 'blue',
            primaryLengthUnit: 'kilometers',
            secondaryLengthUnit: 'miles',
            primaryAreaUnit: 'acres',
            secondaryAreaUnit: 'sqmeters'
        }

        var options1 = {
            position: 'topright',
        }
        var rulerControl = new L.Control.measureControl(options1);
        rulerControl.addTo(map);

        var measureControl = new L.Control.Measure(options);
        measureControl.addTo(map);
       
        L.control.scale().addTo(map);

        map.setView({
                lat: 12.386766,
                lng: 76.735690
            }, 12)
            .setMaxBounds(geolay.getBounds());


                var toggle = L.easyButton({
                states: [{
                stateName: 'add-markers',
                icon: 'fa-circle-thin fa-2x',
                title: 'Draw circle',
                onClick: function (control) {
                    map.once('click', function (e) {

                        circle = L.circle(e.latlng, 2000, {
                            color: 'red',
                            fillColor: '#f03',
                            fillOpacity: 0.5,
                            weight: 1
                        }).on({
                            mousedown: function () {
                                map.on('mousemove', function (e) {
                                    circle.setLatLng(e.latlng);
                                    tempMarkers.forEach(function (e) {
                                        if (circle.getBounds().contains(e.getLatLng())) {
                                            map.addLayer(e);
                                        } else {
                                            map.removeLayer(e);
                                        }
                                    });
                                });
                            }
                        });
                        circle.addTo(map);

                        tempMarkers.forEach(function (e) {
                            if (!circle.getBounds().contains(e.getLatLng())) {
                                map.removeLayer(e);
                            }
                        });

                        //map.fitBounds(circle.getBounds());

                        control.state('remove-markers');

                    });

                }
                }, {
                icon: 'fa-ban fa-2x',
                stateName: 'remove-markers',
                onClick: function (control) {

                    map.removeLayer(circle);
                    tempMarkers.forEach(function (e) {
                        map.addLayer(e);
                    });
                    //map.fitBounds(geolay.getBounds());
                    control.state('add-markers');
                },
                title: 'Remove Circle'
                }],
                position: 'topright'
            });
            toggle.addTo(map);
            map.on('mouseup', function (e) {
                map.removeEventListener('mousemove');
            });


    };

    self.renderMarker = function (markerObj, callback) {
        var markerName, marker = new L.featureGroup();
        //iconObj = new LeafIcon({
        //    iconUrl: markerObj.icon
        //});

        markerObj.markerData.forEach(function (e) {
            tempMarkers.push(L.marker(e.co_ordinates.reverse(), {
                    icon: new LeafIcon({
                        iconUrl: e.icon
                    }),
                    title: e.name
                })
                //.bindPopup(e.name)
                //.on('mouseover', function (e) {
                //    this.openPopup();
                //}).on('mouseout', function (e) {
                //    this.closePopup();
                //})
                .addEventListener("click", function () {
                    callback(this);
                }, e).addTo(marker));
        });

        markers[markerObj.name] = marker;

        //        control.addOverlay(marker, markerObj.name).addTo(map);

        //        var command = L.control({
        //            position: 'topleft'
        //        });

        command.onAdd = function (map) {
            div.innerHTML = div.innerHTML + '<input type="radio" id="' + markerObj.name + '" name="marker" value="' + markerObj.name + '"><label for="' + markerObj.name + '">' + markerObj.name + '</label><br>';
            return div;
        };

        command.addTo(map);

        document.getElementById('All').addEventListener('click', handleCommand, false);
        for (markerName in markers) {
            //searchLayer.addLayer(markers[markerName]);
            //console.log(markers[markerName]);
            document.getElementById(markerName).addEventListener('click', handleCommand, false);
        }

        var tempObj = {
            checked: true,
            id: 'All'
        }
        handleCommand.apply(tempObj);
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
        var markerName;
        if (searchControl !== '') {
            searchLayer = '';
            map.removeControl(searchControl);
            searchControl = '';
        }
        if (this.checked) {
            if (this.id === 'All') {
                searchLayer = L.layerGroup()
                for (markerName in markers) {
                    markers[markerName].getLayers().forEach(function (e) {
                        searchLayer.addLayer(e);
                    });
                    if (!map.hasLayer(markers[markerName])) {
                        map.addLayer(markers[markerName])
                    }
                }
                //                searchLayer.addTo(map);
                map.fitBounds(geolay.getBounds());
            } else {
                for (markerName in markers) {
                    if (markerName !== this.id) {
                        map.removeLayer(markers[markerName])
                    }
                }
                if (!map.hasLayer(markers[this.id])) {
                    map.addLayer(markers[this.id]);
                }
                searchLayer = markers[this.id];
                map.fitBounds(markers[this.id].getBounds());
            }

            searchControl = new L.Control.Search({
                position: 'topright',
                layer: searchLayer,
                initial: false,
                hideMarkerOnCollapse: true,
                zoom: 18
            });

            map.addControl(searchControl);
        } else {
            if (this.id === 'All') {
                for (markerName in markers) {
                    map.removeLayer(markers[markerName]);
                }
                map.fitBounds(geolay.getBounds());
            } else {
                map.removeLayer(markers[this.id])
                    .fitBounds(geolay.getBounds());
            }
        }

    }
};