using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// ����ƽ���λ��
    /// </summary>
    public  class ClassAdsPriceInfo
    {
        private int step;
        /// <summary>
        /// ����λ��
        /// </summary>
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        private double price;
        /// <summary>
        /// ���ļ�Ǯ
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
