using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class BodyInfo
    {
        private int _bodyTypeID;


        public int BodyTypeID
        {
            get { return _bodyTypeID; }
            set { _bodyTypeID = value; }
        }
        private string _bodyType;


        public string BodyType
        {
            get { return _bodyType; }
            set { _bodyType = value; }
        }
    }
}
