<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartLabelView.aspx.cs" Inherits="XYECOM.Web.xymanage.LabelManage.PartLabelView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="../css/style.css" type="text/css" rel="stylesheet" />
    <link href="/common/css/xylib.css" type="text/css" rel="stylesheet" />
    <title>专栏标签预览</title>
    <style>
        /*企业专栏样式*/
.part1_cls{ width:250px; border:1px solid #ccc; padding:3px; text-align:left}
.part1_cls .part_top{ overflow:hidden; margin-bottom:5px;}
.part1_cls .part_top .part_top_left{ float:left; width:48%; font-weight:bold;}
.part1_cls .part_top .part_top_right a{font-weight:bold; font-size:12px;}
.part1_cls .part_top .part_top_right{ float:right; width:45%; line-height:130%;}
.part1_cls .part_top_left img{height:50px; width:130px;}

.part1_cls .part_infos{ line-height:150%; width:100%;}
.part1_cls .part_infos li{width:100%; overflow:hidden; height:18px;}
.part1_cls .part_infos li a{margin-left:2px; }


.part2_cls{ width:345px; border:1px solid #ccc; padding:5px;text-align:left}
.part2_cls .part_top{ overflow:hidden; margin-bottom:5px;}
.part2_cls .part_top .part_top_left{ float:left; width:35%; font-weight:bold;}
.part2_cls .part_top .part_top_right a{font-weight:bold; font-size:12px;}
.part2_cls .part_top .part_top_right{ float:right; width:60%; line-height:130%;}
.part2_cls .part_top_left img{height:50px; width:130px;}

.part2_cls .part_infos{ line-height:150%;}
.part2_cls .part_infos .part_top_left{ float:left; width:65%; }
.part2_cls .part_infos .part_top_right{float:right; width:30%;}

.part2_cls .part_infos li{width:100%; overflow:hidden; height:16px; padding:0px; margin:0px;}
.part2_cls .part_infos li a{margin-left:2px; }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1><a href="../index.aspx">后台管理首页</a> >> 企业专栏预览</h1>
    <div>
    <label runat="server" id="lblBody">
        
    </label>
    </div>
    <div>
        <input id="Button1" class="button" type="button" value="返回" onclick="location.href='PartLabelList.aspx';" />
    </div>
    </form>
</body>
</html>
