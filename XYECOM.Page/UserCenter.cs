using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page
{
    /// <summary>
    /// 用户中心基类
    /// </summary>
    public class UserCenter : BasePage
    {
        #region 更新用户session
        /// <summary>
        /// 更新用户session
        /// </summary>
        protected void UpdateSessionUserInfo()
        {
            XYECOM.Model.UserRegInfo _userInfo = new XYECOM.Business.UserReg().GetItem(userinfo.userid);
            if (null != _userInfo)
            {
                XYECOM.Model.GeneralUserInfo _info = Business.CheckUser.GetUserInfo(_userInfo);
                if (null != _info)
                {
                    XYECOM.Core.Utils.SetSession("UserInfo", _info);
                }
            }
        }
        #endregion
        /// <summary>
        /// 根据审核ID 获取中文标示
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        protected string GetAuditingState(int stateId)
        {
            Model.AuditingState sta = (Model.AuditingState)stateId;
            string name = "";
            switch (sta)
            {
                case XYECOM.Model.AuditingState.Null:
                    name = "未审核";
                    break;
                case XYECOM.Model.AuditingState.NoPass:
                    name = "审核不通过";
                    break;
                case XYECOM.Model.AuditingState.Passed:
                    name = "审核通过";
                    break;
                case XYECOM.Model.AuditingState.EditNoPass:
                    name = "编辑未通过";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (null == userinfo || userinfo.userid <= 0)
            {
                string backUrl = Request.RawUrl;

                if (!backUrl.Equals(""))
                    backUrl = XYECOM.Core.Utils.JSEscape(webInfo.WebDomain + backUrl.Substring(1));

                Response.Redirect(config.WebURL + "login." + config.Suffix + "?surl=" + backUrl);
            }

            base.OnLoad(e);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #region 用户中心分页
        /// <summary>
        /// 前台分页
        /// </summary>
        /// <param name="PageIndex">当前第机页</param>
        /// <param name="HTML">连接页面</param>
        /// <param name="Count">记录数</param>
        /// <param name="PageSize">每页的记录数</param>
        /// <returns></returns>
        protected override void SetPagination(int PageIndex, string HTML, int Count, int PageSize)
        {
            if (Count > 0)
            {
                if ((Count % PageSize) == 0)
                {
                    this.pageinfo.PageCount = (Count / PageSize);
                    if (pageinfo.PageIndex != 1)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>首页</a>";
                        }
                        else
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>首页</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "首页";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "尾页";
                    }
                    else
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">尾页</a>";
                        }
                        else
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">尾页</a>";
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "下一页";

                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        this.pageinfo.NextPage = "下一页";
                    }
                }
                else if ((Count % PageSize) > 0)
                {
                    this.pageinfo.PageCount = (Count / PageSize) + 1;
                    if (pageinfo.PageIndex != 1)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>首页</a>";
                        }
                        else
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>首页</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "首页";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "尾页";
                    }
                    else
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">尾页</a>";
                        }
                        else
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">尾页</a>";
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "下一页";
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">下一页</a>";
                        }
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">上一页</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "上一页";
                        this.pageinfo.NextPage = "下一页";
                    }
                }

            }
            else
            {
                this.pageinfo.FirstPage = "首页";
                this.pageinfo.PreviousPage = "上一页";
                this.pageinfo.NextPage = "下一页";
                this.pageinfo.LastPage = "尾页";
            }
        }
        #endregion

        protected virtual void BindData() { }
    }
}
