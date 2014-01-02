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


public partial class StatewiseLeads : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserregInfo = new UserRegistrationInfo();
    HotLeadsBL objHotLeadBL = new HotLeadsBL();
    int l = 0;

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

                    AllGroups();
                    GetLeadsCentersList();

                }
            }
        }
    }

    private void AllGroups()
    {

        try
        {
            DataSet dsGroups = objHotLeadBL.GetAllProducts();
            ddlgroups.Items.Clear();
            for (int i = 0; i < dsGroups.Tables[0].Rows.Count; i++)
            {
                if (dsGroups.Tables[0].Rows[i]["Vehicletypeid"].ToString() != "0")
                {
                    ListItem list = new ListItem();
                    list.Text = dsGroups.Tables[0].Rows[i]["vehicletypename"].ToString();
                    list.Value = dsGroups.Tables[0].Rows[i]["Vehicletypeid"].ToString();
                    ddlgroups.Items.Add(list);
                }
            }
            //ddlcenters.Items.Insert(0, new ListItem("All", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetLeadsCentersList()
    {

        DataSet GetLeadscenterList = new DataSet();
        GetLeadscenterList = objHotLeadBL.GetLocationByBrand(Convert.ToInt32(ddlgroups.SelectedValue));
        Session["Employees"] = GetLeadscenterList;
        Rpt_Locatons.DataSource = GetLeadscenterList.Tables[0];
        Rpt_Locatons.DataBind();
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
    protected void Rpt_Locatons_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                HiddenField lblLocationId = (HiddenField)e.Item.FindControl("lblLocationId");
                string locationId = lblLocationId.Value;
                Label lblLocationName = (Label)e.Item.FindControl("lbllocation");
                lblLocationName.Text = lblLocationName.Text;
                string LocName = lblLocationName.Text;
                Session["LcName"] = LocName.ToString();
                Session["LocatioId"] = locationId.ToString();
                DataSet DSSateWiseLoc = new DataSet();
                DSSateWiseLoc = objHotLeadBL.StatewiseLeads(Convert.ToInt32(locationId));
                var repeater2 = (Repeater)e.Item.FindControl("Rpt_LeadsCenters");
                l = 0;
                repeater2.DataSource = DSSateWiseLoc;
                repeater2.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;



        }
    }
    protected void Rpt_LeadsCenters_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string LocId = Session["LocatioId"].ToString();

                Label lblzoneNames = (Label)e.Item.FindControl("lblZoneName");
                HiddenField lblzoneId = (HiddenField)e.Item.FindControl("lblzoneId");
                Label lblstates = (Label)e.Item.FindControl("lblstates");
                Label lblcount = (Label)e.Item.FindControl("lblcount");
                Label lblweekavgleads = (Label)e.Item.FindControl("lblweekavgleads");

                string ZoneId = lblzoneId.Value;
                DataSet dsstates = new DataSet();
                dsstates = objHotLeadBL.StatesListBasedonZone(Convert.ToInt32(ZoneId), Convert.ToInt32(LocId));
                string StatesList = ""; int j = 0; int Avg = 1000;
                for (int i = 0; i < dsstates.Tables[0].Rows.Count; i++)
                {
                    StatesList += dsstates.Tables[0].Rows[i]["StateCode"].ToString() + ",";
                    j = j + 1;
                    l = l + 1;
                }

                if (StatesList.EndsWith(","))
                    StatesList = StatesList.Remove(StatesList.Length - 1, 1);

                lblstates.Text = StatesList.ToString();
                lblcount.Text = j.ToString();
                lblweekavgleads.Text = (j * Avg).ToString();

                Session["l"] = l.ToString();

            }

        }
        catch (Exception ex)
        {
            throw ex;


        }
        try
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblTotalCount = (Label)e.Item.FindControl("lblcount");
                Label LabelTotalleads = (Label)e.Item.FindControl("LabelTotalleads");

                int val = Convert.ToInt32(Session["l"].ToString());
                lblTotalCount.Text = Session["l"].ToString();
                LabelTotalleads.Text = (val * 1000).ToString();

            }
        }
        catch { }
    }

    protected void ddlgroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetLeadsCentersList();
    }
}