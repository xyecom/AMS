using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// �����Ϣʵ����
    /// </summary>
    public class UserRemitInfo
    {
        private System.Int32 _R_ID;
        private string _R_Name;
        private string _R_Email;
        private string _R_Tephone;
        private DateTime _R_Time;
        private string _R_Bank;
        private string _R_Account;
        private string _R_CAccount;
        private string _R_RName;
        private decimal _R_Money;
        private System.Int64 _u_id;
        private bool _R_IsPay;

        /// <summary>
        /// ���ȷ�ϱ��
        /// </summary>
        public System.Int32 R_ID
        {
            set { _R_ID = value; }
            get { return _R_ID; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public string R_Name
        {
            set { _R_Name = value; }
            get { return _R_Name; }
        }
        /// <summary>
        /// ��ϵ��Email
        /// </summary>
        public string R_Email
        {

            set { _R_Email = value; }
            get { return _R_Email; }
        }
        /// <summary>
        /// ��ϵ�˵绰
        /// </summary>
        public string R_Tephone
        {
            set { _R_Tephone = value; }
            get { return _R_Tephone; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime R_Time
        {
            set { _R_Time = value; }
            get { return _R_Time; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string R_Bank
        {
            set { _R_Bank = value; }
            get { return _R_Bank; }
        }
        /// <summary>
        /// ���뿨��
        /// </summary>
        public string R_Account
        {
            set { _R_Account = value; }
            get { return _R_Account; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string R_CAccount
        {
            set { _R_CAccount = value; }
            get { return _R_CAccount; }
        }
        /// <summary>
        /// �տ�������
        /// </summary>
        public string R_RName
        {
            set { _R_RName = value; }
            get { return _R_RName; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public decimal R_Money
        {
            set { _R_Money = value; }
            get { return _R_Money; }
        }
        public System.Int64 U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }
        public bool R_IsPay
        {
            set { _R_IsPay = value; }
            get { return _R_IsPay; }
        }

        private AuditingState state;

        /// <summary>
        /// ���״̬
        /// </summary>
        public AuditingState AuditingState
        {
            get { return state; }
            set { state = value; }
        }
    }
}
