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
using HotLeadBL.Masters;
using HotLeadBL.Leads;

public partial class LeadAssign1 : System.Web.UI.Page
{

    HotLeadsBL objHotLeadBL = new HotLeadsBL();
    public int i = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (!IsPostBack)
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
                        //if (CenterCode.Length > 5)
                        //{
                        //    lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString().Substring(0, 5) + ")";
                        //}
                        //else
                        //{
                        //    lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")";
                        //}
                        lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")-" + UserLogName.ToString();
                    }
                    lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");

                    FillCenters();
                    FillStates();
                    divDetails.Visible = true;

                }
            }
        }

    }

    #region LoadUserRight

    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            HotLeadsBL objHotLeadsBL = new HotLeadsBL();
            DataSet dsDatetime = objHotLeadsBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            objHotLeadsBL.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), dtNow, Convert.ToInt32(Session[Constants.USERLOG_ID]), 2);
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
        }
    }


    private void FillStates()
    {
        DropdownBL objdropdownBL = new DropdownBL();

        DataSet dsDropDown = new DataSet();


        try
        {
            if (Session["DsDropDown"] == null)
            {
                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                Session["DsDropDown"] = dsDropDown;
            }
            else
            {
                dsDropDown = (DataSet)Session["DsDropDown"];
            }

            grdAssign.DataSource = dsDropDown.Tables[1];
            grdAssign.DataBind();

        }
        catch (Exception ex)
        {
        }
    }

    private void LoadVehicletype()
    {
        try
        {
            VehicleTypeBL objVehicleTypeBL = new VehicleTypeBL();

            DataSet dsVehicleTypes = new DataSet();

            if (Session["VehicleType"] == null)
            {
                dsVehicleTypes = objVehicleTypeBL.GetVehicleType();
                Session["VehicleType"] = dsVehicleTypes;
            }
            else
            {
                dsVehicleTypes = (DataSet)Session["VehicleType"];
            }
            ddlVehicleType1.DataValueField = "VehicleTypeID";
            ddlVehicleType1.DataTextField = "VehicleType";
            ddlVehicleType1.DataSource = dsVehicleTypes.Tables[0];
            ddlVehicleType1.DataBind();


        }
        catch (Exception ex)
        {

        }
    }
    #endregion LoadUserRight
    private void LoadUserRights()
    {
        DataSet dsSession = new DataSet();
        dsSession = objHotLeadBL.GetUserSession((Session[Constants.USER_ID].ToString()));

        if (dsSession.Tables[0].Rows[0]["SessionID"].ToString() != HttpContext.Current.Session.SessionID.ToString())
        {
            // objUserlog.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), System.DateTime.Now, Convert.ToInt32(Session[Constants.USERLOG_ID]), 8);

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

    private void FillCenters()
    {
        try
        {
            CenterBL objCenterBL = new CenterBL();
            DataSet dsVehicleTypes = new DataSet();

            if (Cache["Centers"] == null)
            {
                dsVehicleTypes = objCenterBL.GetCenters();
                Cache["Centers"] = dsVehicleTypes;
            }
            else
            {
                dsVehicleTypes = (DataSet)Cache["Centers"];
            }

            ddlCenter1.DataValueField = "AgentCenterID";
            ddlCenter1.DataTextField = "AgentCenterCode";
            ddlCenter1.DataSource = dsVehicleTypes.Tables[0];
            ddlCenter1.DataBind();


        }
        catch (Exception ex)
        {

        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        StateWiseLeadAllocationBL objAllocation = new StateWiseLeadAllocationBL();

        objAllocation.SetLeadAssignAllocationForCenters(ddlCenter1.SelectedValue.ToString(), hdnCSID1.Value, hdnSelectedStateID.Value, ddlVehicleType1.SelectedValue);

        FillStates();
        i = 0;
    }

    protected void grdAssign_ItemCommand1(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "State")
        {

            HiddenField hdnStateID = (HiddenField)e.Item.FindControl("hdnStateID");
            HiddenField hdnCenterID = (HiddenField)e.Item.FindControl("hdnCenterID");
            LinkButton lblStateCode = (LinkButton)e.Item.FindControl("lblStateCode");
            HiddenField hdnCSID = (HiddenField)e.Item.FindControl("hdnCSID");
            lblSelectedState.Text = lblStateCode.Text;
            lblVehicleType.Text = ddlVehicleType1.SelectedItem.Text;
            ddlCenter1.SelectedIndex = ddlCenter1.Items.IndexOf(ddlCenter1.Items.FindByValue(hdnCenterID.Value));
            hdnSelectedStateID.Value = hdnStateID.Value;
            hdnCSID1.Value = hdnCSID.Value;
            lblAllocatedLocation.Text = ddlCenter1.SelectedItem.Text;
            mpelblUerExist.Show();
        }
    }


    protected void grdAssign_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        StateWiseLeadAllocationBL objLeadsAssign = new StateWiseLeadAllocationBL();
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataSet dsStateAllocation = new DataSet();
                if (i == 0)
                {
                    i = +1;
                    dsStateAllocation = objLeadsAssign.GetStateAllocationForCenters(ddlVehicleType1.SelectedItem.Value);
                    Session["StateAllocation"] = dsStateAllocation;
                }
                else
                {
                    dsStateAllocation = (DataSet)Session["StateAllocation"];
                }
                LinkButton lblStateCode = (LinkButton)e.Item.FindControl("lblStateCode");
                HiddenField hdnCenterID = (HiddenField)e.Item.FindControl("hdnCenterID");
                HiddenField hdnStateID = (HiddenField)e.Item.FindControl("hdnStateID");
                HiddenField hdnCSID = (HiddenField)e.Item.FindControl("hdnCSID");
                Label lblCenterName = (Label)e.Item.FindControl("lblCenterName");
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                dv = dsStateAllocation.Tables[0].DefaultView;
                dv.RowFilter = "StateID=" + hdnStateID.Value + "";

                dt = dv.ToTable();
                if (dt.Rows.Count > 0)
                {
                    lblCenterName.Text = "-" + dt.Rows[0]["AgentCenterCode"].ToString();
                    hdnCenterID.Value = dt.Rows[0]["CenterID"].ToString();
                    hdnCSID.Value = dt.Rows[0]["CSID"].ToString();
                }

            }

        }
        catch (Exception ex)
        {

        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        //i = 0;
        Session["Sellecte"] = ddlVehicleType1.SelectedItem.Value;
        divDetails.Visible = true;
        FillStates();
    }
    protected void lbtnQcShow_Click(object sender, EventArgs e)
    {

        QCParameterBL objQCParameterBL = new QCParameterBL();
        DataSet ds = objQCParameterBL.GetQCParmeter("1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtNpaRangeFrom.Text = ds.Tables[0].Rows[0]["NPARangeFrom"].ToString();
            NPARangeTo.Text = ds.Tables[0].Rows[0]["NPARangeTo"].ToString();
            NXXRangeFrom.Text = ds.Tables[0].Rows[0]["NXXRangeFrom"].ToString();
            NXXRangeTo.Text = ds.Tables[0].Rows[0]["NXXRangeTo"].ToString();
            OtherNPA.Text = ds.Tables[0].Rows[0]["OtherNPA"].ToString();
            OtherNXX.Text = ds.Tables[0].Rows[0]["OtherNXX"].ToString();
            NPA_NXX_combos.Text = ds.Tables[0].Rows[0]["NPA_NXX_combos"].ToString();
            Last_four_digits.Text = ds.Tables[0].Rows[0]["Last_four_digits"].ToString();
            PRICE_Below.Text = ds.Tables[0].Rows[0]["PRICE_Below"].ToString();
            PRICE_Above.Text = ds.Tables[0].Rows[0]["PRICE_Above"].ToString();
            ModelPriorTo.Text = ds.Tables[0].Rows[0]["ModelPriorTo"].ToString();
            ModelTo.Text = ds.Tables[0].Rows[0]["ModelTo"].ToString();
            MileageGreaterthan.Text = ds.Tables[0].Rows[0]["MileageGreaterthan"].ToString();
            MileageLessThan.Text = ds.Tables[0].Rows[0]["MileageLessThan"].ToString();
            LeadDatePriorTo.Text = ds.Tables[0].Rows[0]["LeadDatePriorTo"].ToString();
            txtFuture_date.Text = ds.Tables[0].Rows[0]["Future_date"].ToString();
        }
        MpeQcPopUp.Show();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        QCParameterBL objQCParameterBL = new QCParameterBL();

        objQCParameterBL.SaveQcParameters("1", txtNpaRangeFrom.Text, NPARangeTo.Text,
        NXXRangeFrom.Text,
        NXXRangeTo.Text,
        OtherNPA.Text,
        OtherNXX.Text,
        NPA_NXX_combos.Text,
        Last_four_digits.Text,
        PRICE_Below.Text,
        PRICE_Above.Text,
        ModelPriorTo.Text,
        ModelTo.Text,
        MileageGreaterthan.Text,
        MileageLessThan.Text,
        LeadDatePriorTo.Text,
        txtFuture_date.Text);

        lblErrUpdated.Text = "Qc Parameters Updated Successfully";
        lblErrUpdated.Visible = true;
        mpealteruserUpdated.Show();

        MpeQcPopUp.Hide();


    }
    protected void btnCANCEL_Click(object sender, EventArgs e)
    {
        MpeQcPopUp.Hide();
    }
}
