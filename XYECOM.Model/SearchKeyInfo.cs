using System;

namespace XYECOM.Model
{
    /// <summary>
    /// �������������ؼ���ʵ����
    /// </summary>
    public class SearchKeyInfo
    {
        private Int64 _sk_id;
        private string _sk_name;
        private string _sk_sort;
        private Int64 _sk_count;
        private bool _sk_iscommend;

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public SearchKeyInfo() { }

        /// <summary>
        /// ���������ؼ��ֱ��
        /// </summary>
        public Int64 SK_ID
        {
            set { _sk_id = value; }
            get { return _sk_id; }
        }

        /// <summary>
        /// ���������ؼ�������
        /// </summary>
        public string SK_Name
        {
            set { _sk_name = value; }
            get { return _sk_name; }
        }

        /// <summary>
        /// ���������ؼ����������
        /// </summary>
        public string SK_Sort
        {
            set { _sk_sort = value; }
            get { return _sk_sort; }
        }

        /// <summary>
        /// ���ֱ���������
        /// </summary>
        public Int64 SK_Count
        {
            set { this._sk_count = value; }
            get { return _sk_count; }
        }

        /// <summary>
        /// �Ƿ��Ƽ��ùؼ���
        /// </summary>
        public bool SK_IsCommend
        {
            set { this._sk_iscommend = value; }
            get { return _sk_iscommend; }
        }

        private bool _SK_IsRanking;
        /// <summary>
        /// �Ƿ��������
        /// </summary>
        public bool SK_IsRanking
        {
            get { return _SK_IsRanking; }
            set { _SK_IsRanking = value; }
        }

        private DateTime _SK_AddTime;
        /// <summary>
        /// ¼��ʱ��(��һ�α�����ʱ��)
        /// </summary>
        public DateTime SK_AddTime
        {
            get { return _SK_AddTime; }
            set { _SK_AddTime = value; }
        }

        private DateTime _SK_LastSearchTime;
        /// <summary>
        /// ���һ������ʱ��
        /// </summary>
        public DateTime SK_LastSearchTime
        {
            get { return _SK_LastSearchTime; }
            set { _SK_LastSearchTime = value; }
        }

        private string _SK_CustomPrice ="";

        /// <summary>
        /// �Զ���۸�
        /// </summary>
        public string SK_CustomPrice
        {
            get { return _SK_CustomPrice; }
            set { _SK_CustomPrice = value; }
        }

        /// <summary>
        /// ��ȡ�۸�
        /// </summary>
        /// <param name="rank">����</param>
        /// <returns></returns>
        public int GetPrice(short rank)
        {
            if (_SK_CustomPrice.Equals("")) return 0;

            string[] prices = _SK_CustomPrice.Split('|');

            if (rank > prices.Length) return 0;

            return Core.MyConvert.GetInt32(prices[rank - 1].ToString());
        }
    }
}
