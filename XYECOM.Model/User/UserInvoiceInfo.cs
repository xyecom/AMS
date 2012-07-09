using System;
using System.Collections.Generic;


namespace XYECOM.Model
{
    /// <summary>
    /// 用户申请发票信息实体类
    /// </summary>
    public class UserInvoiceInfo
    {
        private System.Int32 _I_ID;
        private string _I_Name;
        private string _I_Address;
        private string _I_PostCode;
        private decimal _I_Money;
        private string _I_Title;
        private string _I_Content;
        private string _I_Product;
        private System.Int16 _I_IsFlag;
        private string  _I_Reason;
        private string  _I_Advice;
        private long  _U_ID;
        private DateTime i_Addtime;


        //发票编号
        public System.Int32 I_ID
        {
            set { _I_ID = value; }
            get { return _I_ID; }
        }
        //姓名
        public string I_Name
        {
            set { _I_Name = value; }
            get { return _I_Name; }
        }
        //地址
        public string I_Address
        {
            set { _I_Address = value; }
            get { return _I_Address; }
        }
        //邮编
        public string I_PostCode
        {
            set { _I_PostCode = value; }
            get { return _I_PostCode; }
        }
        //金额
        public decimal I_Money
        {
            set { _I_Money = value; }
            get { return _I_Money; }
        }
        //抬头
        public string I_Title
        {
            set { _I_Title = value; }
            get { return _I_Title; }
        }
        //内容
        public string I_Content
        {
            set { _I_Content = value; }
            get { return _I_Content; }
        }
        //产品名称
        public string I_Product
        {
            set { _I_Product = value; }
            get { return _I_Product; }
        }
        public System.Int16 I_IsFlag
        {
            get { return _I_IsFlag; }
            set { _I_IsFlag = value; }
        }
        public string I_Advice
        {
            get { return _I_Advice; }
            set { _I_Advice = value; }
        }
        public string I_Reason
        {
            get { return _I_Reason; }
            set { _I_Reason = value; }
        }
        public long U_ID
        {
            get { return _U_ID; }
            set { _U_ID = value; }
        }
        public DateTime I_Addtime
        {
            get { return i_Addtime; }
            set { i_Addtime = value; }
        }
    }
}
