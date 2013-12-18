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


public partial class DefaultRights : System.Web.UI.Page
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



                        GetUserDefaultRights();
                    }

                }
            }
        }
    }
    private void GetUserDefaultRights()
    {
        DataSet GetUserDefaultRight = new DataSet();
        GetUserDefaultRight = objHotLeadBL.GetMasterRoles();
        Session["MasterRoles"] = GetUserDefaultRight;
        GridDefaultUserRights.DataSource = GetUserDefaultRight.Tables[0];
        GridDefaultUserRights.DataBind();
    }

   
    protected void GridDefaultUserRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dsTasks3 = (DataSet)Session["MasterRoles"];
                LinkButton lblRole = (LinkButton)e.Row.FindControl("lblRoleNamre");
                HiddenField Paymst = (HiddenField)e.Row.FindControl("hdnRoleId");
                Label lblVehType = (Label)e.Row.FindControl("lblVehType");
                lblVehType.Text = "Default";
                try
                {
                    DataSet GetUserDefaultRight = new DataSet();
                    string Paystats = Paymst.Value;
                    GetUserDefaultRight = objHotLeadBL.GetUserDefaultRights(Convert.ToInt32(Paystats));

                    for (int i = 0; i <= 5; i++)
                    {
                        Label lblLeads = (Label)e.Row.FindControl("lblLeads");
                        Label LblTransfers = (Label)e.Row.FindControl("LblTransfers");
                        Label lblabondons = (Label)e.Row.FindControl("lblabondons");
                        Label lblfreepots = (Label)e.Row.FindControl("lblfreepots");

                        Label lblintromail = (Label)e.Row.FindControl("lblintromail");
                        Label lblNeEntry = (Label)e.Row.FindControl("lblNeEntry");
                        Label lblTransferOut = (Label)e.Row.FindControl("lblTransferOut");
                        Label lblTicker = (Label)e.Row.FindControl("lblTicker");

                        Label lblSelf = (Label)e.Row.FindControl("lblSelf");
                        Label lblCenter = (Label)e.Row.FindControl("lblCenter");

                        Label lblAdmin = (Label)e.Row.FindControl("lblAdmin");

                        //1 Leads
                        if (GetUserDefaultRight.Tables[0].Rows[0]["IsActive"].ToString() == "False")
                        {
                            LblTransfers.Text = "N"; lblabondons.Text = "N"; lblLeads.Text = "N"; lblfreepots.Text = "N";
                        }
                        else
                        {
                            LblTransfers.Text = "Y"; lblabondons.Text = "Y"; lblLeads.Text = "Y"; lblfreepots.Text = "Y";
                        }
                        //Sales
                        if (GetUserDefaultRight.Tables[0].Rows[1]["IsActive"].ToString() == "False")
                        {
                            lblintromail.Text = "N"; lblNeEntry.Text = "N"; lblTransferOut.Text = "N"; lblTicker.Text = "N";
                        }
                        else
                        {
                            lblintromail.Text = "Y"; lblNeEntry.Text = "Y"; lblTransferOut.Text = "Y"; lblTicker.Text = "Y";
                        }
                        //3 Reports
                        //4 Process
                        if (GetUserDefaultRight.Tables[0].Rows[3]["IsActive"].ToString() == "False")
                        {
                            if (lblRole.Text == "Center Manager")
                            {
                                lblSelf.Text = "N"; lblCenter.Text = "Y";
                            }
                            else
                            {
                                lblSelf.Text = "N"; lblCenter.Text = "N";
                            }
                        }
                        else
                        {
                            if (lblRole.Text == "Center Manager")
                            {
                                lblSelf.Text = "Y"; lblCenter.Text = "Y";
                            }
                            else
                            {
                                lblSelf.Text = "Y"; lblCenter.Text = "N";
                            }
                        }
                        //Admin
                        if ((GetUserDefaultRight.Tables[0].Rows[4]["IsActive"].ToString() == "False"))
                        {
                            lblAdmin.Text = "N";
                        }
                        else
                        {
                            lblAdmin.Text = "Y";
                        }
                        //2sales

                        //3 Process

                        //4 Reports

                        //5 admin


                    }

                }
                catch { }
            }
        }
        catch { }
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    private void LoadUserRights()
    {
        DataSet dsSession = new DataSet();
        dsSession = objHotLeadBL.GetUserSession(Convert.ToInt32(Session[Constants.USER_ID]));

        if (dsSession.Tables[0].Rows[0]["SessionID"].ToString() != HttpContext.Current.Session.SessionID.ToString())
        {

            Session["SessionTimeOut"] = 1;
            Response.Redirect("Login.aspx");

        }

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
  
protected void  GridDefaultUserRights_RowCreated(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.Header)
    {
        GridView HeaderGrid = (GridView)sender;

        GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell HeaderCell = new TableCell();
        HeaderCell.Text = "Role";
        HeaderCell.ColumnSpan = 1;
        HeaderGridRow.Cells.Add(HeaderCell);
        
        
        HeaderCell = new TableCell();
        HeaderCell.Text = "Vehicle Type(s)";
        HeaderCell.ColumnSpan = 1;
        HeaderGridRow.Cells.Add(HeaderCell);

        HeaderCell = new TableCell();
        HeaderCell.Text = "Leads Download";
        HeaderCell.ColumnSpan = 4;
        HeaderGridRow.Cells.Add(HeaderCell);
        HeaderCell.CssClass = "BL BR";

        HeaderCell = new TableCell();
        HeaderCell.Text = "Sales";
        HeaderCell.ColumnSpan = 4;
        HeaderGridRow.Cells.Add(HeaderCell);

        
        HeaderCell = new TableCell();
        HeaderCell.Text = "Reports";
        HeaderCell.ColumnSpan = 2;
        HeaderGridRow.Cells.Add(HeaderCell);
        HeaderCell.CssClass = "BL BR";

         
        HeaderCell = new TableCell();
        HeaderCell.Text = "Sales Admin";
        HeaderCell.ColumnSpan = 1;
        HeaderGridRow.Cells.Add(HeaderCell);
        
        GridDefaultUserRights.Controls[0].Controls.AddAt(0, HeaderGridRow);
    }

}
}
