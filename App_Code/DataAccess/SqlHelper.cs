using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Data.SqlClient;
using System.Web;

namespace RazorpaySampleApp.App_Code.DataAccess
{
    public class SqlHelper : DBHelper
    {
        public static bool DatabaseException;
        private string returnUrl = string.Empty;
        private SqlConnectionStringBuilder crConnectionInfo = new SqlConnectionStringBuilder();
        private System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
        private System.Exception sqlEx;
        public SqlHelper()
        {
            try
            {
                returnUrl = HttpContext.Current.Request.QueryString["ReturnUrl"];
            }
            catch (Exception ex)
            {
                returnUrl = string.Empty;
            }
        }
        // Gets the connection String of the Sim database
        protected override string GetConnectionString()
        {
            // Dim str As String = configurationAppSettings.GetValue("ConStr", GetType(System.String))
            SqlConnectionStringBuilder crConnectionInfo = new SqlConnectionStringBuilder();
            {
                var withBlock = crConnectionInfo;
                withBlock.DataSource = configurationAppSettings.GetValue("DBServerName", typeof(System.String)).ToString();
                withBlock.InitialCatalog = configurationAppSettings.GetValue("DBName", typeof(System.String)).ToString();
                withBlock.UserID = configurationAppSettings.GetValue("DBUserName", typeof(System.String)).ToString();
                withBlock.Password = configurationAppSettings.GetValue("DBPassword", typeof(System.String)).ToString();
            }
            return crConnectionInfo.ToString();
        }
        // Helps to open the connection with the database
        public override System.Data.Common.DbConnection OpenConnection()
        {
            SqlConnection connectionObject = new SqlConnection();
            try
            {
                connectionObject.ConnectionString = GetConnectionString();
                connectionObject.Open();
            }
            catch (Exception ex)
            {
            }
            return connectionObject;
        }
        //Helps to close the connection with the database
        public override bool CloseConnection(ref System.Data.Common.DbConnection connectionObject)
        {
            bool connectionClosed = false;
            try
            {
                if ((connectionObject != null))
                {
                    if ((connectionObject.State != ConnectionState.Broken && connectionObject.State != ConnectionState.Closed))
                    {
                        connectionObject.Close();
                        connectionClosed = true;
                    }
                    else
                    {
                        connectionClosed = false;
                    }
                }
                else
                {
                    connectionClosed = false;
                }
            }
            catch (Exception ex)
            {
                //validateException()
                // throw ex;
            }
            return connectionClosed;
        }
        //Helps to execute the stored procedure for update and retrieval operation
        public override System.Data.DataSet ExecuteDataSet(string commandText, System.Data.CommandType commandType, params System.Data.IDbDataParameter[] parameter)
        {
            return ExecuteDataSet(commandText, commandType, 0, -1, parameter);
        }
        //Helps to execute the stored procedure for update and retrieval operation
        public DataSet ExecuteDataSet(string commandText, System.Data.CommandType commandType, int startRecordNum, int maxRecordsToFetch, params System.Data.IDbDataParameter[] parameters)
        {
            SqlConnection connectionObject = null;
            SqlCommand commandObject = default(SqlCommand);
            SqlDataAdapter adapterObject = default(SqlDataAdapter);
            DataSet resultSet = null;
            // Try
            connectionObject = new SqlConnection();
            commandObject = new SqlCommand();
            connectionObject.ConnectionString = GetConnectionString();
            commandObject.Connection = connectionObject;
            commandObject.CommandText = commandText;
            commandObject.CommandType = commandType;
            commandObject.CommandTimeout = 3600;
            commandObject.Parameters.AddRange(parameters);
            try
            {
                connectionObject.Open();

            }
            catch (Exception sqlEx)
            {
                //throw sqlEx;
            }

            adapterObject = new SqlDataAdapter();
            adapterObject.SelectCommand = commandObject;
            resultSet = new DataSet();

            try
            {
                if (!(maxRecordsToFetch == -1))
                {
                    adapterObject.Fill(resultSet, startRecordNum, maxRecordsToFetch, "Table1");
                }
                else
                {
                    adapterObject.Fill(resultSet);
                }
            }
            catch (Exception sqlEx)
            {
                DatabaseException = true;
                //throw sqlEx;
            }
            finally
            {
                if ((connectionObject != null))
                {
                    if (connectionObject.State != ConnectionState.Closed)
                    {
                        connectionObject.Close();
                    }
                    connectionObject.Dispose();
                }
            }
            return resultSet;
        }
        //Helps to execute the stored procedure for insert operation
        public override int ExecuteNonQuery(string commandText, System.Data.CommandType commandType, params System.Data.IDbDataParameter[] parameters)
        {
            SqlConnection connectionObject = null;
            SqlCommand commandObject = default(SqlCommand);
            int numRowsAffected = 0;
            //Try
            connectionObject = new SqlConnection();
            commandObject = new SqlCommand();
            connectionObject.ConnectionString = GetConnectionString();
            commandObject.Connection = connectionObject;
            commandObject.CommandText = commandText;
            commandObject.CommandType = commandType;
            commandObject.Parameters.AddRange(parameters);
            try
            {
                connectionObject.Open();
            }
            catch (Exception sqlEx)
            {
                DatabaseException = true;
                //throw sqlEx;
            }
            try
            {
                numRowsAffected = commandObject.ExecuteNonQuery();
            }
            catch (Exception sqlEx)
            {
                DatabaseException = true;
                //throw sqlEx;
            }
            finally
            {
                if ((connectionObject != null))
                {
                    if (connectionObject.State != ConnectionState.Closed)
                    {
                        connectionObject.Close();
                    }
                    connectionObject.Dispose();
                }
            }
            return numRowsAffected;
        }
        //Helps to execute the stored procedure for insert operation
        public override int ExecuteNonQuery(ref System.Data.Common.DbConnection connectionObject, string commandText, System.Data.CommandType commandType, params System.Data.IDbDataParameter[] parameters)
        {

            SqlCommand commandObject = default(SqlCommand);
            int numRowsAffected = 0;
            try
            {
                SqlConnection connectObject = (SqlConnection)connectionObject;
                commandObject = new SqlCommand();
                commandObject.Connection = connectObject;
                commandObject.CommandText = commandText;
                commandObject.CommandType = commandType;
                commandObject.Parameters.AddRange(parameters);

                numRowsAffected = commandObject.ExecuteNonQuery();
            }
            catch (Exception lException)
            {
                DatabaseException = true;
                //throw lException;
            }
            return numRowsAffected;
        }
        //Created by Rajesh Daniel on 10/11/2008
        //Function to Insert/Update/Delete values in Database
        public override int ExecuteNonQuery(SqlConnection connectionObject, SqlTransaction sqlTrans, string commandText, CommandType commandType, bool OutputParameter, params IDbDataParameter[] parameters)
        {
            SqlCommand commandObject = new SqlCommand();
            int numRowsAffected = 0;
            try
            {
                //SqlConnection connectionObject = new SqlConnection();

                //connectionObject.ConnectionString = GetConnectionString();
                commandObject.Connection = connectionObject;
                commandObject.Transaction = sqlTrans;
                commandObject.CommandText = commandText;
                commandObject.CommandType = commandType;
                commandObject.Parameters.AddRange(parameters);

                //connectionObject.Open();

                numRowsAffected = commandObject.ExecuteNonQuery();
                if ((OutputParameter))
                {
                    if (numRowsAffected > 0)
                    {
                        if (parameters[0] != null)
                        {
                            numRowsAffected = Convert.ToInt32(parameters[0].Value);
                        }
                        else
                        {
                            numRowsAffected = Int32.MinValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
               
            }
            return numRowsAffected;
        }
    }
}