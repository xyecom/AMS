

// JScript 文件
function showtreetype(obj)
{
    document.getElementById("typeids").value = "";
    document.getElementById("typenames").value = "";
    document.getElementById("clickobjname").value = obj.id;
    var ttl=document.getElementById("treetypelist");
	var bgalpaha = document.getElementById("alphaBox");

	if(ttl.style.display == "none") {
		ttl.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		document.getElementById("selectinfo").style.display = "none";
	        getlinktype();

	    
		ttl.style.height = document.documentElement.scrollHeight;
		bgalpaha.style.height= document.documentElement.scrollHeight+"px";
		if (navigator.appName == "Microsoft Internet Explorer") 
			bgalpaha.style.width = document.documentElement.scrollWidth  + "px";
		else 
			bgalpaha.style.width = document.documentElement.scrollWidth  + "px";   
	}
	else
		ttl.style.display = "none";
}


function getlinktype()
{
    //var url =document.getElementById("weburl").value+"Common/Ajax.ashx?ac=038";
    var url ="/Common/Ajax.ashx?ac=038";
    var XMLDoc1 = new XMLHttpObject(url,false);
    XMLDoc1.sendData();
    var msg = XMLDoc1.getText();
    var strmsg = msg.split('$');
    document.getElementById("typelist").innerHTML = strmsg[0];
    document.getElementById("selectctype").innerHTML = strmsg[1];
}

//选择左侧树型类别
function selecttypelist(id,obj)
{

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
     var url =document.getElementById("weburl").value+"Common/Ajax.ashx?ac=039&value="+id;
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	var strmsg = msg.split('$');
    
    
	document.getElementById("selecttype").innerHTML = strmsg[0];
	document.getElementById("selectctype").innerHTML = strmsg[1];


	if(strmsg[0] == strmsg[2])
	    obj.parentNode.className = "sublast";
	else
	{
	    obj.parentNode.className = "spread";
	    obj.parentNode.innerHTML = strmsg[2];
	}
}

//选择右侧类别
function selecttypeinfo(id,name)
{
  

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
  document.getElementById("selectinfo").style.display = "block";
    var str = document.getElementById("typeids").value;
    var strs = str.split(',');
    var ishave = false;
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i]==id)
            ishave = true;
    }
    if(ishave == false)
    {
        document.getElementById("typeids").value = id ;
        document.getElementById("typenames").value = name;
        document.getElementById("selectinfo").innerHTML = "<a href=\"#\" onclick=\"canceltype("+id+");\" class=\"result\">"+name+"</a>";
    }
}

//取消选择项
function canceltype(id)
{

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
	document.getElementById("typeids").value = "";
	documnet.getElementById("typenames").value = "";
	document.getElementById("selectinfo").innerHTML = "";
}



//确认选择
function yes()
{

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
    document.getElementById("selecttype").innerHTML = "";
    document.getElementById("selectinfo").innerHTML = "";
    document.getElementById("selectctype").innerHTML = "";
    document.getElementById(document.getElementById("clickobjname").value).innerHTML = document.getElementById("typenames").value;
    document.getElementById("flsortid").value = document.getElementById("typeids").value;
    document.getElementById("treetypelist").style.display = "none";
}

//取消选择
function no()
{
    document.getElementById("selecttype").innerHTML = "";
    document.getElementById("selectinfo").innerHTML = "";
    document.getElementById("selectctype").innerHTML = "";
    document.getElementById("treetypelist").style.display = "none";
}

var strtype = "";
strtype += "	<div id=\"treetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";
strtype += "<div class=\"adressC\" id=\"cueContainer\" >";
strtype += "<p class=\"distance\"><a name=\"producttypelist\"></a></p>";
strtype += "<div class=\"adressT\">";

strtype += "<div class=\"close\"><a href=\"javascript:;\" onclick=\"no()\"></a></div>";
strtype += "请选择友情链接类别</div>";

strtype += "<input type=\"hidden\" id=\"typeids\" />";
strtype += "<input type=\"hidden\" id=\"typenames\" />";
strtype += "<input type=\"hidden\" id=\"clickobjname\" />";

strtype += "<div id=\"content\">";
strtype += "    <div class=\"list\">";
strtype += "      <div class=\"listcontainer\">";
strtype += "         <div class=\"flow\">";
strtype += "            <ul id=\"typelist\">";
strtype += "		    </ul>";
strtype += "          </div>";
strtype += "      </div>";
strtype += "    </div>";	  
	  
	  
	  
strtype += "      <div class=\"listRight\" >";
strtype += "	  <p class=\"sorttitle\" id=\"selecttype\"></p>";
strtype += "        <div class=\"listSecondary\" id=\"selectctype\">";
strtype += "        </div>";
		
		
strtype += "		<p class=\"sorttitle\">您选择的结果：</p>";
strtype += "		<div class=\"listResult\" id=\"selectinfo\">";
strtype += "		</div>";
strtype += "        <p class=\"listCue\">";
strtype += "		 操作小提示：<br />";
strtype += "1、在左边目录树中选择分类，右列显示其相应的下级分类，用鼠标点击即可选择此类。<br />";
strtype += "2、选择结果在右下方出现，如果您要改变某项选择，用鼠标放在其上，点击关闭按钮即可清楚此项选择及之后的分类。 </p>";

strtype += "        <div class=\"listbutton\">";
strtype += "            <input onclick=yes(); type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strtype += "            <input onclick=no(); type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strtype += "        </div>";
strtype += "      </div>";
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";
strtype += "<div id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>";
strtype += "<div id=alphaBox ></div>";

strtype += "</div>";
document.write(strtype);