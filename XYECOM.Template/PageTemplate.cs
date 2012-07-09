using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace XYECOM.Template
{
    /// <summary>
    /// 模板生成及相关处理基类
    /// </summary>
    public abstract class PageTemplate
    {
        public static Regex[] regex = new Regex[26];

        static PageTemplate()
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

            regex[0] = new Regex(@"<%Include ([^\[\]\{\}\s]+)%>", options);

            regex[1] = new Regex(@"<%Variable ([^\[\]/\{\}\s]+)%>", options);

            regex[2] = new Regex(@"<%loop(\s+)(\(([a-zA-Z.]+)\))(\s+)([^\[\]\{\}\s]+) ([^\[\]\{\}\s]+)%>", options);

            regex[3] = new Regex(@"<%\/loop%>", options);

            regex[4] = new Regex(@"<%continue%>", options);

            regex[5] = new Regex(@"<%if (?:\s*)(([^\s]+)((?:\s*)(\|\||\&\&)(?:\s*)([^\s]+))?)(?:\s*)%>", options);

            regex[6] = new Regex(@"<%else(( (?:\s*)if (?:\s*)(([^\s]+)((?:\s*)(\|\||\&\&)(?:\s*)([^\s]+))?))?)(?:\s*)%>", options);

            regex[7] = new Regex(@"<%\/if%>", options);

            regex[8] = new Regex(@"(\{([^\.\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\})", options);

            regex[9] = new Regex(@"(\{([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\})", options);

            regex[10] = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);

            regex[11] = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);

            regex[12] = new Regex(@"(([=|>|<|!]=)\\" + "\"" + @"([^\s]*)\\" + "\")", options);

            regex[13] = new Regex(@"(\{([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\)\})", options);

            regex[14] = new Regex(@"<%Import ([^\[\]\{\}\s]+)%>", options);

            //regex[15] = new Regex(@"<%left\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\],([^\[\]\{\}\s]+)\)%>", options);
            regex[15] = new Regex(@"<%left\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\],([^\[\]\{\}\s]+)\)%>", options);

            regex[16] = new Regex(@"<%left\(([^\[\]\{\}\s]+(\.[^\[\]\{\}\s]+)?),([^\[\]\{\}\s]+)\)%>", options);

            regex[17] = new Regex(@"<%filter\(([^\[\]\{\}\s]+(\.[^\[\]\{\}\s]+)?),([^\[\]\{\}\s]+(\.[^\[\]\{\}\s]+)?)\)%>", options);

            regex[18] = new Regex(@"<%filter\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\,([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\)%>", options);

            regex[19] = new Regex(@"<%set ((\(([a-zA-Z]+)\))?)(?:\s*)([^\s]+)(?:\s*)=(?:\s*)(.*?)(?:\s*)%>", options);

            regex[20] = new Regex(@"<%XYFunctions ([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\)%>", options);

            regex[21] = new Regex(@"<%formatdatetime\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\],([^\[\]\{\}\s]+)\)%>", options);

            regex[22] = new Regex(@"<%formatdatetime\(([^\[\]\{\}\s]+(\.[^\[\]\{\}\s]+)?),([^\[\]\{\}\s]+)\)%>", options);

            regex[23] = new Regex(@"(\{SYS:[A-Za-z]+\[([^\[\]\{\}\s]+)\]\})", options);

            regex[24] = new Regex(@"<%end%>", options);
            regex[25] = new Regex(@"<%break%>", options);
         }

        /// <summary>
        /// 转换标签
        /// </summary>
        /// <param name="nest">深度</param>
        /// <param name="skinName">模板名称</param>
        /// <param name="inputStr">模板内容</param>
        /// <param name="templateid">模板id</param>
        /// <returns></returns>
        private string ConvertTags(int nest, string skinName, string inputStr, string T_Name,string pathName,string ppathName)
        {
            string strReturn = "";
            bool IsCodeLine;
 
            string strTemplate;
            strTemplate = inputStr.Replace("\\", "\\\\");
            strTemplate = strTemplate.Replace("\"", "\\\"");
            strTemplate = strTemplate.Replace("</script>", "</\" + \"script>");
            IsCodeLine = false;

            //regex[0] = new Regex(@"<%Include ([^\[\]\{\}\s]+)%>", options);
            foreach (Match m in regex[0].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "\r\n" + GetTemplate(skinName, m.Groups[1].ToString(), nest + 1, T_Name, pathName, ppathName) + "\r\n");
            }

            //regex[1] = new Regex(@"<%Variable ([^\[\]/\{\}\s]+)%>", options);
            foreach (Match m in regex[1].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "XYBody.Append( " + m.Groups[1].ToString().Trim() + ".ToString());");

                //strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[1].ToString());
            }

            //regex[2] = new Regex(@"<%loop ((\(([a-zA-Z]+)\) )?)([^\[\]\{\}\s]+) ([^\[\]\{\}\s]+)%>", options);
            foreach (Match m in regex[2].Matches(strTemplate))
            {
                IsCodeLine = true;
                if (m.Groups[3].ToString().ToLower().Equals("datarow"))
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                        string.Format("\r\n\tint {0}__loop__id=0;\r\n\tforeach(DataRow {0} in {1}.Rows)\r\n\t{{\r\n\t\t{0}__loop__id++;\r\n", m.Groups[5].ToString(), m.Groups[6].ToString()));
                }
                else
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                        string.Format("\r\n\tint {1}__loop__id=0;\r\n\tforeach({0} {1} in {2})\r\n\t{{\r\n\t\t{1}__loop__id++;\r\n", m.Groups[3].ToString(), m.Groups[5].ToString(), m.Groups[6].ToString()));
                }
            }

            //regex[3] = new Regex(@"<%\/loop%>", options);
            foreach (Match m in regex[3].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    "\r\n\t}\t//end loop\r\n");
            }

            //regex[4] = new Regex(@"<%continue%>", options);
            foreach (Match m in regex[4].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "\r\t continue;");
            }

            //regex[25] = new Regex(@"<%break%>", options);
            foreach (Match m in regex[25].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "\r\t break;");
            }

            //regex[5] = new Regex(@"<%if (?:\s*)(([^\s]+)((?:\s*)(\|\||\&\&)(?:\s*)([^\s]+))?)(?:\s*)%>", options);
            foreach(Match m in regex[5].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    "\r\n\tif (" + m.Groups[1].ToString().Replace("\\\"", "\"") + ")\r\n\t{\r\n");
            }

            //regex[6] = new Regex(@"<%else(( (?:\s*)if (?:\s*)(([^\s]+)((?:\s*)(\|\||\&\&)(?:\s*)([^\s]+))?))?)(?:\s*)%>", options);
            foreach(Match m in regex[6].Matches(strTemplate))
            {
                IsCodeLine = true;
                if (m.Groups[1].ToString() == string.Empty)
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    "\r\n\t}\r\n\telse\r\n\t{\r\n");
                }
                else
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                        "\r\n\t}\r\n\telse if (" + m.Groups[3].ToString().Replace("\\\"", "\"") + ")\r\n\t{\r\n");
                }
            }

            //regex[7] = new Regex(@"<%\/if%>", options);
            foreach (Match m in regex[7].Matches(strTemplate))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    "\r\n\t}\t//end if\r\n");
            }

            //set 
            foreach (Match m in regex[19].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                string type = "";
                if (m.Groups[3].ToString() != string.Empty)
                {
                    type = m.Groups[3].ToString();
                }
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    string.Format("\t{0} {1} = {2};\r\n\t", type, m.Groups[4].ToString(), m.Groups[5].ToString()).Replace("\\\"", "\"")
                    );
            }

            //regex[11] = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);
            foreach (Match m in regex[11].Matches(strTemplate))
            {
                if (IsCodeLine)
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                        m.Groups[2].ToString());
                }
                else
                {
                    if (m.Groups[1].ToString().Trim().ToLower().IndexOf("seo.") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "")));
                    }
                    else if (m.Groups[1].ToString().Trim().ToLower().IndexOf("config.") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "").Replace("\\\"", "\"")));
                    }
                    else if (m.Groups[1].ToString().Trim().ToLower().IndexOf("pageinfo.") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "").Replace("\\\"", "\"")));
                    }
                    else if (m.Groups[2].ToString().Trim().ToLower().StartsWith("xy_"))
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                                    string.Format("\" + {0}.ToString() + \"", " XYECOMCreateHTML(\"" + m.Groups[2].ToString().Trim() + "\")"));
                    }
                    // 临时规则，会员中心需改后删除
                    else if (m.Groups[1].ToString().Trim().ToLower().IndexOf("xyv_") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "").Remove(0, 4)));
                    }
                    else
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0}.ToString());\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "")));
                    }
                }
            }

            //regex[8] = new Regex(@"(\{([^\.\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\})", options);
            foreach (Match m in regex[8].Matches(strTemplate))
            {
                if (IsCodeLine)
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                        string.Format("{0}.{1}{2}", m.Groups[2].ToString(), XYECOM.Core.Utils.CutString(m.Groups[3].ToString(), 0, 1).ToUpper(), m.Groups[3].ToString().Substring(1, m.Groups[3].ToString().Length - 1)));
                }
                else
                {
                    if (m.Groups[1].ToString().Trim().ToLower().IndexOf("seo.") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "")));
                    }
                    else if (m.Groups[1].ToString().Trim().ToLower().IndexOf("config.") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "")));
                    }
                    else if (m.Groups[1].ToString().Trim().ToLower().IndexOf("pageinfo.") == 1)
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\");\r\tXYBody.Append({0});\r\tXYBody.Append(\"", m.Groups[1].ToString().Trim().Replace("{", "").Replace("}", "")));
                    }
                    else
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                            // string.Format("\" + {0}.{1}{2}.ToString().Trim() + \"", "\" + " + m.Groups[2].ToString() + "." + Utils.CutString(m.Groups[3].ToString(), 0, 1).ToUpper() + m.Groups[3].ToString().Substring(1, m.Groups[3].ToString().Length - 1) + ".ToString().Trim() + \""));
                           string.Format("\" + {0}.{1}{2}.ToString().Trim() + \"", m.Groups[2].ToString(), XYECOM.Core.Utils.CutString(m.Groups[3].ToString(), 0, 1).ToUpper(), m.Groups[3].ToString().Substring(1, m.Groups[3].ToString().Length - 1)));
                    }
                }
            }

            //System Label
            foreach (Match m in regex[23].Matches(strTemplate.ToString()))
            {
                IsCodeLine = false;

                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                                string.Format("\" + {0} + \"", " XYECOMCreateHTML(\"" + m.Groups[1].ToString().Trim().Replace("{","").Replace("}","") + "\")"));

            }

            //regex[9] = new Regex(@"(\{([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\})", options);
            foreach (Match m in regex[9].Matches(strTemplate))
            {
                if (IsCodeLine)
                {
                    if (XYECOM.Core.Utils.IsNumber(m.Groups[3].ToString()))
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "[" + m.Groups[3].ToString() + "].ToString().Trim()");
                    }
                    else
                    {
                        if (m.Groups[3].ToString() == "_id")
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "__loop__id");
                        }
                        else
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "[\"" + m.Groups[3].ToString() + "\"].ToString().Trim()");
                        }
                    }
                }
                else
                {
                    if (XYECOM.Core.Utils.IsNumber(m.Groups[3].ToString()))
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}[{1}].ToString().Trim() + \"", m.Groups[2].ToString(), m.Groups[3].ToString()));
                    }
                    else
                    {
                        if (m.Groups[3].ToString() == "_id")
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}__loop__id.ToString() + \"", m.Groups[2].ToString()));
                        }
                        else
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}[\"{1}\"].ToString().Trim() + \"", m.Groups[2].ToString(), m.Groups[3].ToString()));
                        }
                    }
                }
            }

            //regex[13] = new Regex(@"(\{([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\)\})", options);
            foreach (Match m in regex[13].Matches(strTemplate))
            {
                if (IsCodeLine)
                {
                    if (XYECOM.Core.Utils.IsNumber(m.Groups[3].ToString()))
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "[" + m.Groups[3].ToString() + "].ToString().Trim()");
                    }
                    else
                    {
                        if (m.Groups[3].ToString() == "_id")
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "__loop__id");
                        }
                        else
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), m.Groups[2].ToString() + "[" + m.Groups[3].ToString() + "].ToString().Trim()");
                        }
                    }
                }
                else
                {
                    if (XYECOM.Core.Utils.IsNumber(m.Groups[3].ToString()))
                    {
                        strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}[{1}].ToString().Trim() + \"", m.Groups[2].ToString(), m.Groups[3].ToString()));
                    }
                    else
                    {
                        if (m.Groups[3].ToString() == "_id")
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}__loop__id.ToString() + \"", m.Groups[2].ToString()));
                        }
                        else
                        {
                            strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\" + {0}[\"{1}\"].ToString().Trim() + \"", m.Groups[2].ToString(), m.Groups[3].ToString()));
                        }
                    }
                }
            }

            strTemplate = ReplaceSpecialTemplate(skinName, strTemplate);

            //regex[10] = new Regex(@"({([^\[\]/\{\}='\s]+)})", options);
            foreach (Match m in regex[10].Matches(strTemplate))
            {
                if (m.Groups[0].ToString() == "{commonversion}")
                {
                    strTemplate = strTemplate.Replace(m.Groups[0].ToString(), XYECOM.Core.Utils.GetAssemblyVersion());
                }
            }



            //regex[12] = new Regex(@"(([=|>|<|!]=)\\" + "\"" + @"([^\s]*)\\" + "\")", options);
            foreach (Match m in regex[12].Matches(strTemplate))
            {
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(),
                    m.Groups[2].ToString() + "\"" + m.Groups[3].ToString() + "\"");

            }
            
            //regex[15] = new Regex(@"<%left\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\],([^\[\]\{\}\s]+)\)%>", options);
            foreach (Match m in regex[15].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\tXYBody.Append( Method.left({0}[\"{1}\"].ToString().Trim(),{2}));", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString()));
            }

            foreach (Match m in regex[16].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\tXYBody.Append( Method.left({0}.ToString().Trim(),{1}));", m.Groups[1].ToString(), m.Groups[3].ToString()));
            }

            //filter
            foreach (Match m in regex[17].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\tXYBody.Append( Method.filter({0}.ToString().Trim(),{1}.ToString().Trim()));", m.Groups[1].ToString(), m.Groups[3].ToString()));
            }
            //filter
            foreach (Match m in regex[18].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\t XYBody.Append(Method.filter({0}[\"{1}\"].ToString(),{2}[\"{3}\"].ToString()).ToString().Trim());", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString(), m.Groups[4].ToString()));
            }


            
            //regex[20] = new Regex(@"<%XYFunctions ([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\)%>", options);
            foreach (Match m in regex[20].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\t XYBody.Append({0}({1}[\"{2}\"].ToString().Trim()));", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString()));
            }

            //formatdatetime
            foreach (Match m in regex[21].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\tXYBody.Append( Method.formatdatetime({0}[\"{1}\"].ToString().Trim(),\"{2}\"));", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString()));
            }

            //formatdatetime
            foreach (Match m in regex[22].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\tXYBody.Append( Method.formatdatetime({0}.ToString().Trim(),{1}));", m.Groups[1].ToString(), m.Groups[3].ToString()));
            }


            //regex[24] = new Regex(@"<%end%>", options);
            foreach (Match m in regex[24].Matches(strTemplate.ToString()))
            {
                IsCodeLine = true;
                strTemplate = strTemplate.Replace(m.Groups[0].ToString(), "\r\n\tResponse.Write(XYBody.ToString());\r\nSystem.Web.HttpContext.Current.Response.End();\r\n\t");
            }


            ////regex[18] = new Regex(@"<%XYFunctions ([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\,([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\)%>", options);
            //foreach (Match m in regex[18].Matches(strTemplate.ToString()))
            //{
            //    IsCodeLine = true;
            //    strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\t XYBody.Append({0}.{1}({2}.{3},{4}.{5}).ToString().Trim());", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString(), m.Groups[4].ToString(), m.Groups[5].ToString(), m.Groups[6].ToString()));
            //}

            ////regex[19] = new Regex(@"<%XYFunctions ([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\,([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\,([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\)\)\)%>", options);
            //foreach (Match m in regex[19].Matches(strTemplate.ToString()))
            //{
            //    IsCodeLine = true;
            //    strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\t XYBody.Append({0}.{1}({2}.{3},{4}.{5}({6},{7}.{8}({9}[\"{10}\"].ToString()))).ToString().Trim());", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString(), m.Groups[4].ToString(), m.Groups[5].ToString(), m.Groups[6].ToString(), m.Groups[7].ToString(), m.Groups[8].ToString(), m.Groups[9].ToString(), m.Groups[10].ToString(), m.Groups[11].ToString()));
            //}

            ////regex[20] = new Regex(@"<%XYFunctions ([^\[\]\{\}\s]+)\.([^\[\]\{\}\s]+)\(([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\,([^\[\]\{\}\s]+)\[([^\[\]\{\}\s]+)\]\)%>", options);
            //foreach (Match m in regex[20].Matches(strTemplate.ToString()))
            //{
            //    IsCodeLine = true;
            //    strTemplate = strTemplate.Replace(m.Groups[0].ToString(), string.Format("\r\t XYBody.Append({0}.{1}(Convert.ToInt64({2}[\"{3}\"].ToString()),{4}[\"{5}\"].ToString()).ToString().Trim());", m.Groups[1].ToString(), m.Groups[2].ToString(), m.Groups[3].ToString(), m.Groups[4].ToString(), m.Groups[5].ToString(), m.Groups[6].ToString()));
            //}

            if (IsCodeLine)
            {
                strReturn = strTemplate +"\r\n";
                return strReturn;
            }

            if (strTemplate.Trim() != "")
            {
                StringBuilder sb = new StringBuilder();
                foreach (string temp in XYECOM.Core.Utils.SplitString(strTemplate, "\r\r\r"))
                {
                    if (temp.Trim() == "")
                        continue;

                    sb.Append("\tXYBody.Append(\"" + temp + "\\r\\n\");\r\n");
                    //sb.Append("\tXYBody.Append(\"" + temp + "\");\r\n");
                }
                strReturn = sb.ToString();
            }

            return strReturn;
        }

        public virtual string GetTemplate(string skinName, string templateName, int nest, string T_Name, string pathName, string ppathName)
        {
            XYECOM.Configuration.ModuleInfo moduleInfo = null;
            StringBuilder strReturn = new StringBuilder();

            if (nest > 5) return "";

            if (nest < 1) nest = 1;

            string extNamespace = "";
            string pathFormatStr = "{0}{1}{2}{3}{4}.htm";
            string mapPath = @"..\..\templates";
            string filePath = "";

            if (pathName == "")
            {
                filePath = string.Format(pathFormatStr, XYECOM.Core.Utils.GetMapPath(mapPath), System.IO.Path.DirectorySeparatorChar, skinName, System.IO.Path.DirectorySeparatorChar, templateName);
            }
            else
            {
                moduleInfo = XYECOM.Configuration.Module.Instance.GetItem(pathName);
                if (moduleInfo != null)
                    filePath = string.Format(pathFormatStr, XYECOM.Core.Utils.GetMapPath(mapPath), System.IO.Path.DirectorySeparatorChar, skinName + System.IO.Path.DirectorySeparatorChar + moduleInfo.EName, System.IO.Path.DirectorySeparatorChar, templateName);
                else
                    filePath = string.Format(pathFormatStr, XYECOM.Core.Utils.GetMapPath(mapPath), System.IO.Path.DirectorySeparatorChar, skinName + System.IO.Path.DirectorySeparatorChar + pathName, System.IO.Path.DirectorySeparatorChar, templateName);
            }

            //如果指定风格的模板文件不存在,则到根目录下找，如果根目录也不存在，则认为此文件不存在
            if (!System.IO.File.Exists(filePath) && !pathName.Equals(""))
            {
                filePath = string.Format(pathFormatStr, XYECOM.Core.Utils.GetMapPath(mapPath), System.IO.Path.DirectorySeparatorChar, skinName, System.IO.Path.DirectorySeparatorChar, templateName);     
            }

            //如果在当在模板目录下找不到模板文件，则到默认模板下寻找
            if (!System.IO.File.Exists(filePath))
            {
                //默认风格的模板是否存在...

                if (!pathName.Equals(""))
                {
                    filePath = string.Format(pathFormatStr, XYECOM.Core.Utils.GetMapPath(mapPath), System.IO.Path.DirectorySeparatorChar, "default\\" + pathName, System.IO.Path.DirectorySeparatorChar, templateName);
                }

                if (!System.IO.File.Exists(filePath) || pathName.Equals(""))
                { 
                    filePath = string.Format(pathFormatStr, XYECOM.Core.Utils.GetMapPath(mapPath), System.IO.Path.DirectorySeparatorChar, "default", System.IO.Path.DirectorySeparatorChar, templateName);
                }
             
                //如果没人目录下还不存在就返回空
                if (!System.IO.File.Exists(filePath))
                {
                    return "";
                }
            }

            using (System.IO.StreamReader objReader = new System.IO.StreamReader(filePath, Encoding.Default))
            {
                System.Text.StringBuilder textOutput = new System.Text.StringBuilder();

                textOutput.Append(objReader.ReadToEnd());
                objReader.Close();

                //处理命名空间
                if (nest == 1)
                {
                    //命名空间
                    foreach (Match m in regex[14].Matches(textOutput.ToString()))
                    {
                        extNamespace += "\r\n<%@ Import namespace=\"" + m.Groups[1].ToString() + "\" %>";
                        textOutput.Replace(m.Groups[0].ToString(), string.Empty);
                    }
                }

                //处理Csharp语句
                foreach (Match m in regex[14].Matches(textOutput.ToString()))
                {
                    textOutput.Replace(m.Groups[0].ToString(), m.Groups[0].ToString().Replace("\r\n", "\r\t\r"));
                }

                textOutput.Replace("\r\n", "\r\r\r");
                textOutput.Replace("<%", "\r\r\n<%");
                textOutput.Replace("%>", "%>\r\r\n");

                textOutput.Replace("<%csharp%>\r\r\n", "<%csharp%>").Replace("\r\r\n<%/csharp%>", "<%/csharp%>");


                string[] strlist = XYECOM.Core.Utils.SplitString(textOutput.ToString(), "\r\r\n");
                int count = strlist.GetUpperBound(0);

                for (int i = 0; i <= count; i++)
                {
                    strReturn.Append(ConvertTags(nest, skinName, strlist[i], T_Name, pathName, ppathName));
                }
            }

            string strIsCopyright = "IsCopyright()";

            if (nest == 1)
            {
                string template = "";

                string pageTop = "<%@ Page language=\"c#\" AutoEventWireup=\"false\" EnableViewState=\"false\" Inherits=\"XYECOM.Page.{0},XYECOM.Page\" %>\r\n"
                                + "<%@ Import namespace=\"System.Data\" %>\r\n"
                                + "<%@ Import namespace=\"XYECOM.Core\" %>\r\n"
                                + "<%@ Import namespace=\"XYECOM.Model\" %>\r\n"
                                + "<%@ Import namespace=\"XYECOM.Business\" %>\r\n"
                                + "<%@ Import namespace=\"XYECOM.Template\" %>\r\n"
                                + "<%@ Import namespace=\"XYECOM.Configuration\" %>\r\n"
                                + "<script runat=\"server\">\r\n"
                                + "protected override void OnLoad(EventArgs e)\r\n"
                                + "{{\r\n\t"
                                + "base.OnLoad(e);\r\n"
                                + "{1}\r\n\t"
                                + "XYBody.Append({2});\r\n\t"
                                + "Response.Write(XYBody.ToString());\r\n"
                                + "}}\r\n"
                                + "</script>\r\n";


                if (pathName == "")
                {
                    template = string.Format(pageTop, templateName.ToLower(), strReturn.ToString(), strIsCopyright);
                }
                else
                {
                    moduleInfo = XYECOM.Configuration.Module.Instance.GetItem(pathName);
                    
                    string inheritsName = "";

                    if (ppathName == "")
                    {
                        if (moduleInfo == null)
                        {
                            if (pathName.ToLower().Equals("cp"))
                                inheritsName = pathName + ".index";
                            else
                            {
                                if (skinName.Equals("_shop"))
                                {
                                    strIsCopyright = "\"\"";
                                    inheritsName = "shop." + templateName.ToLower();
                                }
                                else
                                {
                                    inheritsName = pathName + "." + templateName.ToLower();
                                }
                            }
                        }
                        else
                        {
                            if (moduleInfo.PEName.Equals(""))
                            {
                                inheritsName = pathName + "." + templateName.ToLower();
                            }
                            else
                            {
                                inheritsName = moduleInfo.PEName + "." + templateName.ToLower();
                            }
                        }

                        template = string.Format(pageTop, inheritsName, strReturn.ToString(), strIsCopyright);
                    }
                    else
                    {
                        if (ppathName.ToLower().Equals("cp"))
                            inheritsName = ppathName + ".index";
                        else
                            inheritsName = ppathName + "." + templateName.ToLower();

                        template = string.Format(pageTop, inheritsName, strReturn.ToString(), strIsCopyright);
                    }
                }

                string pageDir = "";

                //针对固定模块特殊设计(_shop,_user,_person)
                if (T_Name.StartsWith("_"))
                {
                    T_Name = T_Name.Substring(1);
                }

                if (pathName != "")
                {
                    if (moduleInfo != null)
                    {
                        pageDir = XYECOM.Core.Utils.GetMapPath(@"..\..\aspx\" + T_Name.ToString() + "\\" + moduleInfo.EName + "\\");
                    }
                    else
                    {
                        pageDir = XYECOM.Core.Utils.GetMapPath(@"..\..\aspx\" + T_Name.ToString() + "\\" + pathName + "\\");
                    }
                }
                else
                    pageDir = XYECOM.Core.Utils.GetMapPath(@"..\..\aspx\" + T_Name.ToString() + "\\");

                if (!Directory.Exists(pageDir))
                {
                    XYECOM.Core.Utils.CreateDir(pageDir);
                }

                string outputPath = pageDir + templateName + "." + XYECOM.Configuration.WebInfo.Instance.WebSuffix ;

                using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    Byte[] info = System.Text.Encoding.Default.GetBytes(template);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
            return strReturn.ToString();
        }

        public abstract string ReplaceSpecialTemplate(string skinName, string strTemplate);
    }
}
