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
using HotLeadInfo;
#region Application References

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using HotLeadBL;
using HotLeadInfo;

#endregion Microsoft Application Block References

namespace HotLeadBL.Leads
{
    public class StateWiseLeadAllocationBL
    {

        public DataSet StateAllocationForCenters(string VehicleTypeID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_StateAllocationForCenters]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, VehicleTypeID);

                //Executing stored procedure
                ds = dbDatabase.ExecuteDataSet(dbCommand);


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
            return ds;

        }

        public DataSet GetStateAllocationForCenters(string VehicleTypeID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_GetStateAllocationForCenters]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeid", DbType.String, VehicleTypeID);

                //Executing stored procedure
                ds = dbDatabase.ExecuteDataSet(dbCommand);


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
            return ds;

        }
        //[]   


        public bool SetLeadAssignAllocationForCenters(string CenterID, string CSID, string StateID, string VehicleTypeid)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadAssignAllocationForCenters]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@CSID", DbType.String, CSID);
                dbDatabase.AddInParameter(dbCommand, "@CenterID", DbType.String, CenterID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", DbType.String, StateID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeid", DbType.String, VehicleTypeid);

                //Executing stored procedure
                dbDatabase.ExecuteNonQuery(dbCommand);


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
            return true;

        }
    }
}
