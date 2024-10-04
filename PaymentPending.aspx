<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentPending.aspx.cs" Inherits="PaymentPending" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Pending</title>
    <link href="Content/assest/css/style.css" rel="stylesheet" />
    <style>
        /* Loader styles */
        .loader {
            display: none; /* Initially hidden */
            border: 8px solid #f3f3f3;
            border-radius: 50%;
            border-top: 8px solid #3498db;
            width: 50px;
            height: 50px;
            animation: spin 1s linear infinite;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }

        .overlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5);
        }
    </style>
    <script type="text/javascript">
        function showLoader() {
            document.getElementById("loaderOverlay").style.display = "block";
            return true; // Allow form submission
        }

        function hideLoader() {
            document.getElementById("loaderOverlay").style.display = "none";
        }
    </script>
</head>
<body>
    <div class="mainSection">
        <div class="logoArea">
            <img class="logoTop" src="Content/assest/images/berger-paints-logo.png" alt="logo" />
        </div>
        <form runat="server">
            <div class="formListView" id="divMainContent" runat="server">
                <div class="formGroup">
                    <label>Lead Id:</label>
                    <asp:TextBox runat="server" ID="txtLeadId" CssClass="formContrl" Placeholder="Enter Lead Id"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnProcess" runat="server" CssClass="btn" Text="Proceed To Fetch"
                                OnClick="btnProcess_Click" 
                                  OnClientClick="if(confirm('Are you sure you want to submit?')) { showLoader(); return true; } else { return false; }" /> 
                </div>
            </div>
            <div class="notifyAlt mainSection" id="divMsg" runat="server" visible="false">
                <asp:Label runat="server" ID="lblMsg" CssClass="notifySms"></asp:Label>
            </div>
        </form>
    </div>

    <!-- Loader element -->
    <div class="overlay" id="loaderOverlay">
        <div class="loader" style="text-align: center">
            <img src="Content/Loading_2.gif" />
        </div>
    </div>
</body>
</html>
