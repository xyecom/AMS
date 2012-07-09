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
      /// 添加分类黄金广告位
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
       /// 修改分类黄金广告位
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
       /// 根据id得到一条分类黄金广告的信息
       /// </summary>
       /// <param name="adsid"></param>
       /// <returns></returns>
       public XYECOM.Model.ClassAdsInfo GetItemByAdsid(int adsid)
       {
          return   DAL.GetItem(adsid);
       
       }
       /// <summary>
       /// 删除的方法
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
       /// 跟据类别获取类别广告信息
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
       /// 根据类别id得到相应的类别信息广告
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
        /// 获取广告，前台页面专用（随机排序）
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

           //插入在所有页面都显示的
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
