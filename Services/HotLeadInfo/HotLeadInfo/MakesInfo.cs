using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]

    [Serializable] 


    public class MakesInfo
    {
        private int _makeID;

        public int MakeID
        {
            get { return _makeID; }
            set { _makeID = value; }
        }
        private string _make;

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        } 

    }
}
