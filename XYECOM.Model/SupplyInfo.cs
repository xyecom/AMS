using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ������Ϣʵ����
    /// </summary>
    public class SupplyInfo : BaseInfo
    {
        public SupplyInfo()
        {
            ModuleFlag = "offer";
        }

        #region �����µ�����

        private string unit = string.Empty;
        /// <summary>
        /// �Ƽ۵�λ
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        private int leastNum;
        /// <summary>
        /// ��С������
        /// </summary>
        public int LeastNum
        {
            get { return leastNum; }
            set { leastNum = value; }
        }

        private int countNum;
        /// <summary>
        /// ��������
        /// </summary>
        public int CountNum
        {
            get { return countNum; }
            set { countNum = value; }
        }

        private bool isPayMent;
        /// <summary>
        /// �Ƿ�֧������֧��
        /// </summary>
        public bool IsPayMent
        {
            get { return isPayMent; }
            set { isPayMent = value; }
        }
        #endregion

        #region ������ڼ��̳�����������

        private int brandId;

        /// <summary>
        /// ����Ʒ��ID
        /// </summary>
        public int BrandId
        {
            get { return brandId; }
            set { brandId = value; }
        }

        private int measuringUnitId;

        /// <summary>
        /// ������λ���
        /// </summary>
        public int MeasuringUnitId
        {
            get { return measuringUnitId; }
            set { measuringUnitId = value; }
        }

        private int depotId;

        /// <summary>
        /// �����ⷿ
        /// </summary>
        public int DepotId
        {
            get { return depotId; }
            set { depotId = value; }
        }

        private int stocks;

        /// <summary>
        /// ������
        /// </summary>
        public int Stocks
        {
            get { return stocks; }
            set { stocks = value; }
        }

        private int salesVolume;

        /// <summary>
        /// �ۼ�������
        /// </summary>
        public int SalesVolume
        {
            get { return salesVolume; }
            set { salesVolume = value; }
        }

        private bool isDeleted;

        /// <summary>
        /// �Ƿ���ɾ��
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
        /// �Ƿ��ͬ����
        /// </summary>
        public bool IsContractVouch
        {
            get { return isContractVouch; }
            set { isContractVouch = value; }
        }


        private string summary = string.Empty;

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        private bool isPayBail;

        /// <summary>
        /// �Ƿ��ɱ�֤��
        /// </summary>
        public bool IsPayBail
        {
            get { return isPayBail; }
            set { isPayBail = value; }
        }

        private int freightType;

        /// <summary>
        /// ֧�ֵĻ��˷�ʽ
        /// </summary>
        public int FreightType
        {
            get { return freightType; }
            set { freightType = value; }
        }

        private decimal marketPrice;

        /// <summary>
        /// �г���
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
        /// �Ƿ����ͼƬ
        /// </summary>
        public int Ishasimage
        {
            get { return ishasimage; }
            set { ishasimage = value; }
        }
        #endregion

        private bool isshop;
        /// <summary>
        /// �Ƿ��Ƽ�������
        /// </summary>
        public bool Isshop
        {
            get { return isshop; }
            set { isshop = value; }
        }
        private int companyProductTypeId;
        /// <summary>
        /// ��˾��Ʒ����ID
        /// </summary>
        public int CompanyProductTypeId
        {
            get { return companyProductTypeId; }
            set { companyProductTypeId = value; }
        }

        /// <summary>
        /// ���߶�������
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
        ///�۸�����
        /// </summary>
        public IList<XYECOM.Model.PriceRangeInfo> PriceRange
        {
            get { return ranglist; }
            set { ranglist = value; }
        }

        private Model.BrandInfo _brandInfo;

        /// <summary>
        /// Ʒ��
        /// </summary>
        public Model.BrandInfo BrandInfo
        {
            get { return _brandInfo; }
            set { _brandInfo = value; }
        }

        private Model.DepotInfo _depotInfo;

        /// <summary>
        /// ������
        /// </summary>
        public Model.DepotInfo DepotInfo
        {
            get { return _depotInfo; }
            set { _depotInfo = value; }
        }

        private int lockCount = 0;

        /// <summary>
        /// ������
        /// </summary>
        public int LockCount
        {
            get { return lockCount; }
            set { lockCount = value; }
        }

        private IList<ProductLogisticsEnterpriseInfo> _supportLogitsticsTypes;

        /// <summary>
        /// ֧�ֵ���������
        /// </summary>
        public IList<ProductLogisticsEnterpriseInfo> SupportLogitsticsTypes
        {
            get { return _supportLogitsticsTypes; }
            set { _supportLogitsticsTypes = value; }
        }

        private string supplyUrl;

        /// <summary>
        /// ��Ʒ�������URL
        /// </summary>
        public string SupplyUrl
        {
            get { return supplyUrl; }
            set { supplyUrl = value; }
        }

        private decimal marginRefund;

        /// <summary>
        /// �ѹ��Ʋ�Ʒ�ĺ�ͬ��֤��ٷֱ�
        /// </summary>
        public decimal MarginRefund
        {
            get { return marginRefund; }
            set { marginRefund = value; }
        }
    }
}
