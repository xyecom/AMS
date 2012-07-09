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
using System.IO;
using System.Xml;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class LabelIn : XYECOM.Web.BasePage.ManagePage
    {
        String fieldname = "";
        String messagein = "";
        String messageupdata = "";
        String messagereturn = "";
        String fieldpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
            if (!IsPostBack)
            {

            }
            this.Label1.Text = "";
            this.Label5.Text = "";
            
        }

        #region 上传
        protected void btnupload_Click(object sender, EventArgs e)
        {
            if(this.FileUpload1.FileName.Equals("")){
                this.Label1.Text = "请选择要导入的标签文件";
                return;
            }
            String path = Server.MapPath("/_BackUp/UploadLabel/");

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            String laststr = Path.GetExtension(path + this.FileUpload1.FileName);

            if(!laststr.Equals(".xml")){
                this.Label1.Text = "导入文件格式不正确";
                return; 
            }
            //try { 
                this.FileUpload1.SaveAs(path + this.FileUpload1.FileName);
                
                fieldpath = path + this.FileUpload1.FileName;

                Start(fieldpath, this.FileUpload1.FileName);

                DelFiled(fieldpath);

                this.Label1.Text = "导入成功";
                this.pnlresult.Visible = true;
            //}catch(Exception ex){
            //    this.Label1.Text = "导入失败" + ex.Message;
            //}


        }
        #endregion

        #region 删除
        protected void DelFiled(String filedpath)
        {
            string fileName = filedpath;

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        #endregion

        #region 导入标签

        protected void Start(String filedpath,String filedname)
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(filedpath);
            String namefalg = XYECOM.Core.XML.XMLUtil.GetNodeValue(docXml, "name");
            //覆盖 
            if(this.rbton.Checked == true){

                if (namefalg.Equals("typeLabel") || namefalg.Equals("contentLabel"))
                {
                    if (namefalg.Equals("typeLabel"))
                    {
                        AllTypeLable(0, filedpath);
                        this.Label5.Text = "标签类型：分类标签";
                    }
                    if (namefalg.Equals("contentLabel"))
                    {
                        AllContentLabel(0, filedpath);
                        this.Label5.Text = "标签类型：内容标签";
                    }
                }else{
                    LabelByType(0, filedpath);
                    this.Label5.Text = "标签类型：内容标签";
                }      
            }
            //跳过
            if(this.rbtnext.Checked == true){

                if (namefalg.Equals("typeLabel") || namefalg.Equals("contentLabel"))
                {
                    if (namefalg.Equals("typeLabel"))
                    {
                        AllTypeLable(1, filedpath);
                        this.Label5.Text = "导入类型：分类标签";
                    }
                    if (namefalg.Equals("contentLabel"))
                    {
                        AllContentLabel(1, filedpath);
                        this.Label5.Text = "导入类型：内容标签";
                    }
                }
                else
                {
                    LabelByType(1, filedpath);
                    this.Label5.Text = "标签类型：内容标签";
                }
            }
        }
        #endregion

        #region 所有分类标签
        /// <summary>
        /// 所有分类标签
        /// </summary>
        /// <param name="falg">flag:0 覆盖/flag:1 跳过</param>
        private void AllTypeLable(int falg,String fieldpath) {
            XmlDocument docXml = new XmlDocument();
            DataTable dt = new DataTable();
            int result = 0;
            docXml.Load(fieldpath);
            XYECOM.Business.ClassLabel cl = new XYECOM.Business.ClassLabel();
            XYECOM.Model.ClassLabelInfo info = new XYECOM.Model.ClassLabelInfo();

            XmlNodeList nodelist = docXml.GetElementsByTagName("item");
            for (int i = 0; i < nodelist.Count; i++)
            {
                for (int j = 1; j < nodelist[i].ChildNodes.Count; j++)
                {
                    fieldname = nodelist[i].ChildNodes[j].Name;
                    if (fieldname.Equals("Name"))
                    {
                        dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from xy_classlabel where Name = '" + nodelist[i].ChildNodes[j].FirstChild.Value + "'");
                        if (dt.Rows.Count > 0)
                        {
                            info.ID = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                            info.Name = nodelist[i].ChildNodes[j].FirstChild.Value;
                        }
                        else
                        {
                            info.ID = 0;
                            info.Name = nodelist[i].ChildNodes[j].FirstChild.Value;
                        }
                    }
                    if (fieldname.Equals("CNName"))
                    {
                        info.CNName = nodelist[i].ChildNodes[j].FirstChild.Value;
                    }
                    if (fieldname.Equals("Body"))
                    {
                        info.Body = nodelist[i].ChildNodes[j].FirstChild.Value;
                    }
                    if (fieldname.Equals("TableName"))
                    {
                        info.TableName = nodelist[i].ChildNodes[j].FirstChild.Value;
                    }
                }
                if (info.ID.Equals(0))
                {
                    result = cl.Insert(info);

                    messagein += info.CNName + ",";
                }
                else
                {
                    if(falg.Equals(0)){
                        result = cl.Update(info);
                        messageupdata += info.CNName + ",";
                    }
                    if (falg.Equals(1))
                    {
                        messagereturn += info.CNName + ",";
                    }   
                }
            }
            this.Label2.Text = "导入标签：" + messagein;
            this.Label3.Text = "更新标签：" + messageupdata;
            this.Label4.Text = "跳过标签：" + messagereturn;
        }
        #endregion

        #region 所有内容标签

        private void AllContentLabel(int flag, String fieldpath)
        {
            XmlDocument docXml = new XmlDocument();
            DataTable dt = new DataTable();
            int result = 0;

            docXml.Load(fieldpath);
            XYECOM.Business.Label label = new XYECOM.Business.Label();
            XYECOM.Model.LabelInfo info = new XYECOM.Model.LabelInfo();

            //内容标签
            XmlNodeList nodelist = docXml.GetElementsByTagName("item");

            string nodeValue = "";
            XmlElement ele = null;

            for (int i = 0; i < nodelist.Count; i++)
            {
                for (int j = 1; j < nodelist[i].ChildNodes.Count; j++)
                {
                    fieldname = nodelist[i].ChildNodes[j].Name;

                    ele = (XmlElement)nodelist[i];

                    nodeValue = XYECOM.Core.XML.XMLUtil.GetNodeValue(ele, fieldname);

                    if (fieldname.Equals("L_Name"))
                    {
                        dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from b_label where L_Name = '" + nodeValue + "'");

                        info.LabelName = nodeValue;

                        if (dt.Rows.Count > 0)
                        {
                            info.Id = Convert.ToInt32(dt.Rows[0]["L_ID"].ToString());
                        }
                        else
                        {
                            info.Id = 0;
                        }
                    }
                    if (fieldname.Equals("L_CName"))
                    {
                        info.LabelCName = nodeValue;
                    }
                    if (fieldname.Equals("LT_ID"))
                    { 
                        if (dt.Rows.Count > 0)
                        {
                            info.LabelTypeId = Convert.ToInt32(dt.Rows[0]["LT_ID"].ToString());
                        }
                        else {
                            info.LabelTypeId = Convert.ToInt32(nodeValue);
                        }
                    }
                    if (fieldname.Equals("L_TableName")) info.LabelTableName = nodeValue;

                    if (fieldname.Equals("L_Content")) info.LabelContent = nodeValue;

                    if (fieldname.Equals("L_StyleHead")) info.LabelStyleHead = nodeValue;
                    
                    if (fieldname.Equals("L_StyleContent"))info.LabelStyleContent = nodeValue;
                    
                    if (fieldname.Equals("L_StyleFooter"))info.LabelStyleFooter = nodeValue;

                }
                if (info.Id.Equals(0))
                {
                    String ltname = GetFromXMLType(info.LabelTypeId).LT_Name;
                    info.LabelTypeId = GetTypeID(ltname, GetFromXMLType(info.LabelTypeId));
                    result = label.Insert(info);
                    messagein += info.LabelCName + ",";
                }
                else
                {
                    if (flag.Equals(0))
                    {
                        result = label.Update(info);
                        messageupdata += info.LabelCName + ",";
                    }
                    if (flag.Equals(1))
                    {
                        messagereturn += info.LabelCName + ",";
                    }
                }
            }
            this.Label2.Text = "导入标签：" + messagein;
            this.Label3.Text = "更新标签：" + messageupdata;
            this.Label4.Text = "跳过标签：" + messagereturn;
        }

        #endregion

        #region 按标签分类导入

        private void LabelByType(int flag, String fieldpath)
        {
            int id = 0;
            XmlDocument docxml = new XmlDocument();
            DataTable dt = new DataTable();
            docxml.Load(fieldpath);

            XYECOM.Model.LabelTypeInfo ltinfo = new XYECOM.Model.LabelTypeInfo();

            XmlNodeList nodetypelist = docxml.GetElementsByTagName("typeitem");

            for (int i = 0; i < nodetypelist.Count; i++)
            {
                for (int j = 0; j < nodetypelist[i].ChildNodes.Count; j++)
                {
                    fieldname = nodetypelist[i].ChildNodes[j].Name;
                    if (fieldname.Equals("LT_ID"))
                    {
                        ltinfo.LT_ID = Convert.ToInt32(nodetypelist[i].ChildNodes[j].FirstChild.Value);
                    }
                    if (fieldname.Equals("LT_Name"))
                    {
                        ltinfo.LT_Name = nodetypelist[i].ChildNodes[j].FirstChild.Value;
                    }
                    
                    if (fieldname.Equals("LT_Remark"))
                    {
                        ltinfo.LT_Remark = nodetypelist[i].ChildNodes[j].FirstChild.Value;
                    }
                }
                id = GetTypeID(ltinfo.LT_Name, ltinfo);
            }

            XYECOM.Business.Label label = new XYECOM.Business.Label();
            XYECOM.Model.LabelInfo info = new XYECOM.Model.LabelInfo();

            XmlNodeList nodelist = docxml.GetElementsByTagName("item");

            XmlElement ele = null;

            string nodeVlaue = "";

            for (int i = 0; i < nodelist.Count; i++)
            {
                for (int j = 1; j < nodelist[i].ChildNodes.Count; j++)
                {
                    fieldname = nodelist[i].ChildNodes[j].Name;

                    ele = (XmlElement)nodelist[i];

                    nodeVlaue = XYECOM.Core.XML.XMLUtil.GetNodeValue(ele, fieldname);

                    if (fieldname.Equals("L_Name"))
                    {
                        dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from b_label where L_Name = '" + nodeVlaue + "'");
                        if (dt.Rows.Count > 0)
                        {
                            info.Id = Convert.ToInt32(dt.Rows[0]["L_ID"].ToString());
                        }
                        else
                        {
                            info.Id = 0;
                        }
                        info.LabelName = nodeVlaue;
                    }
                    if (fieldname.Equals("L_CName"))
                    {
                        info.LabelCName = nodeVlaue;
                    }
                    if (fieldname.Equals("LT_ID"))
                    {
                        info.LabelTypeId = id;
                    }
                    if (fieldname.Equals("L_TableName"))
                    {
                        info.LabelTableName = nodeVlaue;
                    }
                    if (fieldname.Equals("L_Content"))
                    {
                        info.LabelContent = nodeVlaue;
                    }
                    if (fieldname.Equals("L_StyleHead"))
                    {
                        info.LabelStyleHead = nodeVlaue;
                    }
                    if (fieldname.Equals("L_StyleContent"))
                    {
                        info.LabelStyleContent = nodeVlaue;
                    }
                    if (fieldname.Equals("L_StyleFooter"))
                    {
                        info.LabelStyleFooter = nodeVlaue;
                    }
                }
                if (info.Id.Equals(0))
                {
                    label.Insert(info);
                    messagein += info.LabelCName + ",";
                }
                else
                {
                    if (flag.Equals(0))
                    {
                        label.Update(info);
                        messageupdata += info.LabelCName + ",";
                    }
                    if (flag.Equals(1))
                    {
                        messagereturn += info.LabelCName + ",";
                    }
                }
            }
            this.Label2.Text = "导入标签：" + messagein;
            this.Label3.Text = "更新标签：" + messageupdata;
            this.Label4.Text = "跳过标签：" + messagereturn;
        }

        #endregion

        #region 返回分类ID

        private int GetTypeID(String name,XYECOM.Model.LabelTypeInfo info) {

            DataTable dt = new DataTable();

            XYECOM.Business.LabelType labeltype = new XYECOM.Business.LabelType();
            XYECOM.Model.LabelTypeInfo typeinfo = new XYECOM.Model.LabelTypeInfo();

            dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from b_labeltype where LT_Name = '"+ name +"'");
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["LT_ID"].ToString());
            }
            else {
                labeltype.Insert(info);
                dt = XYECOM.Core.Data.SqlHelper.ExecuteTable("select * from b_labeltype where LT_Name = '" + info.LT_Name + "'");
                return Convert.ToInt32(dt.Rows[0]["LT_ID"].ToString());
            }
        }

        #endregion

        #region 从XML读取一条分类信息

        private XYECOM.Model.LabelTypeInfo GetFromXMLType(long id)
        {
            XmlDocument docXml = new XmlDocument();
            DataTable dt = new DataTable();

            docXml.Load(fieldpath);
            XYECOM.Model.LabelTypeInfo ltinfo = new XYECOM.Model.LabelTypeInfo();

            XmlNodeList nodetypelist = docXml.GetElementsByTagName("typeitem");
            for (int i = 0; i < nodetypelist.Count; i++)
            {
                for (int j = 0; j < nodetypelist[i].ChildNodes.Count; j++)
                {
                    fieldname = nodetypelist[i].ChildNodes[j].Name;
                    if (fieldname.Equals("LT_ID"))
                    {
                        ltinfo.LT_ID =Convert.ToInt32(nodetypelist[i].ChildNodes[j].FirstChild.Value);
                    }
                    if (fieldname.Equals("LT_Name"))
                    {
                        ltinfo.LT_Name = nodetypelist[i].ChildNodes[j].FirstChild.Value;
                    }
                    
                    if (fieldname.Equals("LT_Remark"))
                    {
                        ltinfo.LT_Remark = nodetypelist[i].ChildNodes[j].FirstChild.Value;
                    }
                }
                if (ltinfo.LT_ID.ToString().Equals(id.ToString()))
                { 
                    return ltinfo;
                }
            }
            return ltinfo;
        }
        #endregion
    }
}
