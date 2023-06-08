<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentGateway.aspx.cs" Inherits=" RazorpaySampleApp.Default" %>

<!doctype html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Razorpay Payment Gateway</title>
    <link href="Content/assest/css/style.css" rel="stylesheet" />
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        var orderId = "<%=orderId%>"
        var TransactionId = "<%=TransactionId%>"
        var options = {
            "name": "<%=txtCustomerName.Text%>",
            "description": "Lead Payment",
            "order_id": orderId,
            "image": "https://bpilmobile.bergerindia.com/SERVICEAPP/images/logo.png",
            "prefill": {
                "name": "<%=txtCustomerName.Text%>",
                "email": "<%=txtEmailID.Text%>",
                "contact": "<%=txtContactNumber.Text%>",
            },
            "notes": {
                "address": "<%=txtAddress.Text%>",
                /*"merchant_order_id": "12312321",*/
            },
            "theme": {
                "color": "#F37254"
            }
        }
        // Boolean whether to show image inside a white frame. (default: true)
        options.theme.image_padding = false;
        options.handler = function (response) {
            document.getElementById('razorpay_payment_id').value = response.razorpay_payment_id;
            document.getElementById('razorpay_order_id').value = orderId;
            document.getElementById('razorpay_signature').value = response.razorpay_signature;
            document.getElementById('razorpay_transaction_id').value = TransactionId;
            document.razorpayForm.submit();
        };
        options.modal = {
            ondismiss: function () {
                console.log("This code runs when the popup is closed");
            },
            // Boolean indicating whether pressing escape key 
            // should close the checkout form. (default: true)
            escape: true,
            // Boolean indicating whether clicking translucent blank
            // space outside checkout form should close the form. (default: false)
            backdropclose: false
        };

        var rzp = new Razorpay(options);
        //document.getElementById('btnPay').onclick = function (e) {
        //    rzp.open();
        //    e.preventDefault();
        //}

        function ClickToPayment() {
            rzp.open();
            e.preventDefault();
        }
    </script>
</head>
<body>
    <form action="Success.aspx" method="post" name="razorpayForm">
        <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" />
        <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" />
        <input id="razorpay_signature" type="hidden" name="razorpay_signature" />
        <input id="razorpay_transaction_id" type="hidden" name="razorpay_transaction_id" />
    </form>
    <div class="mainSection">
        <div class="logoArea">
            <img class="logoTop" src="Content/assest/images/berger-paints-logo.png" alt="logo" />
        </div>
        <form runat="server">
            <div class="formListView" runat="server" id="idMsg" visible="false">
                <div class="formGroup" style="text-align: center;">
                    <asp:Label runat="server" ID="lblmsg" Text="Payment already done." ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="formListView" runat="server" id="idTable">
                <div class="formGroup">
                    <label>Customer Name:</label>
                    <asp:HiddenField runat="server" ID="hdnLeadId" />
                    <asp:HiddenField runat="server" ID="hdnTransactionId" />
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
                    <label>Amount(INR):</label>
                    <asp:TextBox runat="server" ID="txtAmount" CssClass="formContrl"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button runat="server" ID="btnPayAmount" Text="Pay Now" OnClick="btnPayAmount_Click" CssClass="btn" />
                    <%--<button id="btnPay" class="btn">Pay With Razorpay</button>--%>
                </div>
                <div class="formGroup" style="text-align: center;">
                    <asp:Label runat="server" ID="lblError" Text="" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                </div>
            </div>
        </form>
    </div>

</body>
</html>
