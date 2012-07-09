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
using System.Drawing;

public partial class GetCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        Session["VNum"] = GenerateCheckCode();
        this.CreateCheckCodeImage(Session["VNum"].ToString());
    }

    private string GenerateCheckCode()
    {
        int number;
        char code;
        string checkCode = String.Empty;

        System.Random random = new Random();

        for (int i = 0; i < 4; i++)
        {
            number = random.Next();

            //				if(number % 2 == 0)
            code = (char)('0' + (char)(number % 10));
            //				else
            //					code = (char)('A' + (char)(number % 26));

            checkCode += code.ToString();
        }

        return checkCode;
    }

    private void CreateCheckCodeImage(string checkCode)
    {
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;

        System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 12.5)), 22);
        Graphics g = Graphics.FromImage(image);


        //生成随机生成器
        Random random = new Random();

        //图片背景色
        g.Clear(Color.Linen);

        //画图片的背景噪音线
        //			for(int i=0; i<44; i++)
        //			{
        //				int x1 = random.Next(image.Width-i);
        //				int x2 = random.Next(image.Width);
        //				int y1 = random.Next(image.Height);
        //				int y2 = random.Next(image.Height);
        //
        //				g.DrawLine(new Pen(Color.White), x1, y1, x2, y2);
        //			}

        Font font = new System.Drawing.Font("Arial", 14, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));

        System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Coral, Color.Green, 1.2f, true);

        g.DrawString(checkCode, font, brush, 2, 2);

        //画图片的前景噪音点
        for (int i = 0; i < 5; i++)
        {
            int x = random.Next(image.Width);
            int y = random.Next(image.Height);

            image.SetPixel(x, y, Color.FromArgb(random.Next()));
        }

        //画图片的边框线
        g.DrawRectangle(new Pen(Color.OldLace), 0, 0, image.Width - 1, image.Height - 1);

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        Response.ClearContent();
        Response.ContentType = "image/Gif";
        Response.BinaryWrite(ms.ToArray());

    }
}
