#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References
using HotLeadInfo;
#region Application References

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion Microsoft Application Block References

namespace HotLeadBL.Transactions
{
    public class UserLogBL
    {
        public bool SaveUserLog(UserLogInfo ObjUserLog, ref Int64 lngReturn, string logid)
        {
            bool returnValue = false;
            bool bNew = false;
            string spNameString = string.Empty;

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            spNameString = "[USP_Save_UserLog]";

            DbCommand dbCommand = null;
            try
            {

                if (logid == "")
                {
                    bNew = false;
                    ObjUserLog.Log_Id = 0;
                }
                else
                {
                    ObjUserLog.Log_Id = Int64.Parse(logid);
                    bNew = true;
                }

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters
                dbDatabase.AddInParameter(dbCommand, "@Log_Id", DbType.Int64, ObjUserLog.Log_Id);
                dbDatabase.AddInParameter(dbCommand, "@User_Id", DbType.Int64, ObjUserLog.User_Id);
                dbDatabase.AddInParameter(dbCommand, "@Login_Ip", DbType.String, ObjUserLog.Login_Ip);
                dbDatabase.AddInParameter(dbCommand, "@Log_Status_Id", DbType.Int32, ObjUserLog.Log_Status_Id);
                dbDatabase.AddInParameter(dbCommand, "@Login_DateTime", DbType.DateTime, ObjUserLog.Login_DateTime);
                dbDatabase.AddInParameter(dbCommand, "@Logout_time", DbType.DateTime, ObjUserLog.Logout_time);
                dbDatabase.AddInParameter(dbCommand, "@Session_Id", DbType.String, ObjUserLog.Session_Id);
                dbDatabase.AddInParameter(dbCommand, "@CookieID", DbType.String, ObjUserLog.CookieID);
                dbDatabase.AddInParameter(dbCommand, "@bNew", DbType.Boolean, bNew);

                dbDatabase.AddOutParameter(dbCommand, "@ID", DbType.Int64, 1);

                dbDatabase.ExecuteNonQuery(dbCommand);


                lngReturn = Int64.Parse(dbDatabase.GetParameterValue(dbCommand, "@Id").ToString());



                returnValue = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return returnValue;
        }
        public bool Perform_LogOut(int UserID, DateTime logOutDate, int LogID, int logStatusId)
        {
            bool returnValue = false;
            string spNameString = string.Empty;

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            spNameString = "[USP_Perform_LogOut]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
                dbDatabase.AddInParameter(dbCommand, "@LogoutDate", DbType.DateTime, logOutDate);
                dbDatabase.AddInParameter(dbCommand, "@LogID", DbType.Int32, LogID);
                dbDatabase.AddInParameter(dbCommand, "@logStatusId", DbType.Int32, logStatusId);
                dbDatabase.ExecuteNonQuery(dbCommand);

                returnValue = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return returnValue;
        }

        public DataSet GetUserSession(int USER_ID)
        {
            //Decalaring Users object collection
            DataSet dsUserModules = new DataSet();
            string spNameString = string.Empty;

            //Setting Connection


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name
            spNameString = "[USP_CHECK_USER_SESSION]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@USER_ID", DbType.Int32, USER_ID);


                //Executing stored procedure
                dsUserModules = dbDatabase.ExecuteDataSet(dbCommand);
            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return dsUserModules;


        }
    }
}
