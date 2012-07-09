using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ���̼��˷���ʵ����
    /// </summary>
    public class InviteBusinessTypeInfo
    {
        private Int64 _it_id;
        private string _it_name;
        private Int64 _it_parentid;
        private string _ModuleName;
        private string _FullId;
        private int _InfoCount;


        public InviteBusinessTypeInfo() { }
        /// <summary>
        /// ����ֵ�ù��캯��
        /// </summary>
        /// <param name="ctid"></param>
        /// <param name="ctname"></param>
        /// <param name="ctparentid"></param>
        /// <param name="ctbid"></param>
        /// <param name="mid"></param>
        public InviteBusinessTypeInfo(Int64 itid, string itname, Int64 itparentid, string moduleName,string fullId,int infoCount)
        {
            this._it_id = itid;
            this._it_name = itname;
            this._it_parentid = itparentid;
            this._ModuleName = moduleName;
            this._FullId = fullId;
            this._InfoCount = infoCount;
        }

        /// <summary>
        /// �������ı��
        /// </summary>
        public Int64 IT_ID
        {
            set { _it_id = value; }
            get { return _it_id; }
        }

        /// <summary>
        /// ������������
        /// </summary>
        public string IT_Name
        {
            set { _it_name = value; }
            get { return _it_name; }
        }

        /// <summary>
        /// �������ĸ����
        /// </summary>
        public Int64 IT_ParentID
        {
            set { _it_parentid = value; }
            get { return _it_parentid; }
        }
        /// <summary>
        /// �����ʹ�õ�ģ����
        /// Ĭ��Ϊ0,��ΪϵͳĬ�ϱ��
        /// </summary>
        public string ModuleName
        {
            set { _ModuleName = value; }
            get { return _ModuleName; }
        }

        /// <summary>
        /// ��������Id�б�
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
