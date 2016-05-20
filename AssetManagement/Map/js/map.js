var Map = function () {

    var self = this;
    var width = '',
        height = '',
        svg = '',
        layer = '',
        g = '',
        projection = '',
        marker = '',
        defs = '',
        tooltipDiv = '',
        co_ordinateDiv = '';


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
            .on('mousemove', mousemove);

        tooltipDiv = d3.select('body').append('div')
            .attr('class', 'tooltip')
            .style('opacity', 0);

        co_ordinateDiv = d3.select('#' + self.container).append('div')
            //.attr('class', 'tooltip')
            .style('position','absolute')
            .style('right','10px')
            .style('opacity',1);

    };

    self.drawTaluk = function (districtName, talukName, data) {

        var topojsonData = topojson.feature(data, data.objects[districtName])
            .features.filter(function (d) {
                return d.id === talukName;
            });

        var center = d3.geo.centroid(topojsonData[0]);

        var scale = .9;
        var offset = [width / 2, height / 2];
        projection = d3.geo.mercator()
            .scale(scale)
            .center(center)
            .translate(offset);

        var path = d3.geo.path().projection(projection);
        var bounds = path.bounds(topojsonData[0]);
        var hscale = scale * (width - 40) / (bounds[1][0] - bounds[0][0]);
        var vscale = scale * height / (bounds[1][1] - bounds[0][1]);
        var scale = (hscale < vscale) ? hscale : vscale;
        offset = [((width - (bounds[0][0] + bounds[1][0]) / 2)), ((height - (bounds[0][1] + bounds[1][1]) / 2))];

        // new projection
        projection = d3.geo.mercator()
            .center(center)
            .scale(scale)
            .translate(offset);

        path = path.projection(projection);

        var taluk = g.append('g')
            .attr('id', 'taluk');

        defs = taluk.append('defs');

        taluk.selectAll('path').data(topojsonData)
            .enter().append('path')
            .attr('d', path)
            .style('fill', function () {
                return getRandomColor();
            })
            .style('stroke-width', '1')
            .style('stroke', 'black')

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

    function clicked(d) {
        if (active.node() === this) return reset();
        active.classed('active', false);
        active = d3.select(this).classed('active', true);

        activeLabel.attr('opacity', '1');
        activeLabel = selections.district.select('#labels').selectAll('text').filter(function (e) {
            return d.id === e.id;
        });
        activeLabel.attr('opacity', '0');

        // selections.district.select('#labels').filter(function(dd){
        //   return d.id === dd.id }).attr('opacity','0');

        var bounds = path.bounds(d),
            dx = bounds[1][0] - bounds[0][0],
            dy = bounds[1][1] - bounds[0][1],
            x = (bounds[0][0] + bounds[1][0]) / 2,
            y = (bounds[0][1] + bounds[1][1]) / 2,
            scale = .9 / Math.max(dx / width, dy / height),
            translate = [width / 2 - scale * x, height / 2 - scale * y],
            districtName;

        g.transition()
            .duration(750)
            .style('stroke-width', 1.5 / scale + 'px')
            .attr('transform', 'translate(' + translate + ')scale(' + scale + ')');

        districtName = d.id.split(' ').join('');
        selections.marker ? selections.marker.remove() : '';
        if (!zoomed) {
            zoomed = true;
            renderMarkers('Karnataka_' + districtName);
            selections.marker ? selections.marker.transition().attr('transform', 'scale(' + [1, 1] + ')') : '';
        }
        selections.innerdistrict ? selections.innerdistrict.remove() : '';

        renderInnerDistrict('Karnataka_' + districtName);
    }

    function reset() {
        zoomed = false;
        active.classed('active', false);
        active = d3.select(null);

        g.transition()
            .duration(750)
            .style('stroke-width', '1.5px')
            .attr('transform', '');

        activeLabel.attr('opacity', '1');
        selections.marker ? selections.marker.remove() : '';
        selections.innerdistrict.remove();
    }

    function renderMarkers(districtName) {

        markerData.forEach(function (e, i) {
            d3.xml('Map/images/marker_new.svg', function (error, documentFragment) {
                if (error) {
                    console.log(error);
                    return;
                }

                var svgNode = documentFragment
                    .getElementsByTagName('g')[0];
                svgNode.id = svgNode.id + i;
                console.log(svgNode.id);

                g.node().appendChild(svgNode);

                selections.marker = g.select('#marker' + i)
                    .attr('transform', function (d) {
                        return 'translate(' + projection(e.co_ordinates) + ')scale(' + [0.09, 0.09] + ')';
                    });
                marker.style = ""

                g.select('#marker' + i).selectAll('path')
                    .attr('fill', e.color)
                    .on('mouseover', function () {
                        tooltipDiv.transition()
                            .duration(200)
                            .style('opacity', .9);
                        tooltipDiv.html(e.name)
                            .style('left', (d3.event.pageX) + 'px')
                            .style('top', (d3.event.pageY - 28) + 'px');
                    })
                    .on('mouseout', function () {
                        tooltipDiv.transition()
                            .duration(500)
                            .style('opacity', 0);
                    });
            });
        });
    }

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
            .attr('in', 'offsetBlur')
        feMerge.append('feMergeNode')
            .attr('in', 'SourceGraphic');
    }

    function mousemove() {
        var co_ordinates = projection.invert(d3.mouse(this));
        co_ordinateDiv.html(d3.format(".6f")(co_ordinates[0])+', '+d3.format(".6f")(co_ordinates[1]));
//        console.log(co_ordinates);
    }

    self.renderMarker = function (markerData) {

        markerData.forEach(function (e, i) {
            d3.xml('Map/images/marker_new.svg', function (error, documentFragment) {
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
                    .on('mouseover', function () {
                        tooltipDiv.transition()
                            .duration(200)
                            .style('opacity', .9);
                        tooltipDiv.html(e.name)
                            .style('left', (d3.event.pageX) + 'px')
                            .style('top', (d3.event.pageY - 28) + 'px');
                    })
                    .on('mouseout', function () {
                        tooltipDiv.transition()
                            .duration(500)
                            .style('opacity', 0);
                    });
            });
        });
    };
}