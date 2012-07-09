

//取得当前搜索的数据
function SearchGetValue() {
    //keyword=$1^jinji=$2^data=$3^pagesize=$4^style=$5^pageindex=$6
    var arrquery = new Array("keyword", "jinji", "date", "pagesize", "showstyle", "pageindex");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/") + 1);

    var strSearchType
    var arrValue;

    if (config.BogusStatic) {
        var values = url.substring(0, url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        strSearchType = arrValue[0].split("_")[0];
        arrValue.shift();
        //arrValue[2] = unescape(arrValue[2]);
        arrValue[2] = decodeURIComponent(arrValue[2]);
    }
    else {
        strSearchType = url.substring(0, url.lastIndexOf("." + config.Suffix));
        strSearchType = strSearchType.split("_")[0];

        arrValue = new Array(arrquery.length);
        for (var i = 0; i < arrquery.length; i++) {
            arrValue[i] = GetQueryString(arrquery[i]);
        }
        arrValue[2] = unescape(arrValue[2]);
    }
    return {
        searchType: strSearchType,
        query: arrquery,
        value: arrValue,
        //keyword=$1^jinji=$2^data=$3^pagesize=$4^style=$5^pageindex=$6
        objData: {
            keyword: arrValue[0],
            date: arrValue[2],
            showstyle: arrValue[4],
            pagesize: arrValue[3],
            pageindex: arrValue[5],
            jinji: arrValue[1]
        }
    };

}

function SearchSetDefaultValue() {
    var data = new SearchGetValue();

    if (data.objData.keyword.indexOf(",") != -1) {
        var arr = data.objData.keyword.split(",");
        $("txtsearchkey").value = undefined == arr[0] ? "" : arr[0];
        $("txtkeyword").value = undefined == arr[1] ? "" : arr[1];
    }
    else {
        $("txtsearchkey").value = "undefined" == data.objData.keyword ? "" : data.objData.keyword;
    }


    if (undefined == data.objData.date) data.objData.date = "";

    if ("" != data.objData.date) {
        $("selectlistdid").value = data.objData.date;
    }
    if (undefined != data.objData.pagesize && data.objData.pagesize != "") {
        $("pagesize").value = data.objData.pagesize;
    }

    if (undefined != data.objData.jinji && data.objData.jinji != "") {
        $("jinji").value = data.objData.jinji;
    }
    if (undefined != data.objData.showstyle && data.objData.showstyle != "") {
        $("style").value = data.objData.showstyle;
    }
}

function SearchSetClassList(moduleName, typeID) {
    var data = new SearchGetValue();
    var query = "&moduleName=" + moduleName + "&typeID=" + typeID + "&areaid=" + data.objData.areaid;
    query += "&times=" + data.objData.times + "&keyword=" + data.objData.keyword + "&flag=" + data.searchType.substring(0, data.searchType.length - 2);

    var ajaxcls = new Ajax("xy033", query);
    ajaxcls.onSuccess = function () {
        if (ajaxcls.state.result == "1") {
            if (ajaxcls.data) {
                var list = "";
                for (i = 0; i < ajaxcls.data.classlist.length; i++) {
                    list += "<a href=\"javascript:pturl(" + ajaxcls.data.classlist[i].classID + ");\">" + unescape(ajaxcls.data.classlist[i].className) + "(" + ajaxcls.data.classlist[i].infoNum + ")</a>";
                }
                $("xy_ClassList").innerHTML = "" + list + "";
            }
            else {
                //$("xy_ClassList").innerHTML = "<div class>暂无子类！</li>";
                $("xy_PClassList").style.display = "none";
            }
        }
        else
            $("xy_PClassList").style.display = "none";
        //$("ClassList").innerHTML = "<li>暂无子类！</li>";
    }
}

function SearchKeyDown() {
    if (event.keyCode == 13) {
        //searchClick();
        $("DoSearch").click();
    }
}

function CheckSearchKey(source) {
    if (source != "") {
        if (isNull(source) || !isTrueKeyWord(source) || !isNVarchar(source)) {
            alertmsg(false, "输入查询条件不合法！");
            return false;
        }
        else if (source.indexOf(",") >= 0) {
            alertmsg(false, "搜索的字符中不允许出现“,”号！");
            return false;
        }
        else if (source.indexOf("-") >= 0) {
            alertmsg(false, "搜索的字符中不允许出现“-”号！");
            return false;
        }
        else if (source.indexOf("/") >= 0) {
            alertmsg(false, "搜索的字符中不允许出现“/”号！");
            return false;
        }
        else if (source.indexOf("&") >= 0) {
            alertmsg(false, "搜索的字符中不允许出现“&”号！");
            return false;
        }
    }
    return true;
}


function xy_search() {

    var flagName = document.getElementById("xy_FlagName").value;

    searchClick(flagName);
}

//头部搜索
function searchClick(type) {
    if (type == "news") {
        SetNewsSearchURL();
        return;
    }

    if (type == "exhibition") {
        SetSearchURL("exhibition", "seller");
        return;
    }

    if (type == "brand" || type == "company") {
        SetSearchURL(type, "seller");
        return;
    }

    if (type == "job") {
        SetJobSearchURL();
        return;
    }

    if (type == "search") {
        var data = new SearchGetValue();

        if (data.searchType == "") {
            var strflag = location.href.split("/")[3];
            SetSearchURL(strflag, "seller");
        }
        else if (data.searchType == "sell" || data.searchType == "buy")
            SetSearchURL(data.objData.flag, data.searchType + "er");
        else if (data.searchType == "news")
            SetNewsSearchURL();
        else
            SetSearchURL(data.objData.flag, data.searchType);
        return;
    }

    SearchInfo(type);
}
function SearchInfo(strClassType) {
    var infoType = document.getElementById("xy_InfoType").value;

    if (infoType == "") infoType = "sell";

    if (infoType == "sell")
        SetSearchURL(strClassType, "seller");
    else
        SetSearchURL(strClassType, "buyer");
}

function SetSearchURL(strClassType, strs) {
    var key = $F("txtsearchkey").replace(/\s/g, "");

    if (!CheckSearchKey(key)) return false;
    if (config.BogusStatic) {
        var url = config.WebURL + "search/" + strs + "_search-" + strClassType + "--" + key + "-------." + config.Suffix;
    }
    else {
        url = config.WebURL + "search/" + strs + "_search." + config.Suffix + "?flag=" + strClassType + "&keyword=" + key;
    }

    location = url;
}

function SetNewsSearchURL() {
    var key = $F("txtsearchkey").replace(/\s/g, "");

    if (!CheckSearchKey(key)) return false;
    if (config.BogusStatic) {
        var url = config.WebURL + "search/news_search---" + key + "-----." + config.Suffix;
    }
    else {
        url = config.WebURL + "search/news_search." + config.Suffix + "?keyword=" + key;
    }
    location = url;
}

function listSearchKeyDown() {
    var gk = event.keyCode;
    if (gk == 13) {
        listsearch();
    }
}

function xy_GoToPage(pageIndex) {
    if (pageIndex == "") return;

    if (isNaN(pageIndex)) return;

    var total = parseInt($("totalPage").value);

    var toPage = parseInt(pageIndex);

    if (toPage <= 0) return;

    if (toPage > total) {
        alertmsg(false, "最大页数为" + total);
        return;
    }

    listsearch();
}


function xy_setOrder(order) {
    if (order != "grade" && order != "time" && order != "active") order = "";

    $("orderby").value = order;

    listsearch();
}


//列表筛选搜索
function listsearch() {
    if (!CheckSearchKey($F("txtkeyword"))) return false;
    var data = new SearchGetValue();

    var href = config.WebURL + "search/" + data.searchType + "_search";
    // keyword=$1^jinji=$2^data=$3^pagesize=$4^style=$5^pageindex=$6
    //    if (config.BogusStatic) {
    //        for (var i = 0; i < data.query.length; i++) {
    //            href += "-";
    //            if (data.query[i] == "keyword") {
    //                if (data.value[i] != undefined) {
    //                    href += GetSearchKeyWord(data.value[i]);
    //                }
    //            }
    //            else if (data.query[i] == "jinji") {
    //                if (data.value[i] != "") {
    //                    href += $F("jinji");
    //                }
    //            }
    //            else if (data.query[i] == "date") {
    //                if (data.value[i] != "") {
    //                    href += $F("selectlistdid");
    //                }
    //            }
    //            else if (data.query[i] == "pagesize") {
    //                href += $F("pagesize");
    //            }
    //            else if (data.query[i] == "style") {
    //                href += $F("style");
    //            }
    //            else if (data.query[i] == "pageindex") {
    //                var toPage = $F("cpage");
    //                if (toPage != "" && !isNaN(toPage) && toPage > 0) {
    //                    href += toPage;
    //                }
    //            }
    //            else
    //                href += data.value[i];
    //        }
    //        href += "." + config.Suffix;
    //    }
    //    else {
    href += "." + config.Suffix;
    for (var i = 0; i < data.query.length; i++) {
        href += (0 == i ? "?" : "&") + data.query[i] + "=";
        if (data.query[i] == "jinji") {
            try {
                href += $F("jinji");
            }
            catch (e) { }
        }
        else if (data.query[i] == "date")
            href += $F("selectlistdid");
        else if (data.query[i] == "keyword") {

            href += GetSearchKeyWord(data.value[i]);

        } else if (data.query[i] == "style") {
            if (data.value[i] != "") {
                href += GetSearchKeyWord(data.value[i]);
            }
        } else if (data.query[i] == "pagesize") {
            href += $F("pagesize");
        }
        else if (data.query[i] == "pageindex") {
            var toPage = $F("cpage");
            if (toPage != "" && !isNaN(toPage) && toPage != "1") {
                href += toPage;
            }
        }
        else
            href += data.value[i];
    }

    //    }
    window.location = href;
}


function GetSearchKeyWord(strkeyword) {
    if (strkeyword.indexOf(",") != -1) {
        var arr = strkeyword.split(",");
        if ($F("txtkeyword") != "") {
            return arr[0] + $F("txtkeyword");
        }
        else {
            return arr[0];
        }
    }
    else {
        if ($F("txtkeyword") != "") {
            return strkeyword + $F("txtkeyword");
        }
        else {
            return strkeyword;
        }
    }
}

//-------------------Job Search Start---------------------------

function SetJobSearchURL() {
    var key = $F("txtsearchkey").replace(/\s/g, "");

    if (!CheckSearchKey(key)) return false;
    if (config.BogusStatic) {
        var url = config.WebURL + "job/list-----" + key + "---." + config.Suffix;
    }
    else {
        url = config.WebURL + "job/list." + config.Suffix + "?keyword=" + key;
    }
    location = url;
}

//取得当前搜索的数据
function GetJobSearchValue() {
    var arrquery = new Array("typeid", "areaid", "date", "jobtype", "keyword", "pagesize", "pageindex", "custom");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/") + 1);

    var arrValue;

    if (config.BogusStatic) {
        var values = url.substring(0, url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        arrValue.shift();
        arrValue[4] = unescape(arrValue[4]);
    }
    else {
        arrValue = new Array(arrquery.length);
        for (var i = 0; i < arrquery.length; i++) {
            arrValue[i] = GetQueryString(arrquery[i]);
        }
        arrValue[4] = unescape(arrValue[4]);
    }

    for (var i = 0; i < arrquery.length; i++) {
        if (arrValue[i] == undefined || arrValue[i] == "undefined") arrValue[i] = "";
    }

    return {
        query: arrquery,
        value: arrValue,
        objData: {
            typeid: arrValue[0],
            areaid: arrValue[1],
            date: arrValue[2],
            jobtype: arrValue[3],
            keyword: arrValue[4],
            pagesize: arrValue[5],
            pageindex: arrValue[6],
            custom: arrValue[7]
        }
    };
}

//获取简历搜索值
function GetResumeSearchValue() {
    var arrquery = new Array("jobkeyword", "hopecityid", "Schoolage", "JobYear", "Intentpay1", "Intentpay2", "schoolname", "pagesize", "pageindex", "custom");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/") + 1);

    var arrValue;

    if (config.BogusStatic) {
        var values = url.substring(0, url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        arrValue.shift();
        arrValue[4] = unescape(arrValue[4]);
    }
    else {
        arrValue = new Array(arrquery.length);
        for (var i = 0; i < arrquery.length; i++) {
            arrValue[i] = GetQueryString(arrquery[i].replace(/^\s+|\s+$/g, ""));
        }
        arrValue[4] = unescape(arrValue[4]);
    }

    for (var i = 0; i < arrquery.length; i++) {
        if (arrValue[i] == undefined || arrValue[i] == "undefined") arrValue[i] = "";
    }

    return {
        query: arrquery,
        value: arrValue,
        objData: {
            jobkeyword: arrValue[0],
            hopecityid: arrValue[1],
            Schoolage: arrValue[2],
            JobYear: arrValue[3],
            Intentpay1: arrValue[4],
            Intentpay2: arrValue[5],
            schoolname: arrValue[6],
            pagesize: arrValue[7],
            pageindex: arrValue[8],
            custom: arrValue[9]
        }
    };
}


function SetJobSearchDefaultValue() {
    var data = new GetJobSearchValue();
    if (data.objData.keyword.indexOf(",") != -1) {
        var arr = data.objData.keyword.split(",");
        $("txtsearchkey").value = arr[0] == undefined ? "" : arr[0];
        $("txtkeyword").value = arr[1] == undefined ? "" : arr[1];
    }
    else {
        if (data.objData.keyword != "undefined")
            $("txtsearchkey").value = data.objData.keyword;
    }
    try {
        $("typeid").value = data.objData.typeid;
        claPost.Init();
    } catch (e) { }

    try {
        $("areaid").value = data.objData.areaid;
        claArea.Init();
    } catch (e) { }

    if ("undefined" == data.objData.date && "" != data.objData.date) {
        $("date").value = data.objData.date;
    }

    if ("" != data.objData.jobtype) {
        SetRadioValue("jobtype", data.objData.jobtype);
    }
}
//去除空格
function isnonull() {
    $("jobkeyword").value = $("jobkeyword").value.replace(/^\s+|\s+$/g, "");
    $("schoolname").value = $("schoolname").value.replace(/^\s+|\s+$/g, "");
}
function SetResumeSearchDefaultValue() {
    var data = new GetResumeSearchValue();
    if (data.objData.jobkeyword.indexOf(",") != -1) {
        var arr = data.objData.jobkeyword.split(",");
        $("txtsearchkey").value = arr[0] == undefined ? "" : arr[0];
        $("jobkeyword").value = arr[1] == undefined ? "" : arr[1];
    }
    else {
        if (data.objData.jobkeyword != "undefined")
            $("jobkeyword").value = data.objData.jobkeyword;
    }
    try {
        $("hopecityid").value = data.objData.hopecityid;
        claArea1.Init();
    } catch (e) { }

    if ("" != data.objData.Schoolage) {
        $("Schoolage").value = data.objData.Schoolage;
    }
    if ("" != data.objData.JobYear) {
        $("JobYear").value = data.objData.JobYear;
    }
    if ("" != data.objData.Intentpay1) {
        $("Intentpay1").value = data.objData.Intentpay1;
    }
    if ("" != data.objData.Intentpay2) {
        $("Intentpay2").value = data.objData.Intentpay2;
    }
    if ("" != data.objData.schoolname) {
        $("schoolname").value = data.objData.schoolname;
    }
}


function JobListSearch() {
    if (!CheckSearchKey($F("txtkeyword"))) return false;
    var data = new GetJobSearchValue();

    var href = config.WebURL + "job/list";
    if (config.BogusStatic) {
        for (var i = 0; i < data.query.length; i++) {
            href += "-";

            if (data.query[i] == "typeid") {
                href += $F("typeid");
            }
            else if (data.query[i] == "areaid") {
                href += $F("areaid");
            }
            else if (data.query[i] == "date")
                href += $F("date");
            else if (data.query[i] == "keyword") {
                href += GetSearchKeyWord(data.value[i]);
            } else if (data.query[i] == "jobtype") {
                href += GetRadioValue("jobtype");
            }
            else
                href += data.value[i];
        }
        href += "." + config.Suffix;
    }
    else {
        href += "." + config.Suffix;
        for (var i = 0; i < data.query.length; i++) {
            href += (0 == i ? "?" : "&") + data.query[i] + "=";
            if (data.query[i] == "typeid") {
                href += $F("typeid");
            }
            if (data.query[i] == "areaid") {
                href += $F("areaid");
            }
            else if (data.query[i] == "date")
                href += $F("date");
            else if (data.query[i] == "keyword") {
                href += GetSearchKeyWord(data.value[i]);
            } else if (data.query[i] == "jobtype") {
                href += GetRadioValue("jobtype");
            }
            else
                href += data.value[i];
        }

    }
    window.location = href;
}


function ResumeListSearch() {
    if (isNaN(document.getElementById("Intentpay1").value)) {
        alertmsg(false, "输入查询条件不合法！");
        return false;
    }
    if (isNaN(document.getElementById("Intentpay2").value)) {
        alertmsg(false, "输入查询条件不合法！");
        return false;
    }
    var data = new GetResumeSearchValue();

    var href = config.WebURL + "job/resumelist";
    if (config.BogusStatic) {
        for (var i = 0; i < data.query.length; i++) {
            href += "-";

            if (data.query[i] == "jobkeyword") {
                href += $F("jobkeyword");
            }
            else if (data.query[i] == "hopecityid") {
                href += $F("hopecityid");
            }
            else if (data.query[i] == "Schoolage")
                href += $F("Schoolage");
            else if (data.query[i] == "JobYear")
                href += $F("JobYear");
            else if (data.query[i] == "Intentpay1")
                href += $F("Intentpay1");
            else if (data.query[i] == "Intentpay2")
                href += $F("Intentpay2");
            else if (data.query[i] == "schoolname") {
                href += $F("schoolname");
            }
            else {
                href += data.value[i];
            }
        }
        href += "." + config.Suffix;
    }
    else {
        href += "." + config.Suffix;
        for (var i = 0; i < data.query.length; i++) {
            href += (0 == i ? "?" : "&") + data.query[i] + "=";
            if (data.query[i] == "jobkeyword") {
                href += $F("jobkeyword");
            }
            if (data.query[i] == "hopecityid") {
                href += $F("hopecityid");
            }
            else if (data.query[i] == "Schoolage")
                href += $F("Schoolage");
            else if (data.query[i] == "JobYear")
                href += $F("JobYear");
            else if (data.query[i] == "Intentpay1")
                href += $F("Intentpay1");
            else if (data.query[i] == "Intentpay2")
                href += $F("Intentpay2");
            else if (data.query[i] == "schoolname") {
                href += $F("schoolname");
            }
            else
                href += data.value[i];
        }

    }
    window.location = href;
}



//设置单选按钮选中值
function SetRadioValue(name, value) {
    var eles = document.getElementsByName(name);

    for (var i = 0; i < eles.length; i++) {
        if (eles[i].value == value) {
            eles[i].checked = true;
            break;
        }
    }

    try {
        if (i == eles.length) eles[0].checked = true;
    } catch (e) { }
}

//获取单选按钮选中值
function GetRadioValue(name) {
    var eles = document.getElementsByName(name);

    for (var i = 0; i < eles.length; i++) {
        if (eles[i].checked == true) {
            return eles[i].value;
        }
    }

    return "";
}

//-------------------Job Search End--------------------------
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

//列表搜索
function listsearchClick() {
    if ($("txtsearchkey").value != "")
        window.location.href = $("txtsearchkeyurl").value + "?keyword=" + $("txtsearchkey").value;
    else
        window.location.href = $("txtsearchkeyurl").value;

}

//页面加载
function onloadsearch(key) {
    var type = $("txttype").value;
    GetSearchKey(type);
    $("txtsearchkey").value = key;
}

//搜索列表点击
function sethref(type) {
    var url = "";

    url = "search/" + $("hidinfoflag").value + "_search";

    switch (type) {
        case "offer":
            if ($("bogusstatic").value == "True") {
                url += escape("-offer" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=offer";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "venture":
            if ($("bogusstatic").value == "True") {
                url += escape("-venture" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=venture";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "investment":
            if ($("bogusstatic").value == "True") {
                url += escape("-investment" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=investment";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "service":
            if ($("bogusstatic").value == "True") {
                url += escape("-service" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=service";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "exhibition":
            if ($("bogusstatic").value == "True") {
                url += escape("-exhibition" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=exhibition";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "brand":
            if ($("bogusstatic").value == "True") {
                url += escape("-brand" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=brand";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "company":
            if ($("bogusstatic").value == "True") {
                url += escape("-company" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=company";
                if ($("txtsearchwhere").value.length > 0) {
                    url += $("txtsearchwhere").value;
                }
            }
            break;
        case "news":
            if ($("bogusstatic").value == "True") {
                url += escape("-news" + $("txtsearchwhere").value);
                url += "." + $("suffix").value;
            }
            else {
                url += "." + $("suffix").value + "?flag=news";
                if ($("txtsearchwhere").value.length > 0) {
                    url += removeurlparameter("cid", removeurlparameter("provinceid", $("txtsearchwhere").value));

                }
            }
            break;
    }
    window.location.href = config.WebURL + url;
}

//人才列表切换显示方式
function setjobshowstyle(flag) {
    var showstyle = "";
    if (flag == 1) {
        $("detail").className = "on";
        $("nodetail").className = "off";
        showstyle = "detail";
    }
    else {
        $("detail").className = "off";
        $("nodetail").className = "on";
        showstyle = "nodetail";
    }
    var href = window.location.href;
    var nameArray = new Array();
    var valueArray = new Array();

    if ($("bogusstatic").value == "True") {
        var starindex = href.substring(0, href.substring(0, href.lastIndexOf('-')).lastIndexOf('-')).lastIndexOf('-');
        href = href.substring(0, starindex + 1) + showstyle + href.substring(href.substring(0, href.lastIndexOf('-')).lastIndexOf('-'), href.length);
    }
    else {
        if (href.indexOf('?', 0) == -1) {
            href += "?showstyle=" + showstyle;
        }
        else {
            if (href.indexOf('showstyle', 0) == -1) {
                href += "&showstyle=" + showstyle;
            }
            else {
                nameArray[0] = "showstyle";
                valueArray[0] = showstyle;
                href = changeLocationParameter(nameArray, valueArray);
            }
        }
    }
    window.location.href = href;
}
//初始化人才列表样式
//temp
function initjobshowstyle(flag) {
    if (flag == "" || flag == "detail") {
        $("detail").className = "on";
        $("nodetail").className = "off";
    }
    else {
        $("detail").className = "off";
        $("nodetail").className = "on";
    }
}
function joblistSearchKeyDown() {
    var gk = event.keyCode;
    if (gk == 13) {
        listsearch();
    }
}

//列表筛选搜索
//function joblistsearch()
//{
//        var href = "job/list";
//        
//        if($("bogusstatic").value == "True")
//        {
//            href += "-"+$("postid").value;
//            href += "-"+$("selectlistpid").value;
//            href += "-"+$("selectlistcid").value;
//            href += "-";
//            href += "-"+$("selectlistdid").value;
//            href +=  escape("-"+$("txtkeyword").value);
//            href +=  escape("-"+$("txtckeyword").value);            
//            href += "---";        
//                       
//            href += "."+ $("suffix").value;
//        }
//        else
//        {
//            href += "." + $("suffix").value ;
//            if($("postid").value != "")
//            {
//                if(href.indexOf('?',0)!=-1)
//                {
//                    href += "&p_id="+$("postid").value;
//                }
//                else 
//                {
//                    href += "?p_id="+$("postid").value;
//                }
//            }
//            if($("txtkeyword").value != "")
//            {
//                if(isNull($("txtkeyword").value))
//                {
//                    alertmsg(false,"输入查询条件不合法！");
//                }
//                else if(!isTrueKeyWord($("txtkeyword").value))
//                {
//                    alertmsg(false,"输入查询条件不合法！");
//                }
//                else if(!isNVarchar($("txtkeyword").value))
//                {
//                    alertmsg(false,"输入查询条件不合法！");
//                }
//                else 
//                {
//                    if(href.indexOf('?',0)!=-1)
//                    {
//                        href += "&keyword="+$("txtkeyword").value;
//                    }
//                    else
//                    {
//                        href += "?keyword="+$("txtkeyword").value;
//                    }
//                }
//            }
//            if($("txtckeyword").value != "")
//            {
//                if(isNull($("txtckeyword").value))
//                {
//                    alertmsg(false,"输入查询条件不合法！");
//                }
//                else if(!isTrueKeyWord($("txtckeyword").value))
//                {
//                    alertmsg(false,"输入查询条件不合法！");
//                }
//                else if(!isNVarchar($("txtckeyword").value))
//                {
//                    alertmsg(false,"输入查询条件不合法！");
//                }
//                else 
//                {
//                    if(href.indexOf('?',0)!=-1)
//                    {
//                        href += "&ckeyword="+$("txtckeyword").value;
//                    }
//                    else
//                    {
//                        href += "?ckeyword="+$("txtckeyword").value;
//                    }
//                }
//            }
//           if($("selectlistpid").value!= "")
//           {
//                if(href.indexOf('?',0)!=-1)
//                {
//                    href += "&provinceid="+$("selectlistpid").value;
//                }
//                else
//                {
//                    href += "?provinceid="+$("selectlistpid").value;
//                }
//           }
//            if($("selectlistcid").value != "")
//            {
//                if(href.indexOf('?',0)!=-1)
//                {
//                    href += "&cid="+$("selectlistcid").value;            
//                }
//                else
//                {
//                    href += "?cid="+$("selectlistcid").value;
//                }                                                
//            }
//            if($("selectlistdid").value != "")
//            {
//                if(href.indexOf('?',0)!=-1)
//                {
//                    href += "&date="+$("selectlistdid").value;            
//                }
//                else
//                {
//                    href += "?date="+$("selectlistdid").value;     
//                }
//            }
//        }
//        window.location.href  =$("weburl").value +  href;
//}


//网店头部搜索
function shoptopsearch() {
    var key = $F("shopsearchkey").replace(/\s/g, "");

    if (!CheckSearchKey(key)) return false;
    if (config.BogusStatic) {
        var url = config.WebURL + "search/seller_search-" + $F("hidshopsearchflag") + "--" + key + "-------." + config.Suffix;
    }
    else {
        url = config.WebURL + "search/seller_search." + config.Suffix + "?flag=" + $F("hidshopsearchflag") + "&keyword=" + key;
    }
    location = url;
}

//网店头部信息标识
function shoptopflag(num) {
    switch (num) {
        case 1:
            $("ssoffer").className = "on";
            $("ssmachining").className = "";
            $("ssinvestment").className = "";
            $("ssservice").className = "";
            $("ssexhibition").className = "";
            $("ssbrand").className = "";
            $("hidshopsearchflag").value = "offer";
            break;
        case 2:
            $("ssoffer").className = "";
            $("ssmachining").className = "on";
            $("ssinvestment").className = "";
            $("ssservice").className = "";
            $("ssexhibition").className = "";
            $("ssbrand").className = "";
            $("hidshopsearchflag").value = "venture";
            break;
        case 3:
            $("ssoffer").className = "";
            $("ssmachining").className = "";
            $("ssinvestment").className = "on";
            $("ssservice").className = "";
            $("ssexhibition").className = "";
            $("ssbrand").className = "";
            $("hidshopsearchflag").value = "investment";
            break;
        case 4:
            $("ssoffer").className = "";
            $("ssmachining").className = "";
            $("ssinvestment").className = "";
            $("ssservice").className = "on";
            $("ssexhibition").className = "";
            $("ssbrand").className = "";
            $("hidshopsearchflag").value = "service";
            break;
        case 5:
            $("ssoffer").className = "";
            $("ssmachining").className = "";
            $("ssinvestment").className = "";
            $("ssservice").className = "";
            $("ssexhibition").className = "on";
            $("ssbrand").className = "";
            $("hidshopsearchflag").value = "exhibition";
            break;
        case 6:
            $("ssoffer").className = "";
            $("ssmachining").className = "";
            $("ssinvestment").className = "";
            $("ssservice").className = "";
            $("ssexhibition").className = "";
            $("ssbrand").className = "on";
            $("hidshopsearchflag").value = "brand";
            break;
    }
}

//设置页面显示记录条数
function funpagesize(num) {
    var href = document.location.href;
    var nameArray = new Array();
    var valueArray = new Array();

    if (config.BogusStatic) {
        var starindex = href.substring(0, href.lastIndexOf('-')).lastIndexOf('-');

        href = href.substring(0, starindex + 1) + num + "-" + href.substring(href.lastIndexOf('.'), href.length);
    }
    else {
        if (document.location.href.indexOf('?', 0) == -1) {
            if (document.location.href.indexOf('pageindex', 0) != -1) {
                nameArray[0] = "pageindex";
                valueArray[0] = "1";
                href = changeLocationParameter(nameArray, valueArray);
            }
            href += "?pagesize=" + num;
        }
        else {
            if (document.location.href.indexOf('pagesize', 0) == -1) {
                href += "&pagesize=" + num;
            }
            else {
                nameArray[0] = "pagesize";
                valueArray[0] = num;
                if (document.location.href.indexOf('pageindex', 0) != -1) {
                    nameArray[1] = "pageindex";
                    valueArray[1] = "1";
                }
                href = changeLocationParameter(nameArray, valueArray);
            }
        }
    }
    window.location.href = href;
}

//按产品类别搜索
function pturl(ptid) {
    var href = document.location.href;
    var nameArray = new Array();
    var valueArray = new Array();

    if (config.BogusStatic) {
        var starindex = href.indexOf('-', 0) + 1 + href.substring(href.indexOf('-', 0) + 1, href.length).indexOf('-', 0) + 1;
        href = href.substring(0, href.indexOf('-', 0) + 1) + href.substring(href.indexOf('-', 0) + 1, href.length).substring(0, href.substring(href.indexOf('-', 0) + 1, href.length).indexOf('-', 0) + 1) + ptid + href.substring(starindex + href.substring(starindex, href.length).indexOf('-'), href.lastIndexOf('-') + 1) + href.substring(href.lastIndexOf('.'), href.length);
    }
    else {
        if (document.location.href.indexOf('?', 0) == -1) {
            href += "?typeid=" + ptid;
        }
        else {
            if (document.location.href.indexOf('typeid', 0) == -1) {
                if (href.indexOf('pagesize', 0) != -1) {
                    href = href.substring(0, href.indexOf('&pagesize', 0)) + "&typeid=" + ptid + href.substring(href.indexOf('&pagesize', 0), href.length);
                }
                else if (href.indexOf('pageindex', 0) != -1) {
                    //                     href = href.substring(0,href.indexOf('&pageindex',0)) + "&typeid="+typeid +href.substring(href.indexOf('&pageindex',0),href.length);
                    href = removeurlparameter("pageindex", href);
                    href += "&typeid=" + ptid;
                }
                else {
                    href += "&typeid=" + ptid;
                }
            }
            else {
                nameArray[0] = "typeid";
                valueArray[0] = ptid;
                href = changeLocationParameter(nameArray, valueArray);
            }
        }
    }
    window.location.href = href;
}

function pturls(ptid, shopusername) {
    var old = document.location.href;
    href = old.substring(0, old.lastIndexOf('/'));

    if (config.BogusStatic) {
        href += "/product-" + ptid + "--." + config.Suffix;
    }
    else {
        if (!config.IsDomain) {
            href = href.replace("/" + shopusername, "");
        }
        href += "/product." + config.Suffix + "?u_name=" + shopusername + "&typeid=" + ptid;
    }
    window.location.href = href;
}


//替换url参数值
function changeLocationParameter(nameArray, valueArray) {
    var parameter = document.location.search.toString();
    var pname;
    var pstart, pend;

    for (var i = 0; i < nameArray.length; i++) {
        pname = nameArray[i];
        pstart = parameter.indexOf(pname + "=");
        while (pstart > 0) {
            if (parameter.charAt(pstart - 1) == '?' || parameter.charAt(pstart - 1) == '&') {
                pstart = pstart + pname.length + 1;
                pend = parameter.indexOf("&", pstart);
                if (pend >= 0)
                    parameter = parameter.substring(0, pstart) + valueArray[i] + parameter.substring(pend, parameter.length);
                else
                    parameter = parameter.substring(0, pstart) + valueArray[i];
                break;
            }
            else
                pstart = parameter.indexOf(pname + "=", pstart + pname.length + 1);
        }
        if (pstart < 0)
            parameter += "&" + nameArray[i] + "=" + valueArray[i];
    }
    return parameter;
}

//去掉url参数
function removeurlparameter(name, strurl) {
    var href = "";
    var url = "";
    if (strurl == null) {
        url = document.location.search.toString();
        url = url.substr(1);
    }
    else {
        url = strurl;
    }

    strs = url.split('&');
    for (var i = 0; i < strs.length; i++) {
        if (strs[i].split('=')[0] != name) {
            href += "&" + strs[i];
        }
    }
    return href.substr(1);
}

//设置列表显示样式
function setshowstyle(style) {
    var nameArray = new Array();
    var valueArray = new Array();
    if (style != "img") {
        if (config.BogusStatic) {
            var starindex = window.location.href.substring(0, window.location.href.substring(0, window.location.href.lastIndexOf('-')).lastIndexOf('-')).lastIndexOf('-');
            window.location.href = window.location.href.substring(0, starindex + 1) + style + window.location.href.substring(window.location.href.substring(0, window.location.href.lastIndexOf('-')).lastIndexOf('-'), window.location.href.length);
        }
        else {
            if (document.location.href.indexOf('?', 0) == -1) {
                window.location.href = window.location.href + "?showstyle=noimg";
            }
            else {
                if (document.location.href.indexOf('showstyle', 0) != -1) {
                    nameArray[0] = "showstyle";
                    valueArray[0] = "noimg";
                    window.location.href = changeLocationParameter(nameArray, valueArray);
                }
                else {
                    var strurl = window.location.href;
                    if (strurl.indexOf('pagesize', 0) != -1) {
                        strurl = strurl.substring(0, strurl.indexOf('&pagesize', 0)) + "&showstyle=noimg" + strurl.substring(strurl.indexOf('&pagesize', 0), strurl.length);
                    }
                    else if (strurl.indexOf('pageindex', 0) != -1) {
                        strurl = strurl.substring(0, strurl.indexOf('&pageindex', 0)) + "&showstyle=noimg" + strurl.substring(strurl.indexOf('&pageindex', 0), strurl.length);
                    }
                    else {
                        strurl = strurl + "&showstyle=noimg";
                    }
                    window.location.href = strurl;
                }
            }
        }
    }
    else {
        if (config.BogusStatic) {
            var starindex = window.location.href.substring(0, window.location.href.substring(0, window.location.href.lastIndexOf('-')).lastIndexOf('-')).lastIndexOf('-');
            window.location.href = window.location.href.substring(0, starindex + 1) + window.location.href.substring(window.location.href.substring(0, window.location.href.lastIndexOf('-')).lastIndexOf('-'), window.location.href.length);
        }
        else {
            if (document.location.href.indexOf('showstyle', 0) != -1) {
                nameArray[0] = "showstyle";
                valueArray[0] = "img";
                window.location.href = changeLocationParameter(nameArray, valueArray);
            }
        }
    }
}
//对比产品
function compareinfo() {
    var href = config.WebURL + "search/compare";

    href += "." + config.Suffix + "?flag=" + $("hidmoduleflag").value;

    var chk = document.getElementsByTagName("input");
    var num = 0;
    var ids = "";
    for (var i = 0; i < chk.length; i++) {
        if (chk[i].type == 'checkbox') {
            if (chk[i].checked == true) {
                ids += "," + chk[i].value;
                num++;
            }
        }
    }

    if (ids.length > 0) {
        if (num > 4) {
            alertmsg(false, '最多只能比较4条信息！');
        }
        else {
            href += "&id=" + ids.substring(1);

            window.open(href);
        }
    }
    else {
        alertmsg(false, '请选择需要对比的信息！');
    }
}



////==========================================================================
////  搜索 结束
////==========================================================================

///==========================================================================
////  商业信息详细 结束
////==========================================================================
function selectBox(num) {
    switch (num) {
        case 1:
            $("tab1").className = "choiceout";
            $("tab2").className = "choiceon";
            $("contentBox1").style.display = "block";
            $("contentBox2").style.display = "none";
            break;
        case 2:
            $("tab1").className = "choiceon";
            $("tab2").className = "choiceout";
            $("contentBox1").style.display = "none";
            $("contentBox2").style.display = "block";
            break;

        case 3:
            $("tab3").className = "choiceon";
            $("tab4").className = "choiceout";
            $("contentBox3").style.display = "block";
            $("contentBox4").style.display = "none";
            break;
        case 4:
            $("tab3").className = "choiceout";
            $("tab4").className = "choiceon";
            $("contentBox3").style.display = "none";
            $("contentBox4").style.display = "block";
            break
        case 5:
            $("ykinfo").className = "on";
            $("hyinfo").className = "out";
            $("shopinfo").style.display = "block";
            $("spinfo").style.display = "none";
            break;
        case 6:
            $("hyinfo").className = "on";
            $("ykinfo").className = "out";
            $("shopinfo").style.display = "none";
            $("spinfo").style.display = "block";
            break;

        case 7:
            $("ykinfo").className = "on";
            $("hyinfo").className = "out";
            $("contentBox3").style.display = "block";
            $("contentBox4").style.display = "none";
            break;
        case 8:
            $("hyinfo").className = "on";
            $("ykinfo").className = "out";
            $("contentBox3").style.display = "none";
            $("contentBox4").style.display = "block";
            break;
    }
}

//询价
function price(url) {
    window.location.href = url + "#message";
}
//联系方式
function relation(url) {
    window.location.href = url + "#link";
}

//查看图片
function selectimg(obj) {
    $("img").src = obj.src;
}

////==========================================================================
////  商业信息详细 结束
////==========================================================================

//function setuiname()
//{
//  var msg=$("_check").value.replace('<br/>','');
//  var Msgs= msg.split(","); 
//  if(Msgs[0]==1)
//   {
//    return alertmsg(false,'您的信息资料不完善,请您及时完善信息资料！',$("weburl").value +'user/edituserinfo.aspx');
//   }
//   else if(Msgs[1]==2)
//   {
//    return alertmsg(false,'您的信息资料没审核,请及时与管理员联系！',$("weburl").value +'index.aspx');  
//   }
//}

////==========================================================================
////  留言信息开始
////==========================================================================

function hrrewrite()//清空会员留言信息
{
    $("txtContent").value = "";
    $("tCode").value = "";
    $("txtTitle").value = $("messageinfotitle").value;
}
function ykrewrite()//清空游客留言信息
{

    $("linkman").value = "";
    $("email").value = "";

    $("mobile").value = "";

    $("neirong").value = "";
    $("GCode").value = "";
    $('im').src = config.WebURL + "Common/Handler.ashx?ac=xy001&" + Math.random();

    for (i = 0; i <= 16; i++) {
        if ($("txt" + i))
            $("txt" + i).className = "three";
    }
    $("title").value = $("messageinfotitle").value;
}

//function showinfo(num)
//{
//if(num==1)
//{
//$("companyid").checked=true;
//$("useridad").checked=false;
//$("nsex").checked=true;
//$("usertype").value=1;

//$("com").style.display='block';
//}
//else
//{
//$("companyid").checked=false;
//$("useridad").checked=true;
//$("nsex").checked=true;
//$("usertype").value=0;
//}
//}

//function checkmessage()
//{
//    if ($("companyname").value == ""){$ ("companyname").focus();return false;}
//    if ($("linkman").value == ""){$("linkman").focus();return false;}
//    if ($("email").value=="" ){$("email").focus();return false;}
//    if ($("pqh").value == ""){$("pqh").focus();return false;}
//    if ($("phm").value == ""){$("phm").focus();return false;}
//    if ($("address").value == ""){$("address").focus();return false;}
//    if ($("title").value == ""){$("title").focus();return false;}
//    if ($("neirong").value == ""){$("neirong").focus();return false;}
//}


var txtobjmessage = new Array("companyname", "linkman", "email", "pgh", "pqh", "phm", "pfjh", "fgh", "fqh", "fhm", "ffjh", "mobile", "citytype", "address", "title", "neirong", "guestVCode", "bir", "door", "school", "spcia", "resume");
// 获取焦点时显示的文字
var ty = new Array(17);
ty[0] = "请填写公司名称";
ty[1] = "请填写联系人姓名";
ty[2] = "请填写电子信箱";
ty[3] = "请输入国别号！";
ty[4] = "请输入联系电话区号";
ty[5] = "请输入联系电话号码";
ty[6] = "请输入联系电话号码分机号";
ty[7] = "请输入国别号";
ty[8] = "请输入传真电话区号";
ty[9] = "请输入传真电话号码";
ty[10] = "请输入传真电话号码分机号";
ty[11] = "请输入电话或手机号码";
ty[12] = "请输入所在地区";
ty[13] = "请输入联系地址";
ty[14] = "请输入留言标题";
ty[15] = "请输入留言内容";
ty[16] = "请输入验证码";
ty[17] = "请选择日期";
ty[18] = "请输入户口所在地";
ty[19] = "请输入学校";
ty[20] = "请输入专业";
ty[21] = "请输入自我介绍";

// 所填信息错误时显示的文字
var tx = new Array(17);
tx[0] = "请输入公司名称";
tx[1] = "请输入联系人姓名";
tx[2] = "您输入的邮件格式不正确";
tx[3] = "请输入国别号";
tx[4] = "请输入联系电话区号";
tx[5] = "请输入联系电话号码";
tx[6] = "请输入联系电话号码分机号";
tx[7] = "请输入国别号";
tx[8] = "请输入传真电话区号";
tx[9] = "请输入传真电话号码";
tx[10] = "请输入传真电话号码分机号";
tx[11] = "电话或手机格式错误,电话:029-88888888,手机:13000000000";
tx[12] = "请输入所在地区";
tx[13] = "请输入联系地址";
tx[14] = "标题长度大于0小于50";
tx[15] = "内容长度大于0小于200";
tx[16] = "请输入验证码";
tx[17] = "请选择日期";
tx[18] = "请输入户口所在地";
tx[19] = "请输入学校";
tx[20] = "请输入专业";
tx[21] = "请输入自我介绍";


// 样式
var cy = new Array(4);
cy[0] = "three"; // 默认
cy[1] = "cue"; // 获得焦点
cy[2] = "right"; // 正确
cy[3] = "wrong"; // 错误


function getobjy(objName) {
    if ($) { return eval('$("' + objName + '")'); }
    else { return eval('document.all["' + objName + '"]'); }
}
// 获得焦点
function fs(num) {
    var obj = "txt" + num;
    getobjy(obj).setAttribute("className", cy[1]);
    getobjy(obj).innerHTML = ty[num];

}

// 正确
function oky(num) {
    var obj = "txt" + num;
    //getobjy(obj).setAttribute("className",cy[2]);
    getobjy(obj).innerHTML = "&nbsp;";
}
// 错误
function errinfo(num) {
    var obj = "txt" + num;
    getobjy(obj).setAttribute("className", cy[3]);
    getobjy(obj).innerHTML = tx[num];
}

function errinfo1(num, msg) {
    var obj = "txt" + num;
    getobjy(obj).setAttribute("className", cy[3]);
    getobjy(obj).innerHTML = tx[msg];
}

function checkinfo(num) {
    var obj = "txt" + num;
    var val = getobjy(txtobjmessage[num]).value; // 获取文本框的值		

    switch (num) {
        case "0": //公司名称
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;
        case "1": // 联系人
            if (val == "") errinfo(num);
            else if (val.length > 50) errinfo(num);
            else oky(num);
            break;
        case "2": // 电子邮件
            if (val == "") errinfo(num);
            else if (!ValidateEmail(val)) errinfo(num)
            else oky(num); break;
        case "3": //国号
            if (val == "") errinfo1(num, num);
            else if (val.length > 3) errinfo1(num, num);
            else if (val.search(/^[-\+]?\d+$/) == -1) errinfo1(num, num);
            else oky(num);
            break;
        case "4": //区号
            if (val == "" || val.length < 3) errinfo1(3, num);
            else if (val.search(/^[-\+]?\d+$/) == -1) errinfo1(3, num);
            else oky(3);
            break;
        case "5": //号码
            if (val == "") errinfo1(3, num);
            else if (val.length < 7) errinfo1(3, num);
            else if (val.search(/^[-\+]?\d+$/) == -1) errinfo1(3, num);
            else oky(3);
            break;
        case "6": //分机号
            if (val == "") oky(3);
            else if (val.search(/^[-\+]?\d+$/) == -1) errinfo1(3, num);
            else oky(3);
            break;
        case "7": //国号					
            if (val.search(/^[-\+]?\d+$/) == -1) errinfo1(7, num);
            else oky(7);
            break;
        case "8": //区号					
            if (val != "" && val.length < 3 && val.search(/^[-\+]?\d+$/) == -1) errinfo1(7, num);
            else oky(7);
            break;
        case "9": //号码
            if (val != "" && val.length < 7 && val.search(/^[-\+]?\d+$/) == -1) errinfo1(7, num);
            else oky(7);
            break;
        case "10": //传真分机号
            if (val == "") oky(7);
            else if (val != "" && val.search(/^[-\+]?\d+$/) == -1) errinfo1(7, num);
            else oky(num);
            break;
        case "11": //电话或手机
            if (val == "") errinfo(num);
            else if (!ValidateMobileTel(val) && !ValidateTel(val)) errinfo(num);
            else oky(num);
            break;
        case "12": //所在地区
            if (val == "") errinfo(num);
            else oky(num);
            break;
        case "13": //联系地址
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;
        case "14": //标题
            if (val == "") errinfo(num);
            else if (val.length > 50) errinfo(num);
            else oky(num);
            break;
        case "15": //内容
            if (getobjy(txtobjmessage[num]).innerHTML == "") errinfo(num);

            else if (getobjy(txtobjmessage[num]).innerHTML.length > 200) errinfo(num);
            else oky(num);
            break;
        case "16": //验证码
            if (val == "") errinfo(num);
            else if (val.search(/^[-\+]?\d+$/) == -1) errinfo(num);
            else oky(num);
            break;

        case "17": //日期
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;
        case "18": //户口
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;
        case "19": //学校
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;
        case "20": //专业
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;
        case "21": //简历
            if (val == "") errinfo(num);
            else if (val.length > 200) errinfo(num);
            else oky(num);
            break;


    }
}
function IsNotNull(source, num) {
    if ($(source).value == "") {
        checkinfo(num);
        return false;
    }
    return true;
}
function checkmessage() {
    if (!IsNotNull("linkman", "1")) return false;
    if (!IsNotNull("email", "2")) return false;

    //alert($("email").value);
    if (!ValidateEmail($("email").value)) {
        checkinfo("2");
        return false;
    }
    if (!IsNotNull("mobile", "11")) return false;
    if (!ValidateMobileTel($F("mobile")) && !ValidateTel($F("mobile"))) {
        checkinfo("11");
        return false;
    }
    if (!IsNotNull("title", "14")) return false;
    if (!IsNotNull("neirong", "15")) return false;
    if ($F("neirong").length > 200) {
        alertmsg(false, "留言内容不能大于200字！");
        return false;
    }
    if ($("guestVCode")) {
        if (!IsNotNull("guestVCode", "16")) return false;
    }

    addmessageae();
}

function UserMessageInit() {
    $("txtTitle").value = $("title").value = $F("_param_message_title");
    var module = $F("_param_message_module");
    if (module != "") {
        var ajax = new Ajax("xy036", "&module=" + module);
        ajax.onSuccess = function () {
            if (ajax.state.result == "1") {
                var html1 = "";
                var html2 = "";
                for (var imsg = 0; imsg < ajax.data.msglist.length; imsg++) {
                    html1 += "<input type =\"checkbox\"  value =\"" + ajax.data.msglist[imsg].title + "\"  name =\"symess\" onclick =\"getsystemmessage();\"/>" + ajax.data.msglist[imsg].title + "<br />";
                    html2 += "<input type =\"checkbox\"  value =\"" + ajax.data.msglist[imsg].title + "\"  name =\"symessuser\" onclick =\"getusersystemmessage();\"/>" + ajax.data.msglist[imsg].title + "<br />";
                }
                $("ks1").innerHTML = html1;
                $("ks2").innerHTML = html2;
            }
        }
    }
}

function addmessageae()//添加留言
{
    sAlert(XY_LOADING, "", false);
    var url = "";
    url += "&linkman=" + escape($F("linkman"));
    url += "&email=" + escape($F("email"));
    url += "&mobile=" + escape($F("mobile"));
    url += "&title=" + escape($F("title"));
    url += "&neirong=" + escape($F("neirong"));
    //url += "&usertype="+escape($F("usertype"));
    url += "&sex=" + ($("nsex").checked ? "1" : "0");
    url += "&type=" + escape($F("_param_message_parent_module"));
    url += "&ids=" + escape($F("_param_message_infoid"));
    if ($("guestVCode")) {
        url += "&GCode=" + escape($F("guestVCode"));
    }
    url += "&uids=" + escape($F("_param_message_userid"));
    var ajax = new Ajax("xy011", url);
    ajax.onSuccess = function () {
        if (ajax.state.result == "1") {
            if (ajax.data.content == "codeErr") {
                alertmsg(false, "验证码有误！");
                $("guestVCodeImg").src = $("userVCodeImg").src = GetNewCode();
                $("guestVCode").focus();
                return false;
            }
            else if (ajax.data.content == "ok") {
                alertmsg(false, "留言成功！对方登陆后，第一时间会看到您的留言！");
                ykrewrite(); //清空表单
            }
            else if (ajax.data.content == "err") {
                alertmsg(false, "留言失败！");
                return false;
            }
            else {
                alertmsg(false, "留言失败！");
            }
        }
    }
}




function checkusermessage() {
    if ($F("txtTitle") == "") {
        alertmsg(false, "请输入留言标题！");
    }
    else if ($F("txtTitle").length > 50) {
        alertmsg(false, "标题不能大于50个字符！");
    }
    else if ($F("txtContent") == "") {
        alertmsg(false, "请输入留言内容！");
    }
    else if ($F("txtContent").length > 100) {
        alertmsg(false, "内容不能大于100个字符！");
    }
    else if ($("userVCode") && $F("userVCode") == "") {
        alertmsg(false, "请输入验证码！");
    }
    else {
        addusermedssage();
    }
}
function addusermedssage() {
    var str_url = window.location.href;
    sAlert(XY_LOADING, "", false);
    var url = "";
    url += "&content=" + $("txtContent").value;
    if ($("userVCode")) {
        url += "&code=" + $("userVCode").value;
    }
    url += "&title=" + $("txtTitle").value;
    url += "&type=" + $("_param_message_parent_module").value;
    url += "&ids=" + $("_param_message_infoid").value;
    url += "&uids=" + $("_param_message_userid").value;

    var ajax = new Ajax("xy012", url);
    ajax.onSuccess = function () {
        if (ajax.state.result == "1") {
            if (ajax.data.content == "codeErr") {
                alertmsg(false, "验证码有误！");
                $("userVCode").value = "";
                $("userVCode").focus();
                $("userVCodeImg").src = $("guestVCodeImg").src = GetNewCode();
                return false;
            }
            else if (ajax.data.content == "ok") {
                alertmsg(false, "留言成功！对方登陆后，第一时间会看到您的留言！");
                hrrewrite(); //清空表单
            }
            else if (ajax.data.content == "nologin") {
                alertmsg(false, '您尚未登陆！', config.WebURL + 'login.' + config.Suffix + '?surl=' + escape(str_url));
            }
            else if (ajax.data.content == "nomessage") {
                alertmsg(false, "您不能给自己留言！");
            }
            else if (ajax.data.content == "err") {
                alertmsg(false, '留言失败');
            }
        }
    }
}


//function gettephone()
//{
//$("fgh").value=$("pgh").value;
//$("fqh").value=$("pqh").value;
//$("fhm").value=$("phm").value;
//$("ffjh").value=$("pfjh").value;
//}

function getsystemmessage() {
    var info = "";
    var chkother = document.getElementsByName("symess");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {

            if (chkother[i].checked == true) {
                info += chkother[i].value + '\n';
            }

        }
    }
    $("neirong").value = info;

}

function getusersystemmessage() {
    var messinfo = "";
    var chkother = document.getElementsByName("symessuser");
    for (var i = 0; i < chkother.length; i++) {
        if (chkother[i].type == 'checkbox') {

            if (chkother[i].checked == true) {
                messinfo += chkother[i].value + '\n';
            }

        }
    }

    $("txtContent").value = messinfo;
}

////==========================================================================
////  留言信息 结束
////==========================================================================




//收藏岗位信息
function getjobinfo() {
    var chk = document.getElementsByTagName("input");
    var ids = "";
    var num = 0;
    for (var i = 0; i < chk.length; i++) {
        if (chk[i].type == 'checkbox') {
            if (chk[i].checked == true) {
                ids += "," + chk[i].value;
                num++;
            }
        }
    }
    if (num == 0) {
        return alertmsg(false, "至少要选择一条记录才能收藏！");
    }
    else {
        $("ids").value = ids.substring(1);
        Favorite()
    }
}
////==========================================================================
////  收藏信息 开始
////==========================================================================
function Favorite() {
    var str_url = escape(window.location.href);
    var ajax = new Ajax("xy023", "&Module=" + $F("_param_userinfo_parent_module") + "&InfoId=" + $F("_param_userinfo_infoid") + "&UserId=" + $F("_param_userinfo_userid"));
    ajax.onSuccess = function () {
        if (ajax.state.result == "1") {
            if (ajax.data.content == "nologin") {
                alertmsg(false, "您尚未登陆，请登陆后收藏！", config.WebURL + 'login.' + config.Suffix + '?surl=' + str_url);
            }
            else if (ajax.data.content == "ok") {
                alertmsg(false, "收藏成功");
            }
            else if (ajax.data.content == "err") {
                alertmsg(false, "收藏失败");
            }
            else if (ajax.data.content == "exis") {
                alertmsg(false, "该信息已被收藏！");
            }
            else if (ajax.data.content == "nomessage") {
                alertmsg(false, "您不能收藏自己发布的信息！");
            }
            else {
                alertmsg(false, '系统异常！请稍后再试！');
            }
        }
    }
}
////==========================================================================
////  收藏信息 结束
////==========================================================================

/*==========================================================================
浏览信息增加点击量 开始 
pageModule：页面标识
Module:模块名称
infoID:信息Id
userID:用户Id
isUp:是否更新浏览次数(可选，1：更新，0：不更新；默认为1)

tc 2008-11-27 modify
=======================================================================*/
function GetClickNum(pageModule, Module, infoID, userID, isUp) {
    var strhref = "";

    strhref += "&Page=" + pageModule;
    strhref += "&Module=" + Module;
    strhref += "&InfoId=" + infoID;
    strhref += "&UId=" + userID;


    if (undefined == isUp)
        isUp = 1;

    strhref += "&isUp=" + isUp;

    var ajax = new Ajax("XY013", strhref);
    ajax.onSuccess = function () {
        if ("1" == ajax.state.result) {
            if (ajax.data.pause == "1") {
                try {
                    $("clicknum").innerHTML = ajax.data.clicknum;
                    $("messnum").innerHTML = ajax.data.messagenum;
                }
                catch (e) { }

                if (ajax.data.linktype == "1")//可以查看联系方式
                {

                    if (ajax.data.userinfo == undefined) return;

                    //---------------- 页面下方企业联系方式
                    var strConteacts = "";

                    strConteacts += "<table width=\"80%\" border=\"0\" align=\"center\" cellpadding=\"1\" cellspacing=\"1\" class=\"contactlist\">";
                    strConteacts += "<tr>";
                    strConteacts += "<td class=\"typetitle\">企业名称</td>";
                    strConteacts += "<td colspan=\"3\"><a href=\"";
                    strConteacts += ajax.data.userinfo[0].shopindex;
                    strConteacts += "\" class=\"link14\"";
                    strConteacts += ">" + ajax.data.userinfo[0].uiname + "</a></td>";
                    strConteacts += "</tr>";
                    strConteacts += "<tr>";
                    strConteacts += "<td  class=\"typetitle\">联系人</td>";
                    strConteacts += "<td>" + ajax.data.userinfo[0].linkman + "</td>";
                    strConteacts += "<td  class=\"typetitle\">联系电话</td>";
                    strConteacts += "<td>";
                    strConteacts += ajax.data.userinfo[0].telephone;
                    strConteacts += "</td>";
                    strConteacts += "</tr>";
                    strConteacts += "<tr>";
                    strConteacts += "<td  class=\"typetitle\">手机号码</td>";
                    strConteacts += "<td>";
                    strConteacts += ajax.data.userinfo[0].mobile;
                    strConteacts += "</td>";
                    strConteacts += " <td  class=\"typetitle\">传真</td>";
                    strConteacts += "<td>";
                    strConteacts += ajax.data.userinfo[0].fax;
                    strConteacts += "</td>";
                    strConteacts += " </tr>";
                    strConteacts += "<tr>";
                    strConteacts += "<td  class=\"typetitle\">Email</td>";
                    strConteacts += "<td>" + ajax.data.userinfo[0].email + "</td>";
                    strConteacts += "<td  class=\"typetitle\">网址</td>";
                    strConteacts += " <td><a href=\"" + ajax.data.userinfo[0].siteurl + "\"target =\"_blank\">" + ajax.data.userinfo[0].siteurl + "</a></td>";
                    strConteacts += " </tr>";
                    strConteacts += "<tr>";
                    strConteacts += " <td  class=\"typetitle\">地址</td>";
                    strConteacts += " <td colspan=\"3\">" + ajax.data.userinfo[0].address + "</td>";
                    strConteacts += "</tr>";
                    strConteacts += "</table>";

                    $("linkmessage").innerHTML = strConteacts;

                    if (pageModule != "company") {
                        $("loginnouser").style.display = "none";
                        $("UserNoLogin").style.display = "none";
                        $("loginuser").style.display = "block";

                        //显示联系方式
                        $("loginuseruginfo").innerHTML = "<img src=\"" + ajax.data.userinfo[0].uimgurl + "\" alt=\"\"/>" + ajax.data.userinfo[0].uname;

                        //公司名称以及链接
                        $("loginuserurl").href = ajax.data.userinfo[0].uhtmlpage;
                        $("loginuserurl").innerHTML = ajax.data.userinfo[0].uiname;
                        //公司简介链接
                        $("UserIntro").href = ajax.data.userinfo[0].uhtmlpage;

                        //$("userShopUrl").href = msgvalues[2];
                        $("ConsummatePercent").innerHTML = ajax.data.userinfo[0].ureginformation + "%";
                        $("PercentForImg").width = ajax.data.userinfo[0].uinformation;
                        $("loginuseryearnum").innerHTML = ajax.data.userinfo[0].year;

                        //联系人
                        $("LinkManName").innerText = ajax.data.userinfo[0].linkman;
                        //诚信档案
                        $("GoodFaithFile").href = ajax.data.userinfo[0].goodFaithFile;
                        //最新供应
                        $("NewOfferPage").href = ajax.data.userinfo[0].newOfferPage;
                        //联系我们
                        $("Contact").href = ajax.data.userinfo[0].contact;
                        //给我留言
                        $("memessage").href = ajax.data.userinfo[0].contact;
                        //联系方式
                        $("linkme").href = ajax.data.userinfo[0].contact;

                        //QQ在线
                        if (ajax.data.userinfo[0].userIM != "") $("IMOnline").innerHTML = ajax.data.userinfo[0].userIM;
                    }
                }
                else if (ajax.data.linktype == "0") {
                    $("linkmessage").innerHTML = "<span>您当前的身份，不能查看联系方式</span>";

                    if (pageModule != "company") {
                        $("loginnouser").style.display = "block";
                        $("UserNoLogin").style.display = "none";
                        $("loginuser").style.display = "none";

                        if (ajax.data.userinfo != undefined) {
                            //不显示联系方式
                            $("loginnouseruginfo").innerHTML = "你目前是" + ajax.data.userinfo[0].uname + "，无法查看该联系方式";
                        }
                    }
                }
                else if (ajax.data.linktype == "-1") {
                    if (pageModule != "company") {
                        $("loginnouser").style.display = "none";
                        $("UserNoLogin").style.display = "";
                        $("loginuser").style.display = "none";
                    }
                    $("linkmessage").innerHTML = "<span>您当前的身份，不能查看联系方式</span>";
                }
                return false;
            }
            else if (ajax.data.pause == "0") {
                window.location.href = config.WebURL + "Redirect." + config.Suffix + "?msg=0";
            }
            else {
                window.location.href = config.WebURL + "Redirect." + config.Suffix + "?msg=-1";
            }
        }
        else {

        }
    }
}
////==========================================================================
////  浏览信息增加点击量 结束
////==========================================================================

////==========================================================================
////  浏览简历
////==========================================================================
function GetResume(infoID) {
    var strhref = "";
    var str = "";
    strhref += "&InfoId=" + infoID;
    var ajax = new Ajax("xy037", strhref);
    ajax.onSuccess = function () {
        if ("1" == ajax.state.result) {
            if (ajax.data.linktype == "1")//可以查看联系方式
            {
                str += "<table style=\"text-align:center;\">";
                str += "<caption style=\"text-align:left; font-size:16px;font-weight:bold;\">个人信息</caption>";
                str += "<tr>";
                str += "<td class=\"typetitle\">真实姓名：</td>";
                str += "<td>" + ajax.data.userinfo[0].uname + "</td>";
                str += "<tr>";
                str += "<td  class=\"typetitle\">注册邮箱：</td>";
                str += "<td>" + ajax.data.userinfo[0].email + "</td>";
                str += "</tr>";
                str += "<tr>";
                str += "<td  class=\"typetitle\">联系电话：</td>";
                str += "<td>" + ajax.data.userinfo[0].tel + "</td>";
                str += "</tr>";
                str += "<tr>";
                str += "<td  class=\"typetitle\">手机：</td>";
                str += "<td>" + ajax.data.userinfo[0].mobil + "</td>";
                str += "</tr>";
                str += "<tr>";
                str += "<td  class=\"typetitle\">联系地址：</td>";
                str += "<td>" + ajax.data.userinfo[0].address + "</td>";
                str += "</tr>";
                str += "<tr>";
                str += " <td  class=\"typetitle\">身份证号：</td>";
                str += "<td>" + ajax.data.userinfo[0].code + "</td>";
                str += " </tr>";
                str += "</table>";

                $("linkmessage").innerHTML = str;
            }
            else if (ajax.data.linktype == "0") {
                $("linkmessage").innerHTML = "<span style=\"font-weight:bold;\">您当前的身份，不能查看联系方式</span>";
            }
            else if (ajax.data.linktype == "-1") {
                $("linkmessage").innerHTML = "<span style=\"font-weight:bold;\">您当前的身份，不能查看联系方式</span>";
            }
            return false;
        }
        else {

        }
    }
}


////==========================================================================
////  留言信息设置 开始
////==========================================================================

function getMessageinfo(title, content) {
    $("txtTitle").value = title;
    $("txtContent").value = content;
}
////==========================================================================
////  留言信息设置 结束
////==========================================================================




////==========================================================================
////
////  交易开始
////
////==========================================================================
function getMoney(obj) {
    var ProductPrice = $("ProductPrice").value;
    var ProductSmallNum = $("ProductSmallNum").value;
    var OrderMoney = $("OrderMoney");
    if (!isFinite(parseFloat(obj.value))) {
        obj.value = ProductSmallNum;
        obj.focus();
        return alertmsg(false, "请输入有效的数字!");

    }
    else if (parseFloat(obj.value) < parseFloat(ProductSmallNum)) {
        obj.varue = ProductSmallNum;
        obj.focus();
        return alertmsg(false, "该产品的最小起订量为!" + ProductSmallNum);
    }
    else {
        OrderMoney.innerHTML = parseFloat(obj.value) * parseFloat(ProductPrice);
    }

}
/*20080607 TC*/
function InsertOrder() {
    var number = $("txtNumber");
    var linkMan = $("txtLinkMan");
    var linkAddress = $("txtLinkAddress");
    var linkTelphone = $("txtLinkTelphone");

    var msgs = '';
    var flag = true;
    var foucuse = null;

    if (number.value == "") { msgs = "请填写数量！"; foucuse = $("txtNumber"); flag = false; }

    if ($("vcode") && $("vcode").value == "") {
        if (flag) { msgs = "请输入验证玛！"; foucuse = code; flag = false; }
        else { msgs += "</br>请输入验证玛!"; flag = false; }
    }

    if (linkAddress.value == "") {
        if (flag) { msgs = "请输送货地址！"; foucuse = linkAddress; flag = false; }
        else { msgs += "</br>请输入送货地址！"; flag = false; }
    }

    if (linkMan.value == "") {
        if (flag) { msgs = "请输入联系人！"; foucuse = linkMan; flag = false; }
        else { msgs += "</br>请输入联系人！"; flag = false; }
    }

    if (linkTelphone.value == "") {
        if (flag) { msgs = "请输入联系电话！"; foucuse = linkTelphone; flag = false; }
        else { msgs += "</br>请输入联系电话！"; flag = false; }
    }
    else {
        var telephone = linkTelphone.value;
        telephone = ReplaceAll(telephone, '，', ',');

        var teles = telephone.split(",");

        for (var i = 0; i < teles.length; i++) {
            if (!ValidateTel(teles[i])) {
                msgs += "联系电话格式错误";
                break;
            }
        }
    }

    if (flag) { AddOrder(); }
    else { return alertmsg(false, msgs); }
}

function AddOrder() {
    var sd_id = $F("cp_id");
    var Number = $("txtNumber").value;
    var linkMan = $("txtLinkMan").value;
    var linkTelphone = $F("txtLinkTelphone");
    var linkAddress = $("txtLinkAddress").value;
    var code = "";

    try { code = $F("vcode"); } catch (e) { }
    var url = "&infoId=" + sd_id + "&code=" + code + "&number=" + Number + "&linkMan=" + linkMan + "&linkAddress=" + linkAddress + "&linkTelphone=" + linkTelphone;

    var ajax = new Ajax("XY022", url);
    sAlert(XY_LOADING);

    ajax.onSuccess = function () {
        sAlert(ajax.state.message);
        if (ajax.state.result == 1)
            window.location.href = config.WebURL + "user/orderbuylist." + config.Suffix;
        else
            $("imgs").src = GetNewCode();
    }
}
////==========================================================================
////  交易结束
////==========================================================================


////==========================================================================
////  关键字竞价 开始
////==========================================================================

function getsearchkeylist() {
    if ($("tbsearchkey").value == "")
        return alertmsg(false, '请先输入您要选择的关键词');
}

function SetDiv(num) {
    if (num == 1) {
        $("DivInfo").style.display = "block";
        $("DivHistory").style.display = "block";
        $("H4").style.display = "block";
        $("LI1").className = "on";
        $("LI2").className = "out";
        $("LI3").className = "out";
    }
    if (num == 2) {
        $("DivInfo").style.display = "block";
        $("DivHistory").style.display = "block";
        $("H4").style.display = "none";
        $("LI1").className = "out";
        $("LI2").className = "on";
        $("LI3").className = "out";
    }
    if (num == 3) {
        $("DivInfo").style.display = "none";
        $("H4").style.display = "block";
        $("DivHistory").style.display = "block";
        $("LI1").className = "out";
        $("LI2").className = "out";
        $("LI3").className = "on";
    }
}

function selectdiv(num) {
    if (num == 1) {
        $("LI1").className = "on";
        $("LI2").className = "out";
        $("LI3").className = "out";
        $("LI4").className = "out";
        $("DIV1").style.display = "block";
        $("DIV2").style.display = "none";
        $("DIV3").style.display = "none";
        $("DIV4").style.display = "none";
    }
    if (num == 2) {
        $("LI1").className = "out";
        $("LI2").className = "on";
        $("LI3").className = "out";
        $("LI4").className = "out";
        $("DIV1").style.display = "none";
        $("DIV2").style.display = "block";
        $("DIV3").style.display = "none";
        $("DIV4").style.display = "none";
    }
    if (num == 3) {
        $("LI1").className = "out";
        $("LI2").className = "out";
        $("LI3").className = "on";
        $("LI4").className = "out";
        $("DIV1").style.display = "none";
        $("DIV2").style.display = "none";
        $("DIV3").style.display = "block";
        $("DIV4").style.display = "none";
    }
    if (num == 4) {
        $("LI1").className = "out";
        $("LI2").className = "out";
        $("LI3").className = "out";
        $("LI4").className = "on";
        $("DIV1").style.display = "none";
        $("DIV2").style.display = "none";
        $("DIV3").style.display = "none";
        $("DIV4").style.display = "block";
    }
}
////==========================================================================
////  关键字竞价 结束
////==========================================================================


////==========================================================================
////  意见反馈 开始
////==========================================================================   
function CheckFeedback() {
    if ($("title").value.trim() == "") {
        return alertmsg(false, '主题为必填项！');
    }

    if ($("Name").value.trim() == "") {
        return alertmsg(false, '姓名为必填项！');
    }

    if ($("email").value.trim() == "") {
        return alertmsg(false, 'E-Mail为必填项！');
    }

    if ($("email").value.trim().search(/^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$/) == -1) {
        return alertmsg(false, 'Email格式有误，请检查！');
    }

    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);
    if (content.trim() == "") {
        return alertmsg(false, '内容为必填项！');
    }

    if (content.length > 1000) {
        return alertmsg(false, '您输入的内容过长！');
    }

    if ($("vcode")) {
        var code = $F("vcode").trim();
        if (code == "" || code.length != 6) return alertmsg(false, '请输入正确的验证码！');
    }
}
////==========================================================================
////  意见反馈 结束
////==========================================================================

//网店相关

//设置当前要选中的菜单
function xy_Shop_SetMenu() {
    var tmpIndex = location.href.lastIndexOf("/");

    var pageName = location.href.substr(tmpIndex + 1, location.href.length - tmpIndex);

    pageName = pageName.split(".")[0];

    if (pageName == "") pageName = "index";

    if (pageName.indexOf("-") != -1) pageName = pageName.substr(0, pageName.indexOf("-"));

    if (pageName == "job") pageName = "joblist";

    if (pageName == "newsinfo") pageName = "newslist";

    if (pageName == "brandinfo") pageName = "brandlist";

    if (pageName == "venture" || pageName == "service" || pageName == "investment") pageName = "offer";

    var menuId = "";

    menuId = "_shop_menu_" + pageName;

    var pcon = document.getElementById("_shop_menu_list");

    var eles = pcon.getElementsByTagName("li");

    for (var i = 0; i < eles.length; i++) {
        eles[i].className = "";
    }

    document.getElementById(menuId).className = "hover";
}




//  网店内的搜索实现 开始
function xy_Shop_Search() {
    var productname = "";
    var productname = $("Products").value;
    var prourl = "";

    if (productname == "") return;

    prourl = "product--" + productname + "-." + config.Suffix;

    location = prourl;
}

//申请职位
function xy_Shop_ApplyJob() {
    var ajax = new Ajax("XY027", "&eid=" + $F("JobId"));
    ajax.onSuccess = function () {
        if (ajax.state.result == "1") {
            if (ajax.data.content == "nologin") {
                window.location.href = config.WebURL + 'login.' + config.Suffix + '?surl=' + escape(window.location.href);
                return false;
            }

            if (ajax.data.content == "ok") { alertmsg(false, "简历成功发送！"); return false; }
            if (ajax.data.content == "exists") { alertmsg(false, "申请失败！您已经申请过该职位！"); return false; }
            if (ajax.data.content == "self") { alertmsg(false, "申请失败！这是您发的职位信息！"); return false; }
            if (ajax.data.content == "company") { alertmsg(false, "您是企业用户，不能申请职位信息！"); return false; }
            if (ajax.data.content == "resume") { alertmsg(false, "申请失败！您没有完善你的简历信息！"); return false; }

            alertmsg(false, "发送失败！请稍后再试！！"); return false;
        }
    }
}

//推荐职位给好朋友
function xy_Shop_CommendJob() {
    var fromEmail = $("txtFromEmail").value;
    var toEmail = $("txtToEmail").value;
    var fromName = $("txtFromName").value;

    var msg = "", flag = true;
    var emails = toEmail.split(",")

    if (fromName == "") { msg = "请输入您的姓名！"; flag = false; }
    if (fromEmail == "") {
        if (flag) { flag = false; msg = "请输入您的邮箱！"; }
        else { flag = false; msg += "<br/>请输入您的邮箱！"; }
    }
    else if (!ValidateEmail(fromEmail)) {
        if (flag) { flag = false; msg = "您的邮箱格式不正确！"; }
        else { flag = false; msg += "<br/>您的邮箱格式不正确！"; }
    }
    if (toEmail != "") {
        for (var i = 0; i < emails.length; i++) {
            if (!ValidateEmail(emails[i])) { flag = false; msg += "<br/>" + emails[i]; }
        }
        if (!flag) {
            msg += "<br/>格式不正确！";
        }
    }
    else {
        if (flag) { flag = false; msg = "请输入您朋友的邮箱！"; }
        else { flag = false; msg += "<br/>请输入您朋友的邮箱！"; }
    }

    if (!flag) { alertmsg(false, msg); return false; }

    var jobUrl = window.location.href;
    var jobName = $("txtjobname").value;

    sAlert("正在发送邮件，请稍等...<br /><img src='/common/images/ajax-loader.gif' />");

    var ajax = new Ajax("XY028", "&FromEmail=" + fromEmail + "&ToEmail=" + toEmail + "&JobUrl=" + jobUrl + "&JobName=" + jobName + "&FromName=" + fromName);
    ajax.onSuccess = function () {
        if (ajax.state.result == "1") {
            sClose();
            if (ajax.data.content == "nologin") {
                window.location.href = config.WebURL + 'login.' + config.Suffix + '?surl=' + escape(window.location.href);
                return false;
            }

            if (ajax.data.content == "ok") { alertmsg(false, "推荐成功！", window.location.href); return false; }
            if (ajax.data.content == "err") { alertmsg(false, "系统邮件服务器设置错误，发送失败！"); return false; }

            alertmsg(false, "发送失败！系统未设置邮件服务器！"); return false;
        }
    }
}

//清空推荐为好友表单
function xy_Shop_ResetCmdJobForm() {
    $("txtFromEmail").value = '';
    $("txtToEmail").value = '';
    $("txtFromName").value = '';
}

//
function xy_Sel_CurBigMenu(flagName) {
    var pBox = document.getElementById('_xy_big_menu_box');

    var aEles = pBox.getElementsByTagName("a");

    for (var i = 0; i < aEles.length; i++) {
        aEles[i].className = "";
    }

    if (flagName == undefined) {
        var curPage = location.href.replace(config.WebURL, "");

        curPage = curPage.substr(0, curPage.indexOf("/"));

        if (curPage == "") curPage = "index";

        var munuName = "_xymenu_" + curPage;

        try {
            document.getElementById(munuName).className = 'tabactive';
        } catch (e) {
            document.getElementById("_xymenu_index").className = 'tabactive';
        }
    }
    else {
        if (flagName == "") flagName = "index";

        var munuName = "_xymenu_" + flagName;

        try {
            document.getElementById(munuName).className = 'tabactive';
        } catch (e) {
            document.getElementById("_xymenu_index").className = 'tabactive';
        }
    }
}


function xy_ShowSearchMenu() {
    if (document.getElementById('headSel').style.display == 'none') {
        document.getElementById('headSel').style.display = 'block';
    } else {
        document.getElementById('headSel').style.display = 'none';
    }

    return false;
}

function xy_SelectSearchMenu(showName, flagName, infoType) {
    document.getElementById("xy_FlagName").value = flagName;
    document.getElementById("xy_InfoType").value = infoType;

    document.getElementById('headSlected').innerHTML = showName;
    document.getElementById('headSel').style.display = 'none';

    setTimeout("drop_hide('head')", 10);
}

function setTab(name, cursel, n) {
    var RefreshID = null;
    if (RefreshID) { clearTimeout(RefreshID); }
    RefreshID = setTimeout("Switch('" + name + "','" + cursel + "','" + n + "')", 10);
}

function Switch(name, cursel, n) {
    for (i = 1; i <= n; i++) {
        var menu = document.getElementById(name + i);
        var con = document.getElementById("con_" + name + "_" + i);
        menu.className = i == cursel ? "current" : "";
        con.style.display = i == cursel ? "block" : "none";
    }
}


function drop_mouseover(pos) {
    try { window.clearTimeout(timer); } catch (e) { }
}

function drop_mouseout(pos) {
    var posSel = document.getElementById(pos + "Sel").style.display;
    if (posSel == "block") {
        timer = setTimeout("drop_hide('" + pos + "')", 1000);
    }
}

function drop_hide(pos) {
    document.getElementById(pos + "Sel").style.display = "none";
}


window.onerror = function () { return true; }

function slideLine(ul, delay, speed, lh) {
    var slideBox = (typeof ul == 'string') ? document.getElementById(ul) : ul;
    var delay = delay || 1000, speed = speed || 20, lh = lh || 20;
    var tid = null, pause = false;
    var start = function () {
        tid = setInterval(slide, speed);
    }

    var slide = function () {
        if (pause) return;
        slideBox.scrollTop += 2;
        if (slideBox.scrollTop % lh == 0) {
            clearInterval(tid);
            slideBox.appendChild(slideBox.getElementsByTagName('li')[0]);
            slideBox.scrollTop = 0;
            setTimeout(start, delay);
        }
    }

    slideBox.onmouseover = function () { pause = true; }
    slideBox.onmouseout = function () { pause = false; }
    setTimeout(start, delay);

}
/*********百科收藏********/
function FavoriteLemma() {
    var str_url = escape(window.location.href);
    var ajax = new Ajax("xy044", "&InfoId=" + $F("txtInfoId") + "&UserId=" + $F("txtUserId"));
    ajax.onSuccess = function () {
        if (ajax.state.result == "1") {
            if (ajax.data.content == "nologin") {
                alertmsg(false, "您尚未登陆，请登陆后收藏！", config.WebURL + 'login.' + config.Suffix + '?surl=' + str_url);
            }
            else if (ajax.data.content == "ok") {
                alertmsg(false, "收藏成功");
            }
            else if (ajax.data.content == "err") {
                alertmsg(false, "收藏失败");
            }
            else if (ajax.data.content == "exis") {
                alertmsg(false, "该信息已被收藏！");
            }
            else if (ajax.data.content == "nomessage") {
                alertmsg(false, "您不能收藏自己发布的信息！");
            }
            else {
                alertmsg(false, '系统异常！请稍后再试！');
            }
        }
    }
}
/*百科开始*/

/*
词条添加，验证
*/

function lemmaadd() {
    if (CheckLemmaForm()) {
        CheckLemmaName($("lemmaname"));
    }
}

function lemmaedit() {
    if (CheckLemmaForm()) {
        var reason = $F("modifyReason");
        if (reason.trim() == "") {
            sAlert("请输入修改原因！");
            return false;
        }

        $("frmlemma").submit();
    }
}

function CheckLemmaForm() {
    /*词条名称*/
    var lemma = $F("lemmaname");
    if (lemma.trim() == "") {
        sAlert("词条名称为必填项！");
        return false;
    }

    /*类型*/
    var type = $F("typeId");
    if (type.trim() == "") {
        sAlert("请选择百科分类！");
        return false;
    }

    var oEditor = FCKeditorAPI.GetInstance('xyecom');
    var oDOM = oEditor.EditorDocument;
    var text = oDOM.body.innerText;
    if (text.trim() == "") {
        sAlert("词条内容为必填项！");
        return false;
    }
    return true;
}

function CheckLemmaNameBlur() {
    var data = new SearchGetValue();
    var query = "&lemmaname=" + $F("lemmaname");
    var ajaxcls = new Ajax("xy041", query);
    ajaxcls.onSuccess = function () {
        if (ajaxcls.state.result == "1") {
            if (ajaxcls.state.message != "") {
                //window.location.href = config.WebURL+'login.'+config.Suffix+'?surl='+escape();
                sAlert(ajaxcls.state.message);
            }
        }
    }
}

function CheckLemmaName(obj) {
    var data = new SearchGetValue();
    var query = "&lemmaname=" + obj.value
    var ajaxcls = new Ajax("xy041", query);
    ajaxcls.onSuccess = function () {
        if (ajaxcls.state.result == "1") {
            if (ajaxcls.state.message != "") {
                //window.location.href = config.WebURL+'login.'+config.Suffix+'?surl='+escape();
                sAlert(ajaxcls.state.message);
                return false;
            }
            else {
                $("frmlemma").submit();
            }
        }
    }
}

function GetBaikeSearchValue() {
    var arrquery = new Array("typeid", "keyword", "pageindex");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/") + 1);

    var arrValue;

    if (config.BogusStatic) {
        var values = url.substring(0, url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        arrValue.shift();
        arrValue[2] = unescape(arrValue[2]);
    }
    else {
        arrValue = new Array(arrquery.length);
        for (var i = 0; i < arrquery.length; i++) {
            arrValue[i] = GetQueryString(arrquery[i]);
        }
        arrValue[2] = unescape(arrValue[2]);
    }

    for (var i = 0; i < arrquery.length; i++) {
        if (arrValue[i] == undefined || arrValue[i] == "undefined") arrValue[i] = "";
    }
    return {
        query: arrquery,
        value: arrValue,
        objData: {
            typeid: arrValue[0],
            keyword: arrValue[1],
            pageindex: arrValue[2]
        }
    };
}

function SetBaikeSearchDefaultValue() {
    var data = new GetBaikeSearchValue();
    if (data.objData.keyword.indexOf(",") != -1) {
        var arr = data.objData.keyword.split(",");
        var d = $("txtkeyword");
        $("txtkeyword").value = arr[0] == undefined ? "" : arr[0];
    }
    else {
        if (data.objData.keyword != "undefined")
            $("txtkeyword").value = data.objData.keyword;
    }
    try {
        $("typeid").value = data.objData.typeid;
        cla.Mode = "select";

    } catch (e) { }
}

function BaikeListSearch() {

    if (!CheckSearchKey($F("txtkeyword"))) return false;

    var data = new GetBaikeSearchValue();

    var href = config.WebURL + "baike/list";
    if (config.BogusStatic) {
        for (var i = 0; i < data.query.length; i++) {
            href += "-";

            if (data.query[i] == "typeid") {
                href += $F("typeid");
            }
            else if (data.query[i] == "keyword") {
                href += $F("txtkeyword");
            }
            else
                href += data.value[i];
        }
        href += "." + config.Suffix;
    }
    else {
        href += "." + config.Suffix;
        for (var i = 0; i < data.query.length; i++) {
            href += (0 == i ? "?" : "&") + data.query[i] + "=";
            if (data.query[i] == "typeid") {
                href += $F("typeid");
            }
            else if (data.query[i] == "keyword") {
                href += $F("txtkeyword");
            }
            else
                href += data.value[i];
        }

    }
    window.location = href;
}

/*百科结束*/