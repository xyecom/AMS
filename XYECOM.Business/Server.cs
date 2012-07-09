using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 服务器业务类
    /// </summary>
    public class Server
    {
        private static readonly XYECOM.SQLServer.Server DAL = new XYECOM.SQLServer.Server();

        /// <summary>
        /// 添加服务器信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.ServerInfo es)
        {
            return DAL.Insert(es);
        }

        /// <summary>
        /// 修改服务器信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.ServerInfo es)
        {
            return DAL.Update(es);
        }

        /// <summary>
        /// 修改服务器状态
        /// </summary>
        /// <param name="ID">服务器编号Id</param>
        /// <returns>影响行数</returns>
        public int UpdateIsCurrent(int ID)
        {
            return DAL.UpdateIsCurrent(ID);        
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="S_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.ServerInfo GetItem(int S_ID)
        {
            return DAL.GetItem(S_ID);
        }
        /// <summary>
        /// 获取图片的服务器的编号
        /// </summary>
        /// <returns>图片服务器编号</returns>
        public int GetCurrentServerID()
        {
            return DAL.GetCurrentServerID();
        }
        /// <summary>
        /// 获取当前可用的文字服务器的编号
        /// </summary>
        /// <returns>文字服务器编号</returns>
        public int GetCharacterServerID()
        {
            return DAL.GetCharacterServerID();
        }
        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>记录集</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="S_ID">服务器编号Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int S_ID)
        {
            return DAL.Delete(S_ID);
        }
        /// <summary>
        /// 判断在附近表里是否存在
        /// </summary>
        /// <returns>是否存在</returns>
        public bool IsUsed(int S_ID) 
        {
            return DAL.IsUsed(S_ID);
        }
    }
}
