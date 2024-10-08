﻿using System;
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
public class razorPayEnity
{
    public string trx_id { get; set; }
    public string id { get; set; }
    public string bank_transaction_id { get; set; }
    public string address { get; set; }
    public string entity { get; set; }
    public decimal amount { get; set; }
    public string currency { get; set; }
    public string status { get; set; }
    public string order_id { get; set; }
    public string invoice_id { get; set; }
    public string international { get; set; }

    public string method { get; set; }
    public decimal amount_refunded { get; set; }
    public string refund_status { get; set; }
    public string captured { get; set; }
    public string description { get; set; }
    public string card_id { get; set; }
    public string bank { get; set; }
    public string wallet { get; set; }
    public string vpa { get; set; }
    public string email { get; set; }
    public string contact { get; set; }
    public string fee { get; set; }
    public string tax { get; set; }
    public string error_code { get; set; }
    public string error_description { get; set; }
    public string error_source { get; set; }
    public string error_step { get; set; }
    public string error_reason { get; set; }
    public string created_at { get; set; }
    public string exception { get; set; }
}