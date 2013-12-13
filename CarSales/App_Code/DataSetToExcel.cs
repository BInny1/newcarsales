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

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Web;
#endregion Microsoft Application Block References

public class DataSetToExcel
{

    public static void Convert(System.Data.DataSet ds, System.Web.HttpResponse response, string ExcelName)
    {
        //try
        //{
        //first let's clean up the response.object

        response.Clear();
        response.Charset = "";
        //set the response mime type for excel

        response.ContentType = "application/vnd.ms-excel";
        //create a string writer
        //response.AddHeader("Content-Disposition", "attachment;filename=Shilpa.xls");

        response.AddHeader("Content-Disposition", "attachment;filename=" + ExcelName + ".xls");


        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //create an htmltextwriter which uses the stringwriter
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        //instantiate a datagrid
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        //set the datagrid datasource to the dataset passed in
        dg.DataSource = ds.Tables[0];
        //bind the datagrid
        dg.DataBind();
        //tell the datagrid to render itself to our htmltextwriter
        dg.RenderControl(htmlWrite);
        //all that's left is to output the html
        response.Write(stringWrite.ToString());
        response.End();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }
    public static void Convert(System.Data.DataSet ds, string ExcelName)
    {
        //try
        //{
        //first let's clean up the response.object
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.Charset = "";
        //set the response mime type for excel

        response.ContentType = "application/vnd.ms-excel";
        //create a string writer
        //response.AddHeader("Content-Disposition", "attachment;filename=Shilpa.xls");

        response.AddHeader("Content-Disposition", "attachment;filename=" + ExcelName + ".xls");


        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //create an htmltextwriter which uses the stringwriter
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        //instantiate a datagrid
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        //set the datagrid datasource to the dataset passed in
        dg.DataSource = ds.Tables[0];
        //bind the datagrid
        dg.DataBind();
        //tell the datagrid to render itself to our htmltextwriter
        dg.RenderControl(htmlWrite);
        //all that's left is to output the html
        response.Write(stringWrite.ToString());
        response.Flush();
        response.End();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }



    public static void Convert(System.Data.DataSet ds, int TableIndex, System.Web.HttpResponse response, string ExcelName)
    {
        //lets make sure a table actually exists at the passed in value
        //if it is not call the base method
        if (TableIndex > ds.Tables.Count - 1)
        {
            Convert(ds, response, ExcelName);
        }
        //we've got a good table so
        //let's clean up the response.object
        response.Clear();
        response.Charset = "";
        response.AddHeader("Content-Disposition", "attachment;filename=Shilpa.xls");
        //set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel";
        //create a string writer
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //create an htmltextwriter which uses the stringwriter
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        //instantiate a datagrid
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        //set the datagrid datasource to the dataset passed in
        dg.DataSource = ds.Tables[TableIndex];
        //bind the datagrid
        dg.DataBind();
        //tell the datagrid to render itself to our htmltextwriter
        dg.RenderControl(htmlWrite);
        //all that's left is to output the html
        response.Write(stringWrite.ToString());
        response.End();
    }

    public static void Convert(System.Data.DataSet ds, string TableName, System.Web.HttpResponse response, string ExcelName)
    {
        //let's make sure the table name exists
        //if it does not then call the default method
        if (ds.Tables[TableName] == null)
        {
            Convert(ds, response, ExcelName);
        }
        //we've got a good table so
        //let's clean up the response.object
        response.Clear();
        response.Charset = "";
        //set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel";
        //create a string writer
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //create an htmltextwriter which uses the stringwriter
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        //instantiate a datagrid
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        //set the datagrid datasource to the dataset passed in
        dg.DataSource = ds.Tables[TableName];
        //bind the datagrid
        dg.DataBind();
        //tell the datagrid to render itself to our htmltextwriter
        dg.RenderControl(htmlWrite);
        //all that's left is to output the html
        response.Write(stringWrite.ToString());
        response.End();
    }

}