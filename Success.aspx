<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Success.aspx.cs" Inherits="RazorpaySampleApp.Success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment success</title>
    <link href="Content/assest/css/style.css" rel="stylesheet" />
</head>
<body>
    <div class="notifyAltPop">
        <form id="form1" runat="server">
            <div class="notifyAlt mainSection">
                <asp:Image ID="img" runat="server" />
                <asp:Label runat="server" ID="lblMsg" CssClass="notifySms"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
