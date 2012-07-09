using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.basic
{
    public partial class AreaAdd:XYECOM.Web.BasePage.ManagePage
    {
        protected string strID,strParentID;
        private string backUrl = "";
        private bool error = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("area");

            strParentID = "" == XYECOM.Core.XYRequest.GetQueryString("ParentID") ? "0" : XYECOM.Core.XYRequest.GetQueryString("ParentID");
            
            strID = XYECOM.Core.XYRequest.GetQueryString("ID");

            if (!IsPostBack)
            {
                #region ��ʾ�ּ�·��
                XYECOM.Model.AreaInfo info = new XYECOM.Business.Area().GetItem(Convert.ToInt32(strParentID));
                string Path = "";
                if (null != info)
                {
                    string fullId = Core.Utils.RemoveComma(info.FullID);

                    if ("" != fullId)
                    {
                        string[] arr1 = fullId.Split(',');
                        string[] arr2 = info.FullName.Split(',');
                        for (int i = 0; i < arr1.Length; i++)
                        {
                            Path += "&gt;&gt;<a href=\"arealist.aspx?parentID=" + arr1[i] + "\">" + arr2[i] + "</a>";
                        }
                    }
                    Path += "&gt;&gt;<a href=\"arealist.aspx?parentID=" + info.ID + "\">" + info.Name + "</a>";
                }
                lbPath.Text = Path;
                #endregion

                if ("" != strID)
                {
                    txtName.Text = new XYECOM.Business.Area().GetItem(Convert.ToInt32(strID)).Name;
                    txtName.Rows = 1;
                    txtName.Columns = 40;
                }
            }
            backUrl = strParentID != "" ? "AreaList.aspx?ParentID=" + strParentID : "AreaList.aspx";
        }

        private void InsertData(string strType)
        {

            XYECOM.Model.AreaInfo info = new XYECOM.Model.AreaInfo();
            info.Name = strType;
            info.ParentID = Convert.ToInt32(strParentID);
            int resulit = new XYECOM.Business.Area().Insert(info);
            string url = "arealist.aspx?parentID=" + strParentID;
            if (-1 == resulit)
            {
                Alert("��¼�Ѿ����ڣ���������д��", url);
                error = true;
            }
            else if (-2 == resulit)
            {
                Alert("�������󣡲���ʧ�ܣ�", url);
                error = true;
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                Alert("����д��������");
                return;
            }
            if ("" == strID)
            {
                string TypeName = txtName.Text.Trim().Replace("��", ",");
                if (TypeName.IndexOf(",") > 0)
                {
                    string[] arr = TypeName.Split(',');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        InsertData(arr[i].Trim());
                        if (error)
                            break;
                    }
                    if (!error)
                        Response.Redirect(backUrl);
                }
                else
                {
                    InsertData(txtName.Text.Trim());
                    if (!error)
                        Response.Redirect(backUrl);
                }
            }
            else
            {
                XYECOM.Model.AreaInfo info = new XYECOM.Model.AreaInfo();
                info.Name = txtName.Text.Trim();
                info.ID = Int32.Parse(strID);
                int resulit = new XYECOM.Business.Area().Update(info);
                if (0 < resulit)
                    Response.Redirect("arealist.aspx?parentID=" + strParentID);
                else if (-1 == resulit)
                    Alert("�ü�¼�Ѿ����ڣ���������д��", "arealist.aspx?parentID=" + strParentID);
                else if (-2 == resulit)
                    Alert("�������󣡲���ʧ�ܣ�","arealist.aspx?parentID=" + strParentID);
            }
        }
    }
}
