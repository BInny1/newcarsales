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


public partial class SuperadminRights : System.Web.UI.Page
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
                        GetAllLocations();
                        if (CenterCode == "INDG")
                            ddlcenters.SelectedIndex = 0;
                        else if (CenterCode == "INBH")
                            ddlcenters.SelectedIndex = 1;
                        else if (CenterCode == "USMP")
                            ddlcenters.SelectedIndex = 2;
                        else if (CenterCode == "USWB")
                            ddlcenters.SelectedIndex = 3;
                        GetLeadsSattus();
                    }

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
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        LinkButton lblEmpName = (LinkButton)e.Row.FindControl("lblEmpName");
        //        LinkButton lblRole = (LinkButton)e.Row.FindControl("lblRole");
        //        LinkButton QCProcess = (LinkButton)e.Row.FindControl("lblQcProcess");
        //        LinkButton lblPaymentProcess = (LinkButton)e.Row.FindControl("lblPaymentProcess");
        //        LinkButton lblProcessAdmin = (LinkButton)e.Row.FindControl("lblProcessAdmin");
        //        DataSet dsTasks3 = (DataSet)Session["ProcessDataset"];
        //        lblEmpName.Text = dsTasks3.Tables[0].Rows[e.Row.RowIndex]["FirstName"].ToString() + " " + dsTasks3.Tables[0].Rows[e.Row.RowIndex]["lastname"].ToString();
        //        lblRole.Text = dsTasks3.Tables[0].Rows[e.Row.RowIndex]["RoleName"].ToString();
        //        if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["QC"].ToString() != "")
        //        {
        //            QCProcess.Text = "Y";
        //            QCProcess.ForeColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            QCProcess.Text = "";
        //        }
        //        if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["Payment"].ToString() != "")
        //        {
        //            lblPaymentProcess.Text = "Y";
        //            lblPaymentProcess.ForeColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            lblPaymentProcess.Text = "";
        //        }
        //        if (dsTasks3.Tables[0].Rows[e.Row.RowIndex]["ProcessAdmin"].ToString() != "")
        //        {
        //            lblProcessAdmin.Text = "Y";
        //            lblProcessAdmin.ForeColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            lblProcessAdmin.Text = "";
        //        }
        //    }
        //}
        //catch { }
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dsTasks4 = (DataSet)Session["ProcessDataset"];
                Label lblQCCount = (Label)e.Row.FindControl("lblProcessAdmin");
                Label lbladmin = (Label)e.Row.FindControl("lbladmin");

                int CounQCVal = 0;
                for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
                {

                    if (dsTasks4.Tables[0].Rows[i][30].ToString() == "Y")
                    {
                        CounQCVal = CounQCVal + 1;
                    }



                }


                lbladmin.Text = CounQCVal.ToString();

            }
        }
        catch { }
    }

    protected void ddlcenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetLeadsSattus();


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
                    LinkButton lblSalesEmpid = row.Cells[0].FindControl("lblSalesEmpid") as LinkButton;
                    DropDownList lblSalesRoleId = row.Cells[0].FindControl("ddlsalesroles") as DropDownList;
                    string roleid = lblSalesRoleId.Text;
                    if (roleid != "0")
                    {
                        DataSet InsertEmployee = objHotLeadBL.InsertProcessRights(lblSalesEmpid.Text, Convert.ToInt32(lblSalesRoleId.Text),
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
        GetLeadsSattus();
    }
    protected void GridQcProcessStatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Empdeta")
            {

                chkleadsadmin.Items[0].Selected = false;
                string EmpIdva = e.CommandArgument.ToString();

                Session["EMpid"] = EmpIdva.ToString();
                string EMpids = Session[Constants.USER_ID].ToString();
                if (EMpids != EmpIdva.ToString())
                {
                    MpUpdaterights.Show();
                    DataSet GetUserDefaultRight = new DataSet();
                    GetUserDefaultRight = objHotLeadBL.AllEMployeeUserRights(EmpIdva.ToString());
                    int count = GetUserDefaultRight.Tables[0].Rows.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (GetUserDefaultRight.Tables[0].Rows[i]["Active"].ToString() == "1")
                        {
                            string Modulename = GetUserDefaultRight.Tables[0].Rows[i]["SubModuleName"].ToString();

                            if (Modulename == "SuperAdmin")
                                chkleadsadmin.Items[0].Selected = true;

                        }
                    }
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('No possibility for updating own rights');", true);
                }
            }
        }
        catch { }
    }
    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {


        bool Superadmin = false;
        string EMPID = "";

        if (chkleadsadmin.Items[0].Selected == true) Superadmin = true; else Superadmin = false;

        EMPID = Session["EMpid"].ToString();
        string usertypid = "", LogPerson = "";
        try
        {
            usertypid = Session[Constants.USER_TYPE_ID].ToString();
        }
        catch { usertypid = "1"; }
        try
        {
            LogPerson = Session[Constants.USER_ID].ToString();
        }
        catch { }
        DataSet UserEmploRights = objHotLeadBL.UpdateSupadmRightsSales(EMPID, Superadmin, usertypid, LogPerson);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('User Rights are updated successfully.');", true);
        GetLeadsSattus();
        MpUpdaterights.Hide();

        chkleadsadmin.Items[0].Selected = false;

    }
    public void btndelete_Click(object sender, EventArgs e)
    {

        //Deactivating Empid from carsales.
        string EMpid = Session["EMpid"].ToString();
        DataSet dsSalesUpdateList = objHotLeadBL.DeleteEmployee(EMpid);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('" + EMpid + " has been deleted succesfully.');", true);
        MpUpdaterights.Hide();
        GetLeadsSattus();
    }


}