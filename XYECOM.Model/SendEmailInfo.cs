using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 邮件信息实体类
    /// </summary>
     public class SendEmailInfo
    {
      private System.Int32 _E_ID;
      private string _E_title;
      private string _E_content;
      private string _U_IDS;
      private DateTime addTime;

      public System.Int32 E_ID
      {
          set { _E_ID = value; }
          get { return _E_ID; }
      }
      public string E_title
      {
          set { _E_title = value; }
          get { return _E_title; }
      }
      public string E_content
      {
          set { _E_content = value; }
          get { return _E_content; }
      }
      public string U_IDS
      {
          set { _U_IDS = value; }
          get { return _U_IDS; }
      }

      public DateTime AddTime
      {
          set { addTime = value; }
          get { return addTime; }
      }
    }

}
