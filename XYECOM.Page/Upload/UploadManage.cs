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
        /// ��ʼ���ļ��ϴ�
        /// </summary>
        /// <param name="page">��ǰҳ�������ֵΪthis</param>
        /// <param name="tableName">��Ŀ����Ӧ�ı�����</param>
        /// <param name="maxAmount">�������ϴ����ļ�����</param>
        /// <param name="iswatermark">�Ƿ��ˮӡ</param>
        /// <param name="id">��Ŀ���ݵ�id </param>
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
        /// ��ʼ����̨ͼƬ�ϴ�
        /// </summary>
        /// <param name="inputids">�ϴ�ͼƬ��ż���</param>
        /// <param name="inputfiles">�ϴ����ļ�</param>
        /// <param name="item"></param>
        /// <param name="maxAmount">�������</param>
        /// <param name="iswatermark">�Ƿ�����</param>
        /// <param name="id">���Id</param>
        /// <param name="IsCreateThumbnailImg">�Ƿ�������ͼ</param>
        public static void Upload(ref string inputids, ref string inputfiles, Model.AttachmentItem item, int maxAmount, bool iswatermark, Int64 id, bool IsCreateThumbnailImg)
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                SavaUpload(id, IsCreateThumbnailImg);
            }
            SetUpload(ref inputids, ref inputfiles,item, maxAmount.ToString(), iswatermark.ToString().ToLower(), id);
        }
        /// <summary>
        /// ��ʼ���ļ��ϴ�
        /// </summary>
        /// <param name="inputids">������ż���</param>
        /// <param name="inputfiles">�ϴ��ĸ���</param>
        /// <param name="item">�Ǹ�ģ��ĸ���</param>
        /// <param name="maxAmount">�������</param>
        /// <param name="iswatermark">�Ƿ�����</param>
        /// <param name="id">���</param>
        public static void Upload(ref string inputids, ref string inputfiles, Model.AttachmentItem item, int maxAmount, bool iswatermark, Int64 id)
        {
            Upload(ref inputids, ref inputfiles, item, maxAmount, iswatermark, id, true);
        }



        #region ��ʼ���ϴ�
        /// <summary>
        /// ��ʼ���ļ��ϴ�
        /// </summary>
        /// <param name="page">��ǰҳ�������ֵΪthis</param>
        /// <param name="tableName">��Ŀ����Ӧ�ı�����</param>
        /// <param name="maxAmount">�������ϴ����ļ�����</param>
        /// <param name="id">��Ŀ���ݵ�id ������Ϊ0</param>
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
        /// ��̨ͼƬ������ʼ��
        /// </summary>
        /// <param name="inputids">�ϴ�ͼƬ��ż���</param>
        /// <param name="inputfiles">�ϴ����ļ�</param>
        /// <param name="tableName">Ŀ�����</param>
        /// <param name="maxAmount">�������</param>
        /// <param name="iswatermark">�Ƿ�����</param>
        /// <param name="id">���</param>
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

        #region �����ϴ�����Ϣ
        /// <summary>
        /// �����ϴ�����Ϣ
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="IsCreateThumbnailImg">�Ƿ񴴽���СͼƬ</param>
        private static void SavaUpload(Int64 id, bool IsCreateThumbnailImg)
        {
            string DelIDs = XYECOM.Core.XYRequest.GetFormString("Upload_DelIDs");
            string UpIDs = XYECOM.Core.XYRequest.GetFormString("Upload_UpIDs");
            string TableName = XYECOM.Core.XYRequest.GetFormString("Upload_TabName");
            XYECOM.Business.Attachment obj = new XYECOM.Business.Attachment();
            //ɾ����Ϣ
            if ("" != DelIDs)
            {
                obj.Delete(DelIDs);

                //ɾ������ʱͬʱ���¸�����Ӧ����Ϣ�� IsHasImage �ֶε�ֵ
                //IsHasImage �ֶα�ʾ��Ϣ�Ƿ����ͼƬ
                if (id > 0)
                    obj.UpdateInfoIsHasImage(TableName, id);
            }
            //������Ϣ
            if ("" != UpIDs)
            {
                obj.Update(UpIDs, id);
            }
            //������ͼƬ
            UpdateInex(TableName, id, IsCreateThumbnailImg);
        }
        #endregion

        #region �޸���Ϣ����ͼƬindex
        /// <summary>
        /// �޸���Ϣ����ͼƬindex
        /// </summary>
        /// <param name="tableName">Ŀ�����</param>
        /// <param name="id">���</param>
        /// <param name="IsCreateThumbnailImg">�Ƿ񴴽�����ͼ</param>
        private static void UpdateInex(string tableName, Int64 id, bool IsCreateThumbnailImg)
        {
            XYECOM.Business.Attachment obj = new XYECOM.Business.Attachment();
            XYECOM.Model.AttachmentInfo info = XYECOM.Business.Attachment.GetTop1Info(tableName, id.ToString());
            //û������ͼ������Ϣ���˳�
            if (null == info) return;
            //�Ѿ���������ͼ���Ƴ�
            if ("" != info.ThumbnailImg) return;

            if (IsCreateThumbnailImg)
            {
                //��������ͼ
                CreateThumbnailImgByInfo(info);
            }

            info.At_Index = 1;
            obj.Update(info);
        }
        #endregion
        
        #region ָ����������Ϣ�����ɸ�����Ϣ������ͼ
        /// <summary>
        /// ָ����������Ϣ�����ɸ�����Ϣ������ͼ
        /// </summary>
        /// <param name="info">ʵ�����</param>
        private static void CreateThumbnailImgByInfo(XYECOM.Model.AttachmentInfo info)
        {            
            //��ȡ��ͼƬ�ķ�����������Ϣ
            XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(info.S_ID);
            string[] arr = info.At_Path.Split('/');
            string FileName = arr[arr.Length - 1];
            string SFolderPath = sconfig.S_Path + webInfo.UploadThumbnailImgFolder + "\\" + info.At_Path.Replace("/" + FileName, "").Replace("/", @"\\");
            //����Ŀ¼
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

        #region ���Ի�ȡ�����Ƿ����ϴ���ͼƬ
        /// <summary>
        /// �Ƿ��ϴ�ͼƬ
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

        #region ��������ͼ
        /// <summary>
        /// ���ɵȱ����Ե�ͼƬ
        /// </summary>
        /// <param name="filePath">ԭͼƬ��ַ</param>
        /// <param name="newPath">Ҫ���ɵ��µ�ͼƬ��ַ</param>
        /// <param name="fileDimension">Ҫ���ŵĿ�߸�ʽΪ1024*768</param>
        /// <returns>����ͼ����</returns>
        private static CreateThumbnailState CreateThumbnailImg(string filePath, string newPath, string fileDimension)
        {
            if (!CheckFilePath(filePath))
                return CreateThumbnailState.NotFound;

            //Ҫ���ŵĴ�С
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

            //����Ҫ�����ͼƬ
            Image img = Image.FromFile(filePath);
            int imgw, imgh, imgNewW = 0, imgNewH = 0;
            imgw = img.Width;
            imgh = img.Height;

            //�ж��Ƿ���Ҫ��������ͼ
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
            else//���̫С��copyԭ�ļ���ȥ
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
        /// ���ɲ��е�����ͼ
        /// </summary>
        /// <param name="filePath">ԭͼƬ��ַ</param>
        /// <param name="newPath">Ҫ���ɵ��µ�ͼƬ��ַ</param>
        /// <param name="fileDimension">Ҫ���ŵĿ�߸�ʽΪ1024*768</param>
        /// <returns>����ͼ����</returns>
        private static CreateThumbnailState CreateThumbnailCutImg(string filePath, string newPath, string fileDimension)
        {
            if (!CheckFilePath(filePath))
                return CreateThumbnailState.NotFound;
            //Ҫ���ŵĴ�С
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

            //����Ҫ�����ͼƬ
            Image img = Image.FromFile(filePath);

            //ԭͼƬ�Ĵ�С
            int imgw, imgh;

            imgw = img.Width;
            imgh = img.Height;

            //����Ҫ���е�ͼƬ��λ��
            Bitmap bitmay = new Bitmap(zoomWidth, zoomHeight);
            Rectangle rec = new Rectangle();


            //�����ű���
            double wx = zoomWidth / (double)imgw;
            //�����ű���
            double hy = zoomHeight / (double)imgh;

            if (zoomWidth < imgw && zoomHeight < imgh)
            {
                //ԭͼ��Ŀ��ͼС
                rec.Width = zoomWidth;
                rec.Height = zoomHeight;
                rec.X = 0;
                rec.Y = 0;
            }
            else
            {   
                //ԭͼ��͸���������һ�ߴ���Ŀ���С
                if (wx <= hy)
                {
                    //���տ�����ű�������
                    rec.Width = zoomWidth;
                    rec.Height = (int)(imgh * wx);

                    rec.X = 0;
                    rec.Y = (zoomHeight - rec.Height) / 2;
                }
                else
                {
                    //���ո߶����ű�������
                    rec.Width = (int)(imgw * hy);
                    rec.Height = zoomHeight;
                    rec.X = (zoomWidth - rec.Width) / 2;
                    rec.Y = 0;
                }
            }


            //��ʼ��������ͼ
            
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
        /// ����ļ��������
        /// </summary>
        /// <param name="filePath">�ļ�·��</param>
        /// <returns>�Ƿ����</returns>
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

        #region �ϴ��ļ�
        /// <summary>
        /// �ж��ļ������Ƿ������ϴ�
        /// </summary>
        /// <param name="fieleType">�ļ�����</param>
        /// <returns>�Ƿ������ϴ�</returns>
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
        /// �ϴ�ͼƬ
        /// </summary>
        /// <returns>ͼƬ</returns>
        public static string UploadFile()
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                /**
                 * edit by liujia
                 * ���� 
                 * TabName  �������
                 * At_ID    ��ӦͼƬ���id �����Ϊ�� ���ʾ�޸Ķ�Ӧ��ļ�¼
                 * **/
                string TabName = XYECOM.Core.XYRequest.GetQueryString("TabName");

                Int64 AtID = 0;
                string strAtId = XYECOM.Core.XYRequest.GetQueryString("AtID");
                if (strAtId != "") AtID = Convert.ToInt64(strAtId);

                bool iswatermark = "true" == XYECOM.Core.XYRequest.GetQueryString("iswatermark");


                //ȡ��ͼƬ������������Ϣ
                int S_ID = new XYECOM.Business.Server().GetCurrentServerID();
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(S_ID);
                if (S_ID <= 0)
                {
                    return "<script>var errmsf='�ϴ�ʧ�ܣ�<br /> ����������������������ϵ����Ա!';UploadFileSave(errmsf,[]);</script>";
                }

                #region ����Ŀ¼
              
                string DateFolderName = DateTime.Now.ToString("yy-MM-dd");
                string SFolderPath = sconfig.S_Path + TabName + "\\" + DateFolderName;
                if (!Directory.Exists(SFolderPath))
                {
                    Directory.CreateDirectory(SFolderPath);
                }
                if (!Directory.Exists(SFolderPath))
                {
                    return "<script>var errmsf='�ϴ�ʧ�ܣ�<br />����������������������ϵ����Ա!';UploadFileSave(errmsf,[]);</script>";
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
                                    //�ȱ�����ͼƬ
                                    string tmpfilepath = SFolderFullPath.Replace(TargetFileName, "tmp_" + TargetFileName);
                                    CreateThumbnailState createstate = UploadManage.CreateThumbnailImg(SFolderFullPath, tmpfilepath, webInfo.UploadImg);
                                    if (createstate == CreateThumbnailState.Succeed || createstate == CreateThumbnailState.DimensionSmall)
                                    {
                                        //�û��ļ�
                                        File.Delete(SFolderFullPath);
                                        File.Move(tmpfilepath, SFolderFullPath);
                                    }
                                }

                                //���ˮӡ
                                AddWaterMark(TargetFileName, SFolderFullPath, iswatermark, TabName, fileFormat);
                            }

                            //д�����ݿ�
                            Int64 infoid = SaveDataBase(TabName, AtID, fileFormat, Model.UploadFileType.Image,SFileURL, S_ID);

                            result += "" == result ? "" : ",";
                            result += "{id:'" + infoid + "',url:'" + sconfig.S_URL + SFileURL + "'}";
                        }
                    }
                }

                string errmsg = "";
                if ("" != errTypefiles)
                {
                    errmsg += "�ļ��С�" + errTypefiles + "����ʽ����<br />";
                }
                if ("" != errSizeFiles)
                {
                    errmsg += "�ļ��С�" + errSizeFiles + "���ļ�̫��<br />";
                }
                return "<script>var errmsf='" + errmsg + "';var filelist = [" + result + "];UploadFileSave(errmsf,filelist);</script>";
            }
            return "";
        }
        #endregion
     

        #region д�����ݿ�
        /// <summary>
        /// д�����ݿ�
        /// </summary>
        /// <param name="tabName">Ŀ�����</param>
        /// <param name="id">���Id</param>
        /// <param name="fileFormat">�洢��ʽ</param>
        /// <param name="fileType">�ļ�����</param>
        /// <param name="fileURL">����λ��</param>
        /// <param name="sconfigid">���������</param>
        /// <returns>Ӱ������</returns>
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
                //ɾ��ԭ��ͼƬ
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

        #region ͼƬˮӡ����
        /// <summary>
        ///ͼƬˮӡ����
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="fileServerPath">·��</param>
        /// <param name="iswatermark">�Ƿ�����ˮӡ</param>
        /// <param name="TabName">Ŀ�����</param>
        /// <param name="fileType">�ļ�����</param>
        private static void AddWaterMark(string fileName, string fileServerPath, bool iswatermark, string TabName, string fileType)
        {
            if (!CheckFilePath(fileServerPath))
                return ;

            //�������ҵ֤�� �ͱ����ͼƬˮӡ
            if ("u_Certificate" == TabName)
            {
                AddImage(fileName, fileServerPath, "����", float.Parse("0.5"), "");
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

        #region ������ˮӡ
        /// <summary>
        /// ������ˮӡ
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        /// <param name="fontName">ˮӡ��������</param>
        /// <param name="FontSize">�����С</param>
        /// <param name="font">�����ʽ</param>
        /// <param name="FontPlace">λ��</param>
        /// <param name="FontColor">��ɫ</param>
        private static void AddFont(string fileName, string path, string fontName, int FontSize, string font, string FontPlace, string FontColor)
        {
            try
            {
                //������ˮӡ��ע�⣬����Ĵ�������¼�ͼƬˮӡ�Ĵ��벻�ܹ���   
                System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                //���ø�������ֵ��
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                //���ø�����,���ٶȳ���ƽ���̶�
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.DrawImage(image, 0, 0, image.Width, image.Height);

                Font f = new Font(fontName, FontSize);
                Brush b = new SolidBrush(Color.FromName(FontColor.ToString()));
                string addText = font;
                int x = 0;
                int y = 0;
                switch (FontPlace)
                {
                    case "����":
                        x = 10;
                        y = 10;
                        break;
                    case "����":
                        x = Convert.ToInt32(image.Width - 10 - f.Size * font.Length);
                        y = 10;
                        break;
                    case "����":
                        x = Convert.ToInt32((image.Width - f.Size * font.Length) / 2);
                        y = Convert.ToInt32((image.Height - f.Height) / 2);
                        break;
                    case "����":
                        x = 10;
                        y = image.Height - f.Height - 10;
                        break;
                    case "����":
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
                    //����ˮӡͼƬ
                    image.Save(newpath.ToString(), myImageCodecInfo, myEncoderParameters);
                    image.Dispose();
                    //ɾ��Դ�ļ�
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

        #region ͼƬˮӡ
        /// <summary>
        /// ���ͼƬˮӡ
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="path">·��</param>
        /// <param name="WatermarkPath">ˮӡ·��</param>
        /// <param name="FontPlace">ˮӡλ��</param>
        /// <param name="PicDiaphaneity">ˮӡ͸����</param>
        /// <param name="WI_PicColor">ˮӡ��ɫ</param>
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
                                            new float[] {0, 0, 0, PicDiaphaneity, 0}, //ע�⣺�˴�Ϊ0.0fΪ��ȫ͸����1.0fΪ��ȫ��͸��
                                            new float[] {0, 0, 0, 0, 1}};
                    System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(ptsArray);
                    //�½�һ��Image����
                    System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
                    //����ɫ������ӵ�����
                    imageAttributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Default);
                    int x = 0;
                    int y = 0;
                    switch (FontPlace)
                    {
                        case "����":
                            x = 10;
                            y = 10;
                            break;
                        case "����":
                            x = Convert.ToInt32(image.Width - 10 - copyimage.Width);
                            y = 10;
                            break;
                        case "����":
                            x = Convert.ToInt32((image.Width - copyimage.Width) / 2);
                            y = Convert.ToInt32((image.Height - copyimage.Height) / 2);
                            break;
                        case "����":
                            x = 10;
                            y = image.Height - copyimage.Height - 10;
                            break;
                        case "����":
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
                        //����ˮӡͼƬ
                        image.Save(newpath.ToString(), myImageCodecInfo, myEncoderParameters);
                        image.Dispose();
                        //ɾ��Դ�ļ�
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


        #region �ļ��ϴ����
     
        /// <summary>
        /// ��̨�ռ�����ϴ��ļ�
        /// </summary>
        /// <param name="infoId">��ϢId</param>
        public static void UploadFile(long infoId)
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                SavaUploadFile(infoId);
            }
        }
  
        /// <summary>
        /// �����ϴ��ļ���Ϣ���������ݿ⣩
        /// </summary>
        /// <param name="id">��ϢId</param>
        private static void SavaUploadFile(Int64 id)
        {
            string DelIDs = XYECOM.Core.XYRequest.GetFormString("_Upload_DelIDs");
            string UpIDs = XYECOM.Core.XYRequest.GetFormString("_Upload_UpIDs");
            string TableName = XYECOM.Core.XYRequest.GetFormString("_Upload_TabName");

            XYECOM.Business.Attachment obj = new XYECOM.Business.Attachment();
            //ɾ����Ϣ
            if ("" != DelIDs)
            {
                obj.Delete(DelIDs);

                //ɾ������ʱͬʱ���¸�����Ӧ����Ϣ�� IsHasImage �ֶε�ֵ
                //IsHasImage �ֶα�ʾ��Ϣ�Ƿ����ͼƬ
                if (id > 0)
                    obj.UpdateInfoIsHasImage(TableName, id);
            }
            //������Ϣ
            if ("" != UpIDs)
            {
                obj.Update(UpIDs, id);
            }
        }

        /// <summary>
        /// ��ʼ���Ѿ��ϴ��ļ�(�޸�ʱʹ��)
        /// </summary>
        /// <param name="inputIds">�ϴ�ͼƬ��ż���</param>
        /// <param name="inputFiles">�ϴ�ͼƬ</param>
        /// <param name="maxAmount">�������</param>
        /// <param name="infoId">��ϢId</param>
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
        /// �ϴ��ļ�
        /// </summary>
        /// <returns></returns>
        public static string _UploadFile()
        {
            if (XYECOM.Core.XYRequest.IsPost())
            {
                /**
                 * edit by liujia
                 * ���� 
                 * TabName  �������
                 * At_ID    ��ӦͼƬ���id �����Ϊ�� ���ʾ�޸Ķ�Ӧ��ļ�¼
                 * **/
                string TabName = XYECOM.Core.XYRequest.GetQueryString("TabName");

                Int64 AtID = 0;
                string strAtId = XYECOM.Core.XYRequest.GetQueryString("AtID");
                if (strAtId != "") AtID = Convert.ToInt64(strAtId);

                //ȡ��ͼƬ������������Ϣ
                int S_ID = new XYECOM.Business.Server().GetCurrentServerID();
                XYECOM.Model.ServerInfo sconfig = new XYECOM.Business.Server().GetItem(S_ID);
                if (S_ID <= 0)
                {
                    return "<script>var errmsf='�ϴ�ʧ�ܣ�<br /> ����������������������ϵ����Ա!';UploadFileSave(errmsf,[]);</script>";
                }

                #region ����Ŀ¼
                string DateFolderName = DateTime.Now.ToString("yy-MM-dd");
                string SFolderPath = sconfig.S_Path + "files\\" + TabName + "\\" + DateFolderName;
                if (!Directory.Exists(SFolderPath))
                {
                    Directory.CreateDirectory(SFolderPath);
                }
                if (!Directory.Exists(SFolderPath))
                {
                    return "<script>var errmsf='�ϴ�ʧ�ܣ�<br />����������������������ϵ����Ա!';UploadFileSave(errmsf,[]);</script>";
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

                            //д�����ݿ�
                            Int64 infoid = SaveDataBase(TabName, AtID, fileFormat, Model.UploadFileType.File, SFileURL, S_ID);

                            result += "" == result ? "" : ",";
                            result += "{id:'" + infoid + "',url:'" + Path.GetFileName(SFolderFullPath) + "'}";
                        }
                    }
                }

                string errmsg = "";
                if ("" != errTypefiles)
                {
                    errmsg += "�ļ��С�" + errTypefiles + "����ʽ����<br />";
                }
                if ("" != errSizeFiles)
                {
                    errmsg += "�ļ��С�" + errSizeFiles + "���ļ�̫��<br />";
                }
                return "<script>var errmsf='" + errmsg + "';var filelist = [" + result + "];UploadFileSave(errmsf,filelist);</script>";
            }
            return "";
        }

        #endregion
    }
}
