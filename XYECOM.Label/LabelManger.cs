using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.LabelManager.cs
     * 创建标识：TC 20080618
     * 
     * 功能描述：标签管理类抽象父类
     * 
     ************************************.*************/

    /// <summary>
    /// 标签解析管理抽象超级类
    /// </summary>
    public abstract class LabelManger
    {
        protected XYECOM.Configuration.WebInfo config = XYECOM.Configuration.WebInfo.Instance;

        protected XYECOM.Configuration.Module module = XYECOM.Configuration.Module.Instance;

        /// <summary>
        /// 外部参数传递对象
        /// </summary>
        public OuterParameterInfo OuterParameter = new OuterParameterInfo();

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="ex">异常对象</param>
        protected void WriteLog(string message, Exception ex)
        { 
        
        }

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="ex">异常对象</param>
        protected void WriteLog(string message)
        {

        }

        /// <summary>
        /// 获取标签类型
        /// </summary>
        /// <param name="lableName">标签名称</param>
        /// <returns></returns>
        public static LabelType GetLabelType(string lableName)
        {
            //如果是分类标签，则直接读取
            if (lableName.StartsWith("xy_cls_") 
                || lableName.StartsWith("xy_asn_")
                || lableName.StartsWith("xy_tsn_"))
            {
                return LabelType.ClassLabel;
            }

            if (lableName.StartsWith("xy_poll_"))
            {
                return LabelType.PollLabel;
            }

            if (lableName.StartsWith("xy_part_"))
            {
                return LabelType.PartLabel;
            }

            if (lableName.StartsWith("sys:"))
            {
                return LabelType.SystemLabel;
            }

            return LabelType.ContentLabel;
        }

        /// <summary>
        /// 根据标签名称生成HTML内容(子类实现)
        /// </summary>
        /// <param name="labelName">标签名称</param>
        /// <returns></returns>
        public abstract string CreateHTML();
    }
}
