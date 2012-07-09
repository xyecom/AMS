function CredSearch() {
    var sellerId = document.getElementById("sellerId").value;
    var pageSize = document.getElementById("pageSize").value;
    var pageIndex = document.getElementById("pageIndex").value;
    var strwhere = document.getElementById("selectCred").value;
    if (pageIndex < 1) {
        pageIndex = 1;
    }

    if (sellerId != '0') {
        var ajax2 = new Ajax("XY202", "&uid=" + sellerId + "&pageSize=" + pageSize + "&pageIndex=" + pageIndex + "&where=" + strwhere);
        ajax2.onSuccess = function () {
            if (ajax2.state.result == 1) {
                if (null != ajax2.data) {

                    var fieldItems = ajax2.data.Evaluations;
                    document.getElementById("pageCount").value = fieldItems[0].PageCount;
                   // document.getElementById("pagecounts").innerHTML = fieldItems[0].PageCount;
                    var html = "";
                    for (var i = 0; i < fieldItems.length; i++) {
                        html += "<div style=\"float: left;\">";
                        html += fieldItems[i].Avgpoint;
                        html += fieldItems[i].Evaluation;
                        html += "<br />";
                        html += fieldItems[i].Evaluationtime;
                        html += "</div>";

                        html += "<div style=\"float: left;\">";
                        html += "买家：";
                        html += fieldItems[i].buyerLoginName;
                        html += "<br />";
                        html += fieldItems[i].CreditIntegral;
                        html += "</div>";

                        html += "<div style=\"float: left;\">";
                        html += fieldItems[i].OrderId;
                        html += "</div>";
                        html += "<div style=\" clear: both;\"></div>"
                    }
                    document.getElementById("credList").innerHTML = html;
                } else {
                    document.getElementById("credList").innerHTML = "";
                }
            }
        }
    }
}

function changPage(state) {
    var count = parseInt(document.getElementById("pageCount").value);
    var pageIndex = parseInt(document.getElementById("pageIndex").value);
    if (pageIndex == NaN) {
        pageIndex = 1;
    }
    if (state == "top") {
        document.getElementById("pageIndex").value = "1";
    } else if (state == "end") {
        document.getElementById("pageIndex").value = pageCount;
    }
    else if (state == "up" && pageIndex > 1) {
        document.getElementById("pageIndex").value = pageIndex - 1;
    }
    else if (state == "dw" && pageIndex < count) {
        document.getElementById("pageIndex").value = pageIndex + 1;
    }
    else if (state == "") {
        document.getElementById("pageIndex").value = 1;
    }
    CredSearch();
}
//下拉框chang事件
function SelectChang(obj) {
    var value = obj.value;
    changPage('');
}