using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace RazorpaySampleApp.App_Code.DataAccess
{
    public sealed class DBFactory
    {
        public static DBHelper GetHelper()
        {
            SqlHelper lDBHelper = new SqlHelper();
            return lDBHelper;
        }
    }
}