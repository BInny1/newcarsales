using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class AgentInfo
    {
        private int _Sale_Agent_Id;


        public int Sale_Agent_Id
        {
            get { return _Sale_Agent_Id; }
            set { _Sale_Agent_Id = value; }
        }
        private string _Agent_Name;


        public string Agent_Name
        {
            get { return _Agent_Name; }
            set { _Agent_Name = value; }
        }
        private string _First_Name;


        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }
        private string _Last_Name;


        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }
        private string _American_Name;


        public string American_Name
        {
            get { return _American_Name; }
            set { _American_Name = value; }
        }
        private int _Location_ID;


        public int Location_ID
        {
            get { return _Location_ID; }
            set { _Location_ID = value; }
        }
        private int _Created_by;


        public int Created_by
        {
            get { return _Created_by; }
            set { _Created_by = value; }
        }
        private DateTime _Created_Date;


        public DateTime Created_Date
        {
            get { return _Created_Date; }
            set { _Created_Date = value; }
        }
        private int _IsActive;


        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        private int _Disable_By;


        public int Disable_By
        {
            get { return _Disable_By; }
            set { _Disable_By = value; }
        }
        private DateTime _Disable_Date;


        public DateTime Disable_Date
        {
            get { return _Disable_Date; }
            set { _Disable_Date = value; }
        }
    }
}
