<%--- Dakota McCutcheon #991321209 ---%>

<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/functions" prefix="fn" %>
<%--
  Created by IntelliJ IDEA.
  User: Dakota
  Date: 7/21/2014
  Time: 11:31 AM
  To change this template use File | Settings | File Templates.
--%>
<html>
<head>
    <title></title>
    <style>
        body
        {
            background-color:black ;
            color: yellowgreen;
        }
        table
        {
            border: 2px solid yellowgreen;
            color: yellowgreen;
            border-collapse: collapse;
            margin:auto auto;
        }
        tr, td,th
        {
            border: 3px solid gold;
            padding: 7px;
            color: greenyellow;
        }
        tr:first-child
        {
            background: grey;
        }
        form
        {
            color: Black;
            border-style:solid;
            border-width:7px;
            border-color:yellowgreen;
            background-color:yellow;
            position:relative;
            top:10px;
            height:200px;
            width:300px;
            text-align:center;
            margin:auto auto;
            font-size: 18px;
        }
    </style>
</head>
<body>
<form>
    <h3>CSV Upload Result</h3>
    <p>Parsed Records: ${parsedCount}</p>
    <p>Added Records: ${addedCount}</p>
    <%java.text.DateFormat df = new java.text.SimpleDateFormat("EEE, d MMMMM YYYY HH:mm:ss"); %>
    <p>Date Completed: <%= df.format(new java.util.Date()) %></p>
    </form>
<br>
<table>
    <tr><td>#</td><th>First Name</th><th>Last Name</th><th>Company Name</th><th>Address</th><th>City</th><th>Province</th><th>Postal</th><th>Phone 1</th><th>Phone 2</th><th>Email</th><th>Web</th></tr>
    <c:forEach var="person" items="${addedPersons}" varStatus="s">
    <tr>
            <td>${s.count}</td>
            <td>${person.firstName}</td>
            <td>${person.lastName}</td>
            <td>${person.companyName}</td>
            <td>${person.address}</td>
            <td>${person.city}</td>
            <td>${person.province}</td>
            <td>${person.postal}</td>
            <td>${person.phone1}</td>
            <td>${person.phone2}</td>
            <td>${person.email}</td>
            <td>${person.web}</td>
    </tr>
    </c:forEach>
</table>
</body>
</html>



