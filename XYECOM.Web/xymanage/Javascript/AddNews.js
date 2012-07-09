function ClearSelect() {
    var chkother = document.getElementsByTagName("input");

    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                chkother[i].checked = false;
            }
        }
    }
}

function GetSelectIds() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    var ids = "";
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkExport') > -1) {
                if (chkother[i].checked == true) {
                    j++;
                    if (ids == "")
                        ids = chkother[i].value;
                    else
                        ids += "," + chkother[i].value;
                }
            }
        }
    }

    return ids;
}
function ShowTopicPageForToTopioc() {
    var ids = GetSelectIds();

    if (ids == "") {
        sAlert("请至少选择一条记录！", "", true);
        return;
    }
    $("SelTopicType").src = "TopicTypeList.aspx?mode=list&ids=" + ids;
    //$("SelTopicType").src = $("SelTopicType").src + "&ids=" + ids;

    ShowTopicType();
}

function ShowTopicType() {
    var dWidth = 400;
    var dHeight = 300;
    var scrollPos = new getScrollPos();
    var pageSize = new getPageSize();

    $("SelTopicType_bg").style.display = "block";
    $("SelTopicType_bg").style.height = (pageSize.height + scrollPos.scrollY) + "px";
    $("SelTopicType").style.display = "block";

    var x = Math.round(pageSize.width / 2) - (dWidth / 2) + scrollPos.scrollX;
    var y = Math.round(pageSize.height / 2) - (dHeight / 2) + scrollPos.scrollY;
    $("SelTopicType").style.width = dWidth + "px";
    $("SelTopicType").style.height = dHeight + "px";
    $("SelTopicType").style.left = x + 'px';
    $("SelTopicType").style.top = y + 'px';
    if (!IE()) {
        $("SelTopicType").TopicTypeInit();
    }
    else {
        $("SelTopicType").contentWindow.TopicTypeInit();
    }
}

function CloseTopicType() {
    $("SelTopicType_bg").style.display = "none";
    $("SelTopicType").style.display = "none";
}

function TopicTypeInit() {
    var objid = $("seltopictypelist").getElementsByTagName("input");
    var objname = $("seltopictypelist").getElementsByTagName("span");
    var objparentid = parent.$("hidTopicID");
    var objparentname = parent.$("topicnames");

    var arrid = objparentid.value.split(",");
    var tmpname = "";
    for (var i = 0; i < objid.length; i++) {
        for (var j = 0; j < arrid.length; j++) {
            if (objid[i].value == arrid[j]) {
                objid[i].checked = true;
                tmpname += " &nbsp; " + objname[i].innerHTML;
            }
        }
    }
    objparentname.innerHTML = tmpname;
}
function TopicTypeInsert() {
    var objid = $("seltopictypelist").getElementsByTagName("input");
    var objname = $("seltopictypelist").getElementsByTagName("span");
    var objparentid = parent.$("hidTopicID");
    var objparentname = parent.$("topicnames");

    var ids = "";
    var names = "";
    for (var i = 0; i < objid.length; i++) {
        if (objid[i].checked) {
            ids += "" == ids ? "" : ",";
            ids += objid[i].value;
            names += " &nbsp; " + objname[i].innerHTML;
        }
    }
    objparentid.value = ids;
    objparentname.innerHTML = names;
    parent.CloseTopicType();
}

//绑定不同类型
function TypeChange() {
    if (document.getElementById("rbcommonnews").checked == true) {

        document.getElementById("TR1").style.display = "none";
        document.getElementById("TR9").style.display = "none";
        document.getElementById("TR3").style.display = "";
        document.getElementById("TR4").style.display = "";
        document.getElementById("TR5").style.display = "";
        document.getElementById("TR7").style.display = "none";
        document.getElementById("TD1").style.display = "none";
        document.getElementById("rbpicurl").checked = false;
        document.getElementById("rbpicupload").checked = false;
    }

    if (document.getElementById("rbpicnews").checked == true) {

        document.getElementById("TR1").style.display = "none";
        document.getElementById("TR3").style.display = "";
        document.getElementById("TR4").style.display = "";
        document.getElementById("TR5").style.display = "";
        document.getElementById("TD1").style.display = "";
        document.getElementById("TR7").style.display = "";
        document.getElementById("TR9").style.display = "";
        if (document.getElementById("hdpicurl").value != "")
            document.getElementById("imgsrc").src = document.getElementById("hdpicurl").value;
    }

    if (document.getElementById("rbcaptionnews").checked == true) {
        document.getElementById("TR1").style.display = "";
        document.getElementById("TR3").style.display = "none";
        document.getElementById("TR4").style.display = "none";
        document.getElementById("TR5").style.display = "none";
        document.getElementById("TD1").style.display = "";
        document.getElementById("TR7").style.display = "";


        document.getElementById("rbpicurl").checked = false;
        document.getElementById("rbpicupload").checked = false;

        if (document.getElementById("hdpicurl").value != "") {
            document.getElementById("imgsrc").src = document.getElementById("hdpicurl").value;
            document.getElementById("rbpicurl").checked = true;
        }
    }

}

// 页面加载JS
function ChangePicType() {
    $("file22").className = "filebgcolor";
    if (document.getElementById("rbpicurl").checked == true) {

        document.getElementById("TR8").style.display = "block";
        document.getElementById("TR9").style.display = "none";
    }
    else if (document.getElementById("rbpicupload").checked == true) {
        document.getElementById("TR8").style.display = "none";
        document.getElementById("TR9").style.display = "block";
    }

    if (document.getElementById("rbpicurl").checked == false && document.getElementById("rbpicupload").checked == false) {
        document.getElementById("rbpicupload").checked = true;
    }




}

// 图片预览JS
function PreviewImage(num) {
    if (num == "1") {
        if (document.getElementById("tbpinurl").value != "") {
            if (document.getElementById("tbpinurl").value.search(/^http:\/\//) == -1) {
                return alertmsg('图片链接地址格式错误，请重新输入.', '', false);
            }

            var value = GetPicType(document.getElementById("tbpinurl").value);
            if (value == true) {
                if (document.getElementById("rbpicurl").checked == true && document.getElementById("tbpinurl").value != null)
                    ;
                else
                    return alertmsg('图片输入方式或链接地址有误', '', false);
            }
            else {
                document.getElementById("tbpinurl").focus();
                return alertmsg('图片链接格式错误,正确的格式为:' + document.getElementById("imagetype").value + ',请重新输入地址.', '', false);
            }
        }
    }
    if (num == '2') {
        if (document.getElementById("FileUpload").value != "") {
            var value = GetPicType(document.getElementById("FileUpload").value);
            if (value == true) {
                if (document.getElementById("rbpicupload").checked == true && document.getElementById("FileUpload").value != null)
                    document.getElementById("imgPreview").filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = document.getElementById("FileUpload").value;
                else
                    return alertmsg('图片输入方式或链接地址有误', '', false);
            }
            else {
                return alertmsg('图片格式错误,正确的格式为:' + document.getElementById("imagetype").value + ',请重新输入地址.', '', false);
            }
        }
    }
}

// JS验证图片后缀名 
function GetPicType(varpic) {
    if (varpic != "" && varpic != null) {
        var temp = varpic.split('.');
        var len = temp.length;
        var fileExt = temp[len - 1].toLowerCase();
        var type = new Array();
        if (document.getElementById("imagetype").value != "" || document.getElementById("imagetype").value != null) {
            type = document.getElementById("imagetype").value.split(';');
            for (var i = 0; i < type.length; i++) {
                var j = 0;
                j = fileExt.indexOf(type[i]);
                if (j >= 0) {
                    return true;
                    continue;
                }
            }
            return false;
        }
        return true;
    }
    else
        return false;
}

//提交时验证
function Input() {
    var newsBody = FCKeditorAPI.GetInstance('newsBody').GetXHTML(true);
    if (!document.getElementById("rbcaptionnews").checked && newsBody == "") {
        return alertmsg('新闻正文不能为空', '', false);
    }

    if (document.getElementById("rbcommonnews").checked == false && document.getElementById("rbpicnews").checked == false && document.getElementById("rbcaptionnews").checked == false) {
        return alertmsg('新闻类型至少选择一种类型.', '', false);
    }

    if (document.getElementById("tbnewsname").value == "") {
        return alertmsg('新闻标题不能为空.', '', false);
    }

    if (document.getElementById("hdgetid").value == "") {
        return alertmsg("请先选择新闻栏目.", '', false);
    }
    if (document.getElementById("rbcaptionnews").checked == true) {
        if (document.getElementById("tblinkaddress").value == "") {
            return alertmsg('你已选择标题新闻,链接地址不能为空.', '', false);
        }

        if (document.getElementById("tblinkaddress").value.search(/^http:\/\//) == -1) {
            return alertmsg('链接地址格式有误,请重新输入.', '', false);
        }
    }
    
    if (document.getElementById("rbpicnews").checked == true || document.getElementById("rbcaptionnews").checked == true) {
        if (document.getElementById("rbpicnews").checked == true && document.getElementById("rbpicurl").checked == false && document.getElementById("rbpicupload").checked == false) {
            return alertmsg('请选择图片URL或上传图片.', '', false);
        }
      
        if (document.getElementById("rbpicurl").checked == true) {
            if (document.getElementById("tbpinurl").value == "") {
                return alertmsg('你已选择图片链接,请输入链接地址.', '', false);
            }

            if (document.getElementById("tbpinurl").value.search(/^http:\/\//) == -1) {
                return alertmsg('链接地址格式错误，请重新输入.', '', false);
            }
        }
       
        if (document.getElementById("rbpicupload").checked == true) {
            if (!IsUploadFile()) {
                return alertmsg('你已选择上传图片,请选择上传的图片.', '', false);
            }
        }
    }

    if (document.getElementById("cbIsScheme").checked == true) {
        if (!document.getElementById("HidItemStr").value.length > 0)
            return alertmsg('你已选择资讯类型为方案式采购,请选择相关产品.', '', false);
    }
    if (document.getElementById("HidItemStr").value.length > 0) {
        if (!document.getElementById("cbIsScheme").checked == true)
            return alertmsg('你已选择相关产品,请选择此资讯类型为方案式采购.', '', false);
    }
}

//是否数字
function IsNum() {
    var txt = document.getElementById("tbcount").value;
    if (checknumber(txt)) {
        return alertmsg('只允许输入数字.', '', false);
    }
    return true;
}

//是否数字验证
function checknumber(string) {
    var letters = "1234567890";
    var i;
    var c;
    for (i = 0; i < string.length; i++) {
        c = string.charAt(i);
        if (letters.indexOf(c) == -1) {
            return true;
        }
    }
    return false;
}
//获得新闻作者
function getauthor() {
    if (document.getElementById("ddlnewsauthor").value != "") {
        document.getElementById("tbnewsauthor").value = document.getElementById("ddlnewsauthor").value;
    }
}

//获得新闻来源
function getorigin() {
    if (document.getElementById("ddlnewsorigin").value != "") {
        document.getElementById("tbnewsorigin").value = document.getElementById("ddlnewsorigin").value;
    }
}



//页面初始时绑定类型
function AddNewsPageInit() {
    TypeChange();
    ChangePicType();

    if (document.getElementById("rbpicurl").checked == false && document.getElementById("rbpicupload").checked == false) {
        document.getElementById("rbpicupload").checked = true;
    }
}



/******************************  资讯栏目相关  *******************************/
function ChangeCheckBox() {
    if (document.getElementById("cbdomain").checked) {
        document.getElementById("chkSubChannelAutoInherit").checked = true;
    }
}

function ChangeTxt() {
    if (document.getElementById("txtTemplate").value == "") {
        document.getElementById("txtTemplate").value = document.getElementById("txtDomain").value;
    }
}


function checkload(num) {
    if (num == "1") {
        document.getElementById("file22").style.display = "block";
        document.getElementById("file23").style.display = "none"
        $("file22").className = "filebgcolor";

        $("rbfileUpload").className = "usertype";
        $("rbfileUrl").className = "cur_usertype";
    }
    else if (num == "2") {
        document.getElementById("file23").style.display = "block";
        document.getElementById("file22").style.display = "none";
        $("file23").className = "filebgcolor";
        $("rbfileUpload").className = "cur_usertype";
        $("rbfileUrl").className = "usertype";
    }

}

/********Scheme*****20110524 jerome****/
function ShowInfo() {
    var dWidth = 800;
    var dHeight = 390;
    var scrollPos = new getScrollPos();
    var pageSize = new getPageSize();

    $("SelInfo_bg").style.display = "block";
    $("SelInfo_bg").style.height = (pageSize.height + scrollPos.scrollY) + "px";
    $("SelInfo").style.display = "block";

    var x = Math.round(pageSize.width / 2) - (dWidth / 2) + scrollPos.scrollX;
    var y = Math.round(pageSize.height / 2) - (dHeight / 2) + scrollPos.scrollY;
    $("SelInfo").style.width = dWidth + "px";
    $("SelInfo").style.height = dHeight + "px";
    $("SelInfo").style.left = x + 'px';
    $("SelInfo").style.top = y + 'px';

    $("SelInfo").src = "/XYManage/news/AddNewsInfoList.aspx";

}

function CloseInfo() {
    $("SelInfo_bg").style.display = "none";
    $("SelInfo").style.display = "none";
}


function Selectchange(ChangeId) {
    var arr = $("infos").getElementsByTagName("input");
    var arrName = $("infos").getElementsByTagName("Label");
    var str = "";
    var objdiv = $("infos");
    var objHidSelIds = $("SelectinfoIds");
    var NewStr = "";
    var NewSelectedStr = "";
    var objhidItemStr = $("HidItemStr");
    var hidItemStrarry = objhidItemStr.value.split(",");

    for (var i = 0; i < arr.length; i++) {
        if (arr[i].type == "checkbox") {
            if (parseInt(arr[i].value) == parseInt(ChangeId)) {
                arr[i].checked = false;
                break;
            }
        }
    }

    for (var i = 0; i < arr.length; i++) {
        if (arr[i].checked) {
            str += "<input checked='checked' onclick=\"Selectchange('" + arr[i].value + "')\" type='checkbox' id='cbsel_" + arr[i].value + "' value='" + arr[i].value + "'/><Label>" + arrName[i].outerText + "</Label>";
        }
    }

    for (var i = 0; i < hidItemStrarry.length; i++) {
        var HIA = hidItemStrarry[i].split(':');
        if (HIA[0] != ChangeId)
            NewStr += hidItemStrarry[i] + ",";
    }
    objhidItemStr.value = NewStr.substring(0, NewStr.length - 1);
    objdiv.innerHTML = str;
}