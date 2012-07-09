using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XYECOM.Business;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class Field : XYECOM.Web.BasePage.ManagePage
    {
        private FieldManager fieldBLL = new FieldManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("typemanage");
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        protected override void BindData()
        {
            int typeId = XYECOM.Core.XYRequest.GetQueryInt("typeid", 0);
            if (typeId < 1)
            {
                Alert("�Ƿ�������", "Typelist.aspx");
                return;
            }

            //��ʾ��ǰ�������Ϣ
            string parentstr = "";
            List<Model.XYClassInfo> classinfoarr = XYECOM.Business.XYClass.GetParentClassInfos("offer", typeId);
            foreach (Model.XYClassInfo info in classinfoarr)
            {
                parentstr = "" == parentstr ? "" : "��>" + parentstr;
                parentstr = info.ClassName + parentstr;
            }
            lbClassType.Text = parentstr;

            IList<Model.FieldValueInfo> list = fieldBLL.GetItems(typeId);
            string fieldarr = "";
            foreach (Model.FieldValueInfo info in list)
            {
                Model.FieldInfo fldInfo = info.Field;
                fieldarr += "" == fieldarr ? "" : ",";
                fieldarr += "{id:'" + fldInfo.Id
                    + "',ename:'" + fldInfo.EName
                    + "',cname:'" + fldInfo.CName
                    + "',desp:'" + fldInfo.Description.Replace("\r\n", "\\r\\n")
                    + "',defaultvalue:'" + fldInfo.DefaultValue
                    + "',inputmode:'" + fldInfo.Type + "_" + fldInfo.InputModel
                    + "',initvalue:'" + fldInfo.InitValue.Replace("\r\n", "\\r\\n")
                    + "'}";

            }
            litfieldarr.Text = fieldarr;

            string topfieldarr = "[{}]";

            littopclass.Text = topfieldarr;

        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            int productTypeId = XYECOM.Core.XYRequest.GetQueryInt("TypeID", 0);

            string strtopid = XYECOM.Core.XYRequest.GetFormString("topid");
            string[] TopIDs = strtopid.Split(',');
            string[] IDs = XYECOM.Core.XYRequest.GetFormString("id").Split(',');
            string[] ENames = XYECOM.Core.XYRequest.GetFormString("txtEName").Split(',');
            string[] CNames = XYECOM.Core.XYRequest.GetFormString("txtCName").Split(',');
            string[] Desps = XYECOM.Core.XYRequest.GetFormString("txtdesp").Split(',');
            string[] defaults = XYECOM.Core.XYRequest.GetFormString("txtdefault").Split(',');
            string[] initvalues = XYECOM.Core.XYRequest.GetFormString("txtinitvalue").Split(',');
            string[] typeAndMode = XYECOM.Core.XYRequest.GetFormString("seltype").Split(',');

            string[] deleteids = XYECOM.Core.XYRequest.GetFormString("deleteids").Split(',');

            foreach (string idstr in deleteids)
            {
                int delId = XYECOM.Core.MyConvert.GetInt32(idstr);
                if (delId > 0)
                {
                    try
                    {
                        fieldBLL.Delete(delId);
                    }
                    catch (Exception ex)
                    {
                        WriteLog("ɾ����������", ex);
                    }

                }
            }

            //������Ӻ��޸��ֶβ���
            Model.FieldInfo fieldinfo = new Model.FieldInfo();
            int result = 0;
            string msg = "";
            for (int i = 0; i < IDs.Length; i++)
            {
                if ("" != ENames[i])
                {
                    if (XYECOM.Core.Utils.IsNumber(ENames[i]))
                    {
                        msg += "�ֶ�Ӣ��������Ϊ���֣�[" + ENames[i] + "]�����ʧ�ܡ�<br />";
                        continue;
                    }
                    fieldinfo.CName = CNames[i];
                    fieldinfo.Description = Desps[i];
                    fieldinfo.EName = ENames[i];
                    fieldinfo.InitValue = initvalues[i];
                    string[] typemode = typeAndMode[i].Split(new char[] { '_' });
                    fieldinfo.Type = typemode[0];
                    fieldinfo.InputModel = typemode[1];
                    fieldinfo.ProductTypeId = productTypeId;
                    fieldinfo.DefaultValue = defaults[i];

                    if ("" != IDs[i])
                    {
                        fieldinfo.Id = XYECOM.Core.MyConvert.GetInt32(IDs[i]);
                        result = fieldBLL.Update(fieldinfo);
                    }
                    else
                    {
                        result = fieldBLL.Insert(fieldinfo);
                    }
                    if (-2 == result)
                        msg += "�ֶ�[" + fieldinfo.EName + "]�ڸ�ģ���Ѿ��д��ڣ���������д��<br />";
                }
            }
            if ("" == msg)
                msg = "�����ɹ���";
            else
                msg = "������ɣ����д��������������£�<br />" + msg;
            Alert(msg, XYECOM.Core.XYRequest.GetRawUrl().ToString() + "&orderid=" + XYECOM.Core.XYRequest.GetQueryInt64("typeid") + "&ename=" + XYECOM.Core.XYRequest.GetQueryString("ename"));
        }
    }
}