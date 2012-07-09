using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.SessionState;
using System.Text;
using XYECOM.Core;
using XYECOM.Business;
using System.Text.RegularExpressions;

namespace XYECOM.Web.Common
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class XYAjax : IHttpHandler, IRequiresSessionState
    {
        XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
        System.Web.HttpContext content = null;
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext c)
        {
            this.content = c;
            string action = "";

            string ip = XYECOM.Core.XYRequest.GetIP();

            //IP判断
            if (XYECOM.Configuration.Security.Instance._ForbidIP.Contains(ip))
            {
                ResponseXML(Result.Failed, "-禁止访问-");
            }

            if (c.Request.QueryString["ac"] != null)
            {
                action = c.Request.QueryString["ac"].Trim().ToLower();
                switch (action)
                {
                    case "xy001":           //后台供求类别
                    case "xy002":
                    case "xy003":
                    case "xy004":
                    case "xy005":
                    case "xy006":
                    case "xy007":
                    case "xy008":
                    case "xy009":
                    case "xy010":
                        GetClassTypes();
                        break;
                    case "xy011":           //游客留言
                        VisitorMessasge();
                        break;
                    case "xy012":           //会员留言
                        UserMessage();
                        break;
                    case "xy014":           //用户登录
                        Login();
                        break;
                    case "xy015":           //插入新闻评论
                        InsertComment();
                        break;
                    case "xy016":           //检查用户名是否已经存在
                        IsExistsUserByName();
                        break;
                    case "xy017":           //检测邮箱是否已被占用
                        IsExistsUserByEmail();
                        break;
                    //case "xy018":           //新用户注册
                    //    Register();
                    //    break;
                    //case "xy019":
                    //    //用户退出
                    //    break;
                    case "xy020":
                        RetakePassword();   //重设密码
                        break;                    
                    case "xy023":           //收藏信息
                        Favorite();
                        break;
                        break;
                    case "xy026":           //获取新闻评论
                        GetNewsComment();
                        break;
                    case "xy029":           //重设密码(通过密码找回密码)
                        RetakePassword("");
                        break;
                    case "xy030":           //判断是否为免费新闻
                        IsFreeNews();
                        break;
                    case "xy031":           //扣除收费新闻浏览费用
                        DeductChargeForNews();
                        break;
                    case "xy032":
                        GetCustomFieldHTML(); //获取自定义字段内容
                        break;
                    case "xy033":
                        GetModuleType();  //获取类别信息
                        break;
                    case "xy035"://静态页面的生成状态
                        HtmlState();
                        break;
                    case "xy036"://快速留言的设置
                        SpeedMessageList();
                        break;
                    case "xy040":
                        GetUserLastData();
                        break;
                    case "xy041":
                        OnCreateLemma();
                        break;
                    case "xy044"://百科收藏
                        FavoriteLemma();
                        break;
                    case "xy080":   //在线加盟
                        DelType();//删除分类
                        break;
                    case "xy082":
                        GetSubType();
                        break;
                    case "xy100": //添加产品时要选择的分类信息
                        GetProductSubType();
                        break;
                    case "xy101": //添加产品时搜索分类
                        SearchProductType();
                        break;
                    case "xy200":
                        //发布或者编辑商机，验证码
                        ValidateCode();
                        break;
                    case "xy201":
                        //根据产品分类id获取自定义属性
                        getFieldValuesForPtId();
                        break;
                }
            }
        }

        private void getFieldValuesForPtId()
        {
            int ptid = XYECOM.Core.XYRequest.GetQueryInt("pt_id", 0);
            string url = XYECOM.Core.XYRequest.GetQueryString("url");
            string currTypeId = XYECOM.Core.XYRequest.GetQueryString("curTypeId");

            string html = "";
            if (ptid > 0)
            {
                XYECOM.Business.FieldManager bblfm = new FieldManager();
                IList<Model.FieldValueInfo> table = bblfm.GetFieldValueForPtid(ptid);

                int count = 0;
                foreach (Model.FieldValueInfo item in table)
                {
                    count++;
                    string itemId = item.Field.Id.ToString();
                    string[] temp = Regex.Split(item.Field.InitValue, "_");
                    if (temp == null || temp.Length < 1)
                        continue;

                    html += "<FieldItem>";
                    html += "<FieldName>";
                    html += item.Field.CName;
                    html += "</FieldName>";
                    html += "<FieldId>";
                    html += itemId;
                    html += "</FieldId>";
                    #region

                    html += "<SubFields>";
                    html += "<FieldIndex>";
                    html += -1;
                    html += "</FieldIndex>";
                    html += "<SubFieldName>";
                    html += "不限";
                    html += "</SubFieldName>";
                    html += "<FieldUrl>";
                    Regex reg = new Regex("_" + itemId + @"\.\d+");
                    html += XYECOM.Core.Utils.JSEscape(reg.Replace(url, ""));
                    html += "</FieldUrl>";
                    html += "</SubFields>";

                    for (int i = 0; i < temp.Length; i++)
                    {
                        string filedIdAndSubId = itemId + "." + i;
                        html += "<SubFields>";
                        html += "<FieldIndex>";
                        html += i;
                        html += "</FieldIndex>";
                        html += "<SubFieldName>";
                        html += temp[i];
                        html += "</SubFieldName>";
                        html += "<FieldUrl>";

                        string hlink = string.Empty;

                        if (currTypeId.Contains("_" + itemId + "."))
                        {
                            if (webInfo.IsBogusStatic)
                            {
                                //http://127.0.0.1:8100/search/seller_search-offer-1_10.0_11.1--------.aspx

                                Regex regex = new Regex(itemId + @"\.\d+");
                                string tmpId = regex.Replace(currTypeId, filedIdAndSubId);
                                hlink = url.Replace("-offer-" + currTypeId, "-offer-" + tmpId);
                            }
                            else
                            {
                                Regex regex = new Regex(itemId + @"\.\d+");
                                string tmpId = regex.Replace(currTypeId, filedIdAndSubId);
                                hlink = url.Replace("typeid=" + currTypeId, "typeid=" + tmpId);
                            }
                        }
                        else
                        {
                            if (webInfo.IsBogusStatic)
                            {
                                hlink = url.Replace("-offer-" + currTypeId, "-offer-" + currTypeId + "_" + filedIdAndSubId);
                            }
                            else
                            {
                                hlink = url.Replace("typeid=" + currTypeId, "typeid=" + currTypeId + "_" + filedIdAndSubId);
                            }
                        }
                        html += XYECOM.Core.Utils.JSEscape(hlink);

                        html += "</FieldUrl>";
                        html += "</SubFields>";
                    }
                    #endregion
                    html += "</FieldItem>";
                }
            }

            ResponseXML(Result.Success, "", html);
        }
        private void ValidateCode()
        {
            string strMsg = string.Empty;
            string code = XYECOM.Core.XYRequest.GetQueryString("vcode").Trim();
            bool istrue = false;
            if (!string.IsNullOrEmpty(code) && XYECOM.Core.Utils.GetSession("VNum").ToLower() == code.ToLower())
            {
                istrue = true;
            }

            if (!istrue)
            {
                strMsg = "err";
                ResponseXML(Result.Failed, "", "<content>" + strMsg + "</content>");
            }
            else
            {
                ResponseXML(Result.Success);
            }

        }
        #region 发布产品时对产品分类的操作
        private void GetProductSubType()
        {
            XYECOM.Business.ProductType productTypeBLL = new ProductType();
            int parentId = XYECOM.Core.XYRequest.GetQueryInt("pid", 0);
            if (parentId < 0) parentId = 0;
            List<XYECOM.Model.ProductTypeInfo> infos = productTypeBLL.GetItems(parentId);
            StringBuilder data = new StringBuilder();
            foreach (XYECOM.Model.ProductTypeInfo info in infos)
            {
                data.Append("<Item><ID>");
                data.Append(info.PT_ID);
                data.Append("</ID><Name>");
                data.Append(info.PT_Name);
                data.Append("</Name>");
                data.Append("<ParentId>");
                data.Append(info.PT_ParentID);
                data.Append("</ParentId>");
                data.Append("<FullId>");
                data.Append(XYECOM.Core.Utils.RemoveComma((info.FullId + info.PT_ID).Replace(",0,", "")));
                data.Append("</FullId>");
                data.Append("<IsLeaf>");
                data.Append(info.IsLeaf);
                data.Append("</IsLeaf>");
                data.Append("</Item>");
            }
            ResponseXML(Result.Success, "", data.ToString());
        }
        /// <summary>
        /// 分类搜索的功能 暂没实现
        /// </summary>
        private void SearchProductType()
        {
            string keyword = XYECOM.Core.XYRequest.GetQueryString("q");
            //string lan = CCCME.Common.XYRequest.GetQueryString("language").Trim().ToLower();
            //Classification c = new Classification();

            //IList<IDOL.Model.MacthClassInfo> infoList = c.Match(CCCME.Common.Utils.JSunescape(keyword), (lan == "1" ? IDOL.Model.Language.English : IDOL.Model.Language.Chinese));

            StringBuilder data = new StringBuilder();
            //foreach (MacthClassInfo info in infoList)
            //{
            //    data.Append("<Item><ID>");
            //    data.Append(info.ClassId);
            //    data.Append("</ID><Name>");
            //    data.Append(CCCME.Common.Utils.JSEscape(info.StrClassTree));
            //    data.Append("</Name>");
            //    data.Append("<InfoCount>");
            //    data.Append(info.InfoCount);
            //    data.Append("</InfoCount>");
            //    data.Append("<FullId>");
            //    string fullid = info.FullId;
            //    data.Append(fullid);
            //    data.Append("</FullId>");
            //    data.Append("</Item>");
            //}
            ResponseXML(Result.Success, "", data.ToString());
        }
        #endregion
        private void GetUserLastData()
        {
            string moduleName = XYECOM.Core.XYRequest.GetQueryString("module");
            string userId = XYECOM.Core.XYRequest.GetQueryString("userid");
            string isCommend = XYECOM.Core.XYRequest.GetQueryString("isCommend");

            long _UserId = Core.MyConvert.GetInt64(userId);
            int _IsCommend = Core.MyConvert.GetInt32(isCommend);


            if (string.IsNullOrEmpty(moduleName) || _UserId <= 0)
            {
                ResponseXML(Result.Null, "信息不完整！");
            }

            DataTable table = Business.XYInfo.GetUserLastData(moduleName, _UserId, _IsCommend);

            if (table.Rows.Count <= 0)
            {
                ResponseXML(Result.Failed, "暂无信息!");
            }

            StringBuilder str = new StringBuilder("");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                str.Append("<info>");
                str.Append("<id>" + table.Rows[i]["InfoId"].ToString() + "</id>");
                str.Append("<title>" + table.Rows[i]["Title"].ToString() + "</title>");
                str.Append("</info>");
            }

            ResponseXML(Result.Success, "", str.ToString());
        }

        private void GetSubType()
        {
            string ename = F("moduleName");
            long infoId = L("infoid");

            List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems(ename, infoId);
            StringBuilder data = new StringBuilder();

            foreach (XYECOM.Model.XYClassInfo info in infos)
            {
                data.Append("<Item><ID>");
                data.Append(info.ClassId);
                data.Append("</ID><Name>");
                data.Append(Core.Utils.JSEscape(info.ClassName));
                data.Append("</Name><HasSub>");
                data.Append(info.HasSub.ToString().ToLower());
                data.Append("</HasSub></Item>");
            }

            ResponseXML(Result.Success, "", data.ToString());
        }

        private void MoveOrder()
        {
            string ename = F("moduleName");
            string id = F("infoid");
            int type = I("type", 0);

            int i = 0;

            i = XYECOM.Business.XYClass.UpdateOrder(ename, id, type);

            if (i > 0)
            {
                ResponseXML(Result.Success, "修改成功！");
            }
            else
            {
                ResponseXML(Result.Failed, "修改失败！");
            }
        }

        /// <summary>
        /// 百科收藏
        /// </summary>
        private void FavoriteLemma()
        {
            string strmsg = "err";

            long infoId = XYECOM.Core.XYRequest.GetQueryInt64("InfoId");
            long userId = XYECOM.Core.XYRequest.GetQueryInt64("UserId");


            if (!Business.CheckUser.CheckUserLogin())
            {
                strmsg = "nologin";
            }
            else
            {
                XYECOM.Business.LemmaFavorite f = new XYECOM.Business.LemmaFavorite();
                XYECOM.Model.LemmaFavoriteInfo ef = new XYECOM.Model.LemmaFavoriteInfo();
                ef.LemmaId = infoId;
                ef.UserId = Business.CheckUser.UserInfo.userid;
                int i = 0;
                i = f.Insert(ef);
                if (i >= 0)
                {
                    strmsg = "ok";
                }
                else if (i == -1)
                {
                    strmsg = "exis";
                }
                else
                {
                    strmsg = "err";
                }
            }

            ResponseXML(Result.Success, "", "<content>" + strmsg + "</content>");
        }

        #region 百科，创建词条，词条名称验证

        private void OnCreateLemma()
        {
            string name = XYECOM.Core.XYRequest.GetQueryString("lemmaname");
            Business.TmpLemma tmpLemmaBLL = new XYECOM.Business.TmpLemma();
            int res = 0;
            tmpLemmaBLL.CheckLemmaName(name, out res);
            //Business.Lemma lemmaBLL = new XYECOM.Business.Lemma();

            string msg = "";

            if (res == 1)
            {
                msg = "该词条正在被其他用户编辑。";
            }
            else if (res == 2)
            {
                msg = "已经存在该词条！";
            }
            else if (res == 3)
            {
                msg = "该词条已被其他用户创建，等待审核中。";
            }

            ResponseXML(Result.Success, msg);
        }

        #endregion
        /// <summary>
        /// 删除分类
        /// </summary>
        private void DelType()
        {
            string ename = F("moduleName");
            string infoId = F("infoid");
            long parmentId = L("parmentId");

            int i = 0;
            int j = 0;
            XYECOM.Business.XYClass xy = new XYECOM.Business.XYClass();

            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job"))
                {
                    XYECOM.Business.Post post = new Post();
                    j = xy.InfoNum("i_engageinfo", "P_ID", infoId);
                    if (j <= 0)
                    {
                        i = post.Delete(infoId);
                    }
                }
                else if (ename.Equals("exhibition"))
                {
                    XYECOM.Business.ShowType showtype = new XYECOM.Business.ShowType(); ;
                    j = xy.InfoNum("XY_showinfo", "typeid", infoId);
                    if (j <= 0)
                    {
                        i = showtype.Delete(infoId);
                    }
                }

            }
            else
            {
                if (ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer"))
                {
                    XYECOM.Business.ProductType pt = new XYECOM.Business.ProductType();
                    j = xy.InfoNum("i_supply", "PT_ID", infoId);
                    if (j <= 0)
                    {
                        i = pt.Delete(infoId);
                    }
                }
                else if (ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment"))
                {
                    XYECOM.Business.InviteBusinessType it = new XYECOM.Business.InviteBusinessType();
                    j = xy.InfoNum("i_invitebusinessmaninfo", "IT_ID", infoId);
                    if (j <= 0)
                    {
                        i = it.Delete(infoId);
                    }
                }
                else if (ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service"))
                {
                    XYECOM.Business.ServiceType st = new XYECOM.Business.ServiceType(); ;
                    j = xy.InfoNum("i_serviceinfo", "ST_ID", infoId);
                    if (j <= 0)
                    {
                        i = st.Delete(infoId);
                    }
                }

            }
            if (j > 0)
            {
                ResponseXML(Result.Failed, "该分类下含有信息！");
                return;
            }
            if (i > 0)
            {
                ResponseXML(Result.Success, "删除成功");
                return;
            }
        }

        private int I(string str, int defaultvalue)
        {
            return XYECOM.Core.XYRequest.GetQueryInt(str, defaultvalue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private long L(string str)
        {
            return XYECOM.Core.XYRequest.GetQueryInt64(str);
        }

        /// <summary>
        /// 接受Get方式传过来的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string F(string str)
        {
            return XYECOM.Core.XYRequest.GetQueryString(str);
        }

        #region 通用方法
        private enum Result : int
        {
            /// <summary>
            /// 参数不完整
            /// </summary>
            Null = -1,
            /// <summary>
            /// 失败
            /// </summary>
            Failed,
            /// <summary>
            /// 成功
            /// </summary>
            Success
        }

        /// <summary>
        /// 输出XML格式的JS变量
        /// </summary>
        /// <param name="result"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        private void ResponseXML(Result result, string msg, string data)
        {
            StringBuilder str = new StringBuilder();
            str.Append("var " + XYECOM.Core.XYRequest.GetQueryString("ajaxidnex") + " = '<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            str.Append("<XYMsg>");
            str.Append("<state>");
            str.Append("<result>" + (int)result + "</result>");
            str.Append("<message>" + msg + "</message>");
            str.Append("</state>");
            str.Append("<data>");
            str.Append(System.Text.RegularExpressions.Regex.Replace(data.Replace("'", "\""), "[\n-\r]", ""));
            str.Append("</data>");
            str.Append("</XYMsg>'");
            content.Response.Write(str.ToString());
            content.Response.End();
        }

        private void ResponseXML(Result result, string msg)
        {
            ResponseXML(result, msg, "");
        }

        private void ResponseXML(Result result)
        {
            ResponseXML(result, "", "");
        }
        /// <summary>
        /// 通用输出方法
        /// </summary>
        /// <param name="str"></param>
        private void ResponseWrite(string str)
        {
            content.Response.Write(str);
            content.Response.End();
        }

        private void WriteLog(Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            log.Error("", ex);
        }

        #region 短信通知
        private void SendMessage(long OF_ID)
        {
            //XYECOM.Business.OrderForm OForm = new XYECOM.Business.OrderForm();
            //XYECOM.Model.OrderFormInfo orderInfo = OForm.GetItem(OF_ID);
            //string typec = "您成功订购货品";
            //string typeu = "您的商品被成功订购";
            //switch (orderInfo.OF_Type)
            //{
            //    case 1:
            //        typeu = "您成功订购货品";
            //        typec = "您的商品被成功订购";
            //        break;
            //    case 2:
            //        typeu = "卖家已经添加运费，等待您确认付款";
            //        typec = "您已经确认运费";
            //        break;
            //    case 3:
            //        typeu = "您已经确认付款";
            //        typec = "卖家已经确认付款，等待您发货";
            //        break;
            //    case 4:
            //        typeu = "卖家已经确认付款";
            //        typec = "您已经确认付款，请及时确认发货";
            //        break;
            //    case 5:
            //        typeu = "卖家已经确认发货，请您及时确认收货";
            //        typec = "您已经确认发货";
            //        break;
            //    case 6:
            //        typeu = "您已经确认收货";
            //        typec = "卖家已经确认收货";
            //        break;
            //    case 7:
            //        typeu = "您要求退货";
            //        typec = "买家要求退货";
            //        break;
            //    case 8:
            //        typeu = "卖家同意退货";
            //        typec = "您同意退货";
            //        break;
            //    case 9:
            //        typeu = "退货成功";
            //        typec = "退货成功";
            //        break;
            //    case 10:
            //        typeu = "交易成功";
            //        typec = "交易成功";
            //        break;
            //    case 12:
            //        typeu = "卖家拒绝退货";
            //        typec = "您拒绝退货";
            //        break;
            //}

            //XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();

            ////获取购买者信息
            //Model.UserInfo buyerUserInfo = userInfoBLL.GetItem(orderInfo.Customer_ID);
            ////获取销售者信息
            //Model.UserInfo sellerUserInfo = userInfoBLL.GetItem(orderInfo.OF_UID);

            //XYECOM.Business.Message messageBLL = new XYECOM.Business.Message();
            //XYECOM.Model.MessageInfo messgeInfo = new XYECOM.Model.MessageInfo();
            ////发给卖者
            //messgeInfo.M_Adress = orderInfo.LinkAddress;

            //if (buyerUserInfo != null)
            //    messgeInfo.M_CompanyName = buyerUserInfo.Name;

            //messgeInfo.M_Email = "";
            //messgeInfo.M_FHM = "";
            //messgeInfo.M_HasReply = false;
            //messgeInfo.M_Moblie = "";
            //messgeInfo.M_PHMa = orderInfo.LinkTel;
            //messgeInfo.M_RecverType = "administrator";
            //messgeInfo.M_Restore = false;
            //messgeInfo.M_SenderType = "user";
            //messgeInfo.M_Title = typec;
            //messgeInfo.M_Content = "订单：" + orderInfo.OF_Code + "----" + typec;
            //messgeInfo.M_UserName = orderInfo.LinkMan;
            //messgeInfo.M_UserType = false;
            //messgeInfo.U_ID = -2;
            //messgeInfo.UR_ID = orderInfo.OF_UID;
            //messageBLL.Insert(messgeInfo);

            ////发给买者
            //if (sellerUserInfo != null)
            //    messgeInfo.M_CompanyName = sellerUserInfo.Name;

            //messgeInfo.M_HasReply = false;
            //messgeInfo.M_Moblie = "";
            //messgeInfo.M_PHMa = sellerUserInfo.Telephone;
            //messgeInfo.M_RecverType = "administrator";
            //messgeInfo.M_Restore = false;
            //messgeInfo.M_SenderType = "user";
            //messgeInfo.UR_ID = orderInfo.Customer_ID;
            //messgeInfo.M_Title = typeu;
            //messgeInfo.M_UserName = sellerUserInfo.LinkMan;
            //messgeInfo.M_UserType = false;
            //messgeInfo.U_ID = -2;
            //messgeInfo.M_Adress = sellerUserInfo.AreaInfo.Name + "," + sellerUserInfo.Address;
            //messgeInfo.M_Content = "订单：" + orderInfo.OF_Code + "----" + typeu;
            //messageBLL.Insert(messgeInfo);
        }
        #endregion

        #region 发送邮件
        private bool EmailRemind(long OF_ID)
        {
            return false;
            //XYECOM.Business.OrderForm OForm = new XYECOM.Business.OrderForm();
            //XYECOM.Model.OrderFormInfo orderInfo = OForm.GetItem(OF_ID);
            //string typec = "您成功订购货品";
            //string typeu = "您的商品被成功订购";
            //XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();
            //XYECOM.Business.Supply supplyBLL = new XYECOM.Business.Supply();

            ////获取卖家信息
            //XYECOM.Model.UserInfo sellerInfo = userInfoBLL.GetItem(orderInfo.OF_UID);
            ////获取买家信息
            //XYECOM.Model.UserInfo buyerInfo = userInfoBLL.GetItem(orderInfo.Customer_ID);
            ////获取对应产品信息
            //XYECOM.Model.SupplyInfo supplyInfo = supplyBLL.GetItem(orderInfo.SD_ID);
            //获取网站信息
            //

            //switch (orderInfo.OF_Type)
            //{
            //    case 1:
            //        typeu = "您成功订购货品";
            //        typec = "您的商品被成功订购";
            //        break;
            //    case 2:
            //        typeu = "卖家已经添加运费，等待您确认付款";
            //        typec = "您已经确认运费";
            //        break;
            //    case 3:
            //        typeu = "您已经确认付款";
            //        typec = "卖家已经确认付款，等待您发货";
            //        break;
            //    case 4:
            //        typeu = "卖家已经确认付款";
            //        typec = "您已经确认付款，请及时确认发货";
            //        break;
            //    case 5:
            //        typeu = "卖家已经确认发货，请您及时确认收货";
            //        typec = "您已经确认发货";
            //        break;
            //    case 6:
            //        typeu = "您已经确认收货";
            //        typec = "卖家已经确认收货";
            //        break;
            //    case 7:
            //        typeu = "您要求退货";
            //        typec = "买家要求退货";
            //        break;
            //    case 8:
            //        typeu = "卖家同意退货";
            //        typec = "您同意退货";
            //        break;
            //    case 9:
            //        typeu = "退货成功";
            //        typec = "退货成功";
            //        break;
            //    case 10:
            //        typeu = "交易成功";
            //        typec = "交易成功";
            //        break;
            //    case 12:
            //        typeu = "卖家拒绝退货";
            //        typec = "您拒绝退货";
            //        break;
            //}

            ////发给卖家
            //string[] sendSeller = new string[] { typec, sellerInfo.LinkMan,supplyInfo.Title,webInfo.WebName, webInfo.WebDomain,
            //    orderInfo.OF_Price.ToString(),supplyInfo.Unit,orderInfo.OF_Number.ToString(),orderInfo.OF_Money.ToString(),orderInfo.OF_BeginTime.ToString(),buyerInfo.Name,buyerInfo.LinkMan,
            //    buyerInfo.Telephone,buyerInfo.AreaInfo.Name + "," + orderInfo.LinkAddress,"送货地址",orderInfo.OF_Code         
            //};
            ////发给买方
            //string[] sendBuyer = new string[] { typeu, buyerInfo.LinkMan,supplyInfo.Title,webInfo.WebName, webInfo.WebDomain,
            //    orderInfo.OF_Price.ToString(),supplyInfo.Unit,orderInfo.OF_Number.ToString(),orderInfo.OF_Money.ToString(),orderInfo.OF_BeginTime.ToString(),sellerInfo.Name,sellerInfo.LinkMan,
            //    sellerInfo.Telephone,sellerInfo.AreaInfo.Name + "," + sellerInfo.Address ,"联系地址"  ,orderInfo.OF_Code            
            //};
            ////标签
            //string[] str = new string[] { "{$type$}", "{$username$}", "{$SD_Title$}","{$WI_Name$}", "{$SD_url$}", "{$OF_Price$}", "{$SD_Unit$}", "{$OF_Number$}", "{$OF_Money$}", "{$OF_AddDate$}",
            //    "{$companyname$}","{$linkman$}", "{$tephone$}", "{$LinkAddress$}", "{$LinkAddtype$}" ,"{$OFCode$}"};

            ////发给卖家
            //string strcontent = XYECOM.Core.TemplateEmail.GetContent(sendSeller, str, "/templateEmail/Order.htm");
            ////发给买家
            //string strcontents = XYECOM.Core.TemplateEmail.GetContent(sendBuyer, str, "/templateEmail/Order.htm");


            //bool result = XYECOM.Business.Utils.SendMail(sellerInfo.RegInfo.Email, typec, strcontent);

            //result = XYECOM.Business.Utils.SendMail(buyerInfo.RegInfo.Email, typeu, strcontents);

            //return result;
        }
        #endregion
        #endregion

        #region 获取类别信息
        private void GetClassTypes()
        {
            string ids = XYECOM.Core.XYRequest.GetQueryString("strID");
            string Mode = XYECOM.Core.XYRequest.GetQueryString("Mode").Trim();

            string moduleName = XYECOM.Core.XYRequest.GetQueryString("module");
            string customParams = XYECOM.Core.XYRequest.GetQueryString("Params");
            string str = "";
            List<XYECOM.Model.XYClassInfo> classlist = null;
            if ("" == Mode)//获取列表
            {
                Int64 tmpID = XYECOM.Core.MyConvert.GetInt64(ids);
                if (customParams != "")
                {
                    classlist = XYECOM.Business.XYClass.GetSubItems(moduleName, tmpID, customParams);
                }
                else
                {
                    classlist = XYECOM.Business.XYClass.GetSubItems(moduleName, tmpID);
                }

                if (null != classlist)
                {
                    foreach (XYECOM.Model.XYClassInfo info in classlist)
                    {
                        str += "<Item><ID>" + info.ClassId.ToString() + "</ID><Name>" + Core.Utils.JSEscape(info.ClassName) + "</Name><HasSub>" + info.HasSub.ToString().ToLower() + "</HasSub></Item>";
                    }
                }
            }
            else if ("GetInfo" == Mode && "" != ids)//获取单条记录
            {
                Int64 tmpID = XYECOM.Core.MyConvert.GetInt64(ids);
                XYECOM.Model.XYClassInfo info = new XYECOM.Model.XYClassInfo();

                classlist = XYECOM.Business.XYClass.GetParentClassInfos(moduleName, tmpID);

                if (null != classlist)
                {
                    string fullids = "", fullNames = "";
                    bool tmpok = true;
                    foreach (XYECOM.Model.XYClassInfo sinfo in classlist)
                    {
                        if (tmpok)
                        {
                            info = sinfo;
                            tmpok = false;
                        }
                        else
                        {
                            if ("" != fullids) fullids = "," + fullids;
                            if ("" != fullNames) fullNames = "," + fullNames;
                            fullids = sinfo.ClassId + fullids;
                            fullNames = sinfo.ClassName + fullNames;
                        }
                    }
                    str += "<ParentID>" + info.ParentId + "</ParentID><Name>" + Core.Utils.JSEscape(info.ClassName) + "</Name><HasSub>" + info.HasSub.ToString().ToLower() + "</HasSub><FullID>" + Core.Utils.JSEscape(fullids) + "</FullID><FullName>" + Core.Utils.JSEscape(fullNames) + "</FullName>";
                }
            }
            else if ("GetInfos" == Mode && "" != ids)//获取多条记录
            {
                classlist = XYECOM.Business.XYClass.GetSubItems(moduleName, ids);

                if (null != classlist)
                {
                    foreach (XYECOM.Model.XYClassInfo info in classlist)
                    {
                        str += "<Item><ID>" + info.ClassId.ToString() + "</ID><Name>" + Core.Utils.JSEscape(info.ClassName) + "</Name><HasSub>" + info.HasSub.ToString().ToLower() + "</HasSub></Item>";
                    }
                }
            }

            if ("" != str)
                ResponseXML(Result.Success, "", str);
            else
                ResponseXML(Result.Failed, "暂无数据！");
        }
        #endregion

        #region 游客留言
        private void VisitorMessasge()
        {
            string strMsg = "";
            string toemail = "";

            string userId = XYECOM.Core.XYRequest.GetQueryString("uids");

            long _UserID = XYECOM.Core.MyConvert.GetInt64(userId);
            int infoId = 0;
            #region 游客留言

            if (XYECOM.Configuration.Security.Instance.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Message))
            {
                if (!CheckCode(F("GCode").ToString()))
                {
                    strMsg = "codeErr";
                    ResponseXML(Result.Success, "", "<content>" + strMsg + "</content>");
                }
            }

            XYECOM.Business.Message messageBLL = new XYECOM.Business.Message();
            XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();
            XYECOM.Model.UserRegInfo userRegInfo = null;
            infoId = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("ids"));

            if (_UserID > 0)
            {
                userRegInfo = userRegBLL.GetItem(_UserID);

                if (userRegInfo != null)
                {
                    toemail = userRegInfo.Email;
                }
                else
                {
                    if (infoId > 0)
                    {
                        XYECOM.Model.SupplyInfo supplyInfo = new XYECOM.Business.Supply().GetItem(infoId);

                        if (supplyInfo != null)
                            userRegInfo = userRegBLL.GetItem(supplyInfo.UserID);

                        if (userRegInfo != null)
                        {
                            toemail = userRegInfo.Email.ToString();
                            _UserID = supplyInfo.UserID;
                        }
                    }
                }
            }
            XYECOM.Model.MessageInfo messageInfo = new XYECOM.Model.MessageInfo();
            messageInfo.M_UserName = XYECOM.Core.Utils.RemoveHTML(F("linkman")); //联系人
            messageInfo.M_Email = XYECOM.Core.Utils.RemoveHTML(F("email"));//电子邮件                                                           
            messageInfo.M_Moblie = XYECOM.Core.Utils.RemoveHTML(F("mobile"));//手机
            messageInfo.M_Title = XYECOM.Core.Utils.IsLength(40, XYECOM.Core.Utils.RemoveHTML(F("title")));//留言标题
            messageInfo.M_Content = XYECOM.Core.Utils.IsLength(400, XYECOM.Core.Utils.RemoveHTML(F("neirong")));//留言内容
            messageInfo.M_SenderType = F("type");
            messageInfo.M_Sex = false;
            messageInfo.U_ID = 0;
            messageInfo.M_UserType = false;
            messageInfo.M_RecverType = "";
            messageInfo.InfoId = infoId;
            string sexStr = "女士";

            if (F("sex") == "1")
            {
                messageInfo.M_Sex = true;
                sexStr = "先生";
            }

            if (_UserID > 0) messageInfo.UR_ID = _UserID;

            //这块有问题  因为客户端传递的变量usertype永远为1
            //个人认为应该根据选择企业或者个人值有所不同
            //if (F("usertype") == "1") messageInfo.M_UserType = true; //收到留言者类型
            messageInfo.M_UserType = true;

            int result = messageBLL.Insert(messageInfo);

            if (result >= 0)
            {

                string[] dLabel = new string[] {
                    messageInfo.M_Title,
                    messageInfo.M_Content,
                    "<ul><li>姓名:"+messageInfo.M_UserName+" " + sexStr+"</li><li>邮箱:"+messageInfo.M_Email+"</li><li>电话:"+messageInfo.M_Moblie+"</li></ul>",
                    webInfo.WebDomain,
                    webInfo.WebName
                };
                string[] sLabel = new string[] { "{$Title$}", "{$Body$}", "{$Contacts$}", "{$WebUrl$}", "{$WebName$}" };


                XYECOM.Business.Utils.SendMail(toemail, messageInfo.M_Title, XYECOM.Core.TemplateEmail.GetContent(dLabel, sLabel, "/templateEmail/Enquiry.htm"));

                XYECOM.Core.Utils.ClearSession("VNum");

                strMsg = "ok";
            }
            else
            {
                strMsg = "err";
            }


            ResponseXML(Result.Success, "", "<content>" + strMsg + "</content>");
            #endregion
        }
        #endregion

        #region 用户留言
        private void UserMessage()
        {
            string strMsg = "";

            string content = XYECOM.Core.Utils.IsLength(100, XYECOM.Core.XYRequest.GetQueryString("content"));
            string code = XYECOM.Core.XYRequest.GetQueryString("code");
            string title = XYECOM.Core.Utils.IsLength(50, XYECOM.Core.XYRequest.GetQueryString("title"));
            string type = XYECOM.Core.XYRequest.GetQueryString("type");
            string ids = XYECOM.Core.XYRequest.GetQueryString("ids");
            string uids = XYECOM.Core.XYRequest.GetQueryString("uids");

            if (content.Equals("") || title.Equals("") || ids.Equals("") || uids.Equals(""))
            {
                strMsg = "-1";
            }
            else if (!Business.CheckUser.CheckUserLogin())
            {
                strMsg = "nologin";
            }
            else
            {
                if (Business.CheckUser.UserInfo.userid.ToString() == uids)
                {
                    strMsg = "nomessage";
                }
            }

            if (XYECOM.Configuration.Security.Instance.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Message))
            {
                if (!CheckCode(code))
                {
                    strMsg = "codeErr";
                }
            }

            if (!strMsg.Equals(""))
            {
                ResponseXML(Result.Success, "", "<content>" + strMsg + "</content>");
            }

            //当前登录用户ID
            long loginUserId = Business.CheckUser.UserInfo.userid;
            //当前信息发布者ID
            long infoUserId = Convert.ToInt64(uids);

            string toEmail = new Business.UserReg().GetItem(infoUserId).Email;
            long infoId = XYECOM.Core.MyConvert.GetInt64(ids);

            #region 企业会员留言
            XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();
                        

            XYECOM.Model.UserInfo userInfo = userInfoBLL.GetItem(loginUserId);

            if (userInfo != null)
            {
                XYECOM.Model.MessageInfo messageInfo = new XYECOM.Model.MessageInfo();

                messageInfo.M_Adress = userInfo.Address;
                messageInfo.M_Content = XYECOM.Core.Utils.RemoveHTML(content);
                messageInfo.M_Email = userInfo.RegInfo.Email.ToString();
                messageInfo.M_FHM = userInfo.Fax.ToString();
                messageInfo.M_HasReply = false;
                messageInfo.M_Moblie = userInfo.Mobile.ToString();
                messageInfo.M_PHMa = userInfo.Telephone;
                messageInfo.M_Adress = userInfo.Address.ToString();
                messageInfo.M_RecverType = "";
                messageInfo.M_SenderType = type;
                messageInfo.M_Title = XYECOM.Core.Utils.RemoveHTML(title);
                messageInfo.UR_ID = infoUserId;
                messageInfo.M_UserName = userInfo.LinkMan;
                messageInfo.M_UserType = false;
                messageInfo.U_ID = loginUserId;
                messageInfo.M_CompanyName = userInfo.Name.ToString();
                messageInfo.M_Sex = userInfo.Sex;
                messageInfo.Area_ID = userInfo.AreaId;
                messageInfo.InfoId = infoId;

                string sexStr = "女士";

                if (userInfo.Sex) sexStr = "先生";

                int result = new XYECOM.Business.Message().Insert(messageInfo);
                if (result >= 0)
                {

                    string[] dLabel = new string[] {
                    messageInfo.M_Title,
                    messageInfo.M_Content,
                    "<ul><li>姓名:"+messageInfo.M_UserName+" " + sexStr+"("+messageInfo.M_CompanyName+")</li><li>邮箱:"+messageInfo.M_Email+"</li><li>电话:"+messageInfo.M_Moblie+"</li></ul>",
                    webInfo.WebDomain,
                    webInfo.WebName
                      };

                    string[] sLabel = new string[] { "{$Title$}", "{$Body$}", "{$Contacts$}", "{$WebUrl$}", "{$WebName$}" };
                    XYECOM.Business.Utils.SendMail(toEmail, messageInfo.M_Title, XYECOM.Core.TemplateEmail.GetContent(dLabel, sLabel, "/templateEmail/Enquiry.htm"));
                    XYECOM.Core.Utils.ClearSession("VNum");
                    strMsg = "ok";
                }
                else
                {
                    strMsg = "err";
                }
            }
            #endregion

            ResponseXML(Result.Success, "", "<content>" + strMsg + "</content>");
        }
        #endregion

        private bool CheckCode(string code)
        {
            if (string.IsNullOrEmpty(code) || code.Equals("")) return false;

            if (XYECOM.Core.Utils.GetSession("VNum").ToLower() == code.ToLower())
            {
                XYECOM.Core.Utils.ClearSession("VNum");
                return true;
            }

            return false;
        }

        #region 登陆
        private void Login()//登录
        {
            string name = XYECOM.Core.XYRequest.GetQueryString("Name").Trim();
            string pwd = XYECOM.Core.XYRequest.GetQueryString("Pwd").Trim();
            string code = XYECOM.Core.XYRequest.GetQueryString("Code").Trim();
            string isSave = XYECOM.Core.XYRequest.GetQueryString("IsSave").Trim();
            string page = XYECOM.Core.XYRequest.GetQueryString("Page").Trim().ToLower();

            if (name.Equals("") || pwd.Equals(""))
            {
                ResponseXML(Result.Null, "信息不完整！");
            }

            //如果启用验证
            if (XYECOM.Configuration.Security.Instance.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Login))
            {
                if (!CheckCode(code))
                {
                    ResponseXML(Result.Failed, "验证码不正确!");
                    return;
                }
            }

            XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();

            XYECOM.Model.UserRegInfo userInfo = userRegBLL.Login(name, pwd, isSave != "");

            if (userInfo == null)
            {
                ResponseXML(Result.Failed, "用户名或密码有误!");
            }


            string strUserType = "user";

            string message = "";
            if (page.Equals("infologin")) message = "ok";

            string xmlUserInfo = "<userinfo>"
                                + "<userid>" + userInfo.UserId + "</userid>"
                                + "<loginname>" + userInfo.LoginName + "</loginname>"
                                + "<mark>" + userInfo.Mark + "</mark>"
                                + "<usertype>" + strUserType + "</usertype>"
                                + "</userinfo>";
            //登录成功合并购物车信息
            XYECOM.Model.GeneralUserInfo gernerUserInfo = Business.CheckUser.UserInfo;            

            ResponseXML(Result.Success, message, xmlUserInfo);


        }
        #endregion

        #region 插入新闻评论
        /// <summary>
        /// 插入评论
        /// ok: 成功，err:失败
        /// 
        /// 创建标识：一木鱼 20080507
        /// </summary>
        private void InsertComment()
        {
            String strMsg = "";
            Result lastresult = Result.Null;
            string body = XYRequest.GetQueryString("CommentBody").Trim();
            string newsId = XYRequest.GetQueryString("NewsID").Trim();
            string isHiddenIP = XYRequest.GetQueryString("IsHiddenIP").Trim();
            string vcode = XYRequest.GetQueryString("code").Trim();

            long _newsId = XYECOM.Core.MyConvert.GetInt64(newsId);

            if (body.Equals("") || _newsId == 0)
            {
                strMsg = "评论失败";
                lastresult = Result.Failed;
            }

            //如果启用验证码
            if (XYECOM.Configuration.Security.Instance.IsEnabledValidateCode(XYECOM.Configuration.ValidateCodeItem.Comment))
            {
                if (!CheckCode(vcode))
                {
                    ResponseXML(Result.Failed, "验证码不正确！");
                }
            }

            XYECOM.Model.NewsDiscussInfo info = new XYECOM.Model.NewsDiscussInfo();

            info.IpAddress = XYECOM.Core.XYRequest.GetIP();
            info.IpIsShow = isHiddenIP.Equals("1") ? false : true;
            info.ND_Content = content.Server.HtmlEncode(body);
            info.NS_ID = _newsId;
            info.U_ID = 0;
            info.U_Name = "游客";

            if (Business.CheckUser.CheckUserLogin())
            {
                info.U_ID = Business.CheckUser.UserInfo.userid;
                info.U_Name = Business.CheckUser.UserInfo.loginname;
            }

            info.ND_IsShow = true;

            int result = new XYECOM.Business.NewsDiscuss().Insert(info);

            if (result <= 0)
            {
                strMsg = "评论失败";
                lastresult = Result.Failed;
                ResponseXML(lastresult, strMsg);
            }
            else
            {
                XYECOM.Core.Utils.ClearSession("VNum");
                strMsg = "评论成功";
                lastresult = Result.Success;
                ResponseXML(lastresult, strMsg);
            }
        }
        #endregion


        /// <summary>
        /// 检查用户名是否存在
        /// 
        /// 返回值：
        /// -1,用户名为空
        /// 0,不存在，可以使用
        /// 1,已经存在
        /// 2,禁止使用的名称
        /// </summary>
        private void IsExistsUserByName()
        {
            string name = XYECOM.Core.XYRequest.GetQueryString("name").Trim().ToLower();

            if (name.Equals("")) ResponseXML(Result.Failed, "数据不完整");



            if (webInfo.ForbidName != "")
            {
                string[] names = webInfo.ForbidName.Split(',');

                for (int j = 0; j < names.Length; j++)
                {
                    if (name.Equals(names[j].ToLower()))
                    {
                        ResponseXML(Result.Failed, "此用户名不允许注册");
                        break;
                    }
                }
            }

            Business.UserReg userRegBLL = new XYECOM.Business.UserReg();
            if (userRegBLL.IsExistTheUserName(name))
            {
                Model.UserRegInfo userRegInfo = userRegBLL.GetItem(name);

                ResponseXML(Result.Failed, "此用户名已被注册，请选择其他用户名", "<question>" + userRegInfo.Question + "</question>");
            }

            ResponseXML(Result.Success, "验证通过");
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// 
        /// 返回值：
        /// -1,用户名为空
        /// 0,不存在，可以使用
        /// 1,已经存在
        /// </summary>
        private void IsExistsUserByEmail()
        {
            Result result = Result.Success;
            string message = "";

            string email = XYECOM.Core.XYRequest.GetQueryString("email").Trim().ToLower();

            if (email.Equals(""))
            {
                result = Result.Null;
                message = "数据不完整！";
            }

            if (message.Equals(""))
            {
                if (new XYECOM.Business.UserReg().IsExistTheEmail(email))
                {
                    result = Result.Failed;
                    message = "此邮箱已被注册，请选用其他邮箱！";
                }
            }

            if (message.Equals("")) message = "验证通过！";

            ResponseXML(result, message, "");
        }

        #region 重设密码
        /// <summary>
        /// 重设密码
        /// </summary>
        private void RetakePassword()
        {
            string userName = XYECOM.Core.XYRequest.GetQueryString("userName");
            string question = XYECOM.Core.XYRequest.GetQueryString("question");
            string answer = XYECOM.Core.XYRequest.GetQueryString("answer");
            string newPwd = XYECOM.Core.XYRequest.GetQueryString("newPwd");


            if (userName == "" || question == "" || answer == "" || newPwd == "")
            {
                ResponseXML(Result.Null, "数据不完整！");
            }

            int _result = new XYECOM.Business.UserReg().RetakePassWord(userName, XYECOM.Core.SecurityUtil.MD5(newPwd, XYECOM.Configuration.Security.Instance.Md5value), question, answer);

            string message = "";
            Result result = Result.Failed;

            if (_result == -2)
            {
                message = "重置失败！请重新尝试！";
            }

            if (_result == -1)
            {
                message = "密码提示问题或密码提示答案错误！";
            }

            if (_result == 1)
            {
                result = Result.Success;
                message = "重置密码成功！";
            }

            ResponseXML(result, message);
        }

        private void RetakePassword(string temp)
        {
            string email = XYECOM.Core.XYRequest.GetQueryString("email");

            if (email == "")
            {
                ResponseXML(Result.Null, "数据不完整！");
            }

            int _result = new XYECOM.Business.UserReg().RetakePassWord(email);

            //1:成功,0:邮箱不能为空,-1:邮箱不存在,-2:重设密码失败,-3:异常失败

            if (_result == 1) ResponseXML(Result.Success, "密码已发到邮箱");

            if (_result == 0) ResponseXML(Result.Null, "邮箱不能为空");

            if (_result == -1) ResponseXML(Result.Failed, "邮箱不存在,请输入注册邮箱");

            if (_result == -2) ResponseXML(Result.Failed, "重设密码失败,请稍候再试");

            if (_result == -3) ResponseXML(Result.Failed, "异常失败");
        }
        #endregion
        
        #region 收藏
        private void Favorite()
        {
            string strmsg = "err";
            string module = XYECOM.Core.XYRequest.GetQueryString("Module");
            string infoId = XYECOM.Core.XYRequest.GetQueryString("InfoId");
            string userId = XYECOM.Core.XYRequest.GetQueryString("UserId");

            if (module == "" || infoId == "" || userId == "")
            {
                strmsg = "-1";
            }
            else if (!Business.CheckUser.CheckUserLogin())
            {
                strmsg = "nologin";
            }
            else if (Business.CheckUser.UserInfo.userid.ToString() == userId)
            {
                strmsg = "nomessage";
            }
            else
            {
                XYECOM.Business.Favorite f = new XYECOM.Business.Favorite();
                XYECOM.Model.FavoriteInfo ef = new XYECOM.Model.FavoriteInfo();
                if (module.ToString() != "")
                {
                    string[] _ids = infoId.ToString().Split(',');

                    for (int j = 0; j < _ids.Length; j++)
                    {
                        ef.DescTabID = Convert.ToInt64(_ids[j].ToString());
                        if (Business.CheckUser.CheckUserLogin())
                        {
                            ef.U_ID = Business.CheckUser.UserInfo.userid;
                        }
                        ef.DescTabName = module;
                    }
                }
                int i = 0;
                i = f.Insert(ef);
                if (i >= 0)
                {
                    strmsg = "ok";
                }
                else if (i == -1)
                {
                    strmsg = "exis";
                }
                else
                {
                    strmsg = "err";
                }
            }

            ResponseXML(Result.Success, "", "<content>" + strmsg + "</content>");
        }
        #endregion

        #region 获取新闻评论
        private void GetNewsComment()
        {
            string strdata = "";

            Result result = Result.Null;

            XYECOM.Business.NewsDiscuss newsDiscussBLL = new XYECOM.Business.NewsDiscuss();

            string newsId = XYECOM.Core.XYRequest.GetQueryString("value");
            if (newsId.Equals(""))
            {
                ResponseXML(Result.Null, "数据不完整!");
            }

            string strColumuName = " ND_ID, U_Name,U_Flag, U_ID, ND_Content, ND_AddTime,IPIsShow,IPAddress ";

            int topNum = 4;
            int clikcNum = 0;

            clikcNum = XYECOM.Core.Function.Updateinfo(" where NS_ID=" + XYECOM.Core.XYRequest.GetQueryString("value"), "n_News", "NS_Count");
            DataTable tableDiscuss = newsDiscussBLL.GetDataTable(newsId, "", strColumuName, topNum);

            if (tableDiscuss.Rows.Count <= 0)
            {
                ResponseXML(Result.Failed, "没有评论信息!");
            }

            string userType = "";
            string userName = "";
            string shopUrl = "";

            for (int i = 0; i < tableDiscuss.Rows.Count; i++)
            {
                userName = tableDiscuss.Rows[i]["U_Name"].ToString();

                if (tableDiscuss.Rows[i]["U_ID"].ToString() == "0")
                {
                    userType = "guest";
                    shopUrl = "";
                }
                else
                {
                    if (tableDiscuss.Rows[i]["U_Flag"].ToString().ToLower().Equals("true"))
                    {
                        userType = "user";

                        if (webInfo.IsDomain)
                            shopUrl = "http://" + tableDiscuss.Rows[i]["U_Name"].ToString() + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].Substring(HttpContext.Current.Request.ServerVariables["HTTP_HOST"].IndexOf(".")) + "/";
                        else
                            shopUrl = webInfo.WebDomain + "shop/" + tableDiscuss.Rows[i]["U_Name"].ToString() + "/index." + webInfo.WebSuffix;
                    }
                    else
                    {
                        userType = "person";
                        shopUrl = "";
                    }
                }

                strdata += "<comment>"
                                + "<user>"
                                + "  <name>" + userName + "</name>"
                                + "  <shopurl>" + shopUrl + "</shopurl>"
                                + "  <type>" + userType + "</type>"
                                + "</user>"
                                + "<sendtime>" + tableDiscuss.Rows[i]["ND_AddTime"].ToString() + "</sendtime>"
                                + "<content>" + content.Server.HtmlEncode(XYECOM.Business.FiltrateKeyWord.LeachKeyWord(tableDiscuss.Rows[i]["ND_Content"].ToString())) + "</content>"
                            + "</comment>";
            }
            result = Result.Success;
            ResponseXML(result, "", strdata);
        }
        #endregion
        
        #region 判断是否为免费新闻
        private void IsFreeNews()
        {
            string strMsg = "";
            Result result = Result.Null;
            String data = "";
            string newsId = XYECOM.Core.XYRequest.GetQueryString("nid");

            if (newsId.Equals(""))
            {
                ResponseXML(result, "数据不完整");
            }

            long ns_id = Convert.ToInt64(newsId);

            XYECOM.Business.ChargeNews chargeNewsBLL = new XYECOM.Business.ChargeNews();

            Int64 userId = 0;
            if (Business.CheckUser.CheckUserLogin())
                userId = Business.CheckUser.UserInfo.userid;

            int webMoney;   //虚拟货币
            int money;      //现金货币

            int val = chargeNewsBLL.GetIsCharged(userId, ns_id, out webMoney, out money);
            if (val < 0)
            {
                if (val == -3)
                {
                    strMsg = "没有登录";        //代表不可以查看，原因收费新闻,没有登录
                    result = Result.Failed;
                }
                else if (val == -2)
                {
                    strMsg = "权限不足";        //代表不可以查看,原因权限不足
                    result = Result.Failed;
                }
                else
                {
                    strMsg = "";                //可以查看，原因非收费新闻
                    result = Result.Success;
                }
            }
            else if (val > 0)
            {
                strMsg = "已付费";           //代表可以查看,原因已经付过费
                result = Result.Success;
            }
            else
            {
                if (webMoney == 0 && money == 0)
                {
                    strMsg = "";
                    result = Result.Success;
                }
                else
                {
                    strMsg = "收费新闻尚未付费";
                    result = Result.Failed;
                }
                data = "<webmoney>" + webMoney + "</webmoney><money>" + money + "</money>"; //代表不可以查看，因为收费新闻尚未付费
            }
            ResponseXML(result, strMsg, data);
        }
        #endregion

        #region 收费新闻扣除费用
        private void DeductChargeForNews()
        {
            string _newsId = XYECOM.Core.XYRequest.GetQueryString("nid");
            string _webMoney = XYECOM.Core.XYRequest.GetQueryString("webmoney");
            string _money = XYECOM.Core.XYRequest.GetQueryString("money");

            if (_newsId.Equals("") || _webMoney.Equals("") || _money.Equals(""))
            {
                ResponseXML(Result.Null, "数据不完整！");
            }

            long newsId = Convert.ToInt64(_newsId);

            Decimal webmoney = Convert.ToDecimal(_webMoney);
            Decimal money = Convert.ToDecimal(_money);

            Int64 userId = 0;
            if (Business.CheckUser.CheckUserLogin())
                userId = Business.CheckUser.UserInfo.userid;

            XYECOM.Model.ChargeNewsSetInfo chargeNesSetInfo = new XYECOM.Model.ChargeNewsSetInfo();
            XYECOM.Business.ChargeNewsSet chargeNewsSetBLL = new XYECOM.Business.ChargeNewsSet();
            XYECOM.Business.ChargeNews chargeNewsBLL = new XYECOM.Business.ChargeNews();

            if (webmoney == 0 && money == 0)
            {
                chargeNesSetInfo.U_ID = userId;
                chargeNesSetInfo.NS_ID = newsId;


                int row = chargeNewsSetBLL.Insert(chargeNesSetInfo);
                if (row >= 0)
                    //strMsg = "ok$0";   //添加成功,因为扣费皆为0,所以只插入付费信息
                    ResponseXML(Result.Success, "添加成功");
                else
                    //strMsg = "err$1";  //缴费失败
                    ResponseXML(Result.Failed, "缴费失败");
            }
            else
            {
                int rowAff = chargeNewsBLL.ConsumeUpdateMoney(userId, newsId, webmoney, money);

                if (rowAff >= 0)
                { //strMsg += "ok$1";   //扣费成功,消费记录,付费记录都成功
                    ResponseXML(Result.Success, "成功");
                }
                else if (rowAff == -1)
                    //strMsg += "err$-1"; //扣费失败,因为帐户余额不足
                    ResponseXML(Result.Failed, "帐户余额不足");
                else
                    //strMsg += "err$1";  //扣费失败
                    ResponseXML(Result.Failed, "帐户余额不足");

            }
        }
        #endregion

        #region 获取自定义字段内容
        private void GetCustomFieldHTML()
        {
            string moduleName = XYECOM.Core.XYRequest.GetQueryString("module");
            string typeid = XYECOM.Core.XYRequest.GetQueryString("typeid");

            if (moduleName.Equals("") || typeid.Equals(""))
            {
                ResponseXML(Result.Failed, "数据不完整");
            }

            long _TypeId = MyConvert.GetInt64(typeid);

            string html = "";//XYECOM.Business.Field.CreateFieldInnerHTML(_TypeId, moduleName);

            html = XYECOM.Core.Utils.JSEscape(html);

            ResponseXML(Result.Success, "", "<html>" + html + "</html>");
        }
        #endregion

        #region 获取类别
        private void GetModuleType()
        {
            String moduleName = XYECOM.Core.XYRequest.GetQueryString("moduleName");
            int typeID = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("typeID"));
            string areaid = XYECOM.Core.XYRequest.GetQueryString("areaid");
            string times = XYECOM.Core.XYRequest.GetQueryString("times");
            string keyword = XYECOM.Core.XYRequest.GetQueryString("keyword");
            string flag = XYECOM.Core.XYRequest.GetQueryString("flag");

            string cacheObjName = moduleName + "_" + typeID + "_" + areaid + "_" + times + "_" + keyword + "_" + flag;

            object obj = XYECOM.Label.LabelCache.GetCache(cacheObjName, XYECOM.Label.LabelCacheType.ClassInfoStat);

            if (obj != null)
            {
                ResponseXML(Result.Success, "", obj.ToString());
                return;
            }

            XYECOM.Configuration.InfoType infoType = XYECOM.Configuration.InfoType.Sell;
            if (flag.ToLower().Equals("buy")) infoType = XYECOM.Configuration.InfoType.Buy;

            List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetTypeByModuleNameAndTypeID(moduleName, infoType, typeID, areaid, times, keyword);

            String str = "";

            foreach (XYECOM.Model.XYClassInfo info in infos)
            {
                str += "<classlist><classID>" + info.ClassId + "</classID>" + "<className>" + Core.Utils.JSEscape(info.ClassName) + "</className>" + "<infoNum>" + info.InfoNum + "</infoNum></classlist>";
            }

            XYECOM.Label.LabelCache.InsertCache(cacheObjName, str, XYECOM.Label.LabelCacheType.ClassInfoStat);

            ResponseXML(Result.Success, "", str);
        }
        #endregion

        #region 获取关键字
        //private void KeyWord()
        //{
        //    string str = "";

        //    string Mode = XYECOM.Core.XYRequest.GetQueryString("Mode").Trim();
        //    string tmpID = XYECOM.Core.XYRequest.GetQueryString("strID").Trim();
        //    if ("" == Mode)
        //    {
        //        XYECOM.Business.Keyword kw = new XYECOM.Business.Keyword();
        //        XYECOM.Model.KeywordInfo ki = new XYECOM.Model.KeywordInfo();
        //        string strWhere = "where 1=1";
        //        string strOrder = " Order by KI_ID desc";
        //        DataTable dt = kw.GetDataTable(strWhere, strOrder);

        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                str += "<Item><ID>" + dt.Rows[i]["KI_ID"].ToString() + "</ID><Name>" + Core.Utils.JSEscape(dt.Rows[i]["KI_Name"].ToString()) + "</Name><HasSub>false</HasSub></Item>";
        //            }
        //        }
        //    }
        //    else if ("" != tmpID)
        //    {
        //        str += "<ParentID>0</ParentID><Name>" + Core.Utils.JSEscape(new XYECOM.Business.Keyword().GetKeywordName(Convert.ToInt32(tmpID))) + "</Name><FullID></FullID><FullName></FullName>";
        //    }

        //    if ("" != str)
        //        ResponseXML(Result.Success, "", str);
        //    else
        //        ResponseXML(Result.Failed, "暂无数据！");
        //}
        #endregion

        #region html静态页面的生成状态
        private void HtmlState()
        {
            string str = "";
            if (Html.HtmlManage.TaskList.Count > 0)
            {
                Html.HtmlInfo info = Html.HtmlManage.TaskList[0];
                str += "<HtmlIndex>" + info.PageIndex + "</HtmlIndex>";
                str += "<HtmlCount>" + Html.HtmlManage.HtmlCount.ToString() + "</HtmlCount>";
                str += "<HtmlCurrent>" + Html.HtmlManage.HtmlCurrent.ToString() + "</HtmlCurrent>";
                ResponseXML(Result.Success, "", str);
            }
            ResponseXML(Result.Failed, "全部生成完毕！", str);
        }
        #endregion

        #region 快速留言设置
        private void SpeedMessageList()
        {
            string str = "";
            string module = XYECOM.Core.XYRequest.GetQueryString("module").Trim();

            List<Model.ExpressMessageInfo> infos = new XYECOM.Business.ExpressMessage().GetItems(module);

            if (infos.Count > 0)
            {
                foreach (Model.ExpressMessageInfo info in infos)
                {
                    str += "<msglist><id>" + info.Id + "</id><title>" + info.Body + "</title></msglist>";
                }
                ResponseXML(Result.Success, "", str);
            }
            ResponseXML(Result.Failed, "没有数据！", str);
        }
        #endregion
    }
}
