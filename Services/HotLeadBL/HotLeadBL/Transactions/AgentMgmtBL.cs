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
    public class AgentMgmtBL
    {
        public DataSet USP_GetSalesAgentDetails()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

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
        public DataSet USP_GetSalesAgentDetailsByStatus(int IsActive)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

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


        public bool USP_SmartzSaveAgentData(int Sale_Agent_Id, string First_Name, string Last_Name, string American_Name, int Created_by, int IsActive, int Disable_By)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_SmartzCheckAgentExists(int Sale_Agent_Id, string American_Name)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

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


    }
}
