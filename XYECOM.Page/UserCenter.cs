using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page
{
    /// <summary>
    /// �û����Ļ���
    /// </summary>
    public class UserCenter : BasePage
    {
        #region �����û�session
        /// <summary>
        /// �����û�session
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
        /// �������ID ��ȡ���ı�ʾ
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
                    name = "δ���";
                    break;
                case XYECOM.Model.AuditingState.NoPass:
                    name = "��˲�ͨ��";
                    break;
                case XYECOM.Model.AuditingState.Passed:
                    name = "���ͨ��";
                    break;
                case XYECOM.Model.AuditingState.EditNoPass:
                    name = "�༭δͨ��";
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
        }

        #region �û����ķ�ҳ
        /// <summary>
        /// ǰ̨��ҳ
        /// </summary>
        /// <param name="PageIndex">��ǰ�ڻ�ҳ</param>
        /// <param name="HTML">����ҳ��</param>
        /// <param name="Count">��¼��</param>
        /// <param name="PageSize">ÿҳ�ļ�¼��</param>
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
                            this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>��ҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>��ҳ</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "��ҳ";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "βҳ";
                    }
                    else
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "��һҳ";

                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        this.pageinfo.NextPage = "��һҳ";
                    }
                }
                else if ((Count % PageSize) > 0)
                {
                    this.pageinfo.PageCount = (Count / PageSize) + 1;
                    if (pageinfo.PageIndex != 1)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "&pageindex=1>��ҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.FirstPage = "<a href=" + HTML + "?pageindex=1>��ҳ</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.FirstPage = "��ҳ";
                    }
                    if (pageinfo.PageIndex == pageinfo.PageCount)
                    {
                        this.pageinfo.LastPage = "βҳ";
                    }
                    else
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "&pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.LastPage = "<a href=" + HTML + "?pageindex=" + pageinfo.PageCount + ">βҳ</a>";
                        }
                    }
                    if (PageIndex >= pageinfo.PageCount && PageIndex != 1)
                    {
                        this.pageinfo.NextPage = "��һҳ";
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                    }
                    else if (PageIndex <= 1 && PageIndex != pageinfo.PageCount)
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                    }
                    else if (PageIndex > 1 && PageIndex < pageinfo.PageCount)
                    {
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "&pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.NextPage = "<a href=" + HTML + "?pageindex=" + (PageIndex + 1) + ">��һҳ</a>";
                        }
                        if (HTML.IndexOf("?") > 0)
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "&pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                        else
                        {
                            this.pageinfo.PreviousPage = "<a href=" + HTML + "?pageindex=" + (PageIndex - 1) + ">��һҳ</a>";
                        }
                    }
                    else
                    {
                        this.pageinfo.PreviousPage = "��һҳ";
                        this.pageinfo.NextPage = "��һҳ";
                    }
                }

            }
            else
            {
                this.pageinfo.FirstPage = "��ҳ";
                this.pageinfo.PreviousPage = "��һҳ";
                this.pageinfo.NextPage = "��һҳ";
                this.pageinfo.LastPage = "βҳ";
            }
        }
        #endregion
    }
}
