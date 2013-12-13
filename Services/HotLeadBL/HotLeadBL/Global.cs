
/**********************************************************************
' MODULE       : CarsGlobals
' FILENAME     : CarsGlobals.cs
' AUTHOR       : Shravan
' CREATED      : 02-06-2012
' DESCRIPTION  : This class is used for global static values 
'*********************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;


namespace HotLeadBL
{
    public class Global
    {
        public static string EXCEPTION_POLICY = @"BusinessPolicy";
        public static string INSTANCE_NAME = "CarsConn";
        public static string INSTANCE_NAME4 = "CarSalesConn";
        public static string INSTANCE_NAME3 = "CentralDBConn";
        public static string INSTANCE_NAME5 = "CarLeadsDB";
        public static string INSTANCE_NAME6 = "HrData";

        public static string PASSWORD_PREFIX;
        public static string LOGIN_FAILED = @"Login Failed";
        public static string LOGIN_SUCCESS = @"Login Successful";

        public static DbTransaction Transaction;
        //public static DbConnection Connection;

        public static DbConnection Connection;
        public static DbTransaction qcTransaction;
    }
}
