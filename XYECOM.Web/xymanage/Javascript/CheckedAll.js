/*=================================  (Old) Ajax Start =========================================
* 修改标识:Tc 20080707
*===============================================================================================*/

function XMLHttpObject(url, Syne) {
    var XMLHttp = null
    var o = this
    this.url = url
    this.Syne = Syne

    this.sendData = function () {
        if (window.XMLHttpRequest) {
            XMLHttp = new XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            XMLHttp = new ActiveXObject("Microsoft.XMLHTTP");
        }

        with (XMLHttp) {
            open("GET", this.url, this.Syne);
            onreadystatechange = o.CallBack;
            send(null);
        }
    }

    this.OnComplete = function (responseText, responseXml) {
        // Complete
    }

    this.OnAbort = function () {
        // Abort
    }

    this.OnError = function (status, statusText) {
        // Error
    }

    this.CallBack = function () {
        if (XMLHttp.readyState == 1) {
            //this.OnLoading();
        }
        else if (XMLHttp.readyState == 2) {
            //this.OnLoaded();
        }
        else if (XMLHttp.readyState == 3) {
            //this.OnInteractive();
        }
        else if (XMLHttp.readyState == 4) {
            if (XMLHttp.status == 0)
                o.OnAbort();
            else if (XMLHttp.status == 200 && XMLHttp.statusText == "OK")
                o.OnComplete(XMLHttp.responseText, XMLHttp.responseXML);
            else
                o.OnError(XMLHttp.status, XMLHttp.statusText, XMLHttp.responseText);
        }
    }
}

/**************************** (Old)Ajax End *************************/

function SelectAll(objID) {
    var obj = undefined == objID ? document : $(objID);
    var chkother = obj.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox' && chkother[i].id.indexOf("newOnly") == -1) {
            if (chkother[i].checked)
                chkother[i].checked = false;
            else
                chkother[i].checked = true;
        }
    }
}

function chkAll_true() {
    var chkall = document.all["chkAll"];
    var j = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkall.checked == true) {
                    chkother[i].checked = true;
                }
                else {
                    chkother[i].checked = false;
                }
            }
        }
    }
}
function chkAll22() {
    var chkall = document.all["chkAll2"];
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('CBL') > -1) {
                if (chkall.checked == true) {
                    chkother[i].checked = true;
                }
                else {
                    chkother[i].checked = false;
                }
            }
        }
    }
}

function chkchoose_true() {
    var chkall = document.all["chkAll"];
    var j = 0;
    var chkother = document.getElementsByTagName("input");
    var str = "";
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('input') > -1) {
                if (chkall.checked == true) {
                    chkother[i].checked = true;
                    str += chkother[i].value + ",";
                }
                else {
                    chkother[i].checked = false;
                }
            }
        }
    }
    $("strids").value = str;
}

function ChkSelete() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                }
            }
        }
    }

    if (j == 0) {
        sAlert("请至少选择一条记录！", "", true);
        return false;
    }

    return true;
}

function del() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                }
            }
        }
    }

    if (j == 0) {
        sAlert("请至少选择一条记录！", "", true);
        return false;
    }
    else {
        return confirm("确定删除吗？");
    }
}


function edit() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                }
            }
        }
    }

    if (j == 0) {
        return alertmsg('必须选择一条记录才能修改！', '', false);
    }
    else if (j > 1) {
        return alertmsg('不能同时修改多条记录！', '', false);
    }
}

function Rect() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                }
            }
        }
    }

    if (j == 0) {
        return alert('必须选择一条记录才能推荐！', '', false);
    }
}


function QueryString() {
    //构造参数对象并初始化 
    var name, value, i;

    // var str = location.href;//获得浏览器地址栏URL串 
    // var num = str.indexOf("?") 
    //str = str.substr(num+1);//截取“?”后面的参数串 
    var str = location.search.substr(1);

    var arrtmp = str.split("&"); //将各参数分离形成参数数组 
    for (i = 0; i < arrtmp.length; i++) {
        var num = arrtmp[i].indexOf("=");
        if (num > 0) {
            name = arrtmp[i].substring(0, num).toLowerCase(); //取得参数名称 
            value = arrtmp[i].substr(num + 1); //取得参数值 
            this[name] = value; //定义对象属性并初始化 
        }
    }
}
var objRequest = new QueryString(); //使用new运算符创建参数对象实例 

/**
=====================================设置SEO信息 开始================================================
**/
//复制内容
function copyinfo(num) {
    switch (num) {
        case 1:

            $("tbsupplytitle").value = $("tbIndextitle").value;
            $("tbsupplydsp").value = $("tbindexdsp").value;
            $("tbsupplykw").value = $("tbindexkw").value;

            if ($("index").checked == true)
                $("supply").checked = true;
            else
                $("supply").checked = false;



            $("hidSupplyNav").value = $("hidIndexNav").value;
            $("supplyNav").innerHTML = $("indexNav").innerHTML;
            break;
        case 2:
            $("tbdemandtitle").value = $("tbIndextitle").value;
            $("tbdemanddsp").value = $("tbindexdsp").value;
            $("tbdemandkw").value = $("tbindexkw").value;

            if ($("index").checked == true)
                $("demand").checked = true;
            else
                $("demand").checked = false;

            $("hidDemandNav").value = $("hidIndexNav").value;
            $("demandNav").innerHTML = $("indexNav").innerHTML;
            break;
        case 3:
            $("tbbusinesstitle").value = $("tbIndextitle").value;
            $("tbbusinessdsp").value = $("tbindexdsp").value;
            $("tbbusinesskw").value = $("tbindexkw").value;

            if ($("index").checked == true)
                $("business").checked = true;
            else
                $("business").checked = false;

            $("hidBusinessNav").value = $("hidIndexNav").value;
            $("businessNav").innerHTML = $("indexNav").innerHTML;
            break;
        case 4:
            $("tbengagetitle").value = $("tbIndextitle").value;
            $("tbengagedsp").value = $("tbindexdsp").value;
            $("tbengagekw").value = $("tbindexkw").value;

            if ($("index").checked == true)
                $("engage").checked = true;
            else
                $("engage").checked = false;

            $("hidEngageNav").value = $("hidIndexNav").value;
            $("engageNav").innerHTML = $("indexNav").innerHTML;
            break;
        case 5:
            $("tbcorporationtitle").value = $("tbIndextitle").value;
            $("tbcorporationdsp").value = $("tbindexdsp").value;
            $("tbcorporationkw").value = $("tbindexkw").value;

            if ($("index").checked == true)
                $("corporation").checked = true;
            else
                $("corporation").checked = false;

            $("hidCorporationNav").value = $("hidIndexNav").value;
            $("corporationNav").innerHTML = $("indexNav").innerHTML;
            break;
        case 6:
            $("tbaddresstitle").value = $("tbIndextitle").value;
            $("tbaddressdsp").value = $("tbindexdsp").value;
            $("tbaddresskw").value = $("tbindexkw").value;

            if ($("index").checked == true)
                $("address").checked = true;
            else
                $("address").checked = false;

            $("hidAddressNav").value = $("hidIndexNav").value;
            $("addressNav").innerHTML = $("indexNav").innerHTML;
            break;
    }
}

//新增关键词导航
function addkeyword() {
    if ($("txtname").value == "") {
        return alertmsg('关键字不能为空！', '', false);
    }
    else if ($("txturl").value == "") {
        return alertmsg('链接地址不能为空！', '', false);
    }
    else {
        switch ($("hidkeyflag").value) {
            case "1":
                $("hidindexNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("indexNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;
            case "2":
                $("hidSupplyNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("supplyNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;
            case "3":
                $("hidDemandNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("demandNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;
            case "4":
                $("hidBusinessNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("businessNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;
            case "5":
                $("hidEngageNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("engageNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;
            case "6":
                $("hidCorporationNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("corporationNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;
            case "7":
                $("hidAddressNav").value += "," + $("txtname").value + "$" + $("txturl").value;
                $("addressNav").innerHTML += "<a href=\"" + $("txturl").value + "\" title=\"" + $("txtname").value + "\">" + $("txtname").value + "</a>";
                break;

        }

        $("addnav").style.display = "none";
    }
}

//显示添加关键词导航添加层
function showaddnav(num) {
    $("txtname").value = "";
    $("txturl").value = "";
    $("hidkeyflag").value = num;
    $("addnav").style.display = "block";
    $("addnav").style.height = document.documentElement.scrollHeight;
    $("seoalphaBox").style.height = document.documentElement.scrollHeight + "px";
    if (navigator.appName == "Microsoft Internet Explorer")
        $("seoalphaBox").style.width = document.documentElement.scrollWidth + "px";
    else
        $("seoalphaBox").style.width = document.documentElement.scrollWidth + "px";
}

//初始化关键字导航信息
function onloadnav() {

    if ($("hidAddressNav").value != "") {
        var links = $("hidAddressNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("addressNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }

    if ($("hidCorporationNav").value != "") {
        var links = $("hidCorporationNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("corporationNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }

    if ($("hidEngageNav").value != "") {
        var links = $("hidEngageNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("engageNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }

    if ($("hidBusinessNav").value != "") {
        var links = $("hidBusinessNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("businessNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }


    if ($("hidDemandNav").value != "") {
        var links = $("hidDemandNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("demandNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }

    if ($("hidSupplyNav").value != "") {
        var links = $("hidSupplyNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("supplyNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }

    if ($("hidindexNav").value != "") {
        var links = $("hidindexNav").value.split(',');
        for (var i = 0; i < links.length; i++) {
            var urls = links[i].split('$');
            $("indexNav").innerHTML += "<a href=\"" + urls[1] + "\" title=\"" + urls[0] + "\">" + urls[0] + "</a>";
        }
    }

}

/**
=====================================设置SEO信息 结束================================================
**/
/**
=====================================标签管理 开始================================================
**/
//选择标签样式类别
function selecttablename(num) {
    var select = $("scontent").getElementsByTagName("select");

    for (var i = 0; i < select.length; i++) {
        if (i + 1 != num) {
            select[i].style.display = "none";

            try { $("sel" + (i + 1)).style.display = "none"; } catch (e) { }
        }
        else {
            select[i].style.display = "block";

            var tmp = $("hidTableName").value;

            if (tmp != "") num = parseInt(tmp);

            try { $("sel" + num).style.display = "block"; } catch (e) { }
        }
    }
}
//初始化
function InitListBox() {
    if ($("hidTableName").value != "") {
        selecttablename($("hidTableName").value)
    }
}

//选择标签样式
//2008-6-3 update By 蘇哥拉笛
function selectcolumuname(obj) {
    //tagName=obj.name;
    //tag=$(tagName).options.value;
    tag = obj.value;
    var myField;
    myField = $('txtConent');
    if (document.selection) {
        myField.focus();
        sel = document.selection.createRange();
        sel.text = tag;
        myField.focus();
    } else if (myField.selectionStart || myField.selectionStart == '0') {
        var startPos = myField.selectionStart;
        var endPos = myField.selectionEnd;
        var cursorPos = endPos;
        myField.value = myField.value.substring(0, startPos)
                                          + tag
                                          + myField.value.substring(endPos, myField.value.length);
        cursorPos += tag.length;
        myField.focus();
        myField.selectionStart = cursorPos;
        myField.selectionEnd = cursorPos;
    } else {
        myField.value += tag;
        myField.focus();
    }
}

//添加标签
function AddLabel() {
    if ($("tbName").value == "") {
        return alertmsg('名称不能为空！', '', false);
    }
    if ($("hidLT_ID").value == "") {
        return alertmsg('请选择所属栏目！', '', false);
    }

    if ($("rbtnSystem").checked) {
        $("hidUserIds").value = "";
        $("hidGroupIds").value = "";
    }

    if ($("rbtnUser").checked) {
        if ($F("hidUserIds") == "") {
            return alertmsg('请选择标签所属用户！', '', false);
        }
    }

    if ($("rbtnUserGroup").checked) {
        if ($F("hidGroupIds") == "") {
            return alertmsg('请选择标签所属的用户组！', '', false);
        }
    }

    if ($("tbContent").value == "") {
        return alertmsg('标签内容不能为空！', '', false);
    }

    if ($("txtConent").value == "") {
        return alertmsg('主体循环标记不能为空！', '', false);
    }

    return true;
}

function setLabelValue(value) {
    if (value != "") {
        $("tbContent").value = "";
        $("tbContent").value = "{";
        $("tbContent").value += value;
        $("tbContent").value += "}";
    }
    $("Div_window").style.display = "none";
    $("window").style.display = "none";

    IsDisplaySelect(value);
    //selecttablename($F("hidTableName"));
}

//设置是否显示 
//08-06-24 Add By蘇哥拉笛
function IsDisplaySelect(value) {
    var num1 = (value.indexOf("$")) + 1;
    var num2 = value.indexOf("┆");
    var name = value.substring(num1, num2);
    var select = $("scontent").getElementsByTagName("select");

    switch (name) {

        case "SupplyList":
        case "SupplyPageList":
        case "SupplyKeyPageList":
        case "DemandList":
        case "DemandPageList":
        case "MachiningKeyPageList":
        case "BusinessList":
        case "BusinessPageList":
        case "InvestmentKeyPageList":
        case "SurrogateList":
        case "SurrogatePageList":
        case "ServiceKeyPageList":
        case "ShowList":
        case "ShowPageList":
        case "ExhibitionKeyPageList":
        case "BrandList":
        case "BrandPageList":
        case "EngageList":
        case "EngagePageList":
        case "CorporationList":
        case "CorporationPageList":
        case "UserNews":
        case "BaikeList":
        case "BaikePageList":
        case "VoteList":
        case "SupplyBuyList":
        case "SupplyBuyPageList":
        case "TeamBuyList":
        case "TeamBuyPageList":
            //case "AssociatorList":
            //case "AssociatorPageList":
            //case "TopicList":
            //case "TopicPageList":
            selecttablename($F("hidTableName"));
            break;
        default:
            name = "lst_" + value.substring(num1, num2);

            //临时处理
            if (name.toLowerCase() == "lst_associatorpagelist") name = "lst_AssociatorList";
            if (name.toLowerCase() == "lst_newspagelist") name = "lst_NewsList";
            if (name.toLowerCase() == "lst_usernewspagelist") name = "lst_UserNewsList";
            if (name.toLowerCase() == "lst_topicpagelist") name = "lst_TopicList";

            for (var i = 0; i < select.length; i++) {
                if (select[i].id == name) {
                    select[i].style.display = "block";
                } else {
                    if (i + 1 < 8) {
                        $("sel" + (i + 1)).style.display = "none";
                    }
                    select[i].style.display = "none";
                }
            }
            break;
    }
}


function setChildNum(num) {
    $("hidTableName").value = num;
}

//弹出设置模态窗口
function setshow(num) {
    var url = "";
    var strset = "";
    var dWidth = 520;
    var dHeight = 440;
    $("hidTableName").value = num;

    switch (num) {
        case 1:
            url = "SupplySet.aspx";
            break;
        case 2:
            url = "DemandSet.aspx";
            break;
        case 3:
            url = "BusinessSet.aspx";
            break;
        case 4:
            url = "SurrogateSet.aspx";
            break;
        case 5:
            url = "ShowSet.aspx";
            break;
        case 6:
            url = "BrandSet.aspx";
            break;
        case 7:
            url = "EngageSet.aspx";
            break;
        case 8:
            url = "CorporationSet.aspx";
            break;
        case 9:
            url = "NewsSet.aspx";
            break;
        case 11:
            url = "AssociatorSet.aspx";
            dWidth = 440;
            dHeight = 300;
            break;
        case 12:
            url = "TopicSet.aspx";
            break;
        case 13:
        case 15:
            url = "currencyset.aspx";
            dWidth = 440;
            dHeight = 300;
            break;
        case 17:
            url = "baikeset.aspx";
            break;
        case 18:
            url = "VoteSet.aspx";
            break;
        case 19:
            url = "UserNewsSet.aspx";
            break;
        case 20:
            url = "supplyBuySet.aspx";
            break;
        case 21:
            url = "TeamBuySet.aspx";
            break;
    }
    var scrollPos = new getScrollPos();
    var pageSize = new getPageSize();

    $("Div_window").style.height = (pageSize.docheight + scrollPos.scrollY) + "px";

    $("Div_window").style.background = "#000";
    $("Div_window").style.filter = "alpha(opacity=30)";
    $("Div_window").style.opacity = 0.9;
    $("Div_window").style.MozOpacity = 0.3;
    $("Div_window").style.display = "block";

    try {
        if ($("lableid").value != "") {
            url += "?lid=" + $("lableid").value;
            if ($F("hidUserIds") != "") {
                url += "&uid=" + $F("hidUserIds");
            }
        } else {
            if ($F("hidUserIds") != "") {
                url += "?uid=" + $F("hidUserIds");
            }
        }
    } catch (e) { }

    $("window").src = url;
    $("window").style.width = dWidth + "px";
    $("window").style.display = "block";
    $("window").style.height = dHeight + "px";

    var x = Math.round(pageSize.width / 2) - (dWidth / 2) + scrollPos.scrollX;
    var y = 30;

    $("window").style.display = 'block';
    $("window").style.left = x + 'px';
    $("window").style.top = y + 'px';
}

function iframeload(obj) {
    //    if(!IE()){ 
    //		obj.height=obj.contentDocument.body.scrollHeight;}
    //	else{
    //		obj.style.height=obj.contentWindow.document.body.scrollHeight + 10;}

}

//获取选择的资讯栏目
function lselectnewtype() {
    $("hidPT_ID").value = $("newstitleids").value;
}

//获取选择的企业类别
function lselectusertype() {
    $("hidPT_ID").value = $("companytypeids").value;
}

//关闭标签层
function closewindows() {
    parent.$("Div_window").style.display = "none";
    parent.$("window").style.display = "none";
}

//验证信息标签设置
function isNumer(obj) {
    if (obj.value != "") {
        if (obj.value.search(/^[-\+]?\d+$/) == -1) {
            obj.value = "";
            return alertmsg("输入的不是数字！", '', false);
        }
    }
}

function labelvalidate(num) {
    //    switch(num)
    //    {
    //        case 1:
    //            if($("typeids").value!="")
    //            {
    //                $("hidptid").value = $("typeids").value;
    //            }
    //            break;
    //        case 2:
    //            if($("processtypeids").value!="")
    //            {
    //                $("hidptid").value = $("processtypeids").value;
    //            }
    //            break;
    //        case 3:
    //            if($("suogatetypeids").value!="")
    //            {
    //                $("hidptid").value = $("suogatetypeids").value;
    //            }
    //            break;
    //        case 4:
    //            if($("servertypeids").value!="")
    //            {
    //                $("hidptid").value = $("servertypeids").value;
    //            }
    //            break;
    //        case 5:
    //            if($("cooperatetypeids").value!="")
    //            {
    //                $("hidptid").value = $("cooperatetypeids").value;
    //            }
    //            break;
    //        case 6:
    //            if($("jobtypeids").value!="")
    //            {
    //                $("hidptid").value = $("jobtypeids").value;
    //            }
    //            break;    
    //        case 7:
    //            if($("companytypeids").value!="")
    //            {
    //                $("hidptid").value = $("companytypeids").value;
    //            }
    //            break;
    //        case 8:
    //            if($("newstitleids").value!="")
    //            {
    //                $("hdgetid").value = $("newstitleids").value;
    //            }
    //            break;
    //    }
}
function setlabelTableStyle(obj) {
    var arrli = $("labelTable").getElementsByTagName("li");

    for (i = 0; i < arrli.length; i++) {
        arrli[i].className = "";
    }
    obj.className = "current";
}

//信息标签设置
function infoshow(num, obj) {
    setlabelTableStyle(obj);

    switch (num) {
        case 1:
            $("base").style.display = "block";
            $("page").style.display = "none";
            $("key").style.display = "none";
            break;
        case 2:
            $("base").style.display = "none";
            $("page").style.display = "block";
            $("key").style.display = "none";
            break;
        case 3:
            $("base").style.display = "none";
            $("page").style.display = "none";
            $("key").style.display = "block";
            break;
    }
}



//08-11-17 add tc
function setHeaderLabelStyle(num) {
    var arrli = $("labelTable").getElementsByTagName("td");

    for (i = 0; i < arrli.length; i++) {
        arrli[i].className = "";
    }
    $("tdHeader" + num).className = "contentllabeltd";
}

/**
=====================================标签管理 结束================================================
**/

//管理员权限添加
function AdminAdd() {
    if ($("ddlRose").value == "-1") {
        return alertmsg('请选择要添加的角色!', '', false);
    }
    if ($("txtName").value == "") {
        return alertmsg('登陆用户名必须填写!', '', false);
    }
    if ($("txtName").value.length < 4) {
        return alertmsg('登陆用户名长度不能小于4个字符!', '', false);
    }
    if ($("txtPwd").value == "") {
        return alertmsg('密码不能为空!', '', false);
    }
    if ($("txtPwd").value.length < 6) {
        return alertmsg('为了您的帐户安全,密码长度不能小于6个字符!', '', false);
    }
    if ($("txtPwd2").value == "") {
        return alertmsg('请在次输入密码!', '', false);
    }
    if ($("txtPwd").value != $("txtPwd2").value) {
        return alertmsg('两次输入密码不一样,请从新输入!', '', false);
    }
}
//管理员权限修改
function AdminEdit() {
    if ($("ddlUpdate").value == "-1") {
        return alertmsg('请选择角色!', '', false);
    }

    if ($F("txtYuanPwd").trim() != "") {
        if ($F("txtNewPwd").trim() == "") {
            return alertmsg('请输入新密码!', '', false);
        }
        if ($F("txtOKpwd").trim() == "") {
            return alertmsg('请在次输入密码!', '', false);
        }
        if ($F("txtNewPwd").trim() != $F("txtOKpwd").trim()) {
            return alertmsg('两次输入密码不一样,请从新输入!', '', false);
        }
    }
}



//添加角色
function roleadd() {
    if ($("txtName").value == "") {
        return alertmsg('请输入角色名称！', '', false);
    }
}
//修改角色
function roleedit() {
    if ($("TextBox1").value == "") {
        return alertmsg('请输入角色名称！', '', false);
    }
}



//用户等级管理开始
function usergradeadd() {
    if ($("txtName").value == "") {
        return alertmsg('用户等级名必须填写！', '', false);
    }
    if ($("ymoney").value == "") {
        return alertmsg('请输入年租金！', '', false);
    }

    if ($("mmoney").value == "") {
        return alertmsg('请输入月租金！', '', false);
    }

    if ($("ymoney").value.search(/^[0-9]+$/) != -1 || $("ymoney").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("ymoney").value = Math.round(parseFloat($("ymoney").value) * 100) / 100
    }
    else {
        return alertmsg('年租金输入格式错误！\n 例：88.88', '', false)
    }

    if ($("mmoney").value.search(/^[0-9]+$/) != -1 || $("mmoney").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("mmoney").value = Math.round(parseFloat($("mmoney").value) * 100) / 100
    }
    else {
        return alertmsg('月租金格输入格式错误！\n 例：88.88', '', false)
    }
}
function usergradeedit() {

    if ($("txtname1").value == "") {
        return alertmsg('用户等级名必须填写!', '', false);
    }

    if ($("mmoney1").value == "") {
        return alertmsg('请输入月租金！', '', false);
    }
    if ($("ymoney1").value == "") {
        return alertmsg('请输入年租金！', '', false);
    }

    if ($("ymoney1").value.search(/^[0-9]+$/) != -1 || $("ymoney1").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("ymoney1").value = Math.round(parseFloat($("ymoney1").value) * 100) / 100
    }
    else {
        return alertmsg('年租金输入格式错误！\n 例：88.88', '', false)
    }
    if ($("mmoney1").value.search(/^[0-9]+$/) != -1 || $("mmoney1").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("mmoney1").value = Math.round(parseFloat($("mmoney1").value) * 100) / 100
    }
    else {
        return alertmsg('月租金格输入格式错误！\n 例：88.88', '', false)
    }
}
//用户等级管理开始结束


//财务信息开始
function FinanceInfo() {

    if ($("ddlRose").value == "-1") {
        return alertmsg('选择财务类型！', '', false);
    }
    if ($("txtName").value == "") {
        return alertmsg('请输入财务费用！', '', false);
    }
    //    else 
    //	{   
    //        IsFloat($("txtName"))
    //     }    
    if ($("txtuser").value == "") {
        return alertmsg('请输入用户姓名！', '', false);
    }
}
function FinanceInfoEdit() {
    if ($("ddlUpdate").value == "-1") {
        return alertmsg('选择财务类型！', '', false);
    }

    if ($("txtuser1").value == "") {
        return alertmsg('请输入用户姓名！', '', false);
    }
    if ($("txtNewPwd").value == "") {
        return alertmsg('请输入财务费用！', '', false);
    }
    else {
        IsFloat($("txtName"))
    }
}
//财务信息结束


function block() {
    $("add").style.display = 'block';
    window.location.href = "#addtable"
}
function quit() {
    $("add").style.display = 'none'
}
function Exit() {
    $("update").style.display = 'none';
}
function load() {
    switch ($("key").value) {
        case "1":
            $("add").style.display = "none";
            break;
        case "2":
            $("update").style.display = "block";
            break;
        default:
            break;
    }
}



//财务类别开始
function FinanceTypeAdd() {
    if ($("txtName").value == "") {
        return alertmsg('请输入财务类别！', '', false);
    }
}
function FinanceTypeedit() {
    if ($("name").value == "") {
        return alertmsg('请输入财务类别！', '', false);
    }
}
//财务类型结束




//支付方式开始
function paymathodadd() {
    if ($("txtName").value == "") {
        return alertmsg('支付方式必须填写！', '', false);
    }
    if ($("remark").value == "") {
        return alertmsg('备注必须填写！', '', false);
    }
}
function paymathodedit() {
    if ($("txtUpdate").value == "") {
        return alertmsg('支付方式必须填写！', '', false);
    }
    if ($("remark1").value == "") {
        return alertmsg('备注必须填写！', '', false);
    }
}


//支付方式结束
//产品类别添加
function ProductAdd() {
    if ($("txtName").value == "") {
        return alertmsg('请输入产品类别！', '', false);
    }
}
//产品类别修改
function Productedit() {
    if ($("txtName").value == "") {
        return alertmsg('请输入产品类别！', '', false);
    }
}

//服务器添加
function ServerAdd() {
    if ($("txtName").value == "") {
        return alertmsg('服务器名称必须填写！', '', false);
    }
    if ($("serverpath").value == "") {
        return alertmsg('服务器物理路径必须填写！', '', false);
    }
    if ($("serversul").value == "") {
        return alertmsg('服务器虚拟路径必须填写！', '', false);
    }
}
//服务器修改
function ServerEdit() {
    if ($("txtname1").value == "") {
        return alertmsg('服务器名称必须填写！', '', false);
    }
    if ($("serverpath1").value == "") {
        return alertmsg('服务器物理路径必须填写！', '', false);
    }
    if ($("serversul1").value == "") {
        return alertmsg('服务器虚拟路径必须填写！', '', false);
    }
}
//添加角色
function addrole() {
    if ($("txtName").value == "") {
        return alertmsg('请输入角色名称！', '', false);
    }
}
//修改角色 
function editrole() {
    if ($("TextBox1").value == "") {
        return alertmsg('请输入角色名称！', '', false);
    }
}


//用户类型修改

function usertypeedit() {
    if (document.getElementById("txtName").value == "") {
        return alertmsg('请输入用户类别名称！', '', false);
    }
}


//岗位添加信息和修改
function postadd() {
    if ($("txtName").value == "") {
        return alertmsg('请输入岗位名称！', '', false);
    }
}
function postedit() {
    if ($("Textbox1").value == "") {
        return alertmsg('请输入岗位名称！', '', false);
    }
}
//岗位添加信息和修改


//过滤字管理
function keywordadd() {
    if ($("txtName").value == "") {
        return alertmsg('请输入过滤字名称！', '', false);
    }
}
function keywordedit() {
    if ($("TextBox1").value == "") {
        return alertmsg('请输入过滤字名称', '', false);
    }
}
//过滤字管理


//用户等级设置
function CheckUserGradePopedmoSetting() {
    if ($("refashtime").value == "") {
        return alertmsg('刷新时间不能为空！', '', false)
    }
    if ($("refashnum").value == "") {
        return alertmsg('请填写一天内最多刷新的次数！', '', false)
    }
    if ($("refashnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('刷新次数只能为整数！', '', false);
    }
    if ($("seecontactsnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('查看联系方式条数只能是整数！', '', false);
    }
    if ($("uploadpicnum").value == "") {
        return alertmsg('上传图片的张数不能为空！', '', false);
    }
    if ($("uploadpicnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('上传图片的张数只能是整数！', '', false);
    }
    if ($("LimitDate").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('限定的天数只能是整数！', '', false);
    }
    if ($("refashtimes").value == "") {
        return alertmsg('刷新记录条数不能为空！', '', false);
    }
    if ($("refashtimes").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('刷新记录条数只能为整数!', '', false);
    }

    if ($("ddldebaseusergrade").value == "-1") {
        return alertmsg('请选择该等级用户到期后所降低至的级别', '', false);
    }
    var writenum = document.getElementsByTagName("input");
    var str = "";
    for (var i = 0; i < writenum.length; i++) {
        if (writenum[i].type == 'text') {
            if (writenum[i].id.indexOf('messagevalue') > -1) {
                if (writenum[i].value == "" || writenum[i].value.search(/^[-\+]?\d+$/) == -1) {
                    return alertmsg('请填写完整的条目数，且必须为整数!', '', false);
                } else {
                    if ($("HidLimitDate").value == 1) {
                        str += writenum[i].name + "-0,"
                    } else {
                        str += writenum[i].name + "-" + writenum[i].value + ","
                    }
                }
            }
        }
    }
    $("HidMessagenum").value = str;
}


//登陆
function load1() {
    $("txtName").focus();
}
function scrCode() {
    $("imgCode").src = 'PassCode.aspx';
}
function rest() {
    $("txtName").value = "";
    $("txtPwd").value = "";
    $("txtCode").value = "";
    $("imgCode").src = 'PassCode.aspx';

}
function KeyDown() {
    var gk = event.keyCode;
    if (gk == 13) {
        event.keyCode = 9;
        return;
    }
}
function KeyDown1() {
    var gk = event.keyCode;
    if (gk == 13) {
        getlogin();
    }
}


function getlogin() {

    if ($F("txtUserName") == "") {
        return alertmsg('用户名不能为空,请输入用户名！', '', false);
    }
    else if ($("txtPassWord").value == "") {
        return alertmsg('密码不能为空,请输入密码！', '', false);
    }
    else if ($("txtCode").value == "") {
        return alertmsg('请输入验证玛！', '', false);
    }
    else {
        return true;
    }
}


//发送电子邮件
function EmailAdd() {
    if ($("lbtitle").value == "") {
        return alertmsg('标题必须填写！', '', false);
    }
    if ($("lbcontent").value.length < 0) {
        return alertmsg('内容必须填写！', '', false);
    }
}
function search() {
    if ($("TextBox1").value == "") {
        return alertmsg('请输入公司名称！', '', false);
    }
}


//充值信息
function getinputmoney() {
    //    if ($("ddlRose").value == "-1") {
    //        return alertmsg('请选择充值方式', '', false)
    //    }
    //    if ($("dfinance").value == "-1") {
    //        return alertmsg('请选择财务类别', '', false)
    //    }
    if ($("txtmoney").value == "") {
        return alertmsg('请输入充值金额', '', false)
    }
    else {
        IsFloat($("txtmoney"))
    }

}

function IsFloat(obj) {
    var tempValue = obj.value.replace(/(^\s+)|(\s+$)/g, '');
    if (!tempValue)
    { return false }
    if (/^-?\d+(\.\d+)?$/.test(tempValue)) {
        obj.value = parseFloat(tempValue).toFixed(2);
    }
    else {
        $("tbbaseprice").value = "";
        $("tbbaseprice").focus();
        return alertmsg('请输入合法的浮点数.', '', false);
    }
}

//修改邮件信息
function EditEmail() {
    if ($("lbtitle").value == "") {
        return alertmsg('请输入标题信息！', '', false);
    }
    if ($("lbcontent").value.length < 0) {
        return alertmsg('请输入内容信息！', '', false);
    }
}
/**
 
=====================================功能菜单 开始================================================
**/
function menuchange(num) {
    var left = window.parent.left.document;

    switch (num) {
        case 1:
            $("basic").className = "on";
            $("business").className = "";
            $("news").className = "";
            $("users").className = "";
            $("templte").className = "";
            $("advance").className = "";
            $("tools").className = "";
            left.getElementById("basic").style.display = "block";
            left.getElementById("business").style.display = "none";
            left.getElementById("news").style.display = "none";
            left.getElementById("users").style.display = "none";
            left.getElementById("templte").style.display = "none";
            left.getElementById("advance").style.display = "none";
            left.getElementById("tools").style.display = "none";
            break;
        case 2:
            $("basic").className = "";
            $("business").className = "on";
            $("news").className = "";
            $("users").className = "";
            $("templte").className = "";
            $("advance").className = "";
            $("tools").className = "";
            left.getElementById("basic").style.display = "none";
            left.getElementById("business").style.display = "block";
            left.getElementById("news").style.display = "none";
            left.getElementById("users").style.display = "none";
            left.getElementById("templte").style.display = "none";
            left.getElementById("advance").style.display = "none";
            left.getElementById("tools").style.display = "none";
            break;
        case 3:
            $("basic").className = "";
            $("business").className = "";
            $("news").className = "on";
            $("users").className = "";
            $("templte").className = "";
            $("advance").className = "";
            $("tools").className = "";
            left.getElementById("basic").style.display = "none";
            left.getElementById("business").style.display = "none";
            left.getElementById("news").style.display = "block";
            left.getElementById("users").style.display = "none";
            left.getElementById("templte").style.display = "none";
            left.getElementById("advance").style.display = "none";
            left.getElementById("tools").style.display = "none";
            break;
        case 4:
            $("basic").className = "";
            $("business").className = "";
            $("news").className = "";
            $("users").className = "on";
            $("templte").className = "";
            $("advance").className = "";
            $("tools").className = "";
            left.getElementById("basic").style.display = "none";
            left.getElementById("business").style.display = "none";
            left.getElementById("news").style.display = "none";
            left.getElementById("users").style.display = "block";
            left.getElementById("templte").style.display = "none";
            left.getElementById("advance").style.display = "none";
            left.getElementById("tools").style.display = "none";
            break;
        case 5:
            $("basic").className = "";
            $("business").className = "";
            $("news").className = "";
            $("users").className = "";
            $("templte").className = "on";
            $("advance").className = "";
            $("tools").className = "";
            left.getElementById("basic").style.display = "none";
            left.getElementById("business").style.display = "none";
            left.getElementById("news").style.display = "none";
            left.getElementById("users").style.display = "none";
            left.getElementById("templte").style.display = "block";
            left.getElementById("advance").style.display = "none";
            left.getElementById("tools").style.display = "none";
            break;
        case 6:
            $("basic").className = "";
            $("business").className = "";
            $("news").className = "";
            $("users").className = "";
            $("templte").className = "";
            $("advance").className = "on";
            $("tools").className = "";
            left.getElementById("basic").style.display = "none";
            left.getElementById("business").style.display = "none";
            left.getElementById("news").style.display = "none";
            left.getElementById("users").style.display = "none";
            left.getElementById("templte").style.display = "none";
            left.getElementById("advance").style.display = "block";
            left.getElementById("tools").style.display = "none";
            break;
        case 7:
            $("basic").className = "";
            $("business").className = "";
            $("news").className = "";
            $("users").className = "";
            $("templte").className = "";
            $("advance").className = "";
            $("tools").className = "on";
            left.getElementById("basic").style.display = "none";
            left.getElementById("business").style.display = "none";
            left.getElementById("news").style.display = "none";
            left.getElementById("users").style.display = "none";
            left.getElementById("templte").style.display = "none";
            left.getElementById("advance").style.display = "none";
            left.getElementById("tools").style.display = "block";
            break;
    }
}

/**
=====================================功能菜单 结束================================================
**/



/**
=====================================自定义字段 开始================================================
**/

function FiledSelTop(ckobj, typeID, showDiv) {
    if (ckobj.checked) {
        $(showDiv).innerHTML = "";
        $(showDiv).style.display = "none";
        return true;
    }
    if ("" == $F(typeID) || "0" == $F(typeID)) {
        sAlert("请先选择类别");
        return false;
    }
    var ajax = new Ajax("xy037", "&typeid=" + $F(typeID) + "&modulename=" + $F("ddlmodule"))
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            $(showDiv).style.display = "block";
            if (ajax.data) {
                var html = "请选择要继承的字段：<br /><ul>";
                for (var i = 0; i < ajax.data.filedItem.length; i++) {
                    html += "<li><input type=\"checkbox\" id=\"topfiled" + i + "\" name=\"topfiled\" value=\"" + ajax.data.filedItem[i].id + "\" /><label for=\"topfiled" + i + "\">" + ajax.data.filedItem[i].name + "</label></li>";
                }
                html += "</ul>";
                $(showDiv).innerHTML = html;
            }
            else {
                $(showDiv).innerHTML = "没有需要继承的字段";
            }
        }
        else {
            sAlert("顶级类不需要继承！");
            ckobj.checked = true;
            $(showDiv).innerHTML = "";
            $(showDiv).style.display = "none";
        }
    }
}

var addnum = 1;
var htmlArray = new Array();

function addline() {
    htmlArray[0] = '<td><input  size="16"  id="txtEName' + addnum + '" title="" name="txtEName" type="text" value="" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emEName' + addnum + '" style="display:none;">↑字段英文名</em></td> ';
    htmlArray[1] = '<td><input  size="16"  id="txtCName' + addnum + '" title="" name="txtCName" type="text" value="" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emCName' + addnum + '" style="display:none;">↑字段中文名</em></td>';
    htmlArray[2] = '<td><textarea name="txtdesp" cols="19" rows="1" id="txtdesp' + addnum + '" title="" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" ></textarea><em id="emdesp' + addnum + '" style="display:none;">↑字段说明文字</em></td>';
    htmlArray[3] = '<td><select name="seltype"><option selected="selected" value="Text" >文本框</option><option value="Textarea"> 多行文本区 </option><option value="Select">下拉框</option><option value="Radio">单选框</option><option value="Checkbox">复选框</option></select></td>';
    htmlArray[4] = '<td><textarea name="txtselect" cols="19" rows="1" id="txtselect' + addnum + '" title="" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" ></textarea><em id="emselect' + addnum + '" style="display:none;">↑字段预留值</em></td>';
    htmlArray[5] = '<td><input  size="16"  id="txtFieldSize' + addnum + '" title="" name="txtFieldSize" type="text" value="50" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emFieldSize' + addnum + '" style="display:none;">↑字段大小，小于8000</em></td> ';
    //htmlArray[5]='<td><input id="chkbunique'+addnum+'" type="checkbox"  onclick="checkonclick(\'unique\',\'unique'+addnum+'\',this);" /><span id="unique'+addnum+'">重复</span> <input id="chkbnull'+addnum+'" type="checkbox"  onclick="checkonclick(\'null\',\'null'+addnum+'\',this);"  /><span id="null'+addnum+'">选填</span> <input id="chkbtag'+addnum+'" type="checkbox"  onclick="checkonclick(\'tag\',\'tag'+addnum+'\',this);"  /><span id="tag'+addnum+'">一般</span></td>';
    htmlArray[6] = '<td><img src="../images/fielddel.gif" alt="删除" name="imgdelete" onclick="deleteline(this);" /></td>';

    var table = document.all.productfield;
    var newRow = table.insertRow();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    for (var i = 0; i < newRow.cells.length; i++) {
        newRow.cells[i].innerHTML = htmlArray[i];
    }
    addnum++;
}


function deleteline(obj) {
    var chks = document.getElementsByName("imgdelete");
    if (chks.length == 0) { alert("没有可以删除的行!"); return; }
    var rowindex = -1;
    for (var i = 0; i < chks.length; i++) {
        if (chks[i] == obj) { rowindex = i; }
    }
    if (rowindex < 0) { alert("没有选择要删除的行!"); return; }
    if (rowindex == 0) { alertmsg("该行不能删除！", '', false); }
    else if (confirm("真的要删除第" + eval(rowindex + 1) + "行吗?"))
    { document.all.productfield.deleteRow(rowindex); }
}

function addFiled() {
    if ($("typeids").value != undefined && $("typeids").value != "") {
        $("hidPT_ID").value = $("typeids").value;
    }
    if ($("hidPT_ID").value == "") {
        return alertmsg("请选择产品分类！", "", false);
    }
    else {


        var input = document.getElementsByTagName("input");
        for (var i = 0; i < input.length; i++) {
            if (input[i].type == 'checkbox') {
                if (input[i].id.indexOf('chkbunique') > -1) {
                    if (input[i].checked == true) {
                        $("hidUnique").value += ",1";
                    }
                    else {
                        $("hidUnique").value += ",0";
                    }
                }
                else if (input[i].id.indexOf('chkbnull') > -1) {
                    if (input[i].checked == true) {
                        $("hidNull").value += ",1";
                    }
                    else {
                        $("hidNull").value += ",0";
                    }
                }
                else if (input[i].id.indexOf('chkbtag') > -1) {
                    if (input[i].checked == true) {
                        $("hidTag").value += ",1";
                    }
                    else {
                        $("hidTag").value += ",0";
                    }
                }
            }
        }
        return true;
    }
}

function checkonclick(type, name, obj) {

    switch (type) {
        case "unique":
            if (obj.checked == true)
                $(name).innerHTML = "唯一";
            else
                $(name).innerHTML = "重复";
            break;
        case "null":
            if (obj.checked == true)
                $(name).innerHTML = "必填";
            else
                $(name).innerHTML = "选填";
            break;
        case "tag":
            if (obj.checked == true)
                $(name).innerHTML = "标签";
            else
                $(name).innerHTML = "一般";
            break;
    }
}

//获取焦点提示信息
function focusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);
    $(enname).style.display = "block";
}
//失去焦点提示信息
function unfocusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);

    $(enname).style.display = "none";
}

//获取焦点提示信息
function tafocusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);
    obj.rows = 5;
    $(enname).style.display = "block";
}
//失去焦点提示信息
function taunfocusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);
    obj.rows = 1;
    $(enname).style.display = "none";
}

//修改初始化
function pinitline() {

    var lines = $("hidline").value.split('|');


    addnum = 1;
    var table = document.all.productfield;
    for (var j = 0; j < lines.length; j++) {
        var newRow = table.insertRow();
        newRow.insertCell();
        newRow.insertCell();
        newRow.insertCell();
        newRow.insertCell();
        newRow.insertCell();
        newRow.insertCell();
        newRow.insertCell();
        var cells = lines[j].split('$');
        for (var i = 0; i < newRow.cells.length; i++) {

            newRow.cells[i].innerHTML = cells[i];
        }
        addnum++;
    }

}
function pinitaddline() {
    var url = "GetLine.aspx?PT_ID=" + $("hidPT_ID").value;

    var XMLDoc1 = new XMLHttpObject(url, false);
    XMLDoc1.sendData();
    var msg = XMLDoc1.getText();
    var lines = msg.split('|');

    var table = document.all.productfield;
    for (var j = 0; j < lines.length; j++) {
        if (j == 0) {
            var values = lines[j].split('$');
            $("txtEName0").value = values[0];
            $("txtCName0").value = values[1];
            $("txtdesp0").value = values[2];
            $("seltype0").value = values[3];
            $("txtselect0").value = values[4];
            if (values[5] == "true") {
                $("chkbunique0").checked = true;
            }
            if (values[6] == "true") {
                $("chkbnull0").checked = true;
            }
            if (values[7] == "true") {
                $("chkbtag0").checked = true;
            }

        }
        else {
            var newRow = table.insertRow();
            newRow.insertCell();
            newRow.insertCell();
            newRow.insertCell();
            newRow.insertCell();
            newRow.insertCell();
            newRow.insertCell();
            newRow.insertCell();

            var cells = lines[j].split('$');
            for (var i = 0; i < newRow.cells.length; i++) {
                newRow.cells[i].innerHTML = cells[i];
            }
            addnum++;
        }
    }
}


//选择模块获取该模块信息类别
function selectmodule() {
    var moduleName = $F("ddlmodule");
    var arr = new Array("supply", "venture", "business", "service", "show");
    for (var i = 0; i < arr.length; i++) {
        $(arr[i]).style.display = "none";
    }
    switch (moduleName) {
        case "offer":
            $("supply").style.display = "block";
            break;
        case "venture":
            $("venture").style.display = "block";
            break;
        case "investment":
            $("business").style.display = "block";
            break;
        case "service":
            $("service").style.display = "block";
            break;
        case "exhibition":
            $("show").style.display = "block";
            break;
    }
}
/**
=====================================自定义字段 结束================================================
**/

/**
=====================================关键字信息添加与修改 开始================================================
**/
function GetKeyword() {
    var temp = $("KIID").value;
    if (temp == 0) {
        $("add").style.display = "none";
        $("update").style.display = "none";
    }
    else if (temp < 0) {
        $("update").style.display = "none";
        $("add").style.display = "block";
    }
    else {
        $("update").style.display = "block";
        $("add").style.display = "none";
    }
}

function quitadd() {
    $("KIID").value = 0;
    $("add").style.display = "none";
}

function quitupdate() {
    $("KIID").value = 0;
    $("update").style.display = "none";
}

function AddKeyword() {
    $("add").style.display = "block";
    window.location.href = "#addtable";
}

/**
=====================================关键字信息添加与修改 结束================================================
**/

/**
===================================== 诚信指数设置 开始================================================
**/
function faithset() {
    if ($("tbbase").value == "") {
        return alertmsg('请初始完成基本资料后诚信指数增加值！', '', false);
    }
    else if ($("tbbase").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('初始的诚信指数应为整数！', '', false);
    }

    if ($("gfaith").value == "") {
        return alertmsg('请填写个人资料恶意填写处罚扣的诚信指数！', '', false);
    }
    else if ($("gfaith").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("gfaithuu").value == "") {
        return alertmsg('请填写个人资料恶意填写处罚扣的UU币！', '', false);
    }
    else if ($("gfaithuu").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('UU币为整数！', '', false);
    }

    if ($("gerrfaith").value == "") {
        return alertmsg('请填写个人资料普通错误处罚扣的诚信指数！', '', false);
    }
    else if ($("gerrfaith").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("gerrfaithuu").value == "") {
        return alertmsg('请填写个人资料普通错误处罚扣的UU币！', '', false);
    }
    else if ($("gerrfaithuu").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('UU币为整数！', '', false);
    }

    if ($("tbhot").value == "") {
        return alertmsg('请初始完成高级资料后诚信指数增加值！', '', false);
    }
    else if ($("tbhot").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('初始的诚信指数应为整数！', '', false);
    }

    if ($("hfaith").value != "") {
        if ($("hfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("hfaithuu").value != "") {
        if ($("hfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU币为整数！', '', false);
    }

    if ($("herrfaith").value != "") {
        if ($("herrfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("herrfaithuu").value != "") {
        if ($("herrfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU币为整数！', '', false);
    }

    if ($("tblicence").value == "") {
        return alertmsg('请初始上传营业执照后诚信指数增加值！', '', false);
    }
    else if ($("tblicence").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('初始的诚信指数应为整数！', '', false);
    }

    if ($("tbcertificate").value == "") {
        return alertmsg('请初始上传其他资质证书后诚信指数增加值！', '', false);
    }
    else if ($("tbcertificate").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('初始的诚信指数应为整数！', '', false);
    }

    if ($("userfaith").value != "") {
        if ($("userfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("userfaithuu").value != "") {
        if ($("userfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU币为整数！', '', false);
    }

    if ($("usererrfaith").value != "") {
        if ($("usererrfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("usererrfaithuu").value != "") {
        if ($("usererrfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU币为整数！', '', false);
    }

    if ($("businessfaith").value != "") {
        if ($("businessfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("businessfaithuu").value != "") {
        if ($("businessfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU币为整数！', '', false);
    }

    if ($("businesserrfaith").value != "") {
        if ($("businesserrfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('诚信指数为整数！', '', false);
    }

    if ($("businesserrfaithuu").value != "") {
        if ($("businesserrfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU币为整数！', '', false);
    }
}
/**
===================================== 诚信指数设置 结束================================================
**/
//管理员给用户回复留言
function adminmessage() {
    if ($("title").value == "") {
        return alertmsg('请输入回复标题！', '', false);
    }
    if ($("content").value == "") {
        return alertmsg('请输入回复内容！', '', false);
    }
}



//管理员给用户留言
function messageadd() {
    var lbcontent = FCKeditorAPI.GetInstance('lbcontent').GetXHTML(true);
    if (lbcontent == "") {
        return alertmsg('请输入内容', '', false);
    }
    if ($("lbtitle").value == "") {
        return alertmsg('请输入标题！', '', false);
    }
    if ($("lbcontent").value.length > 4000) {
        return alertmsg('内容长度超出范围！', '', false);
    }

}
//添加省份
function ProvinceAdd() {
    if ($("txtName").value == "") {
        return alertmsg('请输入省份名称！', '', false);
    }
}



//修改省份
function ProvinceUpdate() {
    if ($("txtYuanPwd").value == "") {
        return alertmsg('请输入省份名称！', '', false);
    }
}

/*******************  自定义模块相关 **************************/


function AddInfoType() {
    var i = Number(document.getElementById("InfoTypeTotal").value);
    i++;
    var string = new Array();

    string[0] = '<input type="text" id="tbid' + i + '" class="m_i" runat="server" readonly="readonly" value="' + i + '"/>';
    string[1] = '<input type="text" id="tbprefix' + i + '" name="tbprefix' + i + '"/>';
    string[2] = '<input type="text" id="tbpostfix' + i + '" name="tbpostfix' + i + '"/>';
    string[3] = '<input type="radio" name="rb' + i + '" value="sell" checked="checked" onclick="SetInfoTypeValue(' + i + ');"/>供&nbsp;<input type="radio" name="rb' + i + '" value="buy" onclick="SetInfoTypeValue(' + i + ');"/>求<input type="hidden" id="hidInfoType_' + i + '" name="hidInfoType_' + i + '" value="sell" />';
    string[4] = '<a href="javascript:void(null);" onclick="DeleteInfoType(' + i + ');"><img src="../images/delete1.gif" alt="删除"/></a>';

    var table = document.getElementById("TableInfoType");
    var newRow = table.insertRow();
    newRow.id = "tr" + i;
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();

    for (var m = 0; m < 5; m++) {
        if (m == 4) {
            newRow.cells[m].id = "tdDel_" + i;
            newRow.cells[m].style.display = "";
        }

        newRow.cells[m].innerHTML = string[m];
    }

    if ((i - 1) > 1)
        document.getElementById("tdDel_" + (i - 1)).style.display = "none";


    document.getElementById("InfoTypeTotal").value = i;
}


function DeleteInfoType(num) {
    var i = Number(document.getElementById("InfoTypeTotal").value);
    i--;

    var table = document.getElementById("TableInfoType");

    table.deleteRow(num);

    if (i != 1) document.getElementById("tdDel_" + i).style.display = "";

    document.getElementById("InfoTypeTotal").value = i;
}

function SetInfoTypeValue(index) {
    var eles = document.getElementsByName("rb" + index);

    for (i = 0; i < eles.length; i++) {
        if (eles[i].checked) {
            document.getElementById("hidInfoType_" + index).value = eles[i].value;
        }
    }
}

//2008-11-5 后台编辑信息选择类别更新自定义方法
var isconfirm = false;
function SelectTypeIDOnClick() {
    if (!isconfirm) {
        if (window.confirm("如果修改信息类别，原有的自定义字段数据将丢失！\n是否继续修改？")) {
            isconfirm = true;
        }
        else {
            return false;
        }
    }
    return true;
}
function SelectTypeIDOnChange() {
    var ajax = new Ajax("XY032", "&module=" + this.ModuleName + "&typeid=" + $F(this.InputTxtID));
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            document.getElementById("tabFieldBody").innerHTML = "<table>" + unescape(ajax.data.html) + "</table>";
        }
    }
}



/*********************后台发送短信*****************************/

function person() {
    document.getElementById("b23").style.display = "";
    document.getElementById("b22").style.display = "none";
    document.getElementById("lic").className = "usertype";
    document.getElementById("lip").className = "cur_usertype";
    //rbt1();
    // rbt2();
}

function company() {
    document.getElementById("b22").style.display = "";
    document.getElementById("b23").style.display = "none";
    document.getElementById("lic").className = "cur_usertype";
    document.getElementById("lip").className = "usertype";
    //per();
}

function rbtchanage(str) {
    if (str == 0) {
        document.getElementById("panugp").style.display = "";
        document.getElementById("pansearch").style.display = "none";
        document.getElementById("rbtugp").checked = true;
        rbt1();
    }
    if (str == 1) {
        document.getElementById("panugp").style.display = "none";
        document.getElementById("pansearch").style.display = "";
        document.getElementById("rbtsearch").checked = true;
        rbt2();
    }

}

function rbtchanageperson(str) {
    if (str == 0) {
        document.getElementById("personserach").style.display = "none";
        document.getElementById("Radio1").checked = true;
        document.getElementById("personall").value = 1;
    }
    if (str == 1) {
        document.getElementById("personserach").style.display = "";
        document.getElementById("Radio2").checked = true;
        document.getElementById("personall").value = 0;
    }

}

function rbt1() {
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport1') > -1) {
                chkother[i].checked = false;
            }
        }
    }
}

function rbt2() {
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('CBL') > -1) {
                chkother[i].checked = false;
            }
        }
    }
}

function per() {
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                chkother[i].checked = false;
            }
        }
    }
}

function CheckSelectClassNumber() {
    var arr = $("pnlSuperClass").getElementsByTagName("input");
    var strid = "";
    var nonum = 0;
    for (var i = 0; i < arr.length; i++) {
        //if(arr[i].type=='checkbox') 
        if (arr[i].type == 'radio') {
            if (arr[i].checked) {
                nonum = 1;
                strid = arr[i].value;
            }
        }
    }
    if (nonum == 0) {
        sAlert("请选择一个要转移到的分类！");
        return false;
    }
    $("hidptid").value = strid;
}

//改变多行文本框的行数
//eleId:元素Id
//action:操作标识 add:加,sub：减
//maxRow:最大行数
//minRow:最小行数
//step:步长，即每次改变的行数
function ChangeTextRow(eleId, action, maxRow, minRow, step) {
    var ele = document.getElementById(eleId);

    if (!ele) return;

    if (action == "add") {
        if (ele.rows < maxRow) {
            ele.rows = ele.rows + step;
        }
    }

    if (action == "sub") {
        if (ele.rows > minRow) {
            ele.rows = ele.rows - step;
        }
    }
}

//GridView行目标移上事件
//tc 09-02-18
function __XY_GV_Row_MouseOver(obj) {
    //var tds = obj.childNodes;
    var tds = obj.getElementsByTagName("td");
    for (i = 0; i < tds.length; i++) {
        tds[i].style.backgroundColor = "#deeffa";
    }
}
//GridView行目标移走事件
//tc 09-02-18
function __XY_GV_Row_MouseOut(obj) {
    var tds = obj.getElementsByTagName("td");
    for (i = 0; i < tds.length; i++) {
        tds[i].style.backgroundColor = "#ffffff";
    }
}


//投票选项选项相关
function AddPollOption() {
    var i = Number(document.getElementById("OptionTotal").value);
    i++;
    var string = new Array();

    string[0] = '' + i + '.';
    string[1] = '<textarea name="option' + i + '" rows="2" cols="60"></textarea>';
    string[2] = '<a href="javascript:void(null);" onclick="DeletePollOption(' + i + ');"><img src="../images/delete1.gif" alt="删除"/></a>';

    var table = document.getElementById("tablePollOption");
    var newRow = table.insertRow();
    newRow.id = "tr" + i;
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();


    for (var m = 0; m < 3; m++) {
        if (m == 2) {
            newRow.cells[m].id = "tdDel_" + i;
            newRow.cells[m].style.display = "";
        }

        newRow.cells[m].innerHTML = string[m];
    }

    if ((i - 1) > 1)
        document.getElementById("tdDel_" + (i - 1)).style.display = "none";

    document.getElementById("OptionTotal").value = i;
}

function DeletePollOption(num) {
    var i = Number(document.getElementById("OptionTotal").value);
    i--;

    var table = document.getElementById("tablePollOption");

    table.deleteRow(num - 1);

    if (i != 1) document.getElementById("tdDel_" + i).style.display = "";

    document.getElementById("OptionTotal").value = i;
}


//记录删除选项的Id，以便提交后在服务器端进行数据库删除
function DeleteServerOption(optionId) {
    if (optionId == "") return;

    var ids = document.getElementById("DelOptionIds").value;

    if (ids == "")
        ids = optionId;
    else
        ids = ids + "," + optionId;

    document.getElementById("DelOptionIds").value = ids;
}










//新闻附件选项相关
function AddFileOption() {
    var i = Number(document.getElementById("OptionTotal").value);
    i++;
    var string = new Array();
    string[0] = '<input text name="filename' + i + '" value="附件' + i + '" size="20"><input text name="option' + i + '" size="45">';
    string[1] = '<a href="javascript:void(null);" onclick="DeletePollOption(' + i + ');"><img src="../images/delete1.gif" alt="删除"/></a>';

    var table = document.getElementById("tableFileOption");
    var newRow = table.insertRow();
    newRow.id = "tr" + i;
    newRow.insertCell();
    newRow.insertCell();
    newRow.insertCell();


    for (var m = 0; m < 2; m++) {
        if (m == 1) {
            newRow.cells[m].id = "tdDel_" + i;
            newRow.cells[m].style.display = "";
        }

        newRow.cells[m].innerHTML = string[m];
    }

    if ((i - 1) > 1)
        document.getElementById("tdDel_" + (i - 1)).style.display = "none";

    document.getElementById("OptionTotal").value = i;
}

function DeletePollOption(num) {
    var i = Number(document.getElementById("OptionTotal").value);
    i--;

    var table = document.getElementById("tableFileOption");

    table.deleteRow(num - 1);

    if (i != 1) document.getElementById("tdDel_" + i).style.display = "";

    document.getElementById("OptionTotal").value = i;
}




/**
=====================================汉字转拼音 结束================================================
**/
var spell = { 0xB0A1: "a", 0xB0A3: "ai", 0xB0B0: "an", 0xB0B9: "ang", 0xB0BC: "ao", 0xB0C5: "ba", 0xB0D7: "bai", 0xB0DF: "ban", 0xB0EE: "bang", 0xB0FA: "bao", 0xB1AD: "bei", 0xB1BC: "ben", 0xB1C0: "beng", 0xB1C6: "bi", 0xB1DE: "bian", 0xB1EA: "biao", 0xB1EE: "bie", 0xB1F2: "bin", 0xB1F8: "bing", 0xB2A3: "bo", 0xB2B8: "bu", 0xB2C1: "ca", 0xB2C2: "cai", 0xB2CD: "can", 0xB2D4: "cang", 0xB2D9: "cao", 0xB2DE: "ce", 0xB2E3: "ceng", 0xB2E5: "cha", 0xB2F0: "chai", 0xB2F3: "chan", 0xB2FD: "chang", 0xB3AC: "chao", 0xB3B5: "che", 0xB3BB: "chen", 0xB3C5: "cheng", 0xB3D4: "chi", 0xB3E4: "chong", 0xB3E9: "chou", 0xB3F5: "chu", 0xB4A7: "chuai", 0xB4A8: "chuan", 0xB4AF: "chuang", 0xB4B5: "chui", 0xB4BA: "chun", 0xB4C1: "chuo", 0xB4C3: "ci", 0xB4CF: "cong", 0xB4D5: "cou", 0xB4D6: "cu", 0xB4DA: "cuan", 0xB4DD: "cui", 0xB4E5: "cun", 0xB4E8: "cuo", 0xB4EE: "da", 0xB4F4: "dai", 0xB5A2: "dan", 0xB5B1: "dang", 0xB5B6: "dao", 0xB5C2: "de", 0xB5C5: "deng", 0xB5CC: "di", 0xB5DF: "dian", 0xB5EF: "diao", 0xB5F8: "die", 0xB6A1: "ding", 0xB6AA: "diu", 0xB6AB: "dong", 0xB6B5: "dou", 0xB6BC: "du", 0xB6CB: "duan", 0xB6D1: "dui", 0xB6D5: "dun", 0xB6DE: "duo", 0xB6EA: "e", 0xB6F7: "en", 0xB6F8: "er", 0xB7A2: "fa", 0xB7AA: "fan", 0xB7BB: "fang", 0xB7C6: "fei", 0xB7D2: "fen", 0xB7E1: "feng", 0xB7F0: "fo", 0xB7F1: "fou", 0xB7F2: "fu", 0xB8C1: "ga", 0xB8C3: "gai", 0xB8C9: "gan", 0xB8D4: "gang", 0xB8DD: "gao", 0xB8E7: "ge", 0xB8F8: "gei", 0xB8F9: "gen", 0xB8FB: "geng", 0xB9A4: "gong", 0xB9B3: "gou", 0xB9BC: "gu", 0xB9CE: "gua", 0xB9D4: "guai", 0xB9D7: "guan", 0xB9E2: "guang", 0xB9E5: "gui", 0xB9F5: "gun", 0xB9F8: "guo", 0xB9FE: "ha", 0xBAA1: "hai", 0xBAA8: "han", 0xBABB: "hang", 0xBABE: "hao", 0xBAC7: "he", 0xBAD9: "hei", 0xBADB: "hen", 0xBADF: "heng", 0xBAE4: "hong", 0xBAED: "hou", 0xBAF4: "hu", 0xBBA8: "hua", 0xBBB1: "huai", 0xBBB6: "huan", 0xBBC4: "huang", 0xBBD2: "hui", 0xBBE7: "hun", 0xBBED: "huo", 0xBBF7: "ji", 0xBCCE: "jia", 0xBCDF: "jian", 0xBDA9: "jiang", 0xBDB6: "jiao", 0xBDD2: "jie", 0xBDED: "jin", 0xBEA3: "jing", 0xBEBC: "jiong", 0xBEBE: "jiu", 0xBECF: "ju", 0xBEE8: "juan", 0xBEEF: "jue", 0xBEF9: "jun", 0xBFA6: "ka", 0xBFAA: "kai", 0xBFAF: "kan", 0xBFB5: "kang", 0xBFBC: "kao", 0xBFC0: "ke", 0xBFCF: "ken", 0xBFD3: "keng", 0xBFD5: "kong", 0xBFD9: "kou", 0xBFDD: "ku", 0xBFE4: "kua", 0xBFE9: "kuai", 0xBFED: "kuan", 0xBFEF: "kuang", 0xBFF7: "kui", 0xC0A4: "kun", 0xC0A8: "kuo", 0xC0AC: "la", 0xC0B3: "lai", 0xC0B6: "lan", 0xC0C5: "lang", 0xC0CC: "lao", 0xC0D5: "le", 0xC0D7: "lei", 0xC0E2: "leng", 0xC0E5: "li", 0xC1A9: "lia", 0xC1AA: "lian", 0xC1B8: "liang", 0xC1C3: "liao", 0xC1D0: "lie", 0xC1D5: "lin", 0xC1E1: "ling", 0xC1EF: "liu", 0xC1FA: "long", 0xC2A5: "lou", 0xC2AB: "lu", 0xC2BF: "lv", 0xC2CD: "luan", 0xC2D3: "lue", 0xC2D5: "lun", 0xC2DC: "luo", 0xC2E8: "ma", 0xC2F1: "mai", 0xC2F7: "man", 0xC3A2: "mang", 0xC3A8: "mao", 0xC3B4: "me", 0xC3B5: "mei", 0xC3C5: "men", 0xC3C8: "meng", 0xC3D0: "mi", 0xC3DE: "mian", 0xC3E7: "miao", 0xC3EF: "mie", 0xC3F1: "min", 0xC3F7: "ming", 0xC3FD: "miu", 0xC3FE: "mo", 0xC4B1: "mou", 0xC4B4: "mu", 0xC4C3: "na", 0xC4CA: "nai", 0xC4CF: "nan", 0xC4D2: "nang", 0xC4D3: "nao", 0xC4D8: "ne", 0xC4D9: "nei", 0xC4DB: "nen", 0xC4DC: "neng", 0xC4DD: "ni", 0xC4E8: "nian", 0xC4EF: "niang", 0xC4F1: "niao", 0xC4F3: "nie", 0xC4FA: "nin", 0xC4FB: "ning", 0xC5A3: "niu", 0xC5A7: "nong", 0xC5AB: "nu", 0xC5AE: "nv", 0xC5AF: "nuan", 0xC5B0: "nue", 0xC5B2: "nuo", 0xC5B6: "o", 0xC5B7: "ou", 0xC5BE: "pa", 0xC5C4: "pai", 0xC5CA: "pan", 0xC5D2: "pang", 0xC5D7: "pao", 0xC5DE: "pei", 0xC5E7: "pen", 0xC5E9: "peng", 0xC5F7: "pi", 0xC6AA: "pian", 0xC6AE: "piao", 0xC6B2: "pie", 0xC6B4: "pin", 0xC6B9: "ping", 0xC6C2: "po", 0xC6CB: "pu", 0xC6DA: "qi", 0xC6FE: "qia", 0xC7A3: "qian", 0xC7B9: "qiang", 0xC7C1: "qiao", 0xC7D0: "qie", 0xC7D5: "qin", 0xC7E0: "qing", 0xC7ED: "qiong", 0xC7EF: "qiu", 0xC7F7: "qu", 0xC8A6: "quan", 0xC8B1: "que", 0xC8B9: "qun", 0xC8BB: "ran", 0xC8BF: "rang", 0xC8C4: "rao", 0xC8C7: "re", 0xC8C9: "ren", 0xC8D3: "reng", 0xC8D5: "ri", 0xC8D6: "rong", 0xC8E0: "rou", 0xC8E3: "ru", 0xC8ED: "ruan", 0xC8EF: "rui", 0xC8F2: "run", 0xC8F4: "ruo", 0xC8F6: "sa", 0xC8F9: "sai", 0xC8FD: "san", 0xC9A3: "sang", 0xC9A6: "sao", 0xC9AA: "se", 0xC9AD: "sen", 0xC9AE: "seng", 0xC9AF: "sha", 0xC9B8: "shai", 0xC9BA: "shan", 0xC9CA: "shang", 0xC9D2: "shao", 0xC9DD: "she", 0xC9E9: "shen", 0xC9F9: "sheng", 0xCAA6: "shi", 0xCAD5: "shou", 0xCADF: "shu", 0xCBA2: "shua", 0xCBA4: "shuai", 0xCBA8: "shuan", 0xCBAA: "shuang", 0xCBAD: "shui", 0xCBB1: "shun", 0xCBB5: "shuo", 0xCBB9: "si", 0xCBC9: "song", 0xCBD1: "sou", 0xCBD4: "su", 0xCBE1: "suan", 0xCBE4: "sui", 0xCBEF: "sun", 0xCBF2: "suo", 0xCBFA: "ta", 0xCCA5: "tai", 0xCCAE: "tan", 0xCCC0: "tang", 0xCCCD: "tao", 0xCCD8: "te", 0xCCD9: "teng", 0xCCDD: "ti", 0xCCEC: "tian", 0xCCF4: "tiao", 0xCCF9: "tie", 0xCCFC: "ting", 0xCDA8: "tong", 0xCDB5: "tou", 0xCDB9: "tu", 0xCDC4: "tuan", 0xCDC6: "tui", 0xCDCC: "tun", 0xCDCF: "tuo", 0xCDDA: "wa", 0xCDE1: "wai", 0xCDE3: "wan", 0xCDF4: "wang", 0xCDFE: "wei", 0xCEC1: "wen", 0xCECB: "weng", 0xCECE: "wo", 0xCED7: "wu", 0xCEF4: "xi", 0xCFB9: "xia", 0xCFC6: "xian", 0xCFE0: "xiang", 0xCFF4: "xiao", 0xD0A8: "xie", 0xD0BD: "xin", 0xD0C7: "xing", 0xD0D6: "xiong", 0xD0DD: "xiu", 0xD0E6: "xu", 0xD0F9: "xuan", 0xD1A5: "xue", 0xD1AB: "xun", 0xD1B9: "ya", 0xD1C9: "yan", 0xD1EA: "yang", 0xD1FB: "yao", 0xD2AC: "ye", 0xD2BB: "yi", 0xD2F0: "yin", 0xD3A2: "ying", 0xD3B4: "yo", 0xD3B5: "yong", 0xD3C4: "you", 0xD3D9: "yu", 0xD4A7: "yuan", 0xD4BB: "yue", 0xD4C5: "yun", 0xD4D1: "za", 0xD4D4: "zai", 0xD4DB: "zan", 0xD4DF: "zang", 0xD4E2: "zao", 0xD4F0: "ze", 0xD4F4: "zei", 0xD4F5: "zen", 0xD4F6: "zeng", 0xD4FA: "zha", 0xD5AA: "zhai", 0xD5B0: "zhan", 0xD5C1: "zhang", 0xD5D0: "zhao", 0xD5DA: "zhe", 0xD5E4: "zhen", 0xD5F4: "zheng", 0xD6A5: "zhi", 0xD6D0: "zhong", 0xD6DB: "zhou", 0xD6E9: "zhu", 0xD7A5: "zhua", 0xD7A7: "zhuai", 0xD7A8: "zhuan", 0xD7AE: "zhuang", 0xD7B5: "zhui", 0xD7BB: "zhun", 0xD7BD: "zhuo", 0xD7C8: "zi", 0xD7D7: "zong", 0xD7DE: "zou", 0xD7E2: "zu", 0xD7EA: "zuan", 0xD7EC: "zui", 0xD7F0: "zun", 0xD7F2: "zuo" }

var spellArray = new Array()
var pn = ""

function Trim(info) { return info.replace(/(^\s*)|(\s*$)/g, ""); }

function isEnKong1(argValue) {
    var flag = false;
    var compStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    compStr += "1234567890"; //数字
    compStr += "!@#$%^&*()-+=|\{[}]:;'<,>.?/ "; //特殊字符
    var length = argValue.length;
    for (var iIndex = 0; iIndex < length; iIndex++) {
        var temp = compStr.indexOf(argValue.charAt(iIndex));
        if (temp == -1) {
            flag = false;
        }
        else {
            flag = true;
        }
    }
    return flag;
}

function pinyin(char) {
    if (!char.charCodeAt(0) || char.charCodeAt(0) < 1328)
        return char; //return '';过滤字符

    if (spellArray[char.charCodeAt(0)])
        return spellArray[char.charCodeAt(0)];

    ascCode = toAsc(char);
    ascCode = eval("0x" + ascCode);

    if (!(ascCode > 0xB0A0 && ascCode < 0xD7FC))
        return char; //return '';过滤字符

    for (var i = ascCode; (!spell[i] && i > 0); )
        i--;
    return spell[i];
}
//修改的方法
function pinyin_fan(char) {
    if (!char.charCodeAt(0) || char.charCodeAt(0) < 1328)
        return ''; //return char;
    if (spellArray[char.charCodeAt(0)])
        return spellArray[char.charCodeAt(0)];
    ascCode = toAsc(char);
    ascCode = eval("0x" + ascCode);
    if (!(ascCode > 0xB0A0 && ascCode < 0xD7FC))
        return ''; //return char;
    for (var i = ascCode; (!spell[i] && i > 0); )
        i--;
    return spell[i];
}

function toPinyin(str) {
    if (str) {
        var pStr = ""
        for (var i = 0; i < str.length; i++) {
            if (isEnKong1(str.charAt(i))) {
                pStr += str.charAt(i);
            }
            else {
                pStr += "" + pinyin(str.charAt(i));
            }
        }
        return Trim(pStr);
    }
}


//过滤特殊字符
function CheckIfEnglish(String) {
    var Letters = "!@#$%^&*()_+=|\{[}]:;'<>.?/、；,，‘“";
    var i;
    var c;
    var zhixing;
    if (String.charAt(0) == '-')
        return "";
    if (String.charAt(String.length - 1) == '-')
        return "";
    for (i = 0; i < String.length; i++) {
        c = String.charAt(i);
        if (Letters.indexOf(c) > 0) {
            if (c == "," || c == "，") {
                String = String.replace(c, ",");
                String = String.replace(c, ",");
            }
            else {
                String = String.replace(c, "_");
                String = String.replace(c, "_");
            }

        }

    }
    return String;
}



/**
=====================================汉字转拼音 开始================================================
**/


function myclick(id, eventName) {
    if (document.all) {
        document.getElementById(id).click();
    } else {
        var evt = document.createEvent("MouseEvents");
        evt.initEvent(eventName, true, true);
        document.getElementById(id).dispatchEvent(evt);
    }
}

function IsSelectInfo() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                }
            }
        }
    }

    if (j == 0) {
        sAlert("请至少选择一条记录！", "", true);
        return false;
    }
}