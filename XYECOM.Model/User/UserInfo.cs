using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 企业会员信息实体类
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
        /// 用户基本注册信息
        /// 包括基本信息，等级信息，等级权限信息
        /// </summary>
        public Model.UserRegInfo RegInfo
        {
            get { return regInfo; }
            set { regInfo = value; }
        }

        private Model.AreaInfo _AreaInfo = null;

        /// <summary>
        /// 企业所在地信息
        /// </summary>
        public Model.AreaInfo AreaInfo
        {
            get { return _AreaInfo; }
            set { _AreaInfo = value; }
        }

        private Model.AreaInfo regAreaInfo = null;

        /// <summary>
        /// 企业注册地信息
        /// </summary>
        public Model.AreaInfo RegAreaInfo
        {
            get { return regAreaInfo; }
            set { regAreaInfo = value; }
        }

        private Model.UserTypeInfo userTypeInfo = null;

        /// <summary>
        /// 企业类型信息
        /// </summary>
        public Model.UserTypeInfo _UserTypeInfo
        {
            get { return userTypeInfo; }
            set { userTypeInfo = value; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public System.Int64 UserId
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Name
        {
            set { _ui_name = value; }
            get { return _ui_name; }
        }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            set { _ui_area = value; }
            get { return _ui_area; }
        }
        /// <summary>
        /// 营业执照号
        /// </summary>
        public string License
        {
            set { _ui_license = value; }
            get { return _ui_license; }
        }
        /// <summary>
        /// 公司性质
        /// </summary>
        public string Character
        {
            set { _ui_character = value; }
            get { return _ui_character; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set { _ui_linkman = value; }
            get { return _ui_linkman; }
        }
        /// <summary>
        /// 企业人数
        /// </summary>
        public string EmployeeTotal
        {
            set { _ui_number = value; }
            get { return _ui_number; }
        }
        /// <summary>
        /// 企业网址
        /// </summary>
        public string HomePage
        {
            set { _ui_homepage = value; }
            get { return _ui_homepage; }
        }

        /// <summary>
        /// 企业简介
        /// </summary>
        public string Synopsis
        {
            set { _ui_synopsis = value; }
            get { return _ui_synopsis; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postcode
        {
            set { _ui_postcode = value; }
            get { return _ui_postcode; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set { _ui_mobil = value; }
            get { return _ui_mobil; }
        }
        /// <summary>
        /// 用户类型编号
        /// </summary>
        public long UserTypeId
        {
            set { _ut_id = value; }
            get { return _ut_id; }
        }

        /// <summary>
        /// 联系人性别
        /// </summary>
        public bool Sex
        {
            get { return _ui_sex; }
            set { _ui_sex = value; }
        }

        /// <summary>
        /// 电话号码
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
        /// 传真号码
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
        /// 联系人所在部门
        /// </summary>
        public string Section
        {
            get { return _u_section; }
            set { _u_section = value; }
        }
        /// <summary>
        /// 联系人职位
        /// </summary>
        public string Post
        {
            get { return _u_post; }
            set { _u_post = value; }
        }
        /// <summary>
        /// 主营方向(1:供方;2:求方;3:两者都是)
        /// </summary>
        public System.Int16 SupplyOrBuy
        {
            get { return _u_way; }
            set { _u_way = value; }
        }
        /// <summary>
        /// 供应的产品和服务
        /// </summary>
        public string SupplyPro
        {
            get { return _u_supplyproduct; }
            set { _u_supplyproduct = value; }
        }
        /// <summary>
        /// 需求的产品和服务
        /// </summary>
        public string BuyPro
        {
            get { return _u_buyproduct; }
            set { _u_buyproduct = value; }
        }
        /// <summary>
        /// 经营模式
        /// </summary>
        public string Mode
        {
            get { return _u_mode; }
            set { _u_mode = value; }
        }
        /// <summary>
        /// 注册资金
        /// </summary>
        public decimal RegisteredCapital
        {
            get { return _u_money; }
            set { _u_money = value; }
        }
        /// <summary>
        /// 注册时间(年份)
        /// </summary>
        public System.Int32 RegYear
        {
            get { return _u_year; }
            set { _u_year = value; }
        }

        /// <summary>
        /// 企业注册地Id
        /// </summary>
        public System.Int32 RegAreaId
        {
            get { return _ac_id; }
            set { _ac_id = value; }
        }
        /// <summary>
        /// 主要经营地区
        /// </summary>
        public string BusinessAddress
        {
            get { return _u_address; }
            set { _u_address = value; }
        }
        /// <summary>
        /// 主营产品或服务
        /// </summary>
        public string MainProduct
        {
            get { return _u_ptype; }
            set { _u_ptype = value; }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string MoneyType
        {
            get { return _u_moneytype; }
            set { _u_moneytype = value; }
        }
        //企业所在地编号
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
        /// 行业id
        /// </summary>
        public string TradeIds
        {
            get { return tradeIds; }
            set { tradeIds = value; }
        }
        /// <summary>
        /// 用户账户编号
        /// </summary>
        public int Account
        {
            get { return _u_account; }
            set { _u_account = value; }
        }

        #region AMS

        /// <summary>
        /// 公司邮箱
        /// </summary>
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// 公司描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateDate
        {
            get;
            set;
        }
        
        //审核状态	State
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 审核通过时间
        /// </summary>
        public DateTime PassTime
        {
            get;
            set;
        }        
        //审核人	ManagerId	int			FALSE	FALSE	FALSE
        public int ManagerId
        {
            get;
            set;
        }
        /// <summary>
        /// 手机绑定状态
        /// </summary>
        public bool IsBoundMobile
        {
            get;
            set;
        }
        /// <summary>
        /// 邮箱绑定状态
        /// </summary>
        public bool IsBoundEmail
        {
            get;
            set;
        }
        /// <summary>
        /// 评价积分
        /// </summary>
        public int Point
        {
            get;
            set;
        }
        /// <summary>
        /// 是否实名认证
        /// </summary>
        public bool IsReal
        {
            get;
            set;
        }
        /// <summary>
        /// 好评数
        /// </summary>
        public int GoodTimes
        {
            get;
            set;
        }
        /// <summary>
        /// 中评数
        /// </summary>
        public int MidTimes
        {
            get;
            set;
        }
        /// <summary>
        /// 差评数
        /// </summary>
        public int BadTimes
        {
            get;
            set;
        }
        #endregion
    }

}

