using Razorpay.Api;
using RazorpaySampleApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentPending : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            //string leadId = objRes.DecryptText(lead_id);
            //DataSet ds = objRes.Get_Payment_Details_By_trxid("132182036661067274");

        }
        catch (Exception ex)
        {
            divMainContent.Visible = false;
            divMsg.Visible = true;
            lblMsg.Text = "Something went wrong..Please try after some time.!" + ex.Message;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            //img.ImageUrl = "Content/assest/images/error.gif";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        try
        {
            RazorPayResponseClass objRes = new RazorPayResponseClass();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            DataSet ds = new DataSet();
            StringBuilder response = new StringBuilder();
            if (string.IsNullOrEmpty(txtLeadId.Text))
            {
                divMsg.Visible = true;
                lblMsg.Text = "Please enter lead id..!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            ds = objRes.GetOrderDetailsByLead(txtLeadId.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_live_iMs21jlabWW76k", "xXCiAPBjGJ38qX9aoiXWELE8");
                    string rpol_order_id = Convert.ToString(ds.Tables[0].Rows[i]["rpol_order_id"]);
                    List<Payment> result = client.Order.Fetch(rpol_order_id).Payments();
                    if (result != null && result.Count > 0)
                    {
                        foreach (Payment payment in result)
                        {
                            if (payment != null)
                            {
                                if (payment.Attributes["status"] != null)
                                {
                                    RazorPayPendingEnity enity = new RazorPayPendingEnity();
                                    string bank_transaction_id = Convert.ToString(payment.Attributes["acquirer_data"]["bank_transaction_id"]);

                                    if (bank_transaction_id != null)
                                    {
                                        if (bank_transaction_id.Length > 50)
                                        {
                                            bank_transaction_id = bank_transaction_id.Substring(0, 50);
                                        }
                                    }
                                    enity.bank_transaction_id = bank_transaction_id;
                                    enity.address = payment.Attributes["notes"]["address"];
                                    enity.entity = Convert.ToString(payment.Attributes["entity"]);
                                    enity.amount = Convert.ToDecimal(payment.Attributes["amount"]);
                                    enity.currency = Convert.ToString(payment.Attributes["currency"]);
                                    enity.status = Convert.ToString(payment.Attributes["status"]);
                                    enity.order_id = Convert.ToString(payment.Attributes["order_id"]);
                                    enity.invoice_id = Convert.ToString(payment.Attributes["invoice_id"]);
                                    enity.international = Convert.ToString(payment.Attributes["international"]);
                                    enity.method = Convert.ToString(payment.Attributes["method"]);
                                    enity.amount_refunded = Convert.ToDecimal(payment.Attributes["amount_refunded"]);
                                    enity.refund_status = Convert.ToString(payment.Attributes["refund_status"]);
                                    enity.captured = Convert.ToString(payment.Attributes["captured"]);
                                    enity.description = Convert.ToString(payment.Attributes["description"]);
                                    enity.card_id = Convert.ToString(payment.Attributes["card_id"]);
                                    enity.bank = Convert.ToString(payment.Attributes["bank"]);
                                    enity.wallet = Convert.ToString(payment.Attributes["wallet"]);
                                    enity.vpa = Convert.ToString(payment.Attributes["vpa"]);
                                    enity.email = Convert.ToString(payment.Attributes["email"]);
                                    enity.contact = Convert.ToString(payment.Attributes["contact"]);
                                    enity.fee = Convert.ToString(payment.Attributes["fee"]);
                                    enity.tax = Convert.ToString(payment.Attributes["tax"]);
                                    enity.error_code = Convert.ToString(payment.Attributes["error_code"]);
                                    enity.error_description = Convert.ToString(payment.Attributes["error_description"]);
                                    enity.error_source = Convert.ToString(payment.Attributes["error_source"]);
                                    enity.error_step = Convert.ToString(payment.Attributes["error_step"]);
                                    enity.error_reason = Convert.ToString(payment.Attributes["error_reason"]);
                                    enity.created_at = Convert.ToString(payment.Attributes["created_at"]);
                                    enity.trx_id = "123";
                                    enity.id = (Convert.ToString(payment.Attributes["id"]));
                                    enity.exception = Convert.ToString(payment.Attributes["error_reason"]);

                                    int returnResult = 0;
                                    returnResult = objRes.Insert_Razor_Pay_Response_Log_Not_In_Log_Table(enity);
                                    if (returnResult > 0)
                                    {
                                        response.Append("Success");
                                    }
                                    else
                                    {
                                        response.Append("Failed");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        response.Append("No Payment Found.!!");
                    }
                }
            }
            else
            {
                response.Append("No data found");
            }
            divMsg.Visible = true;
            lblMsg.Text = response.ToString();
            if (response.ToString().Equals("Success", StringComparison.OrdinalIgnoreCase))
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            divMsg.Visible = true;
            lblMsg.Text = ex.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
}