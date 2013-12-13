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


public partial class UpdateCentersList : System.Web.UI.Page
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
                Session["CurrentPage"] = "CentersList";

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

                        //LoadUserRights();
                        //lnkBtnLogout.Visible = true;
                        //lblUserName.Visible = true;
                        //string LogUsername = Session[Constants.NAME].ToString();
                        //string CenterCode = Session[Constants.CenterCode].ToString();
                        //string UserLogName = Session[Constants.USER_NAME].ToString();
                        //if (LogUsername.Length > 20)
                        //{
                        //    lblUserName.Text = LogUsername.ToString().Substring(0, 20);
                          
                        //    lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")-" + UserLogName.ToString();
                          
                        //}
                        //else
                        //{
                        //    lblUserName.Text = LogUsername;
                        //    //if (CenterCode.Length > 5)
                          
                        //    lblUserName.Text = lblUserName.Text + " (" + CenterCode.ToString() + ")-" + UserLogName.ToString();
                        //}
                      
                  //  }
                }
            }
        }
        if (!IsPostBack)
        {
            GetCentersUpdateLIst();
           
        }
    }

    private bool LoadIndividualUserRights()
    {
        DataSet dsIndidivitualRights = new DataSet();
        bool bValid = false;
        //dsIndidivitualRights = objHotLeadBL.GetUserModules_ActiveInactive(Session[Constants.USER_ID]);
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


    private void GetCentersUpdateLIst()
    {
        DataSet GridCentersUpa = new DataSet();
        GridCentersUpa = objHotLeadBL.GridCentersUpa();
        GridCentersUpades.DataSource = GridCentersUpa.Tables[0];
        GridCentersUpades.DataBind();
    }
    protected void lnkBtnLogout_Click(object sender,EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    private void GetVehicleTypes()
    {
        DataSet GetVehicles = new DataSet();
        GetVehicles = objHotLeadBL.VehicleTypes();
        GridCentersUpades.DataSource = GetVehicles.Tables[0];
        GridCentersUpades.DataBind();
    }
    protected void lnkBrndNew_Click(object sender, EventArgs e)
    {
        MpVechlAdd.Show();
    }
    protected void btnAddVehicle_Click(object sender, EventArgs e)
    {
        Boolean Sttaus=false;
        if(rbt_VechGrop.Items[0].Selected==true)
            Sttaus=true;
        else
            Sttaus=false;
        objHotLeadBL.SaveNewBrands(txtVeckType.Text, txtBrnad.Text, Sttaus);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('New Brand is added successfully.');", true);
        MpVechlAdd.Hide();
    }
}
