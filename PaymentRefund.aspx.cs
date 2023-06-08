using Razorpay.Api;
using RazorpaySampleApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;

public partial class PaymentRefund : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AddAttribute();
            RazorPayResponseClass objRes = new RazorPayResponseClass();
            //string leadId = objRes.DecryptText(lead_id);
            //DataSet ds = objRes.Get_Payment_Details_By_trxid("132182036661067274");
            DataSet ds = objRes.Get_Payment_Details_By_trxid("132184532542124214");
            if ((!(ds == null) && ds.Tables.Count > 0 && !(ds.Tables[0] == null) && ds.Tables[0].Rows.Count > 0))
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
                hdnPaymentId.Value = Convert.ToString(ds.Tables[0].Rows[0]["payment_id"]);
                hdnTrxId.Value = Convert.ToString(ds.Tables[0].Rows[0]["trx_id"]);
                txtAmount.Text = lp_payable_amt.ToString();
                hdnAmount.Value = lp_payable_amt.ToString();
                txAmountPaid.Text = lp_payable_amt.ToString();
            }
            else
            {
                divMainContent.Visible = false;
                divMsg.Visible = true;
                lblMsg.Text = "Something went wrong or ref no is not valid!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        catch (Exception ex)
        {
            divMainContent.Visible = false;
            divMsg.Visible = true;
            lblMsg.Text = "Something went wrong..Please try after some time.!" + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            //img.ImageUrl = "Content/assest/images/error.gif";
        }
    }
    private void AddAttribute()
    {
        txtAddress.Attributes.Add("ReadOnly", "true");
        //txtAmount.Attributes.Add("ReadOnly", "true");
        txtContactNumber.Attributes.Add("ReadOnly", "true");
        txtCustomerName.Attributes.Add("ReadOnly", "true");
        txtEmailID.Attributes.Add("ReadOnly", "true");
    }

    protected void btnRefund_Click(object sender, EventArgs e)
    {
        string paymentId = string.Empty;
        string status = string.Empty;
        RazorPayResponseClass objRes = new RazorPayResponseClass();
        int returnResult = 0;
        decimal actualAmount = 0;
        decimal amount = 0;
        decimal validateDecimal = 0;
        try
        {
            if (!String.IsNullOrWhiteSpace(hdnPaymentId.Value))
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                paymentId = hdnPaymentId.Value;
                string key = "rzp_live_iMs21jlabWW76k";
                string secret = "xXCiAPBjGJ38qX9aoiXWELE8";
                //string key = "rzp_test_ylrqcxWYXOUjPj";
                //string secret = "w0xUJEi9tHfGMzrEZ6Z8bJqO";
                RazorpayClient client = new RazorpayClient(key, secret);
                Refund refund = new Refund();
                if (!string.IsNullOrWhiteSpace(hdnAmount.Value))
                {
                    actualAmount = Convert.ToDecimal(hdnAmount.Value);
                }
                if (!String.IsNullOrWhiteSpace(txtAmount.Text))
                {
                    amount = Convert.ToDecimal(txtAmount.Text);
                }
                //if (actualAmount > amount)
                //{
                //    //Partial refund
                //    Dictionary<string, object> data = new Dictionary<string, object>();
                //    data.Add("amount", amount);
                //    refund = new Payment((string)paymentId).Refund(data);
                //}
                //else
                //{
                //    refund = new Payment((string)paymentId).Refund();
                //}

                refund = new Payment((string)paymentId).Refund();
                //Payment payment = client.Payment.Fetch(paymentId);

                //full refund
                //Refund refund = new Payment((string)paymentId).Refund();
                //Refund refund = payment.Refund();
                if (refund.Attributes != null)
                {
                    status = refund.Attributes["status"];
                    RefundEntity entity = new RefundEntity();
                    entity.id = refund.Attributes["id"];
                    entity.trx_id = hdnTrxId.Value;
                    entity.entity = refund.Attributes["entity"];
                    entity.amount = refund.Attributes["amount"];
                    entity.currency = refund.Attributes["currency"];
                    entity.payment_id = refund.Attributes["payment_id"];
                    entity.receipt = Convert.ToString(refund.Attributes["receipt"]);
                    //entity.acquirer_data.arn = string.Empty;
                    entity.created_at = Convert.ToString(refund.Attributes["created_at"]);
                    entity.batch_id = Convert.ToString(refund.Attributes["batch_id"]);
                    entity.processed_at = Convert.ToString(refund.Attributes["processed_at"]);
                    entity.refund_type = refund.Attributes["refund_type"];
                    entity.status = refund.Attributes["status"];
                    entity.speed_processed = refund.Attributes["speed_processed"];
                    entity.speed_requested = refund.Attributes["speed_requested"];
                    entity.exception_msg = string.Empty;

                    returnResult = objRes.Insert_Refund_Details(entity);
                }
                if (status == "processed")
                {
                    divMainContent.Visible = false;
                    divMsg.Visible = true;
                    lblMsg.Text = "Refund processed.!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else if (status == "pending")
                {
                    divMainContent.Visible = false;
                    divMsg.Visible = true;
                    lblMsg.Text = "Refund processed.!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else if (status == "failed")
                {
                    divMainContent.Visible = false;
                    divMsg.Visible = true;
                    lblMsg.Text = "Refund Failed.!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    divMainContent.Visible = false;
                    divMsg.Visible = true;
                    lblMsg.Text = "Something went wrong.!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                //Partial refund
                //Dictionary<string, object> data = new Dictionary<string, object>();
                //data.Add("amount", "500100");
                //Refund refundparial =  payment.Refund(data);
            }
        }
        catch (Exception ex)
        {
            divMainContent.Visible = false;
            divMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Green;

            RefundEntity entity = new RefundEntity();
            entity.id = paymentId;
            entity.trx_id = hdnTrxId.Value;
            entity.entity = null;
            entity.amount = amount;
            entity.currency = "INR";
            entity.payment_id = paymentId;
            entity.receipt = null;
            entity.created_at = null;
            entity.batch_id = null;
            entity.processed_at = null;
            entity.refund_type = null;
            entity.status = ex.Message;
            entity.speed_processed = null;
            entity.speed_requested = null;
            entity.exception_msg = ex.Message.ToString();
            returnResult = objRes.Insert_Refund_Details(entity);
        }
    }

}