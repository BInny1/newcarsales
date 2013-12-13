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
    public class LeadsDownloadBL
    {
        public DataSet GetAllcotedLeadsConsolidated(string sVehicleTypeID, string sCenterID, string sFromDt, string sToDt)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_GetAllcotedLeadsConsolidated]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, sVehicleTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CenterID", DbType.String, sCenterID);
                dbDatabase.AddInParameter(dbCommand, "@FromDt", DbType.String, sFromDt);
                dbDatabase.AddInParameter(dbCommand, "@ToDt", DbType.String, sToDt);





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
        public DataSet GetLeadsIssued(string sVehicleTypeID, string sCentreID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadsGetIssuedDetails]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, sVehicleTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CenterID", DbType.String, sCentreID);

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

        public DataSet GetLeadsIssuedDetails(string sIssuedBatchID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadsDownloadAlreadyIssuedDetails]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@IssuanceBatchID", DbType.String, sIssuedBatchID);


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


        public DataSet LeadsUploadDetailsByBatchID(string sIssuedBatchID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadsUploadDetailsByBatchID]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@IssuanceBatchID", DbType.String, sIssuedBatchID);


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

        //

        public DataSet GetAllcotedLeadsDownload(string VehicleTypeID, string CenterID, string sFromDt, string sTodt, string sStateID, string SUID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_GetAllcotedLeads]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, VehicleTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CenterID", DbType.String, CenterID);
                dbDatabase.AddInParameter(dbCommand, "@dtFrom", DbType.String, sFromDt);
                dbDatabase.AddInParameter(dbCommand, "@dtTo", DbType.String, sTodt);
                dbDatabase.AddInParameter(dbCommand, "@StateID", DbType.String, sStateID);
                dbDatabase.AddInParameter(dbCommand, "@UserID", DbType.String, SUID);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sVehicleTypeID"></param>
        /// <param name="sCenterID"></param>
        /// <returns></returns>


        public bool UpdateLeadsAllcotedLeadsStatus(string VehicleTypeID, string CenterID, string sFromDt, string sTodt,
            string sStateID, string SUID, string rowCount)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadsUpdateAllcotedLeadsStatus]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, VehicleTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CenterID", DbType.String, CenterID);
                dbDatabase.AddInParameter(dbCommand, "@dtFrom", DbType.String, sFromDt);
                dbDatabase.AddInParameter(dbCommand, "@dtTo", DbType.String, sTodt);
                dbDatabase.AddInParameter(dbCommand, "@StateID", DbType.String, sStateID);
                dbDatabase.AddInParameter(dbCommand, "@UserID", DbType.String, SUID);
                dbDatabase.AddInParameter(dbCommand, "@rowCount", DbType.String, rowCount);

                

                //Executing stored procedure
                dbDatabase.ExecuteDataSet(dbCommand);


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

        public DataSet GetLeadsDownloadUploadHistory(string sVehicleTypeID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_FileHistoryUpload]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);



                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, sVehicleTypeID);                


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
        
        public DataSet GetLeadsDownloadHistory(string sVehicleTypeID, string sCenterID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_FileHistoryDownload]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);



                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, sVehicleTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CentreID", DbType.String, sCenterID);


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
    }
}
