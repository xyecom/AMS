/*=================================  (Old) Ajax Start =========================================
* �޸ı�ʶ:Tc 20080707
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
        sAlert("������ѡ��һ����¼��", "", true);
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
        sAlert("������ѡ��һ����¼��", "", true);
        return false;
    }
    else {
        return confirm("ȷ��ɾ����");
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
        return alertmsg('����ѡ��һ����¼�����޸ģ�', '', false);
    }
    else if (j > 1) {
        return alertmsg('����ͬʱ�޸Ķ�����¼��', '', false);
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
        return alert('����ѡ��һ����¼�����Ƽ���', '', false);
    }
}


function QueryString() {
    //����������󲢳�ʼ�� 
    var name, value, i;

    // var str = location.href;//����������ַ��URL�� 
    // var num = str.indexOf("?") 
    //str = str.substr(num+1);//��ȡ��?������Ĳ����� 
    var str = location.search.substr(1);

    var arrtmp = str.split("&"); //�������������γɲ������� 
    for (i = 0; i < arrtmp.length; i++) {
        var num = arrtmp[i].indexOf("=");
        if (num > 0) {
            name = arrtmp[i].substring(0, num).toLowerCase(); //ȡ�ò������� 
            value = arrtmp[i].substr(num + 1); //ȡ�ò���ֵ 
            this[name] = value; //����������Բ���ʼ�� 
        }
    }
}
var objRequest = new QueryString(); //ʹ��new�����������������ʵ�� 

/**
=====================================����SEO��Ϣ ��ʼ================================================
**/
//��������
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

//�����ؼ��ʵ���
function addkeyword() {
    if ($("txtname").value == "") {
        return alertmsg('�ؼ��ֲ���Ϊ�գ�', '', false);
    }
    else if ($("txturl").value == "") {
        return alertmsg('���ӵ�ַ����Ϊ�գ�', '', false);
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

//��ʾ��ӹؼ��ʵ�����Ӳ�
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

//��ʼ���ؼ��ֵ�����Ϣ
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
=====================================����SEO��Ϣ ����================================================
**/
/**
=====================================��ǩ���� ��ʼ================================================
**/
//ѡ���ǩ��ʽ���
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
//��ʼ��
function InitListBox() {
    if ($("hidTableName").value != "") {
        selecttablename($("hidTableName").value)
    }
}

//ѡ���ǩ��ʽ
//2008-6-3 update By �K������
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

//��ӱ�ǩ
function AddLabel() {
    if ($("tbName").value == "") {
        return alertmsg('���Ʋ���Ϊ�գ�', '', false);
    }
    if ($("hidLT_ID").value == "") {
        return alertmsg('��ѡ��������Ŀ��', '', false);
    }

    if ($("rbtnSystem").checked) {
        $("hidUserIds").value = "";
        $("hidGroupIds").value = "";
    }

    if ($("rbtnUser").checked) {
        if ($F("hidUserIds") == "") {
            return alertmsg('��ѡ���ǩ�����û���', '', false);
        }
    }

    if ($("rbtnUserGroup").checked) {
        if ($F("hidGroupIds") == "") {
            return alertmsg('��ѡ���ǩ�������û��飡', '', false);
        }
    }

    if ($("tbContent").value == "") {
        return alertmsg('��ǩ���ݲ���Ϊ�գ�', '', false);
    }

    if ($("txtConent").value == "") {
        return alertmsg('����ѭ����ǲ���Ϊ�գ�', '', false);
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

//�����Ƿ���ʾ 
//08-06-24 Add By�K������
function IsDisplaySelect(value) {
    var num1 = (value.indexOf("$")) + 1;
    var num2 = value.indexOf("��");
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

            //��ʱ����
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

//��������ģ̬����
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

//��ȡѡ�����Ѷ��Ŀ
function lselectnewtype() {
    $("hidPT_ID").value = $("newstitleids").value;
}

//��ȡѡ�����ҵ���
function lselectusertype() {
    $("hidPT_ID").value = $("companytypeids").value;
}

//�رձ�ǩ��
function closewindows() {
    parent.$("Div_window").style.display = "none";
    parent.$("window").style.display = "none";
}

//��֤��Ϣ��ǩ����
function isNumer(obj) {
    if (obj.value != "") {
        if (obj.value.search(/^[-\+]?\d+$/) == -1) {
            obj.value = "";
            return alertmsg("����Ĳ������֣�", '', false);
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

//��Ϣ��ǩ����
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
=====================================��ǩ���� ����================================================
**/

//����ԱȨ�����
function AdminAdd() {
    if ($("ddlRose").value == "-1") {
        return alertmsg('��ѡ��Ҫ��ӵĽ�ɫ!', '', false);
    }
    if ($("txtName").value == "") {
        return alertmsg('��½�û���������д!', '', false);
    }
    if ($("txtName").value.length < 4) {
        return alertmsg('��½�û������Ȳ���С��4���ַ�!', '', false);
    }
    if ($("txtPwd").value == "") {
        return alertmsg('���벻��Ϊ��!', '', false);
    }
    if ($("txtPwd").value.length < 6) {
        return alertmsg('Ϊ�������ʻ���ȫ,���볤�Ȳ���С��6���ַ�!', '', false);
    }
    if ($("txtPwd2").value == "") {
        return alertmsg('���ڴ���������!', '', false);
    }
    if ($("txtPwd").value != $("txtPwd2").value) {
        return alertmsg('�����������벻һ��,���������!', '', false);
    }
}
//����ԱȨ���޸�
function AdminEdit() {
    if ($("ddlUpdate").value == "-1") {
        return alertmsg('��ѡ���ɫ!', '', false);
    }

    if ($F("txtYuanPwd").trim() != "") {
        if ($F("txtNewPwd").trim() == "") {
            return alertmsg('������������!', '', false);
        }
        if ($F("txtOKpwd").trim() == "") {
            return alertmsg('���ڴ���������!', '', false);
        }
        if ($F("txtNewPwd").trim() != $F("txtOKpwd").trim()) {
            return alertmsg('�����������벻һ��,���������!', '', false);
        }
    }
}



//��ӽ�ɫ
function roleadd() {
    if ($("txtName").value == "") {
        return alertmsg('�������ɫ���ƣ�', '', false);
    }
}
//�޸Ľ�ɫ
function roleedit() {
    if ($("TextBox1").value == "") {
        return alertmsg('�������ɫ���ƣ�', '', false);
    }
}



//�û��ȼ�����ʼ
function usergradeadd() {
    if ($("txtName").value == "") {
        return alertmsg('�û��ȼ���������д��', '', false);
    }
    if ($("ymoney").value == "") {
        return alertmsg('�����������', '', false);
    }

    if ($("mmoney").value == "") {
        return alertmsg('�����������', '', false);
    }

    if ($("ymoney").value.search(/^[0-9]+$/) != -1 || $("ymoney").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("ymoney").value = Math.round(parseFloat($("ymoney").value) * 100) / 100
    }
    else {
        return alertmsg('����������ʽ����\n ����88.88', '', false)
    }

    if ($("mmoney").value.search(/^[0-9]+$/) != -1 || $("mmoney").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("mmoney").value = Math.round(parseFloat($("mmoney").value) * 100) / 100
    }
    else {
        return alertmsg('�����������ʽ����\n ����88.88', '', false)
    }
}
function usergradeedit() {

    if ($("txtname1").value == "") {
        return alertmsg('�û��ȼ���������д!', '', false);
    }

    if ($("mmoney1").value == "") {
        return alertmsg('�����������', '', false);
    }
    if ($("ymoney1").value == "") {
        return alertmsg('�����������', '', false);
    }

    if ($("ymoney1").value.search(/^[0-9]+$/) != -1 || $("ymoney1").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("ymoney1").value = Math.round(parseFloat($("ymoney1").value) * 100) / 100
    }
    else {
        return alertmsg('����������ʽ����\n ����88.88', '', false)
    }
    if ($("mmoney1").value.search(/^[0-9]+$/) != -1 || $("mmoney1").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/) != -1) {
        $("mmoney1").value = Math.round(parseFloat($("mmoney1").value) * 100) / 100
    }
    else {
        return alertmsg('�����������ʽ����\n ����88.88', '', false)
    }
}
//�û��ȼ�����ʼ����


//������Ϣ��ʼ
function FinanceInfo() {

    if ($("ddlRose").value == "-1") {
        return alertmsg('ѡ��������ͣ�', '', false);
    }
    if ($("txtName").value == "") {
        return alertmsg('�����������ã�', '', false);
    }
    //    else 
    //	{   
    //        IsFloat($("txtName"))
    //     }    
    if ($("txtuser").value == "") {
        return alertmsg('�������û�������', '', false);
    }
}
function FinanceInfoEdit() {
    if ($("ddlUpdate").value == "-1") {
        return alertmsg('ѡ��������ͣ�', '', false);
    }

    if ($("txtuser1").value == "") {
        return alertmsg('�������û�������', '', false);
    }
    if ($("txtNewPwd").value == "") {
        return alertmsg('�����������ã�', '', false);
    }
    else {
        IsFloat($("txtName"))
    }
}
//������Ϣ����


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



//�������ʼ
function FinanceTypeAdd() {
    if ($("txtName").value == "") {
        return alertmsg('������������', '', false);
    }
}
function FinanceTypeedit() {
    if ($("name").value == "") {
        return alertmsg('������������', '', false);
    }
}
//�������ͽ���




//֧����ʽ��ʼ
function paymathodadd() {
    if ($("txtName").value == "") {
        return alertmsg('֧����ʽ������д��', '', false);
    }
    if ($("remark").value == "") {
        return alertmsg('��ע������д��', '', false);
    }
}
function paymathodedit() {
    if ($("txtUpdate").value == "") {
        return alertmsg('֧����ʽ������д��', '', false);
    }
    if ($("remark1").value == "") {
        return alertmsg('��ע������д��', '', false);
    }
}


//֧����ʽ����
//��Ʒ������
function ProductAdd() {
    if ($("txtName").value == "") {
        return alertmsg('�������Ʒ���', '', false);
    }
}
//��Ʒ����޸�
function Productedit() {
    if ($("txtName").value == "") {
        return alertmsg('�������Ʒ���', '', false);
    }
}

//���������
function ServerAdd() {
    if ($("txtName").value == "") {
        return alertmsg('���������Ʊ�����д��', '', false);
    }
    if ($("serverpath").value == "") {
        return alertmsg('����������·��������д��', '', false);
    }
    if ($("serversul").value == "") {
        return alertmsg('����������·��������д��', '', false);
    }
}
//�������޸�
function ServerEdit() {
    if ($("txtname1").value == "") {
        return alertmsg('���������Ʊ�����д��', '', false);
    }
    if ($("serverpath1").value == "") {
        return alertmsg('����������·��������д��', '', false);
    }
    if ($("serversul1").value == "") {
        return alertmsg('����������·��������д��', '', false);
    }
}
//��ӽ�ɫ
function addrole() {
    if ($("txtName").value == "") {
        return alertmsg('�������ɫ���ƣ�', '', false);
    }
}
//�޸Ľ�ɫ 
function editrole() {
    if ($("TextBox1").value == "") {
        return alertmsg('�������ɫ���ƣ�', '', false);
    }
}


//�û������޸�

function usertypeedit() {
    if (document.getElementById("txtName").value == "") {
        return alertmsg('�������û�������ƣ�', '', false);
    }
}


//��λ�����Ϣ���޸�
function postadd() {
    if ($("txtName").value == "") {
        return alertmsg('�������λ���ƣ�', '', false);
    }
}
function postedit() {
    if ($("Textbox1").value == "") {
        return alertmsg('�������λ���ƣ�', '', false);
    }
}
//��λ�����Ϣ���޸�


//�����ֹ���
function keywordadd() {
    if ($("txtName").value == "") {
        return alertmsg('��������������ƣ�', '', false);
    }
}
function keywordedit() {
    if ($("TextBox1").value == "") {
        return alertmsg('���������������', '', false);
    }
}
//�����ֹ���


//�û��ȼ�����
function CheckUserGradePopedmoSetting() {
    if ($("refashtime").value == "") {
        return alertmsg('ˢ��ʱ�䲻��Ϊ�գ�', '', false)
    }
    if ($("refashnum").value == "") {
        return alertmsg('����дһ�������ˢ�µĴ�����', '', false)
    }
    if ($("refashnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('ˢ�´���ֻ��Ϊ������', '', false);
    }
    if ($("seecontactsnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('�鿴��ϵ��ʽ����ֻ����������', '', false);
    }
    if ($("uploadpicnum").value == "") {
        return alertmsg('�ϴ�ͼƬ����������Ϊ�գ�', '', false);
    }
    if ($("uploadpicnum").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('�ϴ�ͼƬ������ֻ����������', '', false);
    }
    if ($("LimitDate").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('�޶�������ֻ����������', '', false);
    }
    if ($("refashtimes").value == "") {
        return alertmsg('ˢ�¼�¼��������Ϊ�գ�', '', false);
    }
    if ($("refashtimes").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('ˢ�¼�¼����ֻ��Ϊ����!', '', false);
    }

    if ($("ddldebaseusergrade").value == "-1") {
        return alertmsg('��ѡ��õȼ��û����ں����������ļ���', '', false);
    }
    var writenum = document.getElementsByTagName("input");
    var str = "";
    for (var i = 0; i < writenum.length; i++) {
        if (writenum[i].type == 'text') {
            if (writenum[i].id.indexOf('messagevalue') > -1) {
                if (writenum[i].value == "" || writenum[i].value.search(/^[-\+]?\d+$/) == -1) {
                    return alertmsg('����д��������Ŀ�����ұ���Ϊ����!', '', false);
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


//��½
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
        return alertmsg('�û�������Ϊ��,�������û�����', '', false);
    }
    else if ($("txtPassWord").value == "") {
        return alertmsg('���벻��Ϊ��,���������룡', '', false);
    }
    else if ($("txtCode").value == "") {
        return alertmsg('��������֤�꣡', '', false);
    }
    else {
        return true;
    }
}


//���͵����ʼ�
function EmailAdd() {
    if ($("lbtitle").value == "") {
        return alertmsg('���������д��', '', false);
    }
    if ($("lbcontent").value.length < 0) {
        return alertmsg('���ݱ�����д��', '', false);
    }
}
function search() {
    if ($("TextBox1").value == "") {
        return alertmsg('�����빫˾���ƣ�', '', false);
    }
}


//��ֵ��Ϣ
function getinputmoney() {
    //    if ($("ddlRose").value == "-1") {
    //        return alertmsg('��ѡ���ֵ��ʽ', '', false)
    //    }
    //    if ($("dfinance").value == "-1") {
    //        return alertmsg('��ѡ��������', '', false)
    //    }
    if ($("txtmoney").value == "") {
        return alertmsg('�������ֵ���', '', false)
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
        return alertmsg('������Ϸ��ĸ�����.', '', false);
    }
}

//�޸��ʼ���Ϣ
function EditEmail() {
    if ($("lbtitle").value == "") {
        return alertmsg('�����������Ϣ��', '', false);
    }
    if ($("lbcontent").value.length < 0) {
        return alertmsg('������������Ϣ��', '', false);
    }
}
/**
 
=====================================���ܲ˵� ��ʼ================================================
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
=====================================���ܲ˵� ����================================================
**/



/**
=====================================�Զ����ֶ� ��ʼ================================================
**/

function FiledSelTop(ckobj, typeID, showDiv) {
    if (ckobj.checked) {
        $(showDiv).innerHTML = "";
        $(showDiv).style.display = "none";
        return true;
    }
    if ("" == $F(typeID) || "0" == $F(typeID)) {
        sAlert("����ѡ�����");
        return false;
    }
    var ajax = new Ajax("xy037", "&typeid=" + $F(typeID) + "&modulename=" + $F("ddlmodule"))
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            $(showDiv).style.display = "block";
            if (ajax.data) {
                var html = "��ѡ��Ҫ�̳е��ֶΣ�<br /><ul>";
                for (var i = 0; i < ajax.data.filedItem.length; i++) {
                    html += "<li><input type=\"checkbox\" id=\"topfiled" + i + "\" name=\"topfiled\" value=\"" + ajax.data.filedItem[i].id + "\" /><label for=\"topfiled" + i + "\">" + ajax.data.filedItem[i].name + "</label></li>";
                }
                html += "</ul>";
                $(showDiv).innerHTML = html;
            }
            else {
                $(showDiv).innerHTML = "û����Ҫ�̳е��ֶ�";
            }
        }
        else {
            sAlert("�����಻��Ҫ�̳У�");
            ckobj.checked = true;
            $(showDiv).innerHTML = "";
            $(showDiv).style.display = "none";
        }
    }
}

var addnum = 1;
var htmlArray = new Array();

function addline() {
    htmlArray[0] = '<td><input  size="16"  id="txtEName' + addnum + '" title="" name="txtEName" type="text" value="" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emEName' + addnum + '" style="display:none;">���ֶ�Ӣ����</em></td> ';
    htmlArray[1] = '<td><input  size="16"  id="txtCName' + addnum + '" title="" name="txtCName" type="text" value="" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emCName' + addnum + '" style="display:none;">���ֶ�������</em></td>';
    htmlArray[2] = '<td><textarea name="txtdesp" cols="19" rows="1" id="txtdesp' + addnum + '" title="" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" ></textarea><em id="emdesp' + addnum + '" style="display:none;">���ֶ�˵������</em></td>';
    htmlArray[3] = '<td><select name="seltype"><option selected="selected" value="Text" >�ı���</option><option value="Textarea"> �����ı��� </option><option value="Select">������</option><option value="Radio">��ѡ��</option><option value="Checkbox">��ѡ��</option></select></td>';
    htmlArray[4] = '<td><textarea name="txtselect" cols="19" rows="1" id="txtselect' + addnum + '" title="" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" ></textarea><em id="emselect' + addnum + '" style="display:none;">���ֶ�Ԥ��ֵ</em></td>';
    htmlArray[5] = '<td><input  size="16"  id="txtFieldSize' + addnum + '" title="" name="txtFieldSize" type="text" value="50" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emFieldSize' + addnum + '" style="display:none;">���ֶδ�С��С��8000</em></td> ';
    //htmlArray[5]='<td><input id="chkbunique'+addnum+'" type="checkbox"  onclick="checkonclick(\'unique\',\'unique'+addnum+'\',this);" /><span id="unique'+addnum+'">�ظ�</span> <input id="chkbnull'+addnum+'" type="checkbox"  onclick="checkonclick(\'null\',\'null'+addnum+'\',this);"  /><span id="null'+addnum+'">ѡ��</span> <input id="chkbtag'+addnum+'" type="checkbox"  onclick="checkonclick(\'tag\',\'tag'+addnum+'\',this);"  /><span id="tag'+addnum+'">һ��</span></td>';
    htmlArray[6] = '<td><img src="../images/fielddel.gif" alt="ɾ��" name="imgdelete" onclick="deleteline(this);" /></td>';

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
    if (chks.length == 0) { alert("û�п���ɾ������!"); return; }
    var rowindex = -1;
    for (var i = 0; i < chks.length; i++) {
        if (chks[i] == obj) { rowindex = i; }
    }
    if (rowindex < 0) { alert("û��ѡ��Ҫɾ������!"); return; }
    if (rowindex == 0) { alertmsg("���в���ɾ����", '', false); }
    else if (confirm("���Ҫɾ����" + eval(rowindex + 1) + "����?"))
    { document.all.productfield.deleteRow(rowindex); }
}

function addFiled() {
    if ($("typeids").value != undefined && $("typeids").value != "") {
        $("hidPT_ID").value = $("typeids").value;
    }
    if ($("hidPT_ID").value == "") {
        return alertmsg("��ѡ���Ʒ���࣡", "", false);
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
                $(name).innerHTML = "Ψһ";
            else
                $(name).innerHTML = "�ظ�";
            break;
        case "null":
            if (obj.checked == true)
                $(name).innerHTML = "����";
            else
                $(name).innerHTML = "ѡ��";
            break;
        case "tag":
            if (obj.checked == true)
                $(name).innerHTML = "��ǩ";
            else
                $(name).innerHTML = "һ��";
            break;
    }
}

//��ȡ������ʾ��Ϣ
function focusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);
    $(enname).style.display = "block";
}
//ʧȥ������ʾ��Ϣ
function unfocusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);

    $(enname).style.display = "none";
}

//��ȡ������ʾ��Ϣ
function tafocusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);
    obj.rows = 5;
    $(enname).style.display = "block";
}
//ʧȥ������ʾ��Ϣ
function taunfocusalt(obj) {
    var txtname = obj.id;
    var enname = "em" + txtname.substring(3);
    obj.rows = 1;
    $(enname).style.display = "none";
}

//�޸ĳ�ʼ��
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


//ѡ��ģ���ȡ��ģ����Ϣ���
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
=====================================�Զ����ֶ� ����================================================
**/

/**
=====================================�ؼ�����Ϣ������޸� ��ʼ================================================
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
=====================================�ؼ�����Ϣ������޸� ����================================================
**/

/**
===================================== ����ָ������ ��ʼ================================================
**/
function faithset() {
    if ($("tbbase").value == "") {
        return alertmsg('���ʼ��ɻ������Ϻ����ָ������ֵ��', '', false);
    }
    else if ($("tbbase").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('��ʼ�ĳ���ָ��ӦΪ������', '', false);
    }

    if ($("gfaith").value == "") {
        return alertmsg('����д�������϶�����д�����۵ĳ���ָ����', '', false);
    }
    else if ($("gfaith").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("gfaithuu").value == "") {
        return alertmsg('����д�������϶�����д�����۵�UU�ң�', '', false);
    }
    else if ($("gfaithuu").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("gerrfaith").value == "") {
        return alertmsg('����д����������ͨ���󴦷��۵ĳ���ָ����', '', false);
    }
    else if ($("gerrfaith").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("gerrfaithuu").value == "") {
        return alertmsg('����д����������ͨ���󴦷��۵�UU�ң�', '', false);
    }
    else if ($("gerrfaithuu").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("tbhot").value == "") {
        return alertmsg('���ʼ��ɸ߼����Ϻ����ָ������ֵ��', '', false);
    }
    else if ($("tbhot").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('��ʼ�ĳ���ָ��ӦΪ������', '', false);
    }

    if ($("hfaith").value != "") {
        if ($("hfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("hfaithuu").value != "") {
        if ($("hfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("herrfaith").value != "") {
        if ($("herrfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("herrfaithuu").value != "") {
        if ($("herrfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("tblicence").value == "") {
        return alertmsg('���ʼ�ϴ�Ӫҵִ�պ����ָ������ֵ��', '', false);
    }
    else if ($("tblicence").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('��ʼ�ĳ���ָ��ӦΪ������', '', false);
    }

    if ($("tbcertificate").value == "") {
        return alertmsg('���ʼ�ϴ���������֤������ָ������ֵ��', '', false);
    }
    else if ($("tbcertificate").value.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg('��ʼ�ĳ���ָ��ӦΪ������', '', false);
    }

    if ($("userfaith").value != "") {
        if ($("userfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("userfaithuu").value != "") {
        if ($("userfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("usererrfaith").value != "") {
        if ($("usererrfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("usererrfaithuu").value != "") {
        if ($("usererrfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("businessfaith").value != "") {
        if ($("businessfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("businessfaithuu").value != "") {
        if ($("businessfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU��Ϊ������', '', false);
    }

    if ($("businesserrfaith").value != "") {
        if ($("businesserrfaith").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('����ָ��Ϊ������', '', false);
    }

    if ($("businesserrfaithuu").value != "") {
        if ($("businesserrfaithuu").value.search(/^[-\+]?\d+$/) == -1)
            return alertmsg('UU��Ϊ������', '', false);
    }
}
/**
===================================== ����ָ������ ����================================================
**/
//����Ա���û��ظ�����
function adminmessage() {
    if ($("title").value == "") {
        return alertmsg('������ظ����⣡', '', false);
    }
    if ($("content").value == "") {
        return alertmsg('������ظ����ݣ�', '', false);
    }
}



//����Ա���û�����
function messageadd() {
    var lbcontent = FCKeditorAPI.GetInstance('lbcontent').GetXHTML(true);
    if (lbcontent == "") {
        return alertmsg('����������', '', false);
    }
    if ($("lbtitle").value == "") {
        return alertmsg('��������⣡', '', false);
    }
    if ($("lbcontent").value.length > 4000) {
        return alertmsg('���ݳ��ȳ�����Χ��', '', false);
    }

}
//���ʡ��
function ProvinceAdd() {
    if ($("txtName").value == "") {
        return alertmsg('������ʡ�����ƣ�', '', false);
    }
}



//�޸�ʡ��
function ProvinceUpdate() {
    if ($("txtYuanPwd").value == "") {
        return alertmsg('������ʡ�����ƣ�', '', false);
    }
}

/*******************  �Զ���ģ����� **************************/


function AddInfoType() {
    var i = Number(document.getElementById("InfoTypeTotal").value);
    i++;
    var string = new Array();

    string[0] = '<input type="text" id="tbid' + i + '" class="m_i" runat="server" readonly="readonly" value="' + i + '"/>';
    string[1] = '<input type="text" id="tbprefix' + i + '" name="tbprefix' + i + '"/>';
    string[2] = '<input type="text" id="tbpostfix' + i + '" name="tbpostfix' + i + '"/>';
    string[3] = '<input type="radio" name="rb' + i + '" value="sell" checked="checked" onclick="SetInfoTypeValue(' + i + ');"/>��&nbsp;<input type="radio" name="rb' + i + '" value="buy" onclick="SetInfoTypeValue(' + i + ');"/>��<input type="hidden" id="hidInfoType_' + i + '" name="hidInfoType_' + i + '" value="sell" />';
    string[4] = '<a href="javascript:void(null);" onclick="DeleteInfoType(' + i + ');"><img src="../images/delete1.gif" alt="ɾ��"/></a>';

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

//2008-11-5 ��̨�༭��Ϣѡ���������Զ��巽��
var isconfirm = false;
function SelectTypeIDOnClick() {
    if (!isconfirm) {
        if (window.confirm("����޸���Ϣ���ԭ�е��Զ����ֶ����ݽ���ʧ��\n�Ƿ�����޸ģ�")) {
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



/*********************��̨���Ͷ���*****************************/

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
        sAlert("��ѡ��һ��Ҫת�Ƶ��ķ��࣡");
        return false;
    }
    $("hidptid").value = strid;
}

//�ı�����ı��������
//eleId:Ԫ��Id
//action:������ʶ add:��,sub����
//maxRow:�������
//minRow:��С����
//step:��������ÿ�θı������
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

//GridView��Ŀ�������¼�
//tc 09-02-18
function __XY_GV_Row_MouseOver(obj) {
    //var tds = obj.childNodes;
    var tds = obj.getElementsByTagName("td");
    for (i = 0; i < tds.length; i++) {
        tds[i].style.backgroundColor = "#deeffa";
    }
}
//GridView��Ŀ�������¼�
//tc 09-02-18
function __XY_GV_Row_MouseOut(obj) {
    var tds = obj.getElementsByTagName("td");
    for (i = 0; i < tds.length; i++) {
        tds[i].style.backgroundColor = "#ffffff";
    }
}


//ͶƱѡ��ѡ�����
function AddPollOption() {
    var i = Number(document.getElementById("OptionTotal").value);
    i++;
    var string = new Array();

    string[0] = '' + i + '.';
    string[1] = '<textarea name="option' + i + '" rows="2" cols="60"></textarea>';
    string[2] = '<a href="javascript:void(null);" onclick="DeletePollOption(' + i + ');"><img src="../images/delete1.gif" alt="ɾ��"/></a>';

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


//��¼ɾ��ѡ���Id���Ա��ύ���ڷ������˽������ݿ�ɾ��
function DeleteServerOption(optionId) {
    if (optionId == "") return;

    var ids = document.getElementById("DelOptionIds").value;

    if (ids == "")
        ids = optionId;
    else
        ids = ids + "," + optionId;

    document.getElementById("DelOptionIds").value = ids;
}










//���Ÿ���ѡ�����
function AddFileOption() {
    var i = Number(document.getElementById("OptionTotal").value);
    i++;
    var string = new Array();
    string[0] = '<input text name="filename' + i + '" value="����' + i + '" size="20"><input text name="option' + i + '" size="45">';
    string[1] = '<a href="javascript:void(null);" onclick="DeletePollOption(' + i + ');"><img src="../images/delete1.gif" alt="ɾ��"/></a>';

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
=====================================����תƴ�� ����================================================
**/
var spell = { 0xB0A1: "a", 0xB0A3: "ai", 0xB0B0: "an", 0xB0B9: "ang", 0xB0BC: "ao", 0xB0C5: "ba", 0xB0D7: "bai", 0xB0DF: "ban", 0xB0EE: "bang", 0xB0FA: "bao", 0xB1AD: "bei", 0xB1BC: "ben", 0xB1C0: "beng", 0xB1C6: "bi", 0xB1DE: "bian", 0xB1EA: "biao", 0xB1EE: "bie", 0xB1F2: "bin", 0xB1F8: "bing", 0xB2A3: "bo", 0xB2B8: "bu", 0xB2C1: "ca", 0xB2C2: "cai", 0xB2CD: "can", 0xB2D4: "cang", 0xB2D9: "cao", 0xB2DE: "ce", 0xB2E3: "ceng", 0xB2E5: "cha", 0xB2F0: "chai", 0xB2F3: "chan", 0xB2FD: "chang", 0xB3AC: "chao", 0xB3B5: "che", 0xB3BB: "chen", 0xB3C5: "cheng", 0xB3D4: "chi", 0xB3E4: "chong", 0xB3E9: "chou", 0xB3F5: "chu", 0xB4A7: "chuai", 0xB4A8: "chuan", 0xB4AF: "chuang", 0xB4B5: "chui", 0xB4BA: "chun", 0xB4C1: "chuo", 0xB4C3: "ci", 0xB4CF: "cong", 0xB4D5: "cou", 0xB4D6: "cu", 0xB4DA: "cuan", 0xB4DD: "cui", 0xB4E5: "cun", 0xB4E8: "cuo", 0xB4EE: "da", 0xB4F4: "dai", 0xB5A2: "dan", 0xB5B1: "dang", 0xB5B6: "dao", 0xB5C2: "de", 0xB5C5: "deng", 0xB5CC: "di", 0xB5DF: "dian", 0xB5EF: "diao", 0xB5F8: "die", 0xB6A1: "ding", 0xB6AA: "diu", 0xB6AB: "dong", 0xB6B5: "dou", 0xB6BC: "du", 0xB6CB: "duan", 0xB6D1: "dui", 0xB6D5: "dun", 0xB6DE: "duo", 0xB6EA: "e", 0xB6F7: "en", 0xB6F8: "er", 0xB7A2: "fa", 0xB7AA: "fan", 0xB7BB: "fang", 0xB7C6: "fei", 0xB7D2: "fen", 0xB7E1: "feng", 0xB7F0: "fo", 0xB7F1: "fou", 0xB7F2: "fu", 0xB8C1: "ga", 0xB8C3: "gai", 0xB8C9: "gan", 0xB8D4: "gang", 0xB8DD: "gao", 0xB8E7: "ge", 0xB8F8: "gei", 0xB8F9: "gen", 0xB8FB: "geng", 0xB9A4: "gong", 0xB9B3: "gou", 0xB9BC: "gu", 0xB9CE: "gua", 0xB9D4: "guai", 0xB9D7: "guan", 0xB9E2: "guang", 0xB9E5: "gui", 0xB9F5: "gun", 0xB9F8: "guo", 0xB9FE: "ha", 0xBAA1: "hai", 0xBAA8: "han", 0xBABB: "hang", 0xBABE: "hao", 0xBAC7: "he", 0xBAD9: "hei", 0xBADB: "hen", 0xBADF: "heng", 0xBAE4: "hong", 0xBAED: "hou", 0xBAF4: "hu", 0xBBA8: "hua", 0xBBB1: "huai", 0xBBB6: "huan", 0xBBC4: "huang", 0xBBD2: "hui", 0xBBE7: "hun", 0xBBED: "huo", 0xBBF7: "ji", 0xBCCE: "jia", 0xBCDF: "jian", 0xBDA9: "jiang", 0xBDB6: "jiao", 0xBDD2: "jie", 0xBDED: "jin", 0xBEA3: "jing", 0xBEBC: "jiong", 0xBEBE: "jiu", 0xBECF: "ju", 0xBEE8: "juan", 0xBEEF: "jue", 0xBEF9: "jun", 0xBFA6: "ka", 0xBFAA: "kai", 0xBFAF: "kan", 0xBFB5: "kang", 0xBFBC: "kao", 0xBFC0: "ke", 0xBFCF: "ken", 0xBFD3: "keng", 0xBFD5: "kong", 0xBFD9: "kou", 0xBFDD: "ku", 0xBFE4: "kua", 0xBFE9: "kuai", 0xBFED: "kuan", 0xBFEF: "kuang", 0xBFF7: "kui", 0xC0A4: "kun", 0xC0A8: "kuo", 0xC0AC: "la", 0xC0B3: "lai", 0xC0B6: "lan", 0xC0C5: "lang", 0xC0CC: "lao", 0xC0D5: "le", 0xC0D7: "lei", 0xC0E2: "leng", 0xC0E5: "li", 0xC1A9: "lia", 0xC1AA: "lian", 0xC1B8: "liang", 0xC1C3: "liao", 0xC1D0: "lie", 0xC1D5: "lin", 0xC1E1: "ling", 0xC1EF: "liu", 0xC1FA: "long", 0xC2A5: "lou", 0xC2AB: "lu", 0xC2BF: "lv", 0xC2CD: "luan", 0xC2D3: "lue", 0xC2D5: "lun", 0xC2DC: "luo", 0xC2E8: "ma", 0xC2F1: "mai", 0xC2F7: "man", 0xC3A2: "mang", 0xC3A8: "mao", 0xC3B4: "me", 0xC3B5: "mei", 0xC3C5: "men", 0xC3C8: "meng", 0xC3D0: "mi", 0xC3DE: "mian", 0xC3E7: "miao", 0xC3EF: "mie", 0xC3F1: "min", 0xC3F7: "ming", 0xC3FD: "miu", 0xC3FE: "mo", 0xC4B1: "mou", 0xC4B4: "mu", 0xC4C3: "na", 0xC4CA: "nai", 0xC4CF: "nan", 0xC4D2: "nang", 0xC4D3: "nao", 0xC4D8: "ne", 0xC4D9: "nei", 0xC4DB: "nen", 0xC4DC: "neng", 0xC4DD: "ni", 0xC4E8: "nian", 0xC4EF: "niang", 0xC4F1: "niao", 0xC4F3: "nie", 0xC4FA: "nin", 0xC4FB: "ning", 0xC5A3: "niu", 0xC5A7: "nong", 0xC5AB: "nu", 0xC5AE: "nv", 0xC5AF: "nuan", 0xC5B0: "nue", 0xC5B2: "nuo", 0xC5B6: "o", 0xC5B7: "ou", 0xC5BE: "pa", 0xC5C4: "pai", 0xC5CA: "pan", 0xC5D2: "pang", 0xC5D7: "pao", 0xC5DE: "pei", 0xC5E7: "pen", 0xC5E9: "peng", 0xC5F7: "pi", 0xC6AA: "pian", 0xC6AE: "piao", 0xC6B2: "pie", 0xC6B4: "pin", 0xC6B9: "ping", 0xC6C2: "po", 0xC6CB: "pu", 0xC6DA: "qi", 0xC6FE: "qia", 0xC7A3: "qian", 0xC7B9: "qiang", 0xC7C1: "qiao", 0xC7D0: "qie", 0xC7D5: "qin", 0xC7E0: "qing", 0xC7ED: "qiong", 0xC7EF: "qiu", 0xC7F7: "qu", 0xC8A6: "quan", 0xC8B1: "que", 0xC8B9: "qun", 0xC8BB: "ran", 0xC8BF: "rang", 0xC8C4: "rao", 0xC8C7: "re", 0xC8C9: "ren", 0xC8D3: "reng", 0xC8D5: "ri", 0xC8D6: "rong", 0xC8E0: "rou", 0xC8E3: "ru", 0xC8ED: "ruan", 0xC8EF: "rui", 0xC8F2: "run", 0xC8F4: "ruo", 0xC8F6: "sa", 0xC8F9: "sai", 0xC8FD: "san", 0xC9A3: "sang", 0xC9A6: "sao", 0xC9AA: "se", 0xC9AD: "sen", 0xC9AE: "seng", 0xC9AF: "sha", 0xC9B8: "shai", 0xC9BA: "shan", 0xC9CA: "shang", 0xC9D2: "shao", 0xC9DD: "she", 0xC9E9: "shen", 0xC9F9: "sheng", 0xCAA6: "shi", 0xCAD5: "shou", 0xCADF: "shu", 0xCBA2: "shua", 0xCBA4: "shuai", 0xCBA8: "shuan", 0xCBAA: "shuang", 0xCBAD: "shui", 0xCBB1: "shun", 0xCBB5: "shuo", 0xCBB9: "si", 0xCBC9: "song", 0xCBD1: "sou", 0xCBD4: "su", 0xCBE1: "suan", 0xCBE4: "sui", 0xCBEF: "sun", 0xCBF2: "suo", 0xCBFA: "ta", 0xCCA5: "tai", 0xCCAE: "tan", 0xCCC0: "tang", 0xCCCD: "tao", 0xCCD8: "te", 0xCCD9: "teng", 0xCCDD: "ti", 0xCCEC: "tian", 0xCCF4: "tiao", 0xCCF9: "tie", 0xCCFC: "ting", 0xCDA8: "tong", 0xCDB5: "tou", 0xCDB9: "tu", 0xCDC4: "tuan", 0xCDC6: "tui", 0xCDCC: "tun", 0xCDCF: "tuo", 0xCDDA: "wa", 0xCDE1: "wai", 0xCDE3: "wan", 0xCDF4: "wang", 0xCDFE: "wei", 0xCEC1: "wen", 0xCECB: "weng", 0xCECE: "wo", 0xCED7: "wu", 0xCEF4: "xi", 0xCFB9: "xia", 0xCFC6: "xian", 0xCFE0: "xiang", 0xCFF4: "xiao", 0xD0A8: "xie", 0xD0BD: "xin", 0xD0C7: "xing", 0xD0D6: "xiong", 0xD0DD: "xiu", 0xD0E6: "xu", 0xD0F9: "xuan", 0xD1A5: "xue", 0xD1AB: "xun", 0xD1B9: "ya", 0xD1C9: "yan", 0xD1EA: "yang", 0xD1FB: "yao", 0xD2AC: "ye", 0xD2BB: "yi", 0xD2F0: "yin", 0xD3A2: "ying", 0xD3B4: "yo", 0xD3B5: "yong", 0xD3C4: "you", 0xD3D9: "yu", 0xD4A7: "yuan", 0xD4BB: "yue", 0xD4C5: "yun", 0xD4D1: "za", 0xD4D4: "zai", 0xD4DB: "zan", 0xD4DF: "zang", 0xD4E2: "zao", 0xD4F0: "ze", 0xD4F4: "zei", 0xD4F5: "zen", 0xD4F6: "zeng", 0xD4FA: "zha", 0xD5AA: "zhai", 0xD5B0: "zhan", 0xD5C1: "zhang", 0xD5D0: "zhao", 0xD5DA: "zhe", 0xD5E4: "zhen", 0xD5F4: "zheng", 0xD6A5: "zhi", 0xD6D0: "zhong", 0xD6DB: "zhou", 0xD6E9: "zhu", 0xD7A5: "zhua", 0xD7A7: "zhuai", 0xD7A8: "zhuan", 0xD7AE: "zhuang", 0xD7B5: "zhui", 0xD7BB: "zhun", 0xD7BD: "zhuo", 0xD7C8: "zi", 0xD7D7: "zong", 0xD7DE: "zou", 0xD7E2: "zu", 0xD7EA: "zuan", 0xD7EC: "zui", 0xD7F0: "zun", 0xD7F2: "zuo" }

var spellArray = new Array()
var pn = ""

function Trim(info) { return info.replace(/(^\s*)|(\s*$)/g, ""); }

function isEnKong1(argValue) {
    var flag = false;
    var compStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    compStr += "1234567890"; //����
    compStr += "!@#$%^&*()-+=|\{[}]:;'<,>.?/ "; //�����ַ�
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
        return char; //return '';�����ַ�

    if (spellArray[char.charCodeAt(0)])
        return spellArray[char.charCodeAt(0)];

    ascCode = toAsc(char);
    ascCode = eval("0x" + ascCode);

    if (!(ascCode > 0xB0A0 && ascCode < 0xD7FC))
        return char; //return '';�����ַ�

    for (var i = ascCode; (!spell[i] && i > 0); )
        i--;
    return spell[i];
}
//�޸ĵķ���
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


//���������ַ�
function CheckIfEnglish(String) {
    var Letters = "!@#$%^&*()_+=|\{[}]:;'<>.?/����,������";
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
            if (c == "," || c == "��") {
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
=====================================����תƴ�� ��ʼ================================================
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
        sAlert("������ѡ��һ����¼��", "", true);
        return false;
    }
}