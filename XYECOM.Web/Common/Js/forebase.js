document.writeln("<script language=\"javascript\" type=\"text/javascript\" src=\"/config/js/config.js\"></script>");

var XY_LOADING = "<img src =\"/common/images/ajax-loader.gif\"/><br/>数据正在录入，请稍等...";

var XY_LOADING_SMALL = "<img src =\"/common/images/ajax-loading-circle.gif\" alt=\"正在加载中....\"/>";

function $F(element) {
    return document.getElementById(element).value;
}

function GetNewCode() {
    return config.WebURL + "common/ValidateCode.ashx?" + Math.random();
}

//给客户端追加js脚本块
//funcName:函数名
//scriptText:函数内容
function attachScript(funcName, scriptText) {
    var script = document.createElement("script");
    script.type = "text/javascript";
    script.text = "function " + funcName + "(){" + scriptText + ";}";
    //document.getElementsByTagName("head")[0].appendChild(script)
    document.body.appendChild(script);
}

//给客户端追加隐藏表单
//eleName:表单名称
//value:表单值
function attachHiddleField(eleName, value) {
    var ele = document.createElement("input");
    ele.id = eleName;
    ele.name = eleName;
    ele.type = "hidden";
    ele.value = value;
    document.body.appendChild(ele);
}


//获取单选按钮组当前选中项的值
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


/********************** 对象添加拖拽操作 ****************************/
var oDrag;
var ox, oy, nx, ny, dy, dx;
function drag(e, o) {
    var e = e ? e : event;
    var mouseD = IE() ? 1 : 0;
    if (e.button == mouseD) {
        oDrag = $("#" + o)[0];
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
/********************** 对象添加拖拽操作结束 ****************************/

function IncludeJs(path) {
    var script = document.createElement('script');
    script.src = path;
    script.type = 'text/javascript';

    document.getElementsByTagName('head')[0].appendChild(script);
}

//设置图片的大小
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
//取得Get传值中的参数
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

//获取指定名称的cookie的值
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

//添加Cookie
function addCookie(objName, objValue, objHours) {
    //添加cookie
    var str = objName + "=" + escape(objValue);

    if (objHours > 0) {
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; expires=" + date.toGMTString();
    }
    document.cookie = str;
}

/*
* 获取 document.body 对象
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

//取得页面尺寸
function getPageSize() {

    var docElem = document.documentElement
    //可见区域宽度
    this.width = self.innerWidth || (docElem && docElem.clientWidth) || document.body.clientWidth;
    //可见区域高度
    this.height = self.innerHeight || (docElem && docElem.clientHeight) || document.body.clientHeight;
    //页面的总高度
    this.docheight = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight);
}

//取得对象尺寸
function getElementSize(elem) {
    this.width = elem.clientWidth || elem.style.pixelWidth;
    this.height = elem.clientHeight || elem.style.pixelHeight;
}


//计算滚动条像素
function getScrollPos() {

    var docElem = document.documentElement;

    this.scrollX = self.pageXOffset || (docElem && docElem.scrollLeft) || document.body.scrollLeft;

    this.scrollY = self.pageYOffset || (docElem && docElem.scrollTop) || document.body.scrollTop;
}

//使对象居为屏幕中央
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


//获取鼠标位置
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
* 清空指定表单元素的值
*/
function ClearObjectValue() {
    var eles = arguments;
    for (i = 0; i < eles.length; i++) {
        $("#" + eles[i] + '')[0].value = '';
    }
}

/*
* 页面跳转
*/
function GoTo(url) {
    window.location.href = url;
}
//验证是否是数字
function IsNum(str) {

    var re = /^[\d]+$/
    return re.test(str);

}
/****************************** 对话框sAlert ************************************/
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
    strHtml += '      <span class="xyAlertBoxBoxTitle">系统提示信息</span><br /> <p id="msgcontent"></p>';
    strHtml += '      </div>';
    strHtml += '      <div class="xyAlertBoxButtons">';
    strHtml += '        <input class="BoxAlertBtnOk" onclick="' + objName + '.doOk();" type="button" value="关闭">';
    strHtml += '      </div>';
    strHtml += '    </div>';
    strHtml += '  </div>';
    strHtml += '</div>';

    document.write(strHtml);

    var div = $("#_xy_alert_")[0];
    var backURL = "";
    var objMsg = objName;
    var obj = this;

    var interval;
    var timeout;

    this.AlertMsg = function (errorMsg, strurl, autoHidden) {
        window.clearInterval(interval);
        window.clearTimeout(timeout);

        this.Show(errorMsg, strurl, autoHidden);
        this.Show(errorMsg, strurl, autoHidden);
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
        $("#msgcontent")[0].innerHTML = errorMsg;

        var pageSize = new getPageSize();
        div.style.height = pageSize.docheight + "px";
        $("#_xy_alert_inner_div")[0].style.display = 'block';
        //对子DIV进行设置
        var mydiv = $("#_xy_alert_inner_div")[0];

        posToCenter(mydiv);
    }

    //释放DIV
    this.doOk = function (strurl) {
        if (backURL != "")
            window.location.href = backURL;

        div.style.display = "none";
        $("#_xy_alert_inner_div")[0].style.display = "none";
        window.clearInterval(interval);
        window.clearTimeout(timeout);
    }
}

var objMsg = new MsgClass("objMsg");
//弹出DIV
function sAlert(errorMsg, strurl, autoHidden) {
    objMsg.AlertMsg(errorMsg, strurl, autoHidden);
}

//停止调用setInterval
function sStop() {
    objMsg.Stop();
}
//开启调用setInterval
function sStart() {
    objMsg.Start();
}

function sClose() {
    objMsg.doOk();
}
/****************************** 对话框sAlert结束 ************************************/

/****************************** ajax start ************************************/
var AjaxIndex = 0; //全局的ajax索引，表示唯一的ajax实例
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
        if (oNode.childNodes.length > 0) {//如果有数据		
            var ii = false;
            for (var i = 0; i < oNode.childNodes.length; i++) {
                var oItem = oNode.childNodes[i];
                if (oItem.nodeType == 1) {//判断是否是Element类型
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
        //内部数据处理方法;
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

//显示类别信息
//      objName             外部实例化的对象名
//      moduleFlagTextId    模块标识名称表单Id
//      showDivID:          显示类别信息的Div的ID，
//      inputTxtID:         页面接受选择后的ID的文本字段
//      acID:               要选择哪个类别表的ID 对应ajax里面的程序
//      level:              显示多少级 默认为全部
//      params            自定义参数  key:value|key1:value1
function ClassType(objName, moduleFlagTextId, showDivID, inputTxtID, level, ac, params) {
    var DivWidth = "240px";
    //初始化全局变量

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
    this.lanuage = "0";
    this.Params = params == undefined ? "" : params;

    this.IndexLevel = 0;
    this.InputTxtID = inputTxtID;
    this.ModuleName = $("#" + moduleFlagTextId)[0] != undefined ? $F(moduleFlagTextId) : moduleFlagTextId;
    //存储默认值
    var OldValue = "";

    this.Mode = "div"; //div or select
    var obj = objName;
    var thisObj = this;
    var mainobj = $("#" + showDivID)[0];
    //模式为select时当前选定控件的默认值用于撤销操作
    var tmpvalue = "";

    this.Init = function () {
        OldValue = $F(this.InputTxtID);

        //初始化html元素
        if ("div" == this.Mode) {
            //添加浮动层
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

            $("#" + showDivID)[0].appendChild(tmpdiv);

            var tmpul = document.createElement("ul");
            tmpul.id = obj + "MainItem";
            tmpul.className = "SelectClassTypeItem";
            mainobj = tmpul;
            $("#" + showDivID)[0].appendChild(tmpul);
        }
        else if ("select" == this.Mode) {

        }

        //初始化读取默认数据
        if ("" != $F(thisObj.InputTxtID) && parseInt($F(thisObj.InputTxtID)) > 0) {
            var ajax = new Ajax(thisObj.ActionID, "&strID=" + $F(thisObj.InputTxtID) + "&Mode=GetInfo&module=" + this.ModuleName + "&Params=" + this.Params + "&lanuage=" + this.lanuage);
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
        tmpli.innerHTML = "<a href=\"javascript:" + obj + ".ShowData(" + strID + "," + this.IndexLevel + ");\">" + (undefined == strName ? "请选择" : strName) + "</a>";
        mainobj.appendChild(tmpli);
    }

    this.close = function () {
        $("#" + obj + "DisplayData")[0].style.display = "none";
    }

    this.ShowData = function (strID, level) {
        if (!this.OnClick()) return;

        this.IndexLevel = level;

        //更新关闭层的清空选项
        $("#" + obj + "Close")[0].innerHTML = "<a href=\"javascript:" + obj + ".SelectItem(" + strID + ",'请选择'," + strID + ",false);\" title=\"点击选择此项\">清空选项</a> | <a href=\"javascript:" + obj + ".close();\">关闭</a>";

        var ajax = new Ajax(this.ActionID, "&strID=" + strID + "&module=" + this.ModuleName + "&lanuage=" + this.lanuage);
        ajax.onSuccess = function () {
            var tmpData = "";
            if (ajax.state.result == 0) {
                tmpData = ajax.state.message;
            }
            else {
                for (i = 0; i < ajax.data.Item.length; i++) {
                    tmpData += "<li><a href=\"javascript:" + obj + ".SelectItem(" + ajax.data.Item[i].ID + ",'" + unescape(ajax.data.Item[i].Name) + "'," + strID + "," + ajax.data.Item[i].HasSub + ");\" title=\"点击选择此项\">" + unescape(ajax.data.Item[i].Name) + "</a></li>";
                }
            }

            $("#" + obj + "DisplayDataUL")[0].innerHTML = tmpData;
            $("#" + obj + "DisplayData")[0].style.display = "block";
            //定位层显示的位置
            var mouse = mouseCoords();

            var dw = parseInt($("#" + obj + "DisplayData")[0].style.width) + parseInt($("#" + obj + "DisplayData")[0].style.padding) * 2;
            if ((mouse.x + dw) < document.body.clientWidth)
                $("#" + obj + "DisplayData")[0].style.left = mouse.x + "px";
            else
                $("#" + obj + "DisplayData")[0].style.left = (mouse.x - dw) + "px";
            $("#" + obj + "DisplayData")[0].style.top = mouse.y + "px";
        }
    }

    this.SelectItem = function (strID, areaName, parentID, isInsert) {
        if (parseInt(strID) <= 0)
            $("#" + this.InputTxtID)[0].value = "";
        else
            $("#" + this.InputTxtID)[0].value = strID;

        $("#" + obj + "li" + this.IndexLevel)[0].innerHTML = "<a href=\"javascript:" + obj + ".ShowData(" + parentID + "," + this.IndexLevel + ");\">" + areaName + "</a>";
        var isShow = isInsert;
        if (this.MaxLevel <= this.IndexLevel) isShow = false;
        for (i = this.IndexLevel + 1; i <= this.MaxLevel; i++) {
            if ($("#0" + obj + "li" + i)[0]) {
                mainobj.removeChild($("#" + obj + "li" + i)[0]);
            }
            else
                break;
        }
        if (isShow) {
            this.AddNode(strID);
        }
        $("#" + obj + "DisplayData")[0].style.display = "none";

        this.OnChange();
    }

    this.AddNodeForSel = function (strParentID, strID, strName) {
        if (this.MaxLevel <= this.IndexLevel) return;
        this.IndexLevel++;
        var tmpsel = document.createElement("select");
        //临时存放当前的索引 因为获取数据是异步方式
        var tmpIndex = this.IndexLevel;
        tmpsel.id = obj + "sel" + this.IndexLevel;
        tmpsel.options.add(new Option("请选择", strParentID + "_false_" + this.IndexLevel));
        //取得该类的数据并填充select
        var ajax = new Ajax(this.ActionID, "&strID=" + strParentID + "&module=" + this.ModuleName + "&Params=" + this.Params + "&lanuage=" + this.lanuage);
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
            $("#" + thisObj.InputTxtID)[0].value = "";
        else
            $("#" + thisObj.InputTxtID)[0].value = strID;

        if (thisObj.MaxLevel <= thisObj.IndexLevel) isShow = false;

        for (i = thisObj.IndexLevel + 1; i <= thisObj.MaxLevel; i++) {
            if ($("#" + obj + "sel" + i)[0]) {
                mainobj.removeChild($("#" + obj + "sel" + i)[0]);
            }
            else
                break;
        }
        if (isShow) {
            thisObj.AddNodeForSel(strID);
        }

        thisObj.OnChange();
    }

    //清空当前选择
    this.Clear = function () {
        this.IndexLevel = 0;
        $("#" + this.InputTxtID)[0].value = OldValue;
        $("#" + showDivID)[0].innerHTML = "";
        this.Init();
    }

    this.OnChange = function () {
        //类别值改变的处理方法
    }

    this.OnClick = function () {
        //点击事件处理方法
        return true;
    }
}

function ClassTypes(objName, moduleFlagTextId, showDivID, inputTxtID, maxNum, params) {
    //初始化全局变量
    this.ActionID = "XY001";
    this.MaxNum = undefined == maxNum ? 999 : arguments[5];
    this.IndexLevel = 0;
    this.InputTxtID = inputTxtID;
    this.ModuleName = $("#" + moduleFlagTextId)[0] != undefined ? $F(moduleFlagTextId) : moduleFlagTextId;
    this.Params = params == undefined ? "" : params;
    //如果选择已经选择的父类的子类
    this.IsSelChild = false;
    var obj = objName;
    var thisObj = this;
    var mainobj = $("#" + showDivID)[0];

    //存储已经选择的对象的数组
    var SelectedItems = [];

    //弹出窗口大小
    var dWidth = 700;
    var dHeight;

    this.Init = function () {
        //添加浮动层
        var html = '';

        html = '' +
        '<a href="javascript:' + obj + '.Show();">请选择</a>' +
        '<div id="' + obj + 'selectedvalues"></div>' +
        '<div id="' + obj + 'selectbg" class="SelectClassTypesbg shidden"></div>' +
        '<div id="' + obj + 'selectMain" class="SelectClassTypesmain shidden">' +
            '<div class="SelectClassTypestit smove" onmousedown="drag(event,\'' + obj + 'selectMain\')">' +
            '    <h2 class="sleft">请选择</h2>' +
            '    <span class="spointer sright" onclick="' + obj + '.Close();">[取消]</span>' +
            '    <span class="spointer sright" onclick="' + obj + '.Update();">[确定]</span>' +
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
            '        <h2>已选择</h2>' +
            '    </div> ' +
            '    <div class="SelectClassTypescont" id="' + obj + 'selectPreviewItem"></div>' +
            '</div>' +
        '</div>'
        insertHtml("beforeend", mainobj, html);
        mainobj = $("#" + obj + "selectSub")[0];

        //初始化读取默认数据
        if ("" != $F(thisObj.InputTxtID) && "0" != $F(thisObj.InputTxtID)) {
            var ajax = new Ajax(thisObj.ActionID, "&strID=" + $F(thisObj.InputTxtID) + "&Mode=GetInfos&module=" + this.ModuleName + "&Params=" + this.Params);
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
            sAlert("您最多选择" + this.MaxNum + "项");
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
        //如果当前的列表里有被删除类别 则取消该类的选择
        var arr = $("#" + obj + "selectItems")[0].getElementsByTagName("input");
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

    //当前要操作的类是否已经被选择
    this.IsCheckedLevelID = function () {
        var arr = $("#" + obj + "selectSub")[0].getElementsByTagName("select");
        for (var i = 0; i < arr.length; i++) {
            for (var sindex = 0; sindex < SelectedItems.length; sindex++) {
                if (parseInt(SelectedItems[sindex].ID) == parseInt(arr[i].value)) {
                    return true;
                }
            }
        }
        return false;
    }

    //判断是否已经选择了该类
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
        $("#" + obj + "selectPreviewItem")[0].innerHTML = str;
    }

    this.RefurbishParentDoc = function () {
        var html = "";
        var ids = "";
        for (var i = 0; i < SelectedItems.length; i++) {
            ids += 0 == i ? "" : ","
            ids += SelectedItems[i].ID;
            html += '<input type="checkbox" checked="true" onclick="' + obj + '.RemoveItemByDoc(' + SelectedItems[i].ID + ');" />' + SelectedItems[i].Name;
        }
        $("#" + this.InputTxtID)[0].value = ids;
        $("#" + obj + "selectedvalues")[0].innerHTML = html;
    }

    this.RemoveItemByDoc = function (strID) {
        this.RemoveItem(strID);
        this.RefurbishParentDoc();
    }

    this.Show = function () {
        var scrollPos = new getScrollPos();
        var pageSize = new getPageSize();

        $("#" + obj + "selectbg")[0].style.display = "block";
        $("#" + obj + "selectbg")[0].style.height = pageSize.docheight + "px";
        $("#" + obj + "selectMain")[0].style.display = "block";

        dHeight = $("#" + obj + "selectMain")[0].clientHeight;
        var x = Math.round(pageSize.width / 2) - (dWidth / 2) + scrollPos.scrollX;
        var y = Math.round(pageSize.height / 2) - (dHeight / 2) + scrollPos.scrollY;

        $("#" + obj + "selectMain")[0].style.width = dWidth + "px";
        //$("#"+obj + "selectMain")[0].style.height = dHeight + "px";
        $("#" + obj + "selectMain")[0].style.left = x + 'px';
        $("#" + obj + "selectMain")[0].style.top = y + 'px';
    }

    this.Update = function () {
        this.RefurbishParentDoc();
        this.Close();
    }

    this.Close = function () {
        $("#" + obj + 'selectbg')[0].style.display = "none";
        $("#" + obj + 'selectMain')[0].style.display = "none";
    }

    this.AddNode = function (strParentID, strID, strName) {
        //如果已经选择了该类 则退出
        if (!thisObj.IsSelChild && thisObj.IsCheckedLevelID()) {
            $("#" + obj + "selectItems")[0].innerHTML = "";
            return;
        }

        this.IndexLevel++;

        var tmpsel = document.createElement("select");
        //临时存放当前的索引 因为获取数据是异步方式
        var tmpIndex = this.IndexLevel;
        tmpsel.id = obj + "sel" + this.IndexLevel;
        tmpsel.options.add(new Option("请选择", strParentID + "_parent_" + this.IndexLevel));
        //取得该类的数据并填充select和多选层
        var ajax = new Ajax(this.ActionID, "&strID=" + strParentID + "&module=" + this.ModuleName + "&Params=" + this.Params);
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
                $("#" + obj + "selectItems")[0].innerHTML = html;
            }
        }
        tmpsel.onchange = this.SelectChange;
        $("#" + obj + "selectSub")[0].appendChild(tmpsel);
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
            if ($("#" + obj + "sel" + i)[0]) {
                mainobj.removeChild($("#" + obj + "sel" + i)[0]);
            }
            else
                break;
        }
        if (isShow) {
            thisObj.AddNode(strID);
        }
        else {
            $("#" + obj + "selectItems")[0].innerHTML = "";
        }
        thisObj.OnChange();
    }

    this.OnChange = function () {
        //类别值改变的处理方法
    }
}
/******************************   Select Class End *********************************/

/***************************通用检测函数********************************/

String.prototype.trim = function () {
    return this.replace(/^\s*/g, "").replace(/\s*$/g, "");
}

//验证Email格式
function ValidateEmail(source) {
    var patrn = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    return patrn.exec(source.trim());
}

//检测电话
function ValidateTel(source) {
    source = source.trim();
    var patrn = /^((\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{2,}))?$/;
    var patrn1 = /^(\d{3})-(\d{3})-(\d{4})$/;

    return patrn.exec(source.trim()) || patrn1.exec(source.trim());
}

//检测以逗号隔开的多个电话号码
function ValidateTels(source) {
    source = source.trim();
    source = source.replace('，', ',');
    var telformat = source.split(',');
    for (var i = 0; i < telformat.length; i++) {
        if (!ValidateTel(telformat[i].trim())) {
            return false;
        }
    }
    return true;
}

//检测手机
function ValidateMobileTel(source) {
    var patrn = /^1\d{10}$/;
    return patrn.exec(source.trim());
}

//监测以逗号隔开的多个手机号
function ValidateMobileTels(source) {
    source = source.trim();
    source = source.replace('，', ',');
    var telformat = source.split(',');
    for (var i = 0; i < telformat.length; i++) {
        if (!ValidateMobileTel(telformat[i].trim())) {
            return false;
        }
    }
    return true;
}

//验证为数字
function ValidateNum(source) {
    var patrn = /^\d+$/;
    return patrn.exec(source.trim());
}
//验证只能有a-z,A-Z，0-9组成的字符串
function ValidateS(source) {
    var patrn = /^[a-zA-Z0-9]+$/
    return patrn.exec(source.trim());
}
//验证只能有a-z,A-Z组成的字符串
function ValidateLetter(source) {
    var patrn = /^[a-zA-Z]+$/
    return patrn.exec(source.trim());
}
//验证是否含有空格、\/、\\、\'、\"、\<、\>等特殊字符,请重新输入!
function ValidateInput(source) {
    len = source.length;
    for (i = 0; i < len; i++) {
        while (source.charAt(i) == " " || source.charAt(i) == "\\" || source.charAt(i) == "/" || source.charAt(i) == "'" || source.charAt(i) == "\"" || source.charAt(i) == "*" || source.charAt(i) == "<" || source.charAt(i) == ">") {
            return true;
        }
    }
}

//验证字符串是否全是中文
function ValidateCNAll(source) {
    var patrn = /^[\u0391-\uFFE5]+$/
    return patrn.exec(source.trim());
}
//验证字符串中是否包含中文
function ValidateCN(source) {
    var patrn = /^(\w*)([\u0391-\uFFE5]+)(\w*)+$/
    return patrn.exec(source.trim());
}

function IsIncludeChinese(source) {
    var patrn = /^(\w*)([\u0391-\uFFE5]+)(\w*)+$/
    return patrn.test(source.trim());
}

//验证URL地址格式
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
//验证长日期格式
function ValidateLongDate(source) {
    var patrn = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$/
    return patrn.exec(source.trim());
}
//验证短日期格式
function ValidateShortDate(source) {
    var patrn = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29))$/
    return patrn.exec(source.trim());
}

//验证身份证号码
function ValidateIdCode(source) {
    var patrn = /^([0-9]{15}|[0-9]{18})$/
    return patrn.test(source.trim());
}

//验证身份证号码
function ValidateZipCode(source) {
    var patrn = /^\d{6}$/
    return patrn.test(source.trim());
}


/***************************end 通用验证函数********************************/

/*************************  其他通用函数开始 ************************************/



//替换所有自定的字符为新字符
//str:目标字符串
//oChr:原字符
//dChr:新字符
function ReplaceAll(str, oChr, dChr) {
    str = str.trim();
    var len = str.length;

    if (len <= 0) return "";

    for (var i = 0; i < len; i++) {
        str = str.replace(oChr, dChr);
    }
    return str;
}


//生成任意长度的随机数字
function GetRandom(numLength) {
    var rnd = "";
    for (i = 0; i < numLength; i++) {
        rnd = rnd + Math.floor(Math.random() * 10)
    }
    return rnd;
}

//字符串进行前空格截除
function TrimLeft(source) {
    while (source.charAt(0) == " ") {
        source = source.substr(1);
    }
    return source;
}
//字符串进行后空格截除
function TrimRight(source) {
    while (source.charAt(source.length - 1) == " ") {
        source = source.substr(0, source.length - 1);
    }
    return source;
}
//字符串进行首末位空格截除
function Trim(source) {
    return TrimRight(TrimLeft(source));
}
//得到字符串的真实长度（双字节换算为两个单字节） 
function GetLength(source) {
    return source.replace(/[^\x00-\xff]/g, "xx").length;
}

//给指定元素赋值
//多个元素用,号隔开
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
            eval("$('#" + prefix + "_tab" + curIndex + "')[0].className='" + curClsName + "';");
            eval("$('#" + prefix + "_box" + curIndex + "')[0].style.display = 'block';");

        }
        else {
            eval("$('#" + prefix + "_tab" + i + "')[0].className='';");
            eval("$('#" + prefix + "_box" + i + "')[0].style.display = 'none';");
        }
    }
}

/*************************  其他通用函数结束 ************************************/

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

        //定位层显示的位置
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
        $("#" + btnId)[0].onclick();
    }
}

function _xy_KeyNext(objId) {
    if (event.keyCode == 13) {
        $("#" + objId)[0].focus();
    }
}

//全选
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
//判断是否有复选框被选中
function CheckSel() {
    var chkother = document.getElementsByTagName("input");
    var j = 0;
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {
            if (chkother[i].id.indexOf('chkId') > -1) {
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
//复选多项删除时，确认删除
function ConfirmDel() {
    if (CheckSel()) {
        return confirm("确定删除吗？");
    }
    return false;
}

/***********************************************************************/
//JSON 转化

if (!this.JSON) {
    this.JSON = {};
}

(function () {

    function f(n) {
        // Format integers to have at least two digits.
        return n < 10 ? '0' + n : n;
    }

    if (typeof Date.prototype.toJSON !== 'function') {

        Date.prototype.toJSON = function (key) {

            return isFinite(this.valueOf()) ?
                   this.getUTCFullYear() + '-' +
                 f(this.getUTCMonth() + 1) + '-' +
                 f(this.getUTCDate()) + 'T' +
                 f(this.getUTCHours()) + ':' +
                 f(this.getUTCMinutes()) + ':' +
                 f(this.getUTCSeconds()) + 'Z' : null;
        };

        String.prototype.toJSON =
        Number.prototype.toJSON =
        Boolean.prototype.toJSON = function (key) {
            return this.valueOf();
        };
    }

    var cx = /[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,
        escapable = /[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,
        gap,
        indent,
        meta = {    // table of character substitutions
            '\b': '\\b',
            '\t': '\\t',
            '\n': '\\n',
            '\f': '\\f',
            '\r': '\\r',
            '"': '\\"',
            '\\': '\\\\'
        },
        rep;


    function quote(string) {

        // If the string contains no control characters, no quote characters, and no
        // backslash characters, then we can safely slap some quotes around it.
        // Otherwise we must also replace the offending characters with safe escape
        // sequences.

        escapable.lastIndex = 0;
        return escapable.test(string) ?
            '"' + string.replace(escapable, function (a) {
                var c = meta[a];
                return typeof c === 'string' ? c :
                    '\\u' + ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
            }) + '"' :
            '"' + string + '"';
    }


    function str(key, holder) {

        // Produce a string from holder[key].

        var i,          // The loop counter.
            k,          // The member key.
            v,          // The member value.
            length,
            mind = gap,
            partial,
            value = holder[key];

        // If the value has a toJSON method, call it to obtain a replacement value.

        if (value && typeof value === 'object' &&
                typeof value.toJSON === 'function') {
            value = value.toJSON(key);
        }

        // If we were called with a replacer function, then call the replacer to
        // obtain a replacement value.

        if (typeof rep === 'function') {
            value = rep.call(holder, key, value);
        }

        // What happens next depends on the value's type.

        switch (typeof value) {
            case 'string':
                return quote(value);

            case 'number':

                // JSON numbers must be finite. Encode non-finite numbers as null.

                return isFinite(value) ? String(value) : 'null';

            case 'boolean':
            case 'null':

                // If the value is a boolean or null, convert it to a string. Note:
                // typeof null does not produce 'null'. The case is included here in
                // the remote chance that this gets fixed someday.

                return String(value);

                // If the type is 'object', we might be dealing with an object or an array or
                // null.

            case 'object':

                // Due to a specification blunder in ECMAScript, typeof null is 'object',
                // so watch out for that case.

                if (!value) {
                    return 'null';
                }

                // Make an array to hold the partial results of stringifying this object value.

                gap += indent;
                partial = [];

                // Is the value an array?

                if (Object.prototype.toString.apply(value) === '[object Array]') {

                    // The value is an array. Stringify every element. Use null as a placeholder
                    // for non-JSON values.

                    length = value.length;
                    for (i = 0; i < length; i += 1) {
                        partial[i] = str(i, value) || 'null';
                    }

                    // Join all of the elements together, separated with commas, and wrap them in
                    // brackets.

                    v = partial.length === 0 ? '[]' :
                    gap ? '[\n' + gap +
                            partial.join(',\n' + gap) + '\n' +
                                mind + ']' :
                          '[' + partial.join(',') + ']';
                    gap = mind;
                    return v;
                }

                // If the replacer is an array, use it to select the members to be stringified.

                if (rep && typeof rep === 'object') {
                    length = rep.length;
                    for (i = 0; i < length; i += 1) {
                        k = rep[i];
                        if (typeof k === 'string') {
                            v = str(k, value);
                            if (v) {
                                partial.push(quote(k) + (gap ? ': ' : ':') + v);
                            }
                        }
                    }
                } else {

                    // Otherwise, iterate through all of the keys in the object.

                    for (k in value) {
                        if (Object.hasOwnProperty.call(value, k)) {
                            v = str(k, value);
                            if (v) {
                                partial.push(quote(k) + (gap ? ': ' : ':') + v);
                            }
                        }
                    }
                }

                // Join all of the member texts together, separated with commas,
                // and wrap them in braces.

                v = partial.length === 0 ? '{}' :
                gap ? '{\n' + gap + partial.join(',\n' + gap) + '\n' +
                        mind + '}' : '{' + partial.join(',') + '}';
                gap = mind;
                return v;
        }
    }

    // If the JSON object does not yet have a stringify method, give it one.

    if (typeof JSON.stringify !== 'function') {
        JSON.stringify = function (value, replacer, space) {

            // The stringify method takes a value and an optional replacer, and an optional
            // space parameter, and returns a JSON text. The replacer can be a function
            // that can replace values, or an array of strings that will select the keys.
            // A default replacer method can be provided. Use of the space parameter can
            // produce text that is more easily readable.

            var i;
            gap = '';
            indent = '';

            // If the space parameter is a number, make an indent string containing that
            // many spaces.

            if (typeof space === 'number') {
                for (i = 0; i < space; i += 1) {
                    indent += ' ';
                }

                // If the space parameter is a string, it will be used as the indent string.

            } else if (typeof space === 'string') {
                indent = space;
            }

            // If there is a replacer, it must be a function or an array.
            // Otherwise, throw an error.

            rep = replacer;
            if (replacer && typeof replacer !== 'function' &&
                    (typeof replacer !== 'object' ||
                     typeof replacer.length !== 'number')) {
                throw new Error('JSON.stringify');
            }

            // Make a fake root object containing our value under the key of ''.
            // Return the result of stringifying the value.

            return str('', { '': value });
        };
    }


    // If the JSON object does not yet have a parse method, give it one.

    if (typeof JSON.parse !== 'function') {
        JSON.parse = function (text, reviver) {

            // The parse method takes a text and an optional reviver function, and returns
            // a JavaScript value if the text is a valid JSON text.

            var j;

            function walk(holder, key) {

                // The walk method is used to recursively walk the resulting structure so
                // that modifications can be made.

                var k, v, value = holder[key];
                if (value && typeof value === 'object') {
                    for (k in value) {
                        if (Object.hasOwnProperty.call(value, k)) {
                            v = walk(value, k);
                            if (v !== undefined) {
                                value[k] = v;
                            } else {
                                delete value[k];
                            }
                        }
                    }
                }
                return reviver.call(holder, key, value);
            }


            // Parsing happens in four stages. In the first stage, we replace certain
            // Unicode characters with escape sequences. JavaScript handles many characters
            // incorrectly, either silently deleting them, or treating them as line endings.

            text = String(text);
            cx.lastIndex = 0;
            if (cx.test(text)) {
                text = text.replace(cx, function (a) {
                    return '\\u' +
                        ('0000' + a.charCodeAt(0).toString(16)).slice(-4);
                });
            }

            // In the second stage, we run the text against regular expressions that look
            // for non-JSON patterns. We are especially concerned with '()' and 'new'
            // because they can cause invocation, and '=' because it can cause mutation.
            // But just to be safe, we want to reject all unexpected forms.

            // We split the second stage into 4 regexp operations in order to work around
            // crippling inefficiencies in IE's and Safari's regexp engines. First we
            // replace the JSON backslash pairs with '@' (a non-JSON character). Second, we
            // replace all simple value tokens with ']' characters. Third, we delete all
            // open brackets that follow a colon or comma or that begin the text. Finally,
            // we look to see that the remaining characters are only whitespace or ']' or
            // ',' or ':' or '{' or '}'. If that is so, then the text is safe for eval.

            if (/^[\],:{}\s]*$/
.test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g, '@')
.replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']')
.replace(/(?:^|:|,)(?:\s*\[)+/g, ''))) {

                // In the third stage we use the eval function to compile the text into a
                // JavaScript structure. The '{' operator is subject to a syntactic ambiguity
                // in JavaScript: it can begin a block or an object literal. We wrap the text
                // in parens to eliminate the ambiguity.

                j = eval('(' + text + ')');

                // In the optional fourth stage, we recursively walk the new structure, passing
                // each name/value pair to a reviver function for possible transformation.

                return typeof reviver === 'function' ?
                    walk({ '': j }, '') : j;
            }

            // If the text is not JSON parseable, then a SyntaxError is thrown.

            throw new SyntaxError('JSON.parse');
        };
    }
} ());
//////////////////////////////////////////////////////////////////////////////////////////////////////