using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace XYECOM.SQLServer
{
    public class NewsSource
    {
        public IList<XYECOM.Model.NewsSourceInfo> GetList(int count, string newstypeId, bool today)
        {
            IList<XYECOM.Model.NewsSourceInfo> list = new List<XYECOM.Model.NewsSourceInfo>();

            string where = string.IsNullOrEmpty(newstypeId) || newstypeId == "0" ? "1=1" : "charindex('," + newstypeId + ",',NT_ID) > 0";
            where += today ? " and datediff(day,NS_AddTime,getdate())=0" : "";
            
            XYECOM.Model.NewsSourceInfo info = null;

            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top",count),
				new SqlParameter("@Columns","*"),
				new SqlParameter("@Table","XYV_News"),
				new SqlParameter("@Where",where),
				new SqlParameter("@Order","NS_AddTime Desc")
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                while (reader.Read())
                {
                    info = new XYECOM.Model.NewsSourceInfo();
                    info.NewsId = int.Parse(reader["NS_ID"].ToString());

                    info.Type = XYECOM.Model.NewsType.TextNews;

                    string newsType = reader["NS_Type"].ToString();
                    if (newsType.Equals("2"))
                        info.Type = XYECOM.Model.NewsType.ImageNews;
                    if (newsType.Equals("3"))
                        info.Type = XYECOM.Model.NewsType.HeadlineNews;

                    info.Title = reader["NS_NewsName"].ToString();

                    info.SubTitle = reader["NS_TwoName"].ToString();

                    info.TitleStyle = reader["NS_TitleStyle"].ToString();

                    info.TypeIds = reader["NT_ID"].ToString();

                    info.Keyword = reader["NS_KeyWord"].ToString();
                    info.Leadin = reader["NS_NewsLess"].ToString();
                    info.HeadlineNewsUrl = reader["NS_LinkAddress"].ToString();
                    info.PicUrl = reader["NS_PicUrl"].ToString();
                    info.Author = reader["NS_NewsAuthor"].ToString();
                    info.Origin = reader["NS_NewsOrigin"].ToString();

                    info.AddTime = reader["NS_AddTime"].ToString();

                    info.ClickNumber = XYECOM.Core.MyConvert.GetInt32(reader["NS_Count"].ToString());

                    info.Content = reader["NS_NewsNote"].ToString();

                    if (reader["AuditingState"].ToString() != "")
                    {
                        if (reader["AuditingState"].ToString().Equals("1"))
                            info.State = XYECOM.Model.AuditingState.Passed;
                        else
                            info.State = XYECOM.Model.AuditingState.NoPass;
                    }
                    else
                    {
                        info.State = XYECOM.Model.AuditingState.Null;
                    }


                    info.IsCommend = Convert.ToBoolean(reader["NS_IsCommand"].ToString());

                    info.HTMLPage = reader["NS_HTMLPage"].ToString();

                    info.IsAllowComment = Convert.ToBoolean(reader["NS_IsDiscuss"].ToString());

                    info.IsTop = Convert.ToBoolean(reader["NS_IsTop"].ToString());

                    info.IsHot = Convert.ToBoolean(reader["NS_IsHot"].ToString());

                    info.IsSlide = Convert.ToBoolean(reader["NS_IsSlide"].ToString());

                    info.TopicType = reader["TopicType"].ToString();

                    info.ChargeState = reader["IsChargeNews"].ToString();

                    info.Contributor = Convert.ToInt64(reader["Contributor"].ToString());

                    info.AreaIds = reader["AreaIds"].ToString();

                    info.TradeIds = reader["TradeIds"].ToString();
                    info.FileUrl = reader["FileUrl"].ToString();
                    info.ProtypeIds = reader["ProtypeIds"].ToString();

                    info.TempletFolderAddress = reader["NT_TempletFolderAddress"].ToString();
                    info.DomainName = reader["DomainName"].ToString();

                    info.IsHasImage = XYECOM.Core.MyConvert.GetInt32(reader["IsHasImage"].ToString());
                    info.CategoryName = reader["NT_Name"].ToString();

                    list.Add(info);
                }
            }

            return list;
        }
    }
}
