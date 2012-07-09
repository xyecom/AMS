using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    /// <summary>
    /// �ղ���Ϣʵ����
    /// </summary>
    public class FavoriteInfo
    {
        private long  _fa_id;
        private long  _u_id;
        private long  _desctabid;
        private string _desctabname;
        private DateTime _at_pulishdate;

        public FavoriteInfo()
        {
            _fa_id = 0;
            _u_id = 0;
            _desctabid = 0;
            _desctabname = "";
            _at_pulishdate = DateTime.Now;
        }


        /// <summary>
        /// �ղر��
        /// </summary>
        public long  Fa_ID
        {
            set { _fa_id = value; }
            get { return _fa_id; }
        }
        /// <summary>
        /// �����߱��
        /// </summary>
        public long  U_ID
        {
            set { _u_id = value; }
            get { return _u_id; }
        }
        /// <summary>
        /// Ŀ�����
        /// </summary>
        public long  DescTabID
        {
            set { _desctabid = value; }
            get { return _desctabid; }
        }
        /// <summary>
        /// Ŀ�������
        /// </summary>
        public string DescTabName
        {
            set { _desctabname = value; }
            get { return _desctabname; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime At_PulishDate
        {
            set { _at_pulishdate = value; }
            get { return _at_pulishdate; }
        }
    }

}
