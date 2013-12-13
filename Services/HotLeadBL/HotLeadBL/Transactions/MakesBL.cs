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

#endregion Microsoft Application Block References

namespace HotLeadBL.Masters
{
    public class MakesBL
    {
        public IList<MakesInfo> GetMakes()
        {
            //Decalaring MakesInfo division object collection
            IList<MakesInfo> MakesInfoIList = new List<MakesInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader MakesInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_GetAllMakes]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.Int64, 0);

                //Executing stored procedure
                MakesInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (MakesInfoDataReader.Read())
                {
                    //Assign values to the MakesInfo object list
                    MakesInfo ObjMakesInfo_Info = new MakesInfo();
                    AssignMakesInfoList(MakesInfoDataReader, ObjMakesInfo_Info);
                    MakesInfoIList.Add(ObjMakesInfo_Info);
                }
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                MakesInfoDataReader.Close();
            }

            return MakesInfoIList;
        }


        public IList<BodyInfo> GetBodys()
        {
            //Decalaring MakesInfo division object collection
            IList<BodyInfo> MakesInfoIList = new List<BodyInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader BodysInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_GetAllBodyTypes]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@bodyTypeID", DbType.Int64, 0);

                //Executing stored procedure
                BodysInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (BodysInfoDataReader.Read())
                {
                    //Assign values to the MakesInfo object list
                    BodyInfo ObjBodysInfo_Info = new BodyInfo();
                    AssignBodysInfoList(BodysInfoDataReader, ObjBodysInfo_Info);
                    MakesInfoIList.Add(ObjBodysInfo_Info);
                }
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                BodysInfoDataReader.Close();
            }

            return MakesInfoIList;
        }

        private void AssignBodysInfoList(IDataReader BodysInfoDataReader, BodyInfo ObjBodysInfo_Info)
        {
            try
            {
                ObjBodysInfo_Info.BodyTypeID = int.Parse(BodysInfoDataReader["bodyTypeID"].ToString());
                ObjBodysInfo_Info.BodyType = Convert.ToString(BodysInfoDataReader["bodyType"]);
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

        private void AssignMakesInfoList(IDataReader MakesInfoDataReader, MakesInfo MakesInfo)
        {
            try
            {
                MakesInfo.MakeID = int.Parse(MakesInfoDataReader["makeID"].ToString());
                MakesInfo.Make = Convert.ToString(MakesInfoDataReader["make"]);
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

    }
}
