using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentInitiateClass
/// </summary>
public class PaymentInitiateEntity
{
    public string name { get; set; }
    public string email { get; set; }
    public string contactNumber { get; set; }
    public string address { get; set; }
    public int amount { get; set; }
    public string transactionId { get; set; }

    public class PaymentRefundModel
    {
        public string payment_id { get; set; }
    }

    public class PaymentRefundEntity
    {
        public string name { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
        public string address { get; set; }
        public int amount { get; set; }
        public string transactionId { get; set; }
        public string paymentId { get; set; }
    }
}