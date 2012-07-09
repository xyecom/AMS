using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.DataSourceManager.cs
     * 创建标识：TC 20080618
     * 
     * 功能描述：标签数据源处理类
     * 
     *************************************************/

    /// <summary>
    /// 标签数据源管理类
    /// </summary>
    internal class DataSourceManager
    {
        /// <summary>
        /// 获取具体标签的数据源名称
        /// </summary>
        /// <param name="labelFlag">标签数据源标识</param>
        /// <returns></returns>
        public static string GetDataSourceName(string labelFlag)
        {
            string dataSourceName = "";

            labelFlag = labelFlag.ToLower().Trim();

            switch (labelFlag)
            {
                case "associatorlist":
                    dataSourceName = "XYV_Individual";
                    break;
                case "showlist":
                    dataSourceName = "XYV_ShowInfo";
                    break;
                case "corporationlist":
                    dataSourceName = "XYV_UserInfo";
                    break;
                case "newslist":
                    dataSourceName = "XYV_News";
                    break;
                case "friendlink":
                    dataSourceName = "XYV_FriendLink";
                    break;
                case "showpagelist":
                    dataSourceName = "XYV_ShowInfo";
                    break;
                case "corporationpagelist":
                    dataSourceName = "XYV_UserInfo";
                    break;
                case "associatorpagelist":
                    dataSourceName = "XYV_Individual";
                    break;
                case "newspagelist":
                    dataSourceName = "XYV_News";
                    break;
                case "channelpagelist":
                    dataSourceName = "XYV_News";
                    break;
                case "advertisinglist":
                    dataSourceName = "XYV_AdInfo";
                    break;
                case "topiclist":
                case "topicpagelist":
                    dataSourceName = "xy_Topic";
                    break;
                case "hotkeyword":
                    dataSourceName = "b_searchkey";
                    break;
                case "usernews":
                    dataSourceName ="xyv_usernews";
                    break;
                case "baikepagelist":
                case "baikelist":
                    dataSourceName = "XY_Lemma";
                    break;
                case "votelist":
                    dataSourceName = "XY_Vote";
                    break;
                case "supplybuylist":
                case "supplybuypagelist":
                    dataSourceName = "XYV_SupplyBuy";
                    break;
                case "teambuylist":
                case "teambuypagelist":
                    dataSourceName = "XY_TeamBuy";
                    break;
            }
            return dataSourceName;
        }

        /// <summary>
        /// 获取具体标签的数据源名称
        /// </summary>
        /// <param name="labelFlag">标签标识名称</param>
        /// <param name="labelBody">标签体</param>
        /// <returns></returns>
        public static string GetDataSourceName(string labelFlag,string labelBody)
        {
            string dataSourceName = "";

            labelFlag = labelFlag.ToLower().Trim();

            switch (labelFlag)
            {
                case "supplykeypagelist":
                case "supplypagelist":
                case "supplylist":
                    dataSourceName = "XYV_Supply";
                    break;
                case "demandlist":
                case "demandpagelist":
                case "machiningkeypagelist":
                    dataSourceName = "XYV_Demand";
                    break;
                case "businesslist":
                case "businesspagelist":
                case "investmentkeypagelist":
                    dataSourceName = "XYV_InviteBusinessmanInfo";
                    break;
                case "surrogatepagelist":
                case "surrogatelist":
                case "servicekeypagelist":
                    dataSourceName = "XYV_ServiceInfo";
                    break;
                case "engagelist":
                case "engagepagelist":
                    dataSourceName = "XYV_Engageinfo";
                    break;
                case "corporationlist":
                case "corporationpagelist":
                    dataSourceName = "XYV_UserInfo";
                    break;                
                case "usernews":
                    dataSourceName = "XYV_UserNews";
                    break;
                case "usernewslist":
                case "usernewspagelist":
                    dataSourceName = "XYV_UserNews";
                    break;
                case "baikepagelist":
                case "baikelist":
                    dataSourceName = "XY_Lemma";
                    break;
                case "supplybuylist":
                case "supplybuypagelist":
                    dataSourceName = "XYV_SupplyBuy";
                    break;
            }
            return dataSourceName;
        }
    }
}
