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

namespace HotLeadBL.CentralDBTransactions
{
    public class CentralDBMainBL
    {
        public DataSet PerformLogin(string UserName, string sPassword)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_Perform_SmartzLogin";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@SmartzUname", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@SmatzPassword", System.Data.DbType.String, sPassword);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveUserLog(UserLogInfo ObjUserLog, ref Int64 lngReturn, string logid)
        {
            bool returnValue = false;
            bool bNew = false;
            string spNameString = string.Empty;

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

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
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

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

        public DataSet GetSmartzUserDetails()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_GetSmartzUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetVoiceFileLocation()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_GetVoiceFileLocation";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSmartzUsersActiveData()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_GetSmartzUsersActiveData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSmartzSalesAgentsDetails()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_GetSmartzSalesAgentsDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSmartzSalesAgentsActiveData()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_GetSmartzSalesAgentsActiveData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSalesAgentDetails()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

                spNameString = "USP_GetSalesAgentDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetUserStatus()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

                spNameString = "USP_GetUserStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet SmartzCheckAgentExists(int Sale_Agent_Id, string American_Name)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

                spNameString = "USP_SmartzCheckAgentExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Sale_Agent_Id", System.Data.DbType.Int32, Sale_Agent_Id);
                dbDatabase.AddInParameter(dbCommand, "@American_Name", System.Data.DbType.String, American_Name);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet CheckAgentExists(string American_Name)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

                spNameString = "USP_CheckAgentExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@American_Name", System.Data.DbType.String, American_Name);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool SmartzSaveAgentData(int Sale_Agent_Id, string First_Name, string Last_Name, string American_Name, int Created_by, int IsActive, int Disable_By)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_SmartzSaveAgentData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Sale_Agent_Id", System.Data.DbType.Int32, Sale_Agent_Id);
                dbDatabase.AddInParameter(dbCommand, "@First_Name", System.Data.DbType.String, First_Name);
                dbDatabase.AddInParameter(dbCommand, "@Last_Name", System.Data.DbType.String, Last_Name);
                dbDatabase.AddInParameter(dbCommand, "@American_Name", System.Data.DbType.String, American_Name);
                dbDatabase.AddInParameter(dbCommand, "@Created_by", System.Data.DbType.Int32, Created_by);
                dbDatabase.AddInParameter(dbCommand, "@IsActive", System.Data.DbType.Int32, IsActive);
                dbDatabase.AddInParameter(dbCommand, "@Disable_By", System.Data.DbType.Int32, Disable_By);

                dbDatabase.ExecuteNonQuery(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSalesAgentDetailsByStatus(int IsActive)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

                spNameString = "USP_GetSalesAgentDetailsByStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@IsActive", System.Data.DbType.Int32, IsActive);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetSmartzSalesAgentsInActivePeriod(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);

                spNameString = "USP_GetSmartzSalesAgentsInActivePeriod";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

