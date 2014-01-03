﻿using System;
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


public partial class Products : System.Web.UI.Page
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

                      
                        GetVehicleTypes();
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
   
    private void GetVehicleTypes()
    {
        GridVehicletype.DataSource = null;
        GridVehicletype.DataBind();
        DataSet GetVehicles = new DataSet();
        GetVehicles = objHotLeadBL.VehicleTypes();
        GridVehicletype.DataSource = GetVehicles.Tables[0];
        GridVehicletype.DataBind();
    }
   

    protected void lnkgroups_Click(object sender, EventArgs e)
    {
        MPBrands.Show();
    }
  
    protected void btngroupAdd_Click(object sender, EventArgs e)
    {
        if (txtgrpname.Text != "")
        {
            txtgrpname.Text = Regex.Replace(txtgrpname.Text, @"\s+", "");
            DataSet checkrecord = objHotLeadBL.CheckRecordforProductexist(txtgrpname.Text.Trim());
            if (checkrecord.Tables[0].Rows.Count == 0)
            {
                objHotLeadBL.InsertNewGroup(txtgrpname.Text);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('New Product is added successfully.');", true);
                GetVehicleTypes();
                MPBrands.Hide();
               
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Product is already existed.');", true);
            }
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('please enter Product.');", true);
            txtgrpname.Focus();
        }
        
    }
    public void BtnEdit_Click(object sender, EventArgs e)
    {
        //Update
        DataSet UpdateProduct = objHotLeadBL.UpdateEditProduct(txtEdit.Text,Convert.ToInt32( Session["VehId"].ToString()));
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Product updaed successfully.');", true);
        MdpEditProduc.Hide();
        GetVehicleTypes();
    }
    protected void GridVehicletype_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            MdpEditProduc.Show();
            if (e.CommandName == "vehick")
            {

                string Vehclnam = e.CommandArgument.ToString();
                string[] strArr = Vehclnam.Split(';');
                Session["VehName"] = strArr[0].ToString();
                Session["VehId"] = strArr[1].ToString();

                txtEdit.Text = Session["VehName"].ToString();


            }
        }
        catch { }
    }

}
