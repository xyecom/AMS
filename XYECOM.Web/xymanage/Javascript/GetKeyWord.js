// JScript 文件

function keyword() 
{
	var showkeywordBox=document.getElementById("showkeywordBox");
	var alphakeywordBox = document.getElementById("alphaBox");
	var content = document.getElementById("content");
	if(showkeywordBox.style.display == "none") 
	{
		showkeywordBox.style.display = "block";
		if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
		showkeywordBox.style.height = document.documentElement.scrollHeight;
		alphakeywordBox.style.height= document.documentElement.scrollHeight+"px";
		if (navigator.appName == "Microsoft Internet Explorer") 
			alphakeywordBox.style.width = document.documentElement.scrollWidth  + "px";
		else 
			alphakeywordBox.style.width = document.documentElement.scrollWidth  + "px";
	}
	else
		showkeywordBox.style.display = "none";
}

function Addkeywords()
{
   var divkeyword = document.getElementById("keywordli");
   var nums = divkeyword.getElementsByTagName("*");
   var textnum=0;
   var addintput = "<input name=\"text\" type=\"text\" size=\"12\" /><input name=\"text\" type=\"text\" size=\"12\" /><input name=\"text\" type=\"text\" size=\"12\"/><input name=\"text\" type=\"text\" size=\"12\"/><input name=\"text\" type=\"text\" size=\"12\"/>";
   for(var m=0; m<nums.length; m++)
   {
      if(divkeyword.all[m].type =="text")
         textnum++;
   } 
   
   if(textnum< 25)
   {
      divkeyword.innerHTML += addintput;
   }
   else
   {
      document.getElementById("numerror").style.display = "block";
   }
}

function Getkeywords()
{
    document.getElementById("divkeyword").innerHTML = "";
    var likeyword = document.getElementById("keywordli");
    var keys = likeyword.getElementsByTagName("*");
    for (var s=0; s<keys.length; s++)
    {
       if(likeyword.all[s].type=="text")
       {
           if(likeyword.all[s].value != "")
           {
              var temp = likeyword.all[s].value;
              document.getElementById("keys").value +=","+temp;
              document.getElementById("divkeyword").innerHTML += getlink(s,temp);
           }
       }
    }
    document.getElementById("reswords").value = document.getElementById("keys").value.substring(1);
    var sdfkja=document.getElementById("reswords").value;
    onkeyword();
    
}

function cancelkeyword(s)
{
   
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
 var temps = document.getElementById("keys").value.substring(1);
    var ts = temps.split(",");
    var words ="";
    var tm="";
    for(var e=0; e<ts.length;e++)
    {
       if(ts[e] != "")
       {
           if(e != s)
           {
              tm += ","+ts[e];
              words += getlink(e,ts[e]);
           }
       }
    }
    document.getElementById("keys").value = tm;
    document.getElementById("reswords").value = tm.substring(1);
    document.getElementById("divkeyword").innerHTML = words;
}

function getlink(s,temp)
{

if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "hidden";
			}
		}
   var str = "<a href=\"javascript:;\" onclick=\"cancelkeyword(\'"+s+"\');\">"+temp+"</a>";
   return str;
}

function onkeyword()
{
   var addinut = "<input name=\"text\" type=\"text\" size=\"12\" /><input name=\"text\" type=\"text\" size=\"12\" /><input name=\"text\" type=\"text\" size=\"12\"/><input name=\"text\" type=\"text\" size=\"12\"/><input name=\"text\" type=\"text\" size=\"12\"/>";
   document.getElementById("keywordli").innerHTML = addinut;
   document.getElementById("numerror").style.display = "none";
if(navigator.appName=="Microsoft Internet Explorer"){

			var pageOption=document.getElementsByTagName("select");
			for(var i=0;i<pageOption.length;i++){
				pageOption[i].style.visibility = "visible";
			}
		}
   document.getElementById("showkeywordBox").style.display = "none";  
}

var strkeyword = "";

strkeyword += "<div id=\"showkeywordBox\" class=\"showBox\"  style=\"display: none\">";

strkeyword += "<div id=\"cueContainer\" class=\"keywordsC\">";

strkeyword += "<p class=\"distance\"><a name=\"keywords\"></a></p>";

strkeyword += "<div class=\"title keywordsT\">";
strkeyword += "<div class=\"cloes\"><a href=\"javascript:;\";></a></div>";
strkeyword += "选择关键字";
strkeyword += "</div>";
strkeyword += "<input type=\"hidden\" id=\"keys\" />";
strkeyword += "<div id=\"content\">";

strkeyword += "<ul class=\"keyContent\">";
strkeyword += "<li>添加关键字：<span class=\"red\" id=\"numerror\" style=\"display: none\" >最多只能输入25个关键字！</span></li>";

strkeyword += "<li id=\"keywordli\" class=\"inputlist\"><input name=\"text\" type=\"text\" size=\"12\" /><input name=\"text\" type=\"text\" size=\"12\" /><input name=\"text\" type=\"text\" size=\"12\"/>";
strkeyword += "<input name=\"text\" type=\"text\" size=\"12\"/><input name=\"text\" type=\"text\" size=\"12\"/></li>";

strkeyword += "<li  class=\"img\"><img src=\"../images/add.gif\" onclick=\"Addkeywords();\" alt=\"add\" /></li>";

strkeyword += "<li  class=\"cue\">小提示：<br />";
strkeyword += "1.单个输入框不能超过10个汉字   2.点击”+“按钮，可增加一排输入框  3.最多只能输入25个.</li>";
strkeyword += "</ul>";

strkeyword += "<div class=\"closebutton\">";
strkeyword += "<input type=\"button\" value=\"确 定\" name=\"button\" onclick=\"Getkeywords();\" class=\"button\" /><input type=\"button\" value=\"取 消\" name=\"button\" onclick=\"onkeyword();\" class=\"button\" />";
strkeyword += "</div>";
strkeyword += "</div>";

strkeyword += "<div id=\"bottom\" class=\"keywordsB\"></div>";
strkeyword += "</div>";

strkeyword += "<div id=\"alphaBox\"></div>";
strkeyword += "</div>";
document.write(strkeyword);

