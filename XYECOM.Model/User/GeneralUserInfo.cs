using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 用户信息实体类
    /// 前台模板调用，调用方式为{useinfo.##},属性名全小写
    /// </summary>
    public class GeneralUserInfo
    {
        #region 共用属性
        /// <summary>
        /// 留言总条数
        /// </summary>
        public int messagecount = 0;

        /// <summary>
        /// 系统未查看留言条数
        /// </summary>
        public int noseesysmsgcount = 0;

        /// <summary>
        /// 审核未通过的原因
        /// </summary>
        public string reason;
        /// <summary>
        /// 审核未通过的建议
        /// </summary>
        public string advice;


        /// <summary>
        /// 用户Id
        /// </summary>
        public long userid = 0;
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName = "";
        
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime regdate = new DateTime();

        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool isaudited = false;

        /// <summary>
        /// [公司或个人]手机
        /// </summary>
        public string mobile = "";

        /// <summary>
        /// [公司或个人]邮政编码
        /// </summary>
        public string zipcode = "";

        /// <summary>
        /// [公司或个人]所在地名称
        /// </summary>
        public string AreaName = "";

        #endregion

        #region 企业用户专用字段
        /// <summary>
        /// 用户网店模板名称
        /// </summary>
        public string template = "";
        /// <summary>
        /// 可以查看联系方式的条目数
        /// </summary>
        public int linkmannum = 0;

        /// <summary>
        /// 律师形象照片
        /// </summary>
        public string LayerPicture = "";
        /// <summary>
        /// 企业banner图片地址
        /// </summary>
        public string banner = "";
        /// <summary>
        /// 企业Logo图片地址
        /// </summary>
        public string logo = "";
        /// <summary>
        /// 用户等级图片
        /// </summary>
        public string gradeimgurl = "";

        /// <summary>
        /// 用户等级大图地址
        /// </summary>
        public string gradebigimgurl = "";
        /// <summary>
        /// 资料完善率
        /// </summary>
        public int infoperfectpercent;
        /// <summary>
        /// 邮箱是否已经激活
        /// </summary>
        public bool activation = false;
        
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName = "";

        /// <summary>
        /// 是否有权限开设网店
        /// </summary>
        public bool isshop = false;

        /// <summary>
        /// 是否可以自定义产品分类
        /// </summary>
        public bool iscompanyprotype = false;

        /// <summary>
        /// 网店地址
        /// </summary>
        public string shopindex = "";

        /// <summary>
        /// 网店联系我们页面地址
        /// </summary>
        public string contactus = "";
        /// <summary>
        /// 诚信指数
        /// </summary>
        public int cred = 0;
        
        /// <summary>
        /// 企业主页
        /// </summary>
        public string homepage = "";

        /// <summary>
        /// 公司性质
        /// </summary>
        public string character = "";

        /// <summary>
        /// 企业类型
        /// </summary>
        public string unittype = "";

        /// <summary>
        /// 企业类型Id
        /// </summary>
        public int unittypeid = 0;

        /// <summary>
        /// 所在行业id
        /// </summary>
        public string tradeids = "";

        /// <summary>
        /// 员工总数
        /// </summary>
        public string employeetotal = "";

        /// <summary>
        /// 公司注册地
        /// </summary>
        public string regarea = "";

        /// <summary>
        /// 公司注册地id
        /// </summary>
        public int regareaid = 0;

        /// <summary>
        /// 详细地址
        /// </summary>
        private string address = "";

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// 经营模式
        /// </summary>
        public string mode = "";

        /// <summary>
        /// 成立年份
        /// </summary>
        public string regyear = "";

        /// <summary>
        /// 供应的产品和服务
        /// </summary>
        public string supplypro = "";

        /// <summary>
        /// 需求的产品和服务
        /// </summary>
        public string buypro = "";

        /// <summary>
        /// 注册资本
        /// </summary>
        public string registeredcapital = "0";

        /// <summary>
        /// 恶意错误处罚次数
        /// </summary>
        public int maliceerr = 0;

        /// <summary>
        /// 错误填写处罚次数
        /// </summary>
        public int commonerr = 0;

        /// <summary>
        /// 职位
        /// </summary>
        public string post = "";

        /// <summary>
        /// 所在部门
        /// </summary>
        public string department = "";

        /// <summary>
        /// 企业供求方向(1:供方;2:求方;3:两者都是)
        /// </summary>
        public short supplyorbuy = 0;

        /// <summary>
        /// IM号码
        /// </summary>
        public string im = "";

        /// <summary>
        /// 网店公告
        /// </summary>
        public string shopannounce = "";

        #endregion

        #region 个人会员专用

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string idcode = "";

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string realname = "";

        #endregion

        public bool isbindingtopdomain = false;
        public string domain = "";
        public bool issubdomain = false;

        /// <summary>
        /// 平台账户编号
        /// </summary>
        public int accountid;
        public decimal creditintegral;

        public Model.CreditLeavlInfo creditleavl;

        public string IdentityNumber { get; set; }

        public int DelState { get; set; }

        public Model.UserType UserType { get; set; }

        public bool IsExport { get; set; }

        public int AreaId { get; set; }

        public string LayerId { get; set; }

        public string IdNumber { get; set; }

        public bool Sex { get; set; }

        public string OtherContact { get; set; }

        public string Telphone { get; set; }

        public string Description { get; set; }

        public string LayerName { get; set; }

        public bool IsPrimary { get; set; }

        public string Email { get; set; }

        public bool IsBoundMobile { get; set; }

        public bool IsBoundEmail { get; set; }

        public int Point { get; set; }

        public bool IsReal { get; set; }

        public int GoodTimes { get; set; }

        public int MidTimes { get; set; }

        public int BadTimes { get; set; }

        public long CompanyId { get; set; }

        public string Fax { get; set; }

        public string LinkMan { get; set; }

        public string PartManagerName { get; set; }

        public string PartManagerTel { get; set; }
    }
}
