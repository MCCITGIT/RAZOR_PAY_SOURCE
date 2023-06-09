using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using System.Data.SqlClient;
namespace RazorpaySampleApp.App_Code.DataAccess
{
    public abstract class DBHelper
    {
        protected abstract string GetConnectionString();
        public abstract DbConnection OpenConnection();
        public abstract bool CloseConnection(ref DbConnection connectionObject);
        public abstract DataSet ExecuteDataSet(string commandText, CommandType commandType, params IDbDataParameter[] parameters);

        public abstract int ExecuteNonQuery(string commandText, CommandType commandType, params IDbDataParameter[] parameters);
        public abstract int ExecuteNonQuery(ref DbConnection connectionObject, string commandText, System.Data.CommandType commandType, params System.Data.IDbDataParameter[] parameters);
        public abstract int ExecuteNonQuery(SqlConnection connectionObject, SqlTransaction sqlTrans, string commandText, CommandType commandType, bool OutputParamter, params IDbDataParameter[] parameters);
    }
}