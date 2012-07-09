using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    public class ExGift
    {
        static readonly XYECOM.SQLServer.ExGift exGift = new XYECOM.SQLServer.ExGift();
        public int ExchangeGift(XYECOM.Model.ExGiftInfo exGiftInfo, XYECOM.Model.GiftInfo giftInfo)
        {
            return exGift.ExchangeGift(exGiftInfo, giftInfo);
        }

        public int ChangeExState(int exId, int newState)
        {
            return exGift.UpdateState(exId, newState);
        }

        public int Delete(string id)
        {
            return exGift.Delete(id);
        }

        /// <summary>
        /// 查找指定ID的礼品是否存在兑换记录
        /// </summary>
        /// <param name="gId">礼品ID</param>
        /// <param name="state">0：等待确认；1：已确认</param>
        /// <returns>存在：true；不存在：false</returns>
        public bool HasExchange(int gId, int state)
        {
            bool flag = false;
            flag = exGift.IsExistExchange(gId, state) == 1 ? true : false;
            return flag;
        }
    }
}
