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
    public class SmartzIntroMail
    {

        public DataSet USP_GetIntroMailDetailsFor15Days()
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetIntroMailDetailsFor15Days";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SaveIntroMailDetails(string MarketSpecialist, string CustomerEmail)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveIntroMailDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@MarketSpecialist", System.Data.DbType.String, MarketSpecialist);
                dbDatabase.AddInParameter(dbCommand, "@CustomerEmail", System.Data.DbType.String, CustomerEmail);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SmartzSaveOfferMailDetails(int SendBy, string CustomerEmail, string FromEmail)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSaveOfferMailDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SendBy", System.Data.DbType.Int32, SendBy);
                dbDatabase.AddInParameter(dbCommand, "@FromEmail", System.Data.DbType.String, FromEmail);
                dbDatabase.AddInParameter(dbCommand, "@CustomerEmail", System.Data.DbType.String, CustomerEmail);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzGetOfferMailDetailsFor15Days()
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetOfferMailDetailsFor15Days";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
