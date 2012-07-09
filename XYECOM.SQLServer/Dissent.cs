using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 数据访问类Dissent。
    /// </summary>
    public class Dissent
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.DissentInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@Id",info.Id),
					new SqlParameter("@OrderId",info.OrderId),
					new SqlParameter("@DissentType",info.DissentType),
					new SqlParameter("@Description",info.Description),
					new SqlParameter("@RefundMoney",info.RefundMoney),
					new SqlParameter("@GoodsOrInvoice",info.GoodsOrInvoice),
					new SqlParameter("@InsertTime",info.InsertTime),
                    new SqlParameter("@OrderType",info.OrderType)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertDissent", param);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.DissentInfo info, out int id)
        {
            SqlParameter[] param = new SqlParameter[]
            { 
					new SqlParameter("@Id",info.Id),
					new SqlParameter("@OrderId",info.OrderId),
					new SqlParameter("@DissentType",info.DissentType),
					new SqlParameter("@Description",info.Description),
					new SqlParameter("@RefundMoney",info.RefundMoney),
					new SqlParameter("@GoodsOrInvoice",info.GoodsOrInvoice),
					new SqlParameter("@InsertTime",info.InsertTime),
            };

            param[0].Direction = ParameterDirection.Output;

            int Tmp = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertDissent", param);

            if (Tmp > 0)
            {
                if (param[0].Value != null)
                    id = int.Parse(param[0].Value.ToString());
                else
                    id = 0;
            }
            else
            {
                id = 0;
            }

            return Tmp;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.DissentInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
					new SqlParameter("@Id",info.Id),
					new SqlParameter("@OrderId",info.OrderId),
					new SqlParameter("@DissentType",info.DissentType),
					new SqlParameter("@Description",info.Description),
					new SqlParameter("@RefundMoney",info.RefundMoney),
					new SqlParameter("@GoodsOrInvoice",info.GoodsOrInvoice),
					new SqlParameter("@InsertTime",info.InsertTime),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateDissent", param);
        }


        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="infoId">记录编号</param>
        /// <returns>数据对象</returns>
        public XYECOM.Model.DissentInfo GetItem(int infoId)
        {
            XYECOM.Model.DissentInfo model = null;
            SqlParameter[] Parame = new SqlParameter[] 
            {
				new SqlParameter("@Top","0"),
				new SqlParameter("@Columns",""),
				new SqlParameter("@Table","XY_Dissent"),
				new SqlParameter("@Where","Id = " + infoId.ToString()),
				new SqlParameter("@Order","")
            };
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_CommonSelect", Parame))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.DissentInfo();

                    model.Id = Convert.ToInt32(rdr["Id"].ToString());
                    model.OrderId = Convert.ToInt32(rdr["OrderId"].ToString());
                    model.DissentType = rdr["DissentType"].ToString();
                    model.Description = rdr["Description"].ToString();
                    model.RefundMoney = Convert.ToDecimal(rdr["RefundMoney"].ToString());
                    model.GoodsOrInvoice = rdr["GoodsOrInvoice"].ToString();
                    model.InsertTime = Convert.ToDateTime(rdr["InsertTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 删除一条或多条记录
        /// </summary>
        /// <param name="infoIds">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string infoIds)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Where"," Id in (" + infoIds.ToString() + ") "),
                new SqlParameter("@TableName","XY_Dissent")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_CommonDelete", param);
        }

        /// <summary>
        /// 获取所有列表
        /// </summary>        
        /// <returns>获取所有列表</returns>
        public DataTable GetList()
        {
            SqlParameter[] Parame = new SqlParameter[]
            {
                new SqlParameter("@Top",""),
                new SqlParameter("@Columns","*"),
                new SqlParameter("@Table","XY_Dissent"),
                new SqlParameter("@Where","1=1"),
                new SqlParameter("@Order","")
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_CommonSelect", Parame);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="goodsorinvoice"></param>
        /// <returns></returns>
        public XYECOM.Model.DissentInfo GetItem(string orderid, string goodsorinvoice)
        {
            XYECOM.Model.DissentInfo model = null;
            //SqlParameter[] Parame = new SqlParameter[] 
            //{
            //    new SqlParameter("@Top","1"),
            //    new SqlParameter("@Columns","*"),
            //    new SqlParameter("@Table","XY_Dissent"),
            //    new SqlParameter("@Where","((OrderId=" + orderid + ") and (GoodsOrInvoice='" + goodsorinvoice + "'))"),
            //    new SqlParameter("@Order","")
            //};
            string sql = string.Format( "select * from XY_Dissent where OrderId={0} and GoodsOrInvoice='{1}'",orderid,goodsorinvoice);
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(sql))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.DissentInfo();

                    model.Id = Convert.ToInt32(rdr["Id"].ToString());
                    model.OrderId = Convert.ToInt32(rdr["OrderId"].ToString());
                    model.DissentType = rdr["DissentType"].ToString();
                    model.Description = rdr["Description"].ToString();
                    model.RefundMoney = Convert.ToDecimal(rdr["RefundMoney"].ToString());
                    model.GoodsOrInvoice = rdr["GoodsOrInvoice"].ToString();
                    model.InsertTime = Convert.ToDateTime(rdr["InsertTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 根据订单编号，订单类型，异议类型获取异议信息
        /// </summary>
        /// <param name="orderid">订单编号</param>
        /// <param name="goodsorinvoice">异议类型</param>
        /// <param name="orderType">订单类型</param>
        /// <returns>异议信息</returns>
        public XYECOM.Model.DissentInfo GetItem(string orderid, string goodsorinvoice,int orderType)
        {
            XYECOM.Model.DissentInfo model = null;
            string sql = string.Format("select * from XY_Dissent where OrderId={0} and GoodsOrInvoice='{1}' and ordertype = {2}", orderid, goodsorinvoice,orderType);
            using (SqlDataReader rdr = XYECOM.Core.Data.SqlHelper.ExecuteReader(sql))
            {
                if (rdr.Read())
                {
                    model = new XYECOM.Model.DissentInfo();

                    model.Id = Convert.ToInt32(rdr["Id"].ToString());
                    model.OrderId = Convert.ToInt32(rdr["OrderId"].ToString());
                    model.DissentType = rdr["DissentType"].ToString();
                    model.Description = rdr["Description"].ToString();
                    model.RefundMoney = Convert.ToDecimal(rdr["RefundMoney"].ToString());
                    model.GoodsOrInvoice = rdr["GoodsOrInvoice"].ToString();
                    model.InsertTime = Convert.ToDateTime(rdr["InsertTime"].ToString());
                }
            }
            return model;
        }
    }
}
