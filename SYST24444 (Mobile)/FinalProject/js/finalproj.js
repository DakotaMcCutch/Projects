var countries = [];
var geocoder;
var map;
var mapCenter;
var years = [];
var data = {};

$(document).ready(function()
{
	readXML();
	about();
});

$(document).on('pageshow', '#geo', function()
{
	google.maps.event.trigger(map, "resize");
	map.setCenter(mapCenter);
});

function readXML()
{
	$.ajax(
		{
			type: "GET",
			url: "Group2-GovtDebtEuroUnion.xml",
			dataType: "xml",
			success: handleResponse
		});
}

function handleResponse(xml)
{
	getCountries(xml);
	getYears(xml);
	geo();
	graph(xml);
	text(xml);
}

//add all countries to array
function getCountries(xml)
{
	$(xml).find("record").each(function()
	{
		var country = $(this).find("country").text();
		if($.inArray(country,countries) == -1)
		{
			countries.push($(this).find("country").text());
		}
	});
	//console.log(countries);
}

function geo() {
	display = new google.maps.DirectionsRenderer();
	geocoder = new google.maps.Geocoder();

	mapCenter = new google.maps.LatLng(53.283839, -28.001287);

	if (navigator.geolocation) {
		var options =
		{
			enableHighAccuracy: true, //if device has GPS
			timeout: 5000, //how long to wait for a position
			maximumAge: 0 //if 0, obtain a new location for each call
		};
		navigator.geolocation.getCurrentPosition(success, fail, options);
	}
	else {
		alert("Geolocation not supported");
	}

	function fail(err) {
		alert("FAIL: " + err.code + "-" + err.message);
	}

	function success(pos) {
		var lat = pos.coords.latitude;
		var lng = pos.coords.longitude;
		var userLoc = new google.maps.LatLng(lat, lng);

		handle_geolocation(pos);

		$.each(countries, function (i, v) {
			var address = v;
			var url = "http://maps.googleapis.com/maps/api/staticmap?scale=false&size=1000x1100&maptype=hybrid&sensor=false&format=jpg&visual_refresh=true&markers=size:mid%7Ccolor:red%7Clabel:%7C"+address;
			$("#map_canvas").append(
				$(document.createElement("img")).attr("src", url).attr('id', 'map')
			);
			$("#map_canvas").append("<br>");
		});
	}

	function handle_geolocation(pos) {

		var url = "http://maps.google.com/maps/api/staticmap?sensor=true&center=" + pos.coords.latitude + ',' + pos.coords.longitude +
			"&zoom=14&size=1000x1100&markers=color:red|label:U|" + pos.coords.latitude + ',' + pos.coords.longitude;

		$("#map_canvas").append(
			$(document.createElement("img")).attr("src", url).attr('id', 'map')

		);
		$("#map_canvas").append("<br>");

	}
}

function getYears(xml)
{
	$(xml).find("record").each(function()
	{
		var year = $(this).find("time_period").text();
		if($.inArray(year,years) == -1)
		{
			years.push($(this).find("time_period").text());
		}
	});
}

function graph(xml)
{
	$(xml).find("record").each(function()
	{
		$("#title").html($(this).find("type").text() + ", " + $(this).find("frequency").text() + ", " + $(this).find("unit").text() + ", " + $(this).find("variable").text() + "<br><br>");

		$.each(countries, function(i,v)
		{
			if(typeof data[v] === 'undefined')
			{
				data[v] = [];
			}
		});
		data[$(this).find("country").text()].push(parseFloat($(this).find("value").text()))

	});

	var chartDataSets = [];
	var up = 0;
	var down = 255;

	$.each(countries, function(i,v)
	{
		var randColor1 = Math.floor(Math.random() * 255);
		var randColor2 = Math.floor(Math.random() * 255);
		var randColor3 = Math.floor(Math.random() * 255);

		chartDataSets.push({fillColor : "rgba(" + randColor1 + "," + randColor2 + "," + randColor3 + ",0)",
			strokeColor : "rgba(" + randColor1 + "," + randColor2 + "," + randColor3 + ",1)",
			pointColor : "rgba(0,255,0,1)",
			pointStrokeColor : "#FFF",
			data : data[v]});
	});

	var chartData = { labels : years, datasets : chartDataSets }

	$("#legend").empty();
	$("#legend").append("<table id='legendTab'><tr>");

	$.each(chartDataSets, function(i,v)
	{
		$("#legendTab").append("<td style='background-color:" + $(v).attr("strokeColor") + ";'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>");
		$("#legendTab").append("<td>"+ countries[i] + "&nbsp;&nbsp;</td>");
	});

	$("#legendTab").append("</tr></table>");
	$("#legendTab").trigger('create')

	var myBar = new Chart(document.getElementById("bar_graph").getContext("2d")).Bar(chartData);
}

function text(xml)
{
	$.each(countries, function(i,v)
	{
		$("#dCountry").append("<input type='checkbox' name='" + v + "' id='" + v + "Text' class='custom'><label for='" + v + "Text'>" + v + "</label>");
	});

	$('[id="dCountry"]').trigger('create');

	$.each(years, function(i,v)
	{
		$("#dYear").append("<input type='checkbox' name='" + v + "' id='" + v + "Text' class='custom'><label for='" + v + "Text'>" + v + "</label>");
	});

	$('[id="dYear"]').trigger('create');

	var criteria = [];
	$("input[type='checkbox']").bind( "change", function(event, ui) {
		var clicked = event.target.name;

		$("#displayData").empty();

		if($.inArray(clicked,criteria) == -1)
		{
			criteria.push(clicked);
		}
		else
		{
			criteria = $.grep(criteria, function(value)
			{
				return value != clicked;
			});
		}

		if(criteria.length <= 1)
		{
			$("#displayData").append("Please Select At Least One Year And One Country");
		}
		else
		{
			$("#displayData").append("<table data-role='table' id='dataShow' data-mode='reflow' class='ui-responsive table-stroke'><thead><tr><th data-priority='persist'>Country</th><th data-priority='persist'>Year</th><th data-priority='persist'>Value</th></tr></thead><tbody>");

			$(xml).find("record").each(function()
			{
				var country = $(this).find("country").text();
				var year = $(this).find("time_period").text();

				if(($.inArray(country,criteria) != -1) && ($.inArray(year,criteria) != -1))
				{
					$("#dataShow").append("<tr><th>" + country + "</th><td>" + year + "</td><td>" + $(this).find("value").text() + "</td></tr>");
				}
			});
		}
	});
}

function about()
{
	$("#dev").empty();
	$.getJSON("about.json", function(data)
	{
		for (x = 0; x < data.students.length; x++)
		{
			$("#dev").append("<p><b>Student Name:</b> " + data.students[x].name + "<br><b>Slate Login:</b> " + data.students[x].login + "<br><b>Student Number:</b> " + data.students[x].number + "</p><br>");
		}
	});
}