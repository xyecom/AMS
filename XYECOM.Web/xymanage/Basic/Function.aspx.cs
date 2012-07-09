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

namespace XYECOM.Web.xymanage.Basic
{
    public partial class Function : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("basic");
            if (!IsPostBack)
            {
                PageInit();
            }
        }
        private void PageInit()
        {
            tbUploadImg.Text = webInfo.UploadImg;
            tbUploadThumbnailImgFolder.Text = webInfo.UploadThumbnailImgFolder;
            tbUploadThumbnailImg1.Text = webInfo.UploadThumbnailImg1;
            tbUploadThumbnailImg2.Text = webInfo.UploadThumbnailImg2;
            tbUploadThumbnailImg3.Text = webInfo.UploadThumbnailImg3;
            rblIsWaterMark.Text = webInfo.IsWaterMark ? "1" : "0";
            rblWaterMarkType.Text = webInfo.WaterMarkType.ToString();
            tbWaterMarkContent.Text = webInfo.WaterMarkContent;
            ddlWaterMarkFont.Text = webInfo.WaterMarkFont;
            ddlWaterMarkFontSize.Text = webInfo.WaterMarkFontSize.ToString();
            ddlWaterMarkPicPlace.Text = webInfo.WaterMarkPicPlace;
            ddlWaterMarkColor.Text = webInfo.WaterMarkColor;
            ddlWaterMarkPlace.Text = webInfo.WaterMarkPlace;
            ddlWaterMarkPicPlace.Text = webInfo.WaterMarkPicPlace;
            ddlWaterMarkPicDiaphaneity.Text = webInfo.WaterMarkPicDiaphaneity.ToString();
            ddlWaterMarkPicBgColor.Text = webInfo.WaterMarkPicBgColor;
            tbUploadFileType.Text = webInfo.UploadFileType;
            tbUploadFileSize.Text = webInfo.UploadFileSize.ToString();
            tbUploadAdjunctType.Text = webInfo.UploadAdjunctType;
            tbUploadAdjunctSize.Text = webInfo.UploadAdjunctSize.ToString();

            rdoIsAutoGatherSearchKey.Text = webInfo.IsAutoGatherSearchKey.ToString().ToLower();

            this.txtAboutNewsNum.Text = webInfo.AboutNewsNum.ToString();

            imgWaterMarkPicURL.ImageUrl = webInfo.WaterMarkPicURL;
            lbWaterMarkPicURL.Text = "水印图片路径为：" + webInfo.WaterMarkPicURL;
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            webInfo.UploadImg = tbUploadImg.Text;
            webInfo.UploadThumbnailImgFolder = tbUploadThumbnailImgFolder.Text;
            webInfo.UploadThumbnailImg1 = tbUploadThumbnailImg1.Text;
            webInfo.UploadThumbnailImg2 = tbUploadThumbnailImg2.Text;
            webInfo.UploadThumbnailImg3 = tbUploadThumbnailImg3.Text;

            webInfo.IsWaterMark = "1" == rblIsWaterMark.Text;
            webInfo.WaterMarkType = XYECOM.Core.MyConvert.GetInt32(rblWaterMarkType.Text);
            webInfo.WaterMarkContent = tbWaterMarkContent.Text;
            webInfo.WaterMarkFont = ddlWaterMarkFont.Text;
            webInfo.WaterMarkFontSize = XYECOM.Core.MyConvert.GetInt32(ddlWaterMarkFontSize.Text);
            webInfo.WaterMarkPicPlace = ddlWaterMarkPicPlace.Text;
            webInfo.WaterMarkColor = ddlWaterMarkColor.Text;
            webInfo.WaterMarkPlace = ddlWaterMarkPlace.Text;
            webInfo.WaterMarkPicPlace = ddlWaterMarkPicPlace.Text;
            webInfo.WaterMarkPicDiaphaneity = XYECOM.Core.MyConvert.GetFloat(ddlWaterMarkPicDiaphaneity.Text);
            webInfo.WaterMarkPicBgColor = ddlWaterMarkPicBgColor.Text;

            webInfo.UploadFileType = tbUploadFileType.Text;
            webInfo.UploadFileSize = XYECOM.Core.MyConvert.GetInt32(tbUploadFileSize.Text);
            webInfo.UploadAdjunctType = tbUploadAdjunctType.Text;
            webInfo.UploadAdjunctSize = XYECOM.Core.MyConvert.GetInt32(tbUploadAdjunctSize.Text);
            webInfo.AboutNewsNum = XYECOM.Core.MyConvert.GetInt32(txtAboutNewsNum.Text.Trim());

            webInfo.IsAutoGatherSearchKey = XYECOM.Core.MyConvert.GetBoolean(rdoIsAutoGatherSearchKey.Text.Trim());

            if (!webInfo.Update())
                Alert("设置失败，请检查/Config/目录可写属性！");
            else
                Alert("设置成功！");
        }
    }
}
