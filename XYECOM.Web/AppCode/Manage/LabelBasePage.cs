using System;

namespace XYECOM.Web.BasePage
{
    public class LabelBasePage : ManagePage
    {
        private string lid = "";
        private int userid;

        /// <summary>
        /// 标签所属的用户的编号
        /// </summary>
        protected int LabelUserId
        {
            get
            {
                return userid;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {   
            if (!IsPostBack)
            {
                lid = Request.QueryString["lid"];

                userid = XYECOM.Core.XYRequest.GetInt("uid", 0); ;

                if (!string.IsNullOrEmpty(lid))
                {
                    MyDictionary table = GetData(lid);
                    if (table.Count > 0)
                    {
                        this.InitPageValue(table);
                    }
                }
            }
            base.OnLoad(e);
        }

        protected virtual void InitPageValue(MyDictionary table)
        { }

        protected virtual MyDictionary GetData(string label)
        {
            MyDictionary table = new MyDictionary();

            XYECOM.Business.Label le = new XYECOM.Business.Label();

            XYECOM.Model.LabelInfo el = null;

            if (!string.IsNullOrEmpty(label))
            {
                long labelId = XYECOM.Core.MyConvert.GetInt64(label);
                if (labelId > 0)
                {
                    el = le.GetItem(labelId);
                }
            }

            if (el != null)
            {
                if (el.LabelRange == XYECOM.Model.LabelRange.User)
                {
                    userid = XYECOM.Core.MyConvert.GetInt32(el.GroupIdOrUserId);
                }
                string content = el.LabelContent;

                content = content.Substring(1, content.Length - 2);

                string[] strayy = content.Split(new char[] { '┆' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string str in strayy)
                {
                    string[] tmparr = str.Split(new char[] { '$' }, StringSplitOptions.None);
                    if (tmparr.Length == 2)
                    {
                        string s = tmparr[1];
                        if (s.Contains(@"\"))
                        {
                            s = s.Replace(@"\", @"\\");
                        }
                        //if(s==@"MM\dd")
                        //{
                        //    s = @"MM\\dd";
                        //}
                        table.Add(tmparr[0].ToUpper(), s);
                    }
                }
            }
            return table;
        }
    }
}
