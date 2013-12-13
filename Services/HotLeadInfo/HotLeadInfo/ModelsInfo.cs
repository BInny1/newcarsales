using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    [Serializable]

    public class ModelsInfo
    {
        private string _Model;

        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        private int _MakeModelID;

        public int MakeModelID
        {
            get { return _MakeModelID; }
            set { _MakeModelID = value; }
        }
        private int _MakeID;

        public int MakeID
        {
            get { return _MakeID; }
            set { _MakeID = value; }
        }
    }
}
