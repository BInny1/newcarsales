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


public partial class NewEntrys : System.Web.UI.Page
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
            if (!IsPostBack)
            {
                Session["CurrentPage"] = "New sale";

                if (LoadIndividualUserRights() == false)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    ServiceReference objServiceReference = new ServiceReference();

                    ScriptReference objScriptReference = new ScriptReference();

                    objServiceReference.Path = "~/WebService.asmx";

                    objScriptReference.Path = "~/Static/Js/CarsJScript.js";

                    scrptmgr.Services.Add(objServiceReference);
                    scrptmgr.Scripts.Add(objScriptReference);

                    if (Session[Constants.NAME] == null)
                    {
                        lnkBtnLogout.Visible = false;
                        lblUserName.Visible = false;
                    }
                    else
                    {
                        //LoadUserRights();
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
                            
                            lblUserName.Text = lblUserName.Text + " (" + UserLogName.ToString() + ")-" + CenterCode.ToString();
                        }

                    }
                    if (Session["DsDropDown"] == null)
                    {
                        dsDropDown = objdropdownBL.Usp_Get_DropDown();
                        Session["DsDropDown"] = dsDropDown;
                    }
                    else
                    {
                        dsDropDown = (DataSet)Session["DsDropDown"];
                    }
                    Session["NewSaleCarID"] = null;
                    Session["NewSaleUID"] = null;
                    Session["NewSalePostingID"] = null;
                    Session["NewSaleUserPackID"] = null;
                    Session["NewSaleSellerID"] = null;
                    Session["NewSalePSID1"] = null;
                    Session["NewSalePSID2"] = null;
                    Session["NewSalePaymentID"] = null;
                    lnkTicker.Attributes.Add("href", "javascript:poptastic('Ticker.aspx?CID=" + Session[Constants.CenterCodeID] + "&CNAME=" + Session[Constants.CenterCode] + "');");
                    DataSet dsYears = objHotLeadBL.USP_GetNext12years();

                    fillYears(dsYears);
                    FillYear();
                    FillPackage();
                    FillDiscounts();
                    FillStates();
                    GetAllModels();
                    GetMakes();
                    GetModelsInfo();
                    FillExteriorColor();
                    FillInteriorColor();
                    GetBody();
                    //FillPaymentDate();
                    FillPDDate();
                    FillBillingStates();
                    FillPhotoSource();
                    FillDescriptionSource();
                    FillVerifier();
                    FillAgents();
                    FillVoiceFileLocation();
                    // FillCheckTypes();
                    //DataSet dsTransfers = objHotLeadBL.GetLoginTransferAgentsCount();
                    //if (dsTransfers.Tables[0].Rows[0]["CountAll"].ToString() == "0")
                    //{
                    //    lblTransferAgentsCount.Text = "Transfer agent(s) are not available";
                    //}
                    //else
                    //{
                    //    lblTransferAgentsCount.Text = dsTransfers.Tables[0].Rows[0]["CountAll"].ToString() + " Transfer agent(s) available";
                    //    //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "lll();", true);
                    //    DataSet dsTransferAgents = objHotLeadBL.GetAllLoginTransferAgentsDetails();
                    //    if (dsTransferAgents.Tables[0].Rows.Count > 0)
                    //    {
                    //        grdTest.DataSource = dsTransferAgents.Tables[0];
                    //        grdTest.DataBind();
                    //    }
                    //}
                    DataSet dsDatetime = objHotLeadBL.GetDatetime();
                    DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                    txtPaymentDate.Text = dtNow.ToString("MM/dd/yyyy");
                    DataSet dsCenterRoles = objHotLeadBL.GetCenterRolesByID(Convert.ToInt32(Session[Constants.CenterCodeID].ToString()));
                    Session["dsCenterRoles"] = dsCenterRoles;
                    if (dsCenterRoles.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsCenterRoles.Tables[0].Rows.Count; i++)
                        {
                            if (dsCenterRoles.Tables[0].Rows[i]["CenterRoleID"].ToString() == "1")
                            {
                                if (dsCenterRoles.Tables[0].Rows[i]["CenterRightStatus"].ToString() == "0")
                                {
                                    btnSale.Visible = false;
                                    btnSale2.Visible = false;
                                }
                                else
                                {
                                    btnSale.Visible = true;
                                    btnSale2.Visible = true;
                                }
                            }
                            if (dsCenterRoles.Tables[0].Rows[i]["CenterRoleID"].ToString() == "2")
                            {
                                if (dsCenterRoles.Tables[0].Rows[i]["CenterRightStatus"].ToString() == "0")
                                {
                                    btnTransfer.Visible = false;
                                    btnTransfer2.Visible = false;
                                    lblTransferAgentsCount.Visible = false;
                                }
                                else
                                {
                                    btnTransfer.Visible = true;
                                    btnTransfer2.Visible = true;
                                    lblTransferAgentsCount.Visible = true;
                                }
                            }
                        }
                    }
                    if ((Session["AbandonSalePostingID"] != null) && (Session["AbandonSalePostingID"].ToString() != ""))
                    {
                        int PostingID = Convert.ToInt32(Session["AbandonSalePostingID"].ToString());
                        DataSet Cardetais = objHotLeadBL.GetCarDetailsByPostingID(PostingID);

                        Double PackCost2 = new Double();
                        PackCost2 = Convert.ToDouble(Cardetais.Tables[0].Rows[0]["Price"].ToString());
                        string PackAmount2 = string.Format("{0:0.00}", PackCost2).ToString();
                        string PackName2 = Cardetais.Tables[0].Rows[0]["Description"].ToString();
                        ListItem listPack = new ListItem();
                        listPack.Value = Cardetais.Tables[0].Rows[0]["PackageID"].ToString();
                        listPack.Text = PackName2 + " ($" + PackAmount2 + ")";
                        ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(listPack);

                        ListItem liVer = new ListItem();
                        liVer.Text = Cardetais.Tables[0].Rows[0]["SaleVerifierName"].ToString();
                        liVer.Value = Cardetais.Tables[0].Rows[0]["SaleVerifierID"].ToString();
                        ddlVerifier.SelectedIndex = ddlVerifier.Items.IndexOf(liVer);

                        txtFirstName.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["sellerName"].ToString());
                        txtLastName.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["LastName"].ToString());
                        txtPhone.Text = objGeneralFunc.filPhnm(Cardetais.Tables[0].Rows[0]["PhoneNum"].ToString());
                        txtEmail.Text = Cardetais.Tables[0].Rows[0]["email"].ToString();
                        txtAddress.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["address1"].ToString());
                        txtCity.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["city"].ToString());
                        if (Cardetais.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                        {
                            chkbxEMailNA.Checked = true;
                        }
                        else
                        {
                            chkbxEMailNA.Checked = false;
                        }

                        ListItem listState = new ListItem();
                        listState.Value = Cardetais.Tables[0].Rows[0]["StateID"].ToString();
                        listState.Text = Cardetais.Tables[0].Rows[0]["state"].ToString();
                        ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(listState);
                        txtZip.Text = Cardetais.Tables[0].Rows[0]["zip"].ToString();

                        ListItem list2 = new ListItem();
                        list2.Value = Cardetais.Tables[0].Rows[0]["MakeID"].ToString();
                        list2.Text = Cardetais.Tables[0].Rows[0]["make"].ToString();
                        ddlMake.SelectedIndex = ddlMake.Items.IndexOf(list2);
                        GetModelsInfo();

                        ListItem list3 = new ListItem();
                        list3.Text = Cardetais.Tables[0].Rows[0]["model"].ToString();
                        list3.Value = Cardetais.Tables[0].Rows[0]["makeModelID"].ToString();
                        ddlModel.SelectedIndex = ddlModel.Items.IndexOf(list3);

                        ListItem list1 = new ListItem();
                        list1.Text = Cardetais.Tables[0].Rows[0]["yearOfMake"].ToString();
                        list1.Value = Cardetais.Tables[0].Rows[0]["yearOfMake"].ToString();
                        ddlYear.SelectedIndex = ddlYear.Items.IndexOf(list1);

                        ListItem listBody = new ListItem();
                        listBody.Value = Cardetais.Tables[0].Rows[0]["bodyTypeID"].ToString();
                        listBody.Text = Cardetais.Tables[0].Rows[0]["bodyType"].ToString();
                        ddlBodyStyle.SelectedIndex = ddlBodyStyle.Items.IndexOf(listBody);

                        if (Cardetais.Tables[0].Rows[0]["Carprice"].ToString() == "0.0000")
                        {
                            txtAskingPrice.Text = "";
                        }
                        else
                        {
                            txtAskingPrice.Text = string.Format("{0:0}", Convert.ToDouble(Cardetais.Tables[0].Rows[0]["Carprice"].ToString()));
                        }
                        if (txtAskingPrice.Text.Length > 6)
                        {
                            txtAskingPrice.Text = txtAskingPrice.Text.Substring(0, 6);
                        }

                        if (Cardetais.Tables[0].Rows[0]["mileage"].ToString() == "0.00")
                        {
                            txtMileage.Text = "";
                        }
                        else
                        {
                            txtMileage.Text = string.Format("{0:0}", Convert.ToDouble(Cardetais.Tables[0].Rows[0]["mileage"].ToString()));
                        }
                        if (txtMileage.Text.Length > 6)
                        {
                            txtMileage.Text = txtMileage.Text.Substring(0, 6);
                        }

                        string NumberOfCylinder = Cardetais.Tables[0].Rows[0]["numberOfCylinder"].ToString();
                        //if (NumberOfCylinder == "3 Cylinder")
                        //{
                        //    rdbtnCylinders1.Checked = true;
                        //    rdbtnCylinders7.Checked = false;
                        //}
                        //else if (NumberOfCylinder == "4 Cylinder")
                        //{
                        //    rdbtnCylinders2.Checked = true;
                        //    rdbtnCylinders7.Checked = false;
                        //}
                        //else if (NumberOfCylinder == "5 Cylinder")
                        //{
                        //    rdbtnCylinders3.Checked = true;
                        //    rdbtnCylinders7.Checked = false;
                        //}
                        //else if (NumberOfCylinder == "6 Cylinder")
                        //{
                        //    rdbtnCylinders4.Checked = true;
                        //    rdbtnCylinders7.Checked = false;
                        //}
                        //else if (NumberOfCylinder == "7 Cylinder")
                        //{
                        //    rdbtnCylinders5.Checked = true;
                        //    rdbtnCylinders7.Checked = false;
                        //}
                        //else if (NumberOfCylinder == "8 Cylinder")
                        //{
                        //    rdbtnCylinders6.Checked = true;
                        //    rdbtnCylinders7.Checked = false;
                        //}
                        //else
                        //{
                        //    rdbtnCylinders7.Checked = true;
                        //}

                        ListItem list7 = new ListItem();
                        list7.Value = Cardetais.Tables[0].Rows[0]["exteriorColor"].ToString();
                        list7.Text = Cardetais.Tables[0].Rows[0]["exteriorColor"].ToString();
                        ddlExteriorColor.SelectedIndex = ddlExteriorColor.Items.IndexOf(list7);


                        ListItem list8 = new ListItem();
                        list8.Text = Cardetais.Tables[0].Rows[0]["interiorColor"].ToString();
                        list8.Value = Cardetais.Tables[0].Rows[0]["interiorColor"].ToString();
                        ddlInteriorColor.SelectedIndex = ddlInteriorColor.Items.IndexOf(list8);

                        string Transmission = Cardetais.Tables[0].Rows[0]["Transmission"].ToString();
                        //if (Transmission == "Automatic")
                        //{
                        //    rdbtnTrans1.Checked = true;
                        //    rdbtnTrans4.Checked = false;
                        //}
                        //else if (Transmission == "Manual")
                        //{
                        //    rdbtnTrans2.Checked = true;
                        //    rdbtnTrans4.Checked = false;
                        //}
                        //else if (Transmission == "Tiptronic")
                        //{
                        //    rdbtnTrans3.Checked = true;
                        //    rdbtnTrans4.Checked = false;
                        //}
                        //else
                        //{
                        //    rdbtnTrans4.Checked = true;
                        //}
                        //string NumberOfDoors = Cardetais.Tables[0].Rows[0]["numberOfDoors"].ToString();
                        //if (NumberOfDoors == "Two Door")
                        //{
                        //    rdbtnDoor2.Checked = true;
                        //    rdbtnDoor6.Checked = false;
                        //}
                        //else if (NumberOfDoors == "Three Door")
                        //{
                        //    rdbtnDoor3.Checked = true;
                        //    rdbtnDoor6.Checked = false;
                        //}
                        //else if (NumberOfDoors == "Four Door")
                        //{
                        //    rdbtnDoor4.Checked = true;
                        //    rdbtnDoor6.Checked = false;
                        //}

                        //else if (NumberOfDoors == "Five Door")
                        //{
                        //    rdbtnDoor5.Checked = true;
                        //    rdbtnDoor6.Checked = false;
                        //}
                        //else
                        //{
                        //    rdbtnDoor6.Checked = true;
                        //}

                        string DriveTrain = Cardetais.Tables[0].Rows[0]["DriveTrain"].ToString();
                        //if (DriveTrain == "2 wheel drive")
                        //{
                        //    rdbtnDriveTrain1.Checked = true;
                        //    rdbtnDriveTrain5.Checked = false;
                        //}
                        //else if (DriveTrain == "2 wheel drive - front")
                        //{
                        //    rdbtnDriveTrain2.Checked = true;
                        //    rdbtnDriveTrain5.Checked = false;
                        //}
                        //else if (DriveTrain == "All wheel drive")
                        //{
                        //    rdbtnDriveTrain3.Checked = true;
                        //    rdbtnDriveTrain5.Checked = false;
                        //}
                        //else if (DriveTrain == "Rear wheel drive")
                        //{
                        //    rdbtnDriveTrain4.Checked = true;
                        //    rdbtnDriveTrain5.Checked = false;
                        //}
                        //else
                        //{
                        //    rdbtnDriveTrain5.Checked = true;
                        //}
                        txtVin.Text = Cardetais.Tables[0].Rows[0]["VIN"].ToString();

                        int FuelTypeID = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["fuelTypeID"].ToString());
                        //if (FuelTypeID == 1)
                        //{
                        //    rdbtnFuelType1.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else if (FuelTypeID == 2)
                        //{
                        //    rdbtnFuelType2.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else if (FuelTypeID == 3)
                        //{
                        //    rdbtnFuelType3.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else if (FuelTypeID == 4)
                        //{
                        //    rdbtnFuelType4.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else if (FuelTypeID == 5)
                        //{
                        //    rdbtnFuelType5.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else if (FuelTypeID == 6)
                        //{
                        //    rdbtnFuelType6.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else if (FuelTypeID == 7)
                        //{
                        //    rdbtnFuelType7.Checked = true;
                        //    rdbtnFuelType8.Checked = false;
                        //}
                        //else
                        //{
                        //    rdbtnFuelType8.Checked = true;
                        //}
                        int ConditionID = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["vehicleConditionID"].ToString());
                        //if (ConditionID == 1)
                        //{
                        //    rdbtnCondition1.Checked = true;
                        //    rdbtnCondition7.Checked = false;
                        //}
                        //else if (ConditionID == 2)
                        //{
                        //    rdbtnCondition2.Checked = true;
                        //    rdbtnCondition7.Checked = false;
                        //}
                        //else if (ConditionID == 3)
                        //{
                        //    rdbtnCondition3.Checked = true;
                        //    rdbtnCondition7.Checked = false;
                        //}
                        //else if (ConditionID == 4)
                        //{
                        //    rdbtnCondition4.Checked = true;
                        //    rdbtnCondition7.Checked = false;
                        //}
                        //else if (ConditionID == 5)
                        //{
                        //    rdbtnCondition5.Checked = true;
                        //    rdbtnCondition7.Checked = false;
                        //}
                        //else if (ConditionID == 6)
                        //{
                        //    rdbtnCondition6.Checked = true;
                        //    rdbtnCondition7.Checked = false;
                        //}
                        //else
                        //{
                        //    rdbtnCondition7.Checked = true;
                        //}


                        for (int i = 1; i < 54; i++)
                        {
                            if (i != 10)
                            {
                                if (i != 37)
                                {
                                    if (i != 38)
                                    {
                                        string ChkBoxID = "chkFeatures" + i.ToString();
                                        CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                                        if (Cardetais.Tables[1].Rows.Count >= i)
                                        {
                                            if (Cardetais.Tables[1].Rows[i - 1]["Isactive"].ToString() == "True")
                                            {
                                                ChkedBox.Checked = true;
                                            }
                                            else
                                            {
                                                ChkedBox.Checked = false;
                                            }
                                        }
                                        else
                                        {
                                            ChkedBox.Checked = false;
                                        }
                                    }
                                }
                            }
                        }
                        if (Cardetais.Tables[1].Rows.Count > 9)
                        {
                            if (Cardetais.Tables[1].Rows[9]["Isactive"].ToString() == "True")
                            {
                                rdbtnLeather.Checked = true;
                                rdbtnInteriorNA.Checked = false;
                            }
                        }
                        if (Cardetais.Tables[1].Rows.Count > 36)
                        {
                            if (Cardetais.Tables[1].Rows[36]["Isactive"].ToString() == "True")
                            {
                                rdbtnVinyl.Checked = true;
                                rdbtnInteriorNA.Checked = false;
                            }
                        }
                        if (Cardetais.Tables[1].Rows.Count > 37)
                        {
                            if (Cardetais.Tables[1].Rows[37]["Isactive"].ToString() == "True")
                            {
                                rdbtnCloth.Checked = true;
                                rdbtnInteriorNA.Checked = false;
                            }
                        }
                        if (Cardetais.Tables[1].Rows.Count > 53)
                        {
                            if (Cardetais.Tables[1].Rows[53]["Isactive"].ToString() == "True")
                            {
                                rdbtnInteriorNA.Checked = true;
                            }
                        }
                        txtDescription.Text = Cardetais.Tables[0].Rows[0]["Cardescription"].ToString();
                        string OldNotes = Cardetais.Tables[0].Rows[0]["SaleNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        txtSaleNotes.Text = OldNotes;

                        ListItem liSourceofPhotos = new ListItem();
                        liSourceofPhotos.Text = Cardetais.Tables[0].Rows[0]["SourceOfPhotosName"].ToString();
                        liSourceofPhotos.Value = Cardetais.Tables[0].Rows[0]["SourceOfPhotosID"].ToString();
                        ddlPhotosSource.SelectedIndex = ddlPhotosSource.Items.IndexOf(liSourceofPhotos);

                        ListItem liVoiceLocation = new ListItem();
                        liVoiceLocation.Text = Cardetais.Tables[0].Rows[0]["VoiceFileLocationName"].ToString();
                        liVoiceLocation.Value = Cardetais.Tables[0].Rows[0]["VoiceFileLocation"].ToString();
                        ddlVoiceFileLocation.SelectedIndex = ddlVoiceFileLocation.Items.IndexOf(liVoiceLocation);

                        ListItem liSourceofDescription = new ListItem();
                        liSourceofDescription.Text = Cardetais.Tables[0].Rows[0]["SourceOfDescriptionName"].ToString();
                        liSourceofDescription.Value = Cardetais.Tables[0].Rows[0]["SourceOfDescriptionID"].ToString();
                        ddlDescriptionSource.SelectedIndex = ddlDescriptionSource.Items.IndexOf(liSourceofDescription);


                        Session["NewSaleCarID"] = Cardetais.Tables[0].Rows[0]["carid"].ToString();
                        Session["NewSaleUID"] = Cardetais.Tables[0].Rows[0]["uid"].ToString();
                        Session["NewSalePostingID"] = Cardetais.Tables[0].Rows[0]["postingID"].ToString();
                        Session["NewSaleUserPackID"] = Cardetais.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["NewSaleSellerID"] = Cardetais.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["NewSalePSID1"] = Cardetais.Tables[0].Rows[0]["PSID1"].ToString();
                        if (Cardetais.Tables[0].Rows[0]["PSID2"].ToString() != "")
                        {
                            Session["NewSalePSID2"] = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PSID2"].ToString());
                        }
                        if (Cardetais.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                        {
                            Session["NewSalePaymentID"] = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PaymentID"].ToString());
                        }

                    }
                    else
                    {
                        MPEUpdate.Show();
                    }
                }
            }
        }
    }

    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            int LeadStatus = Convert.ToInt32(4);
            string SellerPhone = txtPhone.Text;
            SellerPhone = SellerPhone.Replace("-", "");
            SellerPhone = SellerPhone.Replace("-", "");
            DataSet dsReturnExists = objHotLeadBL.ChkUserPhoneNumberExistsForReturned(SellerPhone);
            if (dsReturnExists.Tables[0].Rows.Count > 0)
            {
                Session["NewSaleCarID"] = dsReturnExists.Tables[0].Rows[0]["carid"].ToString();
                Session["NewSaleUID"] = dsReturnExists.Tables[0].Rows[0]["uid"].ToString();
                Session["NewSalePostingID"] = dsReturnExists.Tables[0].Rows[0]["postingID"].ToString();
                Session["NewSaleUserPackID"] = dsReturnExists.Tables[0].Rows[0]["UserPackID"].ToString();
                Session["NewSaleSellerID"] = dsReturnExists.Tables[0].Rows[0]["sellerID"].ToString();
                Session["NewSalePSID1"] = dsReturnExists.Tables[0].Rows[0]["PSID1"].ToString();
                if (dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                {
                    Session["NewSalePSID2"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString());
                }
                if (dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                {
                    Session["NewSalePaymentID"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString());
                }
                int SaleAgentID = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                SaveInfo(LeadStatus, SaleAgentID);
                Session["AbandonSalePostingID"] = null;
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = "The previous record is being updated and successfully saved with sale id " + Session["NewSaleCarID"].ToString();
            }
            else
            {
                DataSet dsUserExists = objHotLeadBL.ChkUserPhoneNumberExistsForSale(SellerPhone);
                if (dsUserExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Phone " + txtPhone.Text + " already exists.<br />Please change phone # to transfer";
                }
                else
                {
                    DataSet dsUserDraftExists = objHotLeadBL.ChkUserPhoneNumberExists(SellerPhone);
                    if (dsUserDraftExists.Tables[0].Rows.Count > 0)
                    {
                        Session["NewSaleCarID"] = dsUserDraftExists.Tables[0].Rows[0]["carid"].ToString();
                        Session["NewSaleUID"] = dsUserDraftExists.Tables[0].Rows[0]["uid"].ToString();
                        Session["NewSalePostingID"] = dsUserDraftExists.Tables[0].Rows[0]["postingID"].ToString();
                        Session["NewSaleUserPackID"] = dsUserDraftExists.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["NewSaleSellerID"] = dsUserDraftExists.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["NewSalePSID1"] = dsUserDraftExists.Tables[0].Rows[0]["PSID1"].ToString();
                        if (dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                        {
                            Session["NewSalePSID2"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString());
                        }
                        if (dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                        {
                            Session["NewSalePaymentID"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString());
                        }
                        int SaleAgentID = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        SaveInfo(LeadStatus, SaleAgentID);
                        Session["AbandonSalePostingID"] = null;
                        mpealteruserUpdated.Show();
                        lblErrUpdated.Visible = true;
                        lblErrUpdated.Text = "The previous record is being updated and successfully saved with sale id " + Session["NewSaleCarID"].ToString();
                    }
                    else
                    {
                        int SaleAgentID = 0;
                        SaveInfo(LeadStatus, SaleAgentID);
                        Session["AbandonSalePostingID"] = null;
                        Response.Redirect("NewSale.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void BtnClsUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            Session["AbandonSalePostingID"] = null;
            Response.Redirect("NewSale.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSale_Click(object sender, EventArgs e)
    {
        try
        {
            int LeadStatus = Convert.ToInt32(1);
            string SellerPhone = txtPhone.Text;
            SellerPhone = SellerPhone.Replace("-", "");
            SellerPhone = SellerPhone.Replace("-", "");
            DataSet dsReturnExists = objHotLeadBL.ChkUserPhoneNumberExistsForReturned(SellerPhone);
            if (dsReturnExists.Tables[0].Rows.Count > 0)
            {
                Session["NewSaleCarID"] = dsReturnExists.Tables[0].Rows[0]["carid"].ToString();
                Session["NewSaleUID"] = dsReturnExists.Tables[0].Rows[0]["uid"].ToString();
                Session["NewSalePostingID"] = dsReturnExists.Tables[0].Rows[0]["postingID"].ToString();
                Session["NewSaleUserPackID"] = dsReturnExists.Tables[0].Rows[0]["UserPackID"].ToString();
                Session["NewSaleSellerID"] = dsReturnExists.Tables[0].Rows[0]["sellerID"].ToString();
                Session["NewSalePSID1"] = dsReturnExists.Tables[0].Rows[0]["PSID1"].ToString();
                if (dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                {
                    Session["NewSalePSID2"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString());
                }
                if (dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                {
                    Session["NewSalePaymentID"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString());
                }
                int SaleAgentID = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                SaveInfo(LeadStatus, SaleAgentID);
                Session["AbandonSalePostingID"] = null;
                //mpealteruserUpdated.Show();
                //lblErrUpdated.Visible = true;
                //lblErrUpdated.Text = "The previous record is being updated and successfully saved with sale id " + Session["NewSaleCarID"].ToString();
                mdepAlertAfterSave.Show();
                lblAlertAfterSave.Visible = true;
                lblAlertAfterSave.Text = "The previous record is being updated and successfully saved with sale id " + Session["NewSaleCarID"].ToString() + "<br />Do you want to add another car for this customer?";
            }
            else
            {
                DataSet dsUserExists = objHotLeadBL.ChkUserPhoneNumberExistsForSale(SellerPhone);
                if (dsUserExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Phone " + txtPhone.Text + " already exists.<br />Please change phone # to save";
                }
                else
                {
                    DataSet dsUserDraftExists = objHotLeadBL.ChkUserPhoneNumberExists(SellerPhone);
                    if (dsUserDraftExists.Tables[0].Rows.Count > 0)
                    {
                        Session["NewSaleCarID"] = dsUserDraftExists.Tables[0].Rows[0]["carid"].ToString();
                        Session["NewSaleUID"] = dsUserDraftExists.Tables[0].Rows[0]["uid"].ToString();
                        Session["NewSalePostingID"] = dsUserDraftExists.Tables[0].Rows[0]["postingID"].ToString();
                        Session["NewSaleUserPackID"] = dsUserDraftExists.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["NewSaleSellerID"] = dsUserDraftExists.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["NewSalePSID1"] = dsUserDraftExists.Tables[0].Rows[0]["PSID1"].ToString();
                        if (dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                        {
                            Session["NewSalePSID2"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString());
                        }
                        if (dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                        {
                            Session["NewSalePaymentID"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString());
                        }
                        int SaleAgentID = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        SaveInfo(LeadStatus, SaleAgentID);
                        Session["AbandonSalePostingID"] = null;
                        //mpealteruserUpdated.Show();
                        //lblErrUpdated.Visible = true;
                        //lblErrUpdated.Text = "The previous record is being updated and successfully saved with sale id " + Session["NewSaleCarID"].ToString();
                        mdepAlertAfterSave.Show();
                        lblAlertAfterSave.Visible = true;
                        lblAlertAfterSave.Text = "The previous record is being updated and successfully saved with sale id " + Session["NewSaleCarID"].ToString() + "<br />Do you want to add another car for this customer?";
                    }
                    else
                    {
                        int SaleAgentID = 0;
                        SaveInfo(LeadStatus, SaleAgentID);
                        Session["AbandonSalePostingID"] = null;
                        //mpealteruserUpdated.Show();
                        //lblErrUpdated.Visible = true;
                        //lblErrUpdated.Text = "Customer details saved successfully with sale id " + Session["NewSaleCarID"].ToString();
                        mdepAlertAfterSave.Show();
                        lblAlertAfterSave.Visible = true;
                        lblAlertAfterSave.Text = "Customer details saved successfully with sale id " + Session["NewSaleCarID"].ToString() + "<br />Do you want to add another car for this customer?";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAbandon_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPhone.Text != "")
            {
                int LeadStatus = Convert.ToInt32(2);
                string SellerPhone = txtPhone.Text;
                SellerPhone = SellerPhone.Replace("-", "");
                SellerPhone = SellerPhone.Replace("-", "");
                DataSet dsReturnExists = objHotLeadBL.ChkUserPhoneNumberExistsForReturned(SellerPhone);
                if (dsReturnExists.Tables[0].Rows.Count > 0)
                {
                    Session["NewSaleCarID"] = dsReturnExists.Tables[0].Rows[0]["carid"].ToString();
                    Session["NewSaleUID"] = dsReturnExists.Tables[0].Rows[0]["uid"].ToString();
                    Session["NewSalePostingID"] = dsReturnExists.Tables[0].Rows[0]["postingID"].ToString();
                    Session["NewSaleUserPackID"] = dsReturnExists.Tables[0].Rows[0]["UserPackID"].ToString();
                    Session["NewSaleSellerID"] = dsReturnExists.Tables[0].Rows[0]["sellerID"].ToString();
                    Session["NewSalePSID1"] = dsReturnExists.Tables[0].Rows[0]["PSID1"].ToString();
                    if (dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                    {
                        Session["NewSalePSID2"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString());
                    }
                    if (dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                    {
                        Session["NewSalePaymentID"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString());
                    }
                    int SaleAgentID = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                    SaveInfo(LeadStatus, SaleAgentID);
                    Session["AbandonSalePostingID"] = null;
                    Response.Redirect("NewSale.aspx");
                }
                else
                {
                    DataSet dsUserExists = objHotLeadBL.ChkUserPhoneNumberExistsForSale(SellerPhone);
                    if (dsUserExists.Tables[0].Rows.Count > 0)
                    {
                        Session["AbandonSalePostingID"] = null;
                        Response.Redirect("NewSale.aspx");
                    }
                    else
                    {
                        DataSet dsUserDraftExists = objHotLeadBL.ChkUserPhoneNumberExists(SellerPhone);
                        if (dsUserDraftExists.Tables[0].Rows.Count > 0)
                        {
                            Session["NewSaleCarID"] = dsUserDraftExists.Tables[0].Rows[0]["carid"].ToString();
                            Session["NewSaleUID"] = dsUserDraftExists.Tables[0].Rows[0]["uid"].ToString();
                            Session["NewSalePostingID"] = dsUserDraftExists.Tables[0].Rows[0]["postingID"].ToString();
                            Session["NewSaleUserPackID"] = dsUserDraftExists.Tables[0].Rows[0]["UserPackID"].ToString();
                            Session["NewSaleSellerID"] = dsUserDraftExists.Tables[0].Rows[0]["sellerID"].ToString();
                            Session["NewSalePSID1"] = dsUserDraftExists.Tables[0].Rows[0]["PSID1"].ToString();
                            if (dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                            {
                                Session["NewSalePSID2"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString());
                            }
                            if (dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                            {
                                Session["NewSalePaymentID"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString());
                            }
                            int SaleAgentID = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                            SaveInfo(LeadStatus, SaleAgentID);
                            Session["AbandonSalePostingID"] = null;
                            Response.Redirect("NewSale.aspx");
                        }
                        else
                        {
                            int SaleAgentID = 0;
                            SaveInfo(LeadStatus, SaleAgentID);
                            Session["AbandonSalePostingID"] = null;
                            Response.Redirect("NewSale.aspx");
                        }
                    }
                }
            }
            else
            {
                Session["AbandonSalePostingID"] = null;
                Response.Redirect("NewSale.aspx");
            }
            //mpealteruserUpdated.Show();
            //Response.Redirect("NewSale.aspx");
            //lblErrUpdated.Visible = true;
            //lblErrUpdated.Text = "Customer details saved successfully";

            // }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSavedraft_Click(object sender, EventArgs e)
    {
        try
        {
            int LeadStatus = Convert.ToInt32(3);
            string SellerPhone = txtPhone.Text;
            SellerPhone = SellerPhone.Replace("-", "");
            SellerPhone = SellerPhone.Replace("-", "");
            DataSet dsReturnExists = objHotLeadBL.ChkUserPhoneNumberExistsForReturned(SellerPhone);
            if (dsReturnExists.Tables[0].Rows.Count > 0)
            {
                Session["NewSaleCarID"] = dsReturnExists.Tables[0].Rows[0]["carid"].ToString();
                Session["NewSaleUID"] = dsReturnExists.Tables[0].Rows[0]["uid"].ToString();
                Session["NewSalePostingID"] = dsReturnExists.Tables[0].Rows[0]["postingID"].ToString();
                Session["NewSaleUserPackID"] = dsReturnExists.Tables[0].Rows[0]["UserPackID"].ToString();
                Session["NewSaleSellerID"] = dsReturnExists.Tables[0].Rows[0]["sellerID"].ToString();
                Session["NewSalePSID1"] = dsReturnExists.Tables[0].Rows[0]["PSID1"].ToString();
                if (dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                {
                    Session["NewSalePSID2"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PSID2"].ToString());
                }
                if (dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                {
                    Session["NewSalePaymentID"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["PaymentID"].ToString());
                }
                int SaleAgentID = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                SaveInfo(LeadStatus, SaleAgentID);
                Session["AbandonSalePostingID"] = null;
            }
            else
            {
                DataSet dsUserExists = objHotLeadBL.ChkUserPhoneNumberExistsForSale(SellerPhone);
                if (dsUserExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Phone " + txtPhone.Text + " already exists.<br />Please change phone # to save";
                }
                else
                {
                    DataSet dsUserDraftExists = objHotLeadBL.ChkUserPhoneNumberExists(SellerPhone);
                    if (dsUserDraftExists.Tables[0].Rows.Count > 0)
                    {
                        Session["NewSaleCarID"] = dsUserDraftExists.Tables[0].Rows[0]["carid"].ToString();
                        Session["NewSaleUID"] = dsUserDraftExists.Tables[0].Rows[0]["uid"].ToString();
                        Session["NewSalePostingID"] = dsUserDraftExists.Tables[0].Rows[0]["postingID"].ToString();
                        Session["NewSaleUserPackID"] = dsUserDraftExists.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["NewSaleSellerID"] = dsUserDraftExists.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["NewSalePSID1"] = dsUserDraftExists.Tables[0].Rows[0]["PSID1"].ToString();
                        if (dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString() != "")
                        {
                            Session["NewSalePSID2"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PSID2"].ToString());
                        }
                        if (dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString() != "")
                        {
                            Session["NewSalePaymentID"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["PaymentID"].ToString());
                        }
                        int SaleAgentID = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        SaveInfo(LeadStatus, SaleAgentID);
                        Session["AbandonSalePostingID"] = null;
                    }
                    else
                    {
                        int SaleAgentID = 0;
                        SaveInfo(LeadStatus, SaleAgentID);
                        Session["AbandonSalePostingID"] = null;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetModelsInfo();
            Session.Timeout = 180;
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

    private void FillPackage()
    {
        try
        {
            for (int i = 1; i < dsDropDown.Tables[2].Rows.Count; i++)
            {
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsDropDown.Tables[2].Rows[i]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = dsDropDown.Tables[2].Rows[i]["Description"].ToString();
                ListItem list = new ListItem();
                list.Text = PackName + " ($" + PackAmount + ")";
                list.Value = dsDropDown.Tables[2].Rows[i]["PackageID"].ToString();
                ddlPackage.Items.Add(list);
            }
            ddlPackage.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillDiscounts()
    {
        try
        {
            DataSet dsDropDown1 = objdropdownBL.GetDiscountpacka();
            for (int i = 1; i < dsDropDown1.Tables[0].Rows.Count; i++)
            {
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsDropDown1.Tables[0].Rows[i]["DiscountAmount"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = dsDropDown1.Tables[0].Rows[i]["DiscountType"].ToString().Trim();
                ListItem list = new ListItem();
                if (PackName == "Mobile Appdown Discount")
                    PackName = "Mobile Appdown Discount (25$)";
                list.Text = PackName;// +"($" + PackAmount + ")";

                list.Value = dsDropDown1.Tables[0].Rows[i]["DisCountTypeId"].ToString();
                ddlDiscount.Items.Add(list);
            }
            ddlDiscount.Items.Insert(0, new ListItem("Zero", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private void GetAllModels()
    {
        try
        {
            DataSet dsAllModels = new DataSet();

            if (Session[Constants.AllModel] == null)
            {

                dsAllModels = objdropdownBL.USP_GetAllModels(0);
                Session[Constants.AllModel] = dsAllModels;
            }
            else
            {
                dsAllModels = (DataSet)Session[Constants.AllModel];
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void GetMakes()
    {
        try
        {
            var obj = new List<MakesInfo>();


            MakesBL objMakesBL = new MakesBL();

            if (Session[Constants.Makes] == null)
            {
                obj = (List<MakesInfo>)objMakesBL.GetMakes();
                Session[Constants.Makes] = obj;
            }
            else
            {
                obj = (List<MakesInfo>)Session[Constants.Makes];
            }
            ddlMake.DataSource = obj;
            ddlMake.DataTextField = "Make";
            ddlMake.DataValueField = "MakeID";
            ddlMake.DataBind();
            ddlMake.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void GetModelsInfo()
    {
        try
        {
            //var objModel = new List<MakesInfo>();
            //objModel = Session["AllModel"] as List<MakesInfo>;
            DataSet dsModels = Session[Constants.AllModel] as DataSet;
            int makeid = Convert.ToInt32(ddlMake.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsModels.Tables[0].DefaultView;
            dvModel.RowFilter = "MakeID='" + makeid.ToString() + "'";
            dtModel = dvModel.ToTable();
            ddlModel.DataSource = dtModel;
            ddlModel.Items.Clear();
            ddlModel.DataTextField = "Model";
            ddlModel.DataValueField = "MakeModelID";
            ddlModel.DataBind();
            ddlModel.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillInteriorColor()
    {
        try
        {
            ddlInteriorColor.DataSource = dsDropDown.Tables[4];
            ddlInteriorColor.DataTextField = "InteriorColorName";
            ddlInteriorColor.DataValueField = "InteriorColorName";
            ddlInteriorColor.DataBind();
            ddlInteriorColor.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillExteriorColor()
    {
        try
        {
            ddlExteriorColor.DataSource = dsDropDown.Tables[3];
            ddlExteriorColor.DataTextField = "ExteriorColorName";
            ddlExteriorColor.DataValueField = "ExteriorColorName";
            ddlExteriorColor.DataBind();
            ddlExteriorColor.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }

    public void GetBody()
    {
        try
        {
            var obj = new List<BodyInfo>();

            //MakesInfo objMakes = new MakesInfo();
            MakesBL objMakesBL = new MakesBL();

            if (Session[Constants.Bodys] == null)
            {
                obj = (List<BodyInfo>)objMakesBL.GetBodys();
                Session["Bodys"] = obj;
            }
            else
            {
                obj = (List<BodyInfo>)Session[Constants.Bodys];
            }


            ddlBodyStyle.DataSource = obj;
            ddlBodyStyle.DataTextField = "bodyType";
            ddlBodyStyle.DataValueField = "bodyTypeID";
            ddlBodyStyle.DataBind();
            ddlBodyStyle.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    ////private void FillCylinders()
    ////{
    ////    try
    ////    {
    ////        ddlCylinderCount.DataSource = dsDropDown.Tables[5];
    ////        ddlCylinderCount.DataTextField = "CylindersName";
    ////        ddlCylinderCount.DataValueField = "CylindersName";
    ////        ddlCylinderCount.DataBind();
    ////        ddlCylinderCount.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////    }
    ////}
    private void FillPDDate()
    {
        try
        {
            DataSet dsDatetime = objHotLeadBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            ddlPDDate.Items.Clear();
            for (int i = 0; i < 21; i++)
            {
                ListItem list = new ListItem();
                list.Text = dtNow.AddDays(i).ToString("MM/dd/yyyy");
                list.Value = dtNow.AddDays(i).ToString("MM/dd/yyyy");
                ddlPDDate.Items.Add(list);
            }
            ddlPDDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillPaymentDate()
    {
        try
        {
            //ddlPaymentdate.Items.Clear();
            //for (int i = 0; i < 7; i++)
            //{
            //    ListItem list = new ListItem();
            //    list.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
            //    list.Value = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
            //    ddlPaymentdate.Items.Add(list);
            //}
            //ddlPaymentdate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void fillYears(DataSet dsYears)
    {
        try
        {
            CCExpiresYear.Items.Clear();
            CCExpiresYear.DataSource = dsYears.Tables[0];
            CCExpiresYear.DataTextField = "YearNum";
            CCExpiresYear.DataValueField = "YearValue";
            CCExpiresYear.DataBind();
            CCExpiresYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillStates()
    {
        try
        {
            ddlLocationState.DataSource = dsDropDown.Tables[1];
            ddlLocationState.DataTextField = "State_Code";
            ddlLocationState.DataValueField = "State_ID";
            ddlLocationState.DataBind();
            ddlLocationState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillBillingStates()
    {
        try
        {
            ddlbillingstate.Items.Clear();
            if (Session["DsDropDown"] == null)
            {
                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                Session["DsDropDown"] = dsDropDown;
            }
            else
            {
                dsDropDown = (DataSet)Session["DsDropDown"];
            }

            ddlbillingstate.DataSource = dsDropDown.Tables[1];
            ddlbillingstate.DataTextField = "State_Code";
            ddlbillingstate.DataValueField = "State_ID";
            ddlbillingstate.DataBind();
            ddlbillingstate.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    //private void FillCheckTypes()
    //{
    //    try
    //    {
    //        DataSet dsCheckTypes = new DataSet();
    //        dsCheckTypes = objHotLeadBL.GetAllCheckTypes();
    //        ddlCheckType.DataSource = dsCheckTypes.Tables[0];
    //        ddlCheckType.DataTextField = "CheckTypeName";
    //        ddlCheckType.DataValueField = "CheckTypeID";
    //        ddlCheckType.DataBind();
    //        ddlCheckType.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    private void FillYear()
    {
        try
        {
            DataSet dsYears = new DataSet();
            if (Session["CarsYears"] == null)
            {
                dsYears = objHotLeadBL.GetYears();
                Session["CarsYears"] = dsYears;
            }
            else
            {
                dsYears = Session["CarsYears"] as DataSet;
            }
            ddlYear.DataSource = dsYears.Tables[0];
            ddlYear.DataTextField = "Year";
            ddlYear.DataValueField = "Year";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillAgents()
    {
        try
        {
            DataSet dsverifier = objHotLeadBL.GetAgentsForAgents(Convert.ToInt32(Session[Constants.CenterCodeID].ToString()));
            ddlSaleAgent.Items.Clear();
            ddlSaleAgent.DataSource = dsverifier;
            ddlSaleAgent.DataTextField = "AgentUFirstName";
            ddlSaleAgent.DataValueField = "AgentUID";
            ddlSaleAgent.DataBind();
            ListItem li = new ListItem();
            li.Text = Session[Constants.NAME].ToString();
            li.Value = Session[Constants.USER_ID].ToString();
            ddlSaleAgent.SelectedIndex = ddlSaleAgent.Items.IndexOf(li);
            ddlSaleAgent.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillVerifier()
    {
        try
        {
           DataSet dsverifier = objHotLeadBL.GetAgentsForVerifier(Convert.ToInt32(Session[Constants.CenterCodeID].ToString()));
            ddlVerifier.Items.Clear();
            ddlVerifier.DataSource = dsverifier;
            ddlVerifier.DataTextField = "AgentUFirstName";
            ddlVerifier.DataValueField = "AgentUID";
            ddlVerifier.DataBind();
            ListItem li = new ListItem();
            li.Text = Session[Constants.NAME].ToString();
            li.Value = Session[Constants.USER_ID].ToString();
            ddlVerifier.SelectedIndex = ddlVerifier.Items.IndexOf(li);
            ddlVerifier.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void FillDescriptionSource()
    {
        try
        {
            DataSet dsDescripSource = objHotLeadBL.GetMasterSourceOfDescription();
            ddlDescriptionSource.DataSource = dsDescripSource.Tables[0];
            ddlDescriptionSource.DataTextField = "SourceOfDescriptionName";
            ddlDescriptionSource.DataValueField = "SourceOfDescriptionID";
            ddlDescriptionSource.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillPhotoSource()
    {
        try
        {
            DataSet dsDescripPhotos = objHotLeadBL.USP_GetMasterSourceOfPhotos();
            ddlPhotosSource.DataSource = dsDescripPhotos.Tables[0];
            ddlPhotosSource.DataTextField = "SourceOfPhotosName";
            ddlPhotosSource.DataValueField = "SourceOfPhotosID";
            ddlPhotosSource.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillVoiceFileLocation()
    {
        try
        {
            DataSet dsVoiceFileLocation = objCentralDBBL.GetVoiceFileLocation();
            ddlVoiceFileLocation.DataSource = dsVoiceFileLocation.Tables[0];
            ddlVoiceFileLocation.DataTextField = "VoiceFileLocationName";
            ddlVoiceFileLocation.DataValueField = "VoiceFileLocationID";
            ddlVoiceFileLocation.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayVisa_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                // divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            CardType.Value = "VisaCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objHotLeadBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            //txtBillingname.Text = "";
            //txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();
            btnProcess.Visible = true;
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayMasterCard_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                // divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            CardType.Value = "MasterCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objHotLeadBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            // txtBillingname.Text = "";
            // txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();
            btnProcess.Visible = true;
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayDiscover_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                //divpdDate.Style["display"] = "block";
            }
            else
            {
                //divpdDate.Style["display"] = "none";
            }
            CardType.Value = "DiscoverCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objHotLeadBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            //txtBillingname.Text = "";
            //  txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();
            btnProcess.Visible = true;
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayAmex_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                //divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            CardType.Value = "AmExCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objHotLeadBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            //txtBillingname.Text = "";
            //txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();
            btnProcess.Visible = true;
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayPaypal_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "none";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "block";
            if (chkboxlstPDsale.Checked == true)
            {
                // divpdDate.Style["display"] = "block";
            }
            else
            {
                //divpdDate.Style["display"] = "none";
            }
            //FillPaymentDate();
            txtPaytransID.Text = "";
            //txtPayAmount.Text = "";
            txtpayPalEmailAccount.Text = "";
            btnProcess.Visible = true;
            chkboxlstPDsale.Enabled = false;
            ddlPDDate.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayCheck_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "none";
            divcheck.Style["display"] = "block";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                //divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            txtBankNameForCheck.Text = "";
            ListItem liAccType = new ListItem();
            liAccType.Text = "Select";
            liAccType.Value = "0";
            ddlAccType.SelectedIndex = ddlAccType.Items.IndexOf(liAccType);
            ListItem liCheckType = new ListItem();
            liCheckType.Text = "Select";
            liCheckType.Value = "0";
            //ddlCheckType.SelectedIndex = ddlCheckType.Items.IndexOf(liCheckType);
            //txtCheckNumber.Text = "";
            txtCustNameForCheck.Text = "";
            txtAccNumberForCheck.Text = "";
            txtRoutingNumberForCheck.Text = "";
            btnProcess.Visible = true;
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void chkboxlstPDsale_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            //if (chkboxlstPDsale.Checked == true)
            //{
            //    divpdDate.Style["display"] = "block";
            //    FillPDDate();
            //    txtPDAmountNow.Text = "";
            //    txtPDAmountLater.Text = "";
            //    btnProcess.Visible = true;
            //}
            //else
            //{
            //    divpdDate.Style["display"] = "none";
            //    btnProcess.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnPhoneOk_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsUserExists = objHotLeadBL.ChkUserPhoneNumberExistsForSale(txtLoadPhone.Text.Trim());
            if (dsUserExists.Tables[0].Rows.Count > 0)
            {
                string SaleID = dsUserExists.Tables[0].Rows[0]["carid"].ToString();
                string CustName = dsUserExists.Tables[0].Rows[0]["Name"].ToString();
                DateTime AddDate = Convert.ToDateTime(dsUserExists.Tables[0].Rows[0]["CreatedDate"].ToString());
                string SaleAgent = dsUserExists.Tables[0].Rows[0]["SaleAgent"].ToString();
                string SaleVerifier = dsUserExists.Tables[0].Rows[0]["SaleVerifierName"].ToString();
                Session["AddAnotherCarSaleUID"] = dsUserExists.Tables[0].Rows[0]["uid"].ToString();
                MPEUpdate.Hide();
                MdepAddAnotherCarAlert.Show();
                lblAddAnotherCarAlertError.Visible = true;
                if (dsUserExists.Tables[0].Rows.Count > 1)
                {
                    lblAddAnotherCarAlertError.Text = "Oops!<br />" + dsUserExists.Tables[0].Rows.Count.ToString() + " Vehicles(s) already exist with this phone # <br />Phone:" + txtLoadPhone.Text.Trim() + "<br />Cust name:" + CustName + "<br />Add date:" + AddDate.ToString("MM/dd/yyyy") + "<br />Agent:" + SaleAgent + "<br />Verifier:" + SaleVerifier + "<br />Do you want to add another car?";
                }
                else
                {
                    lblAddAnotherCarAlertError.Text = "Oops!<br />Record exists for this phone # <br />Phone:" + txtLoadPhone.Text.Trim() + "<br />Cust name:" + CustName + "<br />Add date:" + AddDate.ToString("MM/dd/yyyy") + "<br />Agent:" + SaleAgent + "<br />Verifier:" + SaleVerifier + "<br />Do you want to add another car?";
                }
            }
            else
            {
                DataSet dsReturnExists = objHotLeadBL.ChkUserPhoneNumberExistsForReturned(txtLoadPhone.Text.Trim());
                if (dsReturnExists.Tables[0].Rows.Count > 0)
                {
                    Session["AbandonSalePostingID"] = Convert.ToInt32(dsReturnExists.Tables[0].Rows[0]["postingID"].ToString());
                    MPEUpdate.Hide();
                    mdepDraftExistsShow.Show();
                    lblDraftExistsShow.Visible = true;
                    lblDraftExistsShow.Text = "Return sale already exists with this phone " + txtLoadPhone.Text.Trim() + "<br />Do you want to get details?";
                }
                else
                {
                    DataSet dsUserDraftExists = objHotLeadBL.ChkUserPhoneNumberExists(txtLoadPhone.Text.Trim());
                    if (dsUserDraftExists.Tables[0].Rows.Count > 0)
                    {
                        Session["AbandonSalePostingID"] = Convert.ToInt32(dsUserDraftExists.Tables[0].Rows[0]["postingID"].ToString());
                        MPEUpdate.Hide();
                        mdepDraftExistsShow.Show();
                        lblDraftExistsShow.Visible = true;
                        lblDraftExistsShow.Text = "Draft/Abandon sale already exists with this phone " + txtLoadPhone.Text.Trim() + "<br />Do you want to get details?";
                    }
                    else
                    {
                        MPEUpdate.Hide();
                        txtPhone.Text = objGeneralFunc.filPhnm(txtLoadPhone.Text.Trim());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDraftExistsShowNo_Click(object sender, EventArgs e)
    {
        try
        {
            Session["AbandonSalePostingID"] = null;
            MPEUpdate.Hide();
            txtPhone.Text = objGeneralFunc.filPhnm(txtLoadPhone.Text.Trim());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAnotherCarYes_Click(object sender, EventArgs e)
    {
        try
        {
            Session["AddCarRedirectFrom"] = "FromOldCar";
            Response.Redirect("AddAnotherCar.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAnotherCarNo_Click(object sender, EventArgs e)
    {
        try
        {
            mdepExistsAlertShow.Show();
            MdepAddAnotherCarAlert.Hide();
            lblExistsAlertShow.Visible = true;
            lblExistsAlertShow.Text = "Sale already exists with this phone " + txtLoadPhone.Text.Trim() + "<br />Please change phone #";
            //Session["AbandonSalePostingID"] = null;
            //MPEUpdate.Show();
            //txtPhone.Text = objGeneralFunc.filPhnm(txtLoadPhone.Text.Trim());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAlertExistShow_Click(object sender, EventArgs e)
    {
        try
        {
            mdepExistsAlertShow.Hide();
            MPEUpdate.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAlertAfterSaveYes_Click(object sender, EventArgs e)
    {
        try
        {
            Session["AddAnotherCarSaleUID"] = Session["NewSaleUID"].ToString();
            Session["AddCarRedirectFrom"] = "FromNewCar";
            Response.Redirect("AddAnotherCar.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAlertAfterSaveNo_Click(object sender, EventArgs e)
    {
        try
        {
            Session["AbandonSalePostingID"] = null;
            Response.Redirect("NewEntrys.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDraftExistsShowYes_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("NewEntrys.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SaveInfo(int LeadStatus, int SaleAgentID)
    {
        try
        {
            objUserregInfo.Name = objGeneralFunc.ToProper(txtFirstName.Text);
            objUserregInfo.UserName = txtEmail.Text;
            string SellerPhone = txtPhone.Text;
            SellerPhone = SellerPhone.Replace("-", "");
            SellerPhone = SellerPhone.Replace("-", "");
            objUserregInfo.PhoneNumber = SellerPhone;
            objUserregInfo.Address = objGeneralFunc.ToProper(txtAddress.Text);
            objUserregInfo.City = objGeneralFunc.ToProper(txtCity.Text);
            objUserregInfo.StateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
            objUserregInfo.Zip = txtZip.Text;
            if (SaleAgentID == 0)
            {
                SaleAgentID = Convert.ToInt32(ddlSaleAgent.SelectedItem.Value);
            }
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value);
            string strIp;
            string strHostName = Request.UserHostAddress.ToString();
            strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            int YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Value);
            Session["SelYear"] = ddlYear.SelectedItem.Text;
            Session["SelMake"] = ddlMake.SelectedItem.Text;
            Session["SelModel"] = ddlModel.SelectedItem.Text;
            int MakeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value);
            int BodyTypeID = Convert.ToInt32(ddlBodyStyle.SelectedItem.Value);
            string Price = string.Empty;
            if (txtAskingPrice.Text == "")
            {
                Price = "0";
            }
            else
            {
                Price = txtAskingPrice.Text;
                Price = Price.Replace(",", "");
            }
            string Mileage = string.Empty;
            if (txtMileage.Text == "")
            {
                Mileage = "0";
            }
            else
            {
                Mileage = txtMileage.Text;
                Mileage = Mileage.Replace(",", "");
                Mileage = Mileage.Replace("mi", "");
                Mileage = Mileage.Replace(" ", "");
            }
            string ExteriorColor = ddlExteriorColor.SelectedItem.Text;
            string InteriorColor = ddlInteriorColor.SelectedItem.Text;
            string Transmission = "Unspecified";
            if (ddltransm.SelectedValue == "0")
            {
                Transmission = "Automatic";
            }
            else if (ddltransm.SelectedValue == "1")
            {
                Transmission = "Manual";
            }
            else if (ddltransm.SelectedValue == "2")
            {
                Transmission = "Tiptronic";
            }
            else if (ddltransm.SelectedValue == "3")
            {
                Transmission = "Unspecified";
            }

            string NumberOfDoors = string.Empty;
            if (ddltransm.SelectedValue == "0")
            {
                NumberOfDoors = "Two Door";
            }
            else if (ddltransm.SelectedValue == "1")
            {
                NumberOfDoors = "Three Door";
            }
            else if (ddltransm.SelectedValue == "2")
            {
                NumberOfDoors = "Four Door";
            }
            else if (ddltransm.SelectedValue == "3")
            {
                NumberOfDoors = "Five Door";
            }
            else
            {
                NumberOfDoors = "Unspecified";
            }
            string DriveTrain = "Unspecified";
            if (ddldrivetrain.SelectedValue == "0")
            {
                DriveTrain = "2 wheel drive";
            }
            else if (ddldrivetrain.SelectedValue == "1")
            {
                DriveTrain = "2 wheel drive - front";
            }
            else if (ddldrivetrain.SelectedValue == "2")
            {
                DriveTrain = "All wheel drive";
            }
            else if (ddldrivetrain.SelectedValue == "3")
            {
                DriveTrain = "Rear wheel drive";
            }
            else if (ddldrivetrain.SelectedValue == "4")
            {
                DriveTrain = "Unspecified";
            }

            string VIN = txtVin.Text;
            string NumberOfCylinder = "Unspecified";
            if (ddlcylindars.SelectedValue == "0")
            {
                NumberOfCylinder = "3 Cylinder";
            }
            else if (ddlcylindars.SelectedValue == "1")
            {
                NumberOfCylinder = "4 Cylinder";
            }
            else if (ddlcylindars.SelectedValue == "2")
            {
                NumberOfCylinder = "5 Cylinder";
            }
            else if (ddlcylindars.SelectedValue == "3")
            {
                NumberOfCylinder = "6 Cylinder";
            }
            else if (ddlcylindars.SelectedValue == "4")
            {
                NumberOfCylinder = "7 Cylinder";
            }
            else if (ddlcylindars.SelectedValue == "5")
            {
                NumberOfCylinder = "8 Cylinder";
            }

            int FuelTypeID = Convert.ToInt32(0);
            if (ddlfueltype.SelectedValue == "0")
            {
                FuelTypeID = Convert.ToInt32(1);
            }
            else if (ddlfueltype.SelectedValue == "1")
            {
                FuelTypeID = Convert.ToInt32(2);
            }
            else if (ddlfueltype.SelectedValue == "2")
            {
                FuelTypeID = Convert.ToInt32(3);
            }
            else if (ddlfueltype.SelectedValue == "3")
            {
                FuelTypeID = Convert.ToInt32(4);
            }
            else if (ddlfueltype.SelectedValue == "4")
            {
                FuelTypeID = Convert.ToInt32(5);
            }
            else if (ddlfueltype.SelectedValue == "5")
            {
                FuelTypeID = Convert.ToInt32(6);
            }
            else if (ddlfueltype.SelectedValue == "6")
            {
                FuelTypeID = Convert.ToInt32(7);
            }
            else if (ddlfueltype.SelectedValue == "7")
            {
                FuelTypeID = Convert.ToInt32(0);
            }

            int ConditionID = Convert.ToInt32(0);
            string Condition = "Unspecified";
            if (ddlcondition.SelectedValue == "0")
            {
                ConditionID = Convert.ToInt32(1);
                Condition = "Excellent";
            }
            else if (ddlcondition.SelectedValue == "1")
            {
                ConditionID = Convert.ToInt32(2);
                Condition = "Very Good";
            }
            else if (ddlcondition.SelectedValue == "2")
            {
                ConditionID = Convert.ToInt32(3);
                Condition = "Good";
            }
            else if (ddlcondition.SelectedValue == "3")
            {
                ConditionID = Convert.ToInt32(4);
                Condition = "Fair";
            }
            else if (ddlcondition.SelectedValue == "4")
            {
                ConditionID = Convert.ToInt32(5);
                Condition = "Poor";
            }
            else if (ddlcondition.SelectedValue == "5")
            {
                ConditionID = Convert.ToInt32(6);
                Condition = "Parts or Salvage";
            }
            else if (ddlcondition.SelectedValue == "6")
            {
                ConditionID = Convert.ToInt32(0);
                Condition = "Unspecified";
            }


            string Description = string.Empty;
            Description = txtDescription.Text;

            string Title = "";
            string State = ddlLocationState.SelectedItem.Text;
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtSaleNotes.Text.Trim();
            InternalNotesNew = InternalNotesNew.Trim();
            //string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            //if (InternalNotesNew != "")
            //{
            //    InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "---------------------------------";
            //}
            //else
            //{
            //    InternalNotesNew = InternalNotesNew.Trim();
            int SourceOfPhotos = Convert.ToInt32(ddlPhotosSource.SelectedItem.Value);
            int SourceOfDescription = Convert.ToInt32(ddlDescriptionSource.SelectedItem.Value);

            string LastName = objGeneralFunc.ToProper(txtLastName.Text.Trim());
            int CarID;
            int RegUID;
            int PostingID;
            int UserPackID;
            int sellerID;

            if ((Session["NewSaleCarID"] == null) || (Session["NewSaleCarID"].ToString() == ""))
            {
                CarID = Convert.ToInt32(0);
            }
            else
            {
                CarID = Convert.ToInt32(Session["NewSaleCarID"].ToString());
            }
            if ((Session["NewSaleUID"] == null) || (Session["NewSaleUID"].ToString() == ""))
            {
                RegUID = Convert.ToInt32(0);
            }
            else
            {
                RegUID = Convert.ToInt32(Session["NewSaleUID"].ToString());
            }
            if ((Session["NewSalePostingID"] == null) || (Session["NewSalePostingID"].ToString() == ""))
            {
                PostingID = Convert.ToInt32(0);
            }
            else
            {
                PostingID = Convert.ToInt32(Session["NewSalePostingID"].ToString());
            }
            if ((Session["NewSaleUserPackID"] == null) || (Session["NewSaleUserPackID"].ToString() == ""))
            {
                UserPackID = Convert.ToInt32(0);
            }
            else
            {
                UserPackID = Convert.ToInt32(Session["NewSaleUserPackID"].ToString());
            }
            if ((Session["NewSaleSellerID"] == null) || (Session["NewSaleSellerID"].ToString() == ""))
            {
                sellerID = Convert.ToInt32(0);
            }
            else
            {
                sellerID = Convert.ToInt32(Session["NewSaleSellerID"].ToString());
            }
            int VerifierID = Convert.ToInt32(ddlVerifier.SelectedItem.Value);
            int SaleEnteredBy = 0;
                try{
                    SaleEnteredBy= Convert.ToInt32(Session[Constants.USEREmp_ID].ToString());
          
                }catch{}
                int EmailExists = 1;
            if (chkbxEMailNA.Checked == true)
            {
                EmailExists = 0;
            }
            int DiscountID = 0; decimal Discamount = 0;
            DiscountID = Convert.ToInt32(ddlDiscount.SelectedValue);
            if (DiscountID == 0) Discamount = 0;
            else if (DiscountID == 1) Discamount = 25;
            else if (DiscountID == 2) Discamount = 50;
            DataSet dsdata = objHotLeadBL.SaveSaleStatusData(objUserregInfo, SaleAgentID, PackageID, Discamount, YearOfMake, MakeModelID, BodyTypeID, ConditionID, DriveTrain,
                        Price, Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, VIN, NumberOfCylinder, FuelTypeID, Description, Condition, Title,
                        State, strIp, InternalNotesNew, LeadStatus, LastName, SourceOfPhotos, SourceOfDescription, CarID, RegUID, UserPackID, sellerID, PostingID, VerifierID, SaleEnteredBy, EmailExists);

            CarID = Convert.ToInt32(dsdata.Tables[0].Rows[0]["CarID"].ToString());
            Session["NewSaleCarID"] = CarID;
            RegUID = Convert.ToInt32(dsdata.Tables[0].Rows[0]["UID"].ToString());
            Session["NewSaleUID"] = RegUID;
            PostingID = Convert.ToInt32(dsdata.Tables[0].Rows[0]["PostingID"].ToString());
            Session["NewSalePostingID"] = PostingID;
            UserPackID = Convert.ToInt32(dsdata.Tables[0].Rows[0]["UserPackID"].ToString());
            Session["NewSaleUserPackID"] = UserPackID;
            sellerID = Convert.ToInt32(dsdata.Tables[0].Rows[0]["sellerID"].ToString());
            Session["NewSaleSellerID"] = sellerID;

            int PaymentType = 0;
            string Cardtype = string.Empty;
            if (ddlpayme.SelectedValue == "1")
            {
                PaymentType = 1;
                Cardtype = "VisaCard";
            }
            else if (ddlpayme.SelectedValue == "2")
            {
                PaymentType = 2;
                Cardtype = "MasterCard";
            }
            else if (ddlpayme.SelectedValue == "3")
            {
                PaymentType = 4;
                Cardtype = "DiscoverCard";
            }
            else if (ddlpayme.SelectedValue == "4")
            {
                PaymentType = 3;
                Cardtype = "AmExCard";
            }
            else if (ddlpayme.SelectedValue == "5")
            {
                PaymentType = 6;
            }
            else if (ddlpayme.SelectedValue == "6")
            {
                PaymentType = 5;
            }

            string VoiceRecord = txtVoicefileConfirmNo.Text.Trim();
            int VoiceFileLocation = Convert.ToInt32(ddlVoiceFileLocation.SelectedItem.Value);
            int PSID1;
            if ((Session["NewSalePSID1"] == null) || (Session["NewSalePSID1"].ToString() == ""))
            {
                PSID1 = Convert.ToInt32(0);
            }
            else
            {
                PSID1 = Convert.ToInt32(Session["NewSalePSID1"].ToString());
            }
            int PSID2;
            if ((Session["NewSalePSID2"] == null) || (Session["NewSalePSID2"].ToString() == ""))
            {
                PSID2 = Convert.ToInt32(0);
            }
            else
            {
                PSID2 = Convert.ToInt32(Session["NewSalePSID2"].ToString());
            }
            int PaymentID;
            if ((Session["NewSalePaymentID"] == null) || (Session["NewSalePaymentID"].ToString() == ""))
            {
                PaymentID = Convert.ToInt32(0);
            }
            else
            {
                PaymentID = Convert.ToInt32(Session["NewSalePaymentID"].ToString());
            }

            if ((  (ddlpayme.SelectedValue == "1") ||  (ddlpayme.SelectedValue == "2") ||  (ddlpayme.SelectedValue == "3") ||  (ddlpayme.SelectedValue == "4")))
            {
                if (chkboxlstPDsale.Checked == true)
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    int PSStatusID;
                    int pmntStatus;
                    //int PSStatusID = 4;
                    //int pmntStatus = 1;
                    if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0")
                    {
                        PSStatusID = 8;
                        pmntStatus = 2;
                    }
                    else
                    {
                        PSStatusID = 4;
                        pmntStatus = 1;
                    }
                    string CCCardNumber = CardNumber.Text;
                    string CardExpDt = ExpMon.SelectedValue + "/" + CCExpiresYear.SelectedValue;
                    string CardholderName = objGeneralFunc.ToProper(txtCardholderName.Text);
                    string CardholderLastName = objGeneralFunc.ToProper(txtCardholderLastName.Text);
                    string CardCode = cvv.Text;
                    string BillingAdd = objGeneralFunc.ToProper(txtbillingaddress.Text);
                    string BillingCity = objGeneralFunc.ToProper(txtbillingcity.Text);
                    string BillingState = ddlbillingstate.SelectedItem.Value;
                    string BillingZip = txtbillingzip.Text;
                    DateTime PDDate = Convert.ToDateTime(ddlPDDate.SelectedItem.Text);
                    //string PDPayAmountNow = txtPDAmountNow.Text;
                    string PDPayAmountLater = txtPDAmountLater.Text;
                    DataSet dsSaveCCInfo = objHotLeadBL.SaveCreditCardDataForPDSale(PSID1, PackageID, CarID, PaymentScheduleDate, Amount, PSStatusID, PaymentID, SaleAgentID, PaymentType,
                                            pmntStatus, strIp, VoiceRecord, CCCardNumber, Cardtype, CardExpDt, CardholderName, CardholderLastName, CardCode, BillingZip, BillingAdd,
                                            BillingCity, BillingState, PostingID, PSID2, PDDate, PDPayAmountLater, VoiceFileLocation);
                    PSID1 = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PSID1"].ToString());
                    Session["NewSalePSID1"] = PSID1;
                    PSID2 = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PSID2"].ToString());
                    Session["NewSalePSID2"] = PSID2;
                    PaymentID = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PaymentID"].ToString());
                    Session["NewSalePaymentID"] = PaymentID;
                    if (VoiceRecord.ToString() != "")
                    {
                        DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                    }
                    else
                    {
                        if (LeadStatus != 1)
                        {
                            DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                        }
                    }
                }
                else
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    int PSStatusID = 4;
                    int pmntStatus = 1;
                    string CCCardNumber = CardNumber.Text;
                    string CardExpDt = ExpMon.SelectedValue + "/" + CCExpiresYear.SelectedValue;
                    string CardholderName = objGeneralFunc.ToProper(txtCardholderName.Text);
                    string CardholderLastName = objGeneralFunc.ToProper(txtCardholderLastName.Text);
                    string CardCode = cvv.Text;
                    string BillingAdd = objGeneralFunc.ToProper(txtbillingaddress.Text);
                    string BillingCity = objGeneralFunc.ToProper(txtbillingcity.Text);
                    string BillingState = ddlbillingstate.SelectedItem.Value;
                    string BillingZip = txtbillingzip.Text;
                    DataSet dsSaveCCInfo = objHotLeadBL.SaveCreditCardData(PSID1, PackageID, CarID, PaymentScheduleDate, Amount, PSStatusID, PaymentID, SaleAgentID, PaymentType,
                                            pmntStatus, strIp, VoiceRecord, CCCardNumber, Cardtype, CardExpDt, CardholderName, CardholderLastName, CardCode, BillingZip, BillingAdd,
                                            BillingCity, BillingState, PostingID, VoiceFileLocation);

                    PSID1 = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PSID1"].ToString());
                    Session["NewSalePSID1"] = PSID1;
                    PaymentID = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PaymentID"].ToString());
                    Session["NewSalePaymentID"] = PaymentID;
                    if (VoiceRecord.ToString() != "")
                    {
                        DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                    }
                    else
                    {
                        if (LeadStatus != 1)
                        {
                            DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                        }
                    }
                }
            }
            if (ddlpayme.SelectedValue == "5")
            {
                DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                string Amount = txtPDAmountNow.Text;
                int PSStatusID = 4;
                int pmntStatus = 1;
                string TransID = txtPaytransID.Text;
                string PayPalEmailAcc = txtpayPalEmailAccount.Text;
                DataSet dsSavePayPalInfo = objHotLeadBL.SavePayPalData(PSID1, PackageID, CarID, PaymentScheduleDate, Amount, PSStatusID, PaymentID, SaleAgentID, PaymentType,
                                        pmntStatus, strIp, VoiceRecord, TransID, PayPalEmailAcc, PostingID, VoiceFileLocation);

                PSID1 = Convert.ToInt32(dsSavePayPalInfo.Tables[0].Rows[0]["PSID1"].ToString());
                Session["NewSalePSID1"] = PSID1;
                PaymentID = Convert.ToInt32(dsSavePayPalInfo.Tables[0].Rows[0]["PaymentID"].ToString());
                Session["NewSalePaymentID"] = PaymentID;
                if (VoiceRecord.ToString() != "")
                {
                    DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                }
                else
                {
                    if (LeadStatus != 1)
                    {
                        DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                    }
                }
                //    if (chkboxlstPDsale.Checked == true)
                //    {
                //        int pmntStatus = 1;
                //        string Amount = txtPayAmount.Text;
                //        DateTime PayDate = Convert.ToDateTime(ddlPaymentdate.SelectedItem.Text);
                //        string TransID = txtPaytransID.Text;
                //        string PayPalEmailAcc = txtpayPalEmailAccount.Text;
                //        DateTime PDDate = Convert.ToDateTime(ddlPDDate.SelectedItem.Text);
                //        string PDPayAmountNow = txtPDAmountNow.Text;
                //        string PDPayAmountLater = txtPDAmountLater.Text;
                //        DataSet dsSaveCCInfo = objHotLeadBL.SavePayPalDataForPDSale(UserPackID, PaymentType, pmntStatus, strIp, Amount, VoiceRecord, PostingID, PayDate, TransID, PayPalEmailAcc, PDDate, PDPayAmountNow, PDPayAmountLater);
                //    }
                //    else
                //    {
                //        int pmntStatus = 2;
                //        string Amount = txtPayAmount.Text;
                //        DateTime PayDate = Convert.ToDateTime(ddlPaymentdate.SelectedItem.Text);
                //        string TransID = txtPaytransID.Text;
                //        string PayPalEmailAcc = txtpayPalEmailAccount.Text;
                //        DataSet dsSaveCCInfo = objHotLeadBL.SavePayPalData(UserPackID, PaymentType, pmntStatus, strIp, Amount, VoiceRecord, PostingID, PayDate, TransID, PayPalEmailAcc);
                //    }
            }
           if (ddlpayme.SelectedValue == "6")
            {
                if (chkboxlstPDsale.Checked == true)
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    int PSStatusID;
                    int pmntStatus;
                    //int PSStatusID = 4;
                    //int pmntStatus = 1;
                    if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0")
                    {
                        PSStatusID = 8;
                        pmntStatus = 2;
                    }
                    else
                    {
                        PSStatusID = 4;
                        pmntStatus = 1;
                    }
                    int AccType = Convert.ToInt32(ddlAccType.SelectedItem.Value);
                    string BankRouting = txtRoutingNumberForCheck.Text;
                    string bankName = txtBankNameForCheck.Text;
                    string AccNumber = txtAccNumberForCheck.Text;
                    string AccHolderName = txtCustNameForCheck.Text;
                    DateTime PDDate = Convert.ToDateTime(ddlPDDate.SelectedItem.Text);
                    //string PDPayAmountNow = txtPDAmountNow.Text;
                    string PDPayAmountLater = txtPDAmountLater.Text;
                    string CheckNumber = "";
                    int CheckType = Convert.ToInt32(5);
                    DataSet dsSaveCheckInfo = objHotLeadBL.SaveCheckDataForPDSale(PSID1, PackageID, CarID, PaymentScheduleDate, Amount, PSStatusID, PaymentID, SaleAgentID, PaymentType,
                                            pmntStatus, strIp, VoiceRecord, PostingID, AccType, BankRouting, bankName, AccNumber, AccHolderName, PSID2, PDDate, PDPayAmountLater, VoiceFileLocation, CheckType, CheckNumber);
                    PSID1 = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PSID1"].ToString());
                    Session["NewSalePSID1"] = PSID1;
                    PSID2 = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PSID2"].ToString());
                    Session["NewSalePSID2"] = PSID2;
                    PaymentID = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PaymentID"].ToString());
                    Session["NewSalePaymentID"] = PaymentID;
                    if (VoiceRecord.ToString() != "")
                    {
                        DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                    }
                    else
                    {
                        if (LeadStatus != 1)
                        {
                            DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                        }
                    }
                }
                else
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    int PSStatusID = 4;
                    int pmntStatus = 1;
                    int AccType = Convert.ToInt32(ddlAccType.SelectedItem.Value);
                    string BankRouting = txtRoutingNumberForCheck.Text;
                    string bankName = txtBankNameForCheck.Text;
                    string AccNumber = txtAccNumberForCheck.Text;
                    string AccHolderName = txtCustNameForCheck.Text;
                    string CheckNumber = "";
                    int CheckType = Convert.ToInt32(5);
                    DataSet dsSaveCheckInfo = objHotLeadBL.SaveCheckData(PSID1, PackageID, CarID, PaymentScheduleDate, Amount, PSStatusID, PaymentID, SaleAgentID, PaymentType,
                                            pmntStatus, strIp, VoiceRecord, PostingID, AccType, BankRouting, bankName, AccNumber, AccHolderName, VoiceFileLocation, CheckType, CheckNumber);
                    PSID1 = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PSID1"].ToString());
                    Session["NewSalePSID1"] = PSID1;
                    PaymentID = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PaymentID"].ToString());
                    Session["NewSalePaymentID"] = PaymentID;
                    if (VoiceRecord.ToString() != "")
                    {
                        DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                    }
                    else
                    {
                        if (LeadStatus != 1)
                        {
                            DataSet dsSaveLeadStatus = objHotLeadBL.SaveLeadStatusForSales(PostingID, LeadStatus);
                        }
                    }
                }
            }
            int FeatureID;
            int IsactiveFea;
            for (int i = 1; i < 54; i++)
            {
                if (i != 10)
                {
                    if (i != 37)
                    {
                        if (i != 38)
                        {
                            string ChkBoxID = "chkFeatures" + i.ToString();
                            CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                            if (ChkedBox.Checked == true)
                            {
                                IsactiveFea = 1;
                            }
                            else
                            {
                                IsactiveFea = 0;
                            }
                            FeatureID = i;
                            bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
                        }
                    }
                }
            }
            if (rdbtnLeather.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 10;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 10;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            if (rdbtnVinyl.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 37;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 37;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            if (rdbtnCloth.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 38;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 38;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }

            if (rdbtnInteriorNA.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 54;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 54;
                bool dsCarFeature = objHotLeadBL.SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
