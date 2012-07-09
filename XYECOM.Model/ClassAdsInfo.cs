using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{  
   
  /// <summary>
  /// ����ƽ���λʵ����
  /// </summary>
  [Serializable]
   public    class ClassAdsInfo
    {
       private int adsId;
       /// <summary>
       /// ��Ϣid
       /// </summary>
       public int AdsId
       {
           get { return adsId; }
           set { adsId = value; }
       }
       private int classId;
       /// <summary>
       /// ����Id
       /// </summary>
       public int ClassId
       {
           get { return classId; }
           set { classId = value; }
       }

       private long userId;
       /// <summary>
       /// �û�id
       /// </summary>
       public long UserId
       {
           get { return userId; }
           set { userId= value; }
       }
       private string imageUrl;
       /// <summary>
       /// ͼƬUrl
       /// </summary>
       public string ImageUrl
       {
           get { return imageUrl; }
           set { imageUrl = value; }
       }
       private string link;
       /// <summary>
       /// ���ӵ�ַ
       /// </summary>
       public string Link
       {
           get { return link; }
           set { link = value; }
       }
       private string desc;
       /// <summary>
       /// ���˵������
       /// </summary>
       public string Desc
       {
           get { return desc; }
           set { desc = value; }
       }
       private Int16 rank;
       /// <summary>
       /// ���λ��
       /// </summary>
       public Int16 Rank
       {
           get { return rank; }
           set { rank = value; }
       }
       private DateTime inputTime;
      /// <summary>
      /// �û�¼��ʱ��
      /// </summary>
       public DateTime InputTime
       {
           get { return inputTime; }
           set { inputTime = value; }
       }
       private DateTime? beginTime;
       /// <summary>
       /// ��ʼʱ��
       /// </summary>
       public DateTime? BeginTime
       {
           get { return beginTime; }
           set { beginTime = value; }
       }
       private DateTime? endTime;
       /// <summary>
       /// ����ʱ��
       /// </summary>
       public DateTime? EndTime
       {
           get { return endTime; }
           set { endTime = value; }
       }
       private Int16 timeLength;
      /// <summary>
      /// ������Ч��
      /// </summary>
       public Int16 TimeLength
       {
           get { return timeLength; }
           set { timeLength = value; }
       }
       private string property;
       /// <summary>
       /// ������ԣ�Normal��������top�����з��඼����
       /// </summary>
       public string Property
       {
           get { return property; }
           set { property = value; }
       }
       private bool isPay;
       /// <summary>
       /// �Ƿ��Ѿ�֧��
       /// </summary>
       public bool IsPay
       {
           get { return isPay; }
           set { isPay = value; }
       }

       private AuditingState state = AuditingState.Null;
       /// <summary>
       /// ״̬(ö����)
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
       /// ״̬(����)[-1:�����,0:δͨ�����,1:ͨ�����]
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
