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
    public class AddCarModels
    {
        public DataSet USP_GetModels()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "USP_Get_Models";
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
        public DataSet USP_SaveCarModel(int MakeID, string Model)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "usp_Save_Model";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@model", System.Data.DbType.String, Model);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, MakeID);
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
