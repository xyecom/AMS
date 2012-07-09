//百科


function lemmaadd()
{     
    if(CheckLemmaForm()) CheckLemmaName($("lemmaname"));
}

function lemmaedit()
{
    if(CheckLemmaForm()){
        var reason = $F("modifyReason");    
        if(reason.trim()==""){
            sAlert("请输入修改原因！");
            return false;
        }
        
        $("frmlemma").submit();
    }
}    
    
function CheckLemmaForm()
{
    /*词条名称*/
    var lemma = $F("lemmaname");    
    if(lemma.trim()==""){
        sAlert("词条名称为必填项！");        
        return false;
    }
    
    /*类型*/
    var type = $F("typeId");
    if(type.trim()==""){
        sAlert("请选择百科分类！");         
        return false;
    }
     
    var oEditor = FCKeditorAPI.GetInstance('FCKeditor1');  
    var oDOM = oEditor.EditorDocument;
//    var text = oDOM.body.innerText;
//    if(text.trim()==""){
//        sAlert("词条内容为必填项！");
//        return false;
//    }
    return true;
}

function CheckLemmaNameBlur()
{
    var data = new SearchGetValue();
    var query = "&lemmaname=" + $F("lemmaname");
    var ajaxcls = new Ajax("xy041",query);
    ajaxcls.onSuccess = function() {       
        if (ajaxcls.state.result == "1") {
            if(ajaxcls.state.message!="")
            {
                //window.location.href = config.WebURL+'login.'+config.Suffix+'?surl='+escape();
                sAlert(ajaxcls.state.message);
            }
        }
    }
}

function SearchGetValue()
{
    var arrquery = new Array("flag","typeid","keyword","tradeid","order","areaid","date","showstyle","pagesize","pageindex");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/")+1);
    
    var strSearchType
    var arrValue;
    
    if(config.BogusStatic)
    {
        var values = url.substring(0,url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        strSearchType = arrValue[0].split("_")[0];
        arrValue.shift();
        arrValue[2] = unescape(arrValue[2]);
    }
    else
    {
        strSearchType = url.substring(0,url.lastIndexOf("." + config.Suffix));
        strSearchType = strSearchType.split("_")[0];
        
        arrValue = new Array(arrquery.length);
        for(var i =0; i<arrquery.length; i++) {
            arrValue[i] = GetQueryString(arrquery[i]);
        }
        arrValue[2] = unescape(arrValue[2]);
    }
    return {
        searchType:strSearchType,
        query:arrquery,
        value:arrValue,
        objData:{
            flag:arrValue[0],
            pt_id:arrValue[1],
            keyword:arrValue[2],
            tradeid:arrValue[3],
            order:arrValue[4],
            areaid:arrValue[5],
            times:arrValue[6],
            showstyle:arrValue[7],
            pagesize:arrValue[8],
            pageindex:arrValue[9]
        }
    };    
}

function CheckLemmaName(obj)
{
    var data = new SearchGetValue();
    var query = "&lemmaname=" + obj.value    
    var ajaxcls = new Ajax("xy041",query);
    ajaxcls.onSuccess = function() {       
        if (ajaxcls.state.result == "1") {
            if(ajaxcls.state.message!="")
            {
                //window.location.href = config.WebURL+'login.'+config.Suffix+'?surl='+escape();
                sAlert(ajaxcls.state.message);
                return false;
            }
            else
            {   
               $("frmlemma").submit();
            }
        }
    }
}

function GetBaikeSearchValue() {
    var arrquery = new Array("typeid","keyword", "pageindex");
    var url = location.href;

    //从地址中取得需要的数据
    url = url.substr(url.lastIndexOf("/") + 1);

    var arrValue;

    if (config.BogusStatic) {
        var values = url.substring(0, url.lastIndexOf("." + config.Suffix));
        arrValue = values.split("-");
        arrValue.shift();
        arrValue[2] = unescape(arrValue[2]);
    }
    else {
        arrValue = new Array(arrquery.length);
        for (var i = 0; i < arrquery.length; i++) {
            arrValue[i] = GetQueryString(arrquery[i]);
        }
        arrValue[2] = unescape(arrValue[2]);
    }

    for (var i = 0; i < arrquery.length; i++) {
        if (arrValue[i] == undefined || arrValue[i] == "undefined") arrValue[i] = "";
    }

    return {
        query: arrquery,
        value: arrValue,
        objData: {
            typeid: arrValue[0],
            keyword: arrValue[1],
            pageindex: arrValue[2]
        }
    };
}

function SetBaikeSearchDefaultValue() {
    var data = new GetBaikeSearchValue();
    if (data.objData.keyword.indexOf(",") != -1) {
        var arr = data.objData.keyword.split(",");
        $("txtkeyword").value = arr[0] == undefined ? "" : arr[0];
    }
    else {
        if (data.objData.keyword != "undefined")
            $("txtkeyword").value = data.objData.keyword;
    }
    try {
        $("typeid").value = data.objData.typeid;
        cla.Mode = "select";
        cla.Init();
    }catch (e) { }
}

function BaikeListSearch() {
    
    if (!CheckSearchKey($F("txtkeyword"))) return false;
    
    var data = new GetBaikeSearchValue();

    var href = config.WebURL + "baike/list";
    if (config.BogusStatic) {
        for (var i = 0; i < data.query.length; i++) {
            href += "-";

            if (data.query[i] == "typeid") {
                href += $F("typeid");
            }
            else if (data.query[i] == "keyword") {
                href += $F("txtkeyword");
            }
            else
                href += data.value[i];
        }
        href += "." + config.Suffix;
    }
    else {
        href += "." + config.Suffix;
        for (var i = 0; i < data.query.length; i++) {
            href += (0 == i ? "?" : "&") + data.query[i] + "=";
            if (data.query[i] == "typeid") {
                href += $F("typeid");
            }
            else if (data.query[i] == "keyword") {
                href += $F("txtkeyword");
            }
            else
                href += data.value[i];
        }

    }
    window.location = href;
}