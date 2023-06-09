<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentRefund.aspx.cs" Inherits="PaymentRefund" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Refund</title>
    <link href="Content/assest/css/style.css" rel="stylesheet" />
</head>
<body>
    <div class="mainSection">
        <div class="logoArea">
            <img class="logoTop" src="Content/assest/images/berger-paints-logo.png" alt="logo" />
        </div>
        <form runat="server">
            <div class="formListView" id="divMainContent" runat="server">
                <div class="formGroup">
                    <label>Customer Name:</label>
                    <asp:TextBox runat="server" ID="txtCustomerName" CssClass="formContrl"></asp:TextBox>
                </div>
                <div class="formGroup">
                    <label>Email ID:</label>
                    <asp:TextBox runat="server" ID="txtEmailID" CssClass="formContrl"></asp:TextBox>
                </div>
                <div class="formGroup">
                    <label>Contact Number:</label>
                    <asp:TextBox runat="server" ID="txtContactNumber" CssClass="formContrl"></asp:TextBox>
                </div>
                <div class="formGroup">
                    <label>Address:</label>
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="formContrl" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
                <div class="formGroup">
                    <label>Amount Paid:</label>
                    <asp:TextBox runat="server" ID="txAmountPaid" CssClass="formContrl" Enabled="false"></asp:TextBox>
                </div>
                <div class="formGroup">
                    <label>Refund Amount(INR):</label>
                    <asp:TextBox runat="server" ID="txtAmount" CssClass="formContrl" onkeypress="if(event.keyCode != 46 && event.keyCode > 31 && (event.keyCode < 48 || event.keyCode > 57))event.returnValue=false;"></asp:TextBox>
                    <asp:HiddenField ID="hdnTrxId" runat="server" />
                    <asp:HiddenField ID="hdnPaymentId" runat="server" />
                    <asp:HiddenField ID="hdnAmount" runat="server" />
                </div>
                <div class="text-center">
                    <%-- <button id="btnPay" class="btn">Pay With Razorpay</button>--%>
                    <asp:Button ID="btnRefund" runat="server" CssClass="btn" Text="Proceed To Refund" OnClick="btnRefund_Click" />
                </div>
            </div>
            <div class="notifyAlt mainSection" id="divMsg" runat="server" visible="false">
                <%--<asp:Image ID="img" runat="server" />--%>
                <asp:Label runat="server" ID="lblMsg" CssClass="notifySms"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
