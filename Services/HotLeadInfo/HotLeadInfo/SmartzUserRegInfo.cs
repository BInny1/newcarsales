using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class SmartzUserRegInfo
    {
        private int _SmartzUID;


        public int SmartzUID
        {
            get { return _SmartzUID; }
            set { _SmartzUID = value; }
        }
        private string _SmartzFirstName;


        public string SmartzFirstName
        {
            get { return _SmartzFirstName; }
            set { _SmartzFirstName = value; }
        }
        private string _SmartzLastName;


        public string SmartzLastName
        {
            get { return _SmartzLastName; }
            set { _SmartzLastName = value; }
        }
        private string _SmartzEmail;


        public string SmartzEmail
        {
            get { return _SmartzEmail; }
            set { _SmartzEmail = value; }
        }
        private int _SmartzUtype_Id;


        public int SmartzUtype_Id
        {
            get { return _SmartzUtype_Id; }
            set { _SmartzUtype_Id = value; }
        }
        private DateTime _SmartzAddDate;


        public DateTime SmartzAddDate
        {
            get { return _SmartzAddDate; }
            set { _SmartzAddDate = value; }
        }
        private string _SmartzUname;


        public string SmartzUname
        {
            get { return _SmartzUname; }
            set { _SmartzUname = value; }
        }
        private string _SmatzPassword;


        public string SmatzPassword
        {
            get { return _SmatzPassword; }
            set { _SmatzPassword = value; }
        }
        private int _SmartzIsActive;


        public int SmartzIsActive
        {
            get { return _SmartzIsActive; }
            set { _SmartzIsActive = value; }
        }
    }
}
