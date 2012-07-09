using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
namespace XYECOM.Business
{
    /// <summary>
    /// ������Ϣҵ����
    /// </summary>
    public class Supply
    {
        private static readonly XYECOM.SQLServer.Supply DAL = new XYECOM.SQLServer.Supply();
        /// <summary>
        /// ��ӹ���Ա��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.SupplyInfo info, out int infoId)
        {
            infoId = 0;

            if (info == null) return 0;

            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// �޸Ĺ�Ӧ��Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.SupplyInfo es)
        {
            return DAL.Update(es);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.SupplyInfo GetItem(int SD_ID)
        {
            return DAL.GetItem(SD_ID);
        }


       
        /// <summary>
        /// ��ȡ������¼
        /// </summary>
        /// <param name="��_ID">������ѯ</param>
        /// <returns>������¼</returns>
        public DataTable GetDataTable(long U_ID)
        {
            return DAL.GetDataTable(U_ID);
        }
        /// <summary>
        /// ɾ��һ��������Ϣ
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(long supplyId)
        {
            new XYECOM.Business.Attachment().Delete(supplyId, XYECOM.Model.AttachmentItem.Supply, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(supplyId);
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Deletes(string ids)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Supply, XYECOM.Model.UploadFileType.All);

            return DAL.Deletes(ids);

        }
        /// <summary>
        /// �޸��Ƽ���Ϣ
        /// </summary>
        /// <param name="es">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateVouch(XYECOM.Model.SupplyInfo es)
        {
            return DAL.UpdateVouch(es);
        }
        /// <summary>
        /// �޸���ͣ��Ϣ
        /// </summary>
        /// <param name="SD_ID">���</param>
        /// <returns></returns>
        public int UpdatePause(string SD_ID)
        {
            return DAL.UpdatePause(SD_ID);
        }

        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int MoveSupply(String strwhere, String content)
        {
            return DAL.MoveSupply(strwhere, content);
        }
        #endregion

        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ�ò�Ʒ����ϸ��Ϣ��������� 2011-03-30��
        /// </summary>
        /// <param name="id">��ƷID</param>
        /// <returns>��Ʒ����ϸ��Ϣ</returns>
        public XYECOM.Model.SupplyInfo GetSupplyById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return DAL.GetSupplyById(id);
        }
        /// <summary>
        /// ����Ʒ��id ��ȡ��id�����õĲ�Ʒ��
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForBrandId(int brandId)
        {
            return DAL.GetBrandSupplyForBrandId(brandId);
        }
           /// <summary>
        /// ���ݼ���id ��ȡ��id�����õĲ�Ʒ��
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public int GetBrandSupplyForUnitId(int UnitId)
        {
            return DAL.GetBrandSupplyForUnitId(UnitId);
        }
        /// <summary>
        /// ����һ����Ʒ��Ϣ (������� 2011-04-01)
        /// </summary>
        /// <param name="supply">��Ʒ��Ϣ</param>
        /// <param name="id">�����Ĳ�ƷID</param>
        /// <returns>���������Ĳ�ƷID</returns>
        public int InsertSupply(Model.SupplyInfo supply, out int infoId)
        {
            infoId = 0;
            if (supply != null)
            {
                return DAL.InsertSupply(supply, out infoId);
            }
            return 0;
        }

        /// <summary>
        /// ���ݲ�Ʒ����޸Ĳ�Ʒ��Ϣ (�������2011-04-01)
        /// </summary>
        /// <param name="supply">��Ʒ��Ϣ</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateSupply(Model.SupplyInfo supply)
        {
            if (supply == null || supply.InfoID < 1)
            {
                return 0;
            }
            return DAL.UpdateSupply(supply);
        }


        /// <summary>
        /// ���û�Ա�̻���Ϣ��ͣ (������� 2011-04-07)
        /// </summary>
        /// <param name="lstId">�̻���ż���</param>
        /// <param name="state">״̬ trueΪ���ã�falseͣ��</param>
        /// <returns>����Ӱ������</returns>
        public int UpdateSupplyState(string lstId, bool state)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.UpdateSupplyState(lstId, state);
        }

        /// <summary>
        /// �Ƽ���Ա�̻���Ϣ������,�������ȡ���Ƽ�  (������� 2011-04-07)
        /// </summary>
        /// <param name="lstId">�̻���ż���</param>
        /// <param name="state">״̬ trueΪ�Ƽ���falseȡ���Ƽ�</param>
        /// <returns>����Ӱ������</returns>
        public int RecommendToShop(string lstId, bool state)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.RecommendToShop(lstId, state);
        }

        /// <summary>
        /// ˢ�»�Ա���̻���Ϣ (������� 2011-04-07)
        /// </summary>        
        /// <param name="lstId">�̻���ż���</param>
        /// <returns>����Ӱ������</returns>
        public int ReSendInfo(string lstId)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.ReSendInfo(lstId);
        }

        /// <summary>
        /// ���ݲ�Ʒ����߼�ɾ����Ʒ��Ϣ (������� 2011-04-07)
        /// </summary>
        /// <param name="lstId">��Ʒ���</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateDeleteById(string lstId)
        {
            if (string.IsNullOrEmpty(lstId))
            {
                return 0;
            }
            return DAL.UpdateDeleteById(lstId);
        }

        /// <summary>
        /// ���ݹ��������͵�ǰ��Ʒ�ļ۸�����������ǰ�� (������� 2011-04-07)
        /// </summary>
        /// <param name="proCount">����Ĳ�Ʒ����</param>
        /// <param name="pid">��ƷID</param>
        /// <returns>��ǰ�ļ۸�</returns>
        public decimal GetProductPrice(int pid, int proCount)
        {
            if (pid <= 0 || proCount <= 0)
            {
                return 0;
            }
            return DAL.GetProductPrice(pid, proCount);
        }

        /// <summary>
        /// ���ݹ��������͵�ǰ��Ʒ�ļ۸�����������ǰ�۸����� (������� 2011-04-11)
        /// </summary>
        /// <param name="proCount">����Ĳ�Ʒ����</param>
        /// <param name="pid">��ƷID</param>
        /// <returns>��ǰ�ļ۸�����</returns>
        public int GetProductOrderNum(int pid, int proCount)
        {
            if (pid <= 0 || proCount <= 0)
            {
                return 0;
            }
            return DAL.GetProductOrderNum(pid, proCount);
        }

        /// <summary>
        /// ���ݲ�Ʒ��Ż�ȡ�ò�Ʒ������������������� 2011-04-13��
        /// </summary>
        /// <param name="supplyId">��ƷID</param>
        /// <returns>��������</returns>
        public int GetSmallNum(int supplyId)
        {
            if (supplyId <= 0)
            {
                return 0;
            }
            return DAL.GetSmallNum(supplyId);
        }

        /// <summary>
        ///���ݲ�Ʒ��Ż�ȡ��Ʒ����
        /// </summary>
        /// <param name="suppid">��Ʒ���</param>
        /// <returns>��Ʒ����</returns>
        public string GetSupplyNameById(int suppid)
        {
            if (suppid <= 0)
            {
                return string.Empty;
            }
            return DAL.GetSupplyNameById(suppid);
        }

        /// <summary>
        /// ����һ���Ʒ��ţ���ȡ��Щ��Ʒ��֧�ֵĻ��˷�ʽ
        /// </summary>
        /// <param name="productIds">��Ʒ��ż���</param>        
        /// <returns></returns>
        public DataTable GetProductsSupportLogisticsTypesByProductIds(string productIds)
        {
            return DAL.GetProductsSupportLogisticsTypesByProductIds(productIds);
        }

        /// <summary>
        /// ��Ʒ�Ĺ��Ʋ���
        /// </summary>
        /// <param name="supplyId">��ƷID</param>
        /// <param name="count">������</param>
        /// <param name="ispayBail">���Ƶ�״̬��0������ ��1���ƣ�</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateIsPayBailById(int supplyId, int count, bool ispayBail, decimal MarginRefund)
        {
            if (supplyId <= 0||count<=0)
            {
                return 0;
            }
            return DAL.UpdateIsPayBailById(supplyId,count,ispayBail,MarginRefund);
        }

        /// <summary>
        /// ���ݲ�Ʒ��Ÿ��²�Ʒ�Ŀ��������������������
        /// </summary>
        /// <param name="supplyId">��Ʒ���</param>
        /// <param name="count">��Ʒ����</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateStocksAndLockById(int supplyId, int count)
        {
            if (supplyId <= 0 || count <= 0)
            {
                return 0;
            }
            return DAL.UpdateStocksAndLockById(supplyId, count);
        }

        /// <summary>
        /// ���ݲ�Ʒ����޸����������ۼ�������
        /// </summary>
        /// <param name="supplyId">��Ʒ���</param>
        /// <param name="count">�޸ĵ�������</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateLockCountById(int supplyId, int count)
        {
            if (supplyId <= 0 || count <= 0)
            {
                return 0;
            }
            return DAL.UpdateLockCountById(supplyId, count);
        }
    }
}
