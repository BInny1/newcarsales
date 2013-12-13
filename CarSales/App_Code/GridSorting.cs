/**********************************************************************
 MODULE       :  ARS
 FILENAME     :  GridSorting.cs
 AUTHOR       :  Julius
 CREATED      :  29-MAY-2007
 COPYRIGHT    :  KEN IT Solutions
 DESCRIPTION  :  This page will do the ascending and descending sorting of grid
'*********************************************************************/

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using System.Text;

/// <summary>
/// Summary description for GridSorting
/// </summary>
public class GridSorting
{
    /// <summary>
    /// Constructor
    /// </summary>
    public GridSorting()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// To append image to grid header
    /// </summary>
    /// <param name="sortDir">Direction of sorting</param>
    /// <param name="sortExpr">sort expression</param>
    /// <param name="grid">Grid name</param>
    public static void AppendSortOrderImageToGridHeader(string sortDir, string sortExpr, ref System.Web.UI.WebControls.GridView grid)
    {
        try
        {
            int i;
            int foundColumnIndex = -1;

            const string SORT_ASC = "      &#8659;"; 
            const string SORT_DESC = "      &#8657";

            for (i = 0; i <= grid.Columns.Count - 1; i++)
            {
                grid.Columns[i].HeaderText = grid.Columns[i].HeaderText.Replace(SORT_ASC, string.Empty);
                grid.Columns[i].HeaderText = grid.Columns[i].HeaderText.Replace(SORT_DESC, string.Empty);

                if (sortExpr == grid.Columns[i].SortExpression)
                {
                    foundColumnIndex = i;
                }
            }

            if (foundColumnIndex > -1)
            {
                if (sortDir == Constants.StrAscending)
                {
                    grid.Columns[foundColumnIndex].HeaderText += SORT_ASC;
                }
                else
                {
                    grid.Columns[foundColumnIndex].HeaderText += SORT_DESC;
                }
            }
        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, Constants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;
        }
    }

    /// <summary>
    /// To sort the grid
    /// </summary>
    /// <param name="sortDir">Direction of sorting</param>
    /// <param name="sortExpr">sort expression</param>
    /// <param name="grid">Grid name</param>
    /// <param name="objData">Object Name</param>
    public static void GridSort(string sortDir, string sortExpr, ref System.Web.UI.WebControls.GridView grid, object objData, bool display)
    {
        try
        {
            BindGrid(sortDir, sortExpr, ref grid, objData, display);
        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, Constants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;
        }
    }

    /// <summary>
    /// This method is used to sort the contents and bind it to the datagrid
    /// </summary>
    /// <param name="sortDir">Direction of sorting</param>
    /// <param name="sortColumn">Sort column name</param>
    private static void BindGrid(string sortDir, string sortColumn, ref System.Web.UI.WebControls.GridView grid, object objectPending, bool display)
    {
        DataTable inciDataTable;
        try
        {
            //if (display)
            //{
            //    grid.Columns[3].Visible = true;
            //}

            DataTable objDatatable = new DataTable(); 
            //converting the collection list to a datatable
            objDatatable = (DataTable)objectPending;

            inciDataTable = CreateDataSource(objDatatable);

            //We sort the datatable here
            if (sortDir != null && sortDir == "ASC")
            {
                inciDataTable.DefaultView.Sort = sortColumn + " asc";
            }

            //Check to see if the sort direction is desc
            if (sortDir != null && sortDir == "DESC")
            {
                inciDataTable.DefaultView.Sort = sortColumn + " desc";
            }

            //Assign the datatable to the gridview and bind it
            grid.DataSource = inciDataTable;
            grid.DataBind();
            //if (display)
            //{
            //    grid.Columns[3].Visible = false;
            //}

        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, ARSConstants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;
        }
        finally
        {
            objectPending = null;
        }
    }

    /// <summary>
    /// This method takes in arraylist as input and converts it into a datatable and returns the datatable
    /// </summary>
    /// <param name="alist">Array list</param>
    /// <returns>Data Table</returns>
    private static DataTable CreateDataSource(DataTable dt)
    {
        
        DataRow dr;
        object tempObject;
        object objGetVal;
        try
        {

            
        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, Constants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;

        }
        finally
        {
            objGetVal = null;
            tempObject = null;
        }
        return dt;
    }

    /// <summary>
    /// This method takes in arraylist as input and converts it into a datatable and returns the datatable
    /// </summary>
    /// <param name="alist">Array list</param>
    /// <returns>Data Table</returns>
    private static DataTable CreateDataSource(ArrayList alist)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        object tempObject;
        object objGetVal;
        try
        {
            //Checking for the number of rows in the Arraylist
            if (alist.Count == 0)
            {
                throw new FormatException(Constants.StrFormatException);
            }
            dt.TableName = alist[0].GetType().Name;

            System.Reflection.PropertyInfo[] propInfo = alist[0].GetType().GetProperties();

            //Adding columns into the datatable
            for (int i = 0; i < propInfo.Length; i++)
            {
                dt.Columns.Add(propInfo[i].Name, propInfo[i].PropertyType);
            }

            //Adding rows into the datatable
            for (int row = 0; row < alist.Count; row++)
            {
                dr = dt.NewRow();

                for (int i = 0; i < propInfo.Length; i++)
                {
                    tempObject = alist[row];
                    objGetVal = propInfo[i].GetValue(tempObject, null);
                    if (objGetVal != null)
                        dr[i] = objGetVal.ToString();
                }
                dt.Rows.Add(dr);
            }
        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, Constants.StrPerDatumUIPolicy);

            //if (rethrow)
            //    throw;

        }
        finally
        {
            objGetVal = null;
            tempObject = null;
        }
        return dt;
    }

    /// <summary>
    /// To display the thead and tbody html tags
    /// </summary>
    /// <param name="grid">grid name</param>
    public static void MakeAccessible(GridView grid)
    {
        if (grid.Rows.Count > 0)
        {
            //This replaces <td> with <th> and adds the scope attribute
            grid.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            grid.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element. Remove if you don't have a footer row
            grid.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}
