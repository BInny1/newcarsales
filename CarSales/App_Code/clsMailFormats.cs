using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;
using System.Text;
using System.IO;
using System.Collections.Generic;
using HotLeadBL;
//using HotLeadBL;
//using HotLeadBL.Transactions;


/// <summary>
/// Summary description for clsMailFormats
/// </summary>
public class clsMailFormats
{

    #region RegisterFormat

    GeneralFunc objGeneralFunc = new GeneralFunc();
    public string SendRegistrationdetails(string Username, string Password, string Name, ref string strMailFormat, string Link, string TermsLink)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegisterSuccess.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";
            if (line.Contains("###UploadUser###"))
            {
                strMail = line.Replace("###UploadUser###", Name) + "<br />";
            }
            else if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", Password) + "<br />";
            }
            else if (line.Contains("###UCELINK###"))
            {
                strMail = line.Replace("###UCELINK###", Link) + "<br />";
            }
            else if (line.Contains("###Terms###"))
            {
                strMail = line.Replace("###Terms###", TermsLink) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendRegistrationdetailsForPDSales(string Username, string Password, string Name, ref string strMailFormat, string PDDate)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForPDSales.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";
            if (line.Contains("###UploadUser###"))
            {
                strMail = line.Replace("###UploadUser###", Name) + "<br />";
            }
            else if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", Password) + "<br />";
            }
            else if (line.Contains("###PDDate###"))
            {
                strMail = line.Replace("###PDDate###", PDDate) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    #endregion RegisterFormat
    #region Passwordcahnge


    public string ChangePassword(string Password, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailFormats/PasswordChange.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Password) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    #endregion Passwordcahnge
    #region UserUpdate
    public string SendUserUpdatedetails(string Username, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailFormats/UserUpdate.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    #endregion UserUpdate

    #region CouponDownload
    public string SendCoupondownloaddetails(int CouponID, Double CouAmount, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailFormats/Coupondownload.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", CouponID.ToString()) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", CouAmount.ToString()) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    #endregion CouponDownload


    public string SendForgetPassword(string Username, string Password, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/ForgetPassword.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UserLoginName###"))
            {
                strMail = line.Replace("###UserLoginName###", Username) + "<br />";
            }
            else if (line.Contains("###UserLoginPassword###"))
            {
                strMail = line.Replace("###UserLoginPassword###", Password) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    public string SendNewcarRequestDetails(string Username, string Phone, string Email, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/NewCarRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                strMail = line.Replace("###Cusname###", Username) + "<br />";
            }
            else if (line.Contains("###Phone###"))
            {
                strMail = line.Replace("###Phone###", Phone) + "<br />";
            }
            else if (line.Contains("###Email###"))
            {
                strMail = line.Replace("###Email###", Email) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    public string SendDealerRequestDetails(string Username, string Phone, string Email, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/DealerRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                strMail = line.Replace("###Cusname###", Username) + "<br />";
            }
            else if (line.Contains("###Phone###"))
            {
                strMail = line.Replace("###Phone###", Phone) + "<br />";
            }
            else if (line.Contains("###Email###"))
            {
                strMail = line.Replace("###Email###", Email) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    public string SendContactRequestDetails(string Username, string Phone, string Email, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/ContactRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                strMail = line.Replace("###Cusname###", Username) + "<br />";
            }
            else if (line.Contains("###Phone###"))
            {
                strMail = line.Replace("###Phone###", Phone) + "<br />";
            }
            else if (line.Contains("###Email###"))
            {
                strMail = line.Replace("###Email###", Email) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    public string SendIntromaildetails(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/SmartzIntroMail.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###AgentName###"))
            {
                strMail = line.Replace("###AgentName###", AgentName) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendIntromaildetailsForDealers(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/DealerIntroMail.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###AgentName###"))
            {
                strMail = line.Replace("###AgentName###", AgentName) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendSpanishIntromaildetails(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;

        strMailFormat = "Gracias por su interés en United Car Exchange.<br /><br />";
        strMailFormat += "Conectamos a compradores y vendedores de vehículos usados en todo el país.<br />";
        strMailFormat += "Hay más de 15 millones de usuarios de Internet que buscan coches usados cada mes como el suyo.<br />";
        strMailFormat += "Nosotros pones su vehículo en 15 sitios Web  que le ayudará a la exposición a más de 100.000 compradores.<br /><br />";
        strMailFormat += "Regístrese para una venta rápida.<br /><br />";
        strMailFormat += "Detalles del paquete explicando nuestra garantía de devolución en dinero están disponibles en<br />";
        strMailFormat += "esp.unitedcarexchange.com/Premium.aspx<br /><br /><br />";
        strMailFormat += "También puede contactar a  nuestro departamento de marketing al 888-786-8307.<br />O envíenos un correo electrónico a info@unitedcarexchange.com.<br /><br /><br />";
        strMailFormat += "Su Consultor de marketing personal<br />";
        strMailFormat += AgentName;

        bNew = true;
        return strMailFormat;
    }

    public string SendMultiSitedetails(ref string strMailFormat, DataTable dtMultiSite)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/UCEMultisite.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("IDMultisiteTable"))
            {
                strMail = line + "<br />";
                for (int i = 0; i < dtMultiSite.Rows.Count; i++)
                {
                    strMail = strMail + "<tr>";
                    strMail = strMail + " <td style=\"width: 230px; background: #fff; padding: 5px\"><strong style=\"color: #333; text-decoration: none\"><a href=\"#\" style=\"color: #232323\">";
                    strMail = strMail + dtMultiSite.Rows[i]["SiteUrl"].ToString();
                    strMail = strMail + "</a></strong></td>";
                    strMail = strMail + " <td style=\"background: #fff; padding: 5px\"><a href=";
                    strMail = strMail + dtMultiSite.Rows[i]["URL"].ToString();
                    strMail = strMail + "target=\"_blank\" style=\"color: #CB3024\">";
                    strMail = strMail + dtMultiSite.Rows[i]["URL"].ToString();
                    strMail = strMail + "</a></td>";
                    strMail = strMail + "</tr>";
                }
            }
            strMailFormat = strMailFormat + strMail;


        }

        bNew = true;

        objStreamReader.Close();

        return strMailFormat;

    }


    /// <summary>
    /// New Modified shravan 0614 2012
    /// </summary>
    /// <param name="strMailFormat"></param>
    /// <param name="dtMultiSite"></param>
    /// <param name="CarsDetails"></param>


    public string SendRVRegistrationdetailsForPDSales(string Username, string Password, string Name, ref string strMailFormat, string PDDate)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForRvPDSales.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";
            if (line.Contains("###UploadUser###"))
            {
                strMail = line.Replace("###UploadUser###", Name) + "<br />";
            }
            else if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", Password) + "<br />";
            }
            else if (line.Contains("###PDDate###"))
            {
                strMail = line.Replace("###PDDate###", PDDate) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }




    public string SendRVRegistrationdetails(string Username, string Password, string Name, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForRVs.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";
            if (line.Contains("###UploadUser###"))
            {
                strMail = line.Replace("###UploadUser###", Name) + "<br />";
            }
            else if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", Password) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendOffermaildetails(ref string strMailFormat)
    {

        string strMail = string.Empty;
        strMail += "<html><head><title>United Car Exchange</title></head>";
        strMail += "<body style=\"padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px;\" ondragstart=\"return false\" onselectstart=\"return false\">";
        strMail += "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" height=\"100%\"><tr><td style=\"background: #f5f5f5;\" align=\"center\" valign=\"top\">";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"24\"></td></tr></table><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr>";
        strMail += "<td style=\"background: #f5f5f5;\" width=\"183\" height=\"44\"><a href=\"http://www.unitedcarexchange.com\" target=\"_blank\"><img src=\"http://www.unitedcarexchange.com/Offerimages/logo.jpg\" border=\"0\" /></a></td>";
        strMail += "<td style=\"background: #f5f5f5;\" width=\"417\" height=\"44\" align=\"right\"><div style=\"color: #717171; font-family: arial, verdana; font-size: 12px;\">Customer service: <b>888-786-8307</b></div><div style=\"color: #717171; font-family: arial, verdana; font-size: 10px;\">P.O. Box #504. Iselin, NJ 08830-0504</div></td>";
        strMail += "</tr></table><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"6\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"25\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/body_header_shadow-top.jpg\" /></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"250\"><a href=\"http://www.unitedcarexchange.com/Offers.aspx\" target=\"_blank\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/image_header.jpg\" border=\"0\" /></a></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"27\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/image_header_shadow.jpg\" /></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"15\"></td></tr></table>";
        strMail += "<table style=\"background: #e9e9e9;\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"24\"></td><td style=\"background: #e9e9e9; color: #555555; font-family: arial, verdana; font-size: 15px;line-height: 19px;\" width=\"552\" align=\"left\">You can now advertise your used car for $9.99 one time charge. Its Quick, Easy and Simple at UnitedCarExchange.com/Offers<a href=\"http://www.unitedcarexchange.com/Offers.aspx\" style=\"color: #FF1100; margin: 0 4px;font-weight: bold\">Click Now</a> to Advertise</td><td style=\"background: #e9e9e9;\" width=\"24\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"12\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"40\"><div style=\"width: 570px; height: 2px; margin: 0 auto 10px auto; border-bottom: #ccc 2px dashed\"></div></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"24\"></td><td style=\"background: #e9e9e9; font-family: arial, verdana; font-size: 25px; color: #393939;\" width=\"552\" align=\"left\">Flat 80% off only in your area</td><td style=\"background: #e9e9e9;\" width=\"24\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\"><tr><td style=\"background: #e9e9e9;\" width=\"30\"></td><td style=\"background: #e9e9e9;\" valign=\"top\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\"><tr><td style=\"background: #e9e9e9;\" width=\"320\" height=\"6\"></td></tr><tr><td style=\"background: #e9e9e9; font-family: arial, verdana; font-size: 15px; color: #707070;\" width=\"320\" align=\"left\">";
        strMail += "This August, Advertise you car with UnitedCarExchange.com to sell it Fast, Easy and at Best Price. In fact, we are offering a flat 80% discount, only in your Area!<br><br>All the Enhanced listing features which usually costs you $49.99 now available just for $9.99<br><br>Team <a href=\"http://www.unitedcarexchange.com\" style=\"color: #FF6600; margin: 0 4px; font-weight: bold; font-size: 12px;\" target=\"_blank\">UnitedCarExchange.com</a></td></tr><tr><td style=\"background: #e9e9e9;\" width=\"320\" height=\"14\"></td></tr></table></td><td style=\"background: #e9e9e9;\" width=\"30\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"25\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"25\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/body_header_shadow.jpg\" /></td></tr></table>";
        strMail += "</td></tr></table></body></html>";
        return strMail;
    }
    public string DownloadLeadInfoDetails(ref string strMailFormat, DataTable dtLeadsInfo)
    {

        string strMail = string.Empty;
        strMail += "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>PDF</title></head>";
        strMail += "<body style=\"font-family: 'Calibri'; font-size: 13px; color: #222;\"><a href=\"pdf2.html\" onclick=\"window.print();return false\" style=\"float: right;\"><img src=\"printer_icon.gif\"></a>";
        strMail += "<table style=\"border-collapse: collapse; width: 778px; height: auto; margin: 0\"><tr><td>";
        strMail += "<table style=\"border-collapse: collapse; width: 100%;\"><tr><td style=\"width: 33%; font-size: 15px; line-height: 19px; vertical-align: top; text-align: left;\"><strong>LEADS FOR WINNERS</strong></td>";
        strMail += "<td style=\"font-size: 15px; line-height: 19px; vertical-align: top; text-align: center;\"><strong>NEW YORK - EMPIRE STATE</strong></td>";
        strMail += "<td style=\"width: 33%; vertical-align: top; font-size: 15px; text-align: right;\"><strong>3/3/2013</strong></td></tr></table></td></tr>";
        strMail += "<tr><td style=\"padding: 5px 0;\"><table style=\"border-collapse: collapse; border: none; width: 100%;\">";

        if (dtLeadsInfo.Rows.Count > 0)
        {
            int i = 0;
            int l = 0;
            for (int j = 0; i < dtLeadsInfo.Rows.Count; j++)
            {
                strMail += "<tr>";
                for (int k = 0; k < 4; k++)
                {
                    i = i + 1;
                    l = l + 1;
                    strMail += "<td style=\"width: 25%;\"><div style=\"display: block; padding: 5px; font-size: 11px; color: #333; border: #888 1px solid;height: 180px;\">";
                    strMail += "#202022<br /><strong style=\"display: block; text-align: center; margin: 2px 0;\">2005 Mistubishi Eclipse GTS</strong> <strong style=\"display: block; text-align: center; font-size: 15px;margin-bottom: 2px;\">732-222-2222</strong>";
                    strMail += "<div style=\"display: block; margin: 3px 0 6px 0; height: 10px;\"><span style=\"text-align: left; float: left;\">Fayetssville</span> <span style=\"text-align: right;float: right;\">$10,000</span></div>";
                    strMail += "<div style=\"text-align: center;\">New paint job, new upholstery , power windows, power door locks, cruise control, tilt, 125,xxx miles tinted</div></div>";
                    strMail += "</td>";
                }
                strMail += "</tr>";
                if (l == 20)
                {
                    l = 0;
                    if (i == 20)
                    {
                        strMail += "<tr><td style=\"height:50px;\">&nbsp;</td></tr>";
                    }
                    else
                    {
                        strMail += "<tr><td style=\"height:75px;\">&nbsp;</td></tr>";
                    }
                }
            }
        }
        strMail += "</table></td></tr>";
        strMail += "</table></body></html>";

        return strMail;
    }


}