using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class LeadBatchFile
    {

        private string _UpBatchID;

        public string UpBatchID
        {
            get { return _UpBatchID; }
            set { _UpBatchID = value; }
        }
        private string _Leadsource;

        public string Leadsource
        {
            get { return _Leadsource; }
            set { _Leadsource = value; }
        }
        private string _LeadFile;

        public string LeadFile
        {
            get { return _LeadFile; }
            set { _LeadFile = value; }
        }
        private string _Leaddate;

        public string Leaddate
        {
            get { return _Leaddate; }
            set { _Leaddate = value; }
        }
        private string _Leaduploadeddate;

        public string Leaduploadeddate
        {
            get { return _Leaduploadeddate; }
            set { _Leaduploadeddate = value; }
        }
        private string _LeadUploadedBy;

        public string LeadUploadedBy
        {
            get { return _LeadUploadedBy; }
            set { _LeadUploadedBy = value; }
        }
        private string _RecordCount;

        public string RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        } 

    }
}
