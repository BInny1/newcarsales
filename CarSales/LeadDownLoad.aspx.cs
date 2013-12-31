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


public partial class LeadDownLoad : System.Web.UI.Page
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
                Session["CurrentPage"] = "Central report";

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
                        // lblAgentAddCenterCode.Text = "Center code is " + CenterCode.ToString();

                    }
                    lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");
                    //LoadVehicletype();
                    FillCenters();
                    //FillCenterRights();
                    //LoadDDL();
                }
            }
        }
    }

    protected override void OnUnload(EventArgs e)
    {

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

    private void FillCenters()
    {
        try
        {



            CenterBL objCenterBL = new CenterBL();

            DataSet dsVehicleTypes = new DataSet();

            if (Cache["Centers"] == null)
            {
                dsVehicleTypes = objHotLeadBL.GetAllLocations();
                Cache["Centers"] = dsVehicleTypes;
            }
            else
            {
                dsVehicleTypes = (DataSet)Cache["Centers"];
            }



            ddlCenter.DataValueField = "LocationId";
            ddlCenter.DataTextField = "LocationName";
            ddlCenter.DataSource = dsVehicleTypes.Tables[0];
            ddlCenter.DataBind();


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
                //else
                //{
                //    string Modulename = dsIndidivitualRights.Tables[0].Rows[i]["SubModuleName"].ToString();
                //    LinkButton lbl1;
                //    lbl1 = (LinkButton)Page.FindControl(Modulename);
                //    try
                //    {
                //        lbl1.Enabled = false;
                //    }
                //    catch { }
                //}



            }
            bValid = true;
            return bValid;
            //}
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



    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        //for (int index = 0; index < grdStateWiseLeadsAllocation.Rows.Count; index++)
        //{
        //    //
        //}

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        try
        {
            GetResultsData();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void GetResultsData()
    {
        try
        {
            LeadsDownloadBL objLeadDownload = new LeadsDownloadBL();

            DataSet dsLeadsStats = objLeadDownload.GetAllcotedLeadsConsolidated(ddlVehicleType.SelectedValue, ddlCenter.SelectedValue, txtStartDate.Text, txtEndDate.Text);
            if (dsLeadsStats.Tables[0].Rows.Count > 0)
            {
                dvLeads.Style["display"] = "block";
                rptrDownload.DataSource = dsLeadsStats.Tables[0];
                rptrDownload.DataBind();
                dvLeads.Visible = true;
                lblResHead.Visible = false;
            }
            else
            {
                dvLeads.Style["display"] = "none";
                dvLeads.Visible = false;
                lblResHead.Visible = true;
                lblResHead.Text = "No Leads found to Download";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rptrDownload_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LeadsDownloadBL objLeadDownload = new LeadsDownloadBL();

        HiddenField lblStateID = (HiddenField)e.Item.FindControl("lblStateID");

        Label lblStateCode = (Label)e.Item.FindControl("lblStateCode");


        DataSet dsLeadsDownload = objLeadDownload.GetAllcotedLeadsDownload(ddlVehicleType.SelectedItem.Value, ddlCenter.SelectedItem.Value, txtStartDate.Text, txtEndDate.Text, lblStateID.Value, Convert.ToInt32(Session[Constants.USER_ID]).ToString());


        //DataSetToExcel.Convert(dsLeadsDownload, Response, ddlVehicleType.SelectedItem.Value + lblStateCode.Text);

        DataSetToExcel.Convert(dsLeadsDownload, Response, "UCE-CarLeads-" + ddlCenter.SelectedItem.Text + "-" + String.Format("{0:yyyy-MM-dd}", System.DateTime.Now.ToString()) + ".xls");



    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LeadsDownloadBL objLeadDownload = new LeadsDownloadBL();
        DataSet dsTotal = new DataSet();
        string strStateID = string.Empty;
        int i = 0;
        for (int index = 0; index < rptrDownload.Items.Count; index++)
        {
            HiddenField lblStateID = (HiddenField)rptrDownload.Items[index].FindControl("lblStateID");

            Label lblStateCode = (Label)rptrDownload.Items[index].FindControl("lblStateCode");

            CheckBox chk = (CheckBox)rptrDownload.Items[index].FindControl("chk");
            Label lblTobeDownload = (Label)rptrDownload.Items[index].FindControl("lblTobeDownload");

            if (chk.Checked == true)
            {
                if (lblTobeDownload.Text != "0")
                {
                    if (i == 0)
                    {
                        strStateID = "'" + lblStateID.Value + "'";
                        i = +1;
                    }
                    else
                    {
                        strStateID = strStateID + ",'" + lblStateID.Value + "'";
                    }
                }
            }
        }
        if (strStateID != "")
        {
            DataSet dsLeadsDownload = objLeadDownload.GetAllcotedLeadsDownload(ddlVehicleType.SelectedItem.Value, ddlCenter.SelectedItem.Value, txtStartDate.Text, txtEndDate.Text, strStateID, Convert.ToInt32(Session[Constants.USER_ID]).ToString());

            if (dsLeadsDownload != null)
            {
                if (dsLeadsDownload.Tables.Count > 0)
                {
                    if (dsLeadsDownload.Tables[0].Rows.Count > 0)
                    {
                        lblLeadCnt.Text = dsLeadsDownload.Tables.Count.ToString();
                        DataView dv = GetTopDataViewRows(dsLeadsDownload.Tables[0].DefaultView, 25);

                        rptrLeads.DataSource = dv.ToTable();
                        rptrLeads.DataBind();

                        lblLeadCnt.Text = dv.ToTable().Rows.Count.ToString();
                        MpeShowLeads.Show();
                    }
                    else
                    {
                        lblErrorExists.Visible = true;
                        lblErrorExists.Text = "No leads are available for view/download";
                        mdepAlertExists.Show();
                    }
                }
                else
                {
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "No leads are available for view/download";
                    mdepAlertExists.Show();
                }
            }
            else
            {
                lblErrorExists.Visible = true;
                lblErrorExists.Text = "No leads are available for view/download";
                mdepAlertExists.Show();
            }
        }
        else
        {
            lblErrorExists.Visible = true;
            lblErrorExists.Text = "No leads are available for view/download";
            mdepAlertExists.Show();
        }
    }

    private DataView GetTopDataViewRows(DataView dv, Int32 n)
    {
        DataTable dt = dv.Table.Clone();

        for (int i = 0; i < n - 1; i++)
        {
            if (i >= dv.Count)
            {
                break;
            }
            dt.ImportRow(dv[i].Row);
        }
        return new DataView(dt, dv.RowFilter, dv.Sort, dv.RowStateFilter);
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        LeadsDownloadBL objLeadDownload = new LeadsDownloadBL();
        DataSet dsTotal = new DataSet();
        string strStateID = string.Empty;


        for (int index = 0; index < rptrDownload.Items.Count; index++)
        {
            HiddenField lblStateID = (HiddenField)rptrDownload.Items[index].FindControl("lblStateID");

            Label lblStateCode = (Label)rptrDownload.Items[index].FindControl("lblStateCode");

            CheckBox chk = (CheckBox)rptrDownload.Items[index].FindControl("chk");

            int i = 0;
            if (chk.Checked == true)
            {
                if (i == 0)
                {
                    strStateID = lblStateID.Value;
                    i = +1;
                }
                else
                {
                    strStateID = strStateID + "," + lblStateID.Value;
                }
            }
        }

        DataSet dsLeadsDownload = objLeadDownload.GetAllcotedLeadsDownload(ddlVehicleType.SelectedItem.Value, ddlCenter.SelectedItem.Value, txtStartDate.Text, txtEndDate.Text, strStateID, Convert.ToInt32(Session[Constants.USER_ID]).ToString());

        if (dsLeadsDownload != null)
        {
            if (dsLeadsDownload.Tables.Count > 0)
            {
                if (dsLeadsDownload.Tables[0].Rows.Count > 0)
                {
                    objLeadDownload.UpdateLeadsAllcotedLeadsStatus(ddlVehicleType.SelectedItem.Value, ddlCenter.SelectedItem.Value, txtStartDate.Text, txtEndDate.Text, strStateID, Convert.ToInt32(Session[Constants.USER_ID]).ToString(), dsLeadsDownload.Tables[0].Rows.Count.ToString());
                    //GetResultsData();
                    //DataSetToExcel.Convert(dsLeadsDownload, "UCE-CarLeads-" + ddlCenter.SelectedItem.Text + "-" + String.Format("{0:yyyy-MM-dd}", System.DateTime.Now.ToString()) + ".xls");
                    MpeShowLeads.Hide();
                    GetResultsData();
                    Session["PageDown"] = "LeadsDownload";
                    Session["LeadsDownDataset"] = dsLeadsDownload;
                    Session["LeadsdownloadName"] = "UCE-CarLeads-" + ddlCenter.SelectedItem.Text + "-" + String.Format("{0:yyyy-MM-dd}", System.DateTime.Now.ToString()) + ".xls";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "javascript:poptasticTest('GetExcelDownload.aspx');", true);
                }
                else
                {
                    GetResultsData();
                    MpeShowLeads.Hide();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "No leads are available for view/download";
                    mdepAlertExists.Show();
                }
            }
            else
            {
                GetResultsData();
                MpeShowLeads.Hide();
                lblErrorExists.Visible = true;
                lblErrorExists.Text = "No leads are available for view/download";
                mdepAlertExists.Show();
            }
        }
        else
        {
            GetResultsData();
            MpeShowLeads.Hide();
            lblErrorExists.Visible = true;
            lblErrorExists.Text = "No leads are available for view/download";
            mdepAlertExists.Show();
        }

    }
    protected void AllDownloaded_Click(object sender, EventArgs e)
    {

        LeadsDownloadBL objLeadDownload = new LeadsDownloadBL();
        DataSet dsTotal = new DataSet();
        string strStateID = string.Empty;

        int i = 0;

        for (int index = 0; index < rptrDownload.Items.Count; index++)
        {
            HiddenField lblStateID = (HiddenField)rptrDownload.Items[index].FindControl("lblStateID");

            Label lblStateCode = (Label)rptrDownload.Items[index].FindControl("lblStateCode");

            CheckBox chk = (CheckBox)rptrDownload.Items[index].FindControl("chk");

            if (i == 0)
            {
                strStateID = lblStateID.Value;
                i = +1;
            }
            else
            {
                strStateID = strStateID + "," + lblStateID.Value;
            }

        }

        DataSet dsLeadsDownload = objLeadDownload.GetAllcotedLeadsDownload(ddlVehicleType.SelectedItem.Value, ddlCenter.SelectedItem.Value, txtStartDate.Text, txtEndDate.Text, strStateID, Convert.ToInt32(Session[Constants.USER_ID]).ToString());



        if (dsLeadsDownload != null)
        {
            if (dsLeadsDownload.Tables.Count > 0)
            {
                if (dsLeadsDownload.Tables[0].Rows.Count > 0)
                {

                    objLeadDownload.UpdateLeadsAllcotedLeadsStatus(ddlVehicleType.SelectedItem.Value, ddlCenter.SelectedItem.Value, txtStartDate.Text, txtEndDate.Text, strStateID, Convert.ToInt32(Session[Constants.USER_ID]).ToString(), dsLeadsDownload.Tables[0].Rows.Count.ToString());
                    //GetResultsData();
                    //DataSetToExcel.Convert(dsLeadsDownload, "UCE-CarLeads-" + ddlCenter.SelectedItem.Text + "-" + String.Format("{0:yyyy-MM-dd}", System.DateTime.Now.ToString()) + ".xls");
                    GetResultsData();
                    Session["PageDown"] = "LeadsDownload";
                    Session["LeadsDownDataset"] = dsLeadsDownload;
                    Session["LeadsdownloadName"] = "UCE-CarLeads-" + ddlCenter.SelectedItem.Text + "-" + String.Format("{0:yyyy-MM-dd}", System.DateTime.Now.ToString()) + ".xls";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "javascript:poptasticTest('GetExcelDownload.aspx');", true);

                }
                else
                {
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "No leads are available for view/download";
                    mdepAlertExists.Show();
                }
            }
            else
            {
                lblErrorExists.Visible = true;
                lblErrorExists.Text = "No leads are available for view/download";
                mdepAlertExists.Show();
            }
        }
        else
        {
            lblErrorExists.Visible = true;
            lblErrorExists.Text = "No leads are available for view/download";
            mdepAlertExists.Show();
        }

    }
    protected void rptrDownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void rptrLeads_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Label lbllblLeadQcStatus = (Label)e.Item.FindControl("lblLeadQcStatus");

            //if (lbllblLeadQcStatus.Text == "0")
            //{
            //    lbllblLeadQcStatus.Text = "Passed";
            //}


        }
    }
}
