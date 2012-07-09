using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �շ�����������Ϣ
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
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public ChargeNewsSetInfo() { }

        /// <summary>
        /// ����ֵ�ù��캯��
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
        /// �շ��������ñ��
        /// </summary>
        public Int64 CN_ID
        {
            set { _cn_id = value; }
            get { return _cn_id; }
        }

        /// <summary>
        /// �û�����Ȩ�ޱ��(�û��ȼ�������)
        /// </summary>
        public Int16 CN_VisitPopedom
        {
            set { _cn_visitpopedom = value; }
            get { return _cn_visitpopedom; }
        }

        /// <summary>
        /// ÿ��������ȡ������ҽ��
        /// </summary>
        public int CN_ConsumeWebMoney
        {
            set { _cn_consumewebmoney = value; }
            get { return _cn_consumewebmoney; }
        }

        /// <summary>
        /// ÿ��������ȡ�ֽ���ҽ��
        /// </summary>
        public int CN_ConsumeMoney
        {
            set { _cn_consumemoney = value; }
            get { return _cn_consumemoney; }
        }

        /// <summary>
        /// Ӧ�ø����õ����ű��
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
