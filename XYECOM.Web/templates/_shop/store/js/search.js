//document.writeln("<script language=\"javascript\" type=\"text/javascript\" src=\"/config/js/config.js\"></script>");
//$(document).ready(function () {
//    $("#btnsearch").click(function () {
//        var keyword = $("#txtkeyword").val();
//        var typeid = $("#typeid").val();
//        var brandid = $("#brandid").val();
//        var showstyle = $("#sltshowstyle").val();
//        var price = $("#sltpricerange").val();
//        var loginname = $("#shopuserloginname").val();
//        var cssspjg = $("#spanjg")[0].className;
//        var cssspxl = $("#spanxl")[0].className;
//        var sltnew = $("#sltnew").val();

//        var url = config.WebURL + "shop/" + loginname + "/offer";

//        //关键字
//        url += "-";
//        if (keyword != "") {
//            url += keyword;
//        }
//        //分类编号
//        url += "-";
//        if (typeid > 0) {
//            url += typeid;
//        }
//        //品牌编号
//        url += "-";
//        if (brandid > 0) {
//            url += brandid;
//        }
//        //排序方式
//        url += "-";
//        //        var orderby = sltnew;
//        //        if (cssspjg == "") {
//        //            orderby += ";SD_Price:0"
//        //        } else {
//        //            orderby += ";SD_Price:1"
//        //        }
//        //        if (cssspxl == "") {
//        //            orderby += ";SalesVolume:0"
//        //        }
//        //        else {
//        //            orderby += ";SalesVolume:1"
//        //        }
//        //        url += orderby;
//        //显示方式
//        url += "-";
//        if (showstyle != "0") {
//            url += 1;
//        }
//        //价格上限
//        url += "-";
//        if (price > 0) {
//            url += price;
//        }
//        //分页1
//        url += "-";
//        url += ".";
//        url += config.Suffix;
//        window.location = url;
//    });
//});

function VentureSearch() {
    var Pageindex = $("#pageindex").val();
    var TradeId = $("#tradeid").val();
    var AreaId = $("#areaid").val();
    var TypeId = $("#hiVentureType").val();
    var loginname = $("#shopuserloginname").val();

    var url = config.WebURL + "shop/" + loginname + "/venturelist";

    //分页
    url += "-";
    if (Pageindex != "") {
        url += Pageindex;
    }
    //行业
    url += "-";
    if (TradeId > 0) {
        url += TradeId;
    }
    //地区
    url += "-";
    if (AreaId > 0) {
        url += AreaId;
    }
    //融资类型
    url += "-";
    if (TypeId > 0) {
        url += TypeId;
    }

    url += ".";
    url += config.Suffix;
    window.location = url;
}
