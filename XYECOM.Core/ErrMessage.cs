using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace XYECOM.Core
{
    public class ErrMessage 
    {
        public ErrMessage()
        {
        }
        //public static void WriteErrFile(Exception  es,string type)
        //{
        //    try
        //    {                
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder("");
        //        sb.Append("������Ϣ��");
        //        sb.Append(es.Message);
        //        sb.Append("\n\r");
        //        sb.Append("����ԭ��");
        //        sb.Append(es.Source);
        //        sb.Append("\n\r");
        //        sb.Append("����λ�ã�");
        //        sb.Append(es.StackTrace);
        //        sb.Append("\n\r");
        //        sb.Append("��������");
        //        sb.Append(es.TargetSite);
        //        sb.Append("\n\r");
        //        sb.Append("����ʱ�䣺");
        //        sb.Append(DateTime.Now);
        //        sb.Append("\n\r");
        //        //string content = "";
        //        //FileStream aFile = new FileStream(Util.GetMapPath("~") + @"\errinfo.txt", FileMode.OpenOrCreate);
        //        //StreamReader dd = new StreamReader(aFile);
        //        //content = dd.ReadToEnd();
        //        StreamWriter sw = new StreamWriter(Utils.GetMapPath("~") + @"\errinfo.txt", true);
        //        sw.Write(sb.ToString());
        //        sw.Flush();
        //        sw.Close();



        //        XYECOM.
        //        string url = ""; 
        //        if (type == "user")
        //        {
        //             url = wci.WebURL +"user/errinfo."+wci.Suffix+"?";                 
        //        }
        //        else if (type == "xyecom")
        //        {
        //            url = wci.WebURL + "xymanage/err.aspx?";                
        //        }
        //        else if (type == "index")
        //        {
        //            url = wci.WebURL + "page404." + wci.Suffix + "?";  
        //        }
        //        else if (type == "person")
        //        {
        //            url = wci.WebURL + "person/errinfo." + wci.Suffix + "?"; 
        //        }
        //        //�Դ�����Դ�����ж�
        //        if (es.Source.ToString().IndexOf(".Net SqlClient Data Provider") >= 0)
        //            url += "key=002";
        //        else
        //            url += "key=003";
             
        //      System.Web.HttpContext.Current.Response.Redirect(url,true );
                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static void WriteErrFile(Exception es)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder("");
                sb.Append("������Ϣ��");
                sb.Append(es.Message);
                sb.Append("\n\r");
                sb.Append("����ԭ��");
                sb.Append(es.Source);
                sb.Append("\n\r");
                sb.Append("����λ�ã�");
                sb.Append(es.StackTrace);
                sb.Append("\n\r");
                sb.Append("��������");
                sb.Append(es.TargetSite);
                sb.Append("\n\r");
                sb.Append("����ʱ�䣺");
                sb.Append(DateTime.Now);
                sb.Append("\n\r");
                //string content = "";
                //FileStream aFile = new FileStream(Util.GetMapPath("~") + @"\errinfo.txt", FileMode.OpenOrCreate);
                //StreamReader dd = new StreamReader(aFile);
                //content = dd.ReadToEnd();
                StreamWriter sw = new StreamWriter(Utils.GetMapPath("~") + @"\errinfo.txt", true);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
   
