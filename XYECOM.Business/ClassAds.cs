using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{

   public class ClassAds
    {
       XYECOM.SQLServer.ClassAds DAL = new XYECOM.SQLServer.ClassAds();
      /// <summary>
      /// ��ӷ���ƽ���λ
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
       public int Insert(XYECOM.Model.ClassAdsInfo info,out int adsId)
       {
           if (info == null)
           {
               adsId = 0;

               return 0;
           }
           return  DAL.Insert(info,out adsId);
       }
       /// <summary>
       /// �޸ķ���ƽ���λ
       /// </summary>
       /// <param name="info"></param>
       /// <returns></returns>
       public int Update(XYECOM.Model.ClassAdsInfo info)
       {
           if (info == null)
           {
               return 0;
           }
           return  DAL.Update(info);
       }
       /// <summary>
       /// ����id�õ�һ������ƽ������Ϣ
       /// </summary>
       /// <param name="adsid"></param>
       /// <returns></returns>
       public XYECOM.Model.ClassAdsInfo GetItemByAdsid(int adsid)
       {
          return   DAL.GetItem(adsid);
       
       }
       /// <summary>
       /// ɾ���ķ���
       /// </summary>
       /// <param name="infoid"></param>
       /// <returns></returns>
       public int Delete(string infoid)
       {
           if (infoid.Length < 0 || infoid == "")
           {
               return 0;
           }
           return DAL.Delete(infoid);
       }


       /// <summary>
       /// ��������ȡ�������Ϣ
       /// </summary>
       /// <param name="classid"></param>
       /// <returns></returns>
       public DataTable GetItems(int classid, Model.ClassAdsState clsAdsState, Model.AuditingState state)
       {
           if (classid <= 0)
               return null;

           return DAL.GetItems(classid, clsAdsState, state);
       }
       /// <summary>
       /// �������id�õ���Ӧ�������Ϣ���
       /// </summary>
       /// <param name="classid"></param>
       /// <returns></returns>
       public DataTable GetItems(int classid)
       {
           if (classid <= 0)
               return null;
           return DAL.GetItems(classid);
       }
       /// <summary>
        /// ��ȡ��棬ǰ̨ҳ��ר�ã��������
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="clsAdsState"></param>
        /// <param name="state"></param>
        /// <returns></returns>
       public DataTable GetItemsForFrontPage(int classid)
       {
           if (classid <= 0) return new DataTable();

           bool isInherit = XYECOM.Configuration.ClassAds.Instance.IsInherit;

           DataTable table = null;

           if (!isInherit)
           {
               table =  DAL.GetItemsForFrontPage(classid);
           }
           else
           {
               List<Model.XYClassInfo> parentClsInfos = XYClass.GetParentClassInfos("offer", classid);

               DataTable cTable = null;

               for (int i = parentClsInfos.Count - 1; i >= 0; i--)
               {
                   Model.XYClassInfo cinfo = parentClsInfos[i];

                   cTable = DAL.GetItemsForFrontPage(cinfo.ClassId);

                   if (table == null) table = cTable.Clone();

                   if (cTable.Rows.Count > 0)
                   {
                       foreach (DataRow cRow in cTable.Rows)
                       {
                           table.ImportRow(cRow);
                       }
                   }
               }
           }

           //����������ҳ�涼��ʾ��
           DataTable tableTop = DAL.GetTopItems(classid);

           if (tableTop != null && tableTop.Rows.Count > 0)
           {
               if (table != null && table.Rows.Count > 0)
               {
                   foreach (DataRow _Row in table.Rows)
                   {
                       tableTop.ImportRow(_Row);
                   }   
               }

               return tableTop;
           }

           return table;
       }
    }
}
