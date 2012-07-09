using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �������ʵ����
    /// </summary>
    public class ServiceTypeInfo
    {
        private Int64 _st_id;
        private string _st_name;
        private Int64 _st_parentid;
        private string _ModuleName;
        private string _FullId;
        private int _InfoCount;

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public ServiceTypeInfo () {}
        /// <summary>
        /// ����ֵ�ù��캯��
        /// </summary>
        /// <param name="ctid"></param>
        /// <param name="ctname"></param>
        /// <param name="ctparentid"></param>
        /// <param name="ctbid"></param>
        /// <param name="mid"></param>
        public ServiceTypeInfo(Int64 stid, string stname, Int64 stparentid, string moduleName,string fullId,int infoCount)
        {
            this._st_id = stid;
            this._st_name = stname;
            this._st_parentid = stparentid;
            this._ModuleName = moduleName;
            this._FullId = fullId;
            this._InfoCount = infoCount;
        }

        /// <summary>
        /// �������ı��
        /// </summary>
        public Int64 ST_ID
        {
            set { _st_id = value; }
            get { return _st_id; }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string ST_Name
        {
            set { _st_name = value; }
            get { return _st_name; }
        }

        /// <summary>
        /// �������ĸ����
        /// </summary>
        public Int64 ST_ParentID
        {
            set { _st_parentid = value; }
            get { return _st_parentid; }
        }

        /// <summary>
        /// �����ʹ�õ�ģ����
        /// Ĭ��Ϊ0,��ΪϵͳĬ�ϱ��,��Ϊ����ģ��
        /// </summary>
        public string ModuleName
        {
            set { _ModuleName = value; }
            get { return _ModuleName; }
        }

        /// <summary>
        /// ����Id�б�
        /// </summary>
        public string FullId
        {
            get { return _FullId; }
            set { _FullId = value; }
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
