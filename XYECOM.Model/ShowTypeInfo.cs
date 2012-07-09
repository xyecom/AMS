using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// չ�����ʵ����
    /// </summary>
    public class ShowTypeInfo
    {
        private Int64 _sht_id;
        private string _sht_name;
        private Int64 _sht_parentid;
        private string _FullID;
        private int _InfoCount;
 
        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public ShowTypeInfo() { }

        /// <summary>
        /// ����ֵ�ù��캯��
        /// </summary>
        /// <param name="ctid"></param>
        /// <param name="ctname"></param>
        /// <param name="ctparentid"></param>
        /// <param name="ctbid"></param>
        /// <param name="mid"></param>
        public ShowTypeInfo(Int64 shtid, string shtname, Int64 shtparentid,string fullId,int infoCount)
        {
            this._sht_id = shtid;
            this._sht_name = shtname;
            this._sht_parentid = shtparentid;
            this._FullID = fullId;
            this._InfoCount = infoCount;
        }

        /// <summary>
        /// �������ı��
        /// </summary>
        public Int64 SHT_ID
        {
            set { _sht_id = value; }
            get { return _sht_id; }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string SHT_Name
        {
            set { _sht_name = value; }
            get { return _sht_name; }
        }

        /// <summary>
        /// �������ĸ����
        /// </summary>
        public Int64 SHT_ParentID
        {
            set { _sht_parentid = value; }
            get { return _sht_parentid; }
        }

        /// <summary>
        /// �������༯��
        /// </summary>
        public string FullID
        {
            get { return _FullID; }
            set { _FullID = value; }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public int InfoCount
        {
            get { return _InfoCount; }
            set { _InfoCount = value; }
        }
    }
}
