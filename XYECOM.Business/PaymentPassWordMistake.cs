using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Business
{
    public class PaymentPassWordMistake
    {
        private static readonly XYECOM.SQLServer.PaymentPassWordMistake DAL = new XYECOM.SQLServer.PaymentPassWordMistake();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="PInfo">支付密码错误信息对象</param>
        /// <returns>影响行数</returns>
        /// 
        public int Inster(XYECOM.Model.PaymentPassWordMistake PInfo)
        {
            return DAL.Insert(PInfo);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns>影响行数</returns>
        public int Delete(int UserId)
        {
            return DAL.Delete(UserId);
        }

        /// <summary>
        /// 获取支付密码错误信息对象
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns>影响行数</returns>
        /// 
        public XYECOM.Model.PaymentPassWordMistake GetItem(int UserId)
        {
            return DAL.GetItem(UserId);
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="PInfo">支付密码错误信息对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.PaymentPassWordMistake PInfo)
        {
            return DAL.Update(PInfo);
        }

        //用户输入错误支付密码业务
        public int PaymentPassWord(int UserId, Enum IsMistake, out int MistakeNum, out string OKTime)
        {
            MistakeNum = 3;//允许用户输入支付密码错误次数
            OKTime = "3"; //锁定后允许3分钟后再次输入密码
            int Flag = -1;

            //验证支付密码之前的验证
            if (IsMistake.ToString() == XYECOM.Model.PaymenMistake.Normal.ToString())
            {
                //查看用户输入支付密码锁定状态(在验证支付密码之前)
                XYECOM.Model.PaymentPassWordMistake PInfo = GetItem(UserId);
                if (PInfo == null)
                {
                    //未锁定
                    return (int)XYECOM.Model.PaymenMistake.NoLock;
                }
                else
                {
                    TimeSpan dt = DateTime.Now - PInfo.LockTime;

                    if (dt.TotalMinutes > XYECOM.Core.MyConvert.GetDouble(OKTime))
                    {
                        //清除用户输入错误支付密码锁定信息
                        Delete(UserId);
                        //未锁定
                        return (int)XYECOM.Model.PaymenMistake.NoLock;
                    }

                    else
                    {
                        if (PInfo.MistakeNum == MistakeNum || PInfo.MistakeNum > MistakeNum)
                        {
                            //锁定中
                            return (int)XYECOM.Model.PaymenMistake.YesLock;
                        }
                        else
                        {
                            //未锁定
                            return (int)XYECOM.Model.PaymenMistake.NoLock;
                        }
                    }
                }
            }
            //输入正确密码
            if (IsMistake.ToString() == XYECOM.Model.PaymenMistake.DisMistake.ToString())
            {
                XYECOM.Model.PaymentPassWordMistake PInfo = GetItem(UserId);
                if (PInfo != null)
                {
                    //清除用户输入错误支付密码锁定信息
                    Delete(UserId);
                    //未锁定
                    return (int)XYECOM.Model.PaymenMistake.NoLock;
                }
                //未锁定
                return (int)XYECOM.Model.PaymenMistake.NoLock;
            }
            //输入错误密码
            if (IsMistake.ToString() == XYECOM.Model.PaymenMistake.Mistake.ToString())
            {
                XYECOM.Model.PaymentPassWordMistake PInfo = GetItem(UserId);
                XYECOM.Model.PaymentPassWordMistake newInfo = new Model.PaymentPassWordMistake();

                if (PInfo == null)
                {
                    //第一次输错并记录信息
                    newInfo.UserId = UserId;
                    newInfo.MistakeNum = 1;
                    newInfo.LockTime = DateTime.Now;

                    Inster(newInfo);
                    //未锁定
                    return (int)XYECOM.Model.PaymenMistake.NoLock;
                }
                else
                {
                    newInfo.UserId = UserId;
                    newInfo.MistakeNum = PInfo.MistakeNum + 1;
                    newInfo.LockTime = DateTime.Now;
                    
                    Update(newInfo);

                    //未锁定
                    return (int)XYECOM.Model.PaymenMistake.NoLock;
                }
            }

            return Flag;
        }
    }
}
