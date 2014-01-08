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
using HotLeadBL.Masters;
using System.Collections.Generic;
using HotLeadBL.HotLeadsTran;
using System.Net.Mail;
using System.Text.RegularExpressions;
using HotLeadBL.Leads;
using System.Data.Common;


public partial class LeADSuPs : System.Web.UI.Page
{
    public GeneralFunc GenFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserregInfo = new UserRegistrationInfo();
    HotLeadsBL objHotLeadBL = new HotLeadsBL();
    int Count = 0;
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
                        lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");

                        Session["SortDirec"] = null;



                    }

                }
            }
        }
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    private void LoadUserRights()
    {
        DataSet dsSession = new DataSet();
        dsSession = objHotLeadBL.GetUserSession((Session[Constants.USER_ID].ToString()));

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LeadsBL ObjLeads = new LeadsBL();
        DataSet dsLeads = new DataSet();

        dsLeads = ObjLeads.LeadsCheckBTN();
        Session["LeadBTNs"] = dsLeads;

        string FILENAME = string.Empty;
        string OpenPath = string.Empty;
        string SaveLoc = string.Empty;
        string FileExt = string.Empty;
        string hp = string.Empty;
        string sLoc = string.Empty;

        ArrayList RowNo = new ArrayList();
        ArrayList ColNo = new ArrayList();

        ArrayList SArray = new ArrayList();

        FilesBL objFilesBL = new FilesBL();

        IDataReader IdataReader = null;


        if (Page.IsValid)
        {
            try
            {
                FileExt = System.IO.Path.GetExtension(fuAttachments.PostedFile.FileName);
                //Get The Ext of File 
                //FileName = Server.MapPath(".") + fuAttachments.PostedFile.FileName;

                if (FileExt != ".xls")
                {
                    if (FileExt != ".xlsx")
                    {
                        lblErrorMsg.Text = "You have Selected a Wrong File.Kindly Select Excel File";
                        //grdErrors.DataSource = null;
                        //grdErrors.DataBind();

                        return;
                    }
                }
                if (fuAttachments.HasFile)
                {
                    OpenPath = fuAttachments.PostedFile.FileName;

                    FILENAME = OpenPath;
                    if (FILENAME.Contains("\\"))
                    {
                        string[] strFile = FILENAME.Split('\\');
                        int max = strFile.Length - 1;
                        FILENAME = strFile[max].ToString();
                    }

                    ViewState["FileName"] = FILENAME;


                    SaveLoc = Server.MapPath("LeadsUpload\\");

                    if (System.IO.Directory.Exists(SaveLoc) == false)
                    {
                        // Try to create the directory. 
                        System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(SaveLoc);

                    }
                    SaveLoc = Server.MapPath("LeadsUpload\\" + FILENAME);

                    fuAttachments.PostedFile.SaveAs(SaveLoc);

                    Session["SaveLocation"] = SaveLoc;

                    Session["FileName"] = FILENAME;

                    IdataReader = objFilesBL.Get_FileByFileName(FILENAME);

                    while (IdataReader.Read())
                    {
                        lblErrorMsg.Text = "Leads File Already Exists. Please Upload a new file";

                        btnUpload.Text = "Upload";

                        return;
                    }

                    ReadExcelData(SaveLoc);



                }
                else
                {
                    btnSubmit.Text = "Process";
                    btnSubmit.Enabled = true;
                    btnUpload.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
                //bool rethrow = ExceptionPolicy.HandleException(ex, ConstantClass.StrCRMUIPolicy);
                //if (rethrow)
                //    throw;
                //Redirecting to error message page
                //Response.Redirect(ConstantClass.StrErrorPageURL);
            }
        }
        divresults.Visible = true;
    }
    private void ReadExcelData(string sFileName)
    {

        ArrayList RowNo = new ArrayList();
        ArrayList ColNo = new ArrayList();

        ArrayList SArray = new ArrayList();

        LeadsBL objLeadsBL = new LeadsBL();

        ExcelReading objExcelData = new ExcelReading();

        DataSet ds = new DataSet();
        DataSet dsStatus = new DataSet();

        DataSet dsSales = new DataSet();
        bool bnew = false;
        try
        {

            lblErrorMsg.Text = "";
            ds = objExcelData.GetLeadsExcelToDataset(sFileName);

            DataSet dsError = new DataSet();

            dsError.Tables.Add();
            dsError.Tables["Table1"].Columns.Add("PhoneNo");
            dsError.Tables["Table1"].Columns.Add("RowNo");
            dsError.Tables["Table1"].Columns.Add("Error");



            if (ds.Tables[0].Columns.Contains("PhoneNo") && ds.Tables[0].Columns.Contains("Price") &&
                ds.Tables[0].Columns.Contains("Header") &&
                ds.Tables[0].Columns.Contains("Description") && (ds.Tables[0].Columns.Contains("URL") || ds.Tables[0].Columns.Contains("City")) &&
                ds.Tables[0].Columns.Contains("State") && ds.Tables[0].Columns.Contains("Lead_Date") &&
                ds.Tables[0].Columns.Contains("Make") &&
                    ds.Tables[0].Columns.Contains("Model") &&
                        ds.Tables[0].Columns.Contains("Email") &&
                            ds.Tables[0].Columns.Contains("Year") &&
                                ds.Tables[0].Columns.Contains("VehicleType"))
            {
                int count = objExcelData.GetExcelDistictBTNCOunt_Sales(sFileName);
                ViewState["Count"] = count.ToString();
                if (ds != null)
                {

                    if (ds.Tables[0].Rows.Count > 8000)
                    {
                        lblErrorMsg.Text = "Upload Only 8000 rows Only!";
                        return;
                    }
                    else if (Convert.ToInt32(txtNoofRecords.Text) != Convert.ToInt32(ds.Tables[0].Rows.Count))
                    {
                        lblErrorMsg.Text = "Records Count Does Not Match!";
                        return;
                    }
                    if (ds.Tables[0].Rows.Count == count)
                    {

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            //return;
                            //RowNo.Add(i);

                            if (ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim() == ""
                             || ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim().Length != 10
                             || !GeneralFunc.IsNumeric(ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim()))
                            {
                                dsError.Tables["Table1"].Rows.Add();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid phone number in the excel sheet";


                            }
                            //else if (ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim().Length != 10)
                            //{
                            //    dsError.Tables["Table1"].Rows.Add();
                            //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                            //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                            //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid phone number in the excel sheet";

                            //}
                            //else if (!GeneralFunc.IsNumeric(ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim()))
                            //{
                            //    dsError.Tables["Table1"].Rows.Add();
                            //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                            //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                            //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid phone number in the excel sheet";
                            //}
                            else if (CheckBTN(ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim()))
                            {
                                dsError.Tables["Table1"].Rows.Add();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Phone number already exists in database.";

                            }
                            else
                            {
                                if (ds.Tables[0].Rows[i]["STATE"].ToString().Trim() == ""
                                 || ds.Tables[0].Rows[i]["STATE"].ToString().Trim().Length != 2
                                 || ds.Tables[0].Rows[i]["STATE"].ToString().Trim() == null)
                                {
                                    dsError.Tables["Table1"].Rows.Add();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter the state code in the excel sheet";

                                }
                                //else if (ds.Tables[0].Rows[i]["STATE"].ToString().Trim().Length != 2)
                                //{
                                //    dsError.Tables["Table1"].Rows.Add();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Phoneno"] = ds.Tables[0].Rows[i]["Phoneno"].ToString().Trim();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter the proper state code in the excel Sheet";
                                //}
                                //if (ds.Tables[0].Rows[i]["STATE"].ToString().Trim() == null)
                                //{
                                //    dsError.Tables["Table1"].Rows.Add();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Error in record state code is not valid..";

                                //}

                                else if (ds.Tables[0].Rows[i]["STATE"].ToString().Trim().Length == 2)
                                {
                                    string Stateid = GetStateId(ds.Tables[0].Rows[i]["STATE"].ToString().Trim().ToUpper());
                                    if (Stateid == "0")
                                    {
                                        btnUpload.Text = "Upload";
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please check the record in the sheet, state is invalid.";

                                        ColNo.Add(12);
                                    }
                                }
                                //if (ds.Tables[0].Rows[i]["Price"].ToString().Trim().Length < 0)
                                //{
                                //    dsError.Tables["Table1"].Rows.Add();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                //    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter price in the excel sheet";

                                //}
                                if (ds.Tables[0].Rows[i]["Price"].ToString().Trim() != "")
                                {
                                    if (!GeneralFunc.IsNumeric(ds.Tables[0].Rows[i]["Price"].ToString().Trim()))
                                    {
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter numeric price in the excel sheet";
                                    }
                                }

                                if (ds.Tables[0].Rows[i]["Lead_Date"].ToString().Trim() == "")
                                {
                                    dsError.Tables["Table1"].Rows.Add();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter lead date in the excel sheet";


                                }
                                else if (!GeneralFunc.ValidateDate(ds.Tables[0].Rows[i]["Lead_Date"].ToString().Trim()))
                                {
                                    dsError.Tables["Table1"].Rows.Add();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                    dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid lead date in the excel sheet";
                                }
                                else
                                {
                                    DataSet dsDatetime = objHotLeadBL.GetDatetime();
                                    DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["Lead_Date"].ToString().Trim()) > dtNow)
                                    {
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Lead date cannot be greater than today date";
                                    }

                                }
                                if (ds.Tables[0].Rows[i]["Email"].ToString().Trim() != "")
                                {
                                    if (!GeneralFunc.isEmail(ds.Tables[0].Rows[i]["Email"].ToString().Trim()))
                                    {
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid email in the excel sheet";

                                    }
                                }
                                if (ds.Tables[0].Rows[i]["Year"].ToString().Trim() != "")
                                {
                                    if (!GeneralFunc.IsNumeric(ds.Tables[0].Rows[i]["Year"].ToString().Trim()))
                                    {
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid year in the excel sheet";

                                    }
                                    else if (ds.Tables[0].Rows[i]["Year"].ToString().Trim().Length != 4)
                                    {
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid year in the excel sheet";
                                    }
                                    else
                                    {
                                        DataSet dsDatetime = objHotLeadBL.GetDatetime();
                                        DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                                        DateTime EnterDate = Convert.ToDateTime("1/1/" + ds.Tables[0].Rows[i]["Year"].ToString().Trim());
                                        if (EnterDate > dtNow)
                                        {
                                            dsError.Tables["Table1"].Rows.Add();
                                            dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                            dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                            dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please enter valid year in the excel sheet";
                                        }
                                    }
                                }
                            }
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
                            int cint = 0;

                            foreach (DataRow row in dsVehicleTypes.Tables[0].Rows) // Loop over the rows.
                            {
                                if (row.ItemArray[0].ToString().ToLower() == ds.Tables[0].Rows[i]["VehicleType"].ToString().Trim().ToLower())
                                {
                                    cint = cint + 1;
                                    break;
                                }
                            }
                            if (cint == 0)
                            {
                                dsError.Tables["Table1"].Rows.Add();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please Enter Proper Vehicle Type";
                            }
                            cint = 0;
                            LeadSourceBL objLeadSourceBL = new LeadSourceBL();
                            DataSet dsLeadSource = new DataSet();
                            if (Cache["LeadSource"] == null)
                            {
                                dsLeadSource = objLeadSourceBL.GetLeadSources();
                                Cache["LeadSource"] = dsVehicleTypes;
                            }
                            else
                            {
                                dsLeadSource = (DataSet)Cache["LeadSource"];
                            }
                            foreach (DataRow row in dsLeadSource.Tables[0].Rows) // Loop over the rows.
                            {
                                if (row.ItemArray[0].ToString().ToLower() == ds.Tables[0].Rows[i]["LeadSourceID"].ToString().Trim().ToLower())
                                {
                                    cint = cint + 1;
                                    break;
                                }
                            }
                            if (cint == 0)
                            {
                                dsError.Tables["Table1"].Rows.Add();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (i + 1).ToString();
                                dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Please Enter Proper Lead Source ID";
                            }
                        }

                        if (dsError.Tables["Table1"].Rows.Count > 0)
                        {
                            grdIntroInfo.DataSource = null;
                            grdIntroInfo.DataBind();
                            grdErrors.DataSource = dsError.Tables["Table1"].DefaultView;
                            grdErrors.DataBind();
                            Header.Visible = false;

                        }
                        else
                        {
                            grdErrors.DataSource = null;
                            grdErrors.DataBind();
                            Header.Visible = true;
                            grdIntroInfo.DataSource = ds.Tables["XLData"].DefaultView;
                            grdIntroInfo.DataBind();
                            btnSubmit.Enabled = false; ;
                            btnUpload.Enabled = true;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            int phoneCount = 0;
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[j]["PhoneNo"].ToString() == ds.Tables[0].Rows[i]["PhoneNo"].ToString())
                                {

                                    phoneCount = phoneCount + 1;
                                    if (phoneCount > 1)
                                    {
                                        dsError.Tables["Table1"].Rows.Add();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["PhoneNo"] = ds.Tables[0].Rows[i]["PhoneNo"].ToString().Trim();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["RowNo"] = (j + 1).ToString();
                                        dsError.Tables["Table1"].Rows[dsError.Tables["Table1"].Rows.Count - 1]["Error"] = "Exist Duplicates PhoneNo In Excel Sheet Plz Check Excel Sheet";
                                    }
                                    ColNo.Add(8);

                                }
                            }
                        }

                        if (dsError.Tables["Table1"].Rows.Count > 0)
                        {
                            grdIntroInfo.DataSource = null;
                            grdIntroInfo.DataBind();
                            grdErrors.DataSource = dsError.Tables["Table1"].DefaultView;
                            grdErrors.DataBind();
                            Header.Visible = false;

                        }
                    }
                }
            }

            else
            {
                btnUpload.Text = "Upload";
                lblErrorMsg.Text = "Enter Valid Sales Excel Sheet Proper Columns.";
                btnSubmit.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.ToString() == "Not a legal OleAut date.")
            {
                Header.Visible = false;
                lblErrorMsg.Text = "Enter valid date format in excel sheet";
            }
            else
            {
                throw ex;
            }

        }
    }
    private bool CheckBTN(string BTN)
    {
        try
        {
            bool bFalse = false;
            LeadsBL ObjLeads = new LeadsBL();
            DataSet dsLeads = new DataSet();

            if (Session["LeadBTNs"] == null)
            {
                dsLeads = ObjLeads.LeadsCheckBTN();
                Session["LeadBTNs"] = dsLeads;
            }
            else
            {
                dsLeads = (DataSet)Session["LeadBTNs"];
            }

            DataView dv = new DataView();
            DataTable dt = new DataTable();
            dv = dsLeads.Tables[0].DefaultView;
            dv.RowFilter = "Phone=" + BTN + "";
            dt = dv.ToTable();

            if (dt.Rows.Count > 0)
            {
                bFalse = true;
            }
            return bFalse;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //LeadsInfo objLeadsInfo=new LeadsInfo(); 

        SmtpClient smtpClient = new SmtpClient();
        MailMessage mymail = new MailMessage();
        clsMailFormats objClsMailformat = new clsMailFormats();
        DbTransaction Transaction = null;
        DbConnection Connection = null;



        try
        {
            SalesfilesUpload(Convert.ToInt32(ViewState["Count"]), ViewState["FileName"].ToString());

            for (int index = 0; index < grdIntroInfo.Rows.Count; index++)
            {
                LeadsUploadExcel(index, ref  Transaction, ref  Connection);
            }

            if (Count > 0)
            {
                //string strSrc = Server.MapPath("SalesUpload\\" + ddlCampaigns.SelectedItem.Text + "\\");
                ///Server.MapPath("SalesUpload\\" + ddlCampaigns.SelectedItem.Text + "\\" + FILENAME)

                System.IO.FileInfo dirInfo = new System.IO.FileInfo(Session["FileName"].ToString());

                QCParameterBL objQCParameterBL = new QCParameterBL();
                DataSet ds = objQCParameterBL.UpdateLeadsQcStatusUpdate(Session["FileId"].ToString());

                //string filePath = strSrc;

                //string sAttach = filePath + Session["FileName"].ToString();

                //mymail.Attachments.Add(new Attachment(sAttach));


                //objFileType = (File_Type_Info)Session["Email_Sales"];

                //if (objFileType.Email_To != "")
                //{

                //    mymail.To.Add(objFileType.Email_To);
                //}



                //MailAddress fromAddress = new MailAddress(Session[GenValidations.Email.ToString()].ToString());

                //mymail.CC.Add(Session[GenValidations.Email.ToString()].ToString());

                //mymail.Bcc.Add(objFileType.Email_bCc);

                //mymail.From = fromAddress;

                //mymail.Subject = Session["LocName"].ToString() + "   " + ddlCampaigns.SelectedItem.Text + "  " + txtFrom.Text + "  Sales Uploaded On " + GenFunc.DateTimeFormat(System.DateTime.Now.ToString());

                string s = string.Empty;

                string SalesMailFile = (Server.MapPath("MailFormats") + @"\Sale Upload Mail Body text.txt");

                //objClsMailformat.sendSalesUpload(SalesMailFile,System.DateTime.Now.ToString(),ViewState["Count"].ToString(),txtFrom.Text.ToString(),txtTo.Text.ToString(),Session[GenValidations.USER_NAME].ToString(),ref s)
                //if (objClsMailformat.sendSalesUpload(SalesMailFile, System.DateTime.Now.ToString(), ViewState["Count"].ToString(), txtFrom.Text.ToString(), Session[GenValidations.USER_NAME].ToString(), ref s))
                //{
                //    //Specify true if it  is html message
                //    mymail.IsBodyHtml = true;

                //    mymail.Body = s.ToString();

                //    smtpClient.Host = "127.0.0.1";

                //    smtpClient.Port = 25;

                //    smtpClient.Send(mymail);
                //}
                //System.IO.File.Delete(Session["SaveLoc"].ToString());

                //  Total records in the file: 2000	
                //Duplicates found: 200	
                //Records uploaded: 1800	
                //QC passed leads: 1600	
                //QC failed leads: 200	

                lblErrorMsg.Text = grdIntroInfo.Rows.Count + " Record Uploaded Successfully </br> " + ds.Tables[0].Rows[0][0].ToString() + " QC Passed <br/> " + (Convert.ToInt32(grdIntroInfo.Rows.Count) - Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString())) + " QC Failed";
                btnSubmit.Enabled = true;
                btnUpload.Enabled = false;
                grdIntroInfo.DataSource = null;
                grdIntroInfo.DataBind();
            }
            else
            {
                lblErrorMsg.Text = "There are no Rows to Upload";
            }
        }
        catch (Exception ex)
        {
            Transaction.Rollback();
            Connection.Close();
            lblErrorMsg.Text = "Sales Uploaded, but Mail Could not be Found.";
        }
        finally
        {
            mymail.Dispose();
            smtpClient = null;
        }
    }
    private Int64 LeadsUploadExcel(int rowNo, ref DbTransaction Transaction, ref DbConnection Connection)
    {
        Int64 refOut = 0;

        bool bfirst = true;

        DataSet ds = new DataSet();
        LeadsInfo objLeadsInfo = new LeadsInfo();
        LeadsBL objleadBL = new LeadsBL();
        DataSet dsCampaigns = new DataSet();
        DataView dv = new DataView();
        DataTable dt = new DataTable();
        try
        {
            if (grdIntroInfo.Rows.Count > 0)
            {
                #region SalesTable


                objLeadsInfo.Phone = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblPhoneno")).Text).ToString();
                objLeadsInfo.Header = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblHeader")).Text).ToString();
                objLeadsInfo.Price = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblPrice")).Text).ToString();
                objLeadsInfo.State = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblState")).Text).ToString(); ;
                objLeadsInfo.City = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblCity")).Text).ToString();
                //objLeadsInfo.Zip = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblSaleBY")).Text).ToString();
                objLeadsInfo.URL = GenFunc.ExcelTextFormat(((HyperLink)grdIntroInfo.Rows[rowNo].FindControl("lblURL")).Text).ToString();
                objLeadsInfo.VehicleTypeID = ddlVehicleType.SelectedItem.Value;
                objLeadsInfo.LeadUpBatchID = Session["FileId"].ToString();



                //objLeadsInfo.se
                //objLeadsInfo.yhe = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblSaleBY")).Text).ToString();



                //objLeadsInfo .Sales_Notes = GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("hdnSALESNOTES")).Text.ToString());

                #endregion ContactTable

                //Excel File Opening Transaction 
                if (rowNo == 0)
                {
                    bfirst = true;
                }
                if (rowNo > 0)
                {
                    if (grdIntroInfo.Rows.Count - 1 == rowNo)
                    {
                        bfirst = false;
                    }
                }
                //bool bnew = CheckBTN(GenFunc.ExcelTextFormat(((Label)grdIntroInfo.Rows[rowNo].FindControl("lblPhoneno")).Text).ToString());
                //if (bnew == false)
                //{
                Count = Count + 1;
                objleadBL.SaveLeadsInfo(objLeadsInfo, bfirst, rowNo, grdIntroInfo.Rows.Count - 1, ref Transaction, ref Connection);
                Transaction = Transaction;
                Connection = Connection;
                //}

            }
        }
        catch (Exception ex)
        {
            Transaction.Rollback();
            Connection.Close();

            //bool rethrow = ExceptionPolicy.HandleException(ex, ConstantClass.StrCRMUIPolicy);

            //if (rethrow)
            //    throw;

            //Redirecting to error message page
            //Server.Transfer(ConstantClass.StrErrorPageURL);
        }
        return refOut;
    }
    private void SalesfilesUpload(int RecordCount, string sFileName)
    {
        try
        {
            Int64 Return = 0;

            LeadBatchFile objLeadBatchFile = new LeadBatchFile();
            LeadsBL objLeadsBL = new LeadsBL();

            objLeadBatchFile.Leaddate = System.DateTime.Now.ToString();
            objLeadBatchFile.LeadFile = sFileName;
            objLeadBatchFile.RecordCount = RecordCount.ToString();
            objLeadBatchFile.LeadUploadedBy = (Session[Constants.USER_ID]).ToString();
            objLeadBatchFile.Leadsource = "1";


            DataSet ds = new DataSet();


            ds = objLeadsBL.SaveFileDetails(objLeadBatchFile, ref Return, ddlVehicleType.SelectedItem.Value);



            Session["FileId"] = ds.Tables[0].Rows[0][0].ToString();



        }
        catch (Exception ex)
        {
            //bool rethrow = ExceptionPolicy.HandleException(ex, ConstantClass.StrCRMUIPolicy);
            throw ex;
            //if (rethrow)
            //    throw;

            //Redirecting to error message page
            //Server.Transfer(ConstantClass.StrErrorPageURL);
        }

    }
    public string GetStateId(string StateCode)
    {

        string StateId = string.Empty;

        DataTable dt = new DataTable();

        DataSet ds = new DataSet();

        DataView dv = new DataView();

        try
        {
            if (StateCode != "")
            {

                if (Cache["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Cache["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Cache["DsDropDown"];

                }

                dv = dsDropDown.Tables[1].DefaultView;

                //State_Code

                dv.RowFilter = "State_Code ='" + StateCode + "'";

                dt = dv.ToTable();

                if (dt.Rows.Count > 0)
                {
                    StateId = dt.Rows[0]["State_Id"].ToString();
                }
                if (StateId == "")
                {

                    StateId = "0";
                }
            }
        }

        catch (Exception ex)
        {

            throw ex;
            //Redirecting to error message page
        }
        return StateId;
    }

    public object GetStateId(object StateCode)
    {
        string StateId = string.Empty;

        DataTable dt = new DataTable();

        DataSet ds = new DataSet();

        DataView dv = new DataView();

        try
        {
            if (StateCode != "")
            {
                if (Cache["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Cache["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Cache["DsDropDown"];

                }

                dv = dsDropDown.Tables[1].DefaultView;
                dv.RowFilter = "State_Code = '" + StateCode + "'";

                dt = dv.ToTable();

                if (dt.Rows.Count > 0)
                {
                    StateId = dt.Rows[0]["State_Id"].ToString();
                }
                if (StateId == "")
                {

                    StateId = "0";
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
            //Redirecting to error message page
        }
        return StateId;
    }

}
