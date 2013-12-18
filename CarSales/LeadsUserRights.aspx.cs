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


public partial class LeadsUserRights : System.Web.UI.Page
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



                        GetAllLocations();
                        GetLeadsUserRights(Convert.ToInt32(ddlcenters.SelectedValue));
                    }

                }
            }
        }
    }
    protected void ddlcenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetLeadsUserRights((Convert.ToInt32(ddlcenters.SelectedValue)));
    }
    private void GetLeadsUserRights(int LocationId)
    {
     
        DataSet GetLeadsRights = new DataSet();
        GetLeadsRights = objHotLeadBL.GetLeadsUserRights((Convert.ToInt32(ddlcenters.SelectedValue)));
        Session["LeadsuserRights"] = GetLeadsRights;
        GridDefaultUserRights.DataSource = GetLeadsRights.Tables[0];
        GridDefaultUserRights.DataBind();
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
    protected void GridDefaultUserRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton lblLeadsUpload = (LinkButton)e.Row.FindControl("lblLeadsUpload");
                LinkButton LeadsAdmin = (LinkButton)e.Row.FindControl("LeadsAdmin");
                DataSet dsTasks3 = (DataSet)Session["LeadsuserRights"];
                if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["Leads"].ToString() == "14")
                {
                    lblLeadsUpload.Text = "Y";
                }
                else
                {
                    lblLeadsUpload.Text = "";
                }
                if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["LeadsAdmin"].ToString() == "18")
                {
                    LeadsAdmin.Text = "Y";
                }
                else
                {
                    LeadsAdmin.Text = "";
                }
            }

        }
        catch { }
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalCount = (Label)e.Row.FindControl("lblleadscoun");
                Label lblleadsAdmincoun = (Label)e.Row.FindControl("lblleadsAdmincoun");
                DataSet dsTasks4 = (DataSet)Session["LeadsuserRights"];
                int CounlreadsVal = 0, CounldminVal=0;
                for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
                {
                    if (dsTasks4.Tables[0].Rows[i][7].ToString() == "14")
                    {
                        CounlreadsVal = CounlreadsVal + 1;
                    }
                    if (dsTasks4.Tables[0].Rows[i][8].ToString() == "18")
                    {
                        CounldminVal = CounldminVal + 1;
                    }


                }


                lblTotalCount.Text = CounlreadsVal.ToString();
                lblleadsAdmincoun.Text = CounldminVal.ToString();
            }
        }
        catch { }
    }
}
