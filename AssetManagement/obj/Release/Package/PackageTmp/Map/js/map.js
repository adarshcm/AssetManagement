var Map = function () {
    'use strict';
    var self = this
        , width = ''
        , height = ''
        , svg = ''
        , layer = ''
        , g = ''
        , projection = ''
        , marker = ''
        , defs = ''
        , tooltipDiv = ''
        , co_ordinateDiv = '';


    function getRandomColor() {
        return 'rgb(' +
            (Math.floor(Math.random() * 56) + 200) + ', ' +
            (Math.floor(Math.random() * 56) + 200) + ', ' +
            (Math.floor(Math.random() * 56) + 200) +
            ')';
    }

    function addLineShadow(defs) {
        var filter, feMerge;
        filter = defs.append('filter')
            .attr('id', 'drop-shadow')
            .attr('height', '130%');

        // SourceAlpha refers to opacity of graphic that this filter will be applied to
        // convolve that with a Gaussian with standard deviation 3 and store result
        // in blur
        filter.append('feGaussianBlur')
            .attr('in', 'SourceAlpha')
            .attr('stdDeviation', 7)
            .attr('result', 'blur');

        // translate output of Gaussian blur to the right and downwards with 2px
        // store result in offsetBlur
        filter.append('feOffset')
            .attr('in', 'blur')
            .attr('dx', 1)
            .attr('dy', 1)
            .attr('result', 'offsetBlur');

        // overlay original SourceGraphic over translated blurred opacity by using
        // feMerge filter. Order of specifying inputs is important!
        feMerge = filter.append('feMerge');

        feMerge.append('feMergeNode')
            .attr('in', 'offsetBlur');
        feMerge.append('feMergeNode')
            .attr('in', 'SourceGraphic');
    }

    function mousemove() {
        var co_ordinates = projection.invert(d3.mouse(this));
        co_ordinateDiv.html(d3.format('.6f')(co_ordinates[0]) + ', ' + d3.format('.6f')(co_ordinates[1]));
        //        console.log(co_ordinates);
    }

    function mouseout() {
        co_ordinateDiv.html('');

    }

    self.init = function (config) {
        self.container = config.container;
        width = config.width;
        height = config.height;
        self.zoomable = config.zoomable || false;
        svg = d3.select('#' + self.container)
            .append('svg')
            .attr('width', width)
            .attr('height', height);
        //            .style('border', 'thin solid black');

        layer = svg.append('rect')
            .attr('class', 'background')
            .attr('width', width)
            .attr('height', height);


        g = svg.append('g')
            .style('stroke-width', '1.5px')
            .attr('filter', 'url(#drop-shadow)')
            .on('mousemove', mousemove)
            .on('mouseout', mouseout);

        tooltipDiv = d3.select('body').append('div')
            .attr('class', 'tooltip')
            .style('opacity', 0);

        co_ordinateDiv = d3.select('#' + self.container).append('div')
            //.attr('class', 'tooltip')
            .style('position', 'absolute')
            .style('right', '10px')
            .style('opacity', 1);

    };

    self.drawTaluk = function (districtName, talukName, data) {

        var topojsonData = ''
            , center = ''
            , scale = ''
            , offset = ''
            , path = ''
            , bounds = ''
            , hscale = ''
            , vscale = ''
            , taluk = '';

        topojsonData = topojson.feature(data, data.objects[districtName])
            .features.filter(function (d) {
                return d.id === talukName;
            });

        center = d3.geo.centroid(topojsonData[0]);

        scale = 0.9;
        offset = [width / 2, height / 2];
        projection = d3.geo.mercator()
            .scale(scale)
            .center(center)
            .translate(offset);

        path = d3.geo.path().projection(projection);
        bounds = path.bounds(topojsonData[0]);
        hscale = scale * (width - 40) / (bounds[1][0] - bounds[0][0]);
        vscale = scale * height / (bounds[1][1] - bounds[0][1]);
        scale = (hscale < vscale) ? hscale : vscale;
        offset = [((width - (bounds[0][0] + bounds[1][0]) / 2)), ((height - (bounds[0][1] + bounds[1][1]) / 2))];

        // new projection
        projection = d3.geo.mercator()
            .center(center)
            .scale(scale)
            .translate(offset);

        path = path.projection(projection);

        taluk = g.append('g')
            .attr('id', 'taluk');

        defs = taluk.append('defs');

        //        defs.append('pattern')
        //            .attr('id', 'img')
        //            .attr('patternUnits', 'userSpaceOnUse')
        //            .attr('width', (width))
        //            .attr('height', height)
        //            .append('image')
        //            .attr('xlink:href', '/images/Shrirangapattana.jpg')
        //            .attr('width', (width))
        //            .attr('width', (width))
        //            .attr('height', height)
        //            .attr('opacity' , 0.05);

        taluk.selectAll('path').data(topojsonData)
            .enter().append('path')
            .attr('d', path)
            //            .attr("fill", "url(#img)")
            .style('fill', function () {
                return getRandomColor();
            })
            .style('stroke-width', '1')
            .style('stroke', 'black');

        taluk.append('g')
            .attr('id', 'labels')
            .selectAll('text')
            .data(topojsonData)
            .enter().append('text')
            .text(function (d) {
                return d.id;
            })
            .attr('x', function (d) {
                return path.centroid(d)[0];
            })
            .attr('y', function (d) {
                return path.centroid(d)[1];
            })
            .attr('text-anchor', 'middle')
            .attr('font-size', '12pt');

        addLineShadow(defs);

    };

    self.renderMarker = function (markerData, callback) {
        markerData.forEach(function (e, i) {
            d3.xml('/Map/images/marker_new.svg', function (error, documentFragment) {
                if (error) {
                    return;
                }

                var svgNode = documentFragment
                    .getElementsByTagName('g')[0];
                svgNode.id = svgNode.id + i;

                g.node().appendChild(svgNode);

                marker = g.select('#marker' + i)
                    .attr('transform', function (d) {
                        return 'translate(' + projection(e.co_ordinates) + ')scale(' + [0.5, 0.5] + ')';
                    });

                g.select('#marker' + i).selectAll('path')
                    .attr('fill', e.color)
                    .attr('style', 'cursor:pointer')
                    .on('mouseover', function () {
                        tooltipDiv.transition()
                            .duration(200)
                            .style('opacity', 0.9);
                        tooltipDiv.html(e.name)
                            .style('left', (d3.event.pageX) + 'px')
                            .style('top', (d3.event.pageY - 28) + 'px');
                    })
                    .on('mouseout', function () {
                        tooltipDiv.transition()
                            .duration(500)
                            .style('opacity', 0);
                    })
                    .on('click', function () {
                        callback(e);
                    });

            });
        });
    };
};