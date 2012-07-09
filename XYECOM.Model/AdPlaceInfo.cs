using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model 
{
	 /// <summary>
	 ///���λ��Ϣʵ����
	 /// </summary>
	public class AdPlaceInfo 
	{
		private long _ap_id;
		private string _ap_name;
		private string _ap_alt;
        private int _at_id;
        private bool _ap_isuse;

		public AdPlaceInfo() {
            _ap_id = 0;
            _ap_name = "";
            _ap_alt = "";
            _ap_id = 0;
            _ap_isuse = false;
        }
		  /// <summary>
		  /// ���λ�ı��
		  /// </summary>
		public long AP_ID 
		{
			set { _ap_id = value; }
			get { return _ap_id; }
		}
		  /// <summary>
		  /// ���λ������
		  /// </summary>
		public string AP_Name 
		{
			set { _ap_name = value; }
			get { return _ap_name; }
		}
		  /// <summary>
		  /// ���λ��ע��˵��
		  /// </summary>
		public string AP_Alt 
		{
			set { _ap_alt = value; }
			get { return _ap_alt; }
		}
         /// <summary>
         /// ���λ���IDֵ
         /// </summary>
        public int AT_ID
        {
            set { _at_id = value; }
            get { return _at_id; }
        }

        public bool AP_IsUse
        {
            set { _ap_isuse = value; }
            get { return _ap_isuse; }
        }
	}
}
