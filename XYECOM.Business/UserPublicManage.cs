using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Business
{
    public class UserPublicManage
    {
        private XYECOM.SQLServer.UserPublicAccess access = new SQLServer.UserPublicAccess();
        /// <summary>
        /// 根据用户编号获取实体信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public XYECOM.Model.UserPublic GetItem(int userId)
        {
            if(userId<=0)
            {
                return null;
            }
            return access.GetItem(userId);
        }
    }
}
