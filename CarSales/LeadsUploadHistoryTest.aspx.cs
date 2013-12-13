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
using HotLeadBL.Leads;
using HotLeadBL.Masters;

public partial class AddNewCenters : System.Web.UI.Page
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
                Session["CurrentPage"] = "Leads";

                //if (LoadIndividualUserRights() == false)
                //{
                //    Response.Redirect("Login.aspx");
                //}
                //else
                //{
                if (Session[Constants.NAME] == null)
                {
                    lnkBtnLogout.Visible = false;
                    lblUserName.Visible = false;
                }
                else
                {
                    LoadUserRights();
                    lnkBtnLogout.Visible = true;
                    lblUserName.Visible = true;
                    string LogUsername = Session[Constants.NAME].ToString();
                    string CenterCode = Session[Constants.CenterCode].ToString();
                    string UserLogName = Session[Constants.USER_NAME].ToString();
                    if (LogUsername.Length > 20)
                    {
                        lblUserName.Text = LogUsername.ToString().Substring(0, 20);
                        //if (CenterCode.Length > 5)
                        //{
                        //    lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString().Substring(0, 5) + ")";
                        //}
                        //else
                        //{
                        lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")-" + UserLogName.ToString();
                        //}
                    }
                    else
                    {
                        lblUserName.Text = LogUsername;
                        lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")-" + UserLogName.ToString();
                    }
                    lblCenterCode.Text = "Center code is " + CenterCode.ToString();                 
                }
                lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");
                LoadVehicletype();


            }
        }
    }


    private void LoadVehicletype()
    {
        try
        {
            VehicleTypeBL objVehicleTypeBL = new VehicleTypeBL();

            DataSet dsVehicleTypes = new DataSet();

            if (Cache["VehicleType"] == null)
            {
                dsVehicleTypes = objVehicleTypeBL.GetVehicleType();
                Cache["VehicleType"] = dsVehicleTypes;
            }
            else
            {
                dsVehicleTypes = (DataSet)Cache["VehicleType"];
            }



            ddlVehicleType.DataValueField = "VehicleTypeID";
            ddlVehicleType.DataTextField = "VehicleType";
            ddlVehicleType.DataSource = dsVehicleTypes.Tables[0];
            ddlVehicleType.DataBind();


        }
        catch (Exception ex)
        {

        }
    }



    #region LoadUserRight

    private bool LoadIndividualUserRights()
    {
        DataSet dsIndidivitualRights = new DataSet();
        bool bValid = false;
        dsIndidivitualRights = objHotLeadBL.GetUserModules_ActiveInactive(Session[Constants.USER_ID].ToString());

        if (dsIndidivitualRights.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsIndidivitualRights.Tables[0].Rows.Count; i++)
            {

                if (dsIndidivitualRights.Tables[0].Rows[i]["ModuleName"].ToString() == Session["CurrentPage"].ToString())
                {
                    if (dsIndidivitualRights.Tables[0].Rows[i]["ModuleActive"].ToString() == "1")
                    {
                        bValid = true;
                        break;
                    }

                }


            }
        }
        return bValid;
    }
    private void LoadUserRights()
    {
        DataSet dsSession = new DataSet();
        dsSession = objHotLeadBL.GetUserSession(Convert.ToInt32(Session[Constants.USER_ID]));

        if (dsSession.Tables[0].Rows[0]["SessionID"].ToString() != HttpContext.Current.Session.SessionID.ToString())
        {
            // objUserlog.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), System.DateTime.Now, Convert.ToInt32(Session[Constants.USERLOG_ID]), 8);

            Session["SessionTimeOut"] = 1;
            Response.Redirect("Login.aspx");

        }

    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            HotLeadsBL objHotLeadsBL = new HotLeadsBL();
            DataSet dsDatetime = objHotLeadBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            objHotLeadsBL.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), dtNow, Convert.ToInt32(Session[Constants.USERLOG_ID]), 2);
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    #endregion LoadUserRight


    private void GetLeadsDownloadHistory()
    {

        LeadsDownloadBL objLeadsDownloadBL = new LeadsDownloadBL();

        DataSet dsStateAllocation = objLeadsDownloadBL.GetLeadsDownloadUploadHistory(ddlVehicleType.SelectedItem.Value);

        rptrDownload.DataSource = dsStateAllocation.Tables[0];
        rptrDownload.DataBind();



    }
    protected void grdStateWiseLeadsAllocation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataSet dsFillCenters = new DataSet();
            if (Cache["Centers"] == null)
            {
                dsFillCenters = objHotLeadBL.GetMasterAgentCenters();
                Cache["Centers"] = dsFillCenters;
            }
            else
            {
                dsFillCenters = Cache["Centers"] as DataSet;
            }

            DropDownList ddlDropDownList = (DropDownList)e.Row.FindControl("ddlDropDownList");

            ddlDropDownList.DataSource = dsFillCenters.Tables[0];
            ddlDropDownList.DataTextField = "AgentCenterCode";
            ddlDropDownList.DataValueField = "AgentCenterID";
            ddlDropDownList.DataBind();
            ddlDropDownList.Items.Insert(0, new ListItem("Select", "0"));

            HiddenField hdnCenterID = (HiddenField)e.Row.FindControl("hdnCenterID");

            if (hdnCenterID.Value != "")
            {
                ddlDropDownList.SelectedIndex = ddlDropDownList.Items.IndexOf(ddlDropDownList.Items.FindByValue(hdnCenterID.Value));
            }
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        //for (int index = 0; index < grdStateWiseLeadsAllocation.Rows.Count; index++)
        //{
        //    //objAllocation.SetLeadAssignAllocationForCenters(((DropDownList)grdStateWiseLeadsAllocation.Rows[index].FindControl("ddlDropDownList")).SelectedValue.ToString(), ((HiddenField)grdStateWiseLeadsAllocation.Rows[index].FindControl("lblCSID")).Value.ToString());
        //}

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        GetLeadsDownloadHistory();
    }
    protected void rptrDownload_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton lblIssuanceBatchID = (LinkButton)e.Item.FindControl("lblIssuanceBatchID");
        LeadsDownloadBL obj = new LeadsDownloadBL();

        DataSet ds = obj.LeadsUploadDetailsByBatchID(lblIssuanceBatchID.Text);

        DataSetToExcel.Convert(ds, Response, "LeadsHistory" + lblIssuanceBatchID.Text);
    }
}
