using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Drawing;
using System.Web.SessionState;
using System.Text;

namespace XYECOM.Web.Common
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ValidateCode : IHttpHandler, IRequiresSessionState
    {
        static System.Web.HttpContext context = null;

        public void ProcessRequest(HttpContext c)
        {
            context = c;

            string ip = XYECOM.Core.XYRequest.GetIP();

            //IP判断
            if (XYECOM.Configuration.Security.Instance._ForbidIP.Contains(ip))
            {
                context.Response.Write("-禁止访问-");
                context.Response.End();
            }

            context.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

            string code = ClsValidateCode.Generate();

            XYECOM.Core.Utils.SetSession("VNum", code);
        }

        #region 普通验证码生成类

        internal class ClsValidateCode
        {
            /// <summary>
            /// 产生验证码
            /// </summary>
            /// <returns>返回结果为验证码内容</returns>
            public static string Generate()
            {
                context.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

                string code = GenerateCode();

                CreateValidateCodeImage(code);

                return code;
            }

            static int FontSize = 14;

            static int Padding = 2;    //边框补(默认1像素)

            static bool Chaos = true;   //是否输出燥点(默认不输出)

            static Color ChaosColor = Color.LightGray;//输出燥点的颜色(默认灰色)

            static Color BackgroundColor = Color.White; //自定义背景色(默认白色)

            //自定义随机颜色数组
            static Color[] Colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Brown, Color.DarkCyan, Color.Purple };

            //自定义字体数组
            static string[] Fonts = { "Arial", "Georgia","Catull Bold","微软雅黑","黑体","隶书"};
            //static string[] Fonts = { "Nina" };

            #region 产生波形滤镜效果

            private const double PI = 3.1415926535897932384626433832795;
            private const double PI2 = 6.283185307179586476925286766559;

            /// <summary>
            /// 正弦曲线Wave扭曲图片
            /// </summary>
            /// <param name="srcBmp">图片路径</param>
            /// <param name="bXDir">如果扭曲则选择为True</param>
            /// <param name="nMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
            /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
            /// <returns></returns>
            private static System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
            {
                System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

                // 将位图背景填充为白色
                System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
                graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
                graph.Dispose();

                double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

                for (int i = 0; i < destBmp.Width; i++)
                {
                    for (int j = 0; j < destBmp.Height; j++)
                    {
                        double dx = 0;
                        dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                        dx += dPhase;
                        double dy = Math.Sin(dx);

                        // 取得当前点的颜色
                        int nOldX = 0, nOldY = 0;
                        nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                        nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                        System.Drawing.Color color = srcBmp.GetPixel(i, j);
                        if (nOldX >= 0 && nOldX < destBmp.Width
                         && nOldY >= 0 && nOldY < destBmp.Height)
                        {
                            destBmp.SetPixel(nOldX, nOldY, color);
                        }
                    }
                }

                return destBmp;
            }



            #endregion

            #region 生成校验码图片
            public static Bitmap CreateImageCode(string code)
            {
                int fSize = FontSize;
                int fWidth = fSize + Padding;

                int imageWidth = (int)(code.Length * fWidth) + 10 + 4;
                int imageHeight = fSize * 2 + Padding;

                System.Drawing.Bitmap image = new System.Drawing.Bitmap(imageWidth, imageHeight);

                Graphics g = Graphics.FromImage(image);

                g.Clear(BackgroundColor);

                Random rand = new Random();

                //给背景添加随机生成的燥点
                if (Chaos)
                {
                    Pen pen = new Pen(ChaosColor, 0);
                    int c = XYECOM.Configuration.Security.Instance.VCodeLength * 5;

                    for (int i = 0; i < c; i++)
                    {
                        int x = rand.Next(image.Width);
                        int y = rand.Next(image.Height);
                        pen.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                        g.DrawRectangle(pen, x, y, 1, 1);
                    }

                    for (int i = 0; i < XYECOM.Configuration.Security.Instance.VCodeLength * 2; i++)
                    {
                        int x = rand.Next(image.Width);
                        int y = rand.Next(image.Height);
                        pen.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                        g.DrawLine(pen, rand.Next(image.Width), rand.Next(image.Height), rand.Next(image.Width), rand.Next(image.Height));
                    }
                }

                int left = 0, top = 0, top1 = 1, top2 = 1;

                int n1 = (imageHeight - FontSize - 4);
                int n2 = n1 / 4;
                top1 = n2;
                top2 = n2 * 2;

                Font f;
                Brush b;

                int cindex, findex;

                //随机字体和颜色的验证码字符
                for (int i = 0; i < code.Length; i++)
                {
                    cindex = rand.Next(Colors.Length - 1);
                    findex = rand.Next(Fonts.Length - 1);

                    f = new System.Drawing.Font(Fonts[findex], fSize, System.Drawing.FontStyle.Regular);
                    b = new System.Drawing.SolidBrush(Colors[cindex]);

                    if (i % 2 == 1)
                    {
                        top = top2;
                    }
                    else
                    {
                        top = top1;
                    }

                    left = i * fWidth;

                    g.DrawString(code.Substring(i, 1), f, b, left, top);
                }

                //画一个边框 边框颜色为Color.Gainsboro
                //g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
                g.Dispose();

                //产生波形
                image = TwistImage(image, true, XYECOM.Configuration.Security.Instance.VCodeTortuosity, 4);

                return image;
            }
            #endregion

            #region 将创建好的图片输出到页面
            public static void CreateValidateCodeImage(string code)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Bitmap image = CreateImageCode(code);

                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                context.Response.ClearContent();
                context.Response.ContentType = "image/Jpeg";
                context.Response.BinaryWrite(ms.GetBuffer());

                ms.Close();
                ms = null;
                image.Dispose();
                image = null;
            }
            #endregion

            #region 生成随机字符码
            public static string GenerateCode()
            {

                int codeLen = XYECOM.Configuration.Security.Instance.VCodeLength;

                string[] arr = XYECOM.Configuration.Security.Instance.VCodeCharPool.Split(',');

                string code = "";

                int randValue = -1;

                Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

                for (int i = 0; i < codeLen; i++)
                {
                    randValue = rand.Next(0, arr.Length - 1);

                    code += arr[randValue];
                }

                return code;
            }
            #endregion

        }

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

}
