using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

/// <summary>
/// Summary description for ExcelReading
/// </summary>
public class ExcelReading
{
    public DataSet GetLeadsExcelToDataset(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        DataSet objDataset2 = new DataSet();

        OleDbConnection objConn = new OleDbConnection();

        try
        {
            string FileExt = System.IO.Path.GetExtension(sFileName);
            if (FileExt == ".xls")
            {
                //Excell connection 
                //string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties="Excel 8.0;HDR=Yes;IMEX=1"; 
                string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
                //string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + sFileName + ";" + "Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";

                //string Xls_Con = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + sFileName + ";Extended Properties=Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text"; 
                objConn.ConnectionString = Xls_Con;

                objConn.Open();
                DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";

                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT * FROM " + SpreadSheetName, objConn);


                objAdapter1.Fill(objDataset1, "XLData");
            }
             else if (FileExt == ".xlsx")
            {
                string Xls_Con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

                objConn.ConnectionString = Xls_Con;

                objConn.Open();

                DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";

                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT * FROM " + SpreadSheetName, objConn);


                objAdapter1.Fill(objDataset1, "XLData");


            }

            objConn.Close();

        }
        catch (Exception ex)
        {
            throw ex;
            //objConn.Close();
            //Redirecting to error message page
            //Response.Redirect(ConstantClass.StrErrorPageURL);
        }


        return objDataset1;

    }

    public int GetExcelDistinctBTNCount(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            string FileExt = System.IO.Path.GetExtension(sFileName);
            if (FileExt == ".xls")
            {
                //Excell connection 
                string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
                objConn.ConnectionString = Xls_Con;
                //Dim objConn As New OleDbConnection(Xls_Con) 
                objConn.Open();
                DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct(BTN) FROM " + SpreadSheetName, objConn);
                objAdapter1.Fill(objDataset1, "XLData");

                count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            }
            else if (FileExt == ".xlsx")
            {
                //Excell connection 
                string Xls_Con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                objConn.ConnectionString = Xls_Con;
                //Dim objConn As New OleDbConnection(Xls_Con) 
                objConn.Open();
                DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct(BTN) FROM " + SpreadSheetName, objConn);
                objAdapter1.Fill(objDataset1, "XLData");

                count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            }
            objConn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
            //Redirecting to error message page

            // Redirect(ConstantClass.StrErrorPageURL);
        }
        return count;
    }

    public int GetExcelDistictBTNCOunt_Sales(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
             string FileExt = System.IO.Path.GetExtension(sFileName);
             if (FileExt == ".xls")
             {
                 //Excell connection 
                 string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
                 objConn.ConnectionString = Xls_Con;
                 //Dim objConn As New OleDbConnection(Xls_Con) 
                 objConn.Open();
                 DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                 string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


                 OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct(Phoneno) FROM " + SpreadSheetName, objConn);
                 objAdapter1.Fill(objDataset1, "XLData");

                 count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
             }
             else if (FileExt == ".xlsx")
             {
                 //Excell connection 
                 string Xls_Con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                 objConn.ConnectionString = Xls_Con;
                 //Dim objConn As New OleDbConnection(Xls_Con) 
                 objConn.Open();
                 DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                 string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


                 OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct(Phoneno) FROM " + SpreadSheetName, objConn);
                 objAdapter1.Fill(objDataset1, "XLData");

                 count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
             }
            objConn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
            //Redirecting to error message page

            // Redirect(ConstantClass.StrErrorPageURL);
        }
        return count;
    }


}