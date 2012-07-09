using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �շ������շ���Ϣʵ����
    /// </summary>
    public class ChargeNewsInfo
    {
        private Int64 _ci_id;
        private Int64 _u_id;
        private Int64 _ns_id;
        private DateTime _ci_addtime;

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public ChargeNewsInfo() { }

        /// <summary>
        /// ����ֵ�ù��캯��
        /// </summary>
        /// <param name="ciid"></param>
        /// <param name="uid"></param>
        /// <param name="nsid"></param>
        /// <param name="aiaddtime"></param>
        public ChargeNewsInfo(Int64 ciid,Int64 uid,Int64 nsid,DateTime aiaddtime)
        {
            this._ci_id = ciid;
            this._u_id = uid;
            this._ns_id = nsid;
            this._ci_addtime = aiaddtime;
        }

        /// <summary>
        /// �շ���Ϣ���
        /// </summary>
        public Int64 CI_ID
        {
            get { return _ci_id; }
            set { _ci_id = value; }
        }

        /// <summary>
        /// ����Ϣ��ʹ���û����
        /// </summary>
        public Int64 U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }

        /// <summary>
        /// ���û��������ŵı��
        /// </summary>
        public Int64 NS_ID
        {
            get { return _ns_id; }
            set { _ns_id = value; }
        }

        /// <summary>
        /// �����ű������ʱ��
        /// </summary>
        public DateTime CI_AddTime
        {
            get { return _ci_addtime; }
        }
    }
}
