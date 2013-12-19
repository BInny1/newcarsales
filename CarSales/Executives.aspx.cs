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


public partial class Executives : System.Web.UI.Page
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
                    GetExecutivesList();
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
           // ddlcenters.Items.Insert(0, new ListItem("All", "0"));
          //  ddlcenters.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetExecutivesList()
    {
        DataSet ExecutiveRight = new DataSet();
        ExecutiveRight = objHotLeadBL.ExecutiveRights(Convert.ToInt32(ddlcenters.SelectedValue));
        Session["ExecutiveRights"] = ExecutiveRight;
        GridExecutvRights.DataSource = ExecutiveRight.Tables[0];
        GridExecutvRights.DataBind();

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

    protected void GridExecutvRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lblEmpName = (LinkButton)e.Row.FindControl("lblEmpName");
                LinkButton lblRole = (LinkButton)e.Row.FindControl("lblRole");
                LinkButton lblExecut = (LinkButton)e.Row.FindControl("lblExecut");
                DataSet dsTasks3 = (DataSet)Session["ExecutiveRights"];
                lblEmpName.Text = dsTasks3.Tables[0].Rows[e.Row.RowIndex]["FirstName"].ToString() + " " + dsTasks3.Tables[0].Rows[e.Row.RowIndex]["lastname"].ToString();
                lblRole.Text = dsTasks3.Tables[0].Rows[e.Row.RowIndex]["RoleName"].ToString();
                if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["Executive"].ToString() != "")
                {
                    lblExecut.Text = "Y";
                    lblExecut.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblExecut.Text = "";
                }
                
            }
          
        }
        catch { }
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                 Label lblTotalCount = (Label)e.Row.FindControl("lblTotalCount");
                 DataSet dsTasks4 = (DataSet)Session["ExecutiveRights"];
                int CounVal=0;
                for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
               {
                   if (dsTasks4.Tables[0].Rows[i][3].ToString() != "")
                   {
                       CounVal = CounVal + 1;
                   }
                 
                  
               }


               lblTotalCount.Text = CounVal.ToString();
            }
        }
        catch { }
    }


    protected void ddlcenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetExecutivesList();
    }
    public void lnlupdatelist_Click(object sender, EventArgs e)
    {

        MpUserUpdatelist.Show();
        //DataSet dsSalesUpdateList = objHotLeadBL.SalesUsersUpdateList(Convert.ToInt32(ddlcenters.SelectedValue));
        //GridExecutivs.DataSource = dsSalesUpdateList.Tables[0];
        //GridExecutivs.DataBind();

    }
    public void btnUpda_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in GridUserUpdateList.Rows)
        {
            CheckBox chk = row.Cells[0].FindControl("chk_Check") as CheckBox;
            if (chk != null && chk.Checked)
            {
                Label lblSalesEmpid = row.Cells[0].FindControl("lblSalesEmpid") as Label;
                DropDownList lblSalesRoleId = row.Cells[0].FindControl("ddlsalesroles") as DropDownList;

                DataSet InsertEmployee = objHotLeadBL.UInsertEmpandRightsss(lblSalesEmpid.Text, Convert.ToInt32(lblSalesRoleId.Text),
                    Convert.ToInt32(ddlcenters.SelectedValue), Session[Constants.USER_NAME].ToString());

            }
        }
       // MpUserUpdatelist.Hide();
        GetExecutivesList();
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Selected employees are added successfully.');", true);
    }
}
