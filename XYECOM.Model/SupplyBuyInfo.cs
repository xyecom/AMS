using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 快速发布求购信息实体
    /// </summary>
   public class SupplyBuyInfo
    {
        int emergency;
       /// <summary>
       /// 是否是紧急求购
       /// </summary>
        public int Emergency
        {
            get { return emergency; }
            set { emergency = value; }
        }
        int buyNum;

        public int BuyNum
        {
            get { return buyNum; }
            set { buyNum = value; }
        }
        string time;
       /// <summary>
       /// 发布时间
       /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        long id;
       /// <summary>
       /// 信息ID
       /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
       long uid;
       /// <summary>
       /// 用户ID
       /// </summary>
       public long Uid
       {
           get { return uid; }
           set { uid = value; }
       }
       string title;
       /// <summary>
       /// 信息标题
       /// </summary>
       public string Title
       {
           get { return title; }
           set { title = value; }
       }
       string keyWord;
       /// <summary>
       /// 信息 关键字
       /// </summary>
       public string KeyWord
       {
           get { return keyWord; }
           set { keyWord = value; }
       }
       string contents;
       /// <summary>
       /// 信息内容，产品要求
       /// </summary>
       public string Contents
       {
           get { return contents; }
           set { contents = value; }
       }
       string u_name;
       /// <summary>
       /// 联系人
       /// </summary>
       public string U_name
       {
           get { return u_name; }
           set { u_name = value; }
       }
       string tel;
       /// <summary>
       /// 手机
       /// </summary>
       public string Tel
       {
           get { return tel; }
           set { tel = value; }
       }
       int state;
       /// <summary>
       /// 审核状态
       /// </summary>
       public int State
       {
           get { return state; }
           set { state = value; }
       }

       private int area_id;
       /// <summary>
       /// 求购地区
       /// </summary>
       public int Area_id
       {
           get { return area_id; }
           set { area_id = value; }
       }
    }
}
