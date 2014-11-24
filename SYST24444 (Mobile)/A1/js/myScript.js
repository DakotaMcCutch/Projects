/**
 * Created by Dakota on 9/29/2014.
 */

$(document).ready(function (){
    $.ajax({
        type: "GET",
        url: "a1.xml",
        dataType: "xml",
        success: populate
    });

});

    function populate(xml){
        $("#storeName").append("<h1>" + $(xml).find('bookstore').attr("title") + "</h1>");
        $("#storeFront").append("<img src=\"imgs/" + $(xml).find('storefrontPicture').text() + "\">");
        $("#storeLocation").append($(xml).find('intersection').attr("mainStreet") + "<br>" + "Located Near The Intersection Of " + $(xml).find('intersection').text() );
        $("#main").append("<table>");
        $("#main").append("<tr><th>ISBN</th><th>Title</th><th>Jacket Picture</th><th>Price</th></tr>");
        $(xml).find("book").each(function()
            {
                var isbn = $(this).attr("isbn").trim();
                var title = $(this).find('title').text().trim();
                var jpic = $(this).find('jacketPicture').text().trim();
                var price = $(this).find('price').text().trim();

                $("#main").append("<tr>");
                $("#main").append("<td>" + isbn + "</td>");
                $("#main").append("<td>" + title + "</td>");
                $("#main").append("<td>" +"<img src=\"imgs/" +jpic +"\">"+ "</td>");
                $("#main").append("<td>" + price + "</td>");
                $("#main").append("</tr>");
            });
        $("#main").append("</table>");
    };