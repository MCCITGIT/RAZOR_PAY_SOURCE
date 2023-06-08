using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RazorpaySampleApp
{

    public partial class Default : System.Web.UI.Page
    {
        public string orderId;
        public string TransactionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string en = Encryption.encrypt("LD-1911-000604");
            //string tn = Encryption.encrypt("132184532542124214");
            lblmsg.Text = "";
            if (Request.QueryString["LID"] != null && Request.QueryString["TID"] != null)
            {
                try
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    AddAttribute();

                    string lead_id = Convert.ToString(Request.QueryString["LID"]);
                    string transaction_id = Convert.ToString(Request.QueryString["TID"]);

                    hdnLeadId.Value = lead_id;
                    hdnTransactionId.Value = transaction_id;

                    //string transactionId = "132184532542124214";
                    //string leadId = "LD-1911-000604";

                    RazorPayResponseClass objRes = new RazorPayResponseClass();
                    string leadId = Encryption.Decrypt(lead_id);
                    string transactionId = Encryption.Decrypt(transaction_id);

                    DataSet ds = objRes.get_payment_data_by_lead_id(leadId, transactionId);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string CustName = Convert.ToString(ds.Tables[0].Rows[0]["CustName"]);
                        txtCustomerName.Text = CustName;
                        string email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);
                        txtEmailID.Text = email;
                        string mobileNo = Convert.ToString(ds.Tables[0].Rows[0]["mobileNo"]);
                        txtContactNumber.Text = mobileNo;
                        string adress = Convert.ToString(ds.Tables[0].Rows[0]["adress"]);
                        txtAddress.Text = adress;
                        //decimal lp_payable_amt = 1;
                        decimal lp_payable_amt = Convert.ToDecimal(ds.Tables[0].Rows[0]["lp_payable_amt"]);
                       
                        txtAmount.Text = lp_payable_amt.ToString();
                        string PaidStatus = Convert.ToString(ds.Tables[0].Rows[0]["PaidStatus"]);
                        if (PaidStatus == "PAID")
                        {
                            lblmsg.Text = "Payment already done.";
                            idMsg.Visible = true;
                            idTable.Visible = false;
                            btnPayAmount.Visible = false;
                        }
                        else
                        {
                            idMsg.Visible = false;
                            idTable.Visible = true;
                            btnPayAmount.Visible = true;
                        }
                        //Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_live_iMs21jlabWW76k", "xXCiAPBjGJ38qX9aoiXWELE8");

                        //var fetch1 = client.Order.Fetch("order_LhwJ9SiC2KwQGV");
                    }
                    else
                    {
                        lblmsg.Text = "Invalid data..";
                        idMsg.Visible = true;
                        idTable.Visible = false;
                        btnPayAmount.Visible = false;
                    }
                }
                catch (Exception)
                {
                    lblmsg.Text = "Sorry! Bad Request..";
                    idMsg.Visible = true;
                    idTable.Visible = false;
                    btnPayAmount.Visible = false;
                }
            }
            else
            {
                lblmsg.Text = "Sorry! Bad Request..";
                idMsg.Visible = true;
                idTable.Visible = false;
                btnPayAmount.Visible = false;
            }

        }
        private void AddAttribute()
        {
            txtAddress.Attributes.Add("ReadOnly", "true");
            txtAmount.Attributes.Add("ReadOnly", "true");
            txtContactNumber.Attributes.Add("ReadOnly", "true");
            txtCustomerName.Attributes.Add("ReadOnly", "true");
            txtEmailID.Attributes.Add("ReadOnly", "true");
        }

        protected void btnPayAmount_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            RazorPayResponseClass objRes = new RazorPayResponseClass();
            OrderDetails ORResponse = new OrderDetails();
            string leadId = objRes.DecryptText(hdnLeadId.Value);
            string transactionId = objRes.DecryptText(hdnTransactionId.Value);
            //string transactionId = "132184532542124214";
            //string leadId = "LD-1911-000604";
            try
            {

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                

                DataSet ds = objRes.get_payment_data_by_lead_id(leadId, transactionId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    string CustName = Convert.ToString(ds.Tables[0].Rows[0]["CustName"]);
                    txtCustomerName.Text = CustName;
                    string email = Convert.ToString(ds.Tables[0].Rows[0]["email"]);
                    txtEmailID.Text = email;
                    string mobileNo = Convert.ToString(ds.Tables[0].Rows[0]["mobileNo"]);
                    txtContactNumber.Text = mobileNo;
                    string adress = Convert.ToString(ds.Tables[0].Rows[0]["adress"]);
                    txtAddress.Text = adress;
                    decimal lp_payable_amt = Convert.ToDecimal(ds.Tables[0].Rows[0]["lp_payable_amt"]);
                    //lp_payable_amt = 1;
                    txtAmount.Text = lp_payable_amt.ToString();
                    string PaidStatus = Convert.ToString(ds.Tables[0].Rows[0]["PaidStatus"]);
                    

                    TransactionId = transactionId;

                    Dictionary<string, object> input = new Dictionary<string, object>();
                    input.Add("amount", lp_payable_amt * 100); // this amount should be same as transaction amount
                    input.Add("currency", "INR");
                    input.Add("receipt", transactionId);
                    input.Add("payment_capture", 0);

                    Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_live_iMs21jlabWW76k", "xXCiAPBjGJ38qX9aoiXWELE8");
                    //Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_ylrqcxWYXOUjPj", "w0xUJEi9tHfGMzrEZ6Z8bJqO");

                    Razorpay.Api.Order orderResponse = client.Order.Create(input);
                    if (orderResponse.Attributes != null)
                    {

                        ORResponse.lead_id = leadId;
                        ORResponse.transaction_id = transactionId;
                        ORResponse.id = Convert.ToString(orderResponse.Attributes["id"]);
                        ORResponse.amount = Convert.ToDecimal(orderResponse.Attributes["amount"]);
                        ORResponse.amount_paid = Convert.ToDecimal(orderResponse.Attributes["amount_paid"]);
                        ORResponse.amount_due = Convert.ToDecimal(orderResponse.Attributes["amount_due"]);
                        ORResponse.currency = Convert.ToString(orderResponse.Attributes["currency"]);
                        ORResponse.status = Convert.ToString(orderResponse.Attributes["status"]);
                        ORResponse.attempts = Convert.ToInt32(orderResponse.Attributes["attempts"]);
                        ORResponse.created_at = Convert.ToInt32(orderResponse.Attributes["created_at"]);
                        ORResponse.error_msg = "";
                        int returnResult = objRes.Insert_Order_Log(ORResponse);
                        if (returnResult > 0)
                        {
                            orderId = Convert.ToString(ORResponse.id);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ClickToPayment()", true);
                        }
                        else
                        {
                            lblError.Text = "Ooops! Something went wrong. Try again after sometime.";
                        }
                    }
                    else
                    {
                        ORResponse.lead_id = leadId;
                        ORResponse.transaction_id = transactionId;
                        ORResponse.id = "";
                        ORResponse.amount = 0;
                        ORResponse.amount_paid = 0;
                        ORResponse.amount_due = 0;
                        ORResponse.currency = "";
                        ORResponse.status = "";
                        ORResponse.attempts = 0;
                        ORResponse.created_at = 0;
                        ORResponse.error_msg = "Order not created";
                        int returnResult = objRes.Insert_Order_Log(ORResponse);
                        lblError.Text = "Ooops! Something went wrong. Try again after sometime.";
                    }

                    //

                    //var fetch1 = client.Order.Fetch("order_LhzVAGzG7p8ltT");  

                }
            }
            catch (Exception ex)
            {
                ORResponse.lead_id = leadId;
                ORResponse.transaction_id = transactionId;
                ORResponse.id = "";
                ORResponse.amount = 0;
                ORResponse.amount_paid = 0;
                ORResponse.amount_due = 0;
                ORResponse.currency = "";
                ORResponse.status = "";
                ORResponse.attempts = 0;
                ORResponse.created_at = 0;
                ORResponse.error_msg = ex.ToString();
                int returnResult = objRes.Insert_Order_Log(ORResponse);
                lblError.Text = "Ooops! Something went wrong. Try again after sometime.";
            }
        }
    }
}