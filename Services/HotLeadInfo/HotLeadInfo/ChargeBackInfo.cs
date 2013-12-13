using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class ChargeBackInfo
    {
        private int _ChargeBackID;


        public int ChargeBackID
        {
            get { return _ChargeBackID; }
            set { _ChargeBackID = value; }
        }
        private DateTime _CustomerContactdate;


        public DateTime CustomerContactdate
        {
            get { return _CustomerContactdate; }
            set { _CustomerContactdate = value; }
        }
        private string _CustomerCBVoiceFile;


        public string CustomerCBVoiceFile
        {
            get { return _CustomerCBVoiceFile; }
            set { _CustomerCBVoiceFile = value; }
        }
        private DateTime _ResponseDate;


        public DateTime ResponseDate
        {
            get { return _ResponseDate; }
            set { _ResponseDate = value; }
        }
        private string _Resolution;


        public string Resolution
        {
            get { return _Resolution; }
            set { _Resolution = value; }
        }
        private DateTime _ChargeBackDate;


        public DateTime ChargeBackDate
        {
            get { return _ChargeBackDate; }
            set { _ChargeBackDate = value; }
        }
        private DateTime _ReceivedDate;


        public DateTime ReceivedDate
        {
            get { return _ReceivedDate; }
            set { _ReceivedDate = value; }
        }
        private string _ReferenceNumber;


        public string ReferenceNumber
        {
            get { return _ReferenceNumber; }
            set { _ReferenceNumber = value; }
        }
        private int _RequestType;


        public int RequestType
        {
            get { return _RequestType; }
            set { _RequestType = value; }
        }
        private string _ReasonCode;


        public string ReasonCode
        {
            get { return _ReasonCode; }
            set { _ReasonCode = value; }
        }
        private string _ReasonCodeDescription;


        public string ReasonCodeDescription
        {
            get { return _ReasonCodeDescription; }
            set { _ReasonCodeDescription = value; }
        }
        private string _CaseNumber;


        public string CaseNumber
        {
            get { return _CaseNumber; }
            set { _CaseNumber = value; }
        }
        private string _CBAmount;


        public string CBAmount
        {
            get { return _CBAmount; }
            set { _CBAmount = value; }
        }
        private DateTime _ReplyByDate;


        public DateTime ReplyByDate
        {
            get { return _ReplyByDate; }
            set { _ReplyByDate = value; }
        }
        private string _ClaimantName;


        public string ClaimantName
        {
            get { return _ClaimantName; }
            set { _ClaimantName = value; }
        }
        private string _TranID;


        public string TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }
        private string _Notes;


        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        private int _ChargeBackStatus;


        public int ChargeBackStatus
        {
            get { return _ChargeBackStatus; }
            set { _ChargeBackStatus = value; }
        }
        private int _ProcessorID;


        public int ProcessorID
        {
            get { return _ProcessorID; }
            set { _ProcessorID = value; }
        }
    }
}
