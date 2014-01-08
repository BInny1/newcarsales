#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
#endregion Microsoft Application Block References

/// <summary>
/// Summary description for Constants
/// </summary>
public static class Constants
{
    public static string USER_ID = "UserID";
    public static string USEREmp_ID = "UserID";

    public static string USER_NAME = "USER_NAME";
    public static string CenterCode = "CeneterCode";
    public static string CenterCodeID = "CeneterCodeID";
    

    public static string USER_Rights = "USER_Rights";
    public static string PhoneNumber = "PhoneNumber";
    public static string SellerID = "SellerID";
    public static string NAME = "NAME";
    public static string Salutation = "Salutation";
    public static string States = "States";

    public static string USERLOG_ID = "USERLOG_ID";

    public static string USER_TYPE_ID = "USER_TYPE_ID";

    public static string USER_LocationID = "USER_LocationID";


    public const string StrFormatException = "Parameter ArrayList empty";
    /// String constant for Ascending
    /// </summary>
    public const string StrAscending = "Ascending";

    /// <summary>
    /// String constant for Descending
    /// </summary>
    public const string StrDescending = "Descending";
    public static string SESSIONEXPIRATIONTIME = System.Configuration.ConfigurationManager.AppSettings["SessionExprirationTime"].ToString().Trim();

    public const string Makes = "Makes";
    public const string AllModel = "AllModel";
    public const string Bodys = "Bodys";

}
