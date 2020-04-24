<%@ Page Language="C#" AutoEventWireup="true" CodeFile="msg.aspx.cs" Inherits="msg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <script src="js/jquery.min.js"></script>
    <script>
        var win = window.open("http://gtftechnologies.com/landing-page/thanks.htm", "popupWindow", "popupWindow", "width=359,height=365,top=150,left=500,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no");
        setTimeout(function () {
            location.href = "http://gtftechnologies.com/landing-page/";
            win.close();
            
        }, 2000);
       
    </script>
</body>
</html>
