using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Business
{
    public class newlist
    {
        private static readonly XYECOM.SQLServer.newlist DAL = new XYECOM.SQLServer.newlist();

        /// <summary>
        /// 更改用户资讯信息状态（推荐，置顶） jerome
        /// </summary>        
        /// <param name="lstId">资讯信息Ids</param>
        /// <param name="State">状态</param>
        /// <returns>返回影响行数</returns>
        public int changeStateInfo(string lstId, int State)
        {
            string[] lstIdArry = lstId.Split(',');
            string Str="";

            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }

            for (int i = 0; i < lstIdArry.Length; i++)
            {
                XYECOM.Model.UserNewsInfo newsInfo = DAL.GetUserNewsInfoById(lstIdArry[i]);
                if (!(newsInfo.State == (int)XYECOM.Model.UserNewsFlagInfo.Normal))
                {
                    if (newsInfo != null && newsInfo.State % State != 0)
                    {
                        Str += lstIdArry[i] + ",";
                    }
                }
                else 
                {
                    Str += lstIdArry[i] + ",";
                }
            }
            if (Str == "")
                return lstIdArry.Length;

            Str = Str.Substring(0, Str.Length - 1);

            return DAL.changeStateInfo(Str, State);
        }

        /// <summary>
        /// 更改用户资讯信息状态（取消推荐，取消置顶） jerome
        /// </summary>        
        /// <param name="lstId">资讯信息Ids</param>
        /// <param name="State">状态</param>
        /// <returns>返回影响行数</returns>
        public int unChangeStateInfo(string lstId, int State)
        {
            string[] lstIdArry = lstId.Split(',');
            string Str = "";

            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }

            for (int i = 0; i < lstIdArry.Length; i++)
            {
                XYECOM.Model.UserNewsInfo newsInfo = DAL.GetUserNewsInfoById(lstIdArry[i]);
                if (!(newsInfo.State == (int)XYECOM.Model.UserNewsFlagInfo.Normal))
                {
                    if (newsInfo != null && newsInfo.State % State == 0)
                    {
                        Str += lstIdArry[i] + ",";
                    }
                }
            }
            if (Str == "")
                return lstIdArry.Length;

            Str = Str.Substring(0, Str.Length - 1);

            return DAL.unChangeStateInfo(Str, State);
        }
    }
}
