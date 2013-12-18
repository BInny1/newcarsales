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
namespace HotLeadBL.HotLeadsTran
{
    public class HotLeadsBL
    {
        public DataSet SaveSaleStatusData(UserRegistrationInfo objUserRegInfo, int SaleAgentID, int PackageID, decimal DiscountID, int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string DriveTrain, string Price, string Mileage, string ExteriorColor, string InteriorColor, string Transmission,
        string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Description, string ConditionDescription, string Title, string state, string Ip, string SaleNotes, int LeadStatus, string LastName, int SourceOfPhotosID, int SourceOfDescriptionID,
            int CarID, int UId, int UserPackID, int sellerID, int PostingID, int SaleVerifierID, int SaleEnteredBy, int EmailExists)
        {
            try
            {
                bool bnew = false;
                DataSet ds = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_SaveSaleStatusData";
                spNameString = "USP_SaveSaleStatusDataNew";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserRegInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserRegInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserRegInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserRegInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserRegInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserRegInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserRegInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@DiscountID", System.Data.DbType.Decimal, DiscountID);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);

                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDatabase.AddInParameter(dbCommand, "@SaleNotes", System.Data.DbType.String, SaleNotes);
                dbDatabase.AddInParameter(dbCommand, "@LeadStatus", System.Data.DbType.Int32, LeadStatus);
                dbDatabase.AddInParameter(dbCommand, "@LastName", System.Data.DbType.String, LastName);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfPhotosID", System.Data.DbType.Int32, SourceOfPhotosID);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfDescriptionID", System.Data.DbType.Int32, SourceOfDescriptionID);


                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@SaleVerifierID", System.Data.DbType.Int32, SaleVerifierID);
                dbDatabase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, SaleEnteredBy);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);

                ds = dbDatabase.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet SaveSaleStatusDataForQCEdit(UserRegistrationInfo objUserRegInfo, int SaleAgentID, int PackageID, int DiscountID, int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string DriveTrain, string Price, string Mileage, string ExteriorColor, string InteriorColor, string Transmission,
  string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Description, string ConditionDescription, string Title, string state, string Ip, string SaleNotes, int LeadStatus, string LastName, int SourceOfPhotosID, int SourceOfDescriptionID,
  int CarID, int UId, int UserPackID, int sellerID, int PostingID, int EmailExists)
        {
            try
            {
                bool bnew = false;
                DataSet ds = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_SaveSaleStatusDataForQCEdit1";
                spNameString = "USP_SaveSaleStatusDataForQCEditNew";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserRegInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserRegInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserRegInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserRegInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserRegInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserRegInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserRegInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@DiscountID", System.Data.DbType.Int32, DiscountID);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);

                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDatabase.AddInParameter(dbCommand, "@SaleNotes", System.Data.DbType.String, SaleNotes);
                dbDatabase.AddInParameter(dbCommand, "@LeadStatus", System.Data.DbType.Int32, LeadStatus);
                dbDatabase.AddInParameter(dbCommand, "@LastName", System.Data.DbType.String, LastName);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfPhotosID", System.Data.DbType.Int32, SourceOfPhotosID);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfDescriptionID", System.Data.DbType.Int32, SourceOfDescriptionID);


                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);

                ds = dbDatabase.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet SavePaymentData(int UserPackID, DateTime PayDate, int pmntType, int pmntStatus, string TransactionID, string IPAddress,
            string Amount, string VoiceRecord, int PostingID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePaymentData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PayDate", System.Data.DbType.DateTime, PayDate);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SavePDSalePaymentData(int UserPackID, DateTime PDDate, int pmntType, int pmntStatus, string IPAddress,
           string Amount, string VoiceRecord, int PostingID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePDSalePaymentData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PDDate", System.Data.DbType.DateTime, PDDate);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetYears()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetYears";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetNext12years()
        {
            try
            {
                DataSet dsyears = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetNext12years";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsyears = dbDatabase.ExecuteDataSet(dbCommand);
                return dsyears;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserExists(string UserName)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserPhoneNumberExists(string PhoneNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserPhoneNumberExistsForReturned(string PhoneNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExistsForReturned";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ChkUserPhoneNumberExistsForSale(string PhoneNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExistsForSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ChkUserPhoneNumberExistsForQCSale(string PhoneNumber, int postingID, int uid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExistsForQCSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dbDatabase.AddInParameter(dbCommand, "@uid", System.Data.DbType.Int32, uid);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ChkUserPhoneNumberExistsForQCSaleOtherSales(int uid, int postingID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExistsForQCSaleOtherSales";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@uid", System.Data.DbType.Int32, uid);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet HotLeadsPerformLogin(string UserName, string sPassword, string AgentCenterCode, string IpAddress)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME6);
                // spNameString = "USP_NewHotLeadsPerformLogin";//USP_HotLeadsPerformLogin
                spNameString = "USP_UCS_EmployeeLogin";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@AgentLogUname", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@AgentLogPassword", System.Data.DbType.String, sPassword);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterCode", System.Data.DbType.String, AgentCenterCode);
                dbDatabase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IpAddress);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCenterData(string AgentCenterCode)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCenterData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@AgentCenterCode", System.Data.DbType.String, AgentCenterCode);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SaveUserLog(UserLogInfo ObjUserLog, ref Int64 lngReturn, string logid)
        {
            bool returnValue = false;
            bool bNew = false;
            string spNameString = string.Empty;

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_Save_UserLog]";

            DbCommand dbCommand = null;
            try
            {

                if (logid == "")
                {
                    bNew = false;
                    ObjUserLog.Log_Id = 0;
                }
                else
                {
                    ObjUserLog.Log_Id = Int64.Parse(logid);
                    bNew = true;
                }

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters
                dbDatabase.AddInParameter(dbCommand, "@Log_Id", DbType.Int64, ObjUserLog.Log_Id);
                dbDatabase.AddInParameter(dbCommand, "@User_Id", DbType.Int64, ObjUserLog.User_Id);
                dbDatabase.AddInParameter(dbCommand, "@Login_Ip", DbType.String, ObjUserLog.Login_Ip);
                dbDatabase.AddInParameter(dbCommand, "@Log_Status_Id", DbType.Int32, ObjUserLog.Log_Status_Id);
                dbDatabase.AddInParameter(dbCommand, "@Login_DateTime", DbType.DateTime, ObjUserLog.Login_DateTime);
                dbDatabase.AddInParameter(dbCommand, "@Logout_time", DbType.DateTime, ObjUserLog.Logout_time);
                dbDatabase.AddInParameter(dbCommand, "@Session_Id", DbType.String, ObjUserLog.Session_Id);
                dbDatabase.AddInParameter(dbCommand, "@CookieID", DbType.String, ObjUserLog.CookieID);
                dbDatabase.AddInParameter(dbCommand, "@bNew", DbType.Boolean, bNew);

                dbDatabase.AddOutParameter(dbCommand, "@ID", DbType.Int64, 1);

                dbDatabase.ExecuteNonQuery(dbCommand);


                lngReturn = Int64.Parse(dbDatabase.GetParameterValue(dbCommand, "@Id").ToString());



                returnValue = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return returnValue;
        }
        public bool Perform_LogOut(int UserID, DateTime logOutDate, int LogID, int logStatusId)
        {
            bool returnValue = false;
            string spNameString = string.Empty;

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            spNameString = "[USP_Perform_LogOut]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@UserID", DbType.Int32, UserID);
                dbDatabase.AddInParameter(dbCommand, "@LogoutDate", DbType.DateTime, logOutDate);
                dbDatabase.AddInParameter(dbCommand, "@LogID", DbType.Int32, LogID);
                dbDatabase.AddInParameter(dbCommand, "@logStatusId", DbType.Int32, logStatusId);
                dbDatabase.ExecuteNonQuery(dbCommand);

                returnValue = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return returnValue;
        }
        public bool SmartzUpdateFeatures(int CarID, int FeatureID, int Isactive, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SmartzUpdateFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@FeatureID", System.Data.DbType.Int32, FeatureID);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, Isactive);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEachAgentSalesData(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEachAgentVerifiesData(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentVerifiesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllAgentsSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllAgentsSalesDataNewPayment(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID, int Payment)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsSalesDataNewPayment";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentId", System.Data.DbType.Int32, Payment);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllAgentsSalesDataSearchByPostingId(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID, string search)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsSalesDataSearchByPostingId";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dbDatabase.AddInParameter(dbCommand, "@Search", System.Data.DbType.String, search);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllAgentsSalesDataSearchByPhone(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID, string search)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsSalesDataSearchByPhone";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dbDatabase.AddInParameter(dbCommand, "@Search", System.Data.DbType.String, search);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllAgentsSalesDataSearchByName(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID, string search)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsSalesDataSearchByName";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dbDatabase.AddInParameter(dbCommand, "@Search", System.Data.DbType.String, search);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllAgentsVerifiesSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsVerifiesSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetAllCentersAgentsSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetAllCentersAgentsSalesData";
                spNameString = "USP_GetAllCentersAgentsSalesDataNew";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllCentersAgentsSalesDataNewPending(DateTime FromDate, DateTime ToDate, int AgentCenterID, int paymentid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetAllCentersAgentsSalesData";
                spNameString = "USP_GetAllCentersAgentsSalesDataNewPending";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentId", System.Data.DbType.Int32, paymentid);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllCentersVerifiesSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCentersVerifiesSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllAgentsAbandonSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsAbandonSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllAgentsTransferOutSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID, int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsTransferOutSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllCentersAgentsAbandonSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCentersAgentsAbandonSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllCentersAgentsTransfersOutSalesData(DateTime FromDate, DateTime ToDate, int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCentersAgentsTransfersOutSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEachAgentAbandonSalesData(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentAbandonSalesData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEachAgentTransfersData(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentTransfersData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEachAgentTransfersOutData(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentTransfersOutData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUsersDetails(int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

                spNameString = "USP_GetUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Get_Change_Password(string NewPassword, int UserID)
        {
            try
            {
                DataSet dsUsersPW = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CHANGE_PASSWORD";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UserID);

                dbDatabase.AddInParameter(dbCommand, "@NEWPASSWORD", System.Data.DbType.String, NewPassword);

                dsUsersPW = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsersPW;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetUsersModuleRites_All(int UserID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_NewGetUserModules1";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveUserDetails(string FIRSTNAME, string EMAILID, int USERTYPE, string UName, string PASSWORD, int IsActive, int AgentCenterID)
        {
            string spNameString = string.Empty;
            bool bnew = false;
            DataSet ds = new DataSet();

            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
            spNameString = "USP_SAVE_USER_DETAILS";
            DbCommand dbCommand = null;
            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FirstName", System.Data.DbType.String, FIRSTNAME);
                dbDatabase.AddInParameter(dbCommand, "@Uname", System.Data.DbType.String, UName);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, EMAILID);
                dbDatabase.AddInParameter(dbCommand, "@Password", System.Data.DbType.String, PASSWORD);
                dbDatabase.AddInParameter(dbCommand, "@Utype_Id", System.Data.DbType.Int32, USERTYPE);
                dbDatabase.AddInParameter(dbCommand, "@IsActive", System.Data.DbType.Int32, IsActive);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);

                //dbDatabase.AddOutParameter(dbCommand, "@Id", System.Data.DbType.Int32, Id);



                ds = dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                //    ds1 = Convert.ToInt32(ds1.Tables[0].Rows[0][0].ToString());

                //  bnew = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return ds;
        }
        public DataSet GetUsersModuleRites_All()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_All_GetUserModules_Rights";
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


        public DataSet GetMasterModules()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

                spNameString = "USP_GetMasterModules";
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
        public bool UpdateUser_Details(string FirstName, string EmailId, int UserType, int UserID, int isactive, int Tran_By)
        {
            string spNameString = string.Empty;
            bool bnew = false;
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
            spNameString = "USP_UPDATE_USER_DETAILS";
            DbCommand dbCommand = null;
            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FirstName", System.Data.DbType.String, FirstName);
                dbDatabase.AddInParameter(dbCommand, "@EMAILID ", System.Data.DbType.String, EmailId);
                dbDatabase.AddInParameter(dbCommand, "@UTYPE_id", System.Data.DbType.String, UserType);
                dbDatabase.AddInParameter(dbCommand, "@uid ", System.Data.DbType.Int32, UserID);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, isactive);
                dbDatabase.AddInParameter(dbCommand, "@Tran_By", System.Data.DbType.Int32, Tran_By);

                dbDatabase.ExecuteNonQuery(dbCommand);
                bnew = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return bnew;
        }
        public bool UpdateModuleRights(int UserId, int Module_ID, int IsActive)
        {
            string spNameString = string.Empty;
            bool bnew = false;
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
            spNameString = "Usp_UpdateModules";
            DbCommand dbCommand = null;
            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserId);
                dbDatabase.AddInParameter(dbCommand, "@Module_ID", System.Data.DbType.Int32, Module_ID);
                dbDatabase.AddInParameter(dbCommand, "@Active", System.Data.DbType.Int32, IsActive);

                dbDatabase.ExecuteNonQuery(dbCommand);
                bnew = true;
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {

            }
            return bnew;
        }

        public bool SaveModuleRights(int UserId, int Module_ID, int IsActive)
        {
            string spNameString = string.Empty;
            bool bnew = false;
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
            spNameString = "Usp_SaveModules";
            DbCommand dbCommand = null;
            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserId", System.Data.DbType.Int32, UserId);
                dbDatabase.AddInParameter(dbCommand, "@Module_ID", System.Data.DbType.Int32, Module_ID);
                dbDatabase.AddInParameter(dbCommand, "@Active", System.Data.DbType.Int32, IsActive);

                dbDatabase.ExecuteNonQuery(dbCommand);
                bnew = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return bnew;
        }
        public DataSet SaveCreditCardData(int PSID1, int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PSStatusID, int PaymentID,
           int LastModifiedBy, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, string cardNumber, string cardType,
           string cardExpDt, string cardholderName, string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity, string billingState, int PostingID, int VoiceFileLocation)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCreditCardData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PSID1", System.Data.DbType.Int32, PSID1);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);


                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCreditCardDataForPDSale(int PSID1, int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PSStatusID, int PaymentID,
           int LastModifiedBy, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, string cardNumber, string cardType,
           string cardExpDt, string cardholderName, string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity, string billingState, int PostingID,
            int PSID2, DateTime PDScheduleDate, string PDAmount, int VoiceFileLocation)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCreditCardDataForPDSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PSID1", System.Data.DbType.Int32, PSID1);
                dbDatabase.AddInParameter(dbCommand, "@PSID2", System.Data.DbType.Int32, PSID2);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PDScheduleDate", System.Data.DbType.DateTime, PDScheduleDate);
                dbDatabase.AddInParameter(dbCommand, "@PDAmount", System.Data.DbType.String, PDAmount);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);


                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePayPalData(int PSID1, int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PSStatusID, int PaymentID,
           int LastModifiedBy, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, string TransactionID, string PaypalEmail, int PostingID, int VoiceFileLocation)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePayPalData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PSID1", System.Data.DbType.Int32, PSID1);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);

                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaypalEmail", System.Data.DbType.String, PaypalEmail);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePayPalDataForPDSale(int UserPackID, int pmntType, int pmntStatus, string IPAddress,
       string Amount, string VoiceRecord, int PostingID, DateTime PaymentDate, string TransactionID, string PaypalEmail,
            DateTime PDDate, string PD1Amount, string PD2Amount)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePayPalDataForPDSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);

                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);


                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaypalEmail", System.Data.DbType.String, PaypalEmail);
                dbDatabase.AddInParameter(dbCommand, "@PDDate", System.Data.DbType.DateTime, PDDate);
                dbDatabase.AddInParameter(dbCommand, "@PD1Amount", System.Data.DbType.String, PD1Amount);
                dbDatabase.AddInParameter(dbCommand, "@PD2Amount", System.Data.DbType.String, PD2Amount);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveCheckData(int PSID1, int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PSStatusID, int PaymentID,
           int LastModifiedBy, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int PostingID, int bankAccountType, string bankRouting, string bankName,
            string bankAccountNumber, string bankAccountHolderName, int VoiceFileLocation, int CheckTypeID, string BankCheckNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCheckData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PSID1", System.Data.DbType.Int32, PSID1);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveCheckDataForPDSale(int PSID1, int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PSStatusID, int PaymentID,
           int LastModifiedBy, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int PostingID, int bankAccountType, string bankRouting, string bankName,
            string bankAccountNumber, string bankAccountHolderName, int PSID2, DateTime PDScheduleDate, string PDAmount, int VoiceFileLocation, int CheckTypeID, string BankCheckNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCheckDataForPDSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PSID1", System.Data.DbType.Int32, PSID1);
                dbDatabase.AddInParameter(dbCommand, "@PSID2", System.Data.DbType.Int32, PSID2);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PDScheduleDate", System.Data.DbType.DateTime, PDScheduleDate);
                dbDatabase.AddInParameter(dbCommand, "@PDAmount", System.Data.DbType.String, PDAmount);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetIntroMailDetailsFor15Days(int AgentUID)
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetIntroMailDetailsFor15Days";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentUID", System.Data.DbType.Int32, AgentUID);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCarDetailsByPostingID(int postingID)
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetCarDetailsByPostingID";
                spNameString = "USP_GetCarDetailsByPostingIDNew";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetCarDetailsByPostingIDIN(string postingID)
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCarDetailsByPostingIDIN";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.String, postingID);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInfoByPostingIDForPayInfo(int postingID)
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetInfoByPostingIDForPayInfo";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInfoByDealerSaleIDForPayInfo(int DealerSaleID)
        {
            try
            {
                DataSet dsMails = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetInfoByDealerSaleIDForPayInfo";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dsMails = dbDatabase.ExecuteDataSet(dbCommand);
                return dsMails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SaveIntroMailDetails(string MarketSpecialist, string CustomerEmail, int AgentUID, string Language)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveIntroMailDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@MarketSpecialist", System.Data.DbType.String, MarketSpecialist);
                dbDatabase.AddInParameter(dbCommand, "@CustomerEmail", System.Data.DbType.String, CustomerEmail);
                dbDatabase.AddInParameter(dbCommand, "@AgentUID", System.Data.DbType.Int32, AgentUID);
                dbDatabase.AddInParameter(dbCommand, "@Language", System.Data.DbType.String, Language);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserSession(int USER_ID)
        {
            //Decalaring Users object collection
            DataSet dsUserModules = new DataSet();
            string spNameString = string.Empty;

            //Setting Connection


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            //Assign stored procedure name
            spNameString = "[USP_CHECK_USER_SESSION]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@USER_ID", DbType.Int32, USER_ID);


                //Executing stored procedure
                dsUserModules = dbDatabase.ExecuteDataSet(dbCommand);
            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return dsUserModules;


        }
        public DataSet GetUsersModuleRites(int UserID)
        {
            DataSet dsUsers = new DataSet();
            try
            {

                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //  spNameString = "USP_NewGetUserModules1";
                spNameString = "USP_GetUserModules";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsUsers;
        }

        public DataSet GetUserModules_ActiveInactive(string UserId)
        {
            //Decalaring Users object collection
            DataSet dsUserModules = new DataSet();
            string spNameString = string.Empty;

            //Setting Connection


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);

            //Assign stored procedure name
            spNameString = "[USP_NewGet_User_Modules_All]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Empid", DbType.String, UserId);


                //Executing stored procedure
                dsUserModules = dbDatabase.ExecuteDataSet(dbCommand);
            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return dsUserModules;


        }
        public DataSet GetQCDataForAll(string Status, int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetQCDataForAll";
                spNameString = "USP_GetQCDataForAllNew";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Status", System.Data.DbType.String, Status);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetQCDataForAllSearch(string Status, int AgentCenterID, string Search)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetQCDataForAllwithSearch";
                spNameString = "USP_GetQCDataForAllwithSearchNew";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Status", System.Data.DbType.String, Status);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@Search", System.Data.DbType.String, Search);
                // dbDatabase.AddInParameter(dbCommand, "@SearchField", System.Data.DbType.String, searchfield);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetQCDataForAllSearch2(string Status, int AgentCenterID, string Search)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetQCDataForAllwithSearch2";
                spNameString = "USP_GetQCDataForAllwithSearch2New";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Status", System.Data.DbType.String, Status);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@Search", System.Data.DbType.String, Search);
                // dbDatabase.AddInParameter(dbCommand, "@SearchField", System.Data.DbType.String, searchfield);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetQCDataForAllSearch3(string Status, int AgentCenterID, string Search)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetQCDataForAllwithSearch3";
                spNameString = "USP_GetQCDataForAllwithSearch3New";
                //Discount 21-11-2013 Ends
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Status", System.Data.DbType.String, Status);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@Search", System.Data.DbType.String, Search);
                // dbDatabase.AddInParameter(dbCommand, "@SearchField", System.Data.DbType.String, searchfield);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataSet GetBulkDataAll(string Status, string AgentCenterID, string PaymentType)
        //{
        //    try
        //    {
        //        DataSet dsUsers = new DataSet();
        //        string spNameString = string.Empty;
        //        Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
        //        spNameString = "USP_GetBulkDataForAll";
        //        DbCommand dbCommand = null;
        //        dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
        //        dbDatabase.AddInParameter(dbCommand, "@Status", System.Data.DbType.String, Status);
        //        dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.String, AgentCenterID);
        //        dbDatabase.AddInParameter(dbCommand, "@PaymentStus", System.Data.DbType.String, PaymentType);
        //        dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
        //        return dsUsers;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public DataSet GetBulkDataAll(string AgentCenterID, string Status, string PaymentType, string Transfer, string Ordby)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetBulkDataSpeed1";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Center", System.Data.DbType.Int32, AgentCenterID);
                dbDatabase.AddInParameter(dbCommand, "@QC", System.Data.DbType.String, Status);
                dbDatabase.AddInParameter(dbCommand, "@Payment", System.Data.DbType.String, PaymentType);
                dbDatabase.AddInParameter(dbCommand, "@Transfer", System.Data.DbType.String, Transfer);
                dbDatabase.AddInParameter(dbCommand, "@SortBy", System.Data.DbType.String, Ordby);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateQCStatus(int QCID, string QCNotes, int QCStatusID, int CarID, int QCDoneBy, int postingID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@QCID", System.Data.DbType.Int32, QCID);
                dbDatabase.AddInParameter(dbCommand, "@QCNotes", System.Data.DbType.String, QCNotes);
                dbDatabase.AddInParameter(dbCommand, "@QCStatusID", System.Data.DbType.Int32, QCStatusID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@QCDoneBy", System.Data.DbType.Int32, QCDoneBy);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdatePaymaentStus(int PaystatId, int postingID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdatePaymaentStus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PaystatId", System.Data.DbType.Int32, PaystatId);
                dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.Int32, postingID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateVehicleStatus(int VehId, int carid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makemodelId", System.Data.DbType.Int32, VehId);
                dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.String, carid);
                // dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_PackageUpdate(int carid, string PackId)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_PackageUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Carid", System.Data.DbType.Int32, carid);
                dbDatabase.AddInParameter(dbCommand, "@package", System.Data.DbType.String, PackId);
                // dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_EmailUpdate1(int carid, string Email)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_EmailUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Carid", System.Data.DbType.Int32, carid);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, Email);
                // dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetResultsFromLeadsDB(string PhoneNum)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME5);
                spNameString = "USP_GetResultsToCarsales";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNum", System.Data.DbType.String, PhoneNum);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateBulkQCStatus(int QCID, string QCNotes, int QCStatusID, int CarID, int QCDoneBy, int postingID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@QCID", System.Data.DbType.Int32, QCID);
                dbDatabase.AddInParameter(dbCommand, "@QCNotes", System.Data.DbType.String, QCNotes);
                dbDatabase.AddInParameter(dbCommand, "@QCStatusID", System.Data.DbType.Int32, QCStatusID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@QCDoneBy", System.Data.DbType.Int32, QCDoneBy);
                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCStatusForDealer(int QCID, string QCNotes, int QCStatusID, int DealerSaleID, int QCDoneBy, int DealerUID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCStatusForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@QCID", System.Data.DbType.Int32, QCID);
                dbDatabase.AddInParameter(dbCommand, "@QCNotes", System.Data.DbType.String, QCNotes);
                dbDatabase.AddInParameter(dbCommand, "@QCStatusID", System.Data.DbType.Int32, QCStatusID);
                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@QCDoneBy", System.Data.DbType.Int32, QCDoneBy);
                dbDatabase.AddInParameter(dbCommand, "@DealerUID", System.Data.DbType.Int32, DealerUID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCPayStatus(int pmntID, int PSStatusID, int PmntStatus, string TransactionID, DateTime PaymentScheduledDate, int PaymentCancelReasonID, string Amount, int LastModifiedBy, string PaymentNotes)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCPayStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@pmntID", System.Data.DbType.Int32, pmntID);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PmntStatus", System.Data.DbType.Int32, PmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@PaymentCancelReasonID", System.Data.DbType.Int32, PaymentCancelReasonID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateQCPayStatusForDealer(int pmntID, int PSStatusID, string TransactionID, DateTime PaymentScheduledDate, int PaymentCancelReasonID, string Amount, int LastModifiedBy, string PaymentNotes)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCPayStatusForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@pmntID", System.Data.DbType.Int32, pmntID);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@PaymentCancelReasonID", System.Data.DbType.Int32, PaymentCancelReasonID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateQCPayStatusForProcessButton(int PSID, int PaymentID, int PSStatusID, int PmntStatus, string TransactionID, string Amount, int LastModifiedBy, string PaymentNotes)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCPayStatusForProcessButton";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PSID", System.Data.DbType.Int32, PSID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PmntStatus", System.Data.DbType.Int32, PmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCPayStatusForProcessButtonForDealer(int PaymentID, int PSStatusID, string TransactionID, string Amount, int LastModifiedBy, string PaymentNotes)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCPayStatusForProcessButtonForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);

                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCPayNotesForProcessButton(int PSID, int LastModifiedBy, string PaymentNotes, int PSStatusID, int PmntStatus, int PaymentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCPayNotesForProcessButton";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PSID", System.Data.DbType.Int32, PSID);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PmntStatus", System.Data.DbType.Int32, PmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCPayNotesForProcessButtonForDealers(int LastModifiedBy, string PaymentNotes, int PSStatusID, int PaymentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCPayNotesForProcessButtonForDealers";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@LastModifiedBy", System.Data.DbType.Int32, LastModifiedBy);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dbDatabase.AddInParameter(dbCommand, "@PSStatusID", System.Data.DbType.Int32, PSStatusID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetLiveTransfersData()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetLiveTransfersData";
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

        public DataSet GetCallbacksTransfersData()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCallbacksTransfersData";
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
        public DataSet SaveSaleStatusDataForTransfers(UserRegistrationInfo objUserRegInfo, int SaleAgentID, int PackageID, int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string DriveTrain, string Price, string Mileage, string ExteriorColor, string InteriorColor, string Transmission,
        string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Description, string ConditionDescription, string Title, string state, string Ip, string SaleNotes, int LeadStatus, string LastName, int SourceOfPhotosID, int SourceOfDescriptionID,
            int CarID, int UId, int UserPackID, int sellerID, int PostingID, int DispositionID, int EmailExists)
        {
            try
            {
                bool bnew = false;
                DataSet ds = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveSaleStatusDataForTransfers";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserRegInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserRegInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserRegInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserRegInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserRegInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserRegInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserRegInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);

                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDatabase.AddInParameter(dbCommand, "@SaleNotes", System.Data.DbType.String, SaleNotes);
                dbDatabase.AddInParameter(dbCommand, "@LeadStatus", System.Data.DbType.Int32, LeadStatus);
                dbDatabase.AddInParameter(dbCommand, "@LastName", System.Data.DbType.String, LastName);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfPhotosID", System.Data.DbType.Int32, SourceOfPhotosID);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfDescriptionID", System.Data.DbType.Int32, SourceOfDescriptionID);


                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@DispositionID", System.Data.DbType.Int32, DispositionID);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);
                ds = dbDatabase.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet SaveLeadStatusForTransfers(int PostingID, string Ip, int DispositionID, int LeadStatus)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveLeadStatusForTransfers";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDataBase.AddInParameter(dbCommand, "@DispositionID", System.Data.DbType.Int32, DispositionID);
                dbDataBase.AddInParameter(dbCommand, "@LeadStatus", System.Data.DbType.Int32, LeadStatus);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveLeadStatusForSales(int PostingID, int LeadStatus)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveLeadStatusForSales";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@LeadStatus", System.Data.DbType.Int32, LeadStatus);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_Customer_LockStatus(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "Get_Customer_LockStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_Customer_LockStatus1(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "Get_Customer_LockStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAgentsForVerifier(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAgentsForVerifier";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAgentsForAgents(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAgentsForAgents";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_Lock_Customer(int PostingID, int IsLocked)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_Lock_Customer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@IsLocked", System.Data.DbType.Int32, IsLocked);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_Lock_Customer1(int PostingID, int IsLocked)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_Lock_Customer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@IsLocked", System.Data.DbType.Int32, IsLocked);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_Lock_CustomerBulk(int PostingID, int IsLocked)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_Lock_CustomerBulk";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@IsLocked", System.Data.DbType.Int32, IsLocked);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveNotInterestData(int CarID, int NotInterestReasonID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveNotInterestData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDataBase.AddInParameter(dbCommand, "@NotInterestReasonID", System.Data.DbType.Int32, NotInterestReasonID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveCallbackTimingData(int CarID, int CallbackStatusID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCallbackTimingData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDataBase.AddInParameter(dbCommand, "@CallbackStatusID", System.Data.DbType.Int32, CallbackStatusID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetNotInterestReason()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetNotInterestReason";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPmntCancelReasons()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPmntCancelReasons";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCallbackTimings()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCallbackTimings";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMasterSourceOfDescription()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetMasterSourceOfDescription";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetMasterSourceOfPhotos()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetMasterSourceOfPhotos";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveAgentCallsLog(int CarID, int Status)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveAgentCallsLog";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDataBase.AddInParameter(dbCommand, "@Status", System.Data.DbType.Int32, Status);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMasterUserType()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetMasterUserType";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCenterRolesByID(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCenterRolesByID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllCentersData()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCentersData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllCentersData1()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCentersData1";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetActiveAgentsByCenterID(int CenterId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetActiveAgentsByCenterID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.String, CenterId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCentersRoles()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCentersRoles";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCenters()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCenters";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckCenterExistsForNewCenter(string AgentCenterCode)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CheckCenterExistsForNewCenter";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterCode", System.Data.DbType.String, AgentCenterCode);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveNewCenter(string AgentCenterCode, string AgentCenterName)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveNewCenter";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterCode", System.Data.DbType.String, AgentCenterCode);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterName", System.Data.DbType.String, AgentCenterName);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateCenterDetails(int AgentCenterID, string AgentCenterName, int AgentCenterStatus)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateCenterDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterName", System.Data.DbType.String, AgentCenterName);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterStatus", System.Data.DbType.Int32, AgentCenterStatus);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateAgentVerifier(int AgentID, int VerifierId, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateAgentVerifier";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentName", System.Data.DbType.Int32, AgentID);
                dbDataBase.AddInParameter(dbCommand, "@VeridfierName", System.Data.DbType.Int32, VerifierId);
                dbDataBase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.Int32, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_UpdateAgent(int AgentID, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateAgent";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentName", System.Data.DbType.Int32, AgentID);
                dbDataBase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.Int32, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_UpdateVerifier(int Verifier, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateVerifier";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentName", System.Data.DbType.Int32, Verifier);
                dbDataBase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.Int32, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet VoiceRecordUpdate(string VerifierId, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_VoiceRecordUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@VoiceNo", System.Data.DbType.String, VerifierId);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaleDateUpdate(DateTime Saledate, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaleDateUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@SaleDate", System.Data.DbType.DateTime, Saledate);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CustomerNameUpdate
        public DataSet CustomerNameUpdates(string Fname, string Lname, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CustomerNameUpdates";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CFirstName", System.Data.DbType.String, Fname);
                dbDataBase.AddInParameter(dbCommand, "@CLastName", System.Data.DbType.String, Lname);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpadeChyeckPay(string bankAccountHolderName, string bankAccountNumber, string bankRouting, string bankName, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpadeChyeckPay";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDataBase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDataBase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDataBase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet PaymentDetailsDataPaypal(string TransactionID, string PaypalEmail, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_PaymentDetailsDataPaypal";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@PaypalEmail", System.Data.DbType.String, PaypalEmail);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CusomerAddressUpdates(string Phone, string add, string city, string state, string zipp, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CustomerAddressUpdates";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CPhone", System.Data.DbType.String, Phone);
                dbDataBase.AddInParameter(dbCommand, "@CAddress", System.Data.DbType.String, add);
                dbDataBase.AddInParameter(dbCommand, "@CCity", System.Data.DbType.String, city);
                dbDataBase.AddInParameter(dbCommand, "@CState", System.Data.DbType.String, state);
                dbDataBase.AddInParameter(dbCommand, "@CZip", System.Data.DbType.String, zipp);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateEVhicleinformation(int makemodelId, string year, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateEVhicleinformation";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@MakeModelId", System.Data.DbType.Int16, makemodelId);
                dbDataBase.AddInParameter(dbCommand, "@Year", System.Data.DbType.String, year);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdatePackages(string Amount, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdatePackages";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_PaymentDetailsData(string CadrNo, string cardCode, string cardExpDt, string cardholderName, string cardholderLastName
            , string billingAdd, string billingCity, string billingState, string billingZip, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_PaymentDetailsData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CadrNo", System.Data.DbType.String, CadrNo);
                dbDataBase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDataBase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDataBase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDataBase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDataBase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDataBase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDataBase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDataBase.AddInParameter(dbCommand, "@billingZip", System.Data.DbType.String, billingZip);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdatePaymentScheduledDate(DateTime Date, string Amount, int CarId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdatePaymentScheduledDate";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@Date", System.Data.DbType.DateTime, Date);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int16, CarId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveNewCenterRolesRights(int AgentCenterID, int CenterRoleID, int CenterRightStatus)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveNewCenterRolesRights";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@CenterRoleID", System.Data.DbType.Int32, CenterRoleID);
                dbDataBase.AddInParameter(dbCommand, "@CenterRightStatus", System.Data.DbType.Int32, CenterRightStatus);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserDetailsForAllUsersManagement()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetUserDetailsForAllUsersManagement";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMasterAgentCenters()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetMasterAgentCenters";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetLoginAgentCount()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetLoginAgentCount";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllLoginAgentDetails()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllLoginAgentDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllLoginTransferAgentsDetails()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllLoginTransferAgentsDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetLoginTransferAgentsCount()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetLoginTransferAgentsCount";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateUserLogDataTakenField(int UID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateUserLogDataTakenField";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckForUpdatesData(int UID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CheckForUpdatesData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateSmartzMoveStatus(int SmartzStatus, int postingID, int SmartzCarID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateSmartzMoveStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@SmartzStatus", System.Data.DbType.Int32, SmartzStatus);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, postingID);
                dbDataBase.AddInParameter(dbCommand, "@SmartzCarID", System.Data.DbType.Int32, SmartzCarID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateSmartzMoveStatusForDealer(int SmartzStatus, int DealerSaleID, int SmartzUID, string SmartzDealerCode)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateSmartzMoveStatusForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@SmartzStatus", System.Data.DbType.Int32, SmartzStatus);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDataBase.AddInParameter(dbCommand, "@SmartzUID", System.Data.DbType.Int32, SmartzUID);
                dbDataBase.AddInParameter(dbCommand, "@SmartzDealerCode", System.Data.DbType.String, SmartzDealerCode);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePaymentHistoryData(int PostingID, int PayTryBy, string CardType, string CardNumber, string Address, string City,
            string State, string Zip, string Amount, string Result, string TransactionID, string CCExpiryDate, string Cvv, string CCFirstName, string CCLastName)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePaymentHistoryData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@PayTryBy", System.Data.DbType.Int32, PayTryBy);
                dbDataBase.AddInParameter(dbCommand, "@CardType", System.Data.DbType.String, CardType);
                dbDataBase.AddInParameter(dbCommand, "@CardNumber", System.Data.DbType.String, CardNumber);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@CCExpiryDate", System.Data.DbType.String, CCExpiryDate);
                dbDataBase.AddInParameter(dbCommand, "@Cvv", System.Data.DbType.String, Cvv);
                dbDataBase.AddInParameter(dbCommand, "@CCFirstName", System.Data.DbType.String, CCFirstName);
                dbDataBase.AddInParameter(dbCommand, "@CCLastName", System.Data.DbType.String, CCLastName);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePaymentHistoryDataForDealer(int DealerSaleID, int PayTryBy, string CardType, string CardNumber, string Address, string City,
            string State, string Zip, string Amount, string Result, string TransactionID, string CCExpiryDate, string Cvv, string CCFirstName, string CCLastName)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePaymentHistoryDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDataBase.AddInParameter(dbCommand, "@PayTryBy", System.Data.DbType.Int32, PayTryBy);
                dbDataBase.AddInParameter(dbCommand, "@CardType", System.Data.DbType.String, CardType);
                dbDataBase.AddInParameter(dbCommand, "@CardNumber", System.Data.DbType.String, CardNumber);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@CCExpiryDate", System.Data.DbType.String, CCExpiryDate);
                dbDataBase.AddInParameter(dbCommand, "@Cvv", System.Data.DbType.String, Cvv);
                dbDataBase.AddInParameter(dbCommand, "@CCFirstName", System.Data.DbType.String, CCFirstName);
                dbDataBase.AddInParameter(dbCommand, "@CCLastName", System.Data.DbType.String, CCLastName);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePaymentHistoryDataForChecks(int PostingID, int PayTryBy, string CardType, string Address, string City,
            string State, string Zip, string Amount, string Result, string TransactionID, string AccountHolderName, string AccountNumber,
            string BankName, string RoutingNumber, string AccountType)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePaymentHistoryDataForChecks";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@PayTryBy", System.Data.DbType.Int32, PayTryBy);
                dbDataBase.AddInParameter(dbCommand, "@CardType", System.Data.DbType.String, CardType);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@AccountHolderName", System.Data.DbType.String, AccountHolderName);
                dbDataBase.AddInParameter(dbCommand, "@AccountNumber", System.Data.DbType.String, AccountNumber);
                dbDataBase.AddInParameter(dbCommand, "@BankName", System.Data.DbType.String, BankName);
                dbDataBase.AddInParameter(dbCommand, "@RoutingNumber", System.Data.DbType.String, RoutingNumber);
                dbDataBase.AddInParameter(dbCommand, "@AccountType", System.Data.DbType.String, AccountType);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SavePaymentHistoryDataForChecksForDealer(int DealerSaleID, int PayTryBy, string CardType, string Address, string City,
        string State, string Zip, string Amount, string Result, string TransactionID, string AccountHolderName, string AccountNumber,
        string BankName, string RoutingNumber, string AccountType)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SavePaymentHistoryDataForChecksForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDataBase.AddInParameter(dbCommand, "@PayTryBy", System.Data.DbType.Int32, PayTryBy);
                dbDataBase.AddInParameter(dbCommand, "@CardType", System.Data.DbType.String, CardType);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@AccountHolderName", System.Data.DbType.String, AccountHolderName);
                dbDataBase.AddInParameter(dbCommand, "@AccountNumber", System.Data.DbType.String, AccountNumber);
                dbDataBase.AddInParameter(dbCommand, "@BankName", System.Data.DbType.String, BankName);
                dbDataBase.AddInParameter(dbCommand, "@RoutingNumber", System.Data.DbType.String, RoutingNumber);
                dbDataBase.AddInParameter(dbCommand, "@AccountType", System.Data.DbType.String, AccountType);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckResultPaymentReject(string CCFirstName, string CCLastName, string Address, string Zip, string CardNumber,
            string Cvv, string CCExpiryDate, string Amount, string City, string State, int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CheckResultPaymentReject";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CCFirstName", System.Data.DbType.String, CCFirstName);
                dbDataBase.AddInParameter(dbCommand, "@CCLastName", System.Data.DbType.String, CCLastName);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@CardNumber", System.Data.DbType.String, CardNumber);
                dbDataBase.AddInParameter(dbCommand, "@Cvv", System.Data.DbType.String, Cvv);
                dbDataBase.AddInParameter(dbCommand, "@CCExpiryDate", System.Data.DbType.String, CCExpiryDate);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckResultPaymentRejectForDealer(string CCFirstName, string CCLastName, string Address, string Zip, string CardNumber,
         string Cvv, string CCExpiryDate, string Amount, string City, string State, int DealerSaleID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CheckResultPaymentRejectForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CCFirstName", System.Data.DbType.String, CCFirstName);
                dbDataBase.AddInParameter(dbCommand, "@CCLastName", System.Data.DbType.String, CCLastName);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@CardNumber", System.Data.DbType.String, CardNumber);
                dbDataBase.AddInParameter(dbCommand, "@Cvv", System.Data.DbType.String, Cvv);
                dbDataBase.AddInParameter(dbCommand, "@CCExpiryDate", System.Data.DbType.String, CCExpiryDate);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDatetime()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetDatetime";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPaymentTransactionData(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPaymentTransactionData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPaymentTransactionDataForDealer(int DealerSaleID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPaymentTransactionDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPaymentTransactionDataForChecks(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPaymentTransactionDataForChecks";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPaymentTransactionDataForChecksForDealer(int DealerSaleID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPaymentTransactionDataForChecksForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllSalesByCenterForTicker(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllSalesByCenterForTicker";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllSalesByCenterForTicker1(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetAllSalesByCenterForTickerNew";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTotalSalesBycenterByAgentForoneDay(int AgentCenterID, DateTime dt)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetTotalSalesBycenterByAgentForoneDay";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DatePresenr", System.Data.DbType.DateTime, dt);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTotalSalesBycenterByVerifierForoneDay(int AgentCenterID, DateTime dt)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetTotalSalesBycenterByVerifierForoneDay";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DatePresenr", System.Data.DbType.DateTime, dt);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTotalSalesBycenterByAgentForWeek(int AgentCenterID, DateTime dtstart, DateTime dtend)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetTotalSalesBycenterByAgentForWeek";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DateStart", System.Data.DbType.DateTime, dtstart);
                dbDataBase.AddInParameter(dbCommand, "@DateEnd", System.Data.DbType.DateTime, dtend);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTotalSalesBycenterByVerifierForweekDay(int AgentCenterID, DateTime dtstart, DateTime dtend)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts USP_GetTotalSalesBycenterByVerifiersForWeekByDays
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetTotalSalesBycenterByVerifierForweekDay";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DateStart", System.Data.DbType.DateTime, dtstart);
                dbDataBase.AddInParameter(dbCommand, "@DateEnd", System.Data.DbType.DateTime, dtend);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTotalSalesBycenterByVerifierForweekDays(int AgentCenterID, DateTime dtstart, DateTime dtend)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetTotalSalesBycenterByVerifiersForWeekByDays";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DateStart", System.Data.DbType.DateTime, dtstart);
                dbDataBase.AddInParameter(dbCommand, "@DateEnd", System.Data.DbType.DateTime, dtend);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTotalSalesBycenterByAgentForWeekByDays(int AgentCenterID, DateTime dtstart, DateTime dtend)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                // spNameString = "USP_GetAllSalesByCenterForTicker1";
                spNameString = "USP_GetTotalSalesBycenterByAgentForWeekByDays";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DateStart", System.Data.DbType.DateTime, dtstart);
                dbDataBase.AddInParameter(dbCommand, "@DateEnd", System.Data.DbType.DateTime, dtend);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllAgentsByCenterID(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsByCenterIDSales";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllAgentsByCenterID1(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllAgentsByCenterIDSales1";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSalesByDetails(int AgentCenterID, DateTime dt, int AgentUid)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetSalesByDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DatePresenr", System.Data.DbType.DateTime, dt);
                dbDataBase.AddInParameter(dbCommand, "@AgentUid", System.Data.DbType.Int32, AgentUid);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetVerifierSalesByDetails(int AgentCenterID, DateTime dt, int AgentUid)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetVerifierSalesByDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dbDataBase.AddInParameter(dbCommand, "@DatePresenr", System.Data.DbType.DateTime, dt);
                dbDataBase.AddInParameter(dbCommand, "@AgentUid", System.Data.DbType.Int32, AgentUid);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet GetAllCenterSalesByCenterForTicker(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCenterSalesByCenterForTicker";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllCenterSalesByCenterForTicker1(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetAllCenterSalesByCenterForTicker1";
                spNameString = "USP_GetAllCenterSalesByCenterForTickerNew";
                //Discount 21-11-2013 Ends

                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllCheckTypes()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllCheckTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllIPAddressValues()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetAllIPAddressValues";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet CheckIPAddressExist(string IpAddress)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_CheckIPAddressExist";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IpAddress);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DeleteIPAddressExist(string IpAddress)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_DeleteIPAddressExist";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IpAddress);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet InsertIPAddressValues(string IpAddress)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_InsertIPAddressValues";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IpAddress);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCarSalesReport(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCarSalesReport";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCarsalesReportNewWithSummary(DateTime FromDate, DateTime ToDate, int CenterID, int AgentID, int TypeID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCarsalesReportNewWithSummary";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dbDatabase.AddInParameter(dbCommand, "@CenterID", System.Data.DbType.Int32, CenterID);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dbDatabase.AddInParameter(dbCommand, "@TypeID", System.Data.DbType.Int32, TypeID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserByExistUserID(int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetUserByExistUserID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSurveyQuestions()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetSurveyQuestions";
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
        public DataSet GetPromotionOptions()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPromotionOptions";
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

        public DataSet SaveSaleStatusDataForMultiCar(UserRegistrationInfo objUserRegInfo, int SaleAgentID, int PackageID, int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string DriveTrain, string Price, string Mileage, string ExteriorColor, string InteriorColor, string Transmission,
     string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Description, string ConditionDescription, string Title, string state, string Ip, string SaleNotes, int LeadStatus, string LastName, int SourceOfPhotosID, int SourceOfDescriptionID,
         int CarID, int UId, int UserPackID, int sellerID, int PostingID, int SaleVerifierID, int SaleEnteredBy, int EmailExists)
        {
            try
            {
                bool bnew = false;
                DataSet ds = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveSaleStatusDataForMultiCar";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserRegInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserRegInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserRegInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserRegInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserRegInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserRegInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserRegInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);

                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDatabase.AddInParameter(dbCommand, "@SaleNotes", System.Data.DbType.String, SaleNotes);
                dbDatabase.AddInParameter(dbCommand, "@LeadStatus", System.Data.DbType.Int32, LeadStatus);
                dbDatabase.AddInParameter(dbCommand, "@LastName", System.Data.DbType.String, LastName);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfPhotosID", System.Data.DbType.Int32, SourceOfPhotosID);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfDescriptionID", System.Data.DbType.Int32, SourceOfDescriptionID);


                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@SaleVerifierID", System.Data.DbType.Int32, SaleVerifierID);
                dbDatabase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, SaleEnteredBy);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);

                ds = dbDatabase.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet AddCarsalesDealerInformation(int DealerContactID, string DealerContactName, string DealerJobTitle, string DealerContactPhone, string DealerMobilePhone, string DealerEmail, int DealerUID, string DealerShipName, string DealerAddress, string DealerCity, int DealerStateID,
            string DealerZip, string DealerPhone, string DealerFax, string DealerWebAddress, string DealerLicenseNumber, int DealerSaleID, int UCEDealerCoordinatorID, string LeadGeneratedBy, string LeadAgent, int PackageID, int PromotionID, DateTime TargetSignupDate, DateTime CallbackDate,
            string SaleNotes, int SaleEnteredBy, string IPAddress)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_AddCarsalesDealerInformation";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerContactID", System.Data.DbType.Int32, DealerContactID);
                dbDataBase.AddInParameter(dbCommand, "@DealerContactName", System.Data.DbType.String, DealerContactName);
                dbDataBase.AddInParameter(dbCommand, "@DealerJobTitle", System.Data.DbType.String, DealerJobTitle);
                dbDataBase.AddInParameter(dbCommand, "@DealerContactPhone", System.Data.DbType.String, DealerContactPhone);
                dbDataBase.AddInParameter(dbCommand, "@DealerMobilePhone", System.Data.DbType.String, DealerMobilePhone);
                dbDataBase.AddInParameter(dbCommand, "@DealerEmail", System.Data.DbType.String, DealerEmail);
                dbDataBase.AddInParameter(dbCommand, "@DealerUID", System.Data.DbType.Int32, DealerUID);
                dbDataBase.AddInParameter(dbCommand, "@DealerShipName", System.Data.DbType.String, DealerShipName);
                dbDataBase.AddInParameter(dbCommand, "@DealerAddress", System.Data.DbType.String, DealerAddress);
                dbDataBase.AddInParameter(dbCommand, "@DealerCity", System.Data.DbType.String, DealerCity);
                dbDataBase.AddInParameter(dbCommand, "@DealerStateID", System.Data.DbType.Int32, DealerStateID);
                dbDataBase.AddInParameter(dbCommand, "@DealerZip", System.Data.DbType.String, DealerZip);
                dbDataBase.AddInParameter(dbCommand, "@DealerPhone", System.Data.DbType.String, DealerPhone);
                dbDataBase.AddInParameter(dbCommand, "@DealerFax", System.Data.DbType.String, DealerFax);
                dbDataBase.AddInParameter(dbCommand, "@DealerWebAddress", System.Data.DbType.String, DealerWebAddress);
                dbDataBase.AddInParameter(dbCommand, "@DealerLicenseNumber", System.Data.DbType.String, DealerLicenseNumber);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDataBase.AddInParameter(dbCommand, "@UCEDealerCoordinatorID", System.Data.DbType.Int32, UCEDealerCoordinatorID);
                dbDataBase.AddInParameter(dbCommand, "@LeadGeneratedBy", System.Data.DbType.String, LeadGeneratedBy);
                dbDataBase.AddInParameter(dbCommand, "@LeadAgent", System.Data.DbType.String, LeadAgent);
                dbDataBase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDataBase.AddInParameter(dbCommand, "@PromotionID", System.Data.DbType.Int32, PromotionID);
                dbDataBase.AddInParameter(dbCommand, "@TargetSignupDate", System.Data.DbType.DateTime, TargetSignupDate);
                dbDataBase.AddInParameter(dbCommand, "@CallbackDate", System.Data.DbType.DateTime, CallbackDate);
                dbDataBase.AddInParameter(dbCommand, "@SaleNotes", System.Data.DbType.String, SaleNotes);
                dbDataBase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, SaleEnteredBy);
                dbDataBase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet InsertProductInformation(int ProductOptionID, int DealerUID, int ProductOptionStatus, string ProductOptionNotes)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_InsertProductInformation";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@ProductOptionID", System.Data.DbType.Int32, ProductOptionID);
                dbDataBase.AddInParameter(dbCommand, "@DealerUID", System.Data.DbType.Int32, DealerUID);
                dbDataBase.AddInParameter(dbCommand, "@ProductOptionStatus", System.Data.DbType.Int32, ProductOptionStatus);
                dbDataBase.AddInParameter(dbCommand, "@ProductOptionNotes", System.Data.DbType.String, ProductOptionNotes);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet InsertSurveyInformation(int DealerUID, int SurveyQuestionID, string SurveyQuestionAnswer)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_InsertSurveyInformation";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerUID", System.Data.DbType.Int32, DealerUID);
                dbDataBase.AddInParameter(dbCommand, "@SurveyQuestionID", System.Data.DbType.Int32, SurveyQuestionID);
                dbDataBase.AddInParameter(dbCommand, "@SurveyQuestionAnswer", System.Data.DbType.String, SurveyQuestionAnswer);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCEditCarsalesDealerInformation(int DealerContactID, string DealerContactName, string DealerJobTitle, string DealerContactPhone, string DealerMobilePhone, string DealerEmail, int DealerUID, string DealerShipName, string DealerAddress, string DealerCity, int DealerStateID,
          string DealerZip, string DealerPhone, string DealerFax, string DealerWebAddress, string DealerLicenseNumber, int DealerSaleID, string LeadGeneratedBy, string LeadAgent, int PackageID, int PromotionID,
          string SaleNotes, int SaleEnteredBy, string IPAddress, DateTime ContractSignDate, int ContractSignStatusID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCEditCarsalesDealerInformation";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DealerContactID", System.Data.DbType.Int32, DealerContactID);
                dbDataBase.AddInParameter(dbCommand, "@DealerContactName", System.Data.DbType.String, DealerContactName);
                dbDataBase.AddInParameter(dbCommand, "@DealerJobTitle", System.Data.DbType.String, DealerJobTitle);
                dbDataBase.AddInParameter(dbCommand, "@DealerContactPhone", System.Data.DbType.String, DealerContactPhone);
                dbDataBase.AddInParameter(dbCommand, "@DealerMobilePhone", System.Data.DbType.String, DealerMobilePhone);
                dbDataBase.AddInParameter(dbCommand, "@DealerEmail", System.Data.DbType.String, DealerEmail);
                dbDataBase.AddInParameter(dbCommand, "@DealerUID", System.Data.DbType.Int32, DealerUID);
                dbDataBase.AddInParameter(dbCommand, "@DealerShipName", System.Data.DbType.String, DealerShipName);
                dbDataBase.AddInParameter(dbCommand, "@DealerAddress", System.Data.DbType.String, DealerAddress);
                dbDataBase.AddInParameter(dbCommand, "@DealerCity", System.Data.DbType.String, DealerCity);
                dbDataBase.AddInParameter(dbCommand, "@DealerStateID", System.Data.DbType.Int32, DealerStateID);
                dbDataBase.AddInParameter(dbCommand, "@DealerZip", System.Data.DbType.String, DealerZip);
                dbDataBase.AddInParameter(dbCommand, "@DealerPhone", System.Data.DbType.String, DealerPhone);
                dbDataBase.AddInParameter(dbCommand, "@DealerFax", System.Data.DbType.String, DealerFax);
                dbDataBase.AddInParameter(dbCommand, "@DealerWebAddress", System.Data.DbType.String, DealerWebAddress);
                dbDataBase.AddInParameter(dbCommand, "@DealerLicenseNumber", System.Data.DbType.String, DealerLicenseNumber);
                dbDataBase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDataBase.AddInParameter(dbCommand, "@LeadGeneratedBy", System.Data.DbType.String, LeadGeneratedBy);
                dbDataBase.AddInParameter(dbCommand, "@LeadAgent", System.Data.DbType.String, LeadAgent);
                dbDataBase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDataBase.AddInParameter(dbCommand, "@PromotionID", System.Data.DbType.Int32, PromotionID);
                dbDataBase.AddInParameter(dbCommand, "@ContractSignDate", System.Data.DbType.DateTime, ContractSignDate);
                dbDataBase.AddInParameter(dbCommand, "@ContractSignStatusID", System.Data.DbType.Int32, ContractSignStatusID);
                dbDataBase.AddInParameter(dbCommand, "@SaleNotes", System.Data.DbType.String, SaleNotes);
                dbDataBase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, SaleEnteredBy);
                dbDataBase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveCreditCardDataForDealer(int DealerSaleID, DateTime SchedulePaymentDate, DateTime ContractSignDate, int ContractSignStatusID, int DealerStatusID, string Amount, int PaymentID,
      int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, string cardNumber, string cardType,
       string cardExpDt, string cardholderName, string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity, string billingState)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCreditCardDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@SchedulePaymentDate", System.Data.DbType.DateTime, SchedulePaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@ContractSignDate", System.Data.DbType.DateTime, ContractSignDate);
                dbDatabase.AddInParameter(dbCommand, "@ContractSignStatusID", System.Data.DbType.Int32, ContractSignStatusID);
                dbDatabase.AddInParameter(dbCommand, "@DealerStatusID", System.Data.DbType.Int32, DealerStatusID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCEditCreditCardDataForDealer(int DealerSaleID, DateTime SchedulePaymentDate, string Amount, int PaymentID,
   int pmntType, string IPAddress, string VoiceRecord, int VoiceFileLocation, string cardNumber, string cardType,
    string cardExpDt, string cardholderName, string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity, string billingState)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCEditCreditCardDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@SchedulePaymentDate", System.Data.DbType.DateTime, SchedulePaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCheckDataForDealer(int DealerSaleID, DateTime SchedulePaymentDate, DateTime ContractSignDate, int ContractSignStatusID, int DealerStatusID, string Amount, int PaymentID,
        int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, int bankAccountType, string bankRouting, string bankName,
         string bankAccountNumber, string bankAccountHolderName, int CheckTypeID, string BankCheckNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveCheckDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@SchedulePaymentDate", System.Data.DbType.DateTime, SchedulePaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@ContractSignDate", System.Data.DbType.DateTime, ContractSignDate);
                dbDatabase.AddInParameter(dbCommand, "@ContractSignStatusID", System.Data.DbType.Int32, ContractSignStatusID);
                dbDatabase.AddInParameter(dbCommand, "@DealerStatusID", System.Data.DbType.Int32, DealerStatusID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCEditCheckDataForDealer(int DealerSaleID, DateTime SchedulePaymentDate, string Amount, int PaymentID,
       int pmntType, string IPAddress, string VoiceRecord, int VoiceFileLocation, int bankAccountType, string bankRouting, string bankName,
        string bankAccountNumber, string bankAccountHolderName, int CheckTypeID, string BankCheckNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCEditCheckDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@SchedulePaymentDate", System.Data.DbType.DateTime, SchedulePaymentDate);

                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);

                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveInvoiceDataForDealer(int DealerSaleID, DateTime SchedulePaymentDate, DateTime ContractSignDate, int ContractSignStatusID, int DealerStatusID, string Amount, int PaymentID,
  int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, int SendInvoiceID, string InvoiceAttentionTo,
   string SendInvoiceEmail, string billingName, string BillingZip, string billingAdd, string billingCity, string billingState)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveInvoiceDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@SchedulePaymentDate", System.Data.DbType.DateTime, SchedulePaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@ContractSignDate", System.Data.DbType.DateTime, ContractSignDate);
                dbDatabase.AddInParameter(dbCommand, "@ContractSignStatusID", System.Data.DbType.Int32, ContractSignStatusID);
                dbDatabase.AddInParameter(dbCommand, "@DealerStatusID", System.Data.DbType.Int32, DealerStatusID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@SendInvoiceID", System.Data.DbType.Int32, SendInvoiceID);
                dbDatabase.AddInParameter(dbCommand, "@InvoiceAttentionTo", System.Data.DbType.String, InvoiceAttentionTo);
                dbDatabase.AddInParameter(dbCommand, "@SendInvoiceEmail", System.Data.DbType.String, SendInvoiceEmail);
                dbDatabase.AddInParameter(dbCommand, "@billingName", System.Data.DbType.String, billingName);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateQCEditInvoiceDataForDealer(int DealerSaleID, DateTime SchedulePaymentDate, string Amount, int PaymentID,
 int pmntType, string IPAddress, string VoiceRecord, int VoiceFileLocation, int SendInvoiceID, string InvoiceAttentionTo,
  string SendInvoiceEmail, string billingName, string BillingZip, string billingAdd, string billingCity, string billingState)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateQCEditInvoiceDataForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dbDatabase.AddInParameter(dbCommand, "@SchedulePaymentDate", System.Data.DbType.DateTime, SchedulePaymentDate);

                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);

                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@SendInvoiceID", System.Data.DbType.Int32, SendInvoiceID);
                dbDatabase.AddInParameter(dbCommand, "@InvoiceAttentionTo", System.Data.DbType.String, InvoiceAttentionTo);
                dbDatabase.AddInParameter(dbCommand, "@SendInvoiceEmail", System.Data.DbType.String, SendInvoiceEmail);
                dbDatabase.AddInParameter(dbCommand, "@billingName", System.Data.DbType.String, billingName);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ChkUserPhoneNumberExistsForDealerSave(string PhoneNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExistsForDealerSave";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserPhoneNumberExistsForQCEditDealerSave(string PhoneNumber, int DealerSaleID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ChkUserPhoneNumberExistsForQCEditDealerSave";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEachAgentSalesDataForDealers(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentSalesDataForDealers";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEachAgentPromotionalsDataForDealers(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentPromotionalsDataForDealers";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetEachAgentProspectsDataForDealers(int AgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetEachAgentProspectsDataForDealers";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetDealerDetailsByDealerSaleID(int DealerSaleID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetDealerDetailsByDealerSaleID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@DealerSaleID", System.Data.DbType.Int32, DealerSaleID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateSellerInfoForQCEdit(string Name, string Address, string City, string state, string Zip, string PhoneNumber,
            string email, string LastName, int sellerID, int SaleAgentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateSellerInfoForQCEdit";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@LastName", System.Data.DbType.String, LastName);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetQCDataForDealersData(string Status, int AgentCenterID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetQCDataForDealersData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Status", System.Data.DbType.String, Status);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllQCStatus()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetQCstatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllPaymentStatus()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetPaymentstatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet IpExists(string IpAddress)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME6);
                spNameString = "USP_CS_IpExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IpAddress);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Is Login Is Logged in Hr.Bizstrides
        public DataSet IsLoggedInToday(string Username, DateTime TodatsDate)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME6);
                spNameString = "USP_CS_IsLoggedInToday";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Username", System.Data.DbType.String, Username);
                dbDatabase.AddInParameter(dbCommand, "@TodatsDate", System.Data.DbType.DateTime, TodatsDate);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //vehicleTypes:
        public DataSet VehicleTypes()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetAllCentersAgentsSalesData";
                spNameString = "USP_VehicleTypes";
                //Discount 21-11-2013 Ends

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

        //GetBrandsList
        public DataSet GetBrandsList()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                //Discount 21-11-2013 starts 
                //spNameString = "USP_GetAllCentersAgentsSalesData";
                spNameString = "USP_BrandList";
                //Discount 21-11-2013 Ends

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
        public DataSet SaveNewBrands(string vehicleType, string Brand, Boolean status)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_SaveNewBrands";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@vehicleType", System.Data.DbType.String, vehicleType);
                dbDataBase.AddInParameter(dbCommand, "@Brand", System.Data.DbType.String, Brand);
                dbDataBase.AddInParameter(dbCommand, "@status", System.Data.DbType.Boolean, status);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GridCentersUpa()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetCentersUpdateLIst";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUserDefaultRights(int RoleId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_DefaultUserRights";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@RoleId", System.Data.DbType.String, RoleId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMasterRoles()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USp_MasterRoles";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllLocations()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME6);
                spNameString = "USP_GetLocation";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get All center Employees

        public DataSet GetAllEmployeesByCenetrId(int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME6);
                spNameString = "USP_UCS_GetAllEmployeesByCenetrId";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Get Rights based on Employee

        public DataSet AllEMployeeUserRights(string Empid)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_AllEMployeeUserRights";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@EMPID", System.Data.DbType.String, Empid);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

        public DataSet GetLeadsUserRights(int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_GetLeadsUserRights";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StatewiseLeads(int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_StatewiseLeads";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StatesListBasedonZone(int ZoneId, int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "StatesListBasedonZone";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@ZoneId", System.Data.DbType.String, ZoneId);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet StateWiseLeadsStatus()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_StateWiseLeadsStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet PerocessRightsStatus(int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_PerocessRightsStatusS";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ExecutiveRights(int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_ExecutiveRights";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateUserRights(string EMPID, bool LeadsUpload, bool LeadsDownLoad, bool Abondoned, bool FreePackage,
          bool Ticker, bool IntroMail, bool NewEntry, bool Transferin, bool MyReport, bool QC, bool Payments,
          bool Publish, bool MyReport1, bool Leads, bool Sales, bool Process, bool Executive, bool LeadsAdmin, bool
                         SalesAdmin, bool ProcessAdmin, bool ExecutiveAdmin, bool BrandsAdmin, bool CentersAdmin, bool UsersLog, bool EditLog, bool Center, bool Self)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "USP_UpdateUserRights";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@EMPID", System.Data.DbType.String, EMPID);

                dbDataBase.AddInParameter(dbCommand, "@LeadsUpload", System.Data.DbType.Boolean, LeadsUpload);
                dbDataBase.AddInParameter(dbCommand, "@LeadsDownLoad", System.Data.DbType.Boolean, LeadsDownLoad);
                dbDataBase.AddInParameter(dbCommand, "@Abondoned", System.Data.DbType.Boolean, Abondoned);
                dbDataBase.AddInParameter(dbCommand, "@FreePackage", System.Data.DbType.Boolean, FreePackage);

                dbDataBase.AddInParameter(dbCommand, "@Ticker", System.Data.DbType.Boolean, Ticker);
                dbDataBase.AddInParameter(dbCommand, "@IntroMail", System.Data.DbType.Boolean, IntroMail);
                dbDataBase.AddInParameter(dbCommand, "@NewEntry", System.Data.DbType.Boolean, NewEntry);
                dbDataBase.AddInParameter(dbCommand, "@Transferin", System.Data.DbType.Boolean, Transferin);

                dbDataBase.AddInParameter(dbCommand, "@MyReport", System.Data.DbType.Boolean, MyReport);
                dbDataBase.AddInParameter(dbCommand, "@QC", System.Data.DbType.Boolean, QC);
                dbDataBase.AddInParameter(dbCommand, "@Payments", System.Data.DbType.Boolean, Payments);
                dbDataBase.AddInParameter(dbCommand, "@Publish", System.Data.DbType.Boolean, Publish);

                dbDataBase.AddInParameter(dbCommand, "@MyReport1", System.Data.DbType.Boolean, MyReport1);
                dbDataBase.AddInParameter(dbCommand, "@Leads", System.Data.DbType.Boolean, Leads);
                dbDataBase.AddInParameter(dbCommand, "@Sales", System.Data.DbType.Boolean, Sales);
                dbDataBase.AddInParameter(dbCommand, "@Process", System.Data.DbType.Boolean, Process);

                dbDataBase.AddInParameter(dbCommand, "@Executive", System.Data.DbType.Boolean, Executive);
                dbDataBase.AddInParameter(dbCommand, "@LeadsAdmin", System.Data.DbType.Boolean, LeadsAdmin);
                dbDataBase.AddInParameter(dbCommand, "@SalesAdmin", System.Data.DbType.Boolean, SalesAdmin);

                dbDataBase.AddInParameter(dbCommand, "@ProcessAdmin", System.Data.DbType.Boolean, ProcessAdmin);
                dbDataBase.AddInParameter(dbCommand, "@ExecutiveAdmin", System.Data.DbType.Boolean, ExecutiveAdmin);
                dbDataBase.AddInParameter(dbCommand, "@BrandsAdmin", System.Data.DbType.Boolean, BrandsAdmin);
                dbDataBase.AddInParameter(dbCommand, "@CentersAdmin", System.Data.DbType.Boolean, CentersAdmin);

                dbDataBase.AddInParameter(dbCommand, "@UsersLog", System.Data.DbType.Boolean, UsersLog);
                dbDataBase.AddInParameter(dbCommand, "@EditLog", System.Data.DbType.Boolean, EditLog);
                dbDataBase.AddInParameter(dbCommand, "@Center", System.Data.DbType.Boolean, Center);
                dbDataBase.AddInParameter(dbCommand, "@Self", System.Data.DbType.Boolean, Self);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SalesUsersUpdateList(int LocationId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME4);
                spNameString = "Usp_SalesUsersUpdateList";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@LocationId", System.Data.DbType.String, LocationId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

