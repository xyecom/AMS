

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
                inittypelist();
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

//初始化
function inittypelist()
{

    var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=product&m_id="+document.getElementById("selectflag").value;
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	
	var strmsg = msg.split('$');
    document.getElementById("selecttype").innerHTML = "请选择供求类别";
    document.getElementById("selectctype").innerHTML = strmsg[0];
	document.getElementById("typelist").innerHTML = "<a href=\"javascript:;\" onclick=\"selecttypelist(0,this);\">请选择供求类别</a>"+strmsg[1];
	
}

//选择左侧树型类别
function selecttypelist(id,obj)
{
    var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=product&PT_ID="+id+"&m_id="+document.getElementById("selectflag").value;
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 

	var strmsg = msg.split('$');

	document.getElementById("selecttype").innerHTML = strmsg[0];
	document.getElementById("selectctype").innerHTML = strmsg[1];


	if(strmsg[0]==strmsg[2])
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
    document.getElementById("selectinfo").style.display = "block";

    var str = document.getElementById("typeids").value;
    var strs = str.split(',');
    var ishave = false;
    
    if(document.getElementById("selectflag").value == "1")
    {
        for(var i=0;i<strs.length;i++)
        {
            if(strs[i]==id)
                ishave = true;
        }
    }
    if(ishave == false)
    {
        document.getElementById("typeids").value = id;
        document.getElementById("hidPT_ID").value = id;
        document.getElementById("typenames").value = name;
        document.getElementById("selectinfo").innerHTML = "<a href=\"javascript:;\" onclick=\"canceltype("+id+");\" class=\"result\">"+name+"</a>";
    }
}

//取消选择项
function canceltype(id)
{
    var strs = document.getElementById("typeids").value.split(',');
    var strnames = document.getElementById("typenames").value.split(',');
    var str = "";
    var strname = "";

    var strhtml = "";
    for(var i=0;i<strs.length;i++)
    {
       
        if(strs[i] != id)
        {
            if(str.length>0)
            {
                
                str += "," + strs[i];
                strname += "," + strnames[i];                
                strhtml += "<a href=\"javascript:;\" onclick=\"canceltype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";
            }
            else
            {
                
                str += strs[i];
                strname +=  strnames[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"canceltype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";
                
             }
        }
    }

    document.getElementById("typeids").value = str;
    document.getElementById("typenames").value = strname;
    document.getElementById("hidPT_ID").value = str;

	document.getElementById("selectinfo").innerHTML = strhtml;
	
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
    document.getElementById(document.getElementById("clickobjname").value).innerHTML = "<span>" + document.getElementById("typenames").value + "</span>";
    document.getElementById("treetypelist").style.display = "none";
}

//取消选择
function no()
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
    document.getElementById("treetypelist").style.display = "none";
}

var strtype = "";
strtype += "	<div id=\"treetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";

strtype += "<div id=\"cueContainer\" class=\"adressC\" >";
strtype+="<p style=\"height:50px;\"><a name=\"producttypelist\"></a></p>";
strtype += " <div class=\"adressT\">";
strtype += "<div class=\"close\"><a  href=\"javascript:;\" onclick=\"no();\"></a></div>";
strtype += "请选择供求分类</div>";

strtype += "<input type=\"hidden\" id=\"typeids\"  />";
strtype += "<input type=\"hidden\" id=\"typenames\" />";
strtype += "<input type=\"hidden\" id=\"clickobjname\" />";
strtype += "<div id=\"content\" >";
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

strtype += "		<p class=\"listCue\">";
strtype += "		 操作小提示：<br />";
strtype += " 1、在左边选择分类，右列显示其相应的下级分类；<br />";
strtype += "2、选择结果在右下方显示；<br />3、如果要删除某项选择，点击其右上角的关闭按钮即可清楚此项。 </p>";

strtype += "        <div class=\"listbutton\">";
strtype += "            <input onclick=\"yes();\" type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strtype += "            <input onclick=\"no();\" type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strtype += "        </div>";

strtype += "      </div>";
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";
strtype += "<div  id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>";
strtype += "<div id=alphaBox ></div>";

strtype += "</div>";
document.write(strtype);




////==========================================================================
////
////  展会类别 开始
////
////==========================================================================
function showcooperatetype(obj)
{
    document.getElementById("cooperatetypeids").value = "";
    document.getElementById("cooperatetypenames").value = "";
    document.getElementById("cooperateclickobjname").value = obj.id;
    var ttl=document.getElementById("cooperatetreetypelist");
	var bgalpaha = document.getElementById("alphaBox");
	if(ttl.style.display == "none") {
		ttl.style.display = "block";
		 if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		document.getElementById("cooperateselectinfo").style.display = "none";
	         getcooperateprodtype(); 
	    
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

function getcooperateprodtype()
{
   var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=showlist";
   var XMLDoc1=new XMLHttpObject(url,false);
   XMLDoc1.sendData();
   var msg = XMLDoc1.getText();
   var strmsg = msg.split('$');

   document.getElementById("cooperateselecttype").innerHTML = "请选择展会类别";
   document.getElementById("cooperateselectctype").innerHTML = strmsg[0];
   document.getElementById("cooperateinfotype").innerHTML = "<a href=\"javascript:;\" onclick=\"selectcooperatetype(0,this);\">请选择展会类别</a>"+strmsg[1];
}

//选择左侧树型类别
function selectcooperatetype(id,obj)
{
    var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=showlist&SHT_ID="+id;
    alert(url);
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	var strmsg = msg.split('$');
    
	document.getElementById("cooperateselecttype").innerHTML = strmsg[0];
	document.getElementById("cooperateselectctype").innerHTML = strmsg[1];


	if(strmsg[0] == strmsg[2])
	    obj.parentNode.className = "sublast";
	else
	{
	    obj.parentNode.className = "spread";
	    obj.parentNode.innerHTML = strmsg[2];
	}
}

//选择右侧类别
function selectcooperatetypeinfo(id,name)
{
    document.getElementById("cooperateselectinfo").style.display = "block";
    
    var str = document.getElementById("cooperatetypeids").value;
    var strs = str.split(',');
    var ishave = false;
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i]==id)
            ishave = true;
    }
    if(ishave == false)
    {
       document.getElementById("cooperatetypeids").value=id;
       document.getElementById("cooperatetypenames").value=name;              
       document.getElementById("cooperateselectinfo").innerHTML= "<a href=\"#\" onclick=\"cooperatecanceltype("+id+");\" class=\"result\">"+name+"</a>";
       
    }
}

//取消选择项
function cancelcooperatetype(id)
{
    var strs = document.getElementById("cooperatetypeids").value.split(',');
    var strsname = document.getElementById("cooperatetypenames").value.split(',');
    var str = "";
    var strname = "";
      
    var strhtml = "";
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i] != id)
        {
            if(str.length>0)
            {
                str += ","+strs[i] ;
                strname += ","+strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelcooperatetype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";
            }
            else
            {
                str += strs[i];
                strname += strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelcooperatetype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";
            }    
        }
    }
    document.getElementById("hidPT_ID").value= str;

    document.getElementById("cooperatetypeids").value = str;
   
   
    document.getElementById("cooperateselectinfo").innerHTML = strhtml;
	document.getElementById("cooperatetypenames").value = strname;
	
}



//确认选择
function cooperateyes()
{  
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
   document.getElementById("cooperateselecttype").innerHTML = "";
    document.getElementById("cooperateselectinfo").innerHTML = "";
    document.getElementById("cooperateselectctype").innerHTML = "";
   document.getElementById(document.getElementById("cooperateclickobjname").value).innerHTML = "<span>" + document.getElementById("cooperatetypenames").value+ "</span>";

    document.getElementById("hidPT_ID").value=document.getElementById("cooperatetypeids").value;
   document.getElementById("cooperatetreetypelist").style.display = "none";

}

//取消选择
function cooperatenos()
{
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
     document.getElementById("cooperateselecttype").innerHTML = "";
    document.getElementById("cooperateselectinfo").innerHTML = "";
    document.getElementById("cooperateselectctype").innerHTML = "";
    document.getElementById("cooperatetreetypelist").style.display = "none";
}




var strtype = "";
strtype += "<div id=\"cooperatetreetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";
strtype += "<div id=\"cueContainer\" class=\"adressC\">";
strtype += "<p class=\"distance\"><a name=\"cooperatetreetypelist\"></a></p>";

strtype += "<div class=\"adressT\">";

strtype += "<div class=\"close\" ><a href=\"javascript:;\" onclick=\"cooperatenos()\"></a></div>";
strtype += "请选择展会类别</div>";
strtype += "<input type=\"hidden\" id=\"cooperatetypeids\" />";
strtype += "<input type=\"hidden\" id=\"cooperatetypenames\" />";
strtype += "<input type=\"hidden\" id=\"cooperateclickobjname\" />";



strtype += "<div id=\"content\">";
strtype += "    <div class=\"list\">";
strtype += "      <div class=\"listcontainer\">";
strtype += "         <div class=\"flow\">";
strtype += "            <ul id=\"cooperateinfotype\">";
strtype += "		    </ul>";
strtype += "          </div>";
strtype += "      </div>";
strtype += "    </div>";	  
	  
	  
strtype += "      <div class=\"listRight\" >";
strtype += "	  <p class=\"sorttitle\" id=\"cooperateselecttype\"></p>";
strtype += "        <div class=\"listSecondary\" id=\"cooperateselectctype\">";
strtype += "        </div>";
strtype += "        <p class=\"sorttitle\">您选择的结果:</p>";		
strtype += "        <div class=\"listResult\" id=\"cooperateselectinfo\">";
strtype += "		</div>";
strtype += "        <p class=\"listCue\">";
strtype += "		 操作小提示：<br />";
strtype += "1、在左边目录树中选择分类，右列显示其相应的下级分类:<br />";
strtype += "2、选择结果在右下方显示;<br />3、如果您要删除某项选择，点击其右上角的关闭按钮即可清楚此项. </p>";
strtype += "        <div class=\"listbutton\">";
strtype += "            <input onclick=cooperateyes(); type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strtype += "            <input onclick=cooperatenos(); type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strtype += "        </div>";
strtype += "      </div>";
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";
strtype += "<div id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>";
strtype += "<div id=\"alphaBox\"></div>";
strtype += "</div>";
document.write(strtype);






////==========================================================================
////
////  展会类别 结束
////
////==========================================================================







////==========================================================================
////
////  加工类别 开始
////
////==========================================================================
function processtreetype(obj)
{
    document.getElementById("processtypeids").value = "";
    document.getElementById("processtypenames").value = "";
    document.getElementById("processclickobjname").value = obj.id;
    var ttl=document.getElementById("processtreetypelist");
	var bgalpaha = document.getElementById("alphaBox");

	if(ttl.style.display == "none")
	{
		ttl.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		document.getElementById("processselectinfo").style.display = "none";
	    getprocessprodtype(); 
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

function getprocessprodtype()
{

   var url = document.getElementById("hidweburl").value +"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=processlist";

   var XMLDoc1=new XMLHttpObject(url,false);
   XMLDoc1.sendData();
   var msg = XMLDoc1.getText();
   var strmsg = msg.split('$');
   document.getElementById("processselecttype").innerHTML = "请选择加工类别";
   document.getElementById("processselectctype").innerHTML = strmsg[0];
   document.getElementById("processintype").innerHTML = "<a href=\"javascript:;\" onclick=\"selectprocesstype(0,this);\">请选择加工类别</a>"+strmsg[1];

}

//选择左侧树型类别
function selectprocesstype(id,obj)
{

    var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=processlist&MT_ID="+id;
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	var strmsg = msg.split('$');
    
    
	document.getElementById("processselecttype").innerHTML = strmsg[0];
	document.getElementById("processselectctype").innerHTML = strmsg[1];


	if(strmsg[0] == strmsg[2])
	    obj.parentNode.className = "sublast";
	else
	{
	    obj.parentNode.className = "spread";
	    obj.parentNode.innerHTML = strmsg[2];
	}
}

//选择右侧类别
function selectprocesstypeinfo(id,name)
{


    document.getElementById("processselectinfo").style.display = "block";
    
    var str = document.getElementById("processtypeids").value;
    var strs = str.split(',');
    var ishave = false;
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i]==id)
            ishave = true;
    }
    if(ishave == false)
    {
        
         document.getElementById("processtypeids").value =id;
       
         document.getElementById("processtypenames").value=name;              
         document.getElementById("processselectinfo").innerHTML = "<a href=\"javascript:;\" onclick=\"cancelprocesstype("+id+");\" class=\"result\">"+name+"</a>";
       
    }
}

//取消选择项
function cancelprocesstype(id)
{
    var strs = document.getElementById("processtypeids").value.split(',');
    var strsname = document.getElementById("processtypenames").value.split(',');
    var str = "";
    var strname = "";
    
    var strhtml = "";
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i] != id)
        {
            if(str.length>0)
            {
                str += ","+strs[i] ;
                strname += ","+strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelprocesstype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";
            }
            else
            {
                str += strs[i];
                strname += strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelprocesstype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";
            }    
        }
    }
    document.getElementById("hidPT_ID").value= str;
    document.getElementById("processtypeids").value = str;
    
    document.getElementById("processselectinfo").innerHTML = strhtml;
	document.getElementById("processtypenames").value = strname;
	
	
}



//确认选择
function processyes()
{  
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
   document.getElementById("processselecttype").innerHTML = "";
   document.getElementById("processselectinfo").innerHTML = "";
   document.getElementById("processselectctype").innerHTML = "";
   document.getElementById(document.getElementById("processclickobjname").value).innerHTML = "<span>" + document.getElementById("processtypenames").value + "</span>";
   document.getElementById("hidPT_ID").value=document.getElementById("processtypeids").value;
   document.getElementById("processtreetypelist").style.display = "none";
}

//取消选择
function processnos()
{

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
    document.getElementById("processselecttype").innerHTML = "";
    document.getElementById("processselectinfo").innerHTML = "";
    document.getElementById("processselectctype").innerHTML = "";
    document.getElementById("processtreetypelist").style.display = "none";
}




var strtype = "";
strtype += "<div id=\"processtreetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";
strtype += "<div id=\"cueContainer\" class=\"adressC\">";
strtype += "<p class=\"distance\"><a name=\"processtreetypelist\"></a></p>";

strtype += "<div class=\"adressT\">";

strtype += "<div class=\"close\" ><a href=\"javascript:;\" onclick=\"processnos()\"></a></div>";
strtype += "请选择加工类别</div>";
strtype += "<input type=\"hidden\" id=\"processtypeids\" />";
strtype += "<input type=\"hidden\" id=\"processtypenames\" />";
strtype += "<input type=\"hidden\" id=\"processclickobjname\" />";



strtype += "<div id=\"content\">";
strtype += "    <div class=\"list\">";
strtype += "      <div class=\"listcontainer\">";
strtype += "         <div class=\"flow\">";
strtype += "            <ul id=\"processintype\">";
strtype += "		    </ul>";
strtype += "          </div>";
strtype += "      </div>";
strtype += "    </div>";	  
	  
	  
strtype += "      <div class=\"listRight\" >";
strtype += "	  <p class=\"sorttitle\" id=\"processselecttype\"></p>";
strtype += "        <div class=\"listSecondary\" id=\"processselectctype\">";
strtype += "        </div>";
strtype += "        <p class=\"sorttitle\">您选择的结果:</p>";		
strtype += "        <div class=\"listResult\" id=\"processselectinfo\">";
strtype += "		</div>";
strtype += "        <p class=\"listCue\">";
strtype += "		 操作小提示：<br />";
strtype += "1、在左边目录树中选择分类，右列显示其相应的下级分类:<br />";
strtype += "2、选择结果在右下方显示;<br />3、如果您要删除某项选择，点击其右上角的关闭按钮即可清楚此项. </p>";
strtype += "        <div class=\"listbutton\">";
strtype += "            <input onclick=processyes(); type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strtype += "            <input onclick=processnos(); type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strtype += "        </div>";
strtype += "      </div>";
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";
strtype += "<div id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>";
strtype += "<div id=\"alphaBox\"></div>";
strtype += "</div>";
document.write(strtype);






////==========================================================================
////
////  加工类别 结束
////
////==========================================================================







////==========================================================================
////
////  代理加盟类别 开始
////
////==========================================================================
function showsuogateype(obj)
{
    document.getElementById("suogatetypeids").value = "";
    document.getElementById("suogatetypenames").value = "";
    document.getElementById("suogatesclickobjname").value = obj.id;
    var ttl=document.getElementById("suogatereetypelist");
	var bgalpaha = document.getElementById("alphaBox");

	if(ttl.style.display == "none") {
		ttl.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		document.getElementById("suogateselectinfo").style.display = "none";
	        getsuogateprodtype(); 
	    
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

function getsuogateprodtype()
{
   var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=suogateselist";

   var XMLDoc1=new XMLHttpObject(url,false);
   XMLDoc1.sendData();
   var msg = XMLDoc1.getText();
   var strmsg = msg.split('$');

   document.getElementById("suogateselecttype").innerHTML = "请选择代理加盟类别";
   document.getElementById("suogateselectctype").innerHTML = strmsg[0];
   document.getElementById("suoinfotype").innerHTML = "<a href=\"javascript:;\" onclick=\"selectsuogateype(0,this);\">请选择代理加盟类别</a>"+strmsg[1];
}

//选择左侧树型类别
function selectsuogateype(id,obj)
{
 
   var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=suogateselist&IT_ID="+id;
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	var strmsg = msg.split('$');
    
    
	document.getElementById("suogateselecttype").innerHTML = strmsg[0];
	document.getElementById("suogateselectctype").innerHTML = strmsg[1];


	if(strmsg[0] == strmsg[2])
	    obj.parentNode.className = "sublast";
	else
	{
	    obj.parentNode.className = "spread";
	    obj.parentNode.innerHTML = strmsg[2];
	}
}

//选择右侧类别
function selectsuogateypeinfo(id,name)
{

    document.getElementById("suogateselectinfo").style.display = "block";
    
    var str = document.getElementById("suogatetypeids").value;
    var strs = str.split(',');
    var ishave = false;
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i]==id)
            ishave = true;
    }
    if(ishave == false)
    {

        document.getElementById("suogatetypeids").value=id;

         document.getElementById("suogatetypenames").value=name;              
         document.getElementById("suogateselectinfo").innerHTML= "<a href=\"#\" onclick=\"cancelsuogateype("+id+");\" class=\"result\">"+name+"</a>";
       
    }
}

//取消选择项
function cancelsuogateype(id)
{

    var strs = document.getElementById("suogatetypeids").value.split(',');
    var strsname = document.getElementById("suogatetypenames").value.split(',');
    var str = "";
    var strname = "";
    var strhtml = "";
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i] != id)
        {
            if(str.length>0)
            {
                str += ","+strs[i] ;
                strname += ","+strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelsuogateype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";

            }
            else
            {
                str += strs[i];
                strname += strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelsuogateype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";

            }    
        }
    }

    document.getElementById("hidPT_ID").value= str;
    document.getElementById("suogatetypeids").value = str;

    document.getElementById("suogateselectinfo").innerHTML = strhtml;
	document.getElementById("suogatetypenames").value = strname;

    

	
}



//确认选择
function suogateyes()
{  
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
   document.getElementById("suogateselecttype").innerHTML = "";
    document.getElementById("suogateselectinfo").innerHTML = "";
    document.getElementById("suogateselectctype").innerHTML = "";
   document.getElementById(document.getElementById("suogatesclickobjname").value).innerHTML = "<span>" + document.getElementById("suogatetypenames").value + "</span>";
    document.getElementById("hidPT_ID").value=document.getElementById("suogatetypeids").value;
   document.getElementById("suogatereetypelist").style.display = "none";
}

//取消选择
function suogatenos()
{

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
     document.getElementById("suogateselecttype").innerHTML = "";
    document.getElementById("suogateselectinfo").innerHTML = "";
    document.getElementById("suogateselectctype").innerHTML = "";
    document.getElementById("suogatereetypelist").style.display = "none";
}




var strtype = "";
strtype += "<div id=\"suogatereetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";
strtype += "<div id=\"cueContainer\" class=\"adressC\">";
strtype += "<p class=\"distance\"><a name=\"suogatereetypelist\"></a></p>";

strtype += "<div class=\"adressT\">";

strtype += "<div class=\"close\" ><a href=\"javascript:;\" onclick=\"suogatenos()\"></a></div>";
strtype += "请选择代理加盟类别</div>";
strtype += "<input type=\"hidden\" id=\"suogatetypeids\" />";
strtype += "<input type=\"hidden\" id=\"suogatetypenames\" />";
strtype += "<input type=\"hidden\" id=\"suogatesclickobjname\" />";



strtype += "<div id=\"content\">";
strtype += "    <div class=\"list\">";
strtype += "      <div class=\"listcontainer\">";
strtype += "         <div class=\"flow\">";
strtype += "            <ul id=\"suoinfotype\">";
strtype += "		    </ul>";
strtype += "          </div>";
strtype += "      </div>";
strtype += "    </div>";	  
	  
	  
strtype += "      <div class=\"listRight\" >";
strtype += "	  <p class=\"sorttitle\" id=\"suogateselecttype\"></p>";
strtype += "        <div class=\"listSecondary\" id=\"suogateselectctype\">";
strtype += "        </div>";
strtype += "        <p class=\"sorttitle\">您选择的结果:</p>";		
strtype += "        <div class=\"listResult\" id=\"suogateselectinfo\">";
strtype += "		</div>";
strtype += "        <p class=\"listCue\">";
strtype += "		 操作小提示：<br />";
strtype += "1、在左边目录树中选择分类，右列显示其相应的下级分类:<br />";
strtype += "2、选择结果在右下方显示;<br />3、如果您要删除某项选择，点击其右上角的关闭按钮即可清楚此项. </p>";
strtype += "        <div class=\"listbutton\">";
strtype += "            <input onclick=suogateyes(); type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strtype += "            <input onclick=suogatenos(); type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strtype += "        </div>";
strtype += "      </div>";
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";
strtype += "<div id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>";
strtype += "<div id=\"alphaBox\"></div>";
strtype += "</div>";
document.write(strtype);






////==========================================================================
////
////  代理加盟类别 结束
////
////==========================================================================












////==========================================================================
////
////  服务类别 开始
////
////==========================================================================
function showserverype(obj)
{
    document.getElementById("servertypeids").value = "";
    document.getElementById("servertypenames").value = "";
    document.getElementById("serverclickobjname").value = obj.id;
    var ttl=document.getElementById("serverreetypelist");
	var bgalpaha = document.getElementById("alphaBox");

	if(ttl.style.display == "none") {
		ttl.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		document.getElementById("serverselectinfo").style.display = "none";
	        getservertype(); 
	    
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

function getservertype()
{
   var url = document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=serverlist";
   var XMLDoc1=new XMLHttpObject(url,false);
   XMLDoc1.sendData();
   var msg = XMLDoc1.getText();
   var strmsg = msg.split('$');
   document.getElementById("serverselecttype").innerHTML = "请选择服务类别";
   document.getElementById("serverselectctype").innerHTML = strmsg[0];
   document.getElementById("serverinfotype").innerHTML = "<a href=\"javascript:;\" onclick=\"selectserverype(0,this);\">请选择服务类别</a>"+strmsg[1];
}

//选择左侧树型类别
function selectserverype(id,obj)
{

    var url =document.getElementById("hidweburl").value+"xymanage/GetTreeType."+document.getElementById("hidsuffix").value+"?type=serverlist&ST_ID="+id;

	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	var strmsg = msg.split('$');

    
	document.getElementById("serverselecttype").innerHTML = strmsg[0];
	document.getElementById("serverselectctype").innerHTML = strmsg[1];


	if(strmsg[0] == strmsg[2])
	    obj.parentNode.className = "sublast";
	else
	{
	    obj.parentNode.className = "spread";
	    obj.parentNode.innerHTML = strmsg[2];
	}
}

//选择右侧类别
function selectserverypeinfo(id,name)
{

    document.getElementById("serverselectinfo").style.display = "block";
    
    var str = document.getElementById("servertypeids").value;
    var strs = str.split(',');
    var ishave = false;
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i]==id)
            ishave = true;
    }
    if(ishave == false)
    {
        
         document.getElementById("servertypeids").value=id;
         document.getElementById("servertypenames").value=name;              
         document.getElementById("serverselectinfo").innerHTML= "<a href=\"#\" onclick=\"cancelserverype("+id+");\" class=\"result\">"+name+"</a>";
       
    }
}

//取消选择项
function cancelserverype(id)
{

    var strs = document.getElementById("servertypeids").value.split(',');
    var strsname = document.getElementById("servertypenames").value.split(',');
    var str = "";
    var strname = "";
    var strhtml = "";
    for(var i=0;i<strs.length;i++)
    {
        if(strs[i] != id)
        {
            if(str.length>0)
            {
                str += ","+strs[i] ;
                strname += ","+strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelserverype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";

            }
            else
            {
                str += strs[i];
                strname += strsname[i];
                strhtml += "<a href=\"javascript:;\" onclick=\"cancelserverype("+strs[i]+");\" class=\"result\">"+ strnames[i]+"</a>";

            }    
        }
    }

    document.getElementById("hidPT_ID").value= str;

    document.getElementById("servertypeids").value = str;

    document.getElementById("serverselectinfo").innerHTML = strhtml;
    document.getElementById("servertypenames").value = strname;
}



//确认选择
function serveryes()
{  
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
   document.getElementById("serverselecttype").innerHTML = "";
    document.getElementById("serverselectinfo").innerHTML = "";
    document.getElementById("serverselectctype").innerHTML = "";
   document.getElementById(document.getElementById("serverclickobjname").value).innerHTML = "<span>" + document.getElementById("servertypenames").value+ "</span>";
    document.getElementById("hidPT_ID").value=document.getElementById("servertypeids").value;
   document.getElementById("serverreetypelist").style.display = "none";
   
}

//取消选择
function servernos()
{
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}    
 document.getElementById("serverselecttype").innerHTML = "";
    document.getElementById("serverselectinfo").innerHTML = "";
    document.getElementById("serverselectctype").innerHTML = "";
    document.getElementById("serverreetypelist").style.display = "none";
}




var strtype = "";
strtype += "<div id=\"serverreetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";
strtype += "<div id=\"cueContainer\" class=\"adressC\">";
strtype += "<p class=\"distance\"><a name=\"serverreetypelist\"></a></p>";

strtype += "<div class=\"adressT\">";

strtype += "<div class=\"close\" ><a href=\"javascript:;\" onclick=\"servernos()\"></a></div>";
strtype += "请选择服务类别</div>";
strtype += "<input type=\"hidden\" id=\"servertypeids\" />";
strtype += "<input type=\"hidden\" id=\"servertypenames\" />";
strtype += "<input type=\"hidden\" id=\"serverclickobjname\" />";



strtype += "<div id=\"content\">";
strtype += "    <div class=\"list\">";
strtype += "      <div class=\"listcontainer\">";
strtype += "         <div class=\"flow\">";
strtype += "            <ul id=\"serverinfotype\">";
strtype += "		    </ul>";
strtype += "          </div>";
strtype += "      </div>";
strtype += "    </div>";	  
	  
	  
strtype += "      <div class=\"listRight\" >";
strtype += "	  <p class=\"sorttitle\" id=\"serverselecttype\"></p>";
strtype += "        <div class=\"listSecondary\" id=\"serverselectctype\">";
strtype += "        </div>";
strtype += "        <p class=\"sorttitle\">您选择的结果:</p>";		
strtype += "        <div class=\"listResult\" id=\"serverselectinfo\">";
strtype += "		</div>";
strtype += "        <p class=\"listCue\">";
strtype += "		 操作小提示：<br />";
strtype += "1、在左边目录树中选择分类，右列显示其相应的下级分类:<br />";
strtype += "2、选择结果在右下方显示;<br />3、如果您要删除某项选择，点击其右上角的关闭按钮即可清楚此项. </p>";
strtype += "        <div class=\"listbutton\">";
strtype += "            <input onclick=serveryes(); type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strtype += "            <input onclick=servernos(); type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strtype += "        </div>";
strtype += "      </div>";
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";
strtype += "<div id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>";
strtype += "<div id=\"alphaBox\"></div>";
strtype += "</div>";
document.write(strtype);






////==========================================================================
////
////  服务类别 结束
////
////==========================================================================









