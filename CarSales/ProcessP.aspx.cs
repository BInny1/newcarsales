using System;
using System.Collections;
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
using HotLeadBL;
using HotLeadInfo;
using HotLeadBL.Transactions;
using HotLeadBL.CentralDBTransactions;
using HotLeadInfo;
using HotLeadBL.Masters;
using System.Collections.Generic;
using HotLeadBL.HotLeadsTran;
using System.Net.Mail;


public partial class ProcessP : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserregInfo = new UserRegistrationInfo();
    HotLeadsBL objHotLeadBL = new HotLeadsBL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Session["CurrentPage"] = "Brands";

                if (LoadIndividualUserRights() == false)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (Session[Constants.NAME] == null)
                    {
                        lnkBtnLogout.Visible = false;
                        lblUserName.Visible = false;
                    }
                    else
                    {

                        // LoadUserRights();
                        lnkBtnLogout.Visible = true;
                        lblUserName.Visible = true;
                        string LogUsername = Session[Constants.NAME].ToString();
                        string CenterCode = Session[Constants.CenterCode].ToString();
                        string UserLogName = Session[Constants.USER_NAME].ToString();
                        string Name = LogUsername + " " + UserLogName;
                        LogUsername = Name;
                        if (LogUsername.Length > 20)
                        {
                            lblUserName.Text = LogUsername.ToString().Substring(0, 20);
                            lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")";

                        }
                        else
                        {
                            lblUserName.Text = LogUsername;
                            if (CenterCode.Length > 5)
                            {
                                lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString().Substring(0, 5) + ")";
                            }
                            else
                            {
                                lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")";
                            }
                            //lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")";
                        }
                        // lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");

                        Session["SortDirec"] = null;


                        ListItem list2 = new ListItem();
                        list2.Value = Session[Constants.CenterCodeID].ToString();
                        int val1 = Convert.ToInt32(list2.Value.ToString());

                    }
                    GetAllLocations();
                    GetLeadsSattus();
                }
            }
        }
    }
    private void GetAllLocations()
    {

        try
        {
            DataSet dsCenters = objHotLeadBL.GetAllLocations();
            ddlcenters.Items.Clear();
            for (int i = 0; i < dsCenters.Tables[0].Rows.Count; i++)
            {
                if (dsCenters.Tables[0].Rows[i]["LocationId"].ToString() != "0")
                {
                    ListItem list = new ListItem();
                    list.Text = dsCenters.Tables[0].Rows[i]["LocationName"].ToString();
                    list.Value = dsCenters.Tables[0].Rows[i]["LocationId"].ToString();
                    ddlcenters.Items.Add(list);
                }
            }
            ddlcenters.Items.Insert(0, new ListItem("All", "0"));
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetLeadsSattus()
    {
        DataSet dsLeadsStat = new DataSet();
        dsLeadsStat = objHotLeadBL.PerocessRightsStatus(Convert.ToInt32(ddlcenters.SelectedValue));
        Session["ProcessDataset"] = dsLeadsStat;
        GridQcProcessStatus.DataSource = dsLeadsStat.Tables[0];
        GridQcProcessStatus.DataBind();

    }
    private bool LoadIndividualUserRights()
    {
        DataSet dsIndidivitualRights = new DataSet();
        bool bValid = false;
        dsIndidivitualRights = objHotLeadBL.GetUserModules_ActiveInactive(Session[Constants.USER_ID].ToString());
        if (Session["IndividualUserRights"] == null)
        {
            dsIndidivitualRights = objHotLeadBL.GetUserModules_ActiveInactive(Session[Constants.USER_ID].ToString());
            Session["IndividualUserRights"] = dsIndidivitualRights;
        }
        else
        {
            dsIndidivitualRights = Session["IndividualUserRights"] as DataSet;
        }
        if (dsIndidivitualRights.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsIndidivitualRights.Tables[0].Rows.Count; i++)
            {

                //if (dsIndidivitualRights.Tables[0].Rows[i]["SubModuleName"].ToString() == Session["CurrentPage"].ToString())
                //{
                if (dsIndidivitualRights.Tables[0].Rows[i]["active"].ToString() == "1")
                {
                    string Modulename = dsIndidivitualRights.Tables[0].Rows[i]["SubModuleName"].ToString();

                    LinkButton lbl;
                    lbl = (LinkButton)Page.FindControl(Modulename);
                    try
                    {
                        lbl.Enabled = true;
                    }
                    catch { }
                }
                else
                {
                    string Modulename = dsIndidivitualRights.Tables[0].Rows[i]["SubModuleName"].ToString();
                    LinkButton lbl1;
                    lbl1 = (LinkButton)Page.FindControl(Modulename);
                    try
                    {
                        lbl1.Enabled = false;
                    }
                    catch { }
                }



            }
            bValid = true;
            return bValid;
            //}
        }
        return bValid;
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    protected void GrdSttalStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lblEmpName = (LinkButton)e.Row.FindControl("lblEmpName");
                LinkButton lblRole = (LinkButton)e.Row.FindControl("lblRole");
                LinkButton QCProcess = (LinkButton)e.Row.FindControl("lblQcProcess");
                LinkButton lblPaymentProcess = (LinkButton)e.Row.FindControl("lblPaymentProcess");
                LinkButton lblProcessAdmin = (LinkButton)e.Row.FindControl("lblProcessAdmin");
                DataSet dsTasks3 = (DataSet)Session["ProcessDataset"];
                lblEmpName.Text = dsTasks3.Tables[0].Rows[e.Row.RowIndex]["FirstName"].ToString() + " " + dsTasks3.Tables[0].Rows[e.Row.RowIndex]["lastname"].ToString();
                lblRole.Text = dsTasks3.Tables[0].Rows[e.Row.RowIndex]["RoleName"].ToString();
                if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["QC"].ToString() != "")
                {
                    QCProcess.Text = "Y";
                    QCProcess.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    QCProcess.Text = "";
                }
                if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["Payment"].ToString() != "")
                {
                    lblPaymentProcess.Text = "Y";
                    lblPaymentProcess.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblPaymentProcess.Text = "";
                }
                if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["ProcessAdmin"].ToString() != "")
                {
                    lblProcessAdmin.Text = "Y";
                    lblProcessAdmin.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblProcessAdmin.Text = "";
                }
            }
        }
        catch { }
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dsTasks4 = (DataSet)Session["ProcessDataset"];
                Label lblQCCount = (Label)e.Row.FindControl("lblQCCount");
                Label lblPayCount = (Label)e.Row.FindControl("lblPayCount");
                Label lbladmin = (Label)e.Row.FindControl("lbladmin");
                int CounQCVal = 0, CounPayVal = 0, CounAdminVal = 0;
                for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
                {

                    if (dsTasks4.Tables[0].Rows[i][3].ToString() == "10")
                    {
                        CounQCVal = CounQCVal + 1;
                    }
                    if (dsTasks4.Tables[0].Rows[i][4].ToString() == "11")
                    {
                        CounPayVal = CounPayVal + 1;
                    } 
                    if (dsTasks4.Tables[0].Rows[i][5].ToString() == "20")
                    {
                        CounAdminVal = CounAdminVal + 1;
                    }


                }


                lblQCCount.Text = CounQCVal.ToString();
                lblPayCount.Text = CounPayVal.ToString();
                lbladmin.Text = CounAdminVal.ToString();
            }
        }
        catch { }
    }
    protected void GridQcProcessStatus_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "EID";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Name";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Role";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Process";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Process Admin";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            GridQcProcessStatus.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }

    }
    protected void ddlcenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetLeadsSattus();


    }
}