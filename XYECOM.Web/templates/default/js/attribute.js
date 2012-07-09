function AttributeSearch() {
    var typeId = document.getElementById("hidProductTypeId").value;
    var typeidAndAttribute = document.getElementById("hidProductTypeIdAndAttribute").value;

    if (typeId != '0') {
        var ajax2 = new Ajax("XY201", "&pt_id=" + typeId + "&url=" + escape(document.location.href) + "&curTypeId=" + typeidAndAttribute);
        ajax2.onSuccess = function () {
            if (ajax2.state.result == 1) {
                if (null != ajax2.data) {
                    //temp 一个属性的可选值，如属性颜色的可选值为 红,10.1/绿,10.2/蓝,10.3|红色,11.1/绿色,11.2/蓝色,11.3
                    var fieldItems = ajax2.data.FieldItem;

                    var html = "";
                    for (var i = 0; i < fieldItems.length; i++) {
                        html += "<div>" + fieldItems[i].FieldName + "</div>";
                        var subFields = fieldItems[i].SubFields;
                        for (var j = 0; j < subFields.length; j++) {
                            var tmpId = fieldItems[i].FieldId + "." + subFields[j].FieldIndex;
                            html += "<a href='";
                            html += unescape(subFields[j].FieldUrl);
                            html += "'";
                            if (typeidAndAttribute.indexOf(tmpId) != -1) {
                                html += " class=\"ProInfoTitleA\"";
                            }
                            html += ">" + subFields[j].SubFieldName + "</a>";
                        }
                    }

                    document.getElementById("xy_fleldList").innerHTML = html;
                }
            }
        }
    }
}