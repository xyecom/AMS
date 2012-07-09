using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public class GiftInfo
    {
        int gId;
        /// <summary>
        /// 礼品编号
        /// </summary>
        public int GId
        {
            get { return gId; }
            set { gId = value; }
        }
        string name;
        /// <summary>
        /// 礼品名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int amount;
        /// <summary>
        /// 所需虚拟货币数量
        /// </summary>
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        string gradeIds;
        /// <summary>
        /// 所需用户等级
        /// </summary>
        public string GradeIds
        {
            get { return gradeIds; }
            set { gradeIds = value; }
        }
        int number;
        /// <summary>
        /// 礼品剩余数量
        /// </summary>
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
