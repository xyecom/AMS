using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{  
   
  /// <summary>
  /// 分类黄金广告位实体类
  /// </summary>
  [Serializable]
   public    class ClassAdsInfo
    {
       private int adsId;
       /// <summary>
       /// 信息id
       /// </summary>
       public int AdsId
       {
           get { return adsId; }
           set { adsId = value; }
       }
       private int classId;
       /// <summary>
       /// 分类Id
       /// </summary>
       public int ClassId
       {
           get { return classId; }
           set { classId = value; }
       }

       private long userId;
       /// <summary>
       /// 用户id
       /// </summary>
       public long UserId
       {
           get { return userId; }
           set { userId= value; }
       }
       private string imageUrl;
       /// <summary>
       /// 图片Url
       /// </summary>
       public string ImageUrl
       {
           get { return imageUrl; }
           set { imageUrl = value; }
       }
       private string link;
       /// <summary>
       /// 链接地址
       /// </summary>
       public string Link
       {
           get { return link; }
           set { link = value; }
       }
       private string desc;
       /// <summary>
       /// 广告说明文字
       /// </summary>
       public string Desc
       {
           get { return desc; }
           set { desc = value; }
       }
       private Int16 rank;
       /// <summary>
       /// 广告位置
       /// </summary>
       public Int16 Rank
       {
           get { return rank; }
           set { rank = value; }
       }
       private DateTime inputTime;
      /// <summary>
      /// 用户录入时间
      /// </summary>
       public DateTime InputTime
       {
           get { return inputTime; }
           set { inputTime = value; }
       }
       private DateTime? beginTime;
       /// <summary>
       /// 开始时间
       /// </summary>
       public DateTime? BeginTime
       {
           get { return beginTime; }
           set { beginTime = value; }
       }
       private DateTime? endTime;
       /// <summary>
       /// 结束时间
       /// </summary>
       public DateTime? EndTime
       {
           get { return endTime; }
           set { endTime = value; }
       }
       private Int16 timeLength;
      /// <summary>
      /// 广告的有效期
      /// </summary>
       public Int16 TimeLength
       {
           get { return timeLength; }
           set { timeLength = value; }
       }
       private string property;
       /// <summary>
       /// 广告属性：Normal：正常，top：所有分类都出现
       /// </summary>
       public string Property
       {
           get { return property; }
           set { property = value; }
       }
       private bool isPay;
       /// <summary>
       /// 是否已经支出
       /// </summary>
       public bool IsPay
       {
           get { return isPay; }
           set { isPay = value; }
       }

       private AuditingState state = AuditingState.Null;
       /// <summary>
       /// 状态(枚举型)
       /// </summary>
       public AuditingState State
       {
           get { return state; }
           set
           {
               state = value;

               if (state == AuditingState.Null) intState = -1;
               if (state == AuditingState.NoPass) intState = 0;
               if (state == AuditingState.Passed) intState = 1;
           }
       }

       private int intState;
       /// <summary>
       /// 状态(整型)[-1:审核中,0:未通过审核,1:通过审核]
       /// </summary>
       public int IntState
       {
           get { return intState; }
           set
           {
               intState = value;

               if (intState == -1) state = AuditingState.Null;
               if (intState == 0) state = AuditingState.NoPass;
               if (intState == 1) state = AuditingState.Passed;
           }
       }  
    }
}
