<%@ Page Language="C#" AutoEventWireup="true" Inherits="xymanage_basic_SearchKeyInfo"
    CodeBehind="SearchKeyInfo.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>���Źؼ�����Ϣ</title>
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
//              return alertmsg("��ѡ���ȴ�����.","",false);
//           }
//        }
//        
//        if(document.getElementById("txtKeywords").value == "")
//        {
//             return alertmsg("�ȴ����Ʋ���Ϊ��.","",false);
//        }
//        
//        if(document.getElementById("txtCount").value == "")
//        {
//            return alertmsg("�ȴʵ��������ʼֵ����Ϊ��,����������.","",false);
//        }
//        else if(document.getElementById("txtCount").value != "")
//        {
//             var text = document.getElementById("txtCount").value;
//             if(checknumber(text))
//             {
//                document.getElementById("txtCount").value = "";
//                document.getElementById("txtCount").focus();
//                return alertmsg("ֻ������������.","",false)
//             }
//        }
//        
//         //�Ƿ�������֤
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
        <a href="../index.aspx">��̨������ҳ</a> >> ���Źؼ�����Ϣ</h1>
    <table width="100%">
        <tr>
            <td class="right">
                <div class="main-setting">
                    <div class="itemtitle">
                        <h3 id="cantion" runat="server">
                            ���Źؼ�����Ϣ</h3>
                    </div>
                    <table class="xy_tb xy_tb2">
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                ����ģ�飺
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
                                �ؼ��֣�
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform" style="width: 400px;">
                                <asp:TextBox ID="txtKeywords" runat="server" Columns="80" CssClass="input" TextMode="MultiLine"
                                    Rows="4"></asp:TextBox>
                                <input id="hidskid" runat="Server" type="hidden" />
                            </td>
                            <td class="vtop tips2">
                                <asp:Label ID="lblKeywordsTips" runat="server" Text="����ؼ���֮����,�Ÿ���"></asp:Label>
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                ����������
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
                                �Ƿ��Ƽ���
                            </td>
                        </tr>
                        <tr>
                            <td class="vtop rowform">
                                <asp:RadioButton ID="rbIsCommendTrue" runat="server" GroupName="IsCommend" CssClass="input"
                                    Text="�Ƽ�" />
                                <asp:RadioButton ID="rbIsCommendFalse" runat="server" GroupName="IsCommend" CssClass="input"
                                    Text="���Ƽ�" Checked="True" />
                            </td>
                            <td class="vtop tips2">
                            </td>
                        </tr>
                        <tr class="nobg">
                            <td colspan="2" class="td27">
                                �Ƿ����������
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
                                    onclick="__xy_SetPriceDiv();" />����
                                <input type="radio" id="rbIsRankingFalse" runat="server" name="IsRanking" class="input"
                                    checked="True" onclick="__xy_SetPriceDiv();" />������
                                <br />
                                <div class="tabPrice" id="divCustomPrice">
                                    <input type="checkbox" id="chkIsCustomPrice" runat="server" onclick="__xy_IsCustomPrice();" />�Զ��������۸�
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
                                <asp:Button runat="server" ID="btadd" CssClass="button" Text="ȷ ��" OnClick="btadd_Click" />&nbsp;<input
                                    id="btcancel" runat="Server" class="button" type="button" value="�� ��" />
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
