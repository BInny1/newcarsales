using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class SmartzIntroMailInfo
    {
        private int _IntroMailID;


        public int IntroMailID
        {
            get { return _IntroMailID; }
            set { _IntroMailID = value; }
        }
        private string _MarketSpecialist;


        public string MarketSpecialist
        {
            get { return _MarketSpecialist; }
            set { _MarketSpecialist = value; }
        }
        private string _CustomerEmail;


        public string CustomerEmail
        {
            get { return _CustomerEmail; }
            set { _CustomerEmail = value; }
        }
        private DateTime _SentDateTime;


        public DateTime SentDateTime
        {
            get { return _SentDateTime; }
            set { _SentDateTime = value; }
        }
        private int _Status;


        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
