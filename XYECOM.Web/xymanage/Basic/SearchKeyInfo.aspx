<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_SearchKeyInfo"
    CodeBehind="SearchKeyInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>热门关键字信息</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="/common/js/base.js"></script>

    <script language="javascript" type="text/javascript">
//     function Input()
//     {
//        if(document.getElementById("hidskid").value == "-1")
//        {
//           var type = false;
//           var chklist = document.all.tags("input");
//           for (i = 0; i < chklist.length; i++)
//           {
//              if(chklist[i].type == "checkbox")
//              {
//                  if(chklist[i].checked == true)
//                  {
//                     type = true;
//                     break;
//                  }
//              }
//           }
//           if(type == false)
//           {
//              return alertmsg("请选择热词类型.","",false);
//           }
//        }
//        
//        if(document.getElementById("txtKeywords").value == "")
//        {
//             return alertmsg("热词名称不能为空.","",false);
//        }
//        
//        if(document.getElementById("txtCount").value == "")
//        {
//            return alertmsg("热词点击次数初始值不能为空,请输入数字.","",false);
//        }
//        else if(document.getElementById("txtCount").value != "")
//        {
//             var text = document.getElementById("txtCount").value;
//             if(checknumber(text))
//             {
//                document.getElementById("txtCount").value = "";
//                document.getElementById("txtCount").focus();
//                return alertmsg("只允许输入数字.","",false)
//             }
//        }
//        
//         //是否数字验证
//        function checknumber(string)
//        {
//           var letters = "1234567890";
//           var i;
//           var c;
//           for(i = 0; i < string.length; i++)
//           {
//             c = string.charAt(i);
//             if(letters.indexOf(c) == -1)
//             {
//               return true;
//             }
//           }
//           return false;
//       }
//     }
     
    function __xy_IsCustomPrice()
    {
        var chk = document.getElementById("chkIsCustomPrice");
        var ele = document.getElementById("tablePrice");
        var txts = ele.getElementsByTagName("input");
            
        if(!chk.checked)
        {
            for(var i=0;i<txts.length;i++)
            {
                txts[i].disabled =true;
            }
        }
        else
        {
            for(var i=0;i<txts.length;i++)
            {
                txts[i].disabled =false;
            }
        }
    }
    </script>

    <style type="text/css">
        .tabPrice
        {
            margin-top: 10px;
            border: 1px solid #ccc;
            background-color: #ffffe1;
            padding: 10px;
        }
        .tabPrice table
        {
            background-color: #ffffff;
            margin-top: 10px;
            border: 1px solid #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        <a href="../index.aspx">后台管理首页</a> >> 热门关键字信息</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3 id="cantion" runat="server">
                            热门关键字信息</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                所属模块：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop" colspan="2">
                                <asp:CheckBoxList runat="server" ID="chkModules" CssClass="input" RepeatDirection="Horizontal"
                                    RepeatColumns="5" RepeatLayout="Table">
                                </asp:CheckBoxList>
                                <asp:Label ID="lbtype" runat="server"></asp:Label>
                                <input id="hidModuleName" type="hidden" runat="server" />
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                关键字：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform" style="width: 400px;">
                                <asp:TextBox ID="txtKeywords" runat="server" Columns="80" CssClass="input" TextMode="MultiLine"
                                    Rows="4"></asp:TextBox>
                                <input id="hidskid" runat="Server" type="hidden" />
                            </td>
                            <td class="vtop tips2">
                                <asp:Label ID="lblKeywordsTips" runat="server" Text="多个关键词之间用,号隔开"></asp:Label>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                搜索次数：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:TextBox ID="txtCount" runat="Server" MaxLength="4" CssClass="input" Width="40px"></asp:TextBox>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                是否推荐：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:RadioButton ID="rbIsCommendTrue" runat="server" GroupName="IsCommend" CssClass="input"
                                    Text="推荐" />
                                <asp:RadioButton ID="rbIsCommendFalse" runat="server" GroupName="IsCommend" CssClass="input"
                                    Text="不推荐" Checked="True" />
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                是否参与排名：
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">

                                <script type="text/javascript">
    function __xy_SetPriceDiv()
    {
        if(document.getElementById("rbIsRankingTrue").checked == true)
        {
            document.getElementById("divCustomPrice").style.display ="";
        }
        else
        {
            document.getElementById("divCustomPrice").style.display ="none";
        }
    }
                                </script>

                                <input type="radio" id="rbIsRankingTrue" runat="server" name="IsRanking" class="input"
                                    onclick="__xy_SetPriceDiv();" />参与
                                <input type="radio" id="rbIsRankingFalse" runat="server" name="IsRanking" class="input"
                                    checked="True" onclick="__xy_SetPriceDiv();" />不参与
                                <br />
                                <div class="tabPrice" id="divCustomPrice">
                                    <input type="checkbox" id="chkIsCustomPrice" runat="server" onclick="__xy_IsCustomPrice();" />自定义排名价格
                                    <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>

                                    <script type="text/javascript">
    __xy_IsCustomPrice();
    __xy_SetPriceDiv();
                                    </script>

                                </div>
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="content_action">
                        <tr>
                            <th>
                            </th>
                            <td class="center">
                                <asp:Button runat="server" ID="btadd" CssClass="button" Text="确 定" OnClick="btadd_Click" />&nbsp;<input
                                    id="btcancel" runat="Server" class="button" type="button" value="返 回" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
