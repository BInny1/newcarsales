using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using System.Net.Mail;


/// <summary>
/// Summary description for BizUtility
/// </summary>
public class BizUtility
{
    /// <summary>
    /// Get All States
    /// </summary>
    /// <param name="ddlStates"></param>




    /// <summary>
    /// This method is used to sort the contents of the gridview
    /// </summary>
    /// <param name="formName">Form name </param>
    /// <param name="sortDir">Sort direction</param>
    /// <param name="sortExpr">Sort Expression</param>
    /// <param name="grdReport">Display grid</param>
    public static void GridSortingEx(int formNameNumber, string sortDir, string sortExpr, ref System.Web.UI.WebControls.GridView grdReport, object objCollection)
    {
        GridSorting.GridSort(sortDir, sortExpr, ref grdReport, objCollection, true);
    }


    /// <summary>
    /// This event is used to sort the contents of the grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void GridSort(HtmlInputHidden txthdnSortOrder, GridViewSortEventArgs e, GridView grdReport, int formName, object objCollection)
    {
        string strSortDir = null;

        try
        {
            //storing the value in hidden variable
            if (txthdnSortOrder.Value.Length == 0)
            {
                txthdnSortOrder.Value = e.SortDirection.ToString();
            }

            //To reverse the sort order
            if (txthdnSortOrder.Value.Length != 0)
            {
                if (txthdnSortOrder.Value == "Ascending")
                {
                    txthdnSortOrder.Value = "Descending";
                }
                else
                {
                    txthdnSortOrder.Value = "Ascending";
                }
            }

            //checking the condition and sorting accordingly
            switch (txthdnSortOrder.Value)
            {
                case "Ascending":
                    strSortDir = "ASC";
                    break;

                case "Descending":
                    strSortDir = "DESC";
                    break;
            }

            //Appending arrow symbol to the grid header according to the sorting.
            GridSorting.AppendSortOrderImageToGridHeader(txthdnSortOrder.Value, e.SortExpression, ref grdReport);
            GridSortingEx(formName, strSortDir, e.SortExpression, ref grdReport, objCollection);

            //Add data to the GridView
            //GridSorting.MakeAccessible(grdReport);
        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, ARSConstants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;

            ////Redirecting to error message page
            //HttpContext.Current.Server.Transfer(ARSConstants.StrErrorPageURL);
        }
    }


    public static void GridSortForReport(HtmlInputHidden txthdnSortOrder, string eSortExp, GridView grdReport, int formName, object objCollection, string SortDirec)
    {
        string strSortDir = null;

        try
        {

            txthdnSortOrder.Value = SortDirec;


            //checking the condition and sorting accordingly
            switch (txthdnSortOrder.Value)
            {
                case "Ascending":
                    strSortDir = "ASC";
                    break;

                case "Descending":
                    strSortDir = "DESC";
                    break;
            }

            //Appending arrow symbol to the grid header according to the sorting.
            GridSorting.AppendSortOrderImageToGridHeader(txthdnSortOrder.Value, eSortExp, ref grdReport);
            GridSortingEx(formName, strSortDir, eSortExp, ref grdReport, objCollection);

            //Add data to the GridView
            //GridSorting.MakeAccessible(grdReport);
        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, ARSConstants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;

            ////Redirecting to error message page
            //HttpContext.Current.Server.Transfer(ARSConstants.StrErrorPageURL);
        }
    }

}
