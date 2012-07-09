using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 收费新闻设置信息
    /// </summary>
    public class ChargeNewsSetInfo
    {
        private Int64 _cn_id;
        private Int16 _cn_visitpopedom;
        private int _cn_consumewebmoney;
        private int _cn_consumemoney;
        private Int64 _ns_id;
        private Int64 _u_id;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ChargeNewsSetInfo() { }

        /// <summary>
        /// 给定值得构造函数
        /// </summary>
        /// <param name="cnid"></param>
        /// <param name="cnvisitpopedom"></param>
        /// <param name="cnconsumewebmoney"></param>
        /// <param name="cnconsumemoney"></param>
        /// <param name="nsid"></param>
        public ChargeNewsSetInfo(Int64 cnid,Int16 cnvisitpopedom,int cnconsumewebmoney,int cnconsumemoney,Int64 nsid,Int64 uid) 
        {
            this._cn_id = cnid;
            this._cn_visitpopedom = cnvisitpopedom;
            this._cn_consumewebmoney = cnconsumewebmoney;
            this._cn_consumemoney = cnconsumemoney;
            this._ns_id = nsid;
            this._u_id = uid;
        }

        /// <summary>
        /// 收费新闻设置编号
        /// </summary>
        public Int64 CN_ID
        {
            set { _cn_id = value; }
            get { return _cn_id; }
        }

        /// <summary>
        /// 用户访问权限编号(用户等级表主键)
        /// </summary>
        public Int16 CN_VisitPopedom
        {
            set { _cn_visitpopedom = value; }
            get { return _cn_visitpopedom; }
        }

        /// <summary>
        /// 每条新闻收取虚拟货币金额
        /// </summary>
        public int CN_ConsumeWebMoney
        {
            set { _cn_consumewebmoney = value; }
            get { return _cn_consumewebmoney; }
        }

        /// <summary>
        /// 每条新闻收取现金货币金额
        /// </summary>
        public int CN_ConsumeMoney
        {
            set { _cn_consumemoney = value; }
            get { return _cn_consumemoney; }
        }

        /// <summary>
        /// 应用该设置的新闻编号
        /// </summary>
        public Int64 NS_ID
        {
            set { _ns_id = value; }
            get { return _ns_id; }
        }
        //
        public Int64 U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }
    }
}
