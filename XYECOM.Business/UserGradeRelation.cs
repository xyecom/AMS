using System;
using System.Collections.Generic;
using System.Text;

using System.Data ;

namespace XYECOM.Business
{
    
    /// <summary>
    /// �û��ȼ�ҵ����
    /// </summary>
    public class UserGradeRelation
    {
        private static readonly XYECOM.SQLServer.UserGradeRelation DAL = new XYECOM.SQLServer.UserGradeRelation();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserGradeRelationInfo info)
        {
            return DAL.Insert(info);
        }
      
        /// <summary>
        /// ��ȡһ����Ϣ
        /// </summary>
        /// <param name="userId">�û����Id</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserGradeRelationInfo GetItem(long userId)
        {
            return DAL.GetItem(userId);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateGradeRelation(Model.UserGradeRelationInfo info)
        {
            if (info == null) return 0;

            return DAL.UpdateGradeRelation(info);
        }
    }

}
