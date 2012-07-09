using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 供求信息实体类
    /// </summary>
    public class SupplyInfo : BaseInfo
    {
        public SupplyInfo()
        {
            ModuleFlag = "offer";
        }

        #region 新增新的属性

        private string unit = string.Empty;
        /// <summary>
        /// 计价单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int leastNum;
        /// <summary>
        /// 最小订货量
        /// </summary>
        public int LeastNum
        {
            get { return leastNum; }
            set { leastNum = value; }
        }

        private int countNum;
        /// <summary>
        /// 供货总量
        /// </summary>
        public int CountNum
        {
            get { return countNum; }
            set { countNum = value; }
        }

        private bool isPayMent;
        /// <summary>
        /// 是否支持在线支付
        /// </summary>
        public bool IsPayMent
        {
            get { return isPayMent; }
            set { isPayMent = value; }
        }
        #endregion

        #region 针对于亿家商城新增的属性

        private int brandId;

        /// <summary>
        /// 所属品牌ID
        /// </summary>
        public int BrandId
        {
            get { return brandId; }
            set { brandId = value; }
        }

        private int measuringUnitId;

        /// <summary>
        /// 计量单位编号
        /// </summary>
        public int MeasuringUnitId
        {
            get { return measuringUnitId; }
            set { measuringUnitId = value; }
        }

        private int depotId;

        /// <summary>
        /// 所属库房
        /// </summary>
        public int DepotId
        {
            get { return depotId; }
            set { depotId = value; }
        }

        private int stocks;

        /// <summary>
        /// 挂牌量
        /// </summary>
        public int Stocks
        {
            get { return stocks; }
            set { stocks = value; }
        }

        private int salesVolume;

        /// <summary>
        /// 累计销售量
        /// </summary>
        public int SalesVolume
        {
            get { return salesVolume; }
            set { salesVolume = value; }
        }

        private bool isDeleted;

        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        private string tags = string.Empty;

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private bool isContractVouch;

        /// <summary>
        /// 是否合同担保
        /// </summary>
        public bool IsContractVouch
        {
            get { return isContractVouch; }
            set { isContractVouch = value; }
        }


        private string summary = string.Empty;

        /// <summary>
        /// 产品描述
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        private bool isPayBail;

        /// <summary>
        /// 是否交纳保证金
        /// </summary>
        public bool IsPayBail
        {
            get { return isPayBail; }
            set { isPayBail = value; }
        }

        private int freightType;

        /// <summary>
        /// 支持的货运方式
        /// </summary>
        public int FreightType
        {
            get { return freightType; }
            set { freightType = value; }
        }

        private decimal marketPrice;

        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice
        {
            get { return marketPrice; }
            set { marketPrice = value; }
        }

        private IList<Model.FieldValueInfo> fieldValues = new List<FieldValueInfo>();

        public IList<Model.FieldValueInfo> FieldValues
        {
            get { return fieldValues; }
            set { fieldValues = value; }
        }

        public Model.ProductTypeInfo ProductType
        {
            get;
            set;
        }

        private int ishasimage;

        /// <summary>
        /// 是否包含图片
        /// </summary>
        public int Ishasimage
        {
            get { return ishasimage; }
            set { ishasimage = value; }
        }
        #endregion

        private bool isshop;
        /// <summary>
        /// 是否推荐到网店
        /// </summary>
        public bool Isshop
        {
            get { return isshop; }
            set { isshop = value; }
        }
        private int companyProductTypeId;
        /// <summary>
        /// 公司产品分类ID
        /// </summary>
        public int CompanyProductTypeId
        {
            get { return companyProductTypeId; }
            set { companyProductTypeId = value; }
        }

        /// <summary>
        /// 在线订购链接
        /// </summary>
        public string OrderLink
        {
            get
            {
                if (!IsPayMent) return "";

                if (XYECOM.Configuration.WebInfo.Instance.IsBogusStatic)
                {
                    return "/search/orderadd-offer-" + this.InfoID + "." + XYECOM.Configuration.WebInfo.Instance.WebSuffix;
                }
                else
                {
                    return "/search/orderadd." + XYECOM.Configuration.WebInfo.Instance.WebSuffix + "?infoid=" + this.InfoID + "&flag=offer";
                }
            }
        }

        private IList<XYECOM.Model.PriceRangeInfo> ranglist;

        /// <summary>
        ///价格区间
        /// </summary>
        public IList<XYECOM.Model.PriceRangeInfo> PriceRange
        {
            get { return ranglist; }
            set { ranglist = value; }
        }

        private Model.BrandInfo _brandInfo;

        /// <summary>
        /// 品牌
        /// </summary>
        public Model.BrandInfo BrandInfo
        {
            get { return _brandInfo; }
            set { _brandInfo = value; }
        }

        private Model.DepotInfo _depotInfo;

        /// <summary>
        /// 发货地
        /// </summary>
        public Model.DepotInfo DepotInfo
        {
            get { return _depotInfo; }
            set { _depotInfo = value; }
        }

        private int lockCount = 0;

        /// <summary>
        /// 锁定量
        /// </summary>
        public int LockCount
        {
            get { return lockCount; }
            set { lockCount = value; }
        }

        private IList<ProductLogisticsEnterpriseInfo> _supportLogitsticsTypes;

        /// <summary>
        /// 支持的物流类型
        /// </summary>
        public IList<ProductLogisticsEnterpriseInfo> SupportLogitsticsTypes
        {
            get { return _supportLogitsticsTypes; }
            set { _supportLogitsticsTypes = value; }
        }

        private string supplyUrl;

        /// <summary>
        /// 产品在网店的URL
        /// </summary>
        public string SupplyUrl
        {
            get { return supplyUrl; }
            set { supplyUrl = value; }
        }

        private decimal marginRefund;

        /// <summary>
        /// 已挂牌产品的合同保证金百分比
        /// </summary>
        public decimal MarginRefund
        {
            get { return marginRefund; }
            set { marginRefund = value; }
        }
    }
}
