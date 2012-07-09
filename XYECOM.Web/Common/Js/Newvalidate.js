
function delType(moduleName, infoid, parmentId) {
    if (moduleName == "") {
        moduleName = "offer";
    }
    if (infoid < 1) {
        sAlert("非法参数！");
        return;
    }

    var res = window.confirm("确定删除？");

    if (!res) return false;

    var ajax = new Ajax("xy080", "&moduleName=" + moduleName + "&infoid=" + infoid + "&parmentId=" + parmentId);
    ajax.onSuccess = function () {
        if (ajax.state.result == 1) {
            var li = $("#lithis" + infoid)[0];
            var par = li.parentElement;
            par.removeChild(li);
            sAlert(ajax.state.message);
        }
        else {
            sAlert(ajax.state.message);
        }
    }
}

function delall(objectName) {
    var arrs = document.getElementById("pnlSuperClass").getElementsByTagName("input");
    var str = "";
    var num = 0;
    for (var i = 0; i < arrs.length; i++) {
        if (arrs[i].type == 'checkbox') {
            if (arrs[i].checked) {
                str += arrs[i].value + ",";
                num = 1;
            }
        }
    }
    if (num == 0) {
        alert("请选择要删除的分类！");
        return false;
    }
    $("#"+objectName)[0].value = str;
}
function LabelClassDisplay2(moduleName, infoid, split, ids) {
    if (infoid != "" && infoid != "0") {
        var obj = $("#li_" + infoid)[0];
        if (obj != null && "none" == obj.style.display) {
            $("#lithis" + infoid)[0].getElementsByTagName("img")[0].src = "/xymanage/images/bg_spread.gif";
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

                            if (hasSub == "true") {
                                html += "<a href=\"javascript:LabelClassDisplay2('"; html += moduleName; html += "',"; html += id; html += ",'";
                                html += split2; html += "');\">"; html += "<img src=\"/xymanage/images/bg_shrink.gif\" />"; html += "</a>";
                            } else {
                                html += "<img src=\"/xymanage/images/bg_spread.gif\" />";
                            }

                            if (hasSub == "true") {
                                html += "<input id=\"input_"; html += infoid; html += "_"; html += id; html += "\" type=\"checkbox\" value=\"";
                                html += id; html += "\" disabled/>"; html += "<img src=\"/xymanage/images/folders.gif\" />"; html += " ";
                                html += typeName; html += "<img src=\"/xymanage/images/arrow_black.gif\" />";

                                html += "&nbsp;<a href=\"SupplyTypeList.aspx?ename=";
                                html += moduleName;
                                html += "&upid=";
                                html += id;
                                html += "&orderid=";
                                html += infoid;
                                html += "\" >[&nbsp;↑&nbsp;]</a>&nbsp;";

                                html += "&nbsp;<a href=\"SupplyTypeList.aspx?ename=";
                                html += moduleName;
                                html += "&downid=";
                                html += id;
                                html += "&orderid=";
                                html += infoid;
                                html += "\" >[&nbsp;↓&nbsp;]</a>&nbsp;";

                                html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=0&ename="; html += moduleName;
                                html += "&PT_ID="; html += id; html += "\">添加</a>&nbsp;]"; html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=1&ename=";
                                html += moduleName; html += "&PT_ID="; html += id; html += "\">编辑</a>&nbsp;]";

                            }
                            else {
                                html += "<input id=\"input_"; html += infoid; html += "_"; html += id; html += "\" type=\"checkbox\" value=\"";
                                html += id; html += "\" />"; html += "<img src=\"/xymanage/images/folder.gif\" />"; html += " ";
                                html += typeName; html += "<img src=\"/xymanage/images/arrow_black.gif\" />";

                                html += "&nbsp;<a href=\"SupplyTypeList.aspx?ename=";
                                html += moduleName;
                                html += "&upid=";
                                html += id;
                                html += "&orderid=";
                                html += infoid;
                                html += "\" >[&nbsp;↑&nbsp;]</a>&nbsp;";

                                html += "&nbsp;<a href=\"SupplyTypeList.aspx?ename=";
                                html += moduleName;
                                html += "&downid=";
                                html += id;
                                html += "&orderid=";
                                html += infoid;
                                html += "\" >[&nbsp;↓&nbsp;]</a>&nbsp;";

                                html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=0&ename="; html += moduleName;
                                html += "&PT_ID="; html += id; html += "\">添加</a>&nbsp;]"; html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=1&ename=";
                                html += moduleName; html += "&PT_ID="; html += id; html += "\">编辑</a>&nbsp;]";

                                html += "[&nbsp;<a style=\"cursor:hand;\" onclick=\"javascript:delType('";
                                html += moduleName; html += "',"; html += id; html += ","; html += infoid; html += ")\">删除</a>&nbsp;]";
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
                else {
                    sAlert(ajax.state.message);
                }
            }
        }
        else {
            $("#lithis" + infoid)[0].getElementsByTagName("img")[0].src = "/xymanage/images/bg_shrink.gif";
            obj.style.display = "none";
        }
    }
}