﻿document.write("<div class='QQbox' id='divQQbox' >");
document.write("<div class='Qlist' id='divOnline' onmouseout='hideMsgBox(event);' style='display : none;'>");
document.write("<div class='t'></div>");
document.write("<div class='infobox'>竭诚为您服务</div>");
document.write("<div class='con'>");

document.write("<ul>");

document.write("<li class=odd><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=594449208&site=qq&menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:594449208:45\" alt=\"点击这里给我发消息\" title=\"点击这里给我发消息\"><span>①号客服</span></a></li>");


document.write("<li class=odd><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=594449208&site=qq&menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:594449208:45\" alt=\"点击这里给我发消息\" title=\"点击这里给我发消息\"><span>②号客服</span></a></li>");


document.write("<li class='odd'><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=923600576&site=qq&menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:923600576:45\" alt=\"点击这里给我发消息\" title=\"点击这里给我发消息\"><span>③号客服</span></a></li>");


document.write('<tr><td><li>咨询电话：13891094356</li></td></tr>');

document.write("</ul>");

document.write("</div>");

document.write("<div class='b'></div>");

document.write("</div>");

document.write("<div id='divMenu' onmouseover='OnlineOver();'><img src='Other/images/qq_1.gif' class='press' alt='在线咨询'></div>");

document.write("</div>");



//<![CDATA[

var tips; var theTop = 145/*这是默认高度,越大越往下*/; var old = theTop;

function initFloatTips() {

tips = document.getElementById('divQQbox');

moveTips();

};

function moveTips() {

var tt=50;

if (window.innerHeight) {

pos = window.pageYOffset

}

else if (document.documentElement && document.documentElement.scrollTop) {

pos = document.documentElement.scrollTop

}

else if (document.body) {

pos = document.body.scrollTop;

}

pos=pos-tips.offsetTop+theTop;

pos=tips.offsetTop+pos/10;



if (pos < theTop) pos = theTop;

if (pos != old) {

tips.style.top = pos+"px";

tt=10;

//alert(tips.style.top);

}



old = pos;

setTimeout(moveTips,tt);

}

//!]]>

initFloatTips();







function OnlineOver(){

document.getElementById("divMenu").style.display = "none";

document.getElementById("divOnline").style.display = "block";

document.getElementById("divQQbox").style.width = "170px";

}



function OnlineOut(){

document.getElementById("divMenu").style.display = "block";

document.getElementById("divOnline").style.display = "none";



}



if(typeof(HTMLElement)!="undefined")    //给firefox定义contains()方法，ie下不起作用
{   
      HTMLElement.prototype.contains=function(obj)   
      {   
          while(obj!=null&&typeof(obj.tagName)!="undefind"){ //通过循环对比来判断是不是obj的父元素
   　　　　if(obj==this) return true;   
   　　　　obj=obj.parentNode;
   　　}   
          return false;   
      };   
}  


function hideMsgBox(theEvent){ //theEvent用来传入事件，Firefox的方式

　 if (theEvent){

　 var browser=navigator.userAgent; //取得浏览器属性

　 if (browser.indexOf("Firefox")>0){ //如果是Firefox

　　 if (document.getElementById('divOnline').contains(theEvent.relatedTarget)) { //如果是子元素

　　 return; //结束函式

} 

} 

if (browser.indexOf("MSIE")>0){ //如果是IE

if (document.getElementById('divOnline').contains(event.toElement)) { //如果是子元素

return; //结束函式

}

}

}

/*要执行的操作*/

document.getElementById("divMenu").style.display = "block";

document.getElementById("divOnline").style.display = "none";

}









   