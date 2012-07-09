/* 
* 日历JS小模块 by Amour GUO<amourguo(a)gmail.com> 2006-12-25
* 当调用date.IniCal()时参数需为表单元素对像
* 当传入1个参数，返回“yyyy-mm-dd”格式的字符串给该表单元素作为其值
* 当传入3个参数时则依次返回年、月、日的字符串给三个表单元素作为其值
* 调用例子1：<input ... onclick="date.IniCal(this)".../>
* 调用例子2：<... onclick="date.IniCal(document.forms['formName'].elements['elemName'], document.forms['formName'].elements['elemName'], document.forms['formName'].elements['elemName'])".../>
*/
var date = new Object();
date.VERSION = "1.0";
date.AUTHOR  = "Amour GUO<amourguo(a)gmail.com>";
date.COPY_RIGHT = "date";
date.$ = function(elemId){
	if(document.getElementById){
//alert(elemId+document.getElementById(elemId));
		return document.getElementById(elemId);
	}else if(document.layers){
		document.layers[elemId];
	}else{
		return eval('document.all.' + elemId);
	};
};
date.AppendText = function(pObj, text, className,mYear,mMonth,mDay){
	mYear  = parseInt(mYear , 10);
	mMonth = parseInt(mMonth , 10);
	mDay   = parseInt(mDay , 10);
	rMonth = mMonth + 1;
	var divObj = document.createElement("DIV");
	if(className) divObj.className = className;
	divObj.appendChild(document.createTextNode(text));
	pObj.appendChild(divObj);

	//var curyear = parseInt(date_cal_curyear , 10);
	//var curmonth = parseInt(date_cal_curmonth , 10)+1;
    //var curday = parseInt(date_cal_curday , 10);
	//if(curyear+'-'+(curmonth<10?'0'+curmonth:curmonth)+'-'+(curday<10?'0'+curday:curday) < mYear+'-'+(rMonth<10?'0'+rMonth:rMonth)+'-'+(mDay<10?'0'+mDay:mDay) || mYear+'-'+(rMonth<10?'0'+rMonth:rMonth)+'-'+(mDay<10?'0'+mDay:mDay) < '1998-07-10')
	//{
		//divObj.style.cursor = "pointer";
		//return;
	//}
	
	if(divObj.className != "date_cal_weekday"){
		divObj.onmouseover = function(){
			this.className = "date_cal_sltday";
			this.title = mYear+"年"+rMonth+"月"+mDay+"日";
			date.$("date_cal_date").innerHTML = mYear+'-'+(rMonth<10?'0'+rMonth:rMonth)+'-'+(mDay<10?'0'+mDay:mDay);
		};
		divObj.onmousedown = function(){
			this.className = 'date_cal_slt2day';
		};
		divObj.onmouseout = function(){
			var curClass = (date_cal_curyear==mYear&&date_cal_curmonth==mMonth&&date_cal_curday==mDay)?'date_cal_curday':'date_cal_day';
			this.className = curClass;
		};
		divObj.onclick = function(){
			if(rMonth < 10) rMonth = "0" + rMonth;		//小于10补0
			if(mDay < 10) mDay = "0" + mDay;			//小于10补0
			if(date_cal_robj instanceof Array && date_cal_robj.length==3){
				date_cal_robj[0].value = mYear;
				date_cal_robj[1].value = rMonth;
				date_cal_robj[2].value = mDay;
			}else{
				date_cal_robj.value = (mYear+"-"+rMonth+"-"+mDay);
			}
			date.ColClose();
		}
		divObj.style.cursor = "pointer";
	}
};
date.GetOffsetPos = function(element) {
	var posTop = 0, posLeft = 0;
	do {
		//msg(element.tagName +":"+ element.offsetLeft);//toBeDel2006-8-21ete
		posTop += element.offsetTop || 0;
		posLeft += element.offsetLeft || 0;
		element = element.offsetParent;
		} while (element);
		return [posLeft, posTop];
};
date.TurnMonth = function(sign){
	var curMonth = parseInt(date.$("date_cal_month").innerHTML , 10) - 1;
	var curYear  = parseInt(date.$("date_cal_year").innerHTML , 10);
	if(sign==0){
		if(curMonth<=0){
			curMonth = 11;
			curYear --;
		}else{
			curMonth --;
		}
	}else if(sign==1){
		if(curMonth>=11){
			curMonth = 0;
			curYear ++;
		}else{
			curMonth ++;
		}
	}
	date.SetDate(curYear, curMonth);
};
date.TurnYear = function(sign){
	var curMonth = parseInt(date.$("date_cal_month").innerHTML , 10) - 1;
	var curYear  = parseInt(date.$("date_cal_year").innerHTML , 10);
	if(sign==0){
		if(curYear>1) curYear --;
	}else if(sign==1){
		curYear ++;
	}
	date.SetDate(curYear, curMonth);
};
date.ColClose = function(){
	date.$("date_cal_ibg").style.display = "none";
	date.$("date_cal").style.display = "none";
};
date.SetDate = function(mYear, mMonth){
	mYear = parseInt(mYear , 10);
	mMonth = parseInt(mMonth , 10);
	var firstDay = new Date(mYear,mMonth,1);
	var lastDay = new Date(((mMonth==11)?(mYear+1):mYear),((mMonth==11)?0:(mMonth+1)),0);

	date.$("date_cal_year").innerHTML = mYear;
	date.$("date_cal_month").innerHTML = mMonth+1;

	var dayIndex = 1;
	var con = date.$("date_cal_days");
	con.innerHTML = "";
	for(var i=0;i<=41;i++){
		if(i>(firstDay.getDay()+lastDay.getDate()-1)) break;
		if(i>=firstDay.getDay()){
			var curClass = (date_cal_curyear==mYear&&date_cal_curmonth==mMonth&&date_cal_curday==dayIndex)?'date_cal_curday':'date_cal_day';
			date.AppendText(con,dayIndex,curClass,mYear,mMonth,dayIndex);
			dayIndex++;
		}else{
			date.AppendText(con,'','date_cal_weekday');
		}
	}
	var cal = date.$("date_cal");
	var ibg = date.$("date_cal_ibg");
	ibg.style.height = cal.offsetHeight;
};
var date_cal_curdate = new Date();
var date_cal_curyear = date_cal_curdate.getFullYear();
var date_cal_curmonth = date_cal_curdate.getMonth();
var date_cal_curday = date_cal_curdate.getDate();
var date_cal_robj = null;
date.isDateString = function(sDate)
{
	if(sDate[0] == "undefined" || sDate[1] == "undefined" || sDate[2] == "undefined" || sDate[0] == "" || sDate[1] == "" || sDate[2] == "")
	{
	    return false;
	}
	sDate = sDate[0] + '-' + sDate[1] + '-' + sDate[2];
	var iaMonthDays = [31,28,31,30,31,30,31,31,30,31,30,31]
        var iaDate = new Array(3)
        var year, month, day

        if (arguments.length != 1) return false
        iaDate = sDate.toString().split("-")
        if (iaDate.length != 3) return false
        if (iaDate[1].length > 2 || iaDate[2].length > 2) return false
        if (isNaN(iaDate[0])||isNaN(iaDate[1])||isNaN(iaDate[2])) return false

        year = parseFloat(iaDate[0])
        month = parseFloat(iaDate[1])
        day=parseFloat(iaDate[2])

        if (year < 1900 || year > 2100) return false
        if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) iaMonthDays[1]=29;
        if (month < 1 || month > 12) return false
        if (day < 1 || day > iaMonthDays[month - 1]) return false
        return true
}
date.IniCal = function(){
	if(arguments.length < 1){
		alert("无参数传入！");
		return false;
	}

	if(arguments.length == 1){
		date_cal_robj = arguments[0];
		if(arguments[0].value != "") var sltDate = arguments[0].value.split("-");
	}else if(arguments.length == 3){
		date_cal_robj = [arguments[0],arguments[1],arguments[2]];
		if(arguments[0].value != "" && arguments[1].value != "" && arguments[2].value != "")			var sltDate = [arguments[0].value,arguments[1].value,arguments[2].value];
	}

	var objPos = date.GetOffsetPos(arguments[0]);
	var cal = date.$("date_cal");
	if(cal != null)
	{
        	document.body.removeChild(cal);
	}
	var divobj = document.createElement("div");
       	divobj.innerHTML=date.GetHtml();
       	divobj.style.display="block";
       	divobj.style.position="absolute";
	if(navigator.userAgent.indexOf("FireFox") != -1)
	{
	    divobj.style.width="228px";
	}
	else
	{
	    divobj.style.width="230px";
	}
       	divobj.style.top=(parseInt(objPos[1])+parseInt(arguments[0].offsetHeight)+1)+"px";
       	divobj.style.left=parseInt(objPos[0])+"px";
	divobj.id= "date_cal";
       	document.body.appendChild(divobj);

	date.SetDate((arguments[0].value == "" || !date.isDateString(sltDate))?date_cal_curyear:parseInt(sltDate[0] , 10),(arguments[0].value == "" || !date.isDateString(sltDate))?date_cal_curmonth:parseInt(sltDate[1] , 10)-1);

	var date_cal_curyear2 = parseInt(date_cal_curyear , 10);
	var date_cal_curmonth2 = parseInt(date_cal_curmonth , 10)+1;
	date_cal_curmonth2 = date_cal_curmonth2<10 ? "0"+date_cal_curmonth2 : date_cal_curmonth2;
	var date_cal_curday2 = parseInt(date_cal_curday , 10);
	date_cal_curday2 = date_cal_curday2<10 ? "0"+date_cal_curday2 : date_cal_curday2;

	date.$("date_cal_date").innerHTML = (arguments[0].value == "" || !date.isDateString(sltDate))?date_cal_curyear2+'-'+date_cal_curmonth2+'-'+date_cal_curday2:sltDate[0]+'-'+sltDate[1]+'-'+sltDate[2];

	var ibg = date.$("date_cal_ibg");
	ibg.style.display = "block";
	if(navigator.userAgent.indexOf("Opera") == -1)
	{
	    ibg.style.top=(parseInt(objPos[1])+parseInt(arguments[0].offsetHeight)+1)+"px";
	    ibg.style.left=parseInt(objPos[0])+"px";
	    ibg.style.height = divobj.offsetHeight;
	}
};

date.GetHtml = function()
{
	var v_text = '';
	v_text += '<table border=\'0\' cellpadding=\'0\' cellspacing=\'0\' class=\'f12\'><tr><td class=\'rl_b1\'>';
	v_text += '<table border=\'0\' class=\'f12\' width=\'100%\' cellpadding=\'4\' cellspacing=\'0\'>';
	v_text += '<tr align=\'center\' bgcolor=\'#e0f0f0\'>';
	v_text += '<td><b class=\'nyr\'><span id=\'date_cal_date\'>2007-1-19</span></b></td>';
	v_text += '<td width=\'15\'><a href=\'javascript:date.ColClose();\'><img src=\'http://image2.date.com.cn/pfp/iask/news/n_rl_gb.gif\' border=\'0\' width=\'15\' height=\'15\' alt=\'关闭\'></a></td>';
	v_text += '</tr>';
	v_text += '</table>';
	v_text += '<table border=\'0\' class=\'f12\' bgcolor=\'#ffffff\'>';
	v_text += '<tr align=\'center\' height=\'20\'>';
	v_text += '<td><a href=\'javascript:date.TurnYear(0);\'><img border=\'0\' src=\'http://image2.date.com.cn/pfp/iask/news/n_rl_l.gif\' width=\'14\' height=\'13\' alt=\'上一年\'></a></td>';
	v_text += '<td colspan=\'2\'><b class=\'ny\'><span id=\'date_cal_year\'>2007</span></b></td>';
	v_text += '<td><a href=\'javascript:date.TurnYear(1);\'><img border=\'0\' src=\'http://image2.date.com.cn/pfp/iask/news/n_rl_r.gif\' width=\'14\' height=\'13\' alt=\'下一年\'></a></td>';
	v_text += '<td><a href=\'javascript:date.TurnMonth(0);\'><img border=\'0\' src=\'http://image2.date.com.cn/pfp/iask/news/n_rl_l.gif\' width=\'14\' height=\'13\' alt=\'上一月\'></a></td>';
	v_text += '<td><b class=\'ny\'><span id=\'date_cal_month\'>1</span></b></td>';
	v_text += '<td><a href=\'javascript:date.TurnMonth(1);\'><img border=\'0\' src=\'http://image2.date.com.cn/pfp/iask/news/n_rl_r.gif\' width=\'14\' height=\'13\' alt=\'下一月\'></a></td>';
	v_text += '</tr>';
	v_text += '<tr align=\'center\' height=\'20\' bgcolor=\'#eef6ff\'>';
	v_text += '<td width=\'30\'><font color=\'#ff0066\'>Su</font></td>';
	v_text += '<td width=\'30\'>Mo</td>';
	v_text += '<td width=\'30\'>Tu</td>';
	v_text += '<td width=\'30\'>We</td>';
	v_text += '<td width=\'30\'>Th</td>';
	v_text += '<td width=\'30\'>Fr</td>';
	v_text += '<td width=\'30\'><font color=\'#ff0066\'>Sa</font></td>';
	v_text += '</tr>';
	v_text += '<tr><table>';
	v_text += '<div id=\'date_cal_days\'></div>';
	v_text += '</table></tr>';
	v_text += '</table>';
	v_text += '</td></tr></table>';

	return v_text;
};


document.writeln("\n\
<style type='text/css' media='all'>\n\
#date_cal_ibg{width:228px;position:absolute;background-color:#FAFAFA;display:none;}\n\
.date_cal_weekday{width:28px !important;width:30px;height:18px;line-height:18px;text-align:center;float:left;margin:0px 1px 0px 1px;color:#666;font-size:12px;border:1px solid #fff;}\n\
.date_cal_day{width:28px !important;width:30px;height:18px;line-height:18px;text-align:center;float:left;margin:0px 1px 0px 1px;font-size:12px;border:1px solid #fff;}\n\
.date_cal_curday{width:28px !important;width:30px;height:18px;line-height:18px;background-color:#06c;color:#fff;text-align:center;float:left;margin:0px 1px 0px 1px;font-size:12px;border:1px solid #06c;}\n\
.date_cal_sltday{width:28px !important;width:30px;height:18px;line-height:18px;background-color:#fff;text-align:center;float:left;margin:0px 1px 0px 1px;font-size:12px;border:1px solid #f06;}\n\
.date_cal_slt2day{width:28px !important;width:30px;height:18px;line-height:18px;background-color:#9cf;color:#39c;text-align:center;float:left;margin:0px 1px 0px 1px;font-size:12px;border-left:1px solid #39c; border-top:1px solid #39c; border-right:1px solid #fff; border-bottom:1px solid #fff;}\n\
\n\
.clearfix:after { content: '.'; display: block; height: 0; clear: both; visibility: hidden; }\n\
.clearfix {display: inline-table;}\n\
/* Hides from IE-mac \\*/\n\
 * html .clearfix {height: 1%;} .clearfix {display: block;}\n\
/* End hide from IE-mac */\n\
.f12{font-size:12px;}\n\
.ny{color:#369;}\n\
.nyr{color:#69c;}\n\
.rl_b1{border:1px solid #39c;}\n\
.rl_dt{color:#fff; background:#06c;}\n\
.rl_xz{color:#39c; background:#9cf; border-left:1px solid #39c; border-top:1px solid #39c;}\n\
.rl_hg{border:1px solid #f06;}\n\
</style>\n\
<iframe id='date_cal_ibg' border='0' frameborder='0' scrolling='no'></iframe>\n\
");

