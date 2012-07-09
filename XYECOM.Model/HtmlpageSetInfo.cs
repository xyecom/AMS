using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    #region 静态页面设置信息属性类
    /// <summary>
    /// 静态页面设置信息实体类
    /// </summary>
    public class HtmlPageSetInfo
    {
        private int _HPS_ID;
        private bool _HPS_Index;
        private int _HPS_Indextime;
        private bool _HPS_Supply;
        private int _HPS_Supplytime;
        private bool _HPS_Demand;
        private int _HPS_Demandtime;
        private bool _HPS_Bussiness;
        private int _HPS_Bussinesstime;
        private bool _HPS_Engage;
        private int _HPS_Engagetime;
        private bool _HPS_Corporation;
        private int _HPS_Corporationtime;
        private bool _HPS_Address;
        private int _HPS_Addresstime;

        public HtmlPageSetInfo()
        {
            _HPS_ID = 0;
            _HPS_Index = false;
            _HPS_Indextime = 0;
            _HPS_Supply = false;
            _HPS_Supplytime = 0;
            _HPS_Demand = false;
            _HPS_Demandtime = 0;
            _HPS_Bussiness = false;
            _HPS_Bussinesstime = 0;
            _HPS_Engage = false;
            _HPS_Engagetime = 0;
            _HPS_Corporation = false;
            _HPS_Corporationtime = 0;
            _HPS_Address = false;
            _HPS_Addresstime = 0;
        }

        public int HPS_ID
        {
            set { _HPS_ID = value; }
            get { return _HPS_ID; }
        }

        public bool HPS_Index
        {
            set { _HPS_Index = value; }
            get { return _HPS_Index; }
        }

        public int HPS_Indextime
        {
            set { _HPS_Indextime = value; }
            get { return _HPS_Indextime; }
        }

        public bool HPS_Supply
        {
            set { _HPS_Supply = value; }
            get { return _HPS_Supply; }
        }

        public int HPS_Supplytime
        {
            set { _HPS_Supplytime = value; }
            get { return _HPS_Supplytime; }
        }

        public bool HPS_Demand
        {
            set { _HPS_Demand = value; }
            get { return _HPS_Demand; }
        }

        public int HPS_Demandtime
        {
            set { _HPS_Demandtime = value; }
            get { return _HPS_Demandtime; }
        }

        public bool HPS_Bussiness
        {
            set { _HPS_Bussiness = value; }
            get { return _HPS_Bussiness; }
        }

        public int HPS_Bussinesstime
        {
            set { _HPS_Bussinesstime = value; }
            get { return _HPS_Bussinesstime; }
        }

        public bool HPS_Engage
        {
            set { _HPS_Engage = value; }
            get { return _HPS_Engage; }
        }

        public int HPS_Engagetime
        {
            set { _HPS_Engagetime = value; }
            get { return _HPS_Engagetime; }
        }

        public bool HPS_Corporation
        {
            set { _HPS_Corporation = value;  }
            get { return _HPS_Corporation; }
        }

        public int HPS_Corporationtime
        {
            set { _HPS_Corporationtime = value; }
            get { return _HPS_Corporationtime; }
        }

        public bool HPS_Address
        {
            set { _HPS_Address = value; }
            get { return _HPS_Address; }
        }

        public int HPS_Addresstime
        {
            set { _HPS_Addresstime = value; }
            get { return _HPS_Addresstime; }
        }
    }
    #endregion
}
