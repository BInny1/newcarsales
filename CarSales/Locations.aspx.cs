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


public partial class Locations : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserregInfo = new UserRegistrationInfo();
    HotLeadsBL objHotLeadBL = new HotLeadsBL();
    
    //string modid1 = ""; string modid2 = ""; string modid3 = ""; string modid4 = ""; string modid5 = ""; string modid6 = ""; string modid7 = "";
    //string proid1 = ""; string proid2 = ""; string proid3 = ""; string proid4 = ""; string proid5 = ""; string proid6 = ""; string proid7 = "";
    //string brandid1 = ""; string brandid2 = ""; string brandid3 = ""; string brandid4 = ""; string brandid5 = ""; string brandid6 = ""; string brandid7 = "";
    string centerid = "";
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

                        GetCentersUpdateLIst();

                    }

                }
            }
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


    private void GetCentersUpdateLIst()
    {
        DataSet GridCentersUpa = new DataSet();
        GridCentersUpa = objHotLeadBL.GetAllLocations();
        GridCentersUpades.DataSource = GridCentersUpa.Tables[0];
        GridCentersUpades.DataBind();
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
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
    protected void GridCentersUpades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton lblLeadsUpload = (LinkButton)e.Row.FindControl("lnkUName1");
                Label LeadsUpload = (Label)e.Row.FindControl("LeadsUpload");
                Label lblSales = (Label)e.Row.FindControl("lblSales");
                Label lblcustmerserv = (Label)e.Row.FindControl("lblcustmerserv");
                Label lblprocess = (Label)e.Row.FindControl("lblprocess");
                Label lbltransin = (Label)e.Row.FindControl("lbltransin");
                Label lblabonds = (Label)e.Row.FindControl("lblabonds");
                Label lblfreeposts = (Label)e.Row.FindControl("lblfreeposts");


                HiddenField centerid = (HiddenField)e.Row.FindControl("centerid");
                string cenetrids = centerid.Value;


                DataSet dsTasks3 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 1);
                for (int i = 0; i < dsTasks3.Tables[0].Rows.Count; i++)
                {
                    try
                    {
//string va
                         LeadsUpload.Text+= dsTasks3.Tables[0].Rows[i]["vehicleTypename"].ToString() +",";
                        if(LeadsUpload.Text.EndsWith(","))
                            LeadsUpload.Text=LeadsUpload.Text.Substring(0,LeadsUpload.Text.LastIndexOf(','));
                    }
                    catch { }
                }

                //Sales
                DataSet dsTasks4 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 15);
                for (int i = 0; i < dsTasks4.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        lblSales.Text += dsTasks4.Tables[0].Rows[i]["Brand"].ToString() + ",";
                        if (lblSales.Text.EndsWith(","))
                            lblSales.Text = lblSales.Text.Substring(0, lblSales.Text.LastIndexOf(','));
                    }
                    catch { }
                }

                //lblcustmerserv
                DataSet dsTasks5 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 30);
                for (int i = 0; i < dsTasks5.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        lblcustmerserv.Text += dsTasks5.Tables[0].Rows[i]["Brand"].ToString() + ",";
                        if (lblcustmerserv.Text.EndsWith(","))
                            lblcustmerserv.Text = lblcustmerserv.Text.Substring(0, lblcustmerserv.Text.LastIndexOf(','));
                    }
                    catch { }
                }

               // lblprocess
                DataSet dsTasks6 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 16);
                for (int i = 0; i < dsTasks6.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        lblprocess.Text += dsTasks6.Tables[0].Rows[i]["Brand"].ToString() + ",";
                        if (lblprocess.Text.EndsWith(","))
                            lblprocess.Text = lblprocess.Text.Substring(0, lblprocess.Text.LastIndexOf(','));
                    }
                    catch { }
                }

                //lbltransin
                DataSet dsTasks7 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 8);
                for (int i = 0; i < dsTasks7.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        lbltransin.Text += dsTasks7.Tables[0].Rows[i]["vehicleTypename"].ToString() + ",";
                        if (lbltransin.Text.EndsWith(","))
                            lbltransin.Text = lbltransin.Text.Substring(0, lbltransin.Text.LastIndexOf(','));
                    }
                    catch { }
                }

                //lblabonds
                DataSet dsTasks8 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 3);
                for (int i = 0; i < dsTasks8.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        lblabonds.Text += dsTasks8.Tables[0].Rows[i]["vehicleTypename"].ToString() + ",";
                        if (lblabonds.Text.EndsWith(","))
                            lblabonds.Text = lblabonds.Text.Substring(0, lblabonds.Text.LastIndexOf(','));
                    }
                    catch { }
                }

                //lblfreeposts
                DataSet dsTasks9 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(cenetrids.ToString()), 4);
                for (int i = 0; i < dsTasks9.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        lblfreeposts.Text += dsTasks9.Tables[0].Rows[i]["vehicleTypename"].ToString() + ",";
                        if (lblfreeposts.Text.EndsWith(","))
                            lblfreeposts.Text = lblfreeposts.Text.Substring(0, lblfreeposts.Text.LastIndexOf(','));
                    }
                    catch { }
                }


            }

        }
        catch { }

    }
    protected void GridCentersUpades_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "Center Code";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Leads Upoad";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.CssClass = "BL BR";

            HeaderCell = new TableCell();
            HeaderCell.Text = "Sales";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Customer Service";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.CssClass = "BL BR";

            HeaderCell = new TableCell();
            HeaderCell.Text = "Process";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.CssClass = "BR ";

            HeaderCell = new TableCell();
            HeaderCell.Text = "Leads Download";
            HeaderCell.ColumnSpan = 3;
            HeaderGridRow.Cells.Add(HeaderCell);

            GridCentersUpades.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }


    }
    //protected void btnl_click(object sender, EventArgs e)
    //{
    //    MpUpdaterights.Show();
    //}
    protected void GridCentersUpades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "PLoc")
        {
            ModalPopupExtender2.Show();

            try
            {
                Session["proid1"] = ""; Session["proid2"] = ""; Session["proid3"] = ""; Session["proid4"] = "";
                Session["proid5"] = ""; Session["proid6"] = ""; Session["proid7"] = ""; Session["brandid1"] = "";
                Session["brandid2"] = ""; Session["brandid3"] = ""; Session["brandid4"] = "";
                Session["brandid5"] = ""; Session["brandid6"] = ""; Session["brandid7"] = "";

                DataSet dsTasks3 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 1);
                DataSet dsTasks4 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 15);
                DataSet dsTasks5 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 30);
                DataSet dsTasks6 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 16);
                DataSet dsTasks7 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 8);
                DataSet dsTasks8 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 3);
                DataSet dsTasks9 = objHotLeadBL.UpdatecentersById(Convert.ToInt32(e.CommandArgument.ToString()), 4);
                DataSet dspro = objHotLeadBL.GetAllProducts();
                DropDownList1.DataSource = DropDownList5.DataSource = DropDownList6.DataSource = DropDownList7.DataSource = dspro;
                DropDownList1.DataValueField = DropDownList5.DataValueField = DropDownList6.DataValueField = DropDownList7.DataValueField = "Vehicletypeid";
                DropDownList1.DataTextField = DropDownList5.DataTextField = DropDownList6.DataTextField = DropDownList7.DataTextField = "vehicletypename";
                DataSet dsBrands = objHotLeadBL.GetBrandsList();
                DropDownList2.DataSource = DropDownList3.DataSource = DropDownList4.DataSource = dsBrands;
                DropDownList2.DataValueField = DropDownList3.DataValueField = DropDownList4.DataValueField = "BId";
                DropDownList2.DataTextField = DropDownList3.DataTextField = DropDownList4.DataTextField = "Brands";
                DropDownList1.DataBind(); DropDownList2.DataBind(); DropDownList3.DataBind(); DropDownList4.DataBind();
                DropDownList5.DataBind(); DropDownList6.DataBind(); DropDownList7.DataBind();
                if (Convert.ToInt32(e.CommandArgument) == 4)
                {
                    LinkButton1.Text = "INDG";

                }
                else if (Convert.ToInt32(e.CommandArgument) == 1)
                {
                    LinkButton1.Text = "INBH";
                    //TextBox1.Text = dsTasks3.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox3.Text = dsTasks4.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox4.Text = dsTasks5.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox7.Text = dsTasks6.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox8.Text = dsTasks7.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox9.Text = dsTasks8.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox10.Text = dsTasks9.Tables[0].Rows[0]["Brand"].ToString();
                }
                else if (Convert.ToInt32(e.CommandArgument) == 2)
                {
                    LinkButton1.Text = "USMP";
                    //TextBox1.Text = dsTasks3.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox3.Text = dsTasks4.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox4.Text = dsTasks5.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox7.Text = dsTasks6.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox8.Text = dsTasks7.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox9.Text = dsTasks8.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox10.Text = dsTasks9.Tables[0].Rows[0]["Brand"].ToString();
                }
                else if (Convert.ToInt32(e.CommandArgument) == 3)
                {
                    LinkButton1.Text = "USWB";
                    //TextBox1.Text = dsTasks3.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox3.Text = dsTasks4.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox4.Text = dsTasks5.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox7.Text = dsTasks6.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox8.Text = dsTasks7.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox9.Text = dsTasks8.Tables[0].Rows[0]["Brand"].ToString();
                    //TextBox10.Text = dsTasks9.Tables[0].Rows[0]["Brand"].ToString();
                }
                TextBox1.Text = dsTasks3.Tables[0].Rows[0]["vehicletypename"].ToString();
                TextBox3.Text = dsTasks4.Tables[0].Rows[0]["Brand"].ToString();
                TextBox4.Text = dsTasks5.Tables[0].Rows[0]["Brand"].ToString();
                TextBox7.Text = dsTasks6.Tables[0].Rows[0]["Brand"].ToString();
                TextBox8.Text = dsTasks7.Tables[0].Rows[0]["vehicletypename"].ToString();
                TextBox9.Text = dsTasks8.Tables[0].Rows[0]["vehicletypename"].ToString();
                TextBox10.Text = dsTasks9.Tables[0].Rows[0]["vehicletypename"].ToString();
            }
            catch { }
        }
    }
    protected void btn_Add1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = TextBox1.Text + "," + DropDownList1.SelectedItem.ToString();
        //Session["proid1"] = DropDownList1.SelectedValue;
        Session["brandid1"] = "0";
        Session["modid1"] = "1";
        if (Session["proid1"] != null)
        {
            if (!Session["proid1"].ToString().Contains(DropDownList1.SelectedValue))
            {
                Session["proid1"] = DropDownList1.SelectedValue + "," + Session["proid1"].ToString();
            }
        }
        else
            Session["proid1"] = DropDownList1.SelectedValue;
        DropDownList1.Items.Remove(DropDownList1.SelectedItem);
    }
    protected void btn_Add2_Click(object sender, EventArgs e)
    {
        TextBox3.Text = TextBox3.Text + "," + DropDownList2.SelectedItem.ToString();
        //Session["brandid2"] = DropDownList2.SelectedValue;
        Session["proid2"] = "0";
        Session["modid2"] = "15";
        if (Session["brandid2"] != null)
        {
            if (!Session["brandid2"].ToString().Contains(DropDownList2.SelectedValue))
            {
                Session["brandid2"] = DropDownList2.SelectedValue + "," + Session["brandid2"].ToString();
            }
        }
        else
            Session["brandid2"] = DropDownList2.SelectedValue;
        DropDownList2.Items.Remove(DropDownList2.SelectedItem);
    }
    protected void btn_Add3_Click(object sender, EventArgs e)
    {
        TextBox4.Text = TextBox4.Text + "," + DropDownList3.SelectedItem.ToString();
        //Session["brandid3"] = DropDownList3.SelectedValue;
        Session["proid3"] = "0";
        Session["modid3"] = "30";
        if (Session["brandid3"] != null)
        {
            if (!Session["brandid3"].ToString().Contains(DropDownList3.SelectedValue))
            {
                Session["brandid3"] = DropDownList3.SelectedValue + "," + Session["brandid3"].ToString();
            }
        }
        else
            Session["brandid3"] = DropDownList3.SelectedValue;
        DropDownList3.Items.Remove(DropDownList3.SelectedItem);
    }
    protected void btn_Add4_Click(object sender, EventArgs e)
    {
        TextBox7.Text = TextBox7.Text + "," + DropDownList4.SelectedItem.ToString();
        //Session["brandid4"] = DropDownList4.SelectedValue;
        Session["proid4"] = "0";
        Session["modid4"] = "16";
        if (Session["brandid4"] != null)
        {
            if (!Session["brandid4"].ToString().Contains(DropDownList4.SelectedValue))
            {
                Session["brandid4"] = DropDownList4.SelectedValue + "," + Session["brandid4"].ToString();
            }
        }
        else
            Session["brandid4"] = DropDownList4.SelectedValue;
        DropDownList4.Items.Remove(DropDownList4.SelectedItem);
    }
    protected void btn_Add5_Click(object sender, EventArgs e)
    {
        TextBox8.Text = TextBox8.Text + "," + DropDownList5.SelectedItem.ToString();
        //Session["proid5"] = DropDownList5.SelectedValue;
        Session["brandid5"] = "0";
        Session["modid5"] = "8";
        if (Session["proid5"] != null)
        {
            if (!Session["proid5"].ToString().Contains(DropDownList5.SelectedValue))
            {
                Session["proid5"] = DropDownList5.SelectedValue + "," + Session["proid5"].ToString();
            }
        }
        else
            Session["proid5"] = DropDownList5.SelectedValue;
        DropDownList5.Items.Remove(DropDownList5.SelectedItem);
    }
    protected void btn_Add6_Click(object sender, EventArgs e)
    {
        TextBox9.Text = TextBox9.Text + "," + DropDownList6.SelectedItem.ToString();
        //Session["proid6"] = DropDownList6.SelectedValue;
        Session["brandid6"] = "0";
        Session["modid6"] = "3";
        if (Session["proid6"] != null)
        {
            if (!Session["proid6"].ToString().Contains(DropDownList6.SelectedValue))
            {
                Session["proid6"] = DropDownList6.SelectedValue + "," + Session["proid6"].ToString();
            }
        }
        else
            Session["proid6"] = DropDownList6.SelectedValue;
        DropDownList6.Items.Remove(DropDownList6.SelectedItem);
    }
    protected void btn_Add7_Click(object sender, EventArgs e)
    {
        TextBox10.Text = TextBox10.Text + "," + DropDownList7.SelectedItem.ToString();
        //Session["proid7"] = DropDownList7.SelectedValue;
        Session["brandid7"] = "0";
        Session["modid7"] = "4";
        if (Session["proid7"] != null)
        {
            if (!Session["proid7"].ToString().Contains(DropDownList7.SelectedValue))
            {
                Session["proid7"] = DropDownList7.SelectedValue + "," + Session["proid7"].ToString();
            }
        }
        else
            Session["proid7"] = DropDownList7.SelectedValue;
        DropDownList7.Items.Remove(DropDownList7.SelectedItem);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string[] proid1 = { }; string[] proid2 = { }; string[] proid3 = { };
        string[] proid4 = { }; string[] proid5 = { }; string[] proid6 = { }; string[] proid7 = { };
        string[] brandid1 = { }; string[] brandid2 = { }; string[] brandid3 = { };
        string[] brandid4 = { }; string[] brandid5 = { }; string[] brandid6 = { }; string[] brandid7 = { };
        string[] brandids = { }; string[] proids = { };
        if (LinkButton1.Text == "INDG")
        {
            centerid = "4";
        }
        else if (LinkButton1.Text == "INBH")
        {
            centerid = "1";
        }
        else if (LinkButton1.Text == "USMP")
        {
            centerid = "2";
        }
        else if (LinkButton1.Text == "USWB")
        {
            centerid = "3";
        }
        if (Session["proid1"] != null)
        {
            if (Session["proid1"].ToString().Contains(',') && Session["proid1"].ToString().IndexOf(',') != -1)
            {
                if (Session["proid1"].ToString().LastIndexOf(',') == Session["proid1"].ToString().Length - 1)
                    Session["proid1"] = Session["proid1"].ToString().Substring(0, Session["proid1"].ToString().LastIndexOf(','));
                proid1 = Session["proid1"].ToString().Split(',');
            }
            else
            {
                proid1 = new string[] { Session["proid1"].ToString() };
            }
            foreach (string i in proid1)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid1"].ToString()), Convert.ToInt32(Session["brandid1"].ToString()), Convert.ToInt32(i), Convert.ToInt32(centerid));
            }
        }
        if (Session["proid5"] != null)
        {
            if (Session["proid5"].ToString().Contains(',') && Session["proid5"].ToString().IndexOf(',') != -1)
            {
                if (Session["proid5"].ToString().LastIndexOf(',') == Session["proid5"].ToString().Length - 1)
                    Session["proid5"] = Session["proid5"].ToString().Substring(0, Session["proid5"].ToString().LastIndexOf(','));
                proid5 = Session["proid5"].ToString().Split(',');
            }
            else
            {
                proid5 = new string[] { Session["proid5"].ToString() };
            }
            foreach (string i in proid5)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid5"].ToString()), Convert.ToInt32(Session["brandid5"].ToString()), Convert.ToInt32(i), Convert.ToInt32(centerid));
            }
        }
        if (Session["proid6"] != null)
        {
            if (Session["proid6"].ToString().Contains(',') && Session["proid6"].ToString().IndexOf(',') != -1)
            {
                if (Session["proid6"].ToString().LastIndexOf(',') == Session["proid6"].ToString().Length - 1)
                    Session["proid6"] = Session["proid6"].ToString().Substring(0, Session["proid6"].ToString().LastIndexOf(','));
                proid6 = Session["proid6"].ToString().Split(',');
            }
            else
            {
                proid6 = new string[] { Session["proid6"].ToString() };
            }
            foreach (string i in proid6)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid6"].ToString()), Convert.ToInt32(Session["brandid6"].ToString()), Convert.ToInt32(i), Convert.ToInt32(centerid));
            }
        }
        if (Session["proid7"] != null)
        {
            if (Session["proid7"].ToString().Contains(',') && Session["proid7"].ToString().IndexOf(',') != -1)
            {
                if (Session["proid7"].ToString().LastIndexOf(',') == Session["proid7"].ToString().Length - 1)
                    Session["proid7"] = Session["proid7"].ToString().Substring(0, Session["proid7"].ToString().LastIndexOf(','));
                proid7 = Session["proid7"].ToString().Split(',');
            }
            else
            {
                proid7 = new string[] { Session["proid7"].ToString() };
            }
            foreach (string i in proid7)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid7"].ToString()), Convert.ToInt32(Session["brandid7"].ToString()), Convert.ToInt32(i), Convert.ToInt32(centerid));
            }
        }
        if (Session["brandid2"] != null)
        {
            if (Session["brandid2"].ToString().Contains(',') && Session["brandid2"].ToString().IndexOf(',') != -1)
            {
                if (Session["brandid2"].ToString().LastIndexOf(',') == Session["brandid2"].ToString().Length - 1)
                    Session["brandid2"] = Session["brandid2"].ToString().Substring(0, Session["brandid2"].ToString().LastIndexOf(','));
                brandid2 = Session["brandid2"].ToString().Split(',');
            }
            else
            {
                brandid2 = new string[] { Session["brandid2"].ToString() };
            }
            foreach (string i in brandid2)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid2"].ToString()), Convert.ToInt32(i), Convert.ToInt32(Session["proid2"].ToString()), Convert.ToInt32(centerid));
            }
        }
        if (Session["brandid3"] != null)
        {
            if (Session["brandid3"].ToString().Contains(',') && Session["brandid3"].ToString().IndexOf(',') != -1)
            {
                if (Session["brandid3"].ToString().LastIndexOf(',') == Session["brandid3"].ToString().Length - 1)
                    Session["brandid3"] = Session["brandid3"].ToString().Substring(0, Session["brandid3"].ToString().LastIndexOf(','));
                brandid3 = Session["brandid3"].ToString().Split(',');
            }
            else
            {
                brandid3 = new string[] { Session["brandid3"].ToString() };
            }
            foreach (string i in brandid3)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid3"].ToString()), Convert.ToInt32(i), Convert.ToInt32(Session["proid3"].ToString()), Convert.ToInt32(centerid));
            }
        }
        if (Session["brandid4"] != null)
        {
            if (Session["brandid4"].ToString().Contains(',') && Session["brandid4"].ToString().IndexOf(',') != -1)
            {
                if (Session["brandid4"].ToString().LastIndexOf(',') == Session["brandid4"].ToString().Length - 1)
                    Session["brandid4"] = Session["brandid4"].ToString().Substring(0, Session["brandid4"].ToString().LastIndexOf(','));
                brandid4 = Session["brandid4"].ToString().Split(',');
            }
            else
            {
                brandid4 = new string[] { Session["brandid4"].ToString() };
            }
            foreach (string i in brandid4)
            {
                if (i != "")
                    objHotLeadBL.UpdateCentersList(Convert.ToInt32(Session["modid4"].ToString()), Convert.ToInt32(i), Convert.ToInt32(Session["proid4"].ToString()), Convert.ToInt32(centerid));
            }
        }
        ModalPopupExtender2.Hide();

        GetCentersUpdateLIst();
    }
  
   
}

