function field(objName, divtop, divfield, cbisfull, hdddelids) {
    var index = 0;
    var divtopobj = $(divtop);
    var divfieldobj = $(divfield);
    var cbisfullobj = $(cbisfull);
    var hdddelidsobj = $(hdddelids);
    var istop = false; //�Ƿ��Ƕ�����
    this.topfieldarr = []; //��������ֶ�
    this.fieldarr = []; //��������ֶ�
    this.inheritfield = []; //�̳е��ֶ�
    this.topfield_ul = [];

    this.Init = function (fieldarr, topobj) {
        istop = topobj.istop;
        //������е��ֶ���Ϣ
        this.fieldarr = fieldarr;
        for (var i = 0; i < this.fieldarr.length; i++) {
            this.AddLine(divfieldobj, this.fieldarr[i]);
        }

        //���Ϊ���������˳�
        if (topobj.istop) return;
        if (undefined == this.inheritfield) this.inheritfield = [];

        for (var i = 0; i < this.topfield_ul.length; i++) {
            $("txtEName" + this.topfield_ul[i]).disabled = true;
            $("txtCName" + this.topfield_ul[i]).disabled = true;
            $("txtdesp" + this.topfield_ul[i]).disabled = true;
            $("txtSelect" + this.topfield_ul[i]).disabled = true;
            $("seltype" + this.topfield_ul[i]).disabled = true;
            $("txtFieldSize" + this.topfield_ul[i]).disabled = true;

            if (!topobj.inherit.isinherit && undefined == topobj.inherit.fieldarr) {
                $("cbIsFull").checked = true;
                $("topid" + this.topfield_ul[i]).checked = true;
                $("topid" + this.topfield_ul[i]).disabled = true;
            }
            else if (this.IsInherit($F("topid" + this.topfield_ul[i]))) {
                $("topid" + this.topfield_ul[i]).checked = true;
            }
            else {
                $("ul" + this.topfield_ul[i]).style.display = "none";
            }
        }
    }

    this.IsInherit = function (id) {
        for (var i = 0; i < this.inheritfield.length; i++) {
            if (parseInt(id) == parseInt(this.inheritfield[i])) {
                return true;
            }
        }
        return false;
    }

    this.ShowTopAll = function () {
        for (var i = 0; i < this.topfield_ul.length; i++) {
            $("ul" + this.topfield_ul[i]).style.display = "block";
        }
    }

    this.SelectTopAll = function () {
        this.ShowTopAll();
        for (var i = 0; i < this.topfield_ul.length; i++) {
            $("topid" + this.topfield_ul[i]).checked = cbisfullobj.checked;
            $("topid" + this.topfield_ul[i]).disabled = cbisfullobj.checked;
        }
    }

    this.Check = function () {
        var msg = "";
        var inputfieldarr = divfieldobj.getElementsByTagName("input");
        for (var i = 0; i < inputfieldarr.length; i++) {
            if (inputfieldarr[i].id.indexOf("txtEName") > 0) {
                for (var j = 0; j < this.topfield_ul.length; j++) {
                    if (cbisfullobj.checked || $("topid" + this.topfield_ul[j]).checked) {
                        if (inputfieldarr[i].value == $("txtEName" + this.topfield_ul[j]).value) {
                            msg += "�ֶ�" + inputfieldarr[i].value + "�ѱ�����̳У��޷���Ӹ��ֶ�<br />";
                        }
                    }
                }
            }
        }
        if (msg != "") {
            sAlert(msg);
            return false;
        }
        return true;
    }

    this.AddNewLine = function () {
        var newobj = { id: '', ename: '', cname: '', desp: '', defaultvalue: '', inputmode: '', initvalue: '' };
        this.AddLine(divfieldobj, newobj);
    }

    this.AddLine = function (docobj, fieldobj, istop) {
        insertHtml("beforeend", docobj, this.GetHtml(fieldobj, istop));
    }

    this.Delete = function (objindex) {
        if ("" == $F("id" + objindex)) {
            if (confirm("ȷ��ɾ����")) {
                this.DeleteHtmlObj(objindex);
            }
        }
        else if (istop) {
            var msg = '�����Ƕ����࣬��������Ѿ��̳и��࣬����Ҫ�Ĳ����ǣ�<br />';
            msg += '<a href="javascript:' + objName + '.DeleteChild(1,' + objindex + ');">ɾ�������Լ����̳е�����</a> ';
            msg += '<a href="javascript:' + objName + '.DeleteChild(2,' + objindex + ');">���Ƹ����ֶε����ಢɾ��</a> ';
            msg += '<a href="javascript:sClose();">ȡ������</a>';
            sAlert(msg);
        }
        else {
            if (confirm("ȷ��ɾ����")) {
                this.DeleteChild(0, objindex);
            }
        }
    }

    this.DeleteChild = function (actype, objindex) {
        this.AddDelID(actype, $F("id" + objindex));
        this.DeleteHtmlObj(objindex);
        sClose();
    }

    this.DeleteHtmlObj = function (objindex) {
        if ($("ul" + objindex)) {
            divfieldobj.removeChild($("ul" + objindex));
        }
    }
    //actype 0��ʾֱ��ɾ�������������Ч�������������� 1ɾ���̳е��������� 2���Ƹ��������� Ȼ��ɾ��
    this.AddDelID = function (actype, id) {
        hdddelidsobj.value += "" == hdddelidsobj.value ? "" : ",";
        hdddelidsobj.value += id;
    }

    this.GetHtml = function (obj, istop) {
        var str = '<ul id="ul' + index + '">';
        if (undefined == istop) {
            str += '<li class="fieldlistid"><input type="hidden" id="id' + index + '" name="id" value="' + obj.id + '" /></li>';
        }
        else {
            this.topfield_ul[this.topfield_ul.length] = index;
            str += '<li class="fieldlistid"><input type="checkbox" id="topid' + index + '" name="topid" value="' + obj.id + '" /></li>';
        }
        str += '<li><input  size="16"  id="txtEName' + index + '" ' + (istop ? '' : 'name="txtEName" ') + ' type="text" value="' + obj.ename + '" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emEName' + index + '" style="display:none;">���ֶ�Ӣ����</em></li>';
        str += '<li><input  size="16"  id="txtCName' + index + '" ' + (istop ? '' : 'name="txtCName" ') + ' type="text" value="' + obj.cname + '" onblur="unfocusalt(this);" onfocus="focusalt(this);"  /><em id="emCName' + index + '" style="display:none;">���ֶ�������</em></li>';
        str += '<li><textarea id="txtdesp' + index + '" ' + (istop ? '' : 'name="txtdesp" ') + ' cols="19" rows="1" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" >' + obj.desp + '</textarea><em id="emdesp' + index + '" style="display:none;">���ֶ�˵������</em></li>';
        str += '<li>' + this.GetType(obj.inputmode, istop) + '</li>';
        str += '<li><textarea id="txtdefault' + index + '" ' + (istop ? '' : 'name="txtdefault"') + ' cols="19" rows="1" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" >' + obj.defaultvalue + '</textarea><em id="emdefault' + index + '" style="display:none;">���ֶ�Ĭ��ֵ</em></li>';
        str += '<li><textarea id="txtinitvalue' + index + '" ' + (istop ? '' : 'name="txtinitvalue"') + ' cols="19" rows="1" onblur="taunfocusalt(this);" onfocus="tafocusalt(this);" >' + obj.initvalue + '</textarea><em id="eminitvalue' + index + '" style="display:none;">���ֶγ�ʼѡ��ֵ����ѡ���˷�Ϊ������Ч��</em></li>';
        if (undefined == istop) {
            str += '<li><a href="javascript:' + objName + '.Delete(' + index + ');"><img src="../images/fielddel.gif" alt="ɾ��"/></a></li>';
        }
        str += "</ul>";
        index++;
        return str;
    }


    this.GetType = function (value, istop) {
        value = value.toLowerCase();
        var str = '<select id="seltype' + index + '" ' + (istop ? '' : 'name="seltype"') + '>';
        str += '<option value="text_text"' + ('text_text' == value ? ' selected="selected"' : '') + '>�����ı���</option>';
        str += '<option value="textarea_text"' + ('textarea_text' == value ? ' selected="selected"' : '') + '>�����ı���</option>';
        str += '<option value="radio_select"' + ('radio_select' == value ? ' selected="selected"' : '') + '>������</option>';
        str += '<option value="radio_radio"' + ('radio_radio' == value ? ' selected="selected"' : '') + '>��ѡ��ť</option>';
        str += '<option value="radio_singlelist"' + ('radio_singlelist' == value ? ' selected="selected"' : '') + '>���б�</option>';
        str += '<option value="checkbox_checkbox"' + ('checkbox_checkbox' == value ? ' selected="selected"' : '') + '>��ѡ��</option>';
        str += '<option value="checkbox_multiplelist"' + ('checkbox_multiplelist' == value ? ' selected="selected"' : '') + '>��ѡ�б�</option>';
        return str;
    }
}
