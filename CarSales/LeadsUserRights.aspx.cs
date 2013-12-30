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
            //  ddlcenters.Items.Insert(0, new ListItem("All", "0"));

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
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        LinkButton lblLeadsUpload = (LinkButton)e.Row.FindControl("lblLeadsUpload");
        //        LinkButton LeadsAdmin = (LinkButton)e.Row.FindControl("LeadsAdmin");
        //        DataSet dsTasks3 = (DataSet)Session["LeadsuserRights"];
        //        if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["Leads"].ToString() == "14")
        //        {
        //            lblLeadsUpload.Text = "Y";
        //        }
        //        else
        //        {
        //            lblLeadsUpload.Text = "";
        //        }
        //        if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["LeadsAdmin"].ToString() == "18")
        //        {
        //            LeadsAdmin.Text = "Y";
        //        }
        //        else
        //        {
        //            LeadsAdmin.Text = "";
        //        }
        //    }

        //}
        //catch { }
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalCount = (Label)e.Row.FindControl("lblleadscoun");
                Label lblleadsAdmincoun = (Label)e.Row.FindControl("lblleadsAdmincoun");
                DataSet dsTasks4 = (DataSet)Session["LeadsuserRights"];
                int CounlreadsVal = 0, CounldminVal = 0;
                for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
                {
                    if (dsTasks4.Tables[0].Rows[i][2].ToString() == "Y")
                    {
                        CounlreadsVal = CounlreadsVal + 1;
                    }
                    if (dsTasks4.Tables[0].Rows[i][3].ToString() == "Y")
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
    public void lnlupdatelist_Click(object sender, EventArgs e)
    {

        String empid = ""; String empid1 = "";
        //Deactivate Emploees from HR 
        DataSet DeactivEMp = objHotLeadBL.CheckDeactEmployees();
        int DeacEmpcoun = DeactivEMp.Tables[0].Rows.Count;
        if (DeacEmpcoun >= 1)
        {

            for (int i = 0; i < DeactivEMp.Tables[0].Rows.Count; i++)
            {
                empid = DeactivEMp.Tables[0].Rows[0]["EMpid"].ToString() + ",";
            }
            if (empid.EndsWith(","))
                empid = empid.Remove(empid.Length - 1, 1);

            //Updating List
            bool Updatelist = objHotLeadBL.UpdateDeactEmployees();



        }
        //If Reactive Employees

        DataSet ReactiveEmp = objHotLeadBL.ReactiveEmp();
        int Reacount = ReactiveEmp.Tables[0].Rows.Count;
        if (Reacount >= 1)
        {

            for (int i = 0; i < ReactiveEmp.Tables[0].Rows.Count; i++)
            {
                empid1 = ReactiveEmp.Tables[0].Rows[0]["Empid"].ToString() + ",";
            }
            if (empid1.EndsWith(","))
                empid1 = empid1.Remove(empid1.Length - 1, 1);

            //Updating Reactive List
            bool Updatelist = objHotLeadBL.UpdateReactiveEmp();


        }
        if (empid.Length > 1 && empid1.Length > 1)
        {
            string text = "" + empid + "  deactivate and  \\n " + empid1 + "  activated from HR System.so changing status in carsales";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('" + text + "');", true);
        }
        else if (empid.Length > 1 && empid1.Length < 1)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('" + empid + "  deactivate from HR System.so changing status in carsales');", true);
        }
        else if (empid.Length < 1 && empid1.Length > 1)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('" + empid1 + "  activated from HR System.so changing status in carsales');", true);
        }

        //if all records are complted to add

        DataSet dsSalesUpdateList = objHotLeadBL.SalesUsersUpdateList(Convert.ToInt32(ddlcenters.SelectedValue));
        int EMpcoun = dsSalesUpdateList.Tables[0].Rows.Count;
        if (EMpcoun > 1)
        {
            MpUserUpdatelist.Show();
            GridUserUpdateList.DataSource = dsSalesUpdateList.Tables[0];
            GridUserUpdateList.DataBind();
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('No More New Employees from HR System.');", true);
        }

    }
    public void btnUpda_Click(object sender, EventArgs e)
    {
        int chkcount = 0; string Empis = ""; string EmpisUpdates = ""; int k = 0, l = 0;
        foreach (GridViewRow row in GridUserUpdateList.Rows)
        {
            CheckBox chk = row.Cells[0].FindControl("chk_Check") as CheckBox;
            if (chk.Checked == true)
            {
                chkcount = chkcount + 1;
            }
        }
        if (chkcount >= 1)
        {
            foreach (GridViewRow row in GridUserUpdateList.Rows)
            {
                CheckBox chk = row.Cells[0].FindControl("chk_Check") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    Label lblSalesEmpid = row.Cells[0].FindControl("lblSalesEmpid") as Label;
                    DropDownList lblSalesRoleId = row.Cells[0].FindControl("ddlsalesroles") as DropDownList;
                    string roleid = lblSalesRoleId.Text;
                    if (roleid != "0")
                    {
                        DataSet InsertEmployee = objHotLeadBL.LeadsEmployeeandRights(lblSalesEmpid.Text, Convert.ToInt32(lblSalesRoleId.Text),
                            Convert.ToInt32(ddlcenters.SelectedValue), Session[Constants.USER_NAME].ToString());
                        EmpisUpdates = lblSalesEmpid.Text + ",";
                        k = k + 1;
                    }
                    else
                    {
                        Empis = lblSalesEmpid.Text + ",";
                        l = l + 1;

                    }

                }
            }
            try
            {
                if (Empis.EndsWith(","))
                    Empis = Empis.Remove(Empis.Length - 1, 1);

                if (EmpisUpdates.EndsWith(","))
                    EmpisUpdates = EmpisUpdates.Remove(EmpisUpdates.Length - 1, 1);

            }
            catch { }

            if (k != 0 && l != 0)
            {
                string Text = "Selected  " + Empis + "  added successfully and  \\n " + EmpisUpdates + " not added select roles and update. ";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('" + Text + "');", true);

            }
            else if (k != 0 && l == 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Selected employee(s)  added successfully.');", true);
                MpUserUpdatelist.Hide();
            }
            else if (k == 0 && l != 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('please select role of the employee and update.');", true);
                MpUserUpdatelist.Show();
            }
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Please select employees and update.');", true);
            MpUserUpdatelist.Show();
        }
        GetLeadsUserRights(Convert.ToInt32(ddlcenters.SelectedValue));
    }
    protected void GridDefaultUserRights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            MpUpdaterights.Show();
            if (e.CommandName == "Empdeta")
            {
                Ckleads.Items[0].Selected = false; chkleadsadmin.Items[0].Selected = false;
                string EmpIdva = e.CommandArgument.ToString();

                Session["EMpid"] = EmpIdva.ToString();
                DataSet GetUserDefaultRight = new DataSet();
                GetUserDefaultRight = objHotLeadBL.AllEMployeeUserRights(EmpIdva.ToString());
                int count = GetUserDefaultRight.Tables[0].Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (GetUserDefaultRight.Tables[0].Rows[i]["Active"].ToString() == "1")
                    {
                        string Modulename = GetUserDefaultRight.Tables[0].Rows[i]["SubModuleName"].ToString();

                        if (Modulename == "LeadsUpload")
                            Ckleads.Items[0].Selected = true;

                        if (Modulename == "LeadsAdmin")
                            chkleadsadmin.Items[0].Selected = true;

                    }
                }
            }
        }
        catch { }
    }

    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {

        bool LeadsUpload = false, LeadsAdmin = false;
        string EMPID = "";

        if (Ckleads.Items[0].Selected == true)
        {
            LeadsUpload = true;
        }
        else
        {
            LeadsUpload = false;
        }


        if (chkleadsadmin.Items[0].Selected == true) LeadsAdmin = true; else LeadsAdmin = false;


        EMPID = Session["EMpid"].ToString();

        string usertypid = "";
            try{
                usertypid= Session[Constants.USER_TYPE_ID].ToString();
            }
            catch { usertypid = "1"; }
        DataSet UserEmpRights = objHotLeadBL.EditHistoryforadmin(EMPID, LeadsUpload, LeadsAdmin, usertypid);
        DataSet UserEmploRights = objHotLeadBL.UpdateLeadsRightsSales(EMPID, LeadsUpload, LeadsAdmin);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('User Rights are updated successfully.');", true);
        GetLeadsUserRights(Convert.ToInt32(ddlcenters.SelectedValue));
        MpUpdaterights.Hide();
        Ckleads.Items[0].Selected = false;
        chkleadsadmin.Items[0].Selected = false;

    }
}
