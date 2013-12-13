using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotLeadInfo
{
    public class UserRegistrationInfo
    {
        private int _UId;


        public int UId
        {
            get { return _UId; }
            set { _UId = value; }
        }
        private string _Name;


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _UserName;


        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Pwd;


        public string Pwd
        {
            get { return _Pwd; }
            set { _Pwd = value; }
        }
        private string _PhoneNumber;


        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        private int _isActive;

        public int IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }private string _pwdHint;


        public string PwdHint
        {
            get { return _pwdHint; }
            set { _pwdHint = value; }
        }
        private int _sellerID;


        public int SellerID
        {
            get { return _sellerID; }
            set { _sellerID = value; }
        }
        private string _CouponCode;



        public string CouponCode
        {
            get { return _CouponCode; }
            set { _CouponCode = value; }
        }
        private string _ReferCode;


        public string ReferCode
        {
            get { return _ReferCode; }
            set { _ReferCode = value; }
        }
        private int _PackageID;


        public int PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }



        private string _City;


        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private int _StateID;


        public int StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        private string _Address;


        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Zip;


        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }

        private DateTime _CreatedDate;


        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private string _BusinessName;


        public string BusinessName
        {
            get { return _BusinessName; }
            set { _BusinessName = value; }
        }
        private string _AltEmail;


        public string AltEmail
        {
            get { return _AltEmail; }
            set { _AltEmail = value; }
        }
        private string _AltPhone;


        public string AltPhone
        {
            get { return _AltPhone; }
            set { _AltPhone = value; }
        }
    }
}
