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
using HotLeadBL;

#endregion Microsoft Application Block References
namespace HotLeadBL.Leads
{
    public class VehicleTypeBL
    {
        public DataSet GetVehicleType()
        {
            try
            {
                DataSet dsFuelTypes = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_Leads_VechicleType";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsFuelTypes = dbDatabase.ExecuteDataSet(dbCommand);
                return dsFuelTypes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
