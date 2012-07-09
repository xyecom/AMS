function Getkeyword(obj)
{

    document.getElementById("keywordids").value = "";
    document.getElementById("keywordnames").value = "";
    document.getElementById("wordclickobjname").value = obj.id;
    var ct=document.getElementById("wordtreetypelist");
	var ctbgalpaha = document.getElementById("alphaBox");

	if(ct.style.display == "none") {
		ct.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		selectkeywordlists();
		ct.style.height = document.documentElement.scrollHeight;
		ctbgalpaha.style.height= document.documentElement.scrollHeight+"px";
		if (navigator.appName == "Microsoft Internet Explorer") 
		{
			ctbgalpaha.style.width = document.documentElement.scrollWidth  + "px";
		}
		else 
		{
			ctbgalpaha.style.width = document.documentElement.scrollWidth  + "px";   
		}
	}
	else
	{
		ct.style.display = "none";
	}
}
//初始化关键字　
function selectkeywordlists()
{
    var url = "../GetTreeType.aspx?type=keyword";
	var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
  	document.getElementById("keywordlist").innerHTML = msg;  
}

function selectkeywordlist(id,name)
{
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}	
document.getElementById("keyword").innerHTML=name;
    document.getElementById("keywordid").value=id;
    closeword()
}

function closeword()
{
	if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
    document.getElementById("wordtreetypelist").style.display = "none";
}


function ValidateKwPost()
{
    if(document.getElementById("tbkwtitle").value == "")
    {
       return alertmsg('关键字竞价标题不能为空.','',false);
    }
    if(document.getElementById("keywordid").value == "")
    {
       return alertmsg('关键字不能为空,请选择关键字.','',false);
    }
    if(document.getElementById("tbbaseprice").value == "")
    {
       return alertmsg('关键字竞价底价不能为空,请按要求输入.','',false);
    }
    if(document.getElementById("tbfiexdprice").value == "")
    {
       return alertmsg('请设置关键字一口价.','',false);
    }
    if(document.getElementById("begintime").value == "")
    {
       return alertmsg('请输入竞价开始时间.','',false);
    }
    if(document.getElementById("endtime").value == "")
    {
       return alertmsg('请输入竞价结束时间.','',false);
    }
    if(document.getElementById("begintime").value != "" && document.getElementById("endtime").value != "")
    {
        var date1 = document.getElementById("begintime").value;
        var date2 = document.getElementById("endtime").value;
        var temp = new Date(date1.replace(/-/g,"/")) - (new Date(date2.replace(/-/g,"/"))); 
        if(Number(temp) > 0)
        {
           document.getElementById("begintime").value = "";
           document.getElementById("endtime").value = "";
           
           return alertmsg('竞价结束时间应该比竞价开始时间晚,请重新输入.','',false);
        }
    }
    
    if(document.getElementById("tbaddmin").value == "")
    {
       return alertmsg('请输入最低加价.','',false);
    }
    if(document.getElementById("tbaddmax").value == "")
    {
       return alertmsg('请输入最高加价.','',false);
    }
    if(document.getElementById("puttime").value == "")
    {
       return alertmsg('请选择本次竞价投放时间.','',false);
    }
    if(document.getElementById("putendtime").value == "")
    {
       return alertmsg('请选择本次竞价投放结束时间.','',false);
    }
    if(document.getElementById("puttime").value != "" && document.getElementById("putendtime").value != "")
    {
       var date1 = document.getElementById("begintime").value;
       var date2 = document.getElementById("endtime").value;
       var date3 = document.getElementById("puttime").value;
       var date4 = document.getElementById("putendtime").value;

       var bett = new Date(date2.replace(/-/g,"/")) - (new Date(date3.replace(/-/g,"/")));
       if(Number(bett) > 0)
       {
           document.getElementById("puttime").value = "";
           return alertmsg('投放开始时间应该比竞价结束时间晚,请重新输入.','',false);
       }
       
       var temp = new Date(date3.replace(/-/g,"/")) - (new Date(date4.replace(/-/g,"/"))); 
       if(Number(temp) > 0)
       {
           document.getElementById("puttime").value = "";
           document.getElementById("putendtime").value = "";
           return alertmsg('投放结束时间应该比投放开始时间晚,请重新输入.','',false);
       } 
     }  
}

function checknumber(string)
{
   var letters = "1234567890";
   var i;
   var c;
   for(i = 0; i < string.length; i++)
   {
      c = string.charAt(i);
      if(letters.indexOf(c) == -1)
      {
         return true;
      }
   }
   return false;
}

function IsNum()
{
   var txt = document.getElementById("tbaddmin").value;
   if(txt != "")
   {
       if(checknumber(txt))
       {
          document.getElementById("tbaddmin").value = "";
          document.getElementById("tbaddmin").focus();
          return alertmsg('只允许输入整数.','',false);
       }
   }
}

function IsFloat(obj)
{
    var tempValue=obj.value.replace(/(^\s+)|(\s+$)/g,'');
    if(!tempValue)
      { return false }
    if(/^-?\d+(\.\d+)?$/.test(tempValue))
    {
       obj.value=parseFloat(tempValue).toFixed(2);
    }
    else
    {
      document.getElementById("tbbaseprice").value = "";
      document.getElementById("tbbaseprice").focus();
      return alertmsg('请输入合法的浮点数.','',false);
    }
}


function CompareAdd()
{
   var txt = document.getElementById("tbaddmax").value;
   if(txt != "")
   {
      if(checknumber(txt))
      {
          document.getElementById("tbaddmax").value = "";
          document.getElementById("tbaddmax").focus();
          return alertmsg('只允许输入整数.','',false);
      }
      if(Number(txt) < Number(document.getElementById("tbaddmin").value))
      {
         document.getElementById("tbaddmax").value = "";
         document.getElementById("tbaddmax").focus();
         return alertmsg('最高加价应大于最低加价.','',false);
      }    
   }
}

var strtype = "";
strtype += "<div id=\"wordtreetypelist\" class=\"showBox\"  style=\"DISPLAY: none\">";
strtype += "<div id=\"cueContainer\" class=\"adressC\">";
strtype+="<p class=\"distance\"><a name=\"adresslist\"></a></p>";
 
strtype += "<div class=\"adressT\">";
strtype += "<div class=\"close\"><a  href=\"javascript:;\" onclick=\"closeword();\"></a></div>";
strtype += "选择关键字";
strtype += "</div>";
strtype += "<input type=\"hidden\" id=\"keywordids\" />";
strtype += "<input type=\"hidden\" id=\"keywordnames\" />";
strtype += "<input type=\"hidden\" id=\"wordclickobjname\" />";
  
strtype += "<div id=\"content\" >";


strtype +="<ul class=\"adressContent\" id=\"keywordlist\">";
strtype +=" </ul>";	 
strtype +="<li class=\"cue\">小提示: 点击所选择的关键字,该关键字会选中,且弹出层会自动关闭.</li>"; 
strtype += "<div class=\"closebutton\"></div>";
strtype += "</div>";

strtype += "<div  id=\"bottom\" class=\"adressB\"></div>";
strtype += "</div>"
strtype += "<div id=\"alphaBox\"></div>"
strtype += "</div>";


document.write(strtype);