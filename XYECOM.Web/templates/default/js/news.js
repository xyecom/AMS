/*
新闻模块常用JS
*/

function InsertComment() {

    var newsId = $F("NewsId").trim();
    var body = $F("CommentBody").trim();
    var isHiddenIP = $("IsHiddenIP").checked ? 1 : 0;
    var code = "";
    try {
        code = $F("vcode");
    } catch (e) { }

    if (newsId == "") return alertmsg(false, "异常：新闻ID不能为空！");

    if (body == "") return alertmsg(false, "评论内容不能为空！");

    if (body.length > 200) return alertmsg(false, "评论内容不能超过200字！");

    var url = "&CommentBody=" + escape(body) + "&NewsID=" + escape(newsId) + "&IsHiddenIP=" + escape(isHiddenIP) + "&code=" + code;

    var ajax = new Ajax("XY015", url);
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            $("CommentBody").value = "";
            try {
                ShowNewsCommentList();
                $("vCodeImg").src = GetNewCode();
            } catch (e) { }
        }
        if (ajax.state.result == 0) {
            return alertmsg(false, ajax.state.message);
        }
    }
}

function ShowNewsCommentList() {
    //$("listst").innerHTML = "<div>评论载入中.....</div>";

    var ajax = new Ajax("XY026", "&value=" + $("NewsId").value);
    ajax.onSuccess = function () {

        if (ajax.state.result == 1) {
            var list = "";
            var length = ajax.data.comment.length;
            var url = "";

            for (var i = 0; i < length; i++) {
                var url = ajax.data.comment[i].user[0].shopurl;
                list += "<dd>";
                if (url != "") {
                    list += "<strong><a href='" + url + "' target='_blank'>" + ajax.data.comment[i].user[0].name + "</a></strong>";
                } else {
                    if (ajax.data.comment[i].user[0].type == "person")
                        list += "<strong>" + ajax.data.comment[i].user[0].name + "</strong>(个人会员)";
                    else
                        list += "<strong>" + ajax.data.comment[i].user[0].name + "</strong>(匿名网友)";
                }
                list += " 于 <span>" + ajax.data.comment[i].sendtime + "</span>";

                list += "</dd>";

                list += "<dt>" + ajax.data.comment[i].content + "</dt>";
            }

            $("listst").innerHTML = list;
        }
        if (ajax.state.result == 0) {
            $("listst").innerHTML = ajax.state.message;
        }
    }
}



function reSet() {
    document.getElementById("NewsDiscussContent").value = "";
}

function GetDiscuss() {
    try {
        ShowNewsCommentList();
    } catch (e) { }
}




function toBreakWord(intLen) {
    var obj = document.getElementById("ff");
    var strContent = obj.innerHTML;
    var strTemp = "";
    while (strContent.length > intLen) {
        strTemp += strContent.substr(0, intLen) + " ";
        strContent = strContent.substr(intLen, strContent.length);
    }
    strTemp += " " + strContent;
    obj.innerHTML = strTemp;
}
if (document.getElementById && !document.all)
    toBreakWord(20)
/* 发送评论 */

function Showok() {
    var webmoney = document.getElementById("hwebmoney").value;
    var money = document.getElementById("hmoney").value;

    var url = "&webmoney=" + webmoney + "&money=" + money + "&nid=" + document.getElementById("NID").value;
    var ajax = new Ajax("XY031", url);
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            window.location.href = $("newurl").value;
        }
        if (ajax.state.result == 0) {
            alert(ajax.state.message);
            var returl = config.WebURL + "news/Redirect." + config.Suffix + "?type=1&ret=" + tempvalue + "&old=" + document.getElementById("geturl").value;

            window.location.href = returl
        }
    }
}

function Showno() {
    window.location.href = document.getElementById("geturl").value;
}

//*******投稿***********//

function CheckContributorNews() {
    if ($("title").value.trim() == "") {
        return alertmsg(false, '新闻标题为必填项！');
    }

    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);
    if (content.trim() == "") {
        return alertmsg(false, '新闻内容为必填项！');
    }

    if (content.length > 8000) {
        return alertmsg(false, '您输入的内容过长！');
    }

    if ($("hidTypeId").value == "") {
        return alertmsg(false, '请选择对应栏目！');
    }

    if ($("newskeyword").value.trim() == "") {
        return alertmsg(false, '请填写关键字！');
    }
    if ($("vcode")) {
        var code = $F("vcode").trim();
        if (code == "") return alertmsg(false, '请输入正确的验证码！');
    }
}

/**********News_Scheme***********/
function News_Buy() {
var arr = $("content").getElementsByTagName("input");
var strids = "";
var nonum = 0;

for (var i = 0; i < arr.length; i++) {
        if(arr[i].type=='checkbox') {
            if (arr[i].checked) {
                nonum = 1;
                strids += arr[i].value + ",";
            }
        }
    }
    if (nonum == 0) {
        return alertmsg(false, '请选择一个产品！');
    }
    else{
        strids = strids.substring(0, strids.length - 1);
    window.location.href = config.WebURL + "common/initcart." + config.Suffix + "?pids=" + strids;
    }
}

//function ShowPriceRange(ProId) {
//    $("PriceRange_" + ProId).style.display = 'block';
//}

//function UnShowPriceRange(ProId) {
//    $("PriceRange_" + ProId).style.display = 'none';
//    var BuyNum = $("ProId_" + ProId).value;
//    var LeastNum_ = $("LeastNum_" + ProId).value;
//    if(BuyNum > LeastNum_)

//}