/*
* By advanced_search
**/

var TAB_COUNT = 6;

function selectSearchBox(num)
{
    for(i=1;i<=TAB_COUNT;i++)
    {
        try{
        eval("$('tab"+i+"').className='choiceout';");
        eval("$('contentBox"+i+"').style.display = 'none';");
        }catch(e){}
    }
    try{
    eval("$('tab"+num+"').className='choiceon';");
    eval("$('contentBox"+num+"').style.display = 'block';");
    }
    catch(e){}
}

function OfferSearch()
{
    var infoType = GetRadioValue("offerInfoType");
    var key = $F("offerkey").replace(/\s/g,"");
    var typeId = $F("offerTypeId");
    var areaId = $F("areaIdByOffer");
    var date = GetRadioValue("dateByOffer");
    
    if(date=="0")date="";
    
    GoUrl("offer",infoType,key,typeId,areaId,date);   
}

function MachiningSearch()
{
    var infoType = GetRadioValue("machiningInfoType");
    var key = $F("machiningkey").replace(/\s/g,"");
    var typeId = $F("machiningTypeId");
    var areaId = $F("areaIdByMachining");
    var date = GetRadioValue("dateByMachining");
    
    if(date=="0")date="";
    
    GoUrl("venture",infoType,key,typeId,areaId,date);      
}

function InvestmentSearch()
{
    var infoType = GetRadioValue("investmentInfoType");
    var key = $F("investmentkey").replace(/\s/g,"");
    var typeId = $F("investmentTypeId");
    var areaId = $F("areaIdByInvestment");
    var date = GetRadioValue("dateByInvestment");
    
    if(date=="0")date="";
    
    GoUrl("investment",infoType,key,typeId,areaId,date);   
}

function ServiceSearch()
{
    var infoType = GetRadioValue("serviceInfoType");
    var key = $F("servicekey").replace(/\s/g,"");
    var typeId = $F("serviceTypeId");
    var areaId = $F("areaIdByService");
    var date = GetRadioValue("dateByService");
    
    if(date=="0")date="";
    
    GoUrl("service",infoType,key,typeId,areaId,date);   
}

function UserSearch()
{
    var key = $F("userkey").replace(/\s/g,"");
    var typeId = $F("userTypeId");
    var areaId = $F("areaIdByUser");
    
    GoUrl("company","sell",key,typeId,areaId,"");   
}

function GoUrl(infoFlag,infoType,key,typeId,areaId,date)
{
    var pageFlag ="seller";
    if(infoType=="buy")pageFlag ="buyer";
    
    if(config.BogusStatic) {
        var url = config.WebURL + "search/" + pageFlag + "_search-"+infoFlag+"-"+typeId+"-"+key+"---"+areaId+"-"+date+"---."+config.Suffix; 
    }
    else {
	    url = config.WebURL +"search/" + pageFlag + "_search."+config.Suffix+"?flag="+infoFlag+"&pt_id="+typeId+"&keyword="+key + "&areaId=" + areaId + "&date=" + date; 
	}
	location = url;   
}

function AdvNewsSearch()
{
    var key = $F("newskey").replace(/\s/g,"");
    var typeId = $F("newstitleid");
    var start = $F("newsStartDate");
    var end = $F("newsEndDate");
    var type = GetRadioValue("newsType");
    var isCommend = GetRadioValue("isCommend");
    
    if(start =="" && end!="")
    {
        sAlert("请选择开始时间！","",true);
        return;
    }
    
    if(start!="" && end =="")
    {
        var _date = new Date();
        var month = _date.getMonth() + 1;
        if((""+month).length==1)month = "0" + month;
        var day = _date.getDate();
        if(("" +day).length==1)day = "0" + day;
        end = _date.getYear() +"-"+ month +"-"+ day;
    }
    
    var date = GetNewsTimeSpan(start,end);
    
    var url ="";
    if(config.BogusStatic) {
        url = config.WebURL + "search/news_search-"+type+"-"+typeId+"-"+key+"-"+date+"----"+isCommend+"."+config.Suffix; 
    }
    else {
	    url = config.WebURL +"search/news_search."+config.Suffix+"?type="+type+"&typeid="+typeId+"&keyword="+key + "&date=" + date + "&custom=" + isCommend; 
	}
	location = url;  
}

function GetRadioValue(name)
{
    var eles = document.getElementsByName(name);
    
    if(eles.length <=0)return"";
    
    var value ="";
    
    for(var i=0;i<eles.length;i++)
    {
        if(eles[i].checked)
        {
            value = eles[i].value;
            break;
        }
    }
    
    return value;
}



/*
* For News Search
**/

//取得当前搜索的数据
function GetNewsValue()
{
    var arrquery = new Array("type","typeid","keyword","date","showstyle","pagesize","pageindex","custom");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/")+1);
    
    var strSearchType
    var arrValue;
    
    if(config.BogusStatic)
    {
        var values = url.substring(0,url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        arrValue[2] = unescape(arrValue[2]);
    }
    else
    {
        strSearchType = url.substring(0,url.lastIndexOf("." + config.Suffix));
        //strSearchType = strSearchType.split("_")[0];
        
        arrValue = new Array(arrquery.length);
        for(var i =0; i<arrquery.length; i++) {
            arrValue[i+1] = GetQueryString(arrquery[i]);
        }
        arrValue[2] = unescape(arrValue[2]);
    }
    return {
        query:arrquery,
        value:arrValue,
        objData:{
            type:arrValue[1],
            typeid:arrValue[2],
            keyword:arrValue[3],
            times:arrValue[4],
            showstyle:arrValue[5],
            pagesize:arrValue[6],
            pageindex:arrValue[7],
            custom:arrValue[8]
        }
    };    
}

function SetNewsDefaultValue()
{
    var data = new GetNewsValue();
    
    if(data.objData.keyword.indexOf(",") != -1) {
        var arr = data.objData.keyword.split(",");
        $("txtsearchkey").value = arr[0];
        $("txtkeyword").value = arr[1];
    }
    else {
        $("txtsearchkey").value = data.objData.keyword;
    }
    
    if("" != data.objData.type)
    {
        $("newsType").value = data.objData.type;
    }
    
    if("" != data.objData.times) {
        var myDate = data.objData.times.toLowerCase();
        myDates = myDate.split("to");
        $("NewsStartDate").value = FormatDate(myDates[0]);
        $("NewsEndDate").value = FormatDate(myDates[1]);
    }
    
    if("" != data.objData.custom){
         $("isCommend").value = data.objData.custom;
    }
    
    
    if("" != data.objData.pagesize){
         $("PageSize").value = data.objData.pagesize;
    }
}

function SetNewsClassList(typeID)
{
    var data = new SearchGetValue();
    var query = "&moduleName=news&typeID=" + typeID;
    query += "&times=" + data.objData.times + "&keyword=" + data.objData.keyword
    var ajaxcls = new Ajax("xy033",query);
    ajaxcls.onSuccess = function() {       
        if (ajaxcls.state.result == "1") {       
            if(ajaxcls.data) {
                var list = "";
                for(i=0;i<ajaxcls.data.classlist.length;i++) {
                    list += "<li><a href=\"javascript:pturl(" + ajaxcls.data.classlist[i].classID + ");\">"+ unescape(ajaxcls.data.classlist[i].className) +"(" + ajaxcls.data.classlist[i].infoNum + ")</a></li>";
                }
                $("xy_ClassList").innerHTML = "" + list + "";
            }
            else {
                $("xy_PClassList").style.display ="none";
                //$("xy_ClassList").innerHTML = "<li>暂无子类！</li>";
            }
        }
        else
             $("xy_PClassList").style.display ="none";
            //$("ClassList").innerHTML = "<li>暂无子类！</li>";
    }
}

function NewsSearchKeyDown()
{
    var gk=event.keyCode;
	if(gk==13) 
	{
		NewsSearch();
	}
}

function xy_GoToNewsPage(pageIndex)
{
    if(pageIndex =="")return;
    
    if(isNaN(pageIndex))return;
    
    var total = parseInt($("totalPage").value);
    
    var toPage = parseInt(pageIndex);
    
    if(toPage <=0)return;

    if(toPage > total)
    {
         alertmsg(false,"最大页数为" + total);
         return;
    }
    
    NewsSearch();
}


function NewsSearch()
{   
    if(!CheckSearchKey($F("txtkeyword"))) return false;
    var data = new GetNewsValue();
    
    var href = config.WebURL + "search/news_search";    
    if(config.BogusStatic)
    {
        for(var i =0; i<data.query.length; i++) {
            href += "-";
            if(data.query[i] == "date")
                href += GetNewsTimeSpan($F("NewsStartDate"),$F("NewsEndDate"));
				
            else if(data.query[i] == "keyword") 
			{
                href += GetSearchKeyWord(data.value[i+1]);
            }
			else if(data.query[i]=="type")
			{
                href +=$F("newsType");
            }
			else if(data.query[i]=="custom")
			{
                href+=$F("isCommend");
            }
			else if(data.query[i]=="pagesize")
			{
                href+=GetNewsPageSize();
            }
			else if(data.query[i] == "pageindex")
			{
                var toPage = $F("cpage");
                if(toPage !="" && !isNaN(toPage) && toPage >0)
                {
                    href+= toPage;
                }
            }
            else
                href += data.value[i+1];
        }
        href += "." + config.Suffix;
    }
    else
    {
        href += "." + config.Suffix;
        for(var i =0; i<data.query.length; i++) {
            href += (0 == i ? "?" : "&") + data.query[i] + "=";
            if(data.query[i] == "date")
                href += GetNewsTimeSpan($F("NewsStartDate"),$F("NewsEndDate"));
            else if(data.query[i] == "keyword") {
                href += GetSearchKeyWord(data.value[i+1]);
            }else if(data.query[i]=="type"){
                href +=$F("newsType");
            }else if(data.query[i]=="custom"){
                href+=$F("isCommend");
            }else if(data.query[i]=="pagesize"){
                href+=GetNewsPageSize();
            }else if(data.query[i] == "pageindex"){
                var toPage = $F("cpage");
                if(toPage !="" && !isNaN(toPage) && toPage >0)
                {
                    href+= toPage;
                }
            }
            else
                href += data.value[i+1];
        }
        
    }
    window.location  = href;
}

function GetNewsPageSize()
{
    var pageSize = $F("PageSize");
    var iPageSize =20;
        
    if(!isNaN(pageSize))
    {
        iPageSize = parseInt(pageSize);
        if(iPageSize>100)iPageSize =100;
    }
        
    return iPageSize;
}
/*
function GetNewsTimeSpan(start,end)
{
    var value="";

    if(ValidateDate(start))
	
        value += ReplaceAll(start,"-","") + "TO";
        
    if(ValidateDate(end))
        value += ReplaceAll(end,"-","");
        
    return value;
}

function ValidateDate(source)
{
    var patrn = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29))$/
    return patrn.test(source);
}

function ReplaceAll(source,sChar,dChar)
{ 
    var length = source.length;
    if(length)
    for(var i=0;i<length;i++)
    {
        source = source.replace(sChar,dChar);
    }
    return source;    
}
*/
function GetNewsTimeSpan(start,end)
{
    var value="";

    if(ValidateDate(start))
	
        value += SplitALL(start) + "TO";
        
    if(ValidateDate(end))
        value += SplitALL(end);
        
    return value;
}

function ValidateDate(source)
{
    var patrn = /^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29))$/
    return patrn.test(source);
}

function SplitALL(source)
{ 
    var array= source.split("-");
	var month = array[1];
	var day = array[2];
	
	if(month.length==1) month = "0" + month;
	if(day.length==1) day = "0" + day;
	
	source = array[0] + month  + day;
	
    return source;    
}
function FormatDate(str)
{
    return str.substr(0,4) + "-" + str.substr(4,2) + "-" + str.substr(6,2);
}

function getPage()
{
    var url = location.href;
    
    var startIndex = url.indexOf("curPage");
    
    if(startIndex == -1) return;
    
    var tempStr = url.substr(startIndex,url.length-startIndex);
    
    var ary = tempStr.split("=");
    
    var page = ary[1];

    var aName = "__page_" + page;
    
    document.getElementById(aName).className ="cur";
}