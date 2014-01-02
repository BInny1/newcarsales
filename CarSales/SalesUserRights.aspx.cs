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
using System.Drawing;


public partial class SalesUserRights : System.Web.UI.Page
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
                        GetUserDefaultRights();
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
            //ddlcenters.Items.Insert(0, new ListItem("All", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetUserDefaultRights()
    {

        GridDefaultUserRights.DataSource = null;
        GridDefaultUserRights.DataBind();

        string CenterValue = ddlcenters.SelectedValue;
        DataSet GetAllEmployees = new DataSet();
        GetAllEmployees = objHotLeadBL.PerocessRightsStatus(Convert.ToInt32(CenterValue.ToString()));
        Session["Employees"] = GetAllEmployees;
        GridDefaultUserRights.DataSource = GetAllEmployees.Tables[0];
        GridDefaultUserRights.DataBind();
     
    }


    protected void GridDefaultUserRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //try
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataSet dsTasks3 = (DataSet)Session["Employees"];
        //        LinkButton lblRole = (LinkButton)e.Row.FindControl("lblRoleNamre");
        //        LinkButton Empid = (LinkButton)e.Row.FindControl("lblEmpId");
        //        string EmpIdva = Empid.Text;
        //        LinkButton LblFirstName = (LinkButton)e.Row.FindControl("LblFirstName");
        //        LinkButton lblVehType = (LinkButton)e.Row.FindControl("lblVehType");
        //        lblVehType.Text = "Default";



        //        try
        //        {
        //            DataSet GetUserDefaultRight = new DataSet();
        //            string Paystats = ddlcenters.SelectedValue;
        //            GetUserDefaultRight = objHotLeadBL.AllEMployeeUserRights(EmpIdva.ToString());

        //            for (int i = 0; i <= 27; i++)
        //            {
        //                LinkButton LeadsUploadXX = (LinkButton)e.Row.FindControl("LeadsUploadXX");
        //                LinkButton TransferinXX = (LinkButton)e.Row.FindControl("TransferinXX");
        //                LinkButton AbondonedXX = (LinkButton)e.Row.FindControl("AbondonedXX");
        //                LinkButton FreePackageXX = (LinkButton)e.Row.FindControl("FreePackageXX");

        //                LinkButton IntroMailXX = (LinkButton)e.Row.FindControl("IntroMailXX");
        //                LinkButton NewEntryXX = (LinkButton)e.Row.FindControl("NewEntryXX");
        //                LinkButton lblTransferOutXX = (LinkButton)e.Row.FindControl("lblTransferOutXX");
        //                LinkButton TickerXX = (LinkButton)e.Row.FindControl("TickerXX");

        //                LinkButton SelfXX = (LinkButton)e.Row.FindControl("SelfXX");
        //                LinkButton CenterXX = (LinkButton)e.Row.FindControl("Center");

        //                LinkButton LeadsAdminXX = (LinkButton)e.Row.FindControl("LeadsAdminXX");

        //                if (GetUserDefaultRight.Tables[0].Rows[i]["active"].ToString() == "1")
        //                {

        //                    string Modulename = GetUserDefaultRight.Tables[0].Rows[i]["SubModuleName"].ToString();
        //                    Modulename = Modulename + "XX";
        //                    LinkButton lbl;

        //                    lbl = (LinkButton)e.Row.FindControl(Modulename);
        //                    try
        //                    {
        //                        lbl.Text = "Y";
        //                        lbl.ForeColor = System.Drawing.Color.Red;
        //                        lbl.Style["Font-Weight"] = "bold";
        //                    }
        //                    catch { }

        //                }

        //            }
        //        }
        //        catch { }

        //    }
        //}
        //catch { }

        try
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblTotalCount = (Label)e.Row.FindControl("lblTotalCount");
                    DataSet dsTasks4 = (DataSet)Session["Employees"];

                    int UpLoCount = 0, TrInCount = 0, AbondCount = 0, FreePaCopun = 0,
                       IntCount = 0, NewwentCoun = 0, traoucoun = 0, TickeCount = 0,
                       selfCount = 0, CentersCount = 0, AdminCount = 0;

                    Label lblupload = (Label)e.Row.FindControl("lblupload");
                    Label lbltransfin = (Label)e.Row.FindControl("lbltransfin");
                    Label lblabond = (Label)e.Row.FindControl("lblabond");
                    Label lblfreepack = (Label)e.Row.FindControl("lblfreepack");

                    Label lblintm = (Label)e.Row.FindControl("lblintm");
                    Label lblneent = (Label)e.Row.FindControl("lblneent");
                    Label lbltrnout = (Label)e.Row.FindControl("lbltrnout");
                    Label lblticker = (Label)e.Row.FindControl("lblticker");

                    Label lblselfs = (Label)e.Row.FindControl("lblselfs");
                    Label lblcentrs = (Label)e.Row.FindControl("lblcentrs");

                    Label lblladminsd = (Label)e.Row.FindControl("lblladminsd");

                    for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
                    {
                        if (dsTasks4.Tables[0].Rows[i][2].ToString() == "Y")
                        {
                            UpLoCount = UpLoCount + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][9].ToString() == "Y")
                        {
                            TrInCount = TrInCount + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][4].ToString() == "Y")
                        {
                            AbondCount = AbondCount + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][5].ToString() == "Y")
                        {
                            FreePaCopun = FreePaCopun + 1;
                        }


                        if (dsTasks4.Tables[0].Rows[i][7].ToString() == "Y")
                        {
                            IntCount = IntCount + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][8].ToString() == "Y")
                        {
                            NewwentCoun = NewwentCoun + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][29].ToString() == "Y")
                        {
                            traoucoun = traoucoun + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][6].ToString() == "Y")
                        {
                            TickeCount = TickeCount + 1;
                        }



                        if (dsTasks4.Tables[0].Rows[i][28].ToString() == "Y")
                        {
                            selfCount = selfCount + 1;
                        }
                        if (dsTasks4.Tables[0].Rows[i][27].ToString() == "Y")
                        {
                            CentersCount = CentersCount + 1;
                        }


                        if (dsTasks4.Tables[0].Rows[i][20].ToString() == "Y")
                        {
                            AdminCount = AdminCount + 1;
                        }



                    }



                    //Assign Countds
                    lblupload.Text = UpLoCount.ToString();
                    lbltransfin.Text = TrInCount.ToString();
                    lblabond.Text = AbondCount.ToString();
                    lblfreepack.Text = FreePaCopun.ToString();

                    lblintm.Text = IntCount.ToString();
                    lblneent.Text = NewwentCoun.ToString();
                    lbltrnout.Text = traoucoun.ToString();
                    lblticker.Text = TickeCount.ToString();

                    lblselfs.Text = selfCount.ToString();
                    lblcentrs.Text = CentersCount.ToString();
                    lblladminsd.Text = AdminCount.ToString();
                }
            }
            catch { }
        }


        catch { }
    }

    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        //DataSet UserEmploRights = objHotLeadBL.UpdateUserRights(EMPID,LeadsUpload,LeadsDownLoad ,Abondoned,FreePackage ,Ticker ,IntroMail ,
        //                      NewEntry ,Transferin ,MyReport ,QC ,Payments ,Publish ,MyReport1 ,Leads ,Sales ,Process ,Executive ,LeadsAdmin ,
        //                      SalesAdmin ,ProcessAdmin ,ExecutiveAdmin ,BrandsAdmin ,CentersAdmin ,UsersLog ,EditLog ,Center ,Self );

        bool LeadsUpload = false, LeadsDownLoad = false, Abondoned = false, FreePackage = false, Ticker = false, IntroMail = false,
                            NewEntry = false, Transferin = false, TransferOut = false, QC = false, Payments = false, Publish = false, MyReport1 = false,
                            Leads = false, Sales = false, Process = false, Executive = false, LeadsAdmin = false,
                            SalesAdmin = false, ProcessAdmin = false, ExecutiveAdmin = false, BrandsAdmin = false,
                            CentersAdmin = false, UsersLog = false, EditLog = false, Center = false, Self = false;
        string EMPID = "";

        if (Ckleads.Items[0].Selected == true)
        {
            LeadsUpload = true; LeadsDownLoad = true;
        }
        else
        {
            LeadsUpload = false; LeadsDownLoad = false;
        }

        if (Ckleads.Items[1].Selected == true) Transferin = true; else Transferin = false;
        if (Ckleads.Items[2].Selected == true) Abondoned = true; else Abondoned = false;
        if (Ckleads.Items[3].Selected == true) FreePackage = true; else FreePackage = false;


        if (chksales.Items[0].Selected == true) IntroMail = true; else IntroMail = false;
        if (chksales.Items[1].Selected == true) NewEntry = true; else NewEntry = false;
        if (chksales.Items[2].Selected == true) TransferOut = true; else TransferOut = false;
        if (chksales.Items[3].Selected == true) Ticker = true; else Ticker = false;


        if (ChkReports.Items[0].Selected == true) Self = true; else Self = false;
        if (ChkReports.Items[1].Selected == true) Center = true; else Center = false;

        if (chksaleadmin.Items[0].Selected == true) LeadsAdmin = true; else LeadsAdmin = false;


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
        DataSet UserEmploRights = objHotLeadBL.UpdateUserRightsSales(EMPID, LeadsUpload, LeadsDownLoad, Abondoned, FreePackage, Ticker, IntroMail,
                           NewEntry, Transferin, TransferOut, Center, Self, SalesAdmin, usertypid, LogPerson);

        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('User Rights are updated successfully.');", true);
        GetUserDefaultRights();
        MpVechlAdd.Hide();
      
    }
    protected void ddlcenters_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetUserDefaultRights();


    }
    protected void GridDefaultUserRights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            MpVechlAdd.Show();
            if (e.CommandName == "Empdeta")
            {
                Ckleads.Items[0].Selected = false; Ckleads.Items[1].Selected = false; Ckleads.Items[2].Selected = false; Ckleads.Items[3].Selected = false;
                chksales.Items[0].Selected = false; chksales.Items[1].Selected = false; chksales.Items[2].Selected = false; chksales.Items[3].Selected = false;
                ChkReports.Items[0].Selected = false; ChkReports.Items[1].Selected = false; ChkReports.Items[1].Selected = false;
                chksaleadmin.Items[0].Selected = false;
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
                        {
                            Ckleads.Items[0].Selected = true;

                        }

                        if (Modulename == "Transferin")
                            Ckleads.Items[1].Selected = true;
                        if (Modulename == "Abondoned")
                            Ckleads.Items[2].Selected = true;
                        if (Modulename == "FreePackage")
                            Ckleads.Items[3].Selected = true;

                        if (Modulename == "IntroMail")
                            chksales.Items[0].Selected = true;
                        if (Modulename == "NewEntry")
                            chksales.Items[1].Selected = true;
                        if (Modulename == "TransferOut")
                            chksales.Items[2].Selected = true;
                        if (Modulename == "Ticker")
                            chksales.Items[3].Selected = true;

                        if (Modulename == "Self")
                            ChkReports.Items[0].Selected = true;
                        if (Modulename == "Center")
                            ChkReports.Items[1].Selected = true;

                        if (Modulename == "SalesAdmin")
                            chksaleadmin.Items[0].Selected = true;
                    }
                }




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

    protected void GridDefaultUserRights_RowCreated(object sender, GridViewRowEventArgs e)
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
            HeaderCell.CssClass = "BL BR";

            HeaderCell = new TableCell();
            HeaderCell.Text = "Role";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Vehicle Type(s)";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.CssClass = "BL BR";

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
             bool Updatelist =  objHotLeadBL.UpdateDeactEmployees();
            


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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('"+text+"');", true);

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
    public void GridUserUpdateList_RowDeleting(object sender, EventArgs e)
    {
        int Cols = GridUserUpdateList.Rows.Count;

        GridUserUpdateList.DeleteRow(Cols);
        GridUserUpdateList.DataBind();
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
                        DataSet InsertEmployee = objHotLeadBL.UInsertEmpandRightsss(lblSalesEmpid.Text, Convert.ToInt32(lblSalesRoleId.Text),
                            Convert.ToInt32(ddlcenters.SelectedValue), Session[Constants.USER_NAME].ToString());
                        EmpisUpdates = lblSalesEmpid.Text +",";
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

            if (k!=0 && l!=0)
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
        GetUserDefaultRights();
    }
  
    public void OnConfirm(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {

            //Deactivating Empid from carsales.
            string EMpid = Session["EMpid"].ToString();
            DataSet dsSalesUpdateList = objHotLeadBL.DeleteEmployee(EMpid);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('" + EMpid + " has been deleted succesfully.');", true);
            MpVechlAdd.Hide();
            GetUserDefaultRights();
        }
        else
        {
          
        }
    }
    
  
}
