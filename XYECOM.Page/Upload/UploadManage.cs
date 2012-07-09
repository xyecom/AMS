using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace XYECOM.Page.Upload
{
    public class UploadManage
    {
        private static XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

        /// <summary>
        /// 初始化文件上传
        /// </summary>
        /// <param name="page">当前页面的引用值为this</param>
        /// <param name="tableName">栏目所对应的表名称</param>
        /// <param name="maxAmount">最大可以上传的文件数量</param>
        /// <param name="iswatermark">是否打水印</param>
        /// <param name="id">栏目数据的id </param>
        public static void Upload(object page, Model.AttachmentItem item, int maxAmount, bool iswatermark, Int64 id, bool IsCreateThumbnailImg)
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                SavaUpload(id, IsCreateThumbnailImg);
            }

            SetUpload(page, item, maxAmount.ToString(), iswatermark.ToString().ToLower(), id);
        }

        public static void Upload(object page,Model.AttachmentItem item, int maxAmount, bool iswatermark, Int64 id)
        {
            Upload(page, item, maxAmount, iswatermark, id, true);
        }
       
        /// <summary>
        /// 初始化后台图片上传
        /// </summary>
        /// <param name="inputids">上传图片编号集合</param>
        /// <param name="inputfiles">上传的文件</param>
        /// <param name="item"></param>
        /// <param name="maxAmount">最大数量</param>
        /// <param name="iswatermark">是否启用</param>
        /// <param name="id">编号Id</param>
        /// <param name="IsCreateThumbnailImg">是否有缩略图</param>
        public static void Upload(ref string inputids, ref string inputfiles, Model.AttachmentItem item, int maxAmount, bool iswatermark, Int64 id, bool IsCreateThumbnailImg)
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                SavaUpload(id, IsCreateThumbnailImg);
            }
            SetUpload(ref inputids, ref inputfiles,item, maxAmount.ToString(), iswatermark.ToString().ToLower(), id);
        }
        /// <summary>
        /// 初始化文件上传
        /// </summary>
        /// <param name="inputids">附件编号集合</param>
        /// <param name="inputfiles">上传的附件</param>
        /// <param name="item">那个模块的附件</param>
        /// <param name="maxAmount">最大数量</param>
        /// <param name="iswatermark">是否启用</param>
        /// <param name="id">编号</param>
        public static void Upload(ref string inputids, ref string inputfiles, Model.AttachmentItem item, int maxAmount, bool iswatermark, Int64 id)
        {
            Upload(ref inputids, ref inputfiles, item, maxAmount, iswatermark, id, true);
        }



        #region 初始化上传
        /// <summary>
        /// 初始化文件上传
        /// </summary>
        /// <param name="page">当前页面的引用值为this</param>
        /// <param name="tableName">栏目所对应的表名称</param>
        /// <param name="maxAmount">最大可以上传的文件数量</param>
        /// <param name="id">栏目数据的id 新增则为0</param>
        private static void SetUpload(object page, Model.AttachmentItem item, string maxAmount, string iswatermark, Int64 id)
        {
            string ids = "", files = "";
            if (id > 0)
            {
                DataTable dt = new XYECOM.Business.Attachment().GetDataTable(id, item, XYECOM.Model.UploadFileType.Image);
                foreach (DataRow dr in dt.Rows)
                {
                    ids += "" == ids ? dr["AT_ID"].ToString() : "|" + dr["AT_ID"].ToString();
                    files += "" == files ? dr["S_URL"].ToString() + dr["AT_Path"].ToString() : "|" + dr["S_URL"].ToString() + dr["AT_Path"].ToString();
                }
            }

            BasePage objpage = (BasePage)page;
            objpage.tablename = Business.Attachment.GetDescTableName(item);
            objpage.maxamount = maxAmount;
            objpage.iswatermark = iswatermark;
            objpage.ids = ids;
            objpage.files = files;
        }
        /// <summary>
        /// 后台图片附件初始化
        /// </summary>
        /// <param name="inputids">上传图片编号集合</param>
        /// <param name="inputfiles">上传的文件</param>
        /// <param name="tableName">目标表名</param>
        /// <param name="maxAmount">最大数量</param>
        /// <param name="iswatermark">是否启用</param>
        /// <param name="id">编号</param>
        private static void SetUpload(ref string inputids, ref string inputfiles, Model.AttachmentItem item, string maxAmount, string iswatermark, Int64 id)
        {
            string ids = "", files = "";
            if (id > 0)
            {
                DataTable dt = new XYECOM.Business.Attachment().GetDataTable(id, item, XYECOM.Model.UploadFileType.Image);
                foreach (DataRow dr in dt.Rows)
                {
                    ids += "" == ids ? dr["AT_ID"].ToString() : "|" + dr["AT_ID"].ToString();
                    files += "" == files ? dr["S_URL"].ToString() + dr["AT_Path"].ToString() : "|" + dr["S_URL"].ToString() + dr["AT_Path"].ToString();
                }
            }
            inputids = ids;
            inputfiles = files;
        }
        #endregion

        #region 保存上传的信息
        /// <summary>
        /// 保存上传的信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="IsCreateThumbnailImg">是否创建极小图片</param>
        private static void SavaUpload(Int64 id, bool IsCreateThumbnailImg)
        {
            string DelIDs = XYECOM.Core.XYRequest.GetFormString("Upload_DelIDs");
            string UpIDs = XYECOM.Core.XYRequest.GetFormString("Upload_UpIDs");
            string TableName = XYECOM.Core.XYRequest.GetFormString("Upload_TabName");
            XYECOM.Business.Attachment obj = new XYECOM.Business.Attachment();
            //删除信息
            if ("" != DelIDs)
            {
                obj.Delete(DelIDs);

                //删除附件时同时更新附件对应的信息中 IsHasImage 字段的值
                //IsHasImage 字段表示信息是否包含图片
                if (id > 0)
                    obj.UpdateInfoIsHasImage(TableName, id);
            }
            //更新信息
            if ("" != UpIDs)
            {
                obj.Update(UpIDs, id);
            }
            //更新主图片
            UpdateInex(TableName, id, IsCreateThumbnailImg);
        }
        #endregion

        #region 修改信息的主图片index
        /// <summary>
        /// 修改信息的主图片index
        /// </summary>
        /// <param name="tableName">目标表明</param>
        /// <param name="id">编号</param>
        /// <param name="IsCreateThumbnailImg">是否创建缩略图</param>
        private static void UpdateInex(string tableName, Int64 id, bool IsCreateThumbnailImg)
        {
            XYECOM.Business.Attachment obj = new XYECOM.Business.Attachment();
            XYECOM.Model.AttachmentInfo info = XYECOM.Business.Attachment.GetTop1Info(tableName, id.ToString());
            //没有缩略图数据信息则退出
            if (null == info) return;
            //已经生成缩略图则推出
            if ("" != info.ThumbnailImg) return;

            if (IsCreateThumbnailImg)
            {
                //生成缩略图
                CreateThumbnailImgByInfo(info);
            }

            info.At_Index = 1;
            obj.Update(info);
        }
        #endregion
        
        #region 指定表名和信息来生成该条信息的缩略图
        /// <summary>
        /// 指定表明和信息来生成该条信息的缩略图
        /// </summary>
        /// <param name="info">实体对象</param>
        private static void CreateThumbnailImgByInfo(XYECOM.Model.AttachmentInfo info)
        {            
            //获取该图片的服务器配置信息
            XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(info.S_ID);
            string[] arr = info.At_Path.Split('/');
            string FileName = arr[arr.Length - 1];
            string SFolderPath = sconfig.S_Path + webInfo.UploadThumbnailImgFolder + "\\" + info.At_Path.Replace("/" + FileName, "").Replace("/", @"\\");
            //创建目录
            if (!Directory.Exists(SFolderPath))
            {
                Directory.CreateDirectory(SFolderPath);
            }
            string SFileURL = webInfo.UploadThumbnailImgFolder + "/" + info.At_Path.Replace("/" + FileName, "");
            string BaseFilePath = sconfig.S_Path + info.At_Path.Replace("/", @"\\");

            string SFolderFullPath;
            info.ThumbnailImg = "";
            if ("" != webInfo.UploadThumbnailImg1)
            {
                string s1 = FileName.Replace(".", "s1.");
                SFolderFullPath = SFolderPath + "\\" + s1;
                s1 = SFileURL + "/" + s1;
                CreateThumbnailState result = CreateThumbnailCutImg(BaseFilePath, SFolderFullPath, webInfo.UploadThumbnailImg1);
                if (result == CreateThumbnailState.Succeed)
                    info.ThumbnailImg = s1;
            }

            if ("" != webInfo.UploadThumbnailImg2)
            {
                string s2 = FileName.Replace(".", "s2.");
                SFolderFullPath = SFolderPath + "\\" + s2;
                s2 = SFileURL + "/" + s2;
                CreateThumbnailState result = CreateThumbnailCutImg(BaseFilePath, SFolderFullPath, webInfo.UploadThumbnailImg2);
                if (result == CreateThumbnailState.Succeed)
                    info.ThumbnailImg += "" == info.ThumbnailImg ? s2 : "|" + s2;
            }

            if ("" != webInfo.UploadThumbnailImg3)
            {
                string s3 = FileName.Replace(".", "s3.");
                SFolderFullPath = SFolderPath + "\\" + s3;
                s3 = SFileURL + "/" + s3;
                CreateThumbnailState result = CreateThumbnailCutImg(BaseFilePath, SFolderFullPath, webInfo.UploadThumbnailImg3);
                if (result == CreateThumbnailState.Succeed)
                    info.ThumbnailImg += "" == info.ThumbnailImg ? s3 : "|" + s3;
            }
        }
        #endregion

        #region 属性获取本次是否有上传的图片
        /// <summary>
        /// 是否上传图片
        /// </summary>
        public static bool IsUpfile
        {
            get
            {
                string upids = XYECOM.Core.XYRequest.GetQueryString("Upload_UpIDs");
                string delids = XYECOM.Core.XYRequest.GetQueryString("Upload_DelIDs");
                string oldids = XYECOM.Core.XYRequest.GetQueryString("Upload_IDs");
                if ("" != oldids)
                {
                    string[] arr = oldids.Split('|');
                    for (int iid = 0; iid < arr.Length; iid++)
                    {
                        if (delids.IndexOf(arr[iid]) == -1)
                            return true;
                    }
                }
                if ("" != upids)
                {
                    string[] arr = upids.Split('|');
                    for (int iid = 0; iid < arr.Length; iid++)
                    {
                        if (delids.IndexOf(arr[iid]) == -1)
                            return true;
                    }
                }
                return false;
            }
        }
        #endregion

        #region 生成缩略图
        /// <summary>
        /// 生成等比缩略的图片
        /// </summary>
        /// <param name="filePath">原图片地址</param>
        /// <param name="newPath">要生成的新的图片地址</param>
        /// <param name="fileDimension">要缩放的宽高格式为1024*768</param>
        /// <returns>缩略图描述</returns>
        private static CreateThumbnailState CreateThumbnailImg(string filePath, string newPath, string fileDimension)
        {
            if (!CheckFilePath(filePath))
                return CreateThumbnailState.NotFound;

            //要缩放的大小
            int zoomWidth, zoomHeight;
            string[] arrd = fileDimension.Split('*');
            if (arrd.Length >= 2)
            {
                zoomWidth = XYECOM.Core.MyConvert.GetInt32(arrd[0]);
                zoomHeight = XYECOM.Core.MyConvert.GetInt32(arrd[1]);
            }
            else
            {
                return CreateThumbnailState.DimensionError;
            }

            //载入要处理的图片
            Image img = Image.FromFile(filePath);
            int imgw, imgh, imgNewW = 0, imgNewH = 0;
            imgw = img.Width;
            imgh = img.Height;

            //判断是否需要生成缩略图
            bool ok = false;
            if (imgw / imgh >= zoomWidth / zoomHeight)
            {
                if (imgw > zoomWidth)
                {
                    ok = true;
                    imgNewW = zoomWidth;
                    imgNewH = zoomWidth * imgh / imgw;
                    if (imgNewH <= 0)
                        imgNewH = 1;
                }
            }
            else
            {
                if (imgh > zoomHeight)
                {
                    ok = true;
                    imgNewH = zoomHeight;
                    imgNewW = imgNewH * imgw / imgh;
                    if (imgNewW <= 0)
                        imgNewW = 1;
                }
            }
            if (ok)
            {
                Bitmap bitmay = new Bitmap(imgNewW, imgNewH);
                Graphics g = Graphics.FromImage(bitmay);
                g.DrawImage(img, new Rectangle(0, 0, imgNewW, imgNewH), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                bitmay.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                g.Dispose();
                bitmay.Dispose();
            }
            else//如果太小则copy原文件过去
            {
                File.Copy(filePath, newPath);
            }
            img.Dispose();
            if (ok)
                return CreateThumbnailState.Succeed;
            else
                return CreateThumbnailState.DimensionSmall;
        }

        /// <summary>
        /// 生成裁切的缩略图
        /// </summary>
        /// <param name="filePath">原图片地址</param>
        /// <param name="newPath">要生成的新的图片地址</param>
        /// <param name="fileDimension">要缩放的宽高格式为1024*768</param>
        /// <returns>缩略图描述</returns>
        private static CreateThumbnailState CreateThumbnailCutImg(string filePath, string newPath, string fileDimension)
        {
            if (!CheckFilePath(filePath))
                return CreateThumbnailState.NotFound;
            //要缩放的大小
            int zoomWidth, zoomHeight;
            string[] arrd = fileDimension.Split('*');
            if (arrd.Length >= 2)
            {
                zoomWidth = XYECOM.Core.MyConvert.GetInt32(arrd[0]);
                zoomHeight = XYECOM.Core.MyConvert.GetInt32(arrd[1]);
            }
            else
            {
                return CreateThumbnailState.DimensionError;
            }

            //载入要处理的图片
            Image img = Image.FromFile(filePath);

            //原图片的大小
            int imgw, imgh;

            imgw = img.Width;
            imgh = img.Height;

            //定义要裁切的图片的位置
            Bitmap bitmay = new Bitmap(zoomWidth, zoomHeight);
            Rectangle rec = new Rectangle();


            //宽缩放比例
            double wx = zoomWidth / (double)imgw;
            //高缩放比例
            double hy = zoomHeight / (double)imgh;

            if (zoomWidth < imgw && zoomHeight < imgh)
            {
                //原图比目标图小
                rec.Width = zoomWidth;
                rec.Height = zoomHeight;
                rec.X = 0;
                rec.Y = 0;
            }
            else
            {   
                //原图宽和高中至少有一边大于目标大小
                if (wx <= hy)
                {
                    //按照宽度缩放比例缩放
                    rec.Width = zoomWidth;
                    rec.Height = (int)(imgh * wx);

                    rec.X = 0;
                    rec.Y = (zoomHeight - rec.Height) / 2;
                }
                else
                {
                    //按照高度缩放比例缩放
                    rec.Width = (int)(imgw * hy);
                    rec.Height = zoomHeight;
                    rec.X = (zoomWidth - rec.Width) / 2;
                    rec.Y = 0;
                }
            }


            //开始生成缩略图
            
            Graphics g = Graphics.FromImage(bitmay);            
            Rectangle srcrect = new Rectangle(0, 0, imgw, imgh);
            g.Clear(Color.White);
            g.DrawImage(img, rec, srcrect, GraphicsUnit.Pixel);            
            //g.DrawImage(img, rec, srcrect, GraphicsUnit.Pixel);
            bitmay.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            bitmay.Dispose();

            img.Dispose();

            return CreateThumbnailState.Succeed;

        }
        #endregion

        /// <summary>
        /// 检测文件数否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否存在</returns>
        private static bool CheckFilePath(string filePath)
        {
            if (File.Exists(filePath))
                return true;
            return false;
        }

        //private static bool ThumbnailCallback()
        //{
        //    return false;
        //}

        #region 上传文件
        /// <summary>
        /// 判断文件类型是否允许上传
        /// </summary>
        /// <param name="fieleType">文件类型</param>
        /// <returns>是否允许上传</returns>
        private static bool CheckFileType(string fieleType,Model.UploadFileType fileType)
        {
            string[] ftypes = new string[] { "aspx", "js", "asp", "php", "jsp", "vbs", "html", "htm", "shtml", "shtm", "cgi", "asa", "asax" };
            foreach (string f in ftypes)
            {
                if (f == fieleType) return false;
            }
            

            string[] configtypes = new string[]{""};

            if (fileType == Model.UploadFileType.Image)
                configtypes = webInfo.UploadFileType.ToLower().Split(';');
            else
                configtypes = webInfo.UploadAdjunctType.ToLower().Split(';');
            
            foreach (string f in configtypes)
            {
                if (f == fieleType) return true;
            }
            return false;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>图片</returns>
        public static string UploadFile()
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                /**
                 * edit by liujia
                 * 参数 
                 * TabName  表的名称
                 * At_ID    对应图片表的id 如果不为空 则表示修改对应表的记录
                 * **/
                string TabName = XYECOM.Core.XYRequest.GetQueryString("TabName");

                Int64 AtID = 0;
                string strAtId = XYECOM.Core.XYRequest.GetQueryString("AtID");
                if (strAtId != "") AtID = Convert.ToInt64(strAtId);

                bool iswatermark = "true" == XYECOM.Core.XYRequest.GetQueryString("iswatermark");


                //取得图片服务器配置信息
                int S_ID = new XYECOM.Business.Server().GetCurrentServerID();
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(S_ID);
                if (S_ID <= 0)
                {
                    return "<script>var errmsf='上传失败！<br /> 附件服务器设置有误，请联系管理员!';UploadFileSave(errmsf,[]);</script>";
                }

                #region 创建目录
              
                string DateFolderName = DateTime.Now.ToString("yy-MM-dd");
                string SFolderPath = sconfig.S_Path + TabName + "\\" + DateFolderName;
                if (!Directory.Exists(SFolderPath))
                {
                    Directory.CreateDirectory(SFolderPath);
                }
                if (!Directory.Exists(SFolderPath))
                {
                    return "<script>var errmsf='上传失败！<br />附件服务器设置有误，请联系管理员!';UploadFileSave(errmsf,[]);</script>";
                }
                #endregion

                string errTypefiles = "";
                string errSizeFiles = "";
                string result = "";
                
                HttpFileCollection files = HttpContext.Current.Request.Files;
                for (int ifile = 0; ifile < files.Count; ifile++)
                {
                    HttpPostedFile f = files[ifile];
                    if (f.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(f.FileName);
                        string fileFormat = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();

                        if (!CheckFileType(fileFormat, Model.UploadFileType.Image))
                        {
                            errTypefiles += "" == errTypefiles ? filename : "," + filename;
                        }
                        else if (f.ContentLength / 1024 > webInfo.UploadFileSize)
                        {
                            errSizeFiles += "" == errSizeFiles ? filename : "," + filename;
                        }
                        else
                        {
                            string TargetFileName = DateTime.Now.ToString("yyMMddHHmmssFFF") + "." + fileFormat;
                            string SFileURL = TabName + "/" + DateFolderName + "/" + TargetFileName;
                            string SFolderFullPath = SFolderPath + "\\" + TargetFileName;
                            string SFileFullURL = sconfig.S_URL + SFileURL;
                            f.SaveAs(SFolderFullPath);

                            if ("gif" == fileFormat || "jpg" == fileFormat || "png" == fileFormat || "bmp" == fileFormat || "jpeg" == fileFormat)
                            {
                                if ("" != webInfo.UploadImg)
                                {
                                    //等比缩放图片
                                    string tmpfilepath = SFolderFullPath.Replace(TargetFileName, "tmp_" + TargetFileName);
                                    CreateThumbnailState createstate = UploadManage.CreateThumbnailImg(SFolderFullPath, tmpfilepath, webInfo.UploadImg);
                                    if (createstate == CreateThumbnailState.Succeed || createstate == CreateThumbnailState.DimensionSmall)
                                    {
                                        //置换文件
                                        File.Delete(SFolderFullPath);
                                        File.Move(tmpfilepath, SFolderFullPath);
                                    }
                                }

                                //添加水印
                                AddWaterMark(TargetFileName, SFolderFullPath, iswatermark, TabName, fileFormat);
                            }

                            //写入数据库
                            Int64 infoid = SaveDataBase(TabName, AtID, fileFormat, Model.UploadFileType.Image,SFileURL, S_ID);

                            result += "" == result ? "" : ",";
                            result += "{id:'" + infoid + "',url:'" + sconfig.S_URL + SFileURL + "'}";
                        }
                    }
                }

                string errmsg = "";
                if ("" != errTypefiles)
                {
                    errmsg += "文件中“" + errTypefiles + "”格式错误！<br />";
                }
                if ("" != errSizeFiles)
                {
                    errmsg += "文件中“" + errSizeFiles + "”文件太大！<br />";
                }
                return "<script>var errmsf='" + errmsg + "';var filelist = [" + result + "];UploadFileSave(errmsf,filelist);</script>";
            }
            return "";
        }
        #endregion
     

        #region 写入数据库
        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="tabName">目标表明</param>
        /// <param name="id">编号Id</param>
        /// <param name="fileFormat">存储格式</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="fileURL">储存位置</param>
        /// <param name="sconfigid">服务器编号</param>
        /// <returns>影响行数</returns>
        private static Int64 SaveDataBase(string tabName, Int64 id, string fileFormat, Model.UploadFileType fileType,string fileURL, int sconfigid)
        {
            XYECOM.Model.AttachmentInfo fileinfo = new XYECOM.Model.AttachmentInfo();

            Int64 atid = 0;

            if (0 < id)
            {
                fileinfo = new XYECOM.Business.Attachment().GetItem(id);
                if (fileinfo == null)
                {
                    fileinfo = new XYECOM.Model.AttachmentInfo();
                    id = 0;
                }
            }

            fileinfo.At_FileFormat = fileFormat;

            if (0 < id)
            {
                //删除原有图片
                XYECOM.Model.ServerInfo ffileconfig = new XYECOM.Business.Server().GetItem(fileinfo.S_ID);
                if (null != ffileconfig)
                {
                    string filepath = ffileconfig.S_Path + fileinfo.At_Path;
                    if (File.Exists(filepath))
                        File.Delete(filepath);

                    foreach (string ifile in fileinfo.SmallImg.Images)
                    {
                        filepath = ffileconfig.S_Path + ifile;
                        if (File.Exists(filepath))
                            File.Delete(filepath);
                    }
                }
                fileinfo.S_ID = sconfigid;
                fileinfo.At_Path = fileURL;
                fileinfo.ThumbnailImg = "";
                fileinfo.At_ID = id;
                fileinfo.At_Index = 0;
                new XYECOM.Business.Attachment().Update(fileinfo);
            }
            else
            {
                fileinfo.At_Path = fileURL;
                fileinfo.DescTabID = -1;
                fileinfo.At_FileType = fileType == Model.UploadFileType.Image?"image":"file";
                fileinfo.DescTabName = tabName;
                fileinfo.S_ID = sconfigid;
                fileinfo.At_Remark = "";
                new XYECOM.Business.Attachment().Insert(fileinfo, out atid);
            }
            return atid;
        }
        #endregion

        #region 图片水印操作
        /// <summary>
        ///图片水印操作
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileServerPath">路径</param>
        /// <param name="iswatermark">是否启用水印</param>
        /// <param name="TabName">目标表名</param>
        /// <param name="fileType">文件类型</param>
        private static void AddWaterMark(string fileName, string fileServerPath, bool iswatermark, string TabName, string fileType)
        {
            if (!CheckFilePath(fileServerPath))
                return ;

            //如果是企业证书 就必须加图片水印
            if ("u_Certificate" == TabName)
            {
                AddImage(fileName, fileServerPath, "居中", float.Parse("0.5"), "");
                return;
            }
            if (!iswatermark) return;
            if ("gif" == fileType) return;
            if (!webInfo.IsWaterMark) return;

            if (webInfo.WaterMarkType == 0)
            {
                AddFont(fileName, fileServerPath, webInfo.WaterMarkFont, webInfo.WaterMarkFontSize, webInfo.WaterMarkContent, webInfo.WaterMarkPlace, webInfo.WaterMarkColor);
            }
            else
            {
                AddImage(fileName, fileServerPath, webInfo.WaterMarkPicPlace, webInfo.WaterMarkPicDiaphaneity, webInfo.WaterMarkPicBgColor);
            }
        }
        #endregion

        #region 加文字水印
        /// <summary>
        /// 加文字水印
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="fontName">水印文字内容</param>
        /// <param name="FontSize">字体大小</param>
        /// <param name="font">字体格式</param>
        /// <param name="FontPlace">位置</param>
        /// <param name="FontColor">颜色</param>
        private static void AddFont(string fileName, string path, string fontName, int FontSize, string font, string FontPlace, string FontColor)
        {
            try
            {
                //加文字水印，注意，这里的代码和以下加图片水印的代码不能共存   
                System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.DrawImage(image, 0, 0, image.Width, image.Height);

                Font f = new Font(fontName, FontSize);
                Brush b = new SolidBrush(Color.FromName(FontColor.ToString()));
                string addText = font;
                int x = 0;
                int y = 0;
                switch (FontPlace)
                {
                    case "左上":
                        x = 10;
                        y = 10;
                        break;
                    case "右上":
                        x = Convert.ToInt32(image.Width - 10 - f.Size * font.Length);
                        y = 10;
                        break;
                    case "居中":
                        x = Convert.ToInt32((image.Width - f.Size * font.Length) / 2);
                        y = Convert.ToInt32((image.Height - f.Height) / 2);
                        break;
                    case "左下":
                        x = 10;
                        y = image.Height - f.Height - 10;
                        break;
                    case "右下":
                        x = Convert.ToInt32(image.Width - 10 - f.Size * font.Length);
                        y = image.Height - f.Height - 10;
                        break;
                    default:
                        break;
                }

                if (x > 0 || y > 0)
                {
                    g.DrawString(addText, f, b, x, y);
                    g.Dispose();

                    System.Drawing.Imaging.ImageCodecInfo myImageCodecInfo;
                    System.Drawing.Imaging.Encoder myEncoder;
                    System.Drawing.Imaging.EncoderParameter myEncoderParameter;
                    System.Drawing.Imaging.EncoderParameters myEncoderParameters;
                    myImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                    myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
                    myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 97L); // 0-100 
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    System.Text.StringBuilder newpath = new System.Text.StringBuilder(path);
                    newpath.Replace(fileName, "New_" + fileName);
                    //保存水印图片
                    image.Save(newpath.ToString(), myImageCodecInfo, myEncoderParameters);
                    image.Dispose();
                    //删除源文件
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    if (File.Exists(newpath.ToString()))
                    {
                        File.Copy(newpath.ToString(), path);
                        File.Delete(newpath.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 图片水印
        /// <summary>
        /// 添加图片水印
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="path">路径</param>
        /// <param name="WatermarkPath">水印路径</param>
        /// <param name="FontPlace">水印位置</param>
        /// <param name="PicDiaphaneity">水印透明度</param>
        /// <param name="WI_PicColor">水印底色</param>
        private static void AddImage(string fileName, string path, string FontPlace, float PicDiaphaneity, string WI_PicColor)
        {
            try
            {
                string WatermarkPath = HttpContext.Current.Server.MapPath(webInfo.WaterMarkPicURL);

                System.Drawing.Image image = System.Drawing.Image.FromFile(path);

                System.Drawing.Image copyimage = System.Drawing.Image.FromFile(WatermarkPath);

                if (image.Height > copyimage.Height || image.Width > copyimage.Width)
                {
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);

                    float[][] ptsArray ={ 
                                            new float[] {1, 0, 0, 0, 0},
                                            new float[] {0, 1, 0, 0, 0},
                                            new float[] {0, 0, 1, 0, 0},
                                            new float[] {0, 0, 0, PicDiaphaneity, 0}, //注意：此处为0.0f为完全透明，1.0f为完全不透明
                                            new float[] {0, 0, 0, 0, 1}};
                    System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(ptsArray);
                    //新建一个Image属性
                    System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
                    //将颜色矩阵添加到属性
                    imageAttributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Default);
                    int x = 0;
                    int y = 0;
                    switch (FontPlace)
                    {
                        case "左上":
                            x = 10;
                            y = 10;
                            break;
                        case "右上":
                            x = Convert.ToInt32(image.Width - 10 - copyimage.Width);
                            y = 10;
                            break;
                        case "居中":
                            x = Convert.ToInt32((image.Width - copyimage.Width) / 2);
                            y = Convert.ToInt32((image.Height - copyimage.Height) / 2);
                            break;
                        case "左下":
                            x = 10;
                            y = image.Height - copyimage.Height - 10;
                            break;
                        case "右下":
                            x = Convert.ToInt32(image.Width - 10 - copyimage.Width);
                            y = image.Height - copyimage.Height - 10;
                            break;
                        default:
                            break;
                    }
                    if (x > 0 || y > 0)
                    {
                        g.DrawImage(copyimage, new Rectangle(x, y, copyimage.Width, copyimage.Height), 0, 0, copyimage.Width, copyimage.Height, GraphicsUnit.Pixel, imageAttributes);
                        g.Dispose();

                        System.Drawing.Imaging.ImageCodecInfo myImageCodecInfo;
                        System.Drawing.Imaging.Encoder myEncoder;
                        System.Drawing.Imaging.EncoderParameter myEncoderParameter;
                        System.Drawing.Imaging.EncoderParameters myEncoderParameters;
                        myImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()[1];
                        myEncoder = System.Drawing.Imaging.Encoder.Quality;
                        myEncoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
                        myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 97L); // 0-100 
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        System.Text.StringBuilder newpath = new System.Text.StringBuilder(path);
                        newpath.Replace(fileName, "New_" + fileName);
                        //保存水印图片
                        image.Save(newpath.ToString(), myImageCodecInfo, myEncoderParameters);
                        image.Dispose();
                        //删除源文件
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        System.Drawing.Image newimage = System.Drawing.Image.FromFile(newpath.ToString());
                        newimage.Save(path, myImageCodecInfo, myEncoderParameters);
                        newimage.Dispose();
                        if (File.Exists(newpath.ToString()))
                        {
                            File.Delete(newpath.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 文件上传相关
     
        /// <summary>
        /// 后台空间更新上传文件
        /// </summary>
        /// <param name="infoId">信息Id</param>
        public static void UploadFile(long infoId)
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                SavaUploadFile(infoId);
            }
        }
  
        /// <summary>
        /// 保存上传文件信息（更新数据库）
        /// </summary>
        /// <param name="id">信息Id</param>
        private static void SavaUploadFile(Int64 id)
        {
            string DelIDs = XYECOM.Core.XYRequest.GetFormString("_Upload_DelIDs");
            string UpIDs = XYECOM.Core.XYRequest.GetFormString("_Upload_UpIDs");
            string TableName = XYECOM.Core.XYRequest.GetFormString("_Upload_TabName");

            XYECOM.Business.Attachment obj = new XYECOM.Business.Attachment();
            //删除信息
            if ("" != DelIDs)
            {
                obj.Delete(DelIDs);

                //删除附件时同时更新附件对应的信息中 IsHasImage 字段的值
                //IsHasImage 字段表示信息是否包含图片
                if (id > 0)
                    obj.UpdateInfoIsHasImage(TableName, id);
            }
            //更新信息
            if ("" != UpIDs)
            {
                obj.Update(UpIDs, id);
            }
        }

        /// <summary>
        /// 初始化已经上传文件(修改时使用)
        /// </summary>
        /// <param name="inputIds">上传图片编号集合</param>
        /// <param name="inputFiles">上传图片</param>
        /// <param name="maxAmount">最大数量</param>
        /// <param name="infoId">信息Id</param>
        public static void InitUploadFile(ref string inputIds,ref string inputFiles,int maxAmount,long infoId, Model.AttachmentItem item) 
        {
            string ids = "", files = "";
            if (infoId > 0)
            {
                DataTable dt = new XYECOM.Business.Attachment().GetDataTable(infoId, item, XYECOM.Model.UploadFileType.File);
                foreach (DataRow dr in dt.Rows)
                {
                    ids += "" == ids ? dr["AT_ID"].ToString() : "|" + dr["AT_ID"].ToString();
                    files += "" == files ?   Path.GetFileName(dr["AT_Path"].ToString()) : "|" + Path.GetFileName(dr["AT_Path"].ToString());
                }
            }
            inputIds = ids;
            inputFiles = files;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public static string _UploadFile()
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                /**
                 * edit by liujia
                 * 参数 
                 * TabName  表的名称
                 * At_ID    对应图片表的id 如果不为空 则表示修改对应表的记录
                 * **/
                string TabName = XYECOM.Core.XYRequest.GetQueryString("TabName");

                Int64 AtID = 0;
                string strAtId = XYECOM.Core.XYRequest.GetQueryString("AtID");
                if (strAtId != "") AtID = Convert.ToInt64(strAtId);

                //取得图片服务器配置信息
                int S_ID = new XYECOM.Business.Server().GetCurrentServerID();
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(S_ID);
                if (S_ID <= 0)
                {
                    return "<script>var errmsf='上传失败！<br /> 附件服务器设置有误，请联系管理员!';UploadFileSave(errmsf,[]);</script>";
                }

                #region 创建目录
                string DateFolderName = DateTime.Now.ToString("yy-MM-dd");
                string SFolderPath = sconfig.S_Path + "files\\" + TabName + "\\" + DateFolderName;
                if (!Directory.Exists(SFolderPath))
                {
                    Directory.CreateDirectory(SFolderPath);
                }
                if (!Directory.Exists(SFolderPath))
                {
                    return "<script>var errmsf='上传失败！<br />附件服务器设置有误，请联系管理员!';UploadFileSave(errmsf,[]);</script>";
                }
                #endregion

                string errTypefiles = "";
                string errSizeFiles = "";
                string result = "";

                HttpFileCollection files = HttpContext.Current.Request.Files;
                for (int ifile = 0; ifile < files.Count; ifile++)
                {
                    HttpPostedFile f = files[ifile];
                    if (f.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(f.FileName);
                        string fileFormat = Path.GetExtension(f.FileName).Substring(1);

                        if (!CheckFileType(fileFormat, Model.UploadFileType.File))
                        {
                            errTypefiles += "" == errTypefiles ? filename : "," + filename;
                        }
                        else if (f.ContentLength / 1024 > webInfo.UploadAdjunctSize)
                        {
                            errSizeFiles += "" == errSizeFiles ? filename : "," + filename;
                        }
                        else
                        {
                            string TargetFileName = filename;

                            string SFolderFullPath = SFolderPath + "\\" + TargetFileName;

                            if (File.Exists(SFolderFullPath))
                            {
                                TargetFileName = Path.GetFileNameWithoutExtension(f.FileName) +"("+ (new Random().Next(10, 99)) + ")." + fileFormat;
                                SFolderFullPath = SFolderPath + "\\" + TargetFileName;
                            }


                            string SFileURL = "files/" + TabName + "/" + DateFolderName + "/" + TargetFileName;
                            string SFileFullURL = sconfig.S_URL + SFileURL;

                            f.SaveAs(SFolderFullPath);

                            //写入数据库
                            Int64 infoid = SaveDataBase(TabName, AtID, fileFormat, Model.UploadFileType.File, SFileURL, S_ID);

                            result += "" == result ? "" : ",";
                            result += "{id:'" + infoid + "',url:'" + Path.GetFileName(SFolderFullPath) + "'}";
                        }
                    }
                }

                string errmsg = "";
                if ("" != errTypefiles)
                {
                    errmsg += "文件中“" + errTypefiles + "”格式错误！<br />";
                }
                if ("" != errSizeFiles)
                {
                    errmsg += "文件中“" + errSizeFiles + "”文件太大！<br />";
                }
                return "<script>var errmsf='" + errmsg + "';var filelist = [" + result + "];UploadFileSave(errmsf,filelist);</script>";
            }
            return "";
        }

        #endregion
    }
}
