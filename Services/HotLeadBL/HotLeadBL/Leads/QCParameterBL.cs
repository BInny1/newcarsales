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
    public class QCParameterBL
    {

        public DataSet SaveQcParameters(
            string ID,
            string NPARangeFrom,
        string NPARangeTo,
        string NXXRangeFrom,
        string NXXRangeTo,
        string OtherNPA,
        string OtherNXX,
        string NPA_NXX_combos,
        string Last_four_digits,
        string PRICE_Below,
        string PRICE_Above,
        string ModelPriorTo,
        string ModelTo,
        string MileageGreaterthan,
        string MileageLessThan,
        string LeadDatePriorTo,
        string Future_date)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_Leads_SaveQCParameter]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters      
                dbDatabase.AddInParameter(dbCommand, "@ID", DbType.String, ID);
                dbDatabase.AddInParameter(dbCommand, "@NPARangeFrom", DbType.String, NPARangeFrom);
                dbDatabase.AddInParameter(dbCommand, "@NPARangeTo", DbType.String, NPARangeTo);
                dbDatabase.AddInParameter(dbCommand, "@NXXRangeFrom", DbType.String, NXXRangeFrom);
                dbDatabase.AddInParameter(dbCommand, "@NXXRangeTo", DbType.String, NXXRangeTo);
                dbDatabase.AddInParameter(dbCommand, "@OtherNPA", DbType.String, OtherNPA);
                dbDatabase.AddInParameter(dbCommand, "@OtherNXX", DbType.String, OtherNXX);
                dbDatabase.AddInParameter(dbCommand, "@NPA_NXX_combos", DbType.String, NPA_NXX_combos);
                dbDatabase.AddInParameter(dbCommand, "@Last_four_digits", DbType.String, Last_four_digits);
                dbDatabase.AddInParameter(dbCommand, "@PRICE_Below", DbType.String, PRICE_Below);
                dbDatabase.AddInParameter(dbCommand, "@PRICE_Above", DbType.String, PRICE_Above);
                dbDatabase.AddInParameter(dbCommand, "@ModelPriorTo", DbType.String, ModelPriorTo);
                dbDatabase.AddInParameter(dbCommand, "@ModelTo", DbType.String, ModelTo);
                dbDatabase.AddInParameter(dbCommand, "@MileageGreaterthan", DbType.String, MileageGreaterthan);
                dbDatabase.AddInParameter(dbCommand, "@MileageLessThan", DbType.String, MileageLessThan);
                dbDatabase.AddInParameter(dbCommand, "@LeadDatePriorTo", DbType.String, LeadDatePriorTo);
                dbDatabase.AddInParameter(dbCommand, "@Future_date", DbType.String, Future_date);

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

        public DataSet GetQCParmeter(string sID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_GetQCParameter]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@ID", DbType.String, sID);
                




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


        public DataSet UpdateLeadsQcStatusUpdate(string sIssuanceBatchID)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_LeadsQcStatusUpdate]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters               
                dbDatabase.AddInParameter(dbCommand, "@LeadIssuanceBatchID", DbType.String, sIssuanceBatchID);





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
