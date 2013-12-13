

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using HotLeadBL.HotLeadsTran;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX,uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class TransfersWebService : System.Web.Services.WebService
{

    [WebMethod(EnableSession = true)]
    public string sessionGet()
    {
        string sesTime = HttpContext.Current.Session.Timeout.ToString();
        sesTime = (Convert.ToInt32(sesTime) - 2).ToString();
        return sesTime;
    }

    [WebMethod(EnableSession = true)]
    public string sessionSet(string sTime)
    {
        HttpContext.Current.Session.Timeout = Convert.ToInt32(sTime);
        return sTime;
    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public ArrayList GetAllLoginAgentDetailsService()
    {
        DataSet ds = new DataSet();
        HotLeadsBL objHotLeadsBL = new HotLeadsBL();
        ArrayList arr = new ArrayList();
        ds = objHotLeadsBL.GetAllLoginAgentDetails();

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr.Add(ds.Tables[0].Rows[i]["AgentUFirstName"].ToString() + "," + ds.Tables[0].Rows[i]["AgentCenterCode"].ToString());
            }
        }
        return arr;
    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public ArrayList GetAllLoginTransferAgentsDetailsService()
    {
        DataSet ds = new DataSet();
        HotLeadsBL objHotLeadsBL = new HotLeadsBL();
        ArrayList arr = new ArrayList();
        ds = objHotLeadsBL.GetAllLoginTransferAgentsDetails();

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr.Add(ds.Tables[0].Rows[i]["AgentUFirstName"].ToString() + "," + ds.Tables[0].Rows[i]["AgentCenterCode"].ToString());
            }
        }
        return arr;
    }


}

