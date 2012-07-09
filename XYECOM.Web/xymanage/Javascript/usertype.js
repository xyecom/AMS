

// JScript 文件
function companytreetype(obj)
{
    
    document.getElementById("companytypeids").value = "";
    document.getElementById("companytypenames").value = "";
    document.getElementById("companyclickobjname").value = obj.id;
    var ttl=document.getElementById("treecompanytypelist");
	var bgalpaha = document.getElementById("alphaBox");

	if(ttl.style.display == "none") {
		ttl.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		document.getElementById("selectcompanyinfo").style.display = "none";
                 initcompanytypelist();
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
function initcompanytypelist()
{
    var url =document.getElementById("weburl").value+"Common/Ajax.ashx?ac=024";
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	
	var strmsg = msg.split('$');
    document.getElementById("selectcompanytype").innerHTML = "请选择企业类别";
    document.getElementById("selectccompanytype").innerHTML = strmsg[0];
	document.getElementById("typecompanylist").innerHTML = "<a href=\"javascript:;\" onclick=\"selectcompanytypelist(0,this);\">请选择企业类别</a>"+ strmsg[1];
	
}

//选择左侧树型类别
function selectcompanytypelist(id,obj)
{
  var url =document.getElementById("weburl").value+"Common/Ajax.ashx?ac=025&value="+id;
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 

	var strmsg = msg.split('$');

	document.getElementById("selectcompanytype").innerHTML = strmsg[0];
	document.getElementById("selectccompanytype").innerHTML = strmsg[1];


	if(strmsg[0]==strmsg[2])
	    obj.parentNode.className = "sublast";
	else
	{
	    obj.parentNode.className = "spread";
	    obj.parentNode.innerHTML = strmsg[2];
	}
}


//选择右侧类别
function selectcompanytypeinfo(id,name)
{
    document.getElementById("selectcompanyinfo").style.display = "block";

    var str = document.getElementById("companytypeids").value;
    var strs = str.split(',');
    var ishave = false;
    

        for(var i=0;i<strs.length;i++)
        {
            if(strs[i]==id)
                ishave = true;
        }

    if(ishave == false)
    {
        document.getElementById("companytypeids").value = id;
        
        document.getElementById("companytypenames").value = name;
        document.getElementById("selectcompanyinfo").innerHTML = "<a href=\"javascript:;\" onclick=\"canceltype("+id+");\" class=\"result\">"+name+"</a>";
    }
}

//取消选择项
function cancelcompanytype(id)
{

    var strs = document.getElementById("companytypeids").value.split(',');
    var strnames = document.getElementById("companytypenames").value.split(',');
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

    document.getElementById("companytypeids").value = str;
    document.getElementById("companytypenames").value = strname;


	document.getElementById("selectcompanyinfo").innerHTML = strhtml;
	
}



//确认选择
function companyyes()
{
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}

    document.getElementById("selectcompanytype").innerHTML = "";
    document.getElementById("selectcompanyinfo").innerHTML = "";
    document.getElementById("selectccompanytype").innerHTML = "";
    document.getElementById(document.getElementById("companyclickobjname").value).innerHTML = "<span>" + document.getElementById("companytypenames").value + "</span>";
    document.getElementById("treecompanytypelist").style.display = "none";
}

//取消选择
function companyno()
{
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}

    document.getElementById("selectcompanytype").innerHTML = "";
    document.getElementById("selectcompanyinfo").innerHTML = "";
    document.getElementById("selectccompanytype").innerHTML = "";
    document.getElementById("treecompanytypelist").style.display = "none";
}

var strusertype = "";
strusertype += "	<div id=\"treecompanytypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";

strusertype += "<div id=\"cueContainer\" class=\"adressC\" >";
strusertype+="<p style=\"height:50px;\"><a name=\"companytypelist\"></a></p>";
strusertype += " <div class=\"adressT\">";
strusertype += "<div class=\"close\"><a  href=\"javascript:;\" onclick=\"companyno();\"></a></div>";
strusertype += "请选择企业类别</div>";

strusertype += "<input type=\"hidden\" id=\"companytypeids\"  />";
strusertype += "<input type=\"hidden\" id=\"companytypenames\" />";
strusertype += "<input type=\"hidden\" id=\"companyclickobjname\" />";
strusertype += "<div id=\"content\" >";
strusertype += "    <div class=\"list\">";
strusertype += "      <div class=\"listcontainer\">";
strusertype += "         <div class=\"flow\">";
strusertype += "            <ul id=\"typecompanylist\">";
strusertype += "		    </ul>";
strusertype += "          </div>";
strusertype += "      </div>";
strusertype += "    </div>";	  
  
	  
	  
strusertype += "      <div class=\"listRight\" >";
strusertype += "	  <p class=\"sorttitle\" id=\"selectcompanytype\"></p>";
strusertype += "        <div class=\"listSecondary\" id=\"selectccompanytype\">";
strusertype += "        </div>";
		
		
		

		
strusertype += "		<p class=\"sorttitle\">您选择的结果：</p>";
strusertype += "		<div class=\"listResult\" id=\"selectcompanyinfo\">";
strusertype += "		</div>";

strusertype += "		<p class=\"listCue\">";
strusertype += "		 操作小提示：<br />";
strusertype += " 1、在左边选择分类，右列显示其相应的下级分类；<br />";
strusertype += "2、选择结果在右下方显示；<br />3、如果要删除某项选择，点击其右上角的关闭按钮即可清楚此项。 </p>";

strusertype += "        <div class=\"listbutton\">";
strusertype += "            <input onclick=\"companyyes();\" type=button value=\"确 定\" name=button class=\"alertbutton\"> ";        
strusertype += "            <input onclick=\"companyno();\" type=button value=\"取 消\" name=button class=\"alertbutton\"> ";  
strusertype += "        </div>";

strusertype += "      </div>";
strusertype += "<div class=\"closebutton\"></div>";
strusertype += "</div>";
strusertype += "<div  id=\"bottom\" class=\"adressB\"></div>";
strusertype += "</div>";
strusertype += "<div id=alphaBox ></div>";

strusertype += "</div>";
document.write(strusertype);
