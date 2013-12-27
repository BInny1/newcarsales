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
using System.Text.RegularExpressions;


public partial class Brands : System.Web.UI.Page
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
                        lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");

                        Session["SortDirec"] = null;

                        GetProducts();
                        GetBrands();
                      
                    }

                }
            }
        }
    }

    private void GetProducts()
    {

        try
        {
            DataSet dsProducts = objHotLeadBL.GetAllProducts();
            txtVeckType.Items.Clear();
            for (int i = 0; i < dsProducts.Tables[0].Rows.Count; i++)
            {
                if (dsProducts.Tables[0].Rows[i]["Vehicletypeid"].ToString() != "0")
                {
                    ListItem list = new ListItem();
                    list.Text = dsProducts.Tables[0].Rows[i]["vehicletypename"].ToString();
                    list.Value = dsProducts.Tables[0].Rows[i]["Vehicletypeid"].ToString();
                    txtVeckType.Items.Add(list);
                }
            }
            txtVeckType.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
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
    private void GetBrands()
    {
        GridBrands.DataSource = null;
        GridBrands.DataBind();
        DataSet GetBrands = new DataSet();
        GetBrands = objHotLeadBL.GetBrandsList();
        GridBrands.DataSource = GetBrands.Tables[0];
        GridBrands.DataBind();
    }
  
  
    protected void lnkBrndNew_Click(object sender, EventArgs e)
    {
        MPBrands.Show();
        txtVeckType.SelectedIndex = 0;
        txtBrnad.Text = "";
    }

    protected void lnkgroups_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        Boolean Sttaus = false, Sttaus1 = false;
        if (rbt_VechGrop.Items[0].Selected == true)
            Sttaus = true;
        else
            Sttaus = false;
        if (rbt_VechGrop.Items[1].Selected == true)
            Sttaus1 = true;
        else
            Sttaus1 = false;

        if (txtVeckType.Text != "0")
        {
            if (txtBrnad.Text != "")
            {
                if (Sttaus == true || Sttaus1 == true)
                {
                    //if brand is existed or not UCE

                    txtBrnad.Text = Regex.Replace(txtBrnad.Text, @"\s+", "");
                    DataSet checkrecord = objHotLeadBL.CheckRecordexist(txtBrnad.Text.Trim());
                    if (checkrecord.Tables[0].Rows.Count == 0)
                    {
                        objHotLeadBL.SaveNewBrands(txtVeckType.Text, txtBrnad.Text, Sttaus);
                      
                        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('New Brand is added successfully.');", true);
                        //MpVechlAdd.Hide();
                        GetBrands();
                       
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Brand already existed.');", true);
                    }
                  
                }
                else
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('please select status.');", true);
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('please enter Brand.');", true);
                MPBrands.Show();
                txtBrnad.Focus();
            }

        }
       
        else
        {
            txtVeckType.Focus();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('please select product.');", true);
            MPBrands.Show();
        }
       
       
     
       
    }
    protected void btngroupAdd_Click(object sender, EventArgs e)
    {
       
    }

}
