
//QQ�ͷ�
document.write("<div class='QQbox' id='divQQbox' >");

document.write("<div class='Qlist' id='divOnline' onmouseout='hideMsgBox(event);' style='display : none;'>");

document.write("<div class='t'></div>");

document.write("<div class='con'>");

document.write("<h2>�ͷ���������</h2>");

document.write("<ul>");

document.write("<li class='odd1'><img src='Other/images/meinv.png' border='0' height='72'/></a></li>");

document.writeln("<li class='odd'><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=594449208&site=qq&menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:594449208:45\" alt=\"���������ҷ���Ϣ\" title=\"���������ҷ���Ϣ\"><span>�ٺſͷ�</span></a></li>");

document.writeln("<li class='odd'><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=594449208&site=qq&menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:594449208:45\" alt=\"���������ҷ���Ϣ\" title=\"���������ҷ���Ϣ\"><span>�ںſͷ�</span></a></li>");

document.writeln("<li class='odd'><a target=\"_blank\" href=\"http://wpa.qq.com/msgrd?v=3&uin=923600576&site=qq&menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:923600576:45\" alt=\"���������ҷ���Ϣ\" title=\"���������ҷ���Ϣ\"><span>�ۺſͷ�</span></a></li>");
document.write("<li class='odd2'>13891094356</li>");
document.write("</ul>");document.write("</div>");
document.write("<div class='b'></div>");
document.write("</div>");
document.write("<div id='divMenu' onmouseover='OnlineOver();'><img src='Other/images/qq_1.png' class='press'></div>");
document.write("</div>");
//<![CDATA[
var tips; 
var theTop = 80; /*����Ĭ�ϸ߶�,Խ��Խ����*/
var old = theTop;

function initFloatTips() {

tips = document.getElementById('divQQbox');

moveTips();

};

function moveTips() {

var tt=1;

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

tt=1;

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

document.getElementById("divQQbox").style.width = "125px";

}



function OnlineOut(){

document.getElementById("divMenu").style.display = "block";

document.getElementById("divOnline").style.display = "none";



}



function hideMsgBox(theEvent){ //theEvent���������¼���Firefox�ķ�ʽ

�� if (theEvent){

�� var browser=navigator.userAgent; //ȡ�����������

�� if (browser.indexOf("Firefox")>0){ //�����Firefox

���� if (document.getElementById('divOnline').contains(theEvent.relatedTarget)) { //�������Ԫ��

���� return; //������ʽ

} 

} 

if (browser.indexOf("MSIE")>0){ //�����IE

if (document.getElementById('divOnline').contains(event.toElement)) { //�������Ԫ��

return; //������ʽ

}

}

}

/*Ҫִ�еĲ���*/

document.getElementById("divMenu").style.display = "block";

document.getElementById("divOnline").style.display = "none";

}