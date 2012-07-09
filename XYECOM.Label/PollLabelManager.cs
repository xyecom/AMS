using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 投票标签处理类
    /// </summary>
    public class PollLabelManager:LabelManger
    {
        private static PollLabelManager instance = null;

        private static string labelName = "";

        private PollLabelManager() { }

        /// <summary>
        /// 获取实例对象
        /// </summary>
        /// <param name="_labelName">标签名称</param>
        /// <returns></returns>
        public static LabelManger GetInstance(string _labelName)
        {
            labelName = _labelName;

            instance = new PollLabelManager();

            return (LabelManger)instance;
        }

        /// <summary>
        /// 获取解析后的结果
        /// </summary>
        /// <returns></returns>
        public override string CreateHTML()
        {
            Model.PollInfo poll = new Business.Poll().GetItem(labelName);

            if (poll == null) return "";

            List<Model.PollOptionInfo> options = new Business.PollOption().GetItems(poll.PollId);

            if (options.Count < 1) return "";

            string selInputType = "radio";
            if (poll.Mode == XYECOM.Model.PollMode.Check) selInputType = "checkbox";
            
            StringBuilder html = new StringBuilder("");

            html.Append("<div id='poll_"+poll.PollId+"'>");
            html.Append("<form action='/poll.").Append(config.WebSuffix).Append("?pollid=").Append(poll.PollId).Append("' method='post' target='_blank' id='poll_form_" + poll.PollId + "'>");
            html.Append("<span class='poll_title'>").Append(poll.Title).Append("</span>");
            html.Append("<ul>");

            foreach (Model.PollOptionInfo o in options)
            {
                html.Append("<li>");
                html.Append("<input type='").Append(selInputType)
                    .Append("' value='")
                    .Append(o.OptionId)
                    .Append("' name='")
                    .Append("poll_sel_").Append(poll.PollId).Append("'")
                    .Append(">")
                    .Append(o.Option);
                html.Append("</li>");
            }

            html.Append("</ul>");
            html.Append("<span class='poll_btn'>");
            html.Append("<input type='button' value='投票' onclick='poll_form_"+poll.PollId+".submit();'> ");
            html.Append("【<a href='/poll.").Append(config.WebSuffix).Append("?pollid=").Append(poll.PollId).Append("' target='_blank'>投票结果</a>】");
            html.Append("</span>");
            html.Append("</form>");
            html.Append("</div>");

            return html.ToString();
        }
    }
}
