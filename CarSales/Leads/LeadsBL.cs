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
    public class LeadsBL
    {
        public bool SaveLeadsInfo(LeadsInfo objLeadsInfo, bool bfirst, int rowNo, int LastRow, ref  DbTransaction Transaction, ref DbConnection Connection)
        {
            bool bNew = false;

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_SaveLeads]";

            DbCommand dbCommand = null;

            // dbCommand.CommandTimeout = 0;

            try
            {


                if (rowNo == 0)
                {
                    if (bfirst == true)
                    {
                        Global.Connection = dbDatabase.CreateConnection();
                        Global.Connection.Open();
                        Global.Transaction = Global.Connection.BeginTransaction();
                    }
                }

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@PostingID", DbType.Int64, objLeadsInfo.PostingID);
                dbDatabase.AddInParameter(dbCommand, "@Phone", DbType.Int64, objLeadsInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@SellerName", DbType.String, objLeadsInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@Price", DbType.String, objLeadsInfo.Price.ToString());
                dbDatabase.AddInParameter(dbCommand, "@Model", DbType.String, objLeadsInfo.Model);
                dbDatabase.AddInParameter(dbCommand, "@Description", DbType.String, objLeadsInfo.Description);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", DbType.String, objLeadsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@State", DbType.String, objLeadsInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@City", DbType.String, objLeadsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Zip", DbType.String, objLeadsInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@URL", DbType.String, objLeadsInfo.URL);
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, objLeadsInfo.VehicleTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CollectedDate", DbType.String, objLeadsInfo.CollectedDate);
                dbDatabase.AddInParameter(dbCommand, "@SellerType", DbType.String, objLeadsInfo.SellarTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Heading", DbType.String, objLeadsInfo.Header);
                dbDatabase.AddInParameter(dbCommand, "@LeadUpBatchID", DbType.String, objLeadsInfo.LeadUpBatchID);



                //Executing stored procedure
                ///dsSales = dbDatabase.ExecuteDataSet(dbCommand);
                Transaction = Global.Transaction;

                Connection = Global.Connection;

                dbDatabase.ExecuteNonQuery(dbCommand, Global.Transaction);

                if (bfirst == false)
                {
                    Global.Transaction.Commit();
                    Global.Connection.Close();
                }
                else if (LastRow == rowNo)
                {
                    Global.Transaction.Commit();
                    Global.Connection.Close();
                }

                bNew = true;
            }

            catch (Exception ex)
            {
                Global.Transaction.Rollback();
                Global.Connection.Close();
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                dbDatabase = null;
            }
            return bNew;

        }


        public DataSet LeadsCheckBTN()
        {

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadsCheckBTN]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters


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


        public DataSet SaveFileDetails(LeadBatchFile objFiles_Info, ref Int64 lngReturn, string sVehicleTypeiD)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_Lead_BatchUpload]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@Leaddate", DbType.String, objFiles_Info.Leaddate);
                dbDatabase.AddInParameter(dbCommand, "@LeadFile", DbType.String, objFiles_Info.LeadFile);
                dbDatabase.AddInParameter(dbCommand, "@LeadCount", DbType.String, objFiles_Info.RecordCount);
                dbDatabase.AddInParameter(dbCommand, "@Leadsource", DbType.String, objFiles_Info.Leadsource);
                dbDatabase.AddInParameter(dbCommand, "@LeadUploadedBy", DbType.String, objFiles_Info.LeadUploadedBy);
                dbDatabase.AddInParameter(dbCommand, "@VehicleTypeID", DbType.String, sVehicleTypeiD);



                //Executing stored procedure
                ds = dbDatabase.ExecuteDataSet(dbCommand);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lngReturn = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
                returnValue = true;
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


        //USP_GetAllcotedLeads




    }
}
