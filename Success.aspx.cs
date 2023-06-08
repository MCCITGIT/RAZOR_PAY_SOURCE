using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;


namespace RazorpaySampleApp
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string GPaymentId= string.Empty;
            string GtransactionId = string.Empty;

            string paymentSuccess = string.Empty;
            razorPayEnity enity = new razorPayEnity();
            RazorPayResponseClass objRes = new RazorPayResponseClass();
            int returnResult = 0;
            try
            {
                //string paymentId = "pay_LhwJiWDsr1pwq7";
                //string transactionId = "132182036661067274";
                string paymentId = Request.Form["razorpay_payment_id"];
                string transactionId = Request.Params["razorpay_transaction_id"];
                GPaymentId = paymentId;
                GtransactionId = transactionId;


                string key = "rzp_live_iMs21jlabWW76k";
                string secret = "xXCiAPBjGJ38qX9aoiXWELE8";
                //string key = "rzp_test_ylrqcxWYXOUjPj";
                //string secret = "w0xUJEi9tHfGMzrEZ6Z8bJqO";

                RazorpayClient client = new RazorpayClient(key, secret);

                Dictionary<string, string> attributes = new Dictionary<string, string>();

                attributes.Add("razorpay_payment_id", paymentId);
                attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
                attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

                Utils.verifyPaymentSignature(attributes);



                Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

                // This code is for capture the payment 
                Dictionary<string, object> options = new Dictionary<string, object>();
                //options.Add("amount", payment.Attributes["amount"]);
                //Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
                //string amt = paymentCaptured.Attributes["amount"];
                if (payment.Attributes != null)
                {
                    //here creating entity with response data           
                    enity.bank_transaction_id = payment.Attributes["acquirer_data"]["bank_transaction_id"];
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
                    enity.trx_id = transactionId;
                    enity.id = paymentId;
                    enity.exception = Convert.ToString(payment.Attributes["error_reason"]);
                    paymentSuccess = payment.Attributes["status"];
                    //RazorPayResponseClass objRes = new RazorPayResponseClass();
                    //int returnResult = 0;
                    //Inserting log

                    returnResult = objRes.Insert_Bill_Details(enity);

                    if (payment.Attributes["status"] == "captured")
                    {
                        lblMsg.Text = "Payment successful";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        img.ImageUrl = "Content/assest/images/success.gif";
                    }
                    else if (payment.Attributes["status"] == "failed")
                    {
                        lblMsg.Text = "Payment Failed!";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        img.ImageUrl = "Content/assest/images/error.gif";
                    }
                    else
                    {
                        lblMsg.Text = "Payment Failed";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        img.ImageUrl = "Content/assest/images/error.gif";
                    }
                }
                else
                {
                    enity.bank_transaction_id = "";
                    enity.address = "";
                    enity.entity = "";
                    enity.amount = 0;
                    enity.currency = "";
                    enity.status = "";
                    enity.order_id = "";
                    enity.invoice_id = "";
                    enity.international = "";
                    enity.method = "";
                    enity.amount_refunded = 0;
                    enity.refund_status = "";
                    enity.captured = "";
                    enity.description = "";
                    enity.card_id = "";
                    enity.bank = "";
                    enity.wallet = "";
                    enity.vpa = "";
                    enity.email = "";
                    enity.contact = "";
                    enity.fee = "";
                    enity.tax = "";
                    enity.error_code = "";
                    enity.error_description = "";
                    enity.error_source = "";
                    enity.error_step = "";
                    enity.error_reason = "";
                    enity.created_at = "";
                    enity.trx_id = transactionId;
                    enity.id = paymentId;
                    enity.exception = "Fetch Payment Failed!";
                    returnResult = objRes.Insert_Bill_Details(enity);

                    lblMsg.Text = "Payment Failed!";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    img.ImageUrl = "Content/assest/images/error.gif";
                }
               
                //// Check payment made successfully

               

                //Please use below code to refund the payment   
                //Refund refund = new Razorpay.Api.Payment((string)paymentId).Refund();
                //Console.WriteLine(paymentId);
            }
            catch (Exception ex)
            { 
                //inserting log with exceptions
                enity.bank_transaction_id = "";
                enity.address = "";
                enity.entity = "";
                enity.amount = 0;
                enity.currency = "";
                enity.status = "";
                enity.order_id = "";
                enity.invoice_id = "";
                enity.international = "";
                enity.method = "";
                enity.amount_refunded = 0;
                enity.refund_status = "";
                enity.captured = "";
                enity.description = "";
                enity.card_id = "";
                enity.bank = "";
                enity.wallet = "";
                enity.vpa = "";
                enity.email = "";
                enity.contact = "";
                enity.fee = "";
                enity.tax = "";
                enity.error_code = "";
                enity.error_description = "";
                enity.error_source = "";
                enity.error_step = "";
                enity.error_reason = "";
                enity.created_at = "";
                enity.trx_id = GtransactionId;
                enity.id = GPaymentId;
                enity.exception = ex.ToString();
                returnResult = objRes.Insert_Bill_Details(enity);

                lblMsg.Text = "Payment Failed!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                img.ImageUrl = "Content/assest/images/error.gif";

               
                
            }
        }
    }
}