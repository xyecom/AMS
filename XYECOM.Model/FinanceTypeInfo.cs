using System;
using System.Collections.Generic;
using System.Text;


namespace XYECOM.Model
{
    #region �����������
    /// <summary>
    /// ������Ϣ������Ϣʵ����
    /// </summary>
    public class FinanceTypeInfo
    {
        private System.Int32 _FT_ID;
        private string _FT_Type;

        public FinanceTypeInfo()
        {
            _FT_ID = 0;
            _FT_Type = "";
        }

        public System.Int32 FT_ID
        {
            set { _FT_ID = value; }
            get { return _FT_ID; }
        }
        public string FT_Type
        {
            set { _FT_Type = value; }
            get { return _FT_Type; }
        }
    }
    #endregion
}
