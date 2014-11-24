/**
 * Created by Dakota on 10/20/2014.
 */
$(document).ready(function (){

})
$(document).on("pagebeforeshow", "#home", function () {
    $.ajax({
        type: "POST",
        url: "a2.xml",
        dataType: "xml",
        success: processXml
    })
});

function processXml (xml) {
    $("#title").html($(xml).find("title"));
    var n=1;
    $(xml).find("movie").each(function() {
        $(".movie" + n).html($(this).find("name").text());
        n++;
    });
    console.log("test end");
    $(".footer").html($(xml).find("dakota").text() +"  "+$(xml).find("dakota").attr("program") +"  "+$(xml).find("dakota").attr("studentNum"))
}

$(document).on("pagebeforeshow", "#TheBoondockSaints", function () {
    $.ajax({
        type: "POST",
        url: "a2.xml",
        dataType: "xml",
        success: function (xml){
            getData(xml, "The Boondock Saints");
        },
        error: function (e) {
            alert(e.status + " - " + e.statusText);
        }
    });
    $("#movie-TheBoondockSaints-plot").hide();
    $("#movie-TheBoondockSaints-castList").hide();
    $("#movie-TheBoondockSaints-reviewList").hide();
});

$(document).on("pagehide", "#TheBoondockSaints", function () {

    $("#movie-TheBoondockSaints-plot").hide();
    $("#movie-TheBoondockSaints-castList").hide();
    $("#movie-TheBoondockSaints-reviewList").hide();

});
$(document).on("pageshow", "#TheBoondockSaints", function () {

    $("#movie-TheBoondockSaints-plotTitle").click(function (){
        $("#movie-TheBoondockSaints-plot").toggle();
        $("#movie-TheBoondockSaints-castList").hide();
        $("#movie-TheBoondockSaints-reviewList").hide();
    });
    $("#movie-TheBoondockSaints-reviewTitle").click(function (){
        $("#movie-TheBoondockSaints-plot").hide();
        $("#movie-TheBoondockSaints-castList").hide();
        $("#movie-TheBoondockSaints-reviewList").toggle();
    });
    $("#movie-TheBoondockSaints-castTitle").click(function (){
        $("#movie-TheBoondockSaints-plot").hide();
        $("#movie-TheBoondockSaints-castList").toggle();
        $("#movie-TheBoondockSaints-reviewList").hide();
    })

});

$(document).on("pagebeforeshow", "#TheBoondockSaintsII", function () {
    $.ajax({
        type: "POST",
        url: "a2.xml",
        dataType: "xml",
        success: function (xml){
            getData(xml, "The Boondock Saints II");
        },
        error: function (e) {
            alert(e.status + " - " + e.statusText);
        }
    });
    $("#movie-TheBoondockSaintsII-plot").hide();
    $("#movie-TheBoondockSaintsII-castList").hide();
    $("#movie-TheBoondockSaintsII-reviewList").hide();
});

$(document).on("pagehide", "#TheBoondockSaintsII", function () {

    $("#movie-TheBoondockSaintsII-plot").hide();
    $("#movie-TheBoondockSaintsII-castList").hide();
    $("#movie-TheBoondockSaintsII-reviewList").hide();

});
$(document).on("pageshow", "#TheBoondockSaintsII", function () {

    $("#movie-TheBoondockSaintsII-plotTitle").click(function (){
        $("#movie-TheBoondockSaintsII-plot").toggle();
        $("#movie-TheBoondockSaintsII-castList").hide();
        $("#movie-TheBoondockSaintsII-reviewList").hide();
    });
    $("#movie-TheBoondockSaintsII-reviewTitle").click(function (){
        $("#movie-TheBoondockSaintsII-plot").hide();
        $("#movie-TheBoondockSaintsII-castList").hide();
        $("#movie-TheBoondockSaintsII-reviewList").toggle();
    });
    $("#movie-TheBoondockSaintsII-castTitle").click(function (){
        $("#movie-TheBoondockSaintsII-plot").hide();
        $("#movie-TheBoondockSaintsII-castList").toggle();
        $("#movie-TheBoondockSaintsII-reviewList").hide();
    })

});

$(document).on("pagebeforeshow", "#ActOfValor", function () {
    $.ajax({
        type: "POST",
        url: "a2.xml",
        dataType: "xml",
        success: function (xml){
            getData(xml, "Act Of Valor");
        },
        error: function (e) {
            alert(e.status + " - " + e.statusText);
        }
    });
    $("#movie-ActOfValor-plot").hide();
    $("#movie-ActOfValor-castList").hide();
    $("#movie-ActOfValor-reviewList").hide();
});

$(document).on("pagehide", "#ActOfValor", function () {
    $("#movie-ActOfValor-plot").hide();
    $("#movie-ActOfValor-castList").hide();
    $("#movie-ActOfValor-reviewList").hide();
});
$(document).on("pageshow", "#ActOfValor", function () {
    $("#movie-ActOfValor-plotTitle").click(function (){
        $("#movie-ActOfValor-plot").toggle();
        $("#movie-ActOfValor-castList").hide();
        $("#movie-ActOfValor-reviewList").hide();
    });
    $("#movie-ActOfValor-reviewTitle").click(function (){
        $("#movie-ActOfValor-plot").hide();
        $("#movie-ActOfValor-castList").hide();
        $("#movie-ActOfValor-reviewList").toggle();
    });
    $("#movie-ActOfValor-castTitle").click(function (){
        $("#movie-ActOfValor-plot").hide();
        $("#movie-ActOfValor-castList").toggle();
        $("#movie-ActOfValor-reviewList").hide();
    })
});

function getData(xml, choice) {
    var cast = "";
    var review = "";
        $(xml).find("movie").each(function () {
    if (choice == $(this).find("name").text()){
        $("#movie-" + choice.replace(/\s+/g, '')+"-img").html("<div class=\"cover\"><img src=\"imgs/" + choice.replace(/\s+/g, '')  + ".jpg \" /><//div>");
        $(".movie-" + choice.replace(/\s+/g, '')+"-title").html($(this).find("name").text());
        $("#movie-" + choice.replace(/\s+/g, '')+"-plot").html("<p>" +$(this).find("plot").text() + "</p><br>");
        $(this).find("cast").each(function() {
            var i = 1;
            while (i <= $(this).children().size()) {
                cast += "<tr><td>" + $(this).find('actor'+i).text() + "</td></tr><tr><td></td></tr>";
                i++;
        }
        });
        $("#movie-" + choice.replace(/\s+/g, '')+"-castList").html(cast);
        $(this).find("reviews").each(function() {
            var i2 = 1;
            while (i2 <= $(this).children().size()) {
                review += "<tr><td>"+i2+".  " + $(this).find('review'+i2).text() + "</td></tr><tr><td></td></tr>";
                i2++;
            }
        });
        $("#movie-" + choice.replace(/\s+/g, '')+"-reviewList").html(review);

    }
        });
}

