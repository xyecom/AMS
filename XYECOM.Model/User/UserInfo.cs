using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��ҵ��Ա��Ϣʵ����
    /// </summary>
    public class UserInfo
    {
        private long _u_id;
        private string _ui_name;
        private string _ui_area;
        private string _ui_license;
        private string _ui_character;
        private string _ui_linkman;
        private string _ui_number;
        private string _ui_homepage;
        private string _ui_synopsis;
        private string _ui_postcode;
        private string _ui_mobil;
        private long _ut_id;
        private bool _ui_sex;
        private string _u_section;
        private string _u_post;
        private short _u_way;
        private string _u_supplyproduct;
        private string _u_buyproduct;
        private string _u_mode;
        private decimal _u_money;
        private int _u_year;
        private string _u_address;
        private string _u_ptype;
        private string _u_moneytype;
        private int _area_ID;
        private int _ac_id;
        private string _IM;
        private string telephone;
        private string fax;
        private int _u_account;

        private Model.UserRegInfo regInfo = null;

        /// <summary>
        /// �û�����ע����Ϣ
        /// ����������Ϣ���ȼ���Ϣ���ȼ�Ȩ����Ϣ
        /// </summary>
        public Model.UserRegInfo RegInfo
        {
            get { return regInfo; }
            set { regInfo = value; }
        }

        private Model.AreaInfo _AreaInfo = null;

        /// <summary>
        /// ��ҵ���ڵ���Ϣ
        /// </summary>
        public Model.AreaInfo AreaInfo
        {
            get { return _AreaInfo; }
            set { _AreaInfo = value; }
        }

        private Model.AreaInfo regAreaInfo = null;

        /// <summary>
        /// ��ҵע�����Ϣ
        /// </summary>
        public Model.AreaInfo RegAreaInfo
        {
            get { return regAreaInfo; }
            set { regAreaInfo = value; }
        }

        private Model.UserTypeInfo userTypeInfo = null;

        /// <summary>
        /// ��ҵ������Ϣ
        /// </summary>
        public Model.UserTypeInfo _UserTypeInfo
        {
            get { return userTypeInfo; }
            set { userTypeInfo = value; }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public System.Int64 UserId
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// ��˾����
        /// </summary>
        public string Name
        {
            set { _ui_name = value; }
            get { return _ui_name; }
        }

        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        public string Address
        {
            set { _ui_area = value; }
            get { return _ui_area; }
        }
        /// <summary>
        /// Ӫҵִ�պ�
        /// </summary>
        public string License
        {
            set { _ui_license = value; }
            get { return _ui_license; }
        }
        /// <summary>
        /// ��˾����
        /// </summary>
        public string Character
        {
            set { _ui_character = value; }
            get { return _ui_character; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string LinkMan
        {
            set { _ui_linkman = value; }
            get { return _ui_linkman; }
        }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        public string EmployeeTotal
        {
            set { _ui_number = value; }
            get { return _ui_number; }
        }
        /// <summary>
        /// ��ҵ��ַ
        /// </summary>
        public string HomePage
        {
            set { _ui_homepage = value; }
            get { return _ui_homepage; }
        }

        /// <summary>
        /// ��ҵ���
        /// </summary>
        public string Synopsis
        {
            set { _ui_synopsis = value; }
            get { return _ui_synopsis; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Postcode
        {
            set { _ui_postcode = value; }
            get { return _ui_postcode; }
        }
        /// <summary>
        /// �ֻ�
        /// </summary>
        public string Mobile
        {
            set { _ui_mobil = value; }
            get { return _ui_mobil; }
        }
        /// <summary>
        /// �û����ͱ��
        /// </summary>
        public long UserTypeId
        {
            set { _ut_id = value; }
            get { return _ut_id; }
        }

        /// <summary>
        /// ��ϵ���Ա�
        /// </summary>
        public bool Sex
        {
            get { return _ui_sex; }
            set { _ui_sex = value; }
        }

        /// <summary>
        /// �绰����
        /// </summary>
        public string Telephone
        {
            get
            {
                return telephone;
            }
            set { telephone = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        /// <summary>
        /// ��ϵ�����ڲ���
        /// </summary>
        public string Section
        {
            get { return _u_section; }
            set { _u_section = value; }
        }
        /// <summary>
        /// ��ϵ��ְλ
        /// </summary>
        public string Post
        {
            get { return _u_post; }
            set { _u_post = value; }
        }
        /// <summary>
        /// ��Ӫ����(1:����;2:��;3:���߶���)
        /// </summary>
        public System.Int16 SupplyOrBuy
        {
            get { return _u_way; }
            set { _u_way = value; }
        }
        /// <summary>
        /// ��Ӧ�Ĳ�Ʒ�ͷ���
        /// </summary>
        public string SupplyPro
        {
            get { return _u_supplyproduct; }
            set { _u_supplyproduct = value; }
        }
        /// <summary>
        /// ����Ĳ�Ʒ�ͷ���
        /// </summary>
        public string BuyPro
        {
            get { return _u_buyproduct; }
            set { _u_buyproduct = value; }
        }
        /// <summary>
        /// ��Ӫģʽ
        /// </summary>
        public string Mode
        {
            get { return _u_mode; }
            set { _u_mode = value; }
        }
        /// <summary>
        /// ע���ʽ�
        /// </summary>
        public decimal RegisteredCapital
        {
            get { return _u_money; }
            set { _u_money = value; }
        }
        /// <summary>
        /// ע��ʱ��(���)
        /// </summary>
        public System.Int32 RegYear
        {
            get { return _u_year; }
            set { _u_year = value; }
        }

        /// <summary>
        /// ��ҵע���Id
        /// </summary>
        public System.Int32 RegAreaId
        {
            get { return _ac_id; }
            set { _ac_id = value; }
        }
        /// <summary>
        /// ��Ҫ��Ӫ����
        /// </summary>
        public string BusinessAddress
        {
            get { return _u_address; }
            set { _u_address = value; }
        }
        /// <summary>
        /// ��Ӫ��Ʒ�����
        /// </summary>
        public string MainProduct
        {
            get { return _u_ptype; }
            set { _u_ptype = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string MoneyType
        {
            get { return _u_moneytype; }
            set { _u_moneytype = value; }
        }
        //��ҵ���ڵر��
        public System.Int32 AreaId
        {
            get { return _area_ID; }
            set { _area_ID = value; }
        }
        /// <summary>
        /// IM
        /// </summary>
        public string IM
        {
            get { return _IM; }
            set { _IM = value; }
        }

        private string tradeIds;

        /// <summary>
        /// ��ҵid
        /// </summary>
        public string TradeIds
        {
            get { return tradeIds; }
            set { tradeIds = value; }
        }
        /// <summary>
        /// �û��˻����
        /// </summary>
        public int Account
        {
            get { return _u_account; }
            set { _u_account = value; }
        }

        #region AMS

        /// <summary>
        /// ��˾����
        /// </summary>
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// ��˾����
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime CreateDate
        {
            get;
            set;
        }
        
        //���״̬	State
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// ���ͨ��ʱ��
        /// </summary>
        public DateTime PassTime
        {
            get;
            set;
        }        
        //�����	ManagerId	int			FALSE	FALSE	FALSE
        public int ManagerId
        {
            get;
            set;
        }
        /// <summary>
        /// �ֻ���״̬
        /// </summary>
        public bool IsBoundMobile
        {
            get;
            set;
        }
        /// <summary>
        /// �����״̬
        /// </summary>
        public bool IsBoundEmail
        {
            get;
            set;
        }
        /// <summary>
        /// ���ۻ���
        /// </summary>
        public int Point
        {
            get;
            set;
        }
        /// <summary>
        /// �Ƿ�ʵ����֤
        /// </summary>
        public bool IsReal
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>
        public int GoodTimes
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>
        public int MidTimes
        {
            get;
            set;
        }
        /// <summary>
        /// ������
        /// </summary>
        public int BadTimes
        {
            get;
            set;
        }
        #endregion
    }

}

