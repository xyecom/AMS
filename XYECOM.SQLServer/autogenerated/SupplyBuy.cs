using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.SQLServer
{
    public class SupplyBuy
    {
        /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.SupplyBuyInfo info)
        {
            int num = 0;
            string sql =string.Format(@"insert into i_SupplyBuy 
                                    (Uid,Title,KeyWord,Contetns,[Name],Tel,AuditingState,Emergency,BuyNum,Area_ID)
                                     values ({0},'{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9})"
                                    , info.Uid,info.Title,info.KeyWord,info.Contents,info.U_name,info.Tel,info.State,info.Emergency,info.BuyNum,info.Area_id);
            num = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
            return num;
        }
        /// <summary>
        /// 更新一条信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(XYECOM.Model.SupplyBuyInfo info)
        {
            int num = 0;
            string sql = string.Format(@"update i_SupplyBuy  set Title='{0}',KeyWord='{1}',Contetns='{2}',Tel='{3}',Emergency={4},BuyNum={5},Area_ID={6},AuditingState={7} 
                                    where SD_ID={8}",info.Title,info.KeyWord,info.Contents,info.Tel, info.Emergency,info.BuyNum,info.Area_id,info.State,info.Id);
            num = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
            return num;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(long id)
        {
            int num = 0;
            string sql = "delete i_SupplyBuy where SD_ID= " + id;
            num = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
            return num;
        }

        /// <summary>
        /// 删除操作(批量删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string  ids)
        {
            int num = 0;
            string sql = string.Format("delete i_SupplyBuy where SD_ID  in ('{0}') ", ids);
            num = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
            return num;
        }
        /// <summary>
        /// 获取一个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XYECOM.Model.SupplyBuyInfo GetItem(long id)
        {
            XYECOM.Model.SupplyBuyInfo info = new Model.SupplyBuyInfo();
            string sql = "select * from i_SupplyBuy where SD_ID=" + id;
            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);
            foreach (DataRow item in table.Rows)
            {
                info.Id = id;
                info.Uid = XYECOM.Core.MyConvert.GetInt32( item["Uid"].ToString());
                info.Title = item["Title"].ToString();
                info.Contents = item["Contetns"].ToString();
                info.KeyWord = item["KeyWord"].ToString();
                info.Tel = item["Tel"].ToString();
                info.U_name = item["Name"].ToString();
                info.State =XYECOM.Core.MyConvert.GetInt32( item["AuditingState"].ToString());
                info.Time = item["PublishDate"].ToString();
                info.BuyNum = XYECOM.Core.MyConvert.GetInt32(item["BuyNum"].ToString());
                info.Emergency = XYECOM.Core.MyConvert.GetInt32(item["Emergency"].ToString());
                info.Area_id = XYECOM.Core.MyConvert.GetInt32(item["Area_ID"].ToString());
            }
            return info;
        }

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            string sql = "selete * from i_SupplyBuy";
            DataTable table = XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);
            return table;
        }
    }
}
