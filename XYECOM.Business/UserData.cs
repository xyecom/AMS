using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// �û�����ҵ����
    /// </summary>
    public class UserData
    {
        public static readonly XYECOM.SQLServer.UserData DAL = new XYECOM.SQLServer.UserData();

        /// <summary>
        /// ����û�����
        /// </summary>
        /// <param name="userdata">�û�����ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserData userdata) { 
            if (null == userdata) return 0;
            return DAL.Insert(userdata);
        }

        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="userdata">�û�����ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.UserData userdata) {
            if (null == userdata) return 0;
            return DAL.Update(userdata);
        }

        /// <summary>
        /// ��ȡһ���û�����
        /// </summary>
        /// <param name="uid">�û����Id</param>
        /// <returns>ʵ�����</returns>
        public Model.UserData GetItem(Int64 uid) {
            if (uid <= 0) return null;
            return DAL.GetItem(uid);
        }
    }
}
 