/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 04-Jan-2012
' DESCRIPTION  : Business Logic to manipulate .
'*********************************************************************/

#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References

#region Application References
using HotLeadInfo;
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
    public class FilesBL
    {

        public IDataReader Get_FileByFileName(string FileName)
        {
            //Decalaring Users object collection

            IDataReader IAcDetDatarReader = null;

            string spNameString = string.Empty;

            //Setting Connection
            

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            //Assign stored procedure name
            spNameString = "[USP_Get_FileByFileName]";

            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@FileName", DbType.String, FileName);

                //Executing stored procedure
                IAcDetDatarReader = dbDatabase.ExecuteReader(dbCommand);

            }

            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                dbDatabase = null;
            }
            return IAcDetDatarReader;
        }
    }
}
