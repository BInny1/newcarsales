using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class UserLogInfo
    {
        private Int64 _Log_Id;


        public Int64 Log_Id
        {
            get { return _Log_Id; }
            set { _Log_Id = value; }
        }
        private string _User_Id;


        public string User_Id
        {
            get { return _User_Id; }
            set { _User_Id = value; }
        }
        private DateTime _Login_DateTime;


        public DateTime Login_DateTime
        {
            get { return _Login_DateTime; }
            set { _Login_DateTime = value; }
        }
        private string _Login_Ip;


        public string Login_Ip
        {
            get { return _Login_Ip; }
            set { _Login_Ip = value; }
        }
        private DateTime _Logout_time;


        public DateTime Logout_time
        {
            get { return _Logout_time; }
            set { _Logout_time = value; }
        }
        private int _Log_Status_Id;


        public int Log_Status_Id
        {
            get { return _Log_Status_Id; }
            set { _Log_Status_Id = value; }
        }
        private string _Session_Id;


        public string Session_Id
        {
            get { return _Session_Id; }
            set { _Session_Id = value; }
        }
        private string _CookieID;


        public string CookieID
        {
            get { return _CookieID; }
            set { _CookieID = value; }
        }
    }
}
