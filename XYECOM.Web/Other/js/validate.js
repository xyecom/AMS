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
