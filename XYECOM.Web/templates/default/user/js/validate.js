
//==========================================================================
//  公共方法 开始
//==========================================================================

function selectBox(k) {
    for (i = 1; i <= 2; i++) {
        if (i != k) {
            $("contentBox" + i).style.display = "none";

        }
    }
    $("contentBox" + k).style.display = "block";
    for (i = 1; i <= 2; i++) {
        if (k == i) {
            $("tab" + i).className = "on";
        } else {
            $("tab" + i).className = "off";
        }
    }
}

//给输入框和多选框加样式的js    
var isIE = navigator.userAgent.toLowerCase().indexOf('ie');

//添加Select选项
function addoption(obj) {
    if (obj.value == 'addoption') {
        var newOption = prompt('请输入:', '');
        if (newOption != null && newOption != '') {
            var newOptionTag = document.createElement('option');
            newOptionTag.text = newOption;
            newOptionTag.value = newOption;
            try {
                obj.add(newOptionTag, obj.options[0]); // doesn't work in IE
            }
            catch (ex) {
                obj.add(newOptionTag, obj.selecedIndex); // IE only
            }
            obj.value = newOption;
        } else {
            obj.value = obj.options[0].value;
        }
    }
}

//getElementsByTagNameS
function getElementsByTagNames(list, obj) {
    if (!obj) var obj = document;
    var tagNames = list.split(',');
    var resultArray = new Array();
    for (var i = 0; i < tagNames.length; i++) {
        var tags = obj.getElementsByTagName(tagNames[i]);
        for (var j = 0; j < tags.length; j++) {
            resultArray.push(tags[j]);
        }
    }
    var testNode = resultArray[0];
    if (!testNode) return [];
    if (testNode.sourceIndex) {
        resultArray.sort(function (a, b) {
            return a.sourceIndex - b.sourceIndex;
        });
    }
    else if (testNode.compareDocumentPosition) {
        resultArray.sort(function (a, b) {
            return 3 - (a.compareDocumentPosition(b) & 6);
        });
    }
    return resultArray;
}

//刷新
function resh(str) {
    var num = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].name.indexOf('sd_id') > -1) {
                if (chkother[i].checked == true) {
                    num++;
                }
            }
        }
    }
    if (num == 0) {
        if (str == 1) {
            return alertmsg(false, "最少要选择一条记录才能刷新！");
        }
        if (str == 2) {
            return alertmsg(false, "至少要选择一条记录才能暂停！");
        }
        if (str == 3) {
            return alertmsg(false, "至少要选择一条记录才能启用！");
        }
        if (str == 4) {
            return alertmsg(false, "至少要选择一条记录才能推荐！");
        }
    }
}
//重新发布
function setaddinfo() {
    var num = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].name.indexOf('sd_id') > -1) {
                if (chkother[i].checked == true) {
                    num++;
                }
            }
        }
    }
    if (num == 0) {
        return alertmsg(false, "至少要选择一条记录才能重发！");
    }

}
//删除
function bntDelete() {
    var num = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].name.indexOf('sd_id') > -1) {
                if (chkother[i].checked == true) {
                    num++;
                }
            }
        }
    }
    if (num == 0) {
        return alertmsg(false, "至少要选择一条记录才能删除！");
    }
    else if (!confirm('确定删除吗？')) {
        return false;
    }
    else {
        try {
            $("isDelete").value = "Delete";
            return true;
            //edit by liujia
        } catch (err) {
            return true;
        }
    }
}
function CheckedAll() {
    var chkall = document.getElementById("chkAll");
    var j = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('sd_id') > -1) {
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

//============================切换菜单 开始==============================================

function xy_Sel_CurTopMenu() {
    var menus = "_m_index,_m_quick,_m_msg,_m_userinfo,_m_safe";

    var aEles = menus.split(",");

    for (var i = 0; i < aEles.length; i++) {
        document.getElementById(aEles[i]).className = "nor";
    }

    var curPage = location.href;

    var index = curPage.lastIndexOf("/");

    curPage = curPage.substr(index + 1, curPage.length - index);

    curPage = curPage.substr(0, curPage.indexOf(".")).toLowerCase();

    if (curPage == "") curPage = "index";

    if (curPage == "index") {
        document.getElementById("_m_index").className = "act";
    }

    var qkAry = new Array("infoselect", "addnews", "engageadd", "cashacount");

    for (var i = 0; i < qkAry.length; i++) {
        if (curPage == qkAry[i]) {
            document.getElementById("_m_quick").className = "act";
            break;
        }
    }

    var msgAry = new Array("receivemessagelist", "sendmessagelist", "postadministratormessage", "joinlist");

    for (var j = 0; j < msgAry.length; j++) {
        if (curPage == msgAry[j]) {
            document.getElementById("_m_msg").className = "act";
            break;
        }
    }

    var userAry = new Array("registerinfo", "edituserinfo", "edituserinfomore");

    for (var k = 0; k < userAry.length; k++) {
        if (curPage == userAry[k]) {
            document.getElementById("_m_userinfo").className = "act";
            break;
        }
    }

    if (curPage == "edituserpassword") {
        document.getElementById("_m_safe").className = "act";
    }
}

function switchShow(id) {

    var tObj = document.getElementById("div_" + id);
    var iObj = document.getElementById("a_" + id);

    if (tObj && tObj.style.display != "none") {
        tObj.style.display = "none";
        iObj.className = "";
        return;
    }

    for (var i = 1; i <= 9; i++) {
        var div_ = document.getElementById("div_" + i);
        var a_ = document.getElementById("a_" + i);
        if (div_) {
            if (a_) {
                a_.className = "";
            }
            div_.style.display = "none";
        }
    }

    if (tObj) {
        if (iObj) {
            iObj.className = (tObj.style.display == 'none') ? "act" : "";
        }
        tObj.style.display = (tObj.style.display == 'none') ? "block" : "none";
    }

}

function xy_Sel_CurLeftMenu() {
    var curPage = location.href;

    var index = curPage.lastIndexOf("/");

    curPage = curPage.substr(index + 1, curPage.length - index);

    curPage = curPage.substr(0, curPage.indexOf(".")).toLowerCase();

    if (curPage == "") curPage = "index";

    for (var i = 1; i <= 9; i++) {
        if (document.getElementById("div_" + i)) {
            document.getElementById("div_" + i).style.display = "none";
        }
    }

    var allAry = new Array();

    allAry[0] = new Array("2", "searchkeyword", "curranking", "historyranking", "buy_key_1", "buy_key_2");
    allAry[1] = new Array("3", "selectshoptemp", "uploadlogo", "uploadimage", "uploadbanner", "companyproducttype", "bindingdomain", "companyproducttypeadd", "userfirendlink", "userfirendlinkedit", "userfirendlinkadd", "userannounce", "newlist", "addnews", "editnew", "engagelist", "engageadd", "engageedit", "engageinfo", "resumelis", "certificatelist", "certificateadd", "certificateinfo");
    allAry[2] = new Array("8", "orderbuylist", "ordersalelist", "orderbuyinfo", "orderbuythrulist", "orderlist", "ordermessageinfo", "ordersaleinfo", "ordersalethrulist", "ordertypeupdate");
    allAry[3] = new Array("5", "cashacount", "consumptioninfo", "inputmoney", "invoicelist", "invoice", "remit", "fictitiouconsumptioninfo", "paymathod", "accountrecharge", "paymentreturn");
    allAry[4] = new Array("6", "registerinfo", "edituserinfo", "edituserinfomore", "edituserpassword", "buy_key_2");
    allAry[5] = new Array("7", "companys", "favoritelist", "favoriteallbusinesslist", "favoriteotherlist", "companysee");
    allAry[6] = new Array("9", "getgift", "mygift");
    allAry[7] = new Array("4", "buyclassads", "curclassads", "hisclassads");
    for (var i = 0; i < allAry.length; i++) {
        for (j = 1; j < allAry[i].length; j++) {
            if (curPage == allAry[i][j]) {
                //alert(allAry[i][0]);
                document.getElementById("div_" + allAry[i][0]).style.display = "block";
                return;
            }
        }
    }
    document.getElementById("div_1").style.display = "block";
}


// 
//============================切换菜单 结束==============================================
//
////==========================================================================
////  公共方法 结束
////==========================================================================


//加载身份和企业类别
//Tc 2008-11-8 Modify
function InitUserInfo(sex, supplytype, character) {
    var num = 0;
    var chkother = document.getElementsByName("utype");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'radio') {
            if (chkother[i].value == character) {
                chkother[i].checked = true;
            }
        }
    }
    if (supplytype == "1") {
        $("supplyorbuy-1").checked = true;
    }
    else if (supplytype == "2") {
        $("supplyorbuy-2").checked = true;
    }
    else if (supplytype == "3") {
        $("supplyorbuy-3").checked = true;
    }
    addMouseEvent(1);

    $("sext").value = sex;

    if (sex == "1") {
        $("sexy").checked = true;
    }
    else if (sex == "0") {
        $("sexn").checked = true;
    }
    else {
        $("sexy").checked = true;
        $("sexn").checked = false;
    }
}
function shousex(num) {
    if (num == 1) {
        $("sexy").checked = true;
    }
    else {
        $("sexn").checked = true;
    }

    $("sext").value = num;
}

////==========================================================================
////  登陆 结束
////==========================================================================

////==========================================================================
////  基本设置 开始
////==========================================================================
//邮箱验证
function validateemail(obj) {
    var email = obj.value;
    var oldemail = $("oldEmail").value;
    if (email == oldemail) return;


    if (!ValidateEmail(email)) {
        sAlert("邮箱格式不正确");
        obj.focus();
    }


    var ajax = new Ajax("xy017", "&email=" + email);
    ajax.onSuccess = function () {
        if (ajax.state.result == 0 || ajax.state.result == -1) {
            sAlert(ajax.state.message);
            obj.focus();
        }
    }
}

//修改企业信息
function edituserinfo() {
    if ($F("linkman").trim() == "") {
        return alertmsg(false, '请输入联系人的真实姓名！');
    }

    if ($F("email").trim() == "") {
        return alertmsg(false, 'Email为必填项，不能为空！');
    }

    if ($F("email").search(/^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$/) == -1) {
        return alertmsg(false, 'Email格式有误，请检查！');
    }
    else {
        var oldmail = $F("oldEmail").trim();
        if ($F("email").trim() != oldmail) {
            var url = $F("weburl") + "Common/Ajax.ashx?ac=016&value=" + $F("email");
            var XMLDoc1 = new XMLHttpObject(url, false);
            XMLDoc1.sendData();
            var msg = XMLDoc1.getText();
            if (msg > 0) {
                return alertmsg(false, "此邮件地址已被注册！请您选择合适的邮件地址！");
            }
        }
    }


    if ($F("telephone").trim() == "") {
        return alertmsg(false, '固定电话为必填项！');
    }

    if ($F("telephone").trim() != "") {
        if (!ValidateTels($F("telephone"))) {
            return alertmsg(false, '固定电话格式不正确！')
        }
    }


    if ($F("lbMobile").trim() != "") {
        if (!ValidateMobileTels($F("lbMobile"))) {
            return alertmsg(false, '手机号码格式有误! ');
        }
    }

    if ($F("companyname").trim() == "") {
        return alertmsg(false, '请输入公司名称！');
    }

    if ($F("tradeid").trim() == "" || $F("tradeid").trim() == "0") {
        return alertmsg(false, '请选择企业所在行业！');
    }

    if ($F("companyid").trim() == "" || $F("companyid").trim() == "0") {
        return alertmsg(false, '请选择企业类别！');
    }

    if ($F("areatypeid").trim() == "" || $F("areatypeid").trim() == "0") {
        return alertmsg(false, '请选择所在区域！');
    }

    if ($F("txtpostcard").trim() != "") {
        if ($F("txtpostcard").search(/^[-\+]?\d+$/) == -1) {
            return alertmsg(false, '邮编必须为整数！');
        }
        else if ($F("txtpostcard").search(/^\d{6}$/) == -1) {
            return alertmsg(false, '邮编格式有误！');
        }
    }

    if ($F("txtarea").trim() == "") {
        return alertmsg(false, '地址为必填项！');
    }

    if ($F("homepage").trim() != "") {
        if ($F("homepage").search(/[a-zA-z]+:\/\/[^s]*/) == -1 && $("homepage").value != "http:\/\/") {
            return alertmsg(false, '您输入的网址格式有误！');
        }
    }


}
//多种产品或服务
function getmore() {
    $("pmore").style.display = 'block';
}
//经营模式
function getmode() {
    var num = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].checked == true) {
                num++;
            }
        }
    }
    if (num == 0) {
        $("getmode").value = "";
    }
    else if (num > 2) {
        $("getmode").value = 3;
    }
    else {
        $("getmode").value = 2
    }
}
//修改个人信息
function personinfo() {

    getmode();
    if ($("companyname").value == "") {
        return alertmsg(false, '请输入企业名称！');
    }
    if ($("getmode").value == "") {
        return alertmsg(false, '请选择经营模式！');
    }
    else if ($("getmode").value >= 3) {
        return alertmsg(false, '您最多只能选择两种经营模式！');
    }
    if ($("money").value == "") {
        return alertmsg(false, '请输入注册资金！');
    }
    if ($("money").value != "" && $("money").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '公司注册资金必须为整数！');
    }
    if ($("companynian").value == "") {
        return alertmsg(false, '请输入公司成立年份！');
    }
    if ($("companynian").value != "" && $("companynian").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '公司成立年份必须为整数！');
    }
    if ($("areatypeid").value == 0) {
        return alertmsg(false, '请输入公司注册地！');
    }
    if ($("address").value == "") {
        return alertmsg(false, '请输入主要经营地点！');
    }
    if ($("pt").value == "") {
        return alertmsg(false, '请输入主营产品或服务！');
    }
    if ($("lbjianjie").value == "") {
        return alertmsg(false, '公司简介为必须项！');
    }
    if ($("lbjianjie").value.length > 4000) {
        return alertmsg(false, '简介长度超出范围，请检查！');
    }
}

//初始化商务中心高级资料
//28-11-20 tc add
function InitUserMoreInfo(mode, employeetotal) {
    if (mode != "") {
        var ms = mode.split(',');
        var num = 0;
        var chkother = document.getElementsByName("modetype");
        for (var i = 0; i < chkother.length; i++) {
            for (var j = 0; j < ms.length; j++) {
                if (chkother[i].type == 'checkbox' && chkother[i].value == ms[j]) {
                    chkother[i].checked = true;
                }
            }
        }
    }

    var options = $("employeetotal").options;

    for (var j = 0; j <= options.length; j++) {
        if (options[j].value == employeetotal) {
            options[j].selected = true;
            break;
        }
    }
}

//修改密码	
function ispasswore() {
    if ($("oldpad").value == "") {
        return alertmsg(false, '请输入原密码！');
    }
    else if ($("oldpad").value.length < 6) {
        return alertmsg(false, '原密码长度为6-15位的数字或字母');
    }
    else if ($("pwd").value == "") {
        return alertmsg(false, '请输入新密码！');
    }
    else if ($("pwd").value.length < 6) {
        return alertmsg(false, '新密码长度为6-15位的数字或字母！');
    }
    else if ($("pwd1").value == "") {
        return alertmsg(false, '请确认新密码！');
    }
    else if ($("pwd1").value.length < 6) {
        return alertmsg(false, '确认密码长度为6-15位的数字或字母！');
    }
    else if ($("pwd").value != $("pwd1").value) {
        return alertmsg(false, '两次输入的密码不一致，请重新输入！');
    }

}

//上传企业形象图片
function setuserimg() {
    if (!IsUploadFile())
        return alertmsg(false, '请上传企业形象图片！');
}


//添加公司动态
function getnews() {
    if ($("title").value == "") {
        return alertmsg(false, '新闻标题为填项！');
    }

    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);

    if (content == "") {
        return alertmsg(false, '新闻内容为必填项！');
    }

    if (content.length > 4000) {
        return alertmsg(false, '您输入的内容过长！');
    }
}


////==========================================================================
////  基本设置 结束
////==========================================================================

////==========================================================================
////  商业信息 开始
////==========================================================================

//修改供应信息要显示的图片和产品名称
function getonloadtype(PT_ID, PT_Name, At_ID, At_IDs) {
    $("typeids").value = PT_ID;
    $("supplyid").value = PT_ID;
    $("supply").innerHTML = PT_Name;
    businessinfo();
}


//修改求购信息要显示的图片和产品名称
function getbuyonloadtype() {
    var ms;
    ms = document.getElementsByTagName("input");
    var area = $("pclist").value;
    {
        var Msgs = area.split(",");
        for (var i = 0; i < ms.length; i++) {
            for (var j = 0; j < Msgs.length; j++) {
                if (ms[i].type == 'checkbox') {
                    if (Msgs[j] == ms[i].value) {
                        ms[i].checked = true;
                    }
                }
            }
        }
    }
}

//品牌信息
function getbrand() {
    if ($("txtname").value == "") {
        return alertmsg(false, '请输入品牌名称！');
    }
    if ($("supplyid").value == "") {
        return alertmsg(false, '请选择品牌类别！');
    }

    if (!IsUploadFile()) {
        return alertmsg(false, '请上传品牌图片！');
    }

    var content = FCKeditorAPI.GetInstance('txtsm').GetXHTML(true);
    if (content.length > 8000) {
        return alertmsg(false, '品牌介绍长度超出范围，请检查！');
    }
}


//显示招商信息的身份名称
function showcityname(num) {
    if (num == 1) {
        $("cityl").checked = false;
        $("cityls").style.display = "none";
        $("city").value = "全国";
    }
    else {
        $("cityls").style.display = "block";
        $("cityl").checked = true;
        $("citys").checked = false;
        $("city").value = "";
    }
}



//加载时要显示的省份和企业类别
function loadsurrogateinfo(ProvinceID, C_ID, Province_Name, C_Name, PT_ID, PT_Name, At_ID, At_IDs) {
    $("supplyid").value = PT_ID;
    $("supply").innerHTML = PT_Name;
    $("citytype").innerHTML = Province_Name + "&nbsp;" + C_Name;
    $("citytypenames").value = Province_Name + "&nbsp;" + C_Name;
    $("citytypeid").value = C_ID;
    $("ProvinceID").value = ProvinceID;
    businessinfo();
}

////==========================================================================
////  商业信息 结束
////==========================================================================

////==========================================================================
////  财务信息 开始
////==========================================================================
//发票信息 
function InvoiceAdd() {
    if ($("I_Name").value == "") {
        return alertmsg(false, '请输入申请人的姓名！');
    }
    if ($("I_Address").value == "") {
        return alertmsg(false, '请输入申请人的地址！');
    }
    if ($("I_PostCode").value == "") {
        return alertmsg(false, '请输入申请人的邮编！');
    }
    if ($("I_PostCode").value.search(/^\d{6}$/) == -1) {
        return alertmsg(false, '您输入的邮编格式有误！');
    }
    if ($("I_Money").value == "") {
        return alertmsg(false, '请输入发票金额！');
    }
    if ($("I_Title").value == "") {
        return alertmsg(false, '请输入发票抬头信息！');
    }
    if ($("I_Product").value == "") {
        return alertmsg(false, '请输入发票项目名称！');
    }
    if ($("I_Content").value == "") {
        return alertmsg(false, '请输入内容信息');
    }
    if ($("I_Content").value.length > 8000) {
        return alertmsg(false, '您输入的信息内容过长，请检查！');
    }
    if ($("I_Money").value.search(/^[0-9]+$/) != -1 || $("I_Money").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("I_Money").value = Math.round(parseFloat($("I_Money").value) * 100) / 100
        return true;
    }
    else {
        return alertmsg(false, '您输入的金额格式有误，请检查！\n 例：88.88')
    }

}

//商铺分类添加
function typeadd() {
    if ($("name").value == "") {
        return alertmsg(false, '请输入分类名称！');
    }
}

//汇款确认信息
function remitadd() {
    if ($("R_Name").value == "") {
        return alertmsg(false, '请输入收款人姓名！');
    }
    if ($("R_Email").value == "") {
        return alertmsg(false, '请输入汇款人Email！');
    }
    if ($("R_Email").value.search(/^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$/) == -1) {
        return alertmsg(false, '您输入的邮件格式错误，请检查！');
    }
    if ($("haoma").value == "") {
        return alertmsg(false, '联系电话号码为必填项！');
    }
    if ($("R_Time").value == "") {
        return alertmsg(false, '请输入汇款时间！');
    }
    if ($("R_Bank").value == "") {
        return alertmsg(false, '请输入汇入银行！');
    }
    if ($("R_Account").value == "") {
        return alertmsg(false, '请输入汇入卡号！');
    }
    if ($("R_Account").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '汇入卡号必须为整数，请检查！');
    }
    if ($("R_CAccount").value != "" && $("R_CAccount").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '汇出卡号必须为整数，请检查！');
    }
    if ($("R_CName").value == "") {
        return alertmsg(false, '请输入收款人姓名！');
    }
    if ($("R_Money").value == "") {
        return alertmsg(false, '请输入汇款金额！');
    }
    if ($("R_Money").value.search(/^[0-9]+$/) != -1 || $("R_Money").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("R_Money").value = Math.round(parseFloat($("R_Money").value) * 100) / 100
        return true;
    }
    else {
        return alertmsg(false, '输入格式错误！\n 例：88.88')
    }
}
////==========================================================================
////  财务信息 结束
////==========================================================================

////==========================================================================
////  招聘信息 开始
////==========================================================================
//招聘信息
function engeinfo() {
    if ($("engageaid").value == "") {
        return alertmsg(false, '拟招聘岗位不能为空！');
    }
    if ($("EI_Job").value == "") {
        return alertmsg(false, '具体职位名称不能为空!');
    }
    if ($("EI_Branch").value == "") {
        return alertmsg(false, '招聘部门不能为空!');
    }
    if ($("EI_Number").value != "" && $("EI_Number").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '招聘人数为整数!');
    }
    if ($("EI_EndDate").value == "") {
        return alertmsg(false, '截至日期不能为空!');
    }
    if ($("areatypeid").value == "") {
        return alertmsg(false, '工作地区不能为空!');
    }
    if ($("EI_Request").value == "") {
        return alertmsg(false, '具体要求不能为空!');
    }
    if ($("EI_Request").value.length > 650) {
        return alertmsg(false, '具体要求长度超出范围！');
    }
    if ($("EI_Pay").value != "" && $("EI_Pay").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '薪资福利为整数!');
    }
    /* if($("EI_Eb").value=="不限")
    {
    return alertmsg(false,'学历必须选择！');
    }
    if($("EI_Age").value=="不限")
    {
    return alertmsg(false,'年龄必须选择！');
    }*/
    if ($("EI_Experience").value != "" && $("EI_Experience").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '工作经验为整数!');
    }

}

////==========================================================================
////  招聘信息 结束
////==========================================================================

////==========================================================================
////  留言信息 开始
////==========================================================================
//留言信息
function Message() {
    $("lbtitle").value = "";
    $("lbcontent").value = "";
}
//判断留言信息是否为空
function GetMessage() {
    if ($("lbtitle").value == "") {
        return alertmsg(false, '留言主题为必填项，请检查！');
    }
    if ($("lbcontent").value == "") {
        return alertmsg(false, '留言内容必填项，请检查！');
    }
}


function getpostadministrator() {
    if ($("messtitle").value == "") {
        return alertmsg(false, '留言标题必填项，请检查！');
    }
    if ($("admincontent").value == "") {
        return alertmsg(false, '留言内容必填项，请检查！');
    }
    if ($("admincontent").value.length > 8000) {
        return alertmsg(false, '留言内容长度超出范围！');
    }

}
////==========================================================================
////  留言信息 结束
////==========================================================================

////==========================================================================
//// 交易信息 开始
////==========================================================================

function onupdateof(ID, Type) {
    window.location = config.WebURL + "user/ordertypeupdate." + config.Suffix + "?OF_ID=" + ID + "&&Type=" + Type;

}
function loadtypebuy(objtype) {
    switch (objtype) {
        case "1": //修改运费
            $("txtNumber").disabled = "";
            $("txtLinkMan").disabled = "";
            $("sguobie").disabled = "";
            $("squhao").disabled = "";
            $("shaoma").disabled = "";
            $("sfenjihao").disabled = "";
            $("txtLinkAddress").disabled = "";
            $("btnupdateof").value = "请确认无误后点击！";
            break;
        case "2": //确定运费并付款
            $("txtNumber").disabled = "disabled";
            $("txtLinkMan").disabled = "disabled";
            $("txtLinkAddress").disabled = "disabled";
            $("sguobie").disabled = "disabled";
            $("squhao").disabled = "disabled";
            $("shaoma").disabled = "disabled";
            $("sfenjihao").disabled = "disabled";
            $("btnupdateof").value = "请确认运费无误 并汇款后点击！";
            break;
        case "5": //确定收货
            $("txtNumber").disabled = "disabled";
            $("txtLinkMan").disabled = "disabled";
            $("sguobie").disabled = "disabled";
            $("squhao").disabled = "disabled";
            $("shaoma").disabled = "disabled";
            $("sfenjihao").disabled = "disabled";
            $("txtLinkAddress").disabled = "disabled";
            $("btnupdateof").value = "请确认无误 并收货后点击！";
            break;
        case "6": //交易完成
            $("txtNumber").disabled = "disabled";
            $("txtLinkMan").disabled = "disabled";
            $("sguobie").disabled = "disabled";
            $("squhao").disabled = "disabled";
            $("shaoma").disabled = "disabled";
            $("sfenjihao").disabled = "disabled";
            $("txtLinkAddress").disabled = "disabled";
            $("btnupdateof").value = "请确认此订单成功完成后点击！";
            break;
        case "7": //交易完成
            $("txtNumber").disabled = "disabled";
            $("txtLinkMan").disabled = "";
            $("sguobie").disabled = "disabled";
            $("squhao").disabled = "disabled";
            $("shaoma").disabled = "disabled";
            $("sfenjihao").disabled = "disabled";
            $("txtLinkAddress").disabled = "";
            $("btnupdateof").value = "请确认无误 点击要求退货！";
            break;
        default:
            $("txtNumber").disabled = "disabled";
            $("txtLinkMan").disabled = "disabled";
            $("sguobie").disabled = "disabled";
            $("squhao").disabled = "disabled";
            $("shaoma").disabled = "disabled";
            $("sfenjihao").disabled = "disabled";
            $("txtLinkAddress").disabled = "disabled";
            $("btnupdateof").disabled = "disabled";
            break;
    }

}
function loadtypesale(objtype, cbear, cbegin) {
    $("OF_CBear").value = cbear;
    if (cbear == "1") {
        $("OF_CBeary").checked = true;
    }
    else if (cbear == "0") {
        $("OF_CBearn").checked = true;
        hiddenDisplay("showTRFlag");
    }
    $("OF_CBegin").value = cbegin;
    if (cbear == "1") {
        $("CBeginy").checked = true;
    }
    else if (cbear == "0") {
        $("CBeginn").checked = true;
    }

    switch (objtype) {
        case "1": //添加运费
            $("txtNumber").disabled = "";
            $("Carriage").disabled = "";
            $("Favorable").disabled = "";
            $("ProductPrice").disabled = "";
            $("OF_CBearm").disabled = "";
            $("CBegink").disabled = "";
            $("btnupdateof").value = "请确认运费无误点击！";
            break;
        case "2":
            $("txtNumber").disabled = "";
            $("Carriage").disabled = "";
            $("Favorable").disabled = "";
            $("ProductPrice").disabled = "";
            $("OF_CBearm").disabled = "";
            $("CBeginy").disabled = "";
            $("btnupdateof").value = "请确认运费无误点击！";
            break;
        case "3":
            $("txtNumber").disabled = "disabled";
            $("Carriage").disabled = "disabled";
            $("Favorable").disabled = "disabled";
            $("ProductPrice").disabled = "disabled";
            $("OF_CBearn").disabled = "disabled";
            $("CBeginn").disabled = "disabled";
            $("OF_CBeary").disabled = "disabled";
            $("CBeginy").disabled = "disabled";
            $("btnupdateof").value = "请确认无误 并收到汇款后点击！";
            break;
        case "4":
            $("txtNumber").disabled = "disabled";
            $("Carriage").disabled = "disabled";
            $("Favorable").disabled = "disabled";
            $("ProductPrice").disabled = "disabled";
            $("OF_CBearn").disabled = "disabled";
            $("CBeginn").disabled = "disabled";
            $("OF_CBeary").disabled = "disabled";
            $("CBeginy").disabled = "disabled";
            $("btnupdateof").value = "请确认无误 并发货后点击！";
            break;
        default:
            $("txtNumber").disabled = "disabled";
            $("Carriage").disabled = "disabled";
            $("Favorable").disabled = "disabled";
            $("ProductPrice").disabled = "disabled";
            $("OF_CBearm").disabled = "disabled";
            $("OF_CBearn").disabled = "disabled";
            $("CBeginn").disabled = "disabled";
            $("OF_CBeary").disabled = "disabled";
            $("CBeginy").disabled = "disabled";

            break;
    }


}
//显
function showDisplay(tey) {

    var show = $(tey);
    show.style.display = "";
    var Carriage = $("Carriage");
    Carriage.value = 0;
    Carriage.disabled = "";
}
//隐藏
function hiddenDisplay(tey) {
    var show = $(tey);
    show.style.display = "none";
    var Carriage = $("Carriage");
    Carriage.value = 0;
    Carriage.disabled = "disabled";
}
function radio(obj, objName) {
    var Name = $(objName);
    Name.value = obj.value;
    obj.checked = true;

}
//数字判断
function OnisFinite(obj) {
    if (!isFinite(parseFloat(obj.value))) {

        alertmsg(false, "请输入有效的数字!");
        obj.value = "";
    }

}
function getMoneybuy() {
    var ProductPrice = $("ProductPrice").value;
    var ProductNumber = $("txtNumber");
    var OrderMoney = $("OrderMoney");
    var Allgoods = $("Allgoods");
    if (!isFinite(parseFloat(ProductNumber.value))) {
        ProductNumber.value = "0";
        OrderMoney.value = "0";
        alertmsg(false, "请输入有效的数字!");

        return false;
    }
    Allgoods.innerHTML = parseFloat(ProductNumber.value) * parseFloat(ProductPrice);
    OrderMoney.innerHTML = parseFloat(ProductNumber.value) * parseFloat(ProductPrice);

}


function getMoney() {
    var ProductPrice = $("ProductPrice");
    var Carriage = $("Carriage");
    var Favorable = $("Favorable");
    var ProductNumber = $("txtNumber");
    var OrderMoney = $("OrderMoney");
    var Allgoods = $("Allgoods");
    if (!isFinite(parseFloat(ProductPrice.value))) {
        ProductPrice.value = "0";
        alertmsg(false, "请输入有效的数字!");
        return false;
    }
    if (!isFinite(parseFloat(Carriage.value))) {
        Carriage.value = "0";
        alertmsg(false, "请输入有效的数字!");
        return false;
    }
    if (!isFinite(parseFloat(Favorable.value))) {
        Favorable.value = "0";
        alertmsg(false, "请输入有效的数字!");
        return false;
    }
    if (!isFinite(parseFloat(ProductNumber.value))) {
        ProductNumber.value = "0";
        OrderMoney.value = "0";
        alertmsg(false, "请输入有效的数字!");
        return false;
    }
    Allgoods.innerHTML = parseFloat(ProductNumber.value) * parseFloat(ProductPrice.value);
    OrderMoney.innerHTML = (parseFloat(ProductNumber.value) * parseFloat(ProductPrice.value) + parseFloat(Carriage.value) - parseFloat(Favorable.value));

}
function updateofbuy() {
    var ProductNumber = $("txtNumber");
    var lxr = $("txtLinkMan");
    var lxdh = $("txtLinkTel");
    var lxdz = $("txtLinkAddress");

    var msg = '';
    var flag = true;
    var foucuse = null;
    if (ProductNumber.value == "") {
        msg = '请填写数量！';
        foucuse = ProductNumber;
        flag = false;
    }
    if (lxdz.value == "") {
        if (flag) {
            msg = '请输送货地址！';
            foucuse = lxdz;
            flag = false;
        }
        else {
            msg += '\r\n请输入送货地址！';
            flag = false;

        }
    }
    if (lxr.value == "") {
        if (flag) {
            msg = '请输入联系人！';
            foucuse = lxr;
            flag = false;
        }
        else {
            msg += '\r\n请输入联系人！';
            flag = false;

        }
    }
    if (lxdh.value == "") {
        if (flag) {
            msg = '请输入联系电话！';
            foucuse = lxdh;
            flag = false;
        }
        else {
            msg += '\r\n请输入联系电话！';
            flag = false;

        }
    }
    if (flag) {
        return true;
    }
    else {
        alertmsg(false, msg);
        foucuse.focus();
        return false;

    }
}

////==========================================================================
////  交易信息 结束
////==========================================================================

//判断输入页数
//	 function getNO()
//	 {
//	 if($("lbpage").value=="")
//	 {
//	return alertmsg(false,'请输入页数！');
//	 }
//	 }

/****************************结束************************************************/

//商铺搜索

function getkey() {
    if ($("key").value == "") {
        return alertmsg(false, '请输入关键字！');
    }
    else if ($("key").value == "输入关键字") {
        return alertmsg(false, '请输入关键字！');
    }
    else {
        window.location.href = "productlist." + config.Suffix + "?key=" + $("key").value + "&U_ID=" + $("").value;
    }
}
//搜索
function getfocus() {
    $("keyword").value = "";
}

//清空用户名和密码	
function ResetText() {
    $("txtUserName").value = "";
    $("txtUserPWD").value = "";
    $("txtCode").value = "";
}

//搜索
function searchClick() {
    if ($("txttitle").value == "") {
        return alertmsg(false, "请输入查询条件！");

    }
    else if ($("info").checked == true) {
        window.location.href = "/";
    }
    else if ($("user").checked == true) {
        window.location.href = config.WebURL + "corporationlist." + config.Suffix + "?key=" + $("txttitle").value;
    }
}


//控制面板

////基本信息
function basicinfo() {
    addMouseEvent(1);
}

//商业信息
function businessinfo() {
    addMouseEvent(2);

}
//财务信息
function financeinfo() {
    addMouseEvent(3);
}

//招聘信息
function inviteinfo() {
    addMouseEvent(1);
}

//留言信息
function messageinfo() {
    addMouseEvent(5);
}
//交易信息
function orderforminfo() {
    addMouseEvent(6);
}
//控制面板
function indexforminfo() {
    //addMouseEvent(4);
}
////==========================================================================
////  用户是否可以查看留言  开始
////==========================================================================
function IsMessage() {
    if ($("ismessage").value == "1") {
        return alertmsg(false, '对不起，您当前身份不能查看留言，请联系管理员！', config.WebURL + "user/receivemessagelist." + config.Suffix + "");
    }
}

function usermessageinfo() {
    IsMessage();
    messageinfo();

}
////==========================================================================
////  用户是否可以查看留言  结束
////==========================================================================

//返回信息
function getback() {
    if ($("infourl").value != "") {
        window.location.href = $("infourl").value;
    }
}

//选择电话号码
function phone() {
    $("fax").value = $("telephone").value;
}

function huifumessage() {
    if ($("rmesstitle").value == "") {
        return alertmsg(false, '请输入回复标题！');
    }
    if ($("rcontent").value == "") {
        return alertmsg(false, '请输入回复内容！');
    }
    if ($("rcontent").value.length > 1500) {
        return alertmsg(false, '回复内容长度超出范围！');
    }
}

////==========================================================================
////
////  个人会员 基本信息 开始
////
//////==========================================================================
//function IndividualLoad(sex,Province_ID,Province_Name,C_ID,C_Name,A_ID,A_Name)
//{
//    $("citytype").innerHTML=Province_Name+"&nbsp"+C_Name+"&nbsp"+A_Name;   
//    $("sext").value=sex;   
//    if($("citytype").innerHTML=="&nbsp;&nbsp;")
//    {
//       $("citytype").innerHTML="选择所在城市";
//    }
//    $("citytypeid").value=C_ID;
//    $("provinceid").value=Province_ID;
//    $("areatypeid").value=A_ID;
//    if(sex=="1")
//    {
//       $("sexy").checked=true;
//    }
//    else 
//    {
//       $("sexn").checked=true;
//    }  
//    $("type").value="update"
//}
//function RegForm(FormValue, FormType)
//{
//	var reg = new RegExp(FormType);
//	if(!reg.test(FormValue))
//		return false;
//	else
//		return true;
//}

function setType(type) {
    if (type != '') {
        $("Type").value = type;
        return true
    }
    else {
        return false
    }

}


function buiness() {
    addMouseEvent(2);
    // getshowinfo();
}

function busiinfo() {
    addMouseEvent(2);
    // geturlset();
}

//选择模块
function selectpage() {
    window.location.href = config.WebURL + $F("selected");
}

//获取自定义字段信息
function GetFieldInnerHTML() {
    var typeid = $F(this.InputTxtID);
    if ("" == typeid) {
        $("tabFieldBody").innerHTML = "";
        return;
    }

    $("tabFieldBody").innerHTML = XY_LOADING_SMALL;

    var ajax = new Ajax("XY032", "&module=" + this.ModuleName + "&typeid=" + typeid);
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            $("tabFieldBody").innerHTML = "<table class=\"c1_table\" width=\"90%\">" + unescape(ajax.data.html) + "</table>";
        }
    }
}

//选择信息类型
function selectinfotypetr(obj, rd) {
    obj.className = "xuanze";
    $(rd).checked = true;

    for (var i = 0; i < $("typenum").value; i++) {
        if ("tr" + (i + 1) != obj.id) {
            $("tr" + (i + 1)).className = "";
        }
    }
}

function selectinfotype(tr, obj) {
    var typenum = document.getElementsByName("module");
    for (var i = 0; i < typenum.length; i++) {
        $("tr" + (i)).className = "";
    }
    $("selected").value = obj.value;
    $(tr).className = "xuanze";
}

//初始化信息新增页面
function InitInfoAddPageForm(moduleName, moduleParentName, infoType) {
    if (moduleName == "investment" || moduleParentName == "investment") {
        if (infoType == "buy") {
            $("tabInvestmentBuy").style.display = "";
            $("tabInvestmentSell").style.display = "none";
        }
        else {
            $("tabInvestmentBuy").style.display = "none";
            $("tabInvestmentSell").style.display = "";
        }
    }
}
//验证供求信息
function checkofferinfo() {
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);
    if (content == "") {
        return alertmsg(false, '详细说明为必填项，请检查！');
    }

    if ($("datetype").value != "True") {
        if ($("EndDate").value == "") {
            return alertmsg(false, '请选择信息有效时间！');
        }
    }
    if ($("txtsprice").value == "") {
        return alertmsg(false, "请输入单价！");
    }
    if ($("txtsprice").value != "" && $("txtsprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) {
        return alertmsg(false, '单价输入有误，请检查！');
    }
    if ($("txtssmallnum").value != "" && $("txtssmallnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '最小起定量必须为整数，请检查！');
    }

    if ($("txtscountnum").value != "" && $("txtscountnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '货物总量必须为整数，请检查！');
    }
}

//验证加工信息
function checkmachininginfo() {
    try {
        if ($F("hidTypeId") == "" || $F("hidTypeId") == "0") {
            return alertmsg(false, '请选择信息类别！');
        }
    } catch (e) { }

    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);

    if (content == "") {
        return alertmsg(false, '详细说明为必填项，请检查！');
    }

    if ($("datetype").value != "True") {
        if ($("EndDate").value == "") {
            return alertmsg(false, '请选择信息有效时间！');
        }
    }
    if ($("txtcprice").value != "" && $("txtcprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) {
        return alertmsg(false, '单价输入有误，请检查！');
    }
    if ($("txtcsmallnum").value != "" && $("txtcsmallnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '最小起定量必须为整数，请检查！');
    }
    if ($("txtccountnum").value != "" && $("txtccountnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '货物总量必须为整数，请检查！');
    }
}
//验证招商信息
function checkinvestmentinfo() {
    try {
        if ($F("hidTypeId") == "" || $F("hidTypeId") == "0") {
            return alertmsg(false, '请选择信息类别！');
        }
    } catch (e) { }


    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);
    if (content == "") {
        return alertmsg(false, '详细说明为必填项，请检查！');
    }
    if ($("datetype").value != "True") {
        if ($("EndDate").value == "") {
            return alertmsg(false, '请选择信息有效时间！');
        }
    }
    if ($("txtsupport").value.length > 4000) {
        return alertmsg(false, '招商支持内容过长，请检查！');
    }
    if ($("txtdemand").value.length > 4000) {
        return alertmsg(false, '招商要求内容过长，请检查！');
    }

    if ($("pageurl").value != "") {
        if ($("pageurl").value.search(/[a-zA-z]+:\/\/[^s]*/) == -1 && $("pageurl").value != "http:\/\/") {
            return alertmsg(false, '输入网址格式错误！');
        }
    }

}

//验证代理信息
function checksurrogateinfo() {
    try {
        if ($F("hidTypeId") == "" || $F("hidTypeId") == "0") {
            return alertmsg(false, '请选择信息类别！');
        }
    } catch (e) { }


    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);

    if (content == "") {
        return alertmsg(false, '详细说明为必填项，请检查！');
    }

    if ($("datetype").value != "True") {
        if ($("EndDate").value == "") {
            return alertmsg(false, '请选择信息有效时间！');
        }
    }
}

function CheckInfoFrom(moduleName, parentModuleName) {

    if (moduleName == "offer" || parentModuleName == "offer") return editoffer();

    if (moduleName == "venture" || parentModuleName == "venture") return checkmachininginfo();

    if (moduleName == "investment" || parentModuleName == "investment") return checkinvestmentinfo();

    if (moduleName == "service" || parentModuleName == "service") return checksurrogateinfo();

    return false;
}

//信息基本验证
//tc 08-11-6
function InfoBaseCheck() {
    var title = $("infotitle").value.trim();
    var infoType = $F("hidInfoType");
    var typeId = $F("hidTypeId");


    if (title == "" || title == infoType) {
        return alertmsg(false, '请输入信息标题！');
    }

    if (typeId == "" || typeId == 0) {
        return alertmsg(false, '请选择信息类别！');
    }
    return true;
}

function CheckInfoEditFrom(moduleName, moduleParentName) {

    if (!InfoBaseCheck()) return false;

    if (moduleName == "offer" || moduleParentName == "offer") {
        return checkofferinfo();
    }
    if (moduleName == "venture" || moduleParentName == "venture") {
        return checkmachininginfo();
    }
    if (moduleName == "investment" || moduleParentName == "investment") {
        return checkinvestmentinfo();
    }
    if (moduleName == "service" || moduleParentName == "service") {
        return checksurrogateinfo();
    }
    return false;
}

//修改供求信息
function editoffer() {
    if ($F("hidTypeId") == "" || $F("hidTypeId") == "0") {
        return alertmsg(false, '请选择产品类别！');
    }

    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);
    if (content == "") {
        return alertmsg(false, '请输入详细说明！');
    }

    if ($("datetype").value != "True") {
        if ($("EndDate").value == "") {
            return alertmsg(false, '请选择信息有效时间！');
        }
    }
    if ($("txtsprice").value == "") {
        return alertmsg(false, "请输入价格！");
    }
    if ($("txtsprice").value != "" && $("txtsprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) {
        return alertmsg(false, '单价输入有误，请检查！');
    }
    if ($("txtssmallnum").value != "" && $("txtssmallnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '最小起定量必须为整数！');
    }
    if ($("txtscountnum").value != "" && $("txtscountnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '货物总量必须为整数！');
    }

}

// 所填信息正确时显示的文字
var t2 = "正确！请继续！";
// 所填信息错误时显示的文字
var tw = new Array(1);
tw[0] = "格式错误，请不要出现信息类型分类，系统会自动为您加入。";



// 样式
var cw = new Array(4);
cw[0] = "three"; // 默认
cw[1] = "write"; // 获得焦点
cw[2] = "right"; // 正确
cw[3] = "wrong"; // 错误


function getobjw(objName) {
    if ($) { return eval('$("' + objName + '")'); }
    else { return eval('document.all["' + objName + '"]'); }
}
// 正确
function okw(num) {
    var obj = "txt" + num;
    getobjw(obj).setAttribute("className", cw[2]);
    getobjw(obj).innerHTML = t2;
}
// 错误
function errw(num) {
    var obj = "txt" + num;
    getobjw(obj).setAttribute("className", cw[3]);
    getobjw(obj).innerHTML = tw[num];

}

////==========================================================================
////  证书 开始
////==========================================================================
function certificate() {
    if ($("txtname").value == "") {
        return alertmsg(false, "请填写证书名称！");
    }
    if ($("txttype").value == "0") {
        return alertmsg(false, "请选择证书类别！");
    }
    if ($("txtorgan").value == "") {
        return alertmsg(false, "请填写发证机构！");
    }
    if ($("txtbegin").value == "") {
        return alertmsg(false, "请选择生效日期！");
    }
    if ($("txtupto").value == "") {
        return alertmsg(false, "请选择生效日期！");
    }
    if (!IsUploadFile()) {
        return alertmsg(false, "请上传证书图片！");
    }
}
function certificateLoad(type) {
    if (type != "") {
        $("txttype").value = type;
    }
}
function bntisopen(obj) {
    var num = 0;
    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].name.indexOf('sd_id') > -1) {
                if (chkother[i].checked == true) {
                    num++;
                }
            }
        }
    }
    if (num == 0) {
        return alertmsg(false, "至少要选择一条记录才能启用！");
    }
    else {
        $("isSetPause").value = obj.id;
    }

}
////==========================================================================
////  证书 结束
////==========================================================================

//初始话信息(招商代理信息)
//2008-11-20 tc modify
function getsurrogateproductname(IT_ID, IT_Name, datetime, enddate, sign, area) {
    businessinfo();
    getbuyonloadtype();

    InitEndDate(datetime, enddate);

    try {
        var ms;
        ms = document.getElementsByTagName("input");
        if (area == "全国") {
            $("citys").checked = true;
            $("cityl").checked = false;
            $("city").value = "全国";
        }
        else if (area == "") {
            $("cityl").checked = false;
            $("citys").checked = false;
        }
        else {
            $("cityls").style.display = "block";
            $("citys").checked = false;
            $("cityl").checked = true;
        }
    }
    catch (e)
{ }
}
//初始化信息到期时间
//2008-11-20 tc modify
function InitEndDate(datetime, enddate) {
    businessinfo();
    if (enddate == 0) {
        $("EndDate").value = datetime;
    }
    else {
        var chdate = document.getElementsByName("rad");
        for (var i = 0; i < chdate.length; i++) {
            if (chdate[i].value == enddate)
                chdate[i].checked = true;
        }
    }
}

////==========================================================================
////  关键字竞价  开始
////==========================================================================

function __xy_SearchKeyword() {
    if ($("keyword").value == "")
        return alertmsg(false, '请输入您要选择的关键词');
}

function _xy_BuyKey_RecalculatedPrice() {
    var price = $("price").innerText;

    if (isNaN(price)) return;

    price = parseInt(price);

    var timecycle = $("timecycle").value;

    if (timecycle == "1" || timecycle == "") {
        $("timecycle").value = 1;
        return;
    }

    if (isNaN(timecycle)) {
        $("timecycle").value = 1;
        return;
    }

    timecycle = parseInt(timecycle);

    $("amount").innerText = timecycle * price;
}


// 判断是否为整数
//function IsInt(name)//输入为整数
//{  
//   var lette = "1234567890";
//   var c;
//   var retvalue = true;
//   for(var i = 0; i < name.length; i++)
//   {
//      c = name.charAt(i);
//      if(lette.indexOf(c) == -1)
//      {
//        retvalue = false;
//        break;
//      }  
//   }
//   return retvalue;
//}
////==========================================================================
////  关键字竞价  结束
////==========================================================================

//快速搜索
function searchClick() {

    if ($("txtsearchkey").value == "") {
        alertmsg(false, "请输入查询条件！");
    }
    else if (isNull($("txtsearchkey").value)) {
        alertmsg(false, "输入查询条件不合法！");
    }
    else if (!isTrueKeyWord($("txtsearchkey").value)) {
        alertmsg(false, "输入查询条件不合法！");
    }
    else if (!isNVarchar($("txtsearchkey").value)) {
        alertmsg(false, "输入查询条件不合法！");
    }
    else {
        if (config.BogusStatic)
            window.parent.location.href = config.WebURL + "search/seller_search-offer--" + $F("txtsearchkey") + "-------." + config.Suffix;
        else
            window.parent.location.href = config.WebURL + "search/seller_search." + config.Suffix + "?flag=offer&keyword=" + $F("txtsearchkey");
    }
}

/*
字符串验证
*/
//是否为空白字符
function isNull(obj) {
    var reg = /^\s/;
    if (reg.test(obj)) return true;
    return false;
}
//是否为字母和数字
function isTrueKeyWord(obj) {
    var reg1 = /[^\uFF00-\uFFFF]/;

    if (reg1.test(obj)) return true;

    return false;
}
//是否为汉字
function isNVarchar(obj) {
    var reg = /\w|^[\u0391-\uFFE5]+$/;
    if (reg.test(obj)) return true;
    return false;
}


function CheckUserState() {

}
/****** 在线充值相关开始 *********/

function CheckAccountRecharge(Flag) {
    var amount = $F("txtAmount").trim();

    if (amount == "" || amount == "0") {
        return alertmsg(false, "请输入充值金额！");
    }

    if (amount.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '充值金额必须为整数！');
    }
    showid(Flag);
    return true;
}

/****************************** 弹出层 ************************************/

function showid(idname) {
    var isIE = (document.all) ? true : false;
    var isIE6 = isIE && ([/MSIE (\d)\.0/i.exec(navigator.userAgent)][0][1] == 6);
    var newbox = document.getElementById(idname);
    newbox.style.zIndex = "9999";
    newbox.style.display = "block"
    newbox.style.position = !isIE6 ? "fixed" : "absolute";
    newbox.style.top = newbox.style.left = "50%";
    newbox.style.marginTop = -newbox.offsetHeight / 2 + "px";
    newbox.style.marginLeft = -newbox.offsetWidth / 2 + "px";
    var layer = document.createElement("div");
    var close = document.getElementById("close_pay");
    layer.id = "layer";
    layer.style.width = layer.style.height = "100%";
    layer.style.position = !isIE6 ? "fixed" : "absolute";
    layer.style.top = layer.style.left = 0;
    layer.style.backgroundColor = "#000";
    layer.style.zIndex = "9998";
    layer.style.opacity = "0.6";
    document.body.appendChild(layer);

    if (isIE) { layer.style.filter = "alpha(opacity=60)"; }
    if (isIE6) {
        layer_iestyle()
        newbox_iestyle();
        window.attachEvent("onscroll", function () {
            newbox_iestyle();
        })
        window.attachEvent("onresize", layer_iestyle)
    }
    close.onclick = function () {
        newbox.style.display = "none";
        layer.style.display = "none";
        window.parent.location.href = config.WebURL + "user/accountrecharge." + config.Suffix;
    }

    return false;
}

function layer_iestyle() {
    layer.style.width = Math.max(document.documentElement.scrollWidth, document.documentElement.clientWidth)
+ "px";
    layer.style.height = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight) +
"px";
}

function newbox_iestyle() {
    newbox.style.marginTop = document.documentElement.scrollTop - newbox.offsetHeight / 2 + "px";
    newbox.style.marginLeft = document.documentElement.scrollLeft - newbox.offsetWidth / 2 + "px";
}

/****** 在线充值相关结束 *********/

/*****************投稿相关**************************/

function chanagediv() {
    if (document.getElementById("IsContributor").checked == false) {
        document.getElementById("IsContributor").checked = false;
        document.getElementById("divIsContributor").style.display = "none";
        document.getElementById("IsContributor").value = 0;
    }
    else {
        document.getElementById("divIsContributor").style.display = "block";
        document.getElementById("IsContributor").checked = true;
        document.getElementById("IsContributor").value = 1;
    }
}

function Ispinglun() {
    var ch = document.getElementById("ispinglun");
    if (ch.checked == true) {
        ch.value = 1;
    }
    else {
        ch.value = 0;
    }
}

function getQueryStringRegExp() {
    var name = "isflag";
    var reg = new RegExp("(^|\\?|&)" + name + "=([^&]*)(\\s|&|$)", "i");
    if (reg.test(location.href)) return unescape(RegExp.$2.replace(/\+/g, " ")); return "";
}

function which() {
    if (getQueryStringRegExp() == 0) {
        document.getElementById("divIsContributor").style.display = "none";
    } else {
        document.getElementById("divIsContributor").style.display = "block";
    }
}

function ch() {
    document.getElementById("ispinglun").checked = true;
}

/******************************投稿结束*********************************/


/******************************修改商业信息*********************************/
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

//招商代理信息类型
function inftype(val) {
    if (val == "sell") {
        $("trq1").style.display = "block";
        $("trq2").style.display = "block";
        $("trq3").style.display = "block";
        $("tro").style.display = "none";
    }
    else {
        $("trq1").style.display = "none";
        $("trq2").style.display = "none";
        $("trq3").style.display = "none";
        $("tro").style.display = "block";
    }
}
function pageInit() {
    var arr = $("tdinfotype").getElementsByTagName("input");

    for (var i = 0; i < arr.length; i++) {
        if (arr[i].type == 'radio') {
            if (arr[i].checked) {
                arr[i].onclick();
                break;
            }
        }
    }

}
/******************************修改商业信息*********************************/

//全选

function SelectAll(objName, obj) {
    var arr = $(objName).getElementsByTagName("input");
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].type == 'checkbox') {
            if (obj.checked)
                arr[i].checked = true;
            else
                arr[i].checked = false;
        }
    }
}

function Delete(objName) {
    var num = 0;
    var arr = $(objName).getElementsByTagName("input");
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].type == 'checkbox') {
            if (arr[i].checked)
                num++;
        }
    }
    if (num == 0) {
        return alertmsg(false, "至少要选择一条记录才能删除！");
    }
    else if (!confirm('确定删除吗？')) {
        return false;
    }
    else {
        try {
            $("isDelete").value = "Delete";
            return true;
            //edit by liujia
        } catch (err) {
            return true;
        }
    }
}
////==========================================================================
////  友情链接 开始
////==========================================================================
function userfirendlinkinfo() {
    if ($("Url").value == "") {
        return alertmsg(false, '网站地址不能为空！');
    }

    if ($("SiteName").value == "") {
        return alertmsg(false, '网站名称不能为空!');
    }
    if ($F("Url").search(/[a-zA-z]+:\/\/[^s]*/) == -1 && $("Url").value != "http:\/\/") {
        return alertmsg(false, '您输入的网址格式有误！');
    }
}

////==========================================================================
////  友情链接 结束
////==========================================================================
//友情链接
function Announceinfo() {
    var centent = document.getElementById('Content').value;
    var len = 0;
    for (var i = 0; i < centent.length; i++) {
        if (centent.charCodeAt(i) > 255) len += 2;

        else len++;
    }
    if (len > 600) {
        return alertmsg(false, '请把字数限制在300字以内！');
    }

}


////==========================================================================
////  控制管理员留言类型标题 开始
////==========================================================================
function UpdateTtile(num) {
    switch (num) {
        case 1:
            document.getElementById('messtitle').value = "[求助]"
            break

        case 2:
            document.getElementById('messtitle').value = "[建议]"
            break

        case 3:
            document.getElementById('messtitle').value = "[投诉]"
            break

        case 4:
            document.getElementById('messtitle').value = "[表扬]"
            break

        case 5:
            document.getElementById('messtitle').value = "[业务联系]"
            break

        case 6:
            document.getElementById('messtitle').value = "[升级会员]"
            break
    }
}
////==========================================================================
////  控制管理员留言类型标题 结束
////==========================================================================


//企业专栏相关Js 开始
function _xy_part_getUserData() {
    var module = $R("modulename");
    var userId = $F("UserId");

    var url = "&module=" + module + "&userid=" + userId + "&isCommend=-1";

    $("_all_info_box").innerHTML = "";

    var ajax = new Ajax("XY040", url);
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            var length = ajax.data.info.length;

            var id = "";
            var title = "";
            var html = "";


            for (var i = 0; i < length; i++) {

                var id = ajax.data.info[i].id;
                var title = ajax.data.info[i].title;

                html += "<input type='checkbox' id='chkUserInfo' value='" + module + ":" + id + "|" + title + "'>" + title + "<br/>";
            }

            $("_all_info_box").innerHTML = html;
        }
        if (ajax.state.result == 0) {
            $("_all_info_box").innerText = "暂无信息！";
        }
    }
}

function _xy_part_addInfo() {
    var chkother = $("_all_info_box").getElementsByTagName("input");
    var num = 0;

    var html = "";
    var temp = "";
    var value = "";

    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].checked == true) {
                num++;
                value = chkother[i].value;

                temp = value.split("|");
                _xy_part_addOne(value, temp[1]);
            }
        }
    }
    if (num == 0) {
        return alertmsg(false, "请选择一条记录！");
    }
}

function _xy_part_addOne(value, title) {
    var chkother = $("_select_info_box").getElementsByTagName("input");

    var html = "";

    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].value == value) return;
        }
    }
    html += "<input type='checkbox' name='chkSelectUserInfo' value='" + value + "'>" + title + "<br/>";
    $("_select_info_box").innerHTML += html;
}


function _xy_part_moveInfo() {
    var chkother = $("_select_info_box").getElementsByTagName("input");

    var html = "";
    var value = "";
    var temp = "";

    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].checked == true) continue;
            value = chkother[i].value;
            temp = value.split("|");

            html += "<input type='checkbox' name='chkSelectUserInfo' value='" + value + "'>" + temp[1] + "<br/>";
        }
    }
    $("_select_info_box").innerHTML = "";
    $("_select_info_box").innerHTML += html;
}

function _xy_part_setTop() {
    var chkother = $("_select_info_box").getElementsByTagName("input");

    var html = "";
    var value = "";
    var temp = "";
    var num = 0;

    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            value = chkother[i].value;
            temp = value.split("|");

            if (chkother[i].checked == true && num < 1) {
                html += "<input type='checkbox' name='chkSelectUserInfo' value='" + value + "'><b>" + temp[1] + "</b><br/>";
                $("_hidTopInfoId").value = value;
                num++;
                continue;
            }
            html += "<input type='checkbox' name='chkSelectUserInfo' value='" + value + "'>" + temp[1] + "<br/>";
        }
    }
    if (num == 0) {
        alertmsg(false, "请从已选择信息中选择一条记录！");
        return;
    }
    $("_select_info_box").innerHTML = "";
    $("_select_info_box").innerHTML = html;
}


function _xy_part_submit() {
    if (!IsUploadFile()) {
        return alertmsg(false, '请上传图片！');
    }

    var chkother = $("_select_info_box").getElementsByTagName("input");

    var html = "";
    var value = "";
    var temp = "";

    var total = 0;
    var topTotal = 0;

    if (chkother.length <= 0) {
        alertmsg(false, "请选择信息！一共可选择8条！");
        return false;
    }

    var topInfo = $("_hidTopInfoId").value;
    if (topInfo != "") topInfo = "|" + topInfo + "|";

    for (var i = 0; i < chkother.length; i++) {
        if (total >= 8) break;

        if (chkother[i].type == 'checkbox') {
            value = chkother[i].value;
            temp = value.split("|");
            total++;

            if (topInfo.indexOf("|" + temp[0] + "|") != -1) {
                topTotal++;
                continue;
            }

            if (html == "")
                html = value;
            else
                html += "$" + value;
        }
    }

    if (total < 8) {
        alertmsg(false, "信息条数不够(一共可选择8条)！请继续选择！");
        return false;
    }

    if (topTotal != 1) {
        alertmsg(false, "请选择一条信息为头条！");
        return false;
    }


    $("_hidInfoIds").value = html;

    return true;
}

function _xy_part_initPage() {
    var infoIds = $("_infoIds").value;

    if (infoIds == "") return;

    var ids = infoIds.split("$");

    var html = "";

    $("_hidTopInfoId").value = ids[0];

    $("_hidInfoIds").value = infoIds.substr(infoIds.indexOf("$") + 1, infoIds.length - infoIds.indexOf("$"));

    for (var i = 0; i < ids.length; i++) {
        var temp = ids[i].split("|");

        if (i == 0)
            html += "<input type='checkbox' name='chkSelectUserInfo' value='" + ids[i] + "'><b>" + temp[1] + "</b><br/>";
        else
            html += "<input type='checkbox' name='chkSelectUserInfo' value='" + ids[i] + "'>" + temp[1] + "<br/>";
    }

    $("_select_info_box").innerHTML = "";
    $("_select_info_box").innerHTML = html;
}
//企业专栏相关Js结束


////======================================================================
////购买类别黄金广告验证
////======================================================================

function buy_classad_1_Check() {
    if (document.getElementById("timecycle").value == "") {
        return alertmsg(false, '购买时间不能为空！');
    }

    if (document.getElementById("txtLink").value == "") {
        return alertmsg(false, '广告链接地址不能为空');
    }
    var str = document.getElementById("txtLink").value;

    //下面的代码中应用了转义字符"\"输出一个字符"/"
    var Expression = /http(s)?:\/\/([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?/;
    var objExp = new RegExp(Expression);

    if (objExp.test(str) == false) {
        return alertmsg(false, '广告链接地址格式不正确！');
    }
    if (document.getElementById("txtDesc").value == "") {
        return alertmsg(false, '广告描述不能为空');
    }
    return true;
}

////======================================================================
////z自定义排名验证
////======================================================================
function _xy_part_checkUserDefined() {
    if (document.getElementById("title").value == "") {
        return alertmsg(false, '信息标题不能为空！');
    }

    if (document.getElementById("link").value == "") {
        return alertmsg(false, '链接地址不能为空！');
    }
    var str = document.getElementById("link").value;

    //下面的代码中应用了转义字符"\"输出一个字符"/"
    var Expression = /http(s)?:\/\/([\w-]+\.)+[\w-]+(\/[\w- .\/?%&=]*)?/;
    var objExp = new RegExp(Expression);

    if (objExp.test(str) == false) {
        return alertmsg(false, '链接地址格式不正确！');
    }
    if (document.getElementById("desc").value == "") {
        return alertmsg(false, '详细内容不能为空');
    }
    var a = document.getElementById("desc").value.length;
    if (a > 100) {
        return alertmsg(false, '请检查您详细内容字数');
    }
    return true;
}

////==========================================================================
////点击类别树的js
////==========================================================================

function expran(ename, fullid) {
    if (fullid.indexOf(",") != -1) {
        fullid = fullid.substr(1);
    }
    var ids = fullid.split(",");
    LabelClassDisplay2(ename, ids.shift(), "", ids);
}

function LabelClassDisplay2(moduleName, infoid, split, ids) {
    if (infoid != "" && infoid != "0") {
        var obj = $("li_" + infoid);
        if (obj != null && "none" == obj.style.display) {
            $("lithis" + infoid).getElementsByTagName("img")[0].src = config.WebURL + "common/images/bg_spread.gif";
            obj.style.display = "block";
            var ul = obj.getElementsByTagName("ul")[0];
            ul.innerHTML = "<li>正在加载……</li>";
            //ajax 调用
            var ajax = new Ajax("xy082", "&moduleName=" + moduleName + "&infoid=" + infoid);
            ajax.onSuccess = function () {
                if (ajax.state.result == 1) {
                    ul.innerHTML = "";
                    if (null != ajax.data) {
                        for (i = 0; i < ajax.data.Item.length; i++) {
                            var id = ajax.data.Item[i].ID;
                            var hasSub = ajax.data.Item[i].HasSub;
                            var typeName = unescape(ajax.data.Item[i].Name);
                            var lithis = document.createElement("li");
                            lithis.id = "lithis" + id;
                            var split2 = split + "&nbsp;&nbsp;&nbsp;&nbsp;";
                            var html = split2;
                            config.Suffix
                            if (hasSub == "true") {
                                html += "<a href=\"javascript:LabelClassDisplay2('" + moduleName + "'," + id + ",'" + split2 + "');\"><img src=\"/common/images/bg_shrink.gif\" /></a>";
                                html += "<img src=\"/common/images/folders.gif\" /><a href=\"buyclassads." + config.Suffix + "?classid=" + id + "\">" + typeName + "</a>";
                            }
                            else {
                                html += "<img src=\"/common/images/bg_spread.gif\" />";
                                html += "<img src=\"/common/images/folder.gif\" /><a href=\"buyclassads." + config.Suffix + "?classid=" + id + "\">" + typeName + "</a>";
                            }

                            lithis.innerHTML = html;
                            ul.appendChild(lithis);

                            if (hasSub == "true") {
                                var li_ = document.createElement("li");
                                li_.id = "li_" + ajax.data.Item[i].ID;
                                li_.style.display = "none";
                                li_.innerHTML = "<ul/>";
                                ul.appendChild(li_);
                            }
                        }
                        if (!(ids == undefined || ids == null || ids.length < 1)) {
                            id = ids.shift();
                            if (id != "" && id != 0) {
                                LabelClassDisplay2(moduleName, id, split2, ids);
                                split2 += "&nbsp;&nbsp;&nbsp;&nbsp;";
                            }
                        }
                    }
                }
            }
        }
        else {
            $("lithis" + infoid).getElementsByTagName("img")[0].src = config.WebURL + "common/images/bg_shrink.gif";
            obj.style.display = "none";
        }
    }
}

/******用户资讯管理********/
function IsSelectInfo() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('sd_id') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                }
            }
        }
    }

    if (j == 0) {
        sAlert("请至少选择一条信息！", "", true);
        return false;
    }
}

function IsNum(str) {

    var re = /^[\d]+$/
    return re.test(str);

}
function CheckValuebuy() {
    var title = document.getElementById("title").value;
    var keyword = document.getElementById("keyword").value;
    var num = document.getElementById("num").value;

    var contents =  document.getElementById("contents").value;
    var linkman = document.getElementById("linkman").value;

    var tel = document.getElementById("tel").value;
    var jinji;

    if (title == "") {
        return alertmsg(false, '请输入求购标题！');
    }
    if (keyword == "") {
        return alertmsg(false, '请输入产品关键字');
    }

    if (!IsNum(num)) return alertmsg(false, '产品数量为数字！');

    if (contents == "") return alertmsg(false, '产品要求不能为空！');

    if (linkman == "") return alertmsg(false, '请输入联系人姓名！');

    if (tel == "") return alertmsg(false, '请输入联系电话！');
    return true;
}