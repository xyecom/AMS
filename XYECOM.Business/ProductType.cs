using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{

    /// <summary>
    /// ��Ʒ����ҵ����
    /// </summary>
    public class ProductType
    {
        private static readonly XYECOM.SQLServer.ProductType DAL = new XYECOM.SQLServer.ProductType();

        /// <summary>
        /// ��Ӳ�Ʒ����
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.ProductTypeInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// �޸Ĳ�Ʒ������Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.ProductTypeInfo info)
        {
            if (info == null) return 0;

            int result = DAL.Update(info);

            if (result > 0)
            {
                string subIds = XYECOM.Business.XYClass.GetSubIds(info.ModuleName, info.PT_ID);

                subIds = Core.Utils.AppendComma(subIds);

                subIds = subIds.Replace("," + info.PT_ID + ",", ",").Replace(",,", ",");

                subIds = Core.Utils.RemoveComma(subIds);

                XYECOM.SQLServer.Utils.UpdateColumuByWhere("TradeId", info.TradeId.ToString(), " where PT_ID in(" + subIds + ")", "b_ProductType");
            }

            return result;
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="PT_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.ProductTypeInfo GetItem(long PT_ID)
        {
            if (PT_ID <= 0) return null;

            return DAL.GetItem(PT_ID);
        }

        /// <summary>
        /// ���ݷ����Ż�ȡ�ñ�ŵķ��༰�ñ�ŷ����µ���������
        /// </summary>
        /// <param name="parentId">������</param>
        /// <returns>���༯��</returns>
        public List<Model.ProductTypeInfo> GetItems(int parentId)
        {
            if (parentId < 0)
            {
                return null;
            }
            return DAL.GetItems(parentId);
        }


        /// <summary>
        /// ͨ��Ψһ��ʶ����ȡ������Ϣ
        /// </summary>
        /// <param name="flagName">Ψһ��ʾ��</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.ProductTypeInfo GetItemByFlagName(string flagName)
        {
            if (string.IsNullOrEmpty(flagName) || flagName.Trim().Equals("")) return null;

            return DAL.GetItemByFlagName(flagName);
        }

        /// <summary>
        /// �������з�����󼯺�
        /// </summary>
        /// <returns>���з�����󼯺�</returns>
        public List<Model.ProductTypeInfo> GetItems()
        {
            return DAL.GetItems();
        }

        /// <summary>
        /// ��ȡ��Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_ParentID">
        /// ��� PT_ParentID ���ڵ��� 0 ���ز��ֲ�Ʒ������Ϣ
        /// ���� �������еĲ�Ʒ������Ϣ
        /// </param>
        /// <returns>������Ʒ������Ϣ</returns>
        public DataTable GetDataTable(long PT_ParentID)
        {
            return DAL.GetDataTable(PT_ParentID);
        }

        /// <summary>
        /// ��ȡָ����Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_IDs">��Ʒ���</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string PT_IDs)
        {
            return DAL.GetDataTable(PT_IDs);
        }

        /// <summary>
        /// ��ȡָ����Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_IDs">��Ʒ���</param>
        /// <param name="M_ID">ģ����</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(long PT_ParentID, string moduleName)
        {
            return DAL.GetDataTable(PT_ParentID, moduleName);
        }


        /// <summary>
        /// ɾ��һ����Ʒ������Ϣ
        /// </summary>
        /// <param name="PT_ID">���ͱ��</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string PT_ID)
        {
            return DAL.Delete(PT_ID);
        }

        /// <summary>
        /// ��ȡ��ǰ�����ǵڼ���
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public int GetStep(long typeId)
        {
            Model.ProductTypeInfo info = GetItem(typeId);

            if (info == null) return 0;

            if (info.PT_ParentID == 0) return 1;

            string fullId = Core.Utils.RemoveComma(info.FullId);

            string[] ids = fullId.Split(',');

            return ids.Length + 1;
        }


        public XYECOM.Model.ProductTypeInfo GetItemByTypeName(string keyword)
        {
            Model.ProductTypeInfo info = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                info = DAL.GetItemByTypeName(keyword);
            }
            return info;
        }

        /// <summary>
        /// ͨ������ID��ȡ�÷�����Ϣ ��������� 2011-03-30��
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>������Ϣ</returns>
        public Model.ProductTypeInfo GetProTypeById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return DAL.GetProTypeById(id);
        }

        /// <summary>
        /// ͨ�������Ż�ȡѡ��ķ����Լ����Ը����ķ������� ��������� 2011-03-30��
        /// </summary>
        /// <param name="typeId">������</param>
        /// <returns>�ȹط�������</returns>
        public string GetProductTypeNameByTypeId(int typeId)
        {
            if (typeId < 0)
            {
                return string.Empty;
            }
            return DAL.GetProductTypeNameByTypeId(typeId);
        }
    }
}
