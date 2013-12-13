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
using HotLeadBL.CentralDBTransactions;
using HotLeadBL.HotLeadsTran;

public partial class UserControl_Header : System.Web.UI.UserControl
{
    HotLeadsBL objHotLeadsBL = new HotLeadsBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[Constants.NAME] == null)
            {
                lnkBtnLogout.Visible = false;
                lblUserName.Visible = false;
            }
            else
            {

                lnkBtnLogout.Visible = true;
                lblUserName.Visible = true;
                string LogUsername = Session[Constants.NAME].ToString();
                if (LogUsername.Length > 20)
                {
                    lblUserName.Text = LogUsername.ToString().Substring(0, 10);
                }
                else
                {
                    lblUserName.Text = LogUsername;
                }

            }
        }
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
            DataSet dsDatetime = objHotLeadsBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            objHotLeadsBL.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), dtNow, Convert.ToInt32(Session[Constants.USERLOG_ID]), 2);
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
        }
    }
}
