document.writeln("<script language=\"javascript\" type=\"text/javascript\" src=\"/config/js/config.js\"></script>");

//document.writeln("<script language=\"javascript\" type=\"text/javascript\" src=\"/config/js/config.js\"></script>");

var XY_LOADING = "<img src =\"/common/images/ajax-loader.gif\"/><br/>��������¼�룬���Ե�...";

var XY_LOADING_SMALL = "<img src =\"/common/images/ajax-loading-circle.gif\" alt=\"���ڼ�����....\"/>";

function $(element) {
    return document.getElementById(element);
}
function $F(element) {
    return document.getElementById(element).value;
}

function GetNewCode() {
    return config.WebURL + "common/ValidateCode.ashx?" + Math.random();
}

//���ͻ���׷��js�ű���
//funcName:������
//scriptText:��������
function attachScript(funcName, scriptText) {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.text = "function " + funcName + "(){" + scriptText + ";}";
    //document.getElementsByTagName("head")[0].appendChild(script)
    document.body.appendChild(script);
}

//���ͻ���׷�����ر�
//eleName:������
//value:��ֵ
function attachHiddleField(eleName, value) {
    var ele = document.createElement("input");
    ele.id = eleName;
    ele.name = eleName;
    ele.type = "hidden";
    ele.value = value;
    document.body.appendChild(ele);
}


//��ȡ��ѡ��ť�鵱ǰѡ�����ֵ
function $R(element) {
    var eles = document.getElementsByName(element);

    if (eles.length <= 0) return "";

    for (var i = 0; i < eles.length; i++) {
        if (eles[i].checked) {
            return eles[i].value;
        }
    }
    return "";
}

function Dialog(msg) {
    return window.confirm(msg);
}
function IE() {
    Browser = {
        IE: !!(window.attachEvent && !window.opera),
        Opera: !!window.opera,
        WebKit: navigator.userAgent.indexOf('AppleWebKit/') > -1,
        Gecko: navigator.userAgent.indexOf('Gecko') > -1 && navigator.userAgent.indexOf('KHTML') == -1,
        MobileSafari: !!navigator.userAgent.match(/Apple.*Mobile.*Safari/)
    }
    return this.Browser.IE
}

/********************** firefox add event start ************************/
function __firefox() {
    HTMLElement.prototype.__defineGetter__("runtimeStyle", __element_style);
    window.constructor.prototype.__defineGetter__("event", __window_event);
    Event.prototype.__defineGetter__("srcElement", __event_srcElement);
}

function __element_style() {
    return (this.style);
}

function __window_event() {
    return (__window_event_constructor());
}

function __event_srcElement() {
    return this.target;
}

function __window_event_constructor() {
    if (document.all)
        return (window.event);
    var _caller = __window_event_constructor.caller;
    while (_caller != null) {
        var _argument = _caller.arguments[0];
        if (_argument) {
            var _temp = _argument.constructor;
            if (_temp.toString().indexOf("Event") != -1)
                return (_argument);
        }
        _caller = _caller.caller;
    }
    return (null);
}

if (window.addEventListener) {
    __firefox();
}

/********************** firefox add event end ************************/


/********************** ���������ק���� ****************************/
var oDrag;
var ox, oy, nx, ny, dy, dx;
function drag(e, o) {
    var e = e ? e : event;
    var mouseD = IE() ? 1 : 0;
    if (e.button == mouseD) {
        oDrag = $(o);
        ox = e.clientX;
        oy = e.clientY;
    }
}
function dragPro(e) {
    if (oDrag != null) {
        var e = e ? e : event;
        dx = parseInt(oDrag.style.left);
        dy = parseInt(oDrag.style.top);
        nx = e.clientX;
        ny = e.clientY;
        oDrag.style.left = (dx + (nx - ox)) + "px";
        oDrag.style.top = (dy + (ny - oy)) + "px";
        ox = nx;
        oy = ny;
    }
}
document.onmouseup = function () { oDrag = null; }
document.onmousemove = function (event) { dragPro(event); }
/********************** ���������ק�������� ****************************/



//����ͼƬ�Ĵ�С
function SetImgSize(imgObj, maxWidth, maxHeight) {
    if (undefined != maxWidth) {
        if (imgObj.width > maxWidth)
            imgObj.width = maxWidth;
    }
    if (undefined != maxHeight) {
        if (imgObj.height > maxHeight)
            imgObj.height = maxHeight;
    }
}
//ȡ��Get��ֵ�еĲ���
function GetQueryString(queryName) {
    var strURL = location.href;
    var index = strURL.lastIndexOf("?");
    if (index > 0) {
        var values = strURL.substr(index + 1);
        if (values.indexOf("&") > 0) {
            var arrQuery = values.split("&");
            for (i in arrQuery) {
                if (arrQuery[i].indexOf("=") > 0) {
                    var arr = arrQuery[i].split("=");
                    if (arr[0].toLowerCase() == queryName.toLowerCase()) {
                        return arr[1];
                    }
                }
            }
        }
        else {
            var arr = values.split("=");
            if (arr[0].toLowerCase() == queryName.toLowerCase()) {
                return arr[1];
            }
        }
    }
    return "";
}

//��ȡָ�����Ƶ�cookie��ֵ
function getCookie(objName) {
    var arrStr = document.cookie.split("; ");
    for (var i = 0; i < arrStr.length; i++) {
        var temp = arrStr[i].split("=");
        if (temp[0].toLowerCase() == objName.toLowerCase()) {
            return unescape(temp[1]);
        }
    }
    return "";
}

/*
* ��ȡ document.body ����
*/
function GetDocumentBody() {
    if (typeof window.pageYOffset != 'undefined') {
        return indow.pageYOffset;
    }

    if (typeof document.compatMode != 'undefined' &&
         document.compatMode != 'BackCompat') {
        return document.documentElement;
    }

    if (typeof document.body != 'undefined') {
        return document.body;
    }
}

//ȡ��ҳ��ߴ�
function getPageSize() {

    var docElem = document.documentElement
    //�ɼ�������
    this.width = self.innerWidth || (docElem && docElem.clientWidth) || document.body.clientWidth;
    //�ɼ�����߶�
    this.height = self.innerHeight || (docElem && docElem.clientHeight) || document.body.clientHeight;
    //ҳ����ܸ߶�
    this.docheight = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight);
}

//ȡ�ö���ߴ�
function getElementSize(elem) {
    this.width = elem.clientWidth || elem.style.pixelWidth;
    this.height = elem.clientHeight || elem.style.pixelHeight;
}


//�������������
function getScrollPos() {

    var docElem = document.documentElement;

    this.scrollX = self.pageXOffset || (docElem && docElem.scrollLeft) || document.body.scrollLeft;

    this.scrollY = self.pageYOffset || (docElem && docElem.scrollTop) || document.body.scrollTop;
}

//ʹ�����Ϊ��Ļ����
function posToCenter(elem) {
    var scrollPos = new getScrollPos();
    var pageSize = new getPageSize();
    var emSize = new getElementSize(elem);

    var pageSizeWidth = pageSize.width;
    var pageSizeheight = pageSize.height;
    //emSize.height/emSize.width
    var x = Math.round(pageSizeWidth / 2) - (emSize.width / 2) + scrollPos.scrollX;
    var y = Math.round(pageSizeheight / 2) - (emSize.height / 2) + scrollPos.scrollY;
    elem.style.left = x + 'px';
    elem.style.top = y + 'px';
}


//��ȡ���λ��
function mouseCoords() {
    var ev = ev || window.event;
    var tmpobj;
    if (typeof window.pageYOffset != 'undefined') {
        tmpobj = window.pageYOffset;
    }
    else if (typeof document.compatMode != 'undefined' &&
         document.compatMode != 'BackCompat') {
        tmpobj = document.documentElement;
    }
    else if (typeof document.body != 'undefined') {
        tmpobj = document.body;
    }

    if (ev.pageX || ev.pageY) {
        return { x: ev.pageX, y: ev.pageY };
    }
    return {
        x: ev.clientX + tmpobj.scrollLeft - tmpobj.clientLeft,
        y: ev.clientY + tmpobj.scrollTop - tmpobj.clientTop
    };
}

function insertHtml(where, el, html) {
    where = where.toLowerCase();
    if (el.insertAdjacentHTML) {
        switch (where) {
            case "beforebegin":
                el.insertAdjacentHTML('BeforeBegin', html);
                return el.previousSibling;
            case "afterbegin":
                el.insertAdjacentHTML('AfterBegin', html);
                return el.firstChild;
            case "beforeend":
                el.insertAdjacentHTML('BeforeEnd', html);
                return el.lastChild;
            case "afterend":
                el.insertAdjacentHTML('AfterEnd', html);
                return el.nextSibling;
        }
        throw 'Illegal insertion point -> "' + where + '"';
    }
    var range = el.ownerDocument.createRange();
    var frag;
    switch (where) {
        case "beforebegin":
            range.setStartBefore(el);
            frag = range.createContextualFragment(html);
            el.parentNode.insertBefore(frag, el);
            return el.previousSibling;
        case "afterbegin":
            if (el.firstChild) {
                range.setStartBefore(el.firstChild);
                frag = range.createContextualFragment(html);
                el.insertBefore(frag, el.firstChild);
                return el.firstChild;
            } else {
                el.innerHTML = html;
                return el.firstChild;
            }
        case "beforeend":
            if (el.lastChild) {
                range.setStartAfter(el.lastChild);
                frag = range.createContextualFragment(html);
                el.appendChild(frag);
                return el.lastChild;
            } else {
                el.innerHTML = html;
                return el.lastChild;
            }
        case "afterend":
            range.setStartAfter(el);
            frag = range.createContextualFragment(html);
            el.parentNode.insertBefore(frag, el.nextSibling);
            return el.nextSibling;
    }
    throw 'Illegal insertion point -> "' + where + '"';
}

/*
* ���ָ����Ԫ�ص�ֵ
*/
function ClearObjectValue() {
    var eles = arguments;
    for (i = 0; i < eles.length; i++) {
        $(eles[i] + '').value = '';
    }
}

/*
* ҳ����ת
*/
function GoTo(url) {
    window.location.href = url;
}

/****************************** �Ի���sAlert ************************************/
function alertmsg(returnValue, msg, url, strFlag) {
    if (typeof (returnValue) == "string") {
        sAlert(returnValue, msg, true);
        if (typeof (url) == "boolean") {
            return url;
        }
    }
    else {
        sAlert(msg, url, true);

        if (typeof (returnValue) == "boolean") {
            return returnValue;
        }
    }
}

function alertnotbut(str, autoHidden) {
    sAlert(str, "", autoHidden);
}



function MsgClass(objName) {
    var strHtml;
    strHtml = "<div id='_xy_alert_' style=\"display:none;\" class='msgbg'>";
    strHtml += "</div>";
    strHtml += '<div class="xyAlertBoxBox" id="_xy_alert_inner_div" style="display:none;">';
    strHtml += '  <div class="xyAlertBoxInBox">';
    strHtml += '    <div class="xyAlertBoxBoxContent">';
    strHtml += '      <div class="xyAlertBoxBoxContenedor">';
    strHtml += '      <span class="xyAlertBoxBoxTitle">ϵͳ��ʾ��Ϣ</span><br /> <p id="msgcontent"></p>';
    strHtml += '      </div>';
    strHtml += '      <div class="xyAlertBoxButtons">';
    strHtml += '        <input class="BoxAlertBtnOk" onclick="' + objName + '.doOk();" type="button" value="�ر�">';
    strHtml += '      </div>';
    strHtml += '    </div>';
    strHtml += '  </div>';
    strHtml += '</div>';

    document.write(strHtml);

    var div = $("_xy_alert_");
    var backURL = "";
    var objMsg = objName;
    var obj = this;

    var interval;
    var timeout;

    this.AlertMsg = function (errorMsg, strurl, autoHidden) {
        window.clearInterval(interval);
        window.clearTimeout(timeout);

        this.Show(errorMsg,strurl,autoHidden);
        //this.Show(errorMsg,strurl,autoHidden);
        interval = window.setInterval(function () {
            obj.Show(errorMsg, strurl, autoHidden);
        }, 500);

        if (strurl != undefined) {
            backURL = strurl;
        }

        if (autoHidden) {
            timeout = window.setTimeout(objName + ".doOk()", 3000);
        }
    }

    this.Stop = function () {
        if (interval != null) {
            window.clearInterval(interval);
        }
    }

    this.Start = function () {
        if (interval == null) {
            interval = window.setInterval(function () {
                obj.Show(errorMsg, strurl, autoHidden);
            }, 500);
        }
    }

    this.Show = function (errorMsg, strurl, autoHidden) {
        div.style.display = "block";
        $("msgcontent").innerHTML = errorMsg;

        var pageSize = new getPageSize();
        div.style.height = pageSize.docheight + "px";
        $("_xy_alert_inner_div").style.display = 'block';
        //����DIV��������
        var mydiv = $("_xy_alert_inner_div");

        posToCenter(mydiv);
    }

    //�ͷ�DIV
    this.doOk = function (strurl) {
        if (backURL != "")
            window.location.href = backURL;

        div.style.display = "none";
        $("_xy_alert_inner_div").style.display = "none";
        window.clearInterval(interval);
        window.clearTimeout(timeout);
    }
}

var objMsg = new MsgClass("objMsg");
//����DIV
function sAlert(errorMsg, strurl, autoHidden) {
    objMsg.AlertMsg(errorMsg, strurl, autoHidden);
}

//ֹͣ����setInterval
function sStop() {
    objMsg.Stop();
}
//��������setInterval
function sStart() {
    objMsg.Start();
}

function sClose() {
    objMsg.doOk();
}
/****************************** �Ի���sAlert���� ************************************/

/****************************** ajax start ************************************/
var AjaxIndex = 0; //ȫ�ֵ�ajax��������ʾΨһ��ajaxʵ��
function Ajax(acID, url) {

    var thisIndex = "result" + AjaxIndex;
    AjaxIndex++;

    var oXmlDom;
    this.state = null;
    this.data = null;
    this.AJAX_URL = config.WebURL + "Common/XYAjax.ashx?ajaxidnex=" + thisIndex + "&ac=" + acID;
    this.AJAX_URL += undefined == url ? "" : url;
    var obj = this;

    this.getNode = function (oNode) {
        var resulit = "";
        if (oNode.childNodes.length > 0) {//���������		
            var ii = false;
            for (var i = 0; i < oNode.childNodes.length; i++) {
                var oItem = oNode.childNodes[i];
                if (oItem.nodeType == 1) {//�ж��Ƿ���Element����
                    resulit += (ii ? "," : "");
                    if (oItem.childNodes.length == 1) {
                        resulit += oItem.nodeName + ":'" + (IE() ? oItem.text : oItem.textContent) + "'";
                    }
                    else {
                        if (!ii) {
                            resulit += oItem.nodeName + ":[" + obj.getNode(oItem);
                        }
                        else {
                            var pNode = null;

                            for (var j = i - 1; j >= 0; j--) {

                                if (oNode.childNodes[j].nodeType == 1) {
                                    pNode = oNode.childNodes[j];
                                    break;
                                }
                            }
                            if (pNode.nodeName == oItem.nodeName) {
                                resulit += obj.getNode(oItem);
                            }
                            else {
                                resulit += oItem.nodeName + ":[" + obj.getNode(oItem);
                            }
                        }
                        var nNode = null;
                        for (var j = i + 1; j < oNode.childNodes.length; j++) {
                            if (oNode.childNodes[j].nodeType == 1) {
                                nNode = oNode.childNodes[j];
                                break;
                            }
                        }
                        if (nNode != null) {
                            if (nNode.nodeName != oItem.nodeName) {
                                resulit += "]";
                            }
                        }
                        else {
                            resulit += "]";
                        }
                    }
                    ii = true;
                }
            } //end for

            resulit = "{" + resulit + "}";
        }
        else {
            resulit = "null";
        }
        return resulit;
    }

    this.onSuccess = function () {
        //�ڲ����ݴ�����;
    }

    this.getData = function () {
        var nodes = oXmlDom.documentElement;

        for (var i = 0; i < nodes.childNodes.length; i++) {
            var oItem = nodes.childNodes[i];
            if (oItem.nodeType == 1) {
                if (oItem.nodeName.toLowerCase() == "state") {
                    var tmp1 = "";
                    var tmp2 = "";

                    for (var j = 0; j < oItem.childNodes.length; j++) {
                        var tmpNode = oItem.childNodes[j];
                        if (tmpNode.nodeType == 1) {
                            if (tmpNode.nodeName.toLowerCase() == "result")
                                tmp1 = IE() ? tmpNode.text : tmpNode.textContent;
                            else if (tmpNode.nodeName.toLowerCase() == "message")
                                tmp2 = IE() ? tmpNode.text : tmpNode.textContent;
                        }
                    }
                    eval("obj.state = {result:'" + tmp1 + "',message:'" + tmp2 + "'}");
                }
                else if (oItem.nodeName.toLowerCase() == "data") {
                    eval("obj.data = " + obj.getNode(oItem));
                }
            }
        }
        obj.onSuccess();
    }

    this.Init = function () {
        var script = document.createElement("script");
        script.type = "text/javascript";
        script.src = this.AJAX_URL;
        if (IE()) {
            script.onreadystatechange = function () {
                if ("loaded" == script.readyState || "complete" == script.readyState) {
                    oXmlDom = new ActiveXObject("Microsoft.XMLDOM");
                    //oXmlDom.async=false;
                    oXmlDom.onreadystatechange = function () {
                        if (oXmlDom.readyState == 4) {
                            obj.getData();
                        }
                    }
                    try {
                        eval("oXmlDom.loadXML(" + thisIndex + ")");
                    }
                    catch (e) {
                    }
                    document.getElementsByTagName("head")[0].removeChild(script);
                }
            }
        }
        else {
            script.onload = function () {
                var oParser = new DOMParser();
                try {
                    eval("oXmlDom = oParser.parseFromString(" + thisIndex + ",\"text/xml\")");
                    obj.getData();
                }
                catch (e) {

                }
                document.getElementsByTagName("head")[0].removeChild(script);
            }
        }
        document.getElementsByTagName("head")[0].appendChild(script);
    }
    this.Init();
}
/****************************** ajax end **************************************/

/******************************   Select Class Start  *******************************/

//��ʾ�����Ϣ
//      objName             �ⲿʵ�����Ķ�����
//      moduleFlagTextId    ģ���ʶ���Ʊ�Id
//      showDivID:          ��ʾ�����Ϣ��Div��ID��
//      inputTxtID:         ҳ�����ѡ����ID���ı��ֶ�
//      acID:               Ҫѡ���ĸ������ID ��Ӧajax����ĳ���
//      level:              ��ʾ���ټ� Ĭ��Ϊȫ��
//      params            �Զ������  key:value|key1:value1
function ClassType(objName, moduleFlagTextId, showDivID, inputTxtID, level, ac, params) {
    var DivWidth = "240px";
    //��ʼ��ȫ�ֱ���

    this.ActionID = "";
    this.MaxLevel = 999;

    if (ac == undefined || ac == "") {
        this.ActionID = "xy001";
    } else {
        this.ActionID = ac;
    }

    if (level == undefined || level == "") {
        this.MaxLevel = 999;
    } else {
        this.MaxLevel = level;
    }

    this.Params = params == undefined ? "" : params;

    this.IndexLevel = 0;
    this.InputTxtID = inputTxtID;
    this.ModuleName = $(moduleFlagTextId) != undefined ? $F(moduleFlagTextId) : moduleFlagTextId;
    //�洢Ĭ��ֵ
    var OldValue = "";

    this.Mode = "div"; //div or select
    var obj = objName;
    var thisObj = this;
    var mainobj = $(showDivID);
    //ģʽΪselectʱ��ǰѡ���ؼ���Ĭ��ֵ���ڳ�������
    var tmpvalue = "";

    this.Init = function () {
        OldValue = $F(this.InputTxtID);

        //��ʼ��htmlԪ��
        if ("div" == this.Mode) {
            //��Ӹ�����
            var tmpdiv = document.createElement("div");
            tmpdiv.id = obj + "DisplayData";
            tmpdiv.style.position = "absolute";
            tmpdiv.style.width = DivWidth;
            tmpdiv.style.padding = "10px";
            tmpdiv.style.paddingTop = "0";
            tmpdiv.style.display = "none";
            tmpdiv.className = "SelectClassType";
            var closediv = document.createElement("div");
            closediv.style.textAlign = "right";
            closediv.style.width = "95%";
            closediv.id = obj + "Close"
            tmpdiv.appendChild(closediv);
            var dataul = document.createElement("ul");
            dataul.id = obj + "DisplayDataUL";
            tmpdiv.appendChild(dataul);

            $(showDivID).appendChild(tmpdiv);

            var tmpul = document.createElement("ul");
            tmpul.id = obj + "MainItem";
            tmpul.className = "SelectClassTypeItem";
            mainobj = tmpul;
            $(showDivID).appendChild(tmpul);
        }
        else if ("select" == this.Mode) {

        }

        //��ʼ����ȡĬ������
        if ("" != $F(thisObj.InputTxtID) && parseInt($F(thisObj.InputTxtID)) > 0) {
            var ajax = new Ajax(thisObj.ActionID, "&strID=" + $F(thisObj.InputTxtID) + "&Mode=GetInfo&module=" + this.ModuleName + "&Params=" + this.Params);
            ajax.onSuccess = function () {
                if (null != ajax.data) {
                    if ("" != ajax.data.FullID && "0" != ajax.data.FullID) {
                        var arrID = unescape(ajax.data.FullID).split(",");
                        var arrName = unescape(ajax.data.FullName).split(",");
                        for (i = 0; i < arrID.length; i++) {
                            if ("div" == thisObj.Mode) {
                                if (0 == i)
                                    thisObj.AddNode(0, arrName[i]);
                                else
                                    thisObj.AddNode(arrID[i - 1], arrName[i]);
                            }
                            else if ("select" == thisObj.Mode) {
                                if (0 == i)
                                    thisObj.AddNodeForSel(0, arrID[i], arrName[i]);
                                else
                                    thisObj.AddNodeForSel(arrID[i - 1], arrID[i], arrName[i]);
                            }
                        }
                    }

                    if ("div" == thisObj.Mode) {
                        thisObj.AddNode(ajax.data.ParentID, unescape(ajax.data.Name));
                    }
                    else if ("select" == thisObj.Mode) {
                        thisObj.AddNodeForSel(ajax.data.ParentID, $F(thisObj.InputTxtID), unescape(ajax.data.Name));
                    }

                    if (ajax.data.HasSub == "true") {
                        if ("div" == thisObj.Mode) {
                            thisObj.AddNode($F(thisObj.InputTxtID));
                        }
                        else if ("select" == thisObj.Mode) {
                            thisObj.AddNodeForSel($F(thisObj.InputTxtID));
                        }
                    }
                }
            }
        }
        else {
            if ("div" == this.Mode) {
                thisObj.AddNode(0);
            }
            else if ("select" == this.Mode) {
                thisObj.AddNodeForSel(0);
            }
        }

    }

    this.AddNode = function (strID, strName) {
        if (this.MaxLevel <= this.IndexLevel) return;
        this.IndexLevel++;
        var tmpli = document.createElement("li");
        tmpli.id = obj + "li" + this.IndexLevel;
        tmpli.innerHTML = "<a href=\"javascript:" + obj + ".ShowData(" + strID + "," + this.IndexLevel + ");\">" + (undefined == strName ? "��ѡ��" : strName) + "</a>";
        mainobj.appendChild(tmpli);
    }

    this.close = function () {
        $(obj + "DisplayData").style.display = "none";
    }

    this.ShowData = function (strID, level) {
        if (!this.OnClick()) return;

        this.IndexLevel = level;

        //���¹رղ�����ѡ��
        $(obj + "Close").innerHTML = "<a href=\"javascript:" + obj + ".SelectItem(" + strID + ",'��ѡ��'," + strID + ",false);\" title=\"���ѡ�����\">���ѡ��</a> | <a href=\"javascript:" + obj + ".close();\">�ر�</a>";

        var ajax = new Ajax(this.ActionID, "&strID=" + strID + "&module=" + this.ModuleName);
        ajax.onSuccess = function () {
            var tmpData = "";
            if (ajax.state.result == 0) {
                tmpData = ajax.state.message;
            }
            else {
                for (i = 0; i < ajax.data.Item.length; i++) {
                    tmpData += "<li><a href=\"javascript:" + obj + ".SelectItem(" + ajax.data.Item[i].ID + ",'" + unescape(ajax.data.Item[i].Name) + "'," + strID + "," + ajax.data.Item[i].HasSub + ");\" title=\"���ѡ�����\">" + unescape(ajax.data.Item[i].Name) + "</a></li>";
                }
            }

            $(obj + "DisplayDataUL").innerHTML = tmpData;
            $(obj + "DisplayData").style.display = "block";
            //��λ����ʾ��λ��
            var mouse = mouseCoords();

            var dw = parseInt($(obj + "DisplayData").style.width) + parseInt($(obj + "DisplayData").style.padding) * 2;
            if ((mouse.x + dw) < document.body.clientWidth)
                $(obj + "DisplayData").style.left = mouse.x + "px";
            else
                $(obj + "DisplayData").style.left = (mouse.x - dw) + "px";
            $(obj + "DisplayData").style.top = mouse.y + "px";
        }
    }

    this.SelectItem = function (strID, areaName, parentID, isInsert) {
        if (parseInt(strID) <= 0)
            $(this.InputTxtID).value = "";
        else
            $(this.InputTxtID).value = strID;

        $(obj + "li" + this.IndexLevel).innerHTML = "<a href=\"javascript:" + obj + ".ShowData(" + parentID + "," + this.IndexLevel + ");\">" + areaName + "</a>";
        var isShow = isInsert;
        if (this.MaxLevel <= this.IndexLevel) isShow = false;
        for (i = this.IndexLevel + 1; i <= this.MaxLevel; i++) {
            if ($(obj + "li" + i)) {
                mainobj.removeChild($(obj + "li" + i));
            }
            else
                break;
        }
        if (isShow) {
            this.AddNode(strID);
        }
        $(obj + "DisplayData").style.display = "none";

        this.OnChange();
    }

    this.AddNodeForSel = function (strParentID, strID, strName) {
        if (this.MaxLevel <= this.IndexLevel) return;
        this.IndexLevel++;
        var tmpsel = document.createElement("select");
        //��ʱ��ŵ�ǰ������ ��Ϊ��ȡ�������첽��ʽ
        var tmpIndex = this.IndexLevel;
        tmpsel.id = obj + "sel" + this.IndexLevel;
        tmpsel.options.add(new Option("��ѡ��", strParentID + "_false_" + this.IndexLevel));
        //ȡ�ø�������ݲ����select
        var ajax = new Ajax(this.ActionID, "&strID=" + strParentID + "&module=" + this.ModuleName + "&Params=" + this.Params);
        ajax.onSuccess = function () {
            if (ajax.state.result == 0) {
                //sAlert(ajax.state.message);
            }
            else {
                for (i = 0; i < ajax.data.Item.length; i++) {
                    var op = new Option(unescape(ajax.data.Item[i].Name), ajax.data.Item[i].ID + "_" + ajax.data.Item[i].HasSub + "_" + tmpIndex);
                    if (parseInt(strID) == parseInt(ajax.data.Item[i].ID)) op.selected = true;
                    tmpsel.options.add(op);
                }
            }
        }

        tmpsel.onclick = function () { tmpvalue = this.value; }
        tmpsel.onchange = this.SelectChange;
        mainobj.appendChild(tmpsel);
    }

    this.SelectChange = function () {

        if (!thisObj.OnClick()) {
            this.value = tmpvalue;
            return false;
        }

        var strID = parseInt(this.value.split("_")[0]);
        var isShow = "true" == this.value.split("_")[1];
        thisObj.IndexLevel = parseInt(this.value.split("_")[2]);

        if (parseInt(strID) <= 0)
            $(thisObj.InputTxtID).value = "";
        else
            $(thisObj.InputTxtID).value = strID;

        if (thisObj.MaxLevel <= thisObj.IndexLevel) isShow = false;

        for (i = thisObj.IndexLevel + 1; i <= thisObj.MaxLevel; i++) {
            if ($(obj + "sel" + i)) {
                mainobj.removeChild($(obj + "sel" + i));
            }
            else
                break;
        }
        if (isShow) {
            thisObj.AddNodeForSel(strID);
        }

        thisObj.OnChange();
    }

    //��յ�ǰѡ��
    this.Clear = function () {
        this.IndexLevel = 0;
        $(this.InputTxtID).value = OldValue;
        $(showDivID).innerHTML = "";
        this.Init();
    }

    this.OnChange = function () {
        //���ֵ�ı�Ĵ�����
    }

    this.OnClick = function () {
        //����¼�������
        return true;
    }
}

function ClassTypes(objName, moduleFlagTextId, showDivID, inputTxtID, maxNum,ac) {
    //��ʼ��ȫ�ֱ���    
    if (ac == undefined || ac == "") {
        this.ActionID = "XY001";
    } else {
        this.ActionID = ac;
    }

    this.MaxNum = undefined == maxNum ? 999 : arguments[5];
    this.IndexLevel = 0;
    this.InputTxtID = inputTxtID;
    this.ModuleName = $(moduleFlagTextId) != undefined ? $F(moduleFlagTextId) : moduleFlagTextId;
    //���ѡ���Ѿ�ѡ��ĸ��������
    this.IsSelChild = false;
    var obj = objName;
    var thisObj = this;
    var mainobj = $(showDivID);

    //�洢�Ѿ�ѡ��Ķ��������
    var SelectedItems = [];

    //�������ڴ�С
    var dWidth = 700;
    var dHeight;

    this.Init = function () {
        //��Ӹ�����
        var html = '';

        html = '' +
        '<a href="javascript:' + obj + '.Show();">��ѡ��</a>' +
        '<div id="' + obj + 'selectedvalues"></div>' +
        '<div id="' + obj + 'selectbg" class="SelectClassTypesbg shidden"></div>' +
        '<div id="' + obj + 'selectMain" class="SelectClassTypesmain shidden">' +
            '<div class="SelectClassTypestit smove" onmousedown="drag(event,\'' + obj + 'selectMain\')">' +
            '    <h2 class="sleft">��ѡ��</h2>' +
            '    <span class="spointer sright" onclick="' + obj + '.Close();">[ȡ��]</span>' +
            '    <span class="spointer sright" onclick="' + obj + '.Update();">[ȷ��]</span>' +
            '</div>' +
            '<div class="SelectClassTypescls"></div>' +
            '<div class="SelectClassTypescont">' +
            '    <div id="' + obj + 'selectSub">' +
            '    </div>' +
            '    <div id="' + obj + 'selectItems">' +
            '    </div>' +
            '</div>' +
            '<div class="SelectClassTypespreview">' +
            '    <div class="SelectClassTypespreviewtit">' +
            '        <h2>��ѡ��</h2>' +
            '    </div> ' +
            '    <div class="SelectClassTypescont" id="' + obj + 'selectPreviewItem"></div>' +
            '</div>' +
        '</div>'
        insertHtml("beforeend", mainobj, html);
        mainobj = $(obj + "selectSub");

        //��ʼ����ȡĬ������
        if ("" != $F(thisObj.InputTxtID) && "0" != $F(thisObj.InputTxtID)) {
            var ajax = new Ajax(thisObj.ActionID, "&strID=" + $F(thisObj.InputTxtID) + "&Mode=GetInfos&module=" + this.ModuleName);
            ajax.onSuccess = function () {
                if (null != ajax.data) {
                    for (i = 0; i < ajax.data.Item.length; i++) {
                        thisObj.AddItem(ajax.data.Item[i].ID, unescape(ajax.data.Item[i].Name));
                    }
                    thisObj.RefurbishParentDoc();
                }
            }
        }
        this.AddNode(0, 0);
    }

    this.SelectBoxItem = function (objBox, strID, strName) {
        if (!objBox.checked) {
            this.RemoveItem(strID);
        }

        if (SelectedItems.length >= this.MaxNum) {
            sAlert("�����ѡ��" + this.MaxNum + "��");
            objBox.checked = false;
            return;
        }

        if (objBox.checked) {
            this.AddItem(strID, strName);
        }
    }

    this.AddItem = function (strID, strName) {
        SelectedItems[SelectedItems.length] = { ID: strID, Name: strName };
        this.Refurbish();
    }

    this.RemoveItem = function (strID) {
        //�����ǰ���б����б�ɾ����� ��ȡ�������ѡ��
        var arr = $(obj + "selectItems").getElementsByTagName("input");
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].type == "checkbox") {
                if (parseInt(arr[i].value) == parseInt(strID)) {
                    arr[i].checked = false;
                    break;
                }
            }
        }

        for (var i = 0; i < SelectedItems.length; i++) {
            if (parseInt(SelectedItems[i].ID) == parseInt(strID)) {
                SelectedItems.splice(i, 1);
                break;
            }
        }

        this.Refurbish();
    }

    //��ǰҪ���������Ƿ��Ѿ���ѡ��
    this.IsCheckedLevelID = function () {
        var arr = $(obj + "selectSub").getElementsByTagName("select");
        for (var i = 0; i < arr.length; i++) {
            for (var sindex = 0; sindex < SelectedItems.length; sindex++) {
                if (parseInt(SelectedItems[sindex].ID) == parseInt(arr[i].value)) {
                    return true;
                }
            }
        }
        return false;
    }

    //�ж��Ƿ��Ѿ�ѡ���˸���
    this.IsChecked = function (strID) {
        for (var i = 0; i < SelectedItems.length; i++) {
            if (parseInt(SelectedItems[i].ID) == parseInt(strID)) {
                return true;
            }
        }
        return false;
    }

    this.Refurbish = function () {
        var str = '<ul>';
        for (var i = 0; i < SelectedItems.length; i++) {
            str += '<li><input type="checkbox" checked="true" onclick="' + obj + '.RemoveItem(' + SelectedItems[i].ID + ');" />' + SelectedItems[i].Name + '</li>';
        }
        str += '</ul>';
        $(obj + "selectPreviewItem").innerHTML = str;
    }

    this.RefurbishParentDoc = function () {
        var html = "";
        var ids = "";
        for (var i = 0; i < SelectedItems.length; i++) {
            ids += 0 == i ? "" : ","
            ids += SelectedItems[i].ID;
            html += '<input type="checkbox" checked="true" onclick="' + obj + '.RemoveItemByDoc(' + SelectedItems[i].ID + ');" />' + SelectedItems[i].Name;
        }
        $(this.InputTxtID).value = ids;
        $(obj + "selectedvalues").innerHTML = html;
    }

    this.RemoveItemByDoc = function (strID) {
        this.RemoveItem(strID);
        this.RefurbishParentDoc();
    }

    this.Show = function () {
        var scrollPos = new getScrollPos();
        var pageSize = new getPageSize();

        $(obj + "selectbg").style.display = "block";
        $(obj + "selectbg").style.height = pageSize.docheight + "px";
        $(obj + "selectMain").style.display = "block";

        dHeight = $(obj + "selectMain").clientHeight;
        var x = Math.round(pageSize.width / 2) - (dWidth / 2) + scrollPos.scrollX;
        var y = Math.round(pageSize.height / 2) - (dHeight / 2) + scrollPos.scrollY;

        $(obj + "selectMain").style.width = dWidth + "px";
        //$(obj + "selectMain").style.height = dHeight + "px";
        $(obj + "selectMain").style.left = x + 'px';
        $(obj + "selectMain").style.top = y + 'px';
    }

    this.Update = function () {
        this.RefurbishParentDoc();
        this.Close();
    }

    this.Close = function () {
        $(obj + 'selectbg').style.display = "none";
        $(obj + 'selectMain').style.display = "none";
    }

    this.AddNode = function (strParentID, strID, strName) {
        //����Ѿ�ѡ���˸��� ���˳�
        if (!thisObj.IsSelChild && thisObj.IsCheckedLevelID()) {
            $(obj + "selectItems").innerHTML = "";
            return;
        }

        this.IndexLevel++;

        var tmpsel = document.createElement("select");
        //��ʱ��ŵ�ǰ������ ��Ϊ��ȡ�������첽��ʽ
        var tmpIndex = this.IndexLevel;
        tmpsel.id = obj + "sel" + this.IndexLevel;
        tmpsel.options.add(new Option("��ѡ��", strParentID + "_parent_" + this.IndexLevel));
        //ȡ�ø�������ݲ����select�Ͷ�ѡ��
        var ajax = new Ajax(this.ActionID, "&strID=" + strParentID + "&module=" + this.ModuleName);
        ajax.onSuccess = function () {
            if (ajax.state.result == 0) {
                sAlert(ajax.state.message);
            }
            else {
                var html = '<ul>';
                var tmpstr = '';
                for (i = 0; i < ajax.data.Item.length; i++) {
                    var op = new Option(unescape(ajax.data.Item[i].Name), ajax.data.Item[i].ID + "_" + ajax.data.Item[i].HasSub + "_" + tmpIndex);
                    if (parseInt(strID) == parseInt(ajax.data.Item[i].ID)) op.selected = true;
                    tmpsel.options.add(op);

                    tmpstr = "";
                    if (thisObj.IsChecked(ajax.data.Item[i].ID)) {
                        tmpstr = ' checked="true" '
                    }
                    html += '<li><input type="checkbox" ' + tmpstr + ' value="' + ajax.data.Item[i].ID + '" onclick="' + obj + '.SelectBoxItem(this,' + ajax.data.Item[i].ID + ',\'' + unescape(ajax.data.Item[i].Name) + '\');" />' + unescape(ajax.data.Item[i].Name) + '</li>';

                }
                html += '</ul>';
                $(obj + "selectItems").innerHTML = html;
            }
        }
        tmpsel.onchange = this.SelectChange;
        $(obj + "selectSub").appendChild(tmpsel);
    }

    this.SelectChange = function () {
        var strID = parseInt(this.value.split("_")[0]);
        var isShow = "true" == this.value.split("_")[1];
        var tmplevel = thisObj.IndexLevel;
        thisObj.IndexLevel = parseInt(this.value.split("_")[2]);
        if ("parent" == this.value.split("_")[1]) {
            isShow = true;
            thisObj.IndexLevel = thisObj.IndexLevel - 1
        }

        for (i = thisObj.IndexLevel + 1; i <= tmplevel; i++) {
            if ($(obj + "sel" + i)) {
                mainobj.removeChild($(obj + "sel" + i));
            }
            else
                break;
        }
        if (isShow) {
            thisObj.AddNode(strID);
        }
        else {
            $(obj + "selectItems").innerHTML = "";
        }
        thisObj.OnChange();
    }

    this.OnChange = function () {
        //���ֵ�ı�Ĵ�����
    }
}
/******************************   Select Class End *********************************/

/***************************ͨ�ü�⺯��********************************/

String.prototype.trim = function () {
    return this.replace(/^\s*/g, "").replace(/\s*$/g, "");
}

//��֤Email��ʽ
function ValidateEmail(source) {
    var patrn = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    return patrn.exec(source.trim());
}

//���绰
function ValidateTel(source) {
    source = source.trim();
    var patrn = /^((\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{2,}))?$/;
    var patrn1 = /^(\d{3})-(\d{3})-(\d{4})$/;

    return patrn.exec(source.trim()) || patrn1.exec(source.trim());
}

//����Զ��Ÿ����Ķ���绰����
function ValidateTels(source) {
    source = source.trim();
    source = source.replace('��', ',');
    var telformat = source.split(',');
    for (var i = 0; i < telformat.length; i++) {
        if (!ValidateTel(telformat[i].trim())) {
            return false;
        }
    }
    return true;
}

//����ֻ�
function ValidateMobileTel(source) {
    var patrn = /^1\d{10}$/;
    return patrn.exec(source.trim());
}

//����Զ��Ÿ����Ķ���ֻ���
function ValidateMobileTels(source) {
    source = source.trim();
    source = source.replace('��', ',');
    var telformat = source.split(',');
    for (var i = 0; i < telformat.length; i++) {
        if (!ValidateMobileTel(telformat[i].trim())) {
            return false;
        }
    }
    return true;
}

//��֤Ϊ����
function ValidateNum(source) {
    var patrn = /^\d+$/;
    return patrn.exec(source.trim());
}
//��ֻ֤����a-z,A-Z��0-9��ɵ��ַ���
function ValidateS(source) {
    var patrn = /^[a-zA-Z0-9]+$/
    return patrn.exec(source.trim());
}
//��ֻ֤����a-z,A-Z��ɵ��ַ���
function ValidateLetter(source) {
    var patrn = /^[a-zA-Z]+$/
    return patrn.exec(source.trim());
}
//��֤�Ƿ��пո�\/��\\��\'��\"��\<��\>�������ַ�,����������!
function ValidateInput(source) {
    len = source.length;
    for (i = 0; i < len; i++) {
        while (source.charAt(i) == " " || source.charAt(i) == "\\" || source.charAt(i) == "/" || source.charAt(i) == "'" || source.charAt(i) == "\"" || source.charAt(i) == "*" || source.charAt(i) == "<" || source.charAt(i) == ">") {
            return true;
        }
    }
}

//��֤�ַ����Ƿ�ȫ������
function ValidateCNAll(source) {
    var patrn = /^[\u0391-\uFFE5]+$/
    return patrn.exec(source.trim());
}
//��֤�ַ������Ƿ��������
function ValidateCN(source) {
    var patrn = /^(\w*)([\u0391-\uFFE5]+)(\w*)+$/
    return patrn.exec(source.trim());
}

function IsIncludeChinese(source) {
    var patrn = /^(\w*)([\u0391-\uFFE5]+)(\w*)+$/
    return patrn.test(source.trim());
}
//��֤URL��ַ��ʽ
function ValidateUrl(source) {
    var regExp = new RegExp("((^http)|(^https)|(^ftp)):\/\/(\\w)+\.(\\w)+");
    var rtn = source.match(regExp);
    if (rtn == null) {
        return false;
    }
    else {
        return true;
    }
}
//��֤�����ڸ�ʽ
function ValidateLongDate(source) {
    var patrn = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$/
    return patrn.exec(source.trim());
}
//��֤�����ڸ�ʽ
function ValidateShortDate(source) {
    var patrn = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29))$/
    return patrn.exec(source.trim());
}

//��֤���֤����
function ValidateIdCode(source) {
    var patrn = /^([0-9]{15}|[0-9]{18})$/
    return patrn.test(source.trim());
}

//��֤���֤����
function ValidateZipCode(source) {
    var patrn = /^\d{6}$/
    return patrn.test(source.trim());
}


/***************************end ͨ����֤����********************************/

/*************************  ����ͨ�ú�����ʼ ************************************/



//�滻�����Զ����ַ�Ϊ���ַ�
//str:Ŀ���ַ���
//oChr:ԭ�ַ�
//dChr:���ַ�
function ReplaceAll(str, oChr, dChr) {
    str = str.trim();
    var len = str.length;

    if (len <= 0) return "";

    for (var i = 0; i < len; i++) {
        str = str.replace(oChr, dChr);
    }
    return str;
}


//�������ⳤ�ȵ��������
function GetRandom(numLength) {
    var rnd = "";
    for (i = 0; i < numLength; i++) {
        rnd = rnd + Math.floor(Math.random() * 10)
    }
    return rnd;
}

//�ַ�������ǰ�ո�س�
function TrimLeft(source) {
    while (source.charAt(0) == " ") {
        source = source.substr(1);
    }
    return source;
}
//�ַ������к�ո�س�
function TrimRight(source) {
    while (source.charAt(source.length - 1) == " ") {
        source = source.substr(0, source.length - 1);
    }
    return source;
}
//�ַ���������ĩλ�ո�س�
function Trim(source) {
    return TrimRight(TrimLeft(source));
}
//�õ��ַ�������ʵ���ȣ�˫�ֽڻ���Ϊ�������ֽڣ� 
function GetLength(source) {
    return source.replace(/[^\x00-\xff]/g, "xx").length;
}

//��ָ��Ԫ�ظ�ֵ
//���Ԫ����,�Ÿ���
function SetElementValue(eleIds, value) {

    if (eleIds.trim() == "") return;

    var eles = eleIds.split(',');

    for (var i = 0; i < eles.length; i++) {
        if (document.getElementById(eles[i])) {
            document.getElementById(eles[i]).value = value;
        }
    }
}

function xy_selectBox(tabTotal, curIndex, prefix, curClsName) {
    if (curClsName == undefined) curClsName = "current";

    for (i = 1; i <= tabTotal; i++) {
        if (i == curIndex) {
            eval("$('" + prefix + "_tab" + curIndex + "').className='" + curClsName + "';");
            eval("$('" + prefix + "_box" + curIndex + "').style.display = 'block';");

        }
        else {
            eval("$('" + prefix + "_tab" + i + "').className='';");
            eval("$('" + prefix + "_box" + i + "').style.display = 'none';");
        }
    }
}

/*************************  ����ͨ�ú������� ************************************/

function div_opennew(_id, _width, _height) {
    var newDiv = document.getElementById(_id);

    if (newDiv.style.display == 'none') {
        newDiv.style.position = "absolute";
        newDiv.style.zIndex = "9999";
        newDiv.style.width = _width + "px";
        newDiv.style.height = _height + "px";
        newDiv.style.background = "#fff";
        newDiv.style.border = "1px solid #ccc";
        newDiv.style.padding = "5px";

        newDiv.style.display = 'block';

        //��λ����ʾ��λ��
        var mouse = mouseCoords();

        var dw = parseInt(_width) + parseInt(newDiv.style.padding) * 2;

        if ((mouse.x + dw) < document.body.clientWidth)
            newDiv.style.left = mouse.x + "px";
        else
            newDiv.style.left = (mouse.x - dw) + "px";

        newDiv.style.top = mouse.y + "px";
    }
    else {
        newDiv.style.display = 'none';
    }
    return;
}


function div_mouseover(pos) {
    try { window.clearTimeout(timerDiv); } catch (e) { }
}

function div_mouseout(pos) {
    var posSel = document.getElementById(pos).style.display;
    if (posSel == "block") {
        timerDiv = setTimeout("div_hide('" + pos + "')", 1000);
    }
}

function div_hide(pos) {
    document.getElementById(pos).style.display = "none";
}

function _xy_KeyPress(btnId) {
    if (event.keyCode == 13) {
        $(btnId).onclick();
    }
}

function _xy_KeyNext(objId) {
    if (event.keyCode == 13) {
        $(objId).focus();
    }
}


//ȫѡ
function SelectAll() {
    var chkall = document.all["chkAll"];

    if (!chkall) {
        chkall = document.getElementById("chkAll");
    }

    var chkother = document.getElementsByTagName("input");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkId') > -1) {
                chkother[i].checked = chkall.checked;
            }
        }
    }
}
//��ѡ����ɾ��ʱ��ȷ��ɾ��
function ConfirmDel(isen) {
    var mess = "ȷ��ɾ����?";
    if (isen == true) {
        mess = "Sure you want to delete it?";
    }
    if (CheckSel(isen)) {
        return confirm(mess);
    }
    return false;
}

//���ص���ǰ��ַ���� burl= ���Ƿ��صĵ�ַ
function back() {
    var index = window.location.search.indexOf("burl=");
    var url = window.location.search.substr(index + 5);
    window.location.href = url;
}