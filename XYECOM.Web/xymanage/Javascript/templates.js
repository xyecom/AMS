// JScript 文件
//切换模板和其他文件
function isaspx(num)
{
    var arr1 = new Array("defaultlist","newslist","areasitelist","csslist");
                        
    var arr2 = new Array("default","news","areasite","css");
                        
    var arr3 = new Array("","news", "area", "css");
                        
    for(i=0;i<arr1.length;i++)
    {
        $(arr1[i]).style.display = "none";
        $(arr2[i]).className = "";
    }
    $(arr1[num - 1]).style.display = "block";
    $(arr2[num-1]).className = "current";
    $("hidpathname").value = arr3[num-1];
}

//全选
function templatescheckall()
{
    var chkall = document.getElementById("chkallaspx");

    var chkother;

    if(document.getElementById("hidpathname").value !="")
        chkother= document.getElementsByName($F("hidpathname"));
    else
        chkother= document.getElementsByName("default");
        
	for (var i=0;i<chkother.length;i++)
	{
	    if(chkother[i].disabled == true)continue;

		chkother[i].checked=chkall.checked;
	}
}


function CancelChecked()
{
    var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
		    if(chkother[i].id.indexOf('chkaspx')>-1)
		    { 
			    if(chkother[i].checked==true)
			    {
                    chkother[i].checked = false;
				}
		    }
		}
	}
}

//按模板生成页面
function createhtml()
{
    if($F("hidpathname") == "css") {
        sAlert("css不用生成!");
        return;
    }
    var tempnames = "";
    var j = 0;
    var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
		    if(chkother[i].id.indexOf('chkaspx')>-1)
		    { 
			    if(chkother[i].checked==true)
			    {
				    j++;
				    if(j==1)
				        tempnames += chkother[i].value;
				    else
				        tempnames += "," + chkother[i].value;
				}
		    }
		}
	}
	
	if(j==0)
	{
	    sAlert("必须选择一个模板才能生成相对应的页面!");
	    return false;
	}
	else
	{
	    alertnotbut("<img src=\"../images/ajax-loader.gif\" /><br>正在生成模版文件...",false);
	    
		createtemps(tempnames,document.getElementById("hidpath").value);
	}
}
function createAll(path)
{
     alertnotbut("<img src=\"../images/ajax-loader.gif\" /><br>正在生成模版文件...",false);
     
     createtemps("all|",path);
}

function createtemps(tempnames,path)
{
    var url = "AddTemplate.aspx?TempNames="+tempnames+"&path="+path
    if(document.getElementById("hidpathname")) url += "&pathName="+document.getElementById("hidpathname").value;
    
    var xmlDoc=new XMLHttpObject(url,true);
    xmlDoc.OnComplete = Complete;   
    xmlDoc.sendData(); 
}

function Complete(responseText, responseXML)
{
    if(responseText =="nologin")
    {
        window.parent.location.href='../outlogin.aspx';
    }
    else
    {
        alertmsg(responseText,"",true,"");
        if($("chkallaspx")) $("chkallaspx").checked = false;
        
        CancelChecked();
    }
}

//生成自定义模块模板
function createmobulehtml()
{
    var tempnames = "";
    var j = 0;
    var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
		    if(chkother[i].id.indexOf('chkaspx')>-1)
		    { 
			    if(chkother[i].checked==true)
			    {
				    j++;
				    if(j==1)
				        tempnames += chkother[i].value;
				    else
				        tempnames += "," + chkother[i].value;
				}
		    }
			
		}
	}
	
	if(j==0)
	{
	    sAlert("至少选择一个模板文件!");
	    return false;
	}
	else
	{
	    alertnotbut("<img src=\"../images/ajax-loader.gif\" /><br>正在生成模版文件...");
		createmobuletemps(tempnames,$F("hidT_ID"),$F("hidpath"));
	}
}

function createmobuletemps(tempnames,tid,path)
{
    var url = "AddTemplate.aspx?TempNames="+tempnames+"&tid="+tid+"&path="+path+"&pathName="+document.getElementById("hidpathname").value;
    
    if(document.getElementById("hidppathname").value != "")
        url += "&ppathname="+document.getElementById("hidppathname").value;

    var xmlDoc=new XMLHttpObject(url,true);
    xmlDoc.OnComplete = AboutComplete;   
    xmlDoc.sendData(); 
}

function AboutComplete(responseText, responseXML)
{
    if(responseText =="nologin")
    {
        window.parent.location.href='../outlogin.aspx';
    }
    else
    {
        alertmsg(responseText,$F("hidurl"));
        
        CancelChecked();
    }
}

//删除模板
function deletehtml()
{
    var tempnames = "";
    var j = 0;
    var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
	        if(chkother[i].id.indexOf('chkaspx')>-1)
		    {
			    if(chkother[i].checked==true)
			    {
			        j++;
				    if(j==1)
				        tempnames += chkother[i].value;
				    else
				        tempnames += "," + chkother[i].value;
				}
		    }
		}
	}
	if(j==0)
	{
	    sAlert("至少选择一个模板文件!");
	    return false;
	}
	else 
	{
	    alertnotbut("<img src=\"../images/ajax-loader.gif\" /><br>正在删除模版文件...");
		deletetemps(tempnames,$F("hidpath"));
	}
	
}
function deletetemps(tempnames,path)
{
    var url = "AddTemplate.aspx?TempNames="+tempnames+"&delete=1&path="+path;

    var xmlDoc=new XMLHttpObject(url,true);
    xmlDoc.OnComplete = DeleteComplete;   
    xmlDoc.sendData(); 
    
    $("showBox").style.display = "none";
}


function DeleteComplete(responseText, responseXML)
{
    if(responseText =="nologin")
    {
        window.parent.location.href='../outlogin.aspx';
    }
    else
    {
        sAlert(responseText,"list.aspx");
    }
}


function TemplatesEdit(url)
{
    var strset = "";
    var dWidth = 800;
    var dHeight = 450;    
	var scrollPos	= new getScrollPos();				
	var pageSize	= new getPageSize();
	
    $("Div_window").style.height=(pageSize.height + scrollPos.scrollY) + "px";
    $("Div_window").style.background="#000";
    $("Div_window").style.filter="alpha(opacity=30)";
    $("Div_window").style.opacity=0.9;
    $("Div_window").style.MozOpacity =1;
    $("Div_window").style.display = "block";
    
    $("window").src = "TemplatesEdit.aspx?path=" + url;
    $("window").style.width = dWidth + "px";
    $("window").style.display = "block";
    $("window").style.height = dHeight + "px";
	
	var x = Math.round(pageSize.width/2) - (dWidth /2) + scrollPos.scrollX;
	var y = 30;
	
	$("window").style.display = 'block';
	$("window").style.left	= x+'px';			
	$("window").style.top= y+'px';
}
function TemplatesClose()
{
    $("window").style.display = 'none';
    $("Div_window").style.display = "none";
    alertmsg('修改成功!','',false);
}

function ShopStyleSetting(folder)
{
    _ShopSetting(folder,"style");
}

function ShopTemplatesSetting(folder)
{
    _ShopSetting(folder,"");
}

function _ShopSetting(folder,type)
{
    var strset = "";
    var dWidth = 500;
    var dHeight = 300;    
	var scrollPos	= new getScrollPos();				
	var pageSize	= new getPageSize();
	
    $("Div_window").style.height=(pageSize.height + scrollPos.scrollY) + "px";
    $("Div_window").style.background="#000";
    $("Div_window").style.filter="alpha(opacity=30)";
    $("Div_window").style.opacity=0.9;
    $("Div_window").style.MozOpacity =1;
    $("Div_window").style.display = "block";
    
    $("window").src = "ShopTemplateSetting.aspx?folder=" + folder + "&type=" + type;
    $("window").style.width = dWidth + "px";
    $("window").style.display = "block";
    $("window").style.height = dHeight + "px";
	
	var x = Math.round(pageSize.width/2) - (dWidth /2) + scrollPos.scrollX;
	var y = 50;
	
	$("window").style.display = 'block';
	$("window").style.left	= x+'px';			
	$("window").style.top= y+'px';
}

function SelectUser(obj,toObj)
{
    var value = obj.options[obj.selectedIndex].value;
    
    var list = document.getElementById(toObj).value.trim();
     
    if(list==""){
        list = value;
    }else{
        var aryList = list.split(',');
        for(var i=0;i<aryList.length;i++){
            if(aryList[i]==value){
                alert("已在ID列表中！");
                obj.remove(obj.selectedIndex);
                return;
            }
        }
        list = list + "," + value;
        obj.remove(obj.selectedIndex);
    }
            
    document.getElementById(toObj).value = list;
}

function ShopAboutSettingClose()
{
    $("Div_window").style.display = "none";
    $("window").style.display = "none";
    alertmsg('设置成功!','',false);
}

function ShopAboutSettingCancel()
{
    parent.$("Div_window").style.display = "none";
    parent.$("window").style.display = "none";
}


var timeout;
function SetHtmlState(htmlList) {
    HtmlInit(htmlList);
    timeout = window.setInterval(function() {HtmlState(htmlList);},1000);
}

function HtmlState(htmlList) {
    var ajax = new Ajax("xy035","");

    ajax.onSuccess = function(){

        if(ajax.state.result ==0 || ajax.state.result ==-1) {
            window.clearInterval(timeout);
            if(htmlList.length > 0) {
                SetHtmlCode(htmlList,0,0,0);
                sAlert("全部处理完毕！","HtmlManage.aspx");
            }
        }
        else {
            SetHtmlCode(htmlList,ajax.data.HtmlIndex,ajax.data.HtmlCount,ajax.data.HtmlCurrent);
        }
    }
}

function HtmlInit(htmlList) {
    var htmlcode = "<table width=\"100%\">";    
    var htmlinfo;
    for(var i =0; i< htmlList.length;i++) {
        htmlinfo = htmlList[i];
        htmlcode += "<tr>";
        htmlcode += "<td width=\"300\">" + (htmlinfo.isdel ? "删除" : "生成") + htmlinfo.name + "</td><td width=\"230\">&nbsp;</td><td>等待中</td>"
        htmlcode += "</tr>";
    }
    htmlcode += "</table>";
    $("htmlstate").innerHTML = htmlcode;
}

function SetHtmlCode(htmlList,htmlindex,htmlcount,htmlcurrent) {
    var htmlcode = "<table width=\"100%\">";
    var tmp = false;
    
    var htmlinfo;
    for(var i =0; i< htmlList.length;i++) {
        htmlinfo = htmlList[i];
        htmlcode += "<tr>";
        if(htmlinfo.index == htmlindex) {
            tmp = true;
            htmlcode += "<td width=\"300\">" + "<b>" + (htmlinfo.isdel ? "删除" : "生成") + htmlinfo.name + "</b>" + "</td><td width=\"230\">" + takeState(htmlcount,htmlcurrent) + "</td><td><b>正在处理中...</b></td>"
        }
        else {
            if(tmp) {
                htmlcode += "<td width=\"300\">" + (htmlinfo.isdel ? "删除" : "生成") + htmlinfo.name + "</td><td width=\"230\">&nbsp;</td><td>等待中</td>"
            }
//            else {
//                htmlcode += "<td width=\"300\"><i>" + (htmlinfo.isdel ? "删除" : "生成") + htmlinfo.name + "</i></td><td width=\"230\">&nbsp;</td><td><i>处理完毕</i></td>"
//            }
        }
        htmlcode += "</tr>";
    }
    if(!tmp) clearInterval(timeout);
    htmlcode += "</table>";
    $("htmlstate").innerHTML = htmlcode;
}

function takeState(htmlcount,htmlcurrent) {
    if(htmlcount <= 0) {
        return "";
    }
    else {
        var cwidth = 150;
        var currwidth = parseInt(cwidth * (htmlcurrent/htmlcount));
        return "<div class=\"htmlmain\"><div class=\"htmlcount\" style=\"width:" + cwidth + "px;\"><div class=\"htmlcurrent\"  style=\"width:" + currwidth + "px;\"></div></div> <div class=\"htmltext\"> "+ htmlcurrent +"/" + htmlcount + "</div></div>";
    }
}

/**
=====================================模板管理 开始================================================
**/


function deltemp()
{
    var chkother= document.getElementsByTagName("input");
	var j=0;
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
			if(chkother[i].id.indexOf('T_ID')>-1)
			{
				if(chkother[i].checked == true)
				{
					j++;
				}
			}
		}
	}
	
	if(j==0)
	{
		return alertmsg('必须选择一个模板才能删除！','',false);
	}
	else if(confirm('是否删除？') == false)
	{
		return false;
	}
}
function addtemp()
{
    var T_ID = "";
    var chkother= document.getElementsByTagName("input");
	var j=0;
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
			if(chkother[i].id.indexOf('T_ID')>-1)
			{
				if(chkother[i].checked == true)
				{
					j++;
					T_ID = chkother[i].value;
				}
			}
		}
	}
	
	if(j==0)
	{
		return alertmsg('必须选择一个模板才能入库！','',false);
	}
	else 
	{
		CreateTemp(T_ID);
	}
}

function CreateTemp(T_ID)
{
    var url = "AddTemplate.aspx?T_ID="+T_ID;

    var xmlDoc=new XMLHttpObject(url,true);
    xmlDoc.OnComplete = CreateTempComplete;   
    xmlDoc.sendData();       
}

function CreateTempComplete(responseText, responseXML)
{
   alertmsg(responseText,"list.aspx",true);
}




/**
=====================================模板管理 结束================================================
**/


//选择普通模块
function selectothermodlue(obj)
{
    switch(obj.value)
    {
        case "brand":
            $("brand").style.display = "block";
            $("job").style.display = "none";
            $("company").style.display = "none";
            break;
        case "job":
            $("brand").style.display = "none";
            $("job").style.display = "block";
            $("company").style.display = "none";
            break;
        case "company":
            $("brand").style.display = "none";
            $("job").style.display = "none";
            $("company").style.display = "block";
            break;
    }
}

function xy_select_shop_template(obj)
{
    var type = document.getElementById("templateType").value;
    
    var tempName = "basic_shop_temp";
    if(type == "other")tempName = "other_shop_temp";
    
    var eles = document.getElementsByName(tempName);
        
    for(var i=0;i<eles.length;i++)
    {
        if(eles[i].type=="checkbox")
        {
            eles[i].checked = obj.checked;
        }
    }
}

function xy_create_shop_template()
{
    var type = document.getElementById("templateType").value;
    
    var tempName = "basic_shop_temp";
    if(type == "other")tempName = "other_shop_temp";
    
    var eles = document.getElementsByName(tempName);
        
    var tempPath ="";
    for(var i=0;i<eles.length;i++)
    {
        if(eles[i].type=="checkbox" && eles[i].checked)
        {
            if(tempPath =="")
                tempPath = "_shop/" + eles[i].value;
            else
                tempPath += "|_shop/" + eles[i].value;
        }
    }
    
    if(tempPath != "") createShopAll(tempPath);
}

function createShopAll(path)
{
     alertnotbut("<img src=\"../images/ajax-loader.gif\" /><br>正在生成网店模板文件...",false);
     
     createtemps("all|",path);
}
