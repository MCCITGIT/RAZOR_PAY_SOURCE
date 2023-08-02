using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using RazorpaySampleApp.App_Code.DataAccess;
using System.Text;

namespace RazorpaySampleApp
{
    public class RazorPayResponseClass
    {
        public int Insert_Bill_Details(razorPayEnity entity)
        {
            int returnResult = 0;
            SqlConnection sqlConn = null;
            SqlTransaction sqlTrans = null;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[31];

                sqlParams[0] = new SqlParameter();
                sqlParams[0].ParameterName = "@address";
                sqlParams[0].DbType = DbType.String;
                sqlParams[0].Direction = System.Data.ParameterDirection.Input;
                sqlParams[0].Value = string.IsNullOrEmpty(entity.address) ? (object)DBNull.Value : entity.address; 

                sqlParams[1] = new SqlParameter();
                sqlParams[1].ParameterName = "@amount";
                sqlParams[1].DbType = DbType.Decimal;
                sqlParams[1].Direction = System.Data.ParameterDirection.Input;
                sqlParams[1].Value = entity.amount;


                sqlParams[2] = new SqlParameter();
                sqlParams[2].ParameterName = "@amount_refunded";
                sqlParams[2].DbType = DbType.Decimal;
                sqlParams[2].Direction = System.Data.ParameterDirection.Input;
                sqlParams[2].Value = entity.amount_refunded;

                sqlParams[3] = new SqlParameter();
                sqlParams[3].ParameterName = "@bank";
                sqlParams[3].DbType = DbType.String;
                sqlParams[3].Direction = System.Data.ParameterDirection.Input;
                sqlParams[3].Value = string.IsNullOrEmpty(entity.bank) ? (object)DBNull.Value : entity.bank; 

                sqlParams[4] = new SqlParameter();
                sqlParams[4].ParameterName = "@bank_transaction_id";
                sqlParams[4].DbType = DbType.String;
                sqlParams[4].Direction = System.Data.ParameterDirection.Input;
                sqlParams[4].Value = string.IsNullOrEmpty(entity.bank_transaction_id) ? (object)DBNull.Value : entity.bank_transaction_id; 

                sqlParams[5] = new SqlParameter();
                sqlParams[5].ParameterName = "@captured";
                sqlParams[5].DbType = DbType.String;
                sqlParams[5].Direction = System.Data.ParameterDirection.Input;
                sqlParams[5].Value = string.IsNullOrEmpty(entity.captured) ? (object)DBNull.Value : entity.captured; 

                sqlParams[6] = new SqlParameter();
                sqlParams[6].ParameterName = "@card_id";
                sqlParams[6].DbType = DbType.String;
                sqlParams[6].Direction = System.Data.ParameterDirection.Input;
                sqlParams[6].Value = string.IsNullOrEmpty(entity.card_id) ? (object)DBNull.Value : entity.card_id; 

                sqlParams[7] = new SqlParameter();
                sqlParams[7].ParameterName = "@contact";
                sqlParams[7].DbType = DbType.String;
                sqlParams[7].Direction = System.Data.ParameterDirection.Input;
                sqlParams[7].Value = string.IsNullOrEmpty(entity.contact) ? (object)DBNull.Value : entity.contact; 

                sqlParams[8] = new SqlParameter();
                sqlParams[8].ParameterName = "@created_at";
                sqlParams[8].DbType = DbType.String;
                sqlParams[8].Direction = System.Data.ParameterDirection.Input;
                sqlParams[8].Value = string.IsNullOrEmpty(entity.created_at) ? (object)DBNull.Value : entity.created_at; 

                sqlParams[9] = new SqlParameter();
                sqlParams[9].ParameterName = "@currency";
                sqlParams[9].DbType = DbType.String;
                sqlParams[9].Direction = System.Data.ParameterDirection.Input;
                sqlParams[9].Value = string.IsNullOrEmpty(entity.currency) ? (object)DBNull.Value : entity.currency; 

                sqlParams[10] = new SqlParameter();
                sqlParams[10].ParameterName = "@description";
                sqlParams[10].DbType = DbType.String;
                sqlParams[10].Direction = System.Data.ParameterDirection.Input;
                sqlParams[10].Value = string.IsNullOrEmpty(entity.description) ? (object)DBNull.Value : entity.description; 

                sqlParams[11] = new SqlParameter();
                sqlParams[11].ParameterName = "@email";
                sqlParams[11].DbType = DbType.String;
                sqlParams[11].Direction = System.Data.ParameterDirection.Input;
                sqlParams[11].Value = string.IsNullOrEmpty(entity.email) ? (object)DBNull.Value : entity.email; 

                sqlParams[12] = new SqlParameter();
                sqlParams[12].ParameterName = "@entity";
                sqlParams[12].DbType = DbType.String;
                sqlParams[12].Direction = System.Data.ParameterDirection.Input;
                sqlParams[12].Value = string.IsNullOrEmpty(entity.entity) ? (object)DBNull.Value : entity.entity; 

                sqlParams[13] = new SqlParameter();
                sqlParams[13].ParameterName = "@error_code";
                sqlParams[13].DbType = DbType.String;
                sqlParams[13].Direction = System.Data.ParameterDirection.Input;
                sqlParams[13].Value = string.IsNullOrEmpty(entity.error_code) ? (object)DBNull.Value : entity.error_code; 

                sqlParams[14] = new SqlParameter();
                sqlParams[14].ParameterName = "@error_description";
                sqlParams[14].DbType = DbType.String;
                sqlParams[14].Direction = System.Data.ParameterDirection.Input;
                sqlParams[14].Value = string.IsNullOrEmpty(entity.error_description) ? (object)DBNull.Value : entity.error_description; 

                sqlParams[15] = new SqlParameter();
                sqlParams[15].ParameterName = "@error_reason";
                sqlParams[15].DbType = DbType.String;
                sqlParams[15].Direction = System.Data.ParameterDirection.Input;
                sqlParams[15].Value = string.IsNullOrEmpty(entity.error_reason) ? (object)DBNull.Value : entity.error_reason; 

                sqlParams[16] = new SqlParameter();
                sqlParams[16].ParameterName = "@error_source";
                sqlParams[16].DbType = DbType.String;
                sqlParams[16].Direction = System.Data.ParameterDirection.Input;
                sqlParams[16].Value = string.IsNullOrEmpty(entity.error_source) ? (object)DBNull.Value : entity.error_source; 

                sqlParams[17] = new SqlParameter();
                sqlParams[17].ParameterName = "@error_step";
                sqlParams[17].DbType = DbType.String;
                sqlParams[17].Direction = System.Data.ParameterDirection.Input;
                sqlParams[17].Value = string.IsNullOrEmpty(entity.error_step) ? (object)DBNull.Value : entity.error_step; 

                sqlParams[18] = new SqlParameter();
                sqlParams[18].ParameterName = "@fee";
                sqlParams[18].DbType = DbType.String;
                sqlParams[18].Direction = System.Data.ParameterDirection.Input;
                sqlParams[18].Value = string.IsNullOrEmpty(entity.fee) ? (object)DBNull.Value : entity.fee; 

                sqlParams[19] = new SqlParameter();
                sqlParams[19].ParameterName = "@international";
                sqlParams[19].DbType = DbType.String;
                sqlParams[19].Direction = System.Data.ParameterDirection.Input;
                sqlParams[19].Value = string.IsNullOrEmpty(entity.international) ? (object)DBNull.Value : entity.international; 

                sqlParams[20] = new SqlParameter();
                sqlParams[20].ParameterName = "@invoice_id";
                sqlParams[20].DbType = DbType.String;
                sqlParams[20].Direction = System.Data.ParameterDirection.Input;
                sqlParams[20].Value = string.IsNullOrEmpty(entity.invoice_id) ? (object)DBNull.Value : entity.invoice_id; 

                sqlParams[21] = new SqlParameter();
                sqlParams[21].ParameterName = "@method";
                sqlParams[21].DbType = DbType.String;
                sqlParams[21].Direction = System.Data.ParameterDirection.Input;
                sqlParams[21].Value = string.IsNullOrEmpty(entity.method) ? (object)DBNull.Value : entity.method; 

                sqlParams[22] = new SqlParameter();
                sqlParams[22].ParameterName = "@order_id";
                sqlParams[22].DbType = DbType.String;
                sqlParams[22].Direction = System.Data.ParameterDirection.Input;
                sqlParams[22].Value = string.IsNullOrEmpty(entity.order_id) ? (object)DBNull.Value : entity.order_id; 

                sqlParams[23] = new SqlParameter();
                sqlParams[23].ParameterName = "@refund_status";
                sqlParams[23].DbType = DbType.String;
                sqlParams[23].Direction = System.Data.ParameterDirection.Input;
                sqlParams[23].Value = string.IsNullOrEmpty(entity.refund_status) ? (object)DBNull.Value : entity.refund_status; 

                sqlParams[24] = new SqlParameter();
                sqlParams[24].ParameterName = "@status";
                sqlParams[24].DbType = DbType.String;
                sqlParams[24].Direction = System.Data.ParameterDirection.Input;
                sqlParams[24].Value = string.IsNullOrEmpty(entity.status) ? (object)DBNull.Value : entity.status; 


                sqlParams[25] = new SqlParameter();
                sqlParams[25].ParameterName = "@tax";
                sqlParams[25].DbType = DbType.String;
                sqlParams[25].Direction = System.Data.ParameterDirection.Input;
                sqlParams[25].Value = string.IsNullOrEmpty(entity.tax) ? (object)DBNull.Value : entity.tax; 

                sqlParams[26] = new SqlParameter();
                sqlParams[26].ParameterName = "@vpa";
                sqlParams[26].DbType = DbType.String;
                sqlParams[26].Direction = System.Data.ParameterDirection.Input;
                sqlParams[26].Value = string.IsNullOrEmpty(entity.vpa) ? (object)DBNull.Value : entity.vpa; 

                sqlParams[27] = new SqlParameter();
                sqlParams[27].ParameterName = "@wallet";
                sqlParams[27].DbType = DbType.String;
                sqlParams[27].Direction = System.Data.ParameterDirection.Input;
                sqlParams[27].Value = string.IsNullOrEmpty(entity.wallet) ? (object)DBNull.Value : entity.wallet;

                sqlParams[28] = new SqlParameter();
                sqlParams[28].ParameterName = "@id";
                sqlParams[28].DbType = DbType.String;
                sqlParams[28].Direction = System.Data.ParameterDirection.Input;
                sqlParams[28].Value = entity.id;

                sqlParams[29] = new SqlParameter();
                sqlParams[29].ParameterName = "@trx_id";
                sqlParams[29].DbType = DbType.String;
                sqlParams[29].Direction = System.Data.ParameterDirection.Input;
                sqlParams[29].Value = entity.trx_id;

                sqlParams[30] = new SqlParameter();
                sqlParams[30].ParameterName = "@exception_msg";
                sqlParams[30].DbType = DbType.String;
                sqlParams[30].Direction = System.Data.ParameterDirection.Input;
                sqlParams[30].Value = string.IsNullOrEmpty(entity.exception) ? (object)DBNull.Value : entity.exception;

                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.Transaction = sqlTrans;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "[dbo].[insert_razor_pay_response_log]";
                sqlCmd.Parameters.AddRange(sqlParams);
                returnResult = sqlCmd.ExecuteNonQuery();
                if (returnResult > 0)
                {
                    sqlTrans.Commit();
                }
            }
            catch (Exception ex)
            {
                returnResult=-1;
            }
            finally
            {
                if ((sqlConn != null))
                    sqlConn.Close();
            }
            return returnResult;
        }

        public DataSet get_payment_data_by_lead_id(string lead_id, string pay_ref_no)
        {
            DataSet ds;
            SqlParameter[] sqlParams = new SqlParameter[2];

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@lead_id";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = lead_id;

            sqlParams[1] = new SqlParameter();
            sqlParams[1].ParameterName = "@pay_ref_no";
            sqlParams[1].DbType = DbType.Decimal;
            sqlParams[1].Direction = System.Data.ParameterDirection.Input;
            sqlParams[1].Value = pay_ref_no;

            ds = DBFactory.GetHelper().ExecuteDataSet("[dbo].[get_payment_data_by_lead_id_v1]", System.Data.CommandType.StoredProcedure, sqlParams);

            return ds;
        }

        public DataSet Get_Payment_Details_By_trxid(string pay_ref_no)
        {
            DataSet ds;
            SqlParameter[] sqlParams = new SqlParameter[1];    

            sqlParams[0] = new SqlParameter();
            sqlParams[0].ParameterName = "@pay_ref_no";
            sqlParams[0].DbType = DbType.String;
            sqlParams[0].Direction = System.Data.ParameterDirection.Input;
            sqlParams[0].Value = pay_ref_no;

            ds = DBFactory.GetHelper().ExecuteDataSet("[dbo].[Get_Payment_Details_By_trxid]", System.Data.CommandType.StoredProcedure, sqlParams);

            return ds;

        }

        public int Insert_Refund_Details(RefundEntity entity)
        {
            int returnResult = 0;
            SqlConnection sqlConn = null;
            SqlTransaction sqlTrans = null;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[15];

                sqlParams[0] = new SqlParameter();
                sqlParams[0].ParameterName = "@id";
                sqlParams[0].DbType = DbType.String;
                sqlParams[0].Direction = System.Data.ParameterDirection.Input;
                sqlParams[0].Value = entity.id;

                sqlParams[1] = new SqlParameter();
                sqlParams[1].ParameterName = "@amount";
                sqlParams[1].DbType = DbType.Decimal;
                sqlParams[1].Direction = System.Data.ParameterDirection.Input;
                sqlParams[1].Value = entity.amount;


                sqlParams[2] = new SqlParameter();
                sqlParams[2].ParameterName = "@trx_id";
                sqlParams[2].DbType = DbType.String;
                sqlParams[2].Direction = System.Data.ParameterDirection.Input;
                sqlParams[2].Value = entity.trx_id;

                sqlParams[3] = new SqlParameter();
                sqlParams[3].ParameterName = "@entity";
                sqlParams[3].DbType = DbType.String;
                sqlParams[3].Direction = System.Data.ParameterDirection.Input;
                sqlParams[3].Value = string.IsNullOrEmpty(entity.entity) ? (object)DBNull.Value : entity.entity;

                sqlParams[4] = new SqlParameter();
                sqlParams[4].ParameterName = "@currency";
                sqlParams[4].DbType = DbType.String;
                sqlParams[4].Direction = System.Data.ParameterDirection.Input;
                sqlParams[4].Value = string.IsNullOrEmpty(entity.currency) ? (object)DBNull.Value : entity.currency;

                sqlParams[5] = new SqlParameter();
                sqlParams[5].ParameterName = "@payment_id";
                sqlParams[5].DbType = DbType.String;
                sqlParams[5].Direction = System.Data.ParameterDirection.Input;
                sqlParams[5].Value = string.IsNullOrEmpty(entity.payment_id) ? (object)DBNull.Value : entity.payment_id;

                sqlParams[6] = new SqlParameter();
                sqlParams[6].ParameterName = "@receipt";
                sqlParams[6].DbType = DbType.String;
                sqlParams[6].Direction = System.Data.ParameterDirection.Input;
                sqlParams[6].Value = string.IsNullOrEmpty(entity.receipt) ? (object)DBNull.Value : entity.receipt;

                //sqlParams[7] = new SqlParameter();
                //sqlParams[7].ParameterName = "@arn";
                //sqlParams[7].DbType = DbType.String;
                //sqlParams[7].Direction = System.Data.ParameterDirection.Input;
                //sqlParams[7].Value = DBNull.Value;

                sqlParams[7] = new SqlParameter();
                sqlParams[7].ParameterName = "@status";
                sqlParams[7].DbType = DbType.String;
                sqlParams[7].Direction = System.Data.ParameterDirection.Input;
                sqlParams[7].Value = string.IsNullOrEmpty(entity.status) ? (object)DBNull.Value : entity.status;

                sqlParams[8] = new SqlParameter();
                sqlParams[8].ParameterName = "@refund_type";
                sqlParams[8].DbType = DbType.String;
                sqlParams[8].Direction = System.Data.ParameterDirection.Input;
                sqlParams[8].Value = string.IsNullOrEmpty(entity.refund_type) ? (object)DBNull.Value : entity.refund_type;

                sqlParams[9] = new SqlParameter();
                sqlParams[9].ParameterName = "@batch_id";
                sqlParams[9].DbType = DbType.String;
                sqlParams[9].Direction = System.Data.ParameterDirection.Input;
                sqlParams[9].Value = string.IsNullOrEmpty(entity.batch_id) ? (object)DBNull.Value : entity.batch_id;

                sqlParams[10] = new SqlParameter();
                sqlParams[10].ParameterName = "@processed_at";
                sqlParams[10].DbType = DbType.String;
                sqlParams[10].Direction = System.Data.ParameterDirection.Input;
                sqlParams[10].Value = string.IsNullOrEmpty(entity.processed_at) ? (object)DBNull.Value : entity.processed_at;

                sqlParams[11] = new SqlParameter();
                sqlParams[11].ParameterName = "@speed_processed";
                sqlParams[11].DbType = DbType.String;
                sqlParams[11].Direction = System.Data.ParameterDirection.Input;
                sqlParams[11].Value = string.IsNullOrEmpty(entity.speed_processed) ? (object)DBNull.Value : entity.speed_processed;

                sqlParams[12] = new SqlParameter();
                sqlParams[12].ParameterName = "@speed_requested";
                sqlParams[12].DbType = DbType.String;
                sqlParams[12].Direction = System.Data.ParameterDirection.Input;
                sqlParams[12].Value = string.IsNullOrEmpty(entity.speed_requested) ? (object)DBNull.Value : entity.speed_requested;

                sqlParams[13] = new SqlParameter();
                sqlParams[13].ParameterName = "@created_at";
                sqlParams[13].DbType = DbType.String;
                sqlParams[13].Direction = System.Data.ParameterDirection.Input;
                sqlParams[13].Value = string.IsNullOrEmpty(entity.created_at) ? (object)DBNull.Value : entity.created_at;

                sqlParams[14] = new SqlParameter();
                sqlParams[14].ParameterName = "@exception_msg";
                sqlParams[14].DbType = DbType.String;
                sqlParams[14].Direction = System.Data.ParameterDirection.Input;
                sqlParams[14].Value = string.IsNullOrEmpty(entity.exception_msg) ? (object)DBNull.Value : entity.exception_msg;            

                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.Transaction = sqlTrans;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "[dbo].[insert_razorpay_refund_details]";
                sqlCmd.Parameters.AddRange(sqlParams);
                returnResult = sqlCmd.ExecuteNonQuery();
                if (returnResult > 0)
                {
                    sqlTrans.Commit();
                }
            }
            catch (Exception ex)
            {
                returnResult = -1;
            }
            finally
            {
                if ((sqlConn != null))
                    sqlConn.Close();
            }
            return returnResult;
        }
        #region "Decrypt string"
        public string DecryptText(string input)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(input);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                return string.Empty;
            }
        }
        public int Insert_Order_Log(OrderDetails entity)
        {
            int returnResult = 0;
            SqlConnection sqlConn = null;
            SqlTransaction sqlTrans = null;
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[11];

                sqlParams[0] = new SqlParameter();
                sqlParams[0].ParameterName = "@rpol_lead_id";
                sqlParams[0].DbType = DbType.String;
                sqlParams[0].Direction = System.Data.ParameterDirection.Input;
                sqlParams[0].Value = entity.lead_id;

                sqlParams[1] = new SqlParameter();
                sqlParams[1].ParameterName = "@rpol_pay_ref_no";
                sqlParams[1].DbType = DbType.String;
                sqlParams[1].Direction = System.Data.ParameterDirection.Input;
                sqlParams[1].Value = entity.transaction_id;

                sqlParams[2] = new SqlParameter();
                sqlParams[2].ParameterName = "@rpol_order_id";
                sqlParams[2].DbType = DbType.String;
                sqlParams[2].Direction = System.Data.ParameterDirection.Input;
                sqlParams[2].Value = entity.id;

                sqlParams[3] = new SqlParameter();
                sqlParams[3].ParameterName = "@rpol_amount";
                sqlParams[3].DbType = DbType.Decimal;
                sqlParams[3].Direction = System.Data.ParameterDirection.Input;
                sqlParams[3].Value = entity.amount;

                sqlParams[4] = new SqlParameter();
                sqlParams[4].ParameterName = "@rpol_amount_paid";
                sqlParams[4].DbType = DbType.Decimal;
                sqlParams[4].Direction = System.Data.ParameterDirection.Input;
                sqlParams[4].Value = entity.amount_paid;

                sqlParams[5] = new SqlParameter();
                sqlParams[5].ParameterName = "@rpol_amount_due";
                sqlParams[5].DbType = DbType.Decimal;
                sqlParams[5].Direction = System.Data.ParameterDirection.Input;
                sqlParams[5].Value = entity.amount_due;

                sqlParams[6] = new SqlParameter();
                sqlParams[6].ParameterName = "@rpol_currency";
                sqlParams[6].DbType = DbType.String;
                sqlParams[6].Direction = System.Data.ParameterDirection.Input;
                sqlParams[6].Value = entity.currency;

                sqlParams[7] = new SqlParameter();
                sqlParams[7].ParameterName = "@rpol_status";
                sqlParams[7].DbType = DbType.String;
                sqlParams[7].Direction = System.Data.ParameterDirection.Input;
                sqlParams[7].Value = entity.status;

                sqlParams[8] = new SqlParameter();
                sqlParams[8].ParameterName = "@rpol_attempts";
                sqlParams[8].DbType = DbType.Int32;
                sqlParams[8].Direction = System.Data.ParameterDirection.Input;
                sqlParams[8].Value = entity.attempts;

                sqlParams[9] = new SqlParameter();
                sqlParams[9].ParameterName = "@rpol_created_at";
                sqlParams[9].DbType = DbType.Int32;
                sqlParams[9].Direction = System.Data.ParameterDirection.Input;
                sqlParams[9].Value = entity.created_at;

                sqlParams[10] = new SqlParameter();
                sqlParams[10].ParameterName = "@rpol_error_msg";
                sqlParams[10].DbType = DbType.String;
                sqlParams[10].Direction = System.Data.ParameterDirection.Input;
                sqlParams[10].Value = entity.error_msg;

                sqlConn = (SqlConnection)DBFactory.GetHelper().OpenConnection();
                sqlTrans = sqlConn.BeginTransaction();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlConn;
                sqlCmd.Transaction = sqlTrans;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "[dbo].[insert_lead_payments_razor_pay_order_log]";
                sqlCmd.Parameters.AddRange(sqlParams);
                returnResult = sqlCmd.ExecuteNonQuery();
                if (returnResult > 0)
                {
                    sqlTrans.Commit();
                }
            }
            catch (Exception ex)
            {
                returnResult = -1;
            }
            finally
            {
                if ((sqlConn != null))
                    sqlConn.Close();
            }
            return returnResult;
        }
        #endregion
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
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AcquirerData
    {
        public string arn { get; set; }
    }

    public class RefundEntity
    {
        public string id { get; set; }
        public string trx_id { get; set; }
        public string entity { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string payment_id { get; set; }
        public List<object> notes { get; set; }
        public string receipt { get; set; }
        //public AcquirerData acquirer_data { get; set; }
        public string created_at { get; set; }
        public string batch_id { get; set; }
        public string processed_at { get; set; }
        public string refund_type { get; set; }
        public string status { get; set; }
        public string speed_processed { get; set; }
        public string speed_requested { get; set; }
        public string exception_msg { get; set; }
    }
    public class OrderDetails
    {
        public string lead_id { get; set; }
        public string transaction_id { get; set; }
        public string id { get; set; }
        public decimal amount { get; set; }
        public decimal amount_paid { get; set; }
        public decimal amount_due { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public int attempts { get; set; }
        public int created_at { get; set; }
        public string error_msg { get; set; }
    }
}