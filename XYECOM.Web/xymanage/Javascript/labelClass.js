function LabelClassDisplay(objID,objli)
{
    var obj = $(objID);
    if("none" == obj.style.display)
    {
        $(objli).getElementsByTagName("img")[0].src="../images/bg_spread.gif";
        obj.style.display = "block";
    }
    else
    {
        $(objli).getElementsByTagName("img")[0].src="../images/bg_shrink.gif";
        obj.style.display = "none";
    }
}

function expran(ename,fullid)
{    
    if(fullid.indexOf(",")!=-1)
    {
        fullid = fullid.substr(1);
    }
    var ids = fullid.split(",");
    LabelClassDisplay2(ename,ids.shift(),"",ids);
}

function LabelClassDisplay2(moduleName,infoid,split,ids)
{
    if(infoid!="" && infoid!="0")
    {
        var obj = $("li_" + infoid);
        if(obj != null && "none" == obj.style.display)
        {
            $("lithis" + infoid).getElementsByTagName("img")[0].src="../images/bg_spread.gif";
            obj.style.display = "block";
            var ul = obj.getElementsByTagName("ul")[0];                
            ul.innerHTML = "<li>正在加载……</li>";
            //ajax 调用
            var ajax = new Ajax("xy082","&moduleName=" + moduleName + "&infoid=" + infoid);
            ajax.onSuccess = function() 
            {
                if(ajax.state.result == 1)
                {
                    ul.innerHTML = "";
                    if(null != ajax.data)
                    {
                        for(i=0;i<ajax.data.Item.length;i++){
                            var id = ajax.data.Item[i].ID;
                            var hasSub = ajax.data.Item[i].HasSub;
                            var typeName = unescape(ajax.data.Item[i].Name);
                            var lithis = document.createElement("li");
                            lithis.id="lithis"+id;
                            
                            var split2=split+"&nbsp;&nbsp;&nbsp;&nbsp;";
                            
                            var html = split2;
                            
                            if(hasSub == "true")
                            {
                                html += "<a href=\"javascript:LabelClassDisplay2('";html += moduleName;html += "',";html += id;html += ",'";
                                html += split2;html += "');\">";html += "<img src=\"../images/bg_shrink.gif\" />";html += "</a>";
                            }else
                            {
                                html += "<img src=\"../images/bg_spread.gif\" />";
                            }
                            
                            if(moduleName == "area" || moduleName == "Area")
                            {
                                if(hasSub=="true")
                                {
                                    html+="<img src=\"../images/folders.gif\" /> ";
                                    html+=typeName;
                                    html+="<img src=\"../images/arrow_black.gif\" />";
                                    html+="[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + id + "\" >添加</a>&nbsp;]";
                                    html+="[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + id + "&ID=" + id + "\" >编辑</a>&nbsp;]";
                                }
                                else
                                {
                                    html+="<img src=\"../images/folder.gif\" />";
                                    html+=typeName;
                                    html+="<img src=\"../images/arrow_black.gif\" />";
                                    html+="[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + id + "\" >添加</a>&nbsp;]";
                                    html+=" [&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + id + "&ID=" + id + "\" >编辑</a>&nbsp;]";
                                    html+="[&nbsp;<a onclick=\"javascript:return confirm('确定删除？')\" href=\"AreaList.aspx?delID=" + id + "\" >删除</a>&nbsp;]";
                                }
                            }
                            else if (moduleName == "offer")
                            {
                                if(hasSub=="true")
                                {
                                    html += "<input id=\"input_";html += infoid;html += "_";html += id;html += "\"type=\"checkbox\" value=\"";html += id;
                                    html += "\" disabled/>";html += "<img src=\"../images/folders.gif\" />";html += "";html += typeName;html += "";html += "<img src=\"../images/arrow_black.gif\" />";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&upid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↑&nbsp;]</a>&nbsp;";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&downid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↓&nbsp;]</a>&nbsp;";
                                    
                                    html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=0&ename=";html += moduleName;html += "&PT_ID=";
                                    html += id;html += "\">添加</a>&nbsp;]";html += " [&nbsp;<a href=\"ProductTypeAdd.aspx?type=1&ename=";html += moduleName;html += "&PT_ID=";
                                    html += id;html += "\">编辑</a>&nbsp;]";html += " [&nbsp;<a href=\"ProductMove.aspx?ename=";html += moduleName;
                                    html += "&PT_ParentID="; html += id; html += "\">移动</a>&nbsp;]";
                                    html += "[&nbsp;<a href=\"/xymanage/BrandManage/BandBrand.aspx?id=";
                                    html += id; html += "\">品牌管理</a>&nbsp;]";
                                    html += "[&nbsp;<a href=\"BandUnits.aspx?id=";
                                    html += id; html += "\">计量单位管理</a>&nbsp;]";
                                }
                                else
                                {
                                    html += "<input id=\"input_";html += infoid;html += "_";html += id;html += "\" type=\"checkbox\" value=\"";html += id;
                                    html += "\" />";html += "<img src=\"../images/folder.gif\" />";html += "";html += typeName;html += "";html += "<img src=\"../images/arrow_black.gif\" />";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&upid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↑&nbsp;]</a>&nbsp;";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&downid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↓&nbsp;]</a>&nbsp;";
                                    
                                    html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=0&ename=";
                                    html += moduleName;html += "&PT_ID=";html += id;html += "\">添加</a>&nbsp;]";html += "[&nbsp;<a href=\"ProductTypeAdd.aspx?type=1&ename=";html += moduleName;
                                    html += "&PT_ID=";html += id;html += "\">编辑</a>&nbsp;]";html += "[&nbsp;<a href=\"ProductMove.aspx?ename=";html += moduleName;
                                    html += "&PT_ParentID="; html += id; html += "\">移动</a>&nbsp;]";
                                    html += "[&nbsp;<a href=\"/xymanage/BrandManage/BandBrand.aspx?id=";
                                    html += id; html += "\">品牌管理</a>&nbsp;]";
                                    html += "[&nbsp;<a href=\"BandUnits.aspx?id=";
                                    html += id; html += "\">计量单位管理</a>&nbsp;]";
                                    html += "[&nbsp;<a style=\"cursor:hand;\" onclick=\"javascript:delType('";
                                    html += moduleName;html += "',";html += id;html += ",";html += infoid;html += ")\">删除</a>&nbsp;]";
                                }                            
                            
                            }
                            else
                            {
                                if (hasSub=="true")
                                {
                                    html += "<input id=\"input_";html += infoid;html += "_";html += id;html += "\" type=\"checkbox\" value=\"";
                                    html += id;html += "\" disabled/>";html += "<img src=\"../images/folders.gif\" />";html += " ";
                                    html += typeName;html += "<img src=\"../images/arrow_black.gif\" />";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&upid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↑&nbsp;]</a>&nbsp;";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&downid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↓&nbsp;]</a>&nbsp;";
                                    
                                    html += "[&nbsp;<a href=\"TypeAdd.aspx?type=0&ename=";html += moduleName;
                                    html += "&PT_ID=";html += id;html += "\">添加</a>&nbsp;]";html += "[&nbsp;<a href=\"TypeAdd.aspx?type=1&ename=";
                                    html += moduleName;html += "&PT_ID=";html += id;html += "\">编辑</a>&nbsp;]";
                                    html += "[&nbsp;<a href=\"ProductMove.aspx?ename=";
                                    html += moduleName;html += "&PT_ParentID=";html += id;html += "\">移动</a>&nbsp;]";
                                }
                                else
                                {
                                    html += "<input id=\"input_";html += infoid;html += "_";html += id;html += "\" type=\"checkbox\" value=\"";
                                    html += id;html += "\" />";html += "<img src=\"../images/folder.gif\" />";html += " ";
                                    html += typeName;html += "<img src=\"../images/arrow_black.gif\" />";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&upid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↑&nbsp;]</a>&nbsp;";
                                    
                                    html += "&nbsp;<a href=\"Typelist.aspx?ename=";
                                    html += moduleName;
                                    html += "&downid=";
                                    html += id;
                                    html += "&orderid=";                                
                                    html += infoid;
                                    html += "\" >[&nbsp;↓&nbsp;]</a>&nbsp;";
                                    
                                    html += "[&nbsp;<a href=\"TypeAdd.aspx?type=0&ename=";html += moduleName;
                                    html += "&PT_ID=";html += id;html += "\">添加</a>&nbsp;]";html += "[&nbsp;<a href=\"TypeAdd.aspx?type=1&ename=";
                                    html += moduleName;html += "&PT_ID=";html += id;html += "\">编辑</a>&nbsp;]";
                                    html += "[&nbsp;<a href=\"ProductMove.aspx?ename=";html += moduleName;html += "&PT_ParentID=";
                                    html += id;html += "\">移动</a>&nbsp;]";
                                    html += "[&nbsp;<a style=\"cursor:hand;\" onclick=\"javascript:delType('";
                                    html += moduleName;html += "',";html += id;html += ",";html += infoid;html += ")\">删除</a>&nbsp;]";
                                }            
                            }
                            
                            if ("exhibition" != moduleName && "brand" != moduleName && "job" != moduleName && "area"!=moduleName && "Area"!=moduleName)
                            {
                                html += "[&nbsp;<a  href=\"Field.aspx?ModuleName=";                            
                                html += moduleName;
                                html += "&TypeID=";
                                html += id;
                                html += "\">自定义字段管理</a>&nbsp;]";
                            }
                            
                            lithis.innerHTML = html;
                            ul.appendChild(lithis);
                            
                            if(hasSub == "true")
                            {
                                var li_ = document.createElement("li");
                                li_.id="li_"+ajax.data.Item[i].ID;
                                li_.style.display = "none";
                                li_.innerHTML = "<ul/>";
                                ul.appendChild(li_);
                            }
                        }
                        if(!(ids == undefined || ids==null || ids.length < 1))
                        { 
                            id = ids.shift();
                            if(id!="" && id!=0)
                            {   
                                LabelClassDisplay2(moduleName,id,split2,ids);
                                split2+="&nbsp;&nbsp;&nbsp;&nbsp;";
                            }
                        }
                    }
                }
                else 
                {
                    sAlert(ajax.state.message);
                }
            }        
        }
        else
        {
            $("lithis" + infoid).getElementsByTagName("img")[0].src="../images/bg_shrink.gif";
            obj.style.display = "none";
        }
    }
}

function SetLabelClass2(objid)
{    
    var arr = $("class2").getElementsByTagName("div");
    for(var i=0;i<arr.length;i++)
    {
        if(arr[i].id == "classitem" + objid){
            var inputarr = arr[i].getElementsByTagName("input");
            var cc = false;
            for (var i=0;i<inputarr.length;i++)
            {
                if(0 == i)
                    cc = inputarr[i].checked;
                if(cc)
                    inputarr[i].checked = false;
                else
                    inputarr[i].checked = true;
            }
            return;    
        }            
    }
    var inputarrcls1 = $("pnlSuperClass").getElementsByTagName("input");
    for (var i=0;i<inputarrcls1.length;i++)	{
		if(inputarrcls1[i].id == "input_0_" + objid)
		    inputarrcls1[i].checked = true;
	}
    
    var tmpdiv = document.createElement("div");
    tmpdiv.id = "classitem" + objid;    
    tmpdiv.className = "class2item";
    var html = "<ul>"
    var obj = $("li_" + objid);
    var inputarr = obj.getElementsByTagName("input");
    
    for (var i=0;i<inputarr.length;i++)
	{
		if(inputarr[i].id.indexOf("input_" + objid + "_")!=-1)
		{
		    if(inputarr[i].type=='checkbox')
                html += "<li><input id=\"input2_" + inputarr[i].value.split("|")[0] + "\" checked=\"checked\" type=\"checkbox\" value=\"" + inputarr[i].value + "\" />" + unescape(inputarr[i].value.split("|")[1]) + "</li>";
	    }
	}
	
	html += "</ul>"
	tmpdiv.innerHTML = html;	
	$("class2").appendChild(tmpdiv);
}
function LabelClassAssembled() {
    var obj1 = GetClassValue("pnlSuperClass");
    if(obj1.id == "") {
        sAlert("请选择一级分类！");
        return;
    }
    var obj2 = GetClassValue("class2");
    var html = "<div><input type=\"text\" readonly=\"true\" value=\"" + unescape(obj1.name) + "\" maxlength=\"100\" size=\"80\" /><br/><textarea rows=\"4\" cols=\"100\" readonly=\"true\">" + unescape(obj2.name) + "</textarea><br/><br/></div>";
    $("tdComClass").innerHTML += html;
    $("hddValue").value += "" == $("hddValue").value ? "" : "$"
    $("hddValue").value += obj1.value + "#" + obj2.value;
    LabelClassClearCls2();
}
function LabelClassClear() {
    LabelClassClearCls2();
    $("hddValue").value = "";
    $("tdComClass").innerHTML = "";
}
function LabelClassClearCls2(){
    var arr = $("pnlSuperClass").getElementsByTagName("input");
    for(var i=0;i<arr.length;i++) {
        if(arr[i].type=='checkbox') {
            if(arr[i].checked) {
                arr[i].checked = false;
            }
        }
    }
    var arrdiv = $("class2").getElementsByTagName("div");
    for(var i=0;i<arrdiv.length;) {
        $("class2").removeChild(arrdiv[i]);
    }
}

function GetClassValue(strDivID) {
    var arr = $(strDivID).getElementsByTagName("input");    
    var strid = "";
    var strname = "";
    var strvalue = "";
    for(var i=0;i<arr.length;i++) {
        if(arr[i].type=='checkbox') {
            if(arr[i].checked) {
                strid += "" == strid ? "" : ",";
                strid += arr[i].value.split("|")[0];
                strname += "" == strname ? "" : " ";
                strname += arr[i].value.split("|")[1].trim();
                strvalue += "" == strvalue ? "" : ",";
                strvalue += arr[i].value;
            }
        }
    }
    return {
        id:strid,
        name:strname,
        value:strvalue
    }
}


/*******************************************************************/




function delall(){
    var arrs = $("pnlSuperClass").getElementsByTagName("input"); 
    var str = "";
    var num = 0;
    for(var i=0;i<arrs.length;i++){
        if(arrs[i].type == 'checkbox'){
            if(arrs[i].checked){
                str += arrs[i].value + ",";
                num =1;
            }
        }
    }
    if(num == 0){
        alert("请选择要删除的分类！");
        return false;
    }
    $("strdel").value = str;
}

function createordelete(tip,whichone){
  var arrs = $("pnlSuperClass").getElementsByTagName("input"); 
    var str = "";
    var num = 0;
    for(var i=0;i<arrs.length;i++){
        if(arrs[i].type == 'checkbox'){
            if(arrs[i].checked){
                str += arrs[i].value + ",";
                num =1;
            }
        }
    }
    if(num == 0){
        alert(tip);
        return false;
    }
    $("strids").value = str;
    $("cod").value = whichone;
}



//add by liujia 2008-11-18 地区标签的信息页
function ShowToPage(obj) {
    if("job" == obj.value) {
        $("rblToPage").style.display = "none";
    }
    else {
        $("rblToPage").style.display = "block";
    }
}

function delType(moduleName,infoid,parmentId){    
    if(moduleName==""){
        moduleName = "offer";
    }
    if(infoid < 1) {
        sAlert("非法参数！");
        return;
    }
    
    var res = window.confirm("确定删除？");
    
    if(!res) return false;
    
    var ajax = new Ajax("xy080","&moduleName=" + moduleName + "&infoid=" + infoid + "&parmentId=" + parmentId);
    ajax.onSuccess = function() {
        if(ajax.state.result == 1) {
            var li = $("lithis"+infoid);
            var par = li.parentElement;
            par.removeChild(li);
            sAlert(ajax.state.message);
        }
        else {
            sAlert(ajax.state.message);
        }
    }
}