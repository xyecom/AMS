using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Text.RegularExpressions;


namespace XYECOM.Template
{
    /// <summary>
    /// 网站模板业务类
    /// </summary>
    public class WebPageTemplate : PageTemplate
    {
        static Regex __forumPageRegex = null;
        static WebPageTemplate()
        {
            RegexOptions options;
            
            if (Environment.Version.Major == 1)
            {
                options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline;
            }
            else
            {
                options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            }

            __forumPageRegex = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);

        }

        public override string GetTemplate(string skinName, string templateName, int nest, string T_Name,string pathName,string ppathName)
        {
            return base.GetTemplate(skinName, templateName, nest, T_Name, pathName, ppathName);
        }

        public override string ReplaceSpecialTemplate(string skinName, string strTemplate)
        {
            Match m;

            StringBuilder sb = new StringBuilder();
            sb.Append(strTemplate);
            for (m = __forumPageRegex.Match(strTemplate); m.Success; m = m.NextMatch())
            {
                if (m.Groups[0].ToString() == "{forumversion}")
                {
                    sb = sb.Replace(m.Groups[0].ToString(), XYECOM.Core.Utils.GetAssemblyVersion());
                }
                else if (m.Groups[0].ToString() == "{forumproductname}")
                {
                    sb = sb.Replace(m.Groups[0].ToString(), XYECOM.Core.Utils.GetAssemblyProductName());
                }
            }

            foreach (DataRow dr in GetTemplateVarList(skinName).Rows)
            {
                sb = sb.Replace(dr["variablename"].ToString().Trim(), dr["variablevalue"].ToString().Trim());
            }
            return sb.ToString();
        }

        public static DataTable GetTemplateVarList(string skinName)
        {
            DataSet set = new DataSet("template");
            string[] files = new string[] { XYECOM.Core.Utils.GetMapPath("../../templates/" + skinName + "/templatevariable.xml") };
            if (XYECOM.Core.Utils.FileExists(files[0]))
            {
                set.ReadXml(files[0]);
            }
            else
            {
                DataTable table2 = new DataTable("TemplateVariable");
                table2.Columns.Add("id", Type.GetType("System.Int32"));
                table2.Columns.Add("variablename", Type.GetType("System.String"));
                table2.Columns.Add("variablevalue", Type.GetType("System.String"));
                set.Tables.Add(table2);
            }
            return set.Tables[0];
        }
    }
}
