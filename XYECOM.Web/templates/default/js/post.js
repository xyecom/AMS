
//获取自定义字段信息
function GetFieldInnerHTML()
{
    var moduleName = $F("hidModuleName");
    var typeId = $F("hidTypeId");
    
    document.getElementById("tabFieldBody").innerHTML = XY_LOADING_SMALL;
    
    var ajax = new Ajax("XY032","&module="+moduleName +"&typeid=" + typeId);
    ajax.onSuccess = function(){
        if(ajax.state.result == 1){        
            document.getElementById("tabFieldBody").innerHTML = "<table class=\"c1_table\" width=\"100%\">" + unescape(ajax.data.html) + "</table>";
            return true;
        }
    }
    return false;

}
//验证是否是数字
function IsNum(str) {

    var re = /^[\d]+$/
    return re.test(str);

}
function CheckValuebuy() {
    var title = document.getElementById("title").value;
    var keyword = document.getElementById("keyword").value;
    var num = document.getElementById("num").value;
   
    var contents = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true);
    var linkman = document.getElementById("linkman").value;
   
    var tel = document.getElementById("tel").value;
    var jinji;

    if (title == "") {
        return alertmsg(false, '请输入求购标题！');
    }
    if (keyword == "") {
        return alertmsg(false, '请输入产品关键字');
    }

    if (!IsNum(num)) return alertmsg(false, '产品数量为数字！');

    if (contents == "") return alertmsg(false, '产品要求不能为空！');

    if (linkman == "") return alertmsg(false, '请输入联系人姓名！');

    if (tel == "") return alertmsg(false, '请输入联系电话！');
    return true;
}
//初始化信息新增页面
function InitInfoAddPageForm(moduleName,moduleParentName,infoType){
    if(moduleName =="investment" || moduleParentName == "investment")
    {
        if(infoType=="buy")
        {
            $("tabInvestmentBuy").style.display ="";
            $("tabInvestmentSell").style.display ="none";
        }
        else
        {
            $("tabInvestmentBuy").style.display ="none";
            $("tabInvestmentSell").style.display ="";
        }
    }
}

function showcityname(num)
{
    if(num==1)
    {
        $("cityl").checked=false;
        $("cityls").style.display="none";
        $("city").value="全国";
    }
    else
    {
        $("cityls").style.display="block";
        $("cityl").checked=true;
        $("citys").checked=false;
        $("city").value="";
   }
}


//信息基本验证
//tc 08-11-6
function InfoBaseCheck(){
    var title = $("infotitle").value.trim();
    var infoType = $F("hidInfoType");
    var typeId = $F("hidTypeId");
   

    if(title=="" || title ==infoType )
    {
        return alertmsg(false,'请输入信息标题！');
    }    
    
    if(typeId=="" || typeId==0)
    {
        return alertmsg(false,'请选择信息类别！');
    }
    return true;    
}


function CheckInfoEditFrom(moduleName,moduleParentName){

    if(!InfoBaseCheck())return false;

    var infoCheckResult = false;
    if(moduleName=="offer"||moduleParentName=="offer") {
        infoCheckResult =  checkofferinfo();
    }
    if(moduleName=="venture"||moduleParentName=="venture") {
        infoCheckResult =  checkmachininginfo();
    }
    if(moduleName=="investment"||moduleParentName=="investment") {
        infoCheckResult = checkinvestmentinfo();
    }
    if(moduleName=="service"||moduleParentName=="service") {
        infoCheckResult =  checksurrogateinfo();
    }

    if(!infoCheckResult)return false;
    
    if($("vcode"))
    {
        var code = $F("vcode").trim();
        if(code==""){
            return alertmsg(false,'请输入正确的验证码！');
        }
    }

    $("frmQuickPostInfo").submit();
    
    return false;
}

//用户信息验证
//tc 08-11-6
function UserInfoCheck(){   
    
    var usertype = $R("usertype");
        
    if(usertype=="")
    {
        $("frmQuickPostInfo").submit();
        return true;
    }
   
    if($("vcode"))
    {
        var code = $F("vcode").trim();
        if(code=="")return alertmsg(false,'请输入正确的验证码！');
    }
   
    if(usertype=="user"){

        var username = $F("username").trim();
        var userpwd = $F("userpwd").trim();
        var issave = "true";        
            
        if(username=="" || username.length < 4 || !ValidateS(username)){
            return alertmsg(false,'请输入正确的用户名！');
        }
        
        if(userpwd == "" || userpwd.length < 6){
            return alertmsg(false,'请输入正确的密码！');
        }
        
        $("frmQuickPostInfo").submit();
        return true;        
    }else if(usertype=="guest"){
    
        var guestusername =$F("guestusername");
        var guestuserpwd = $F("guestuserpwd");
        var unitname = $F("unitname").trim();
        var linkman = $F("linkman").trim();
        var telephone = $F("telephone").trim();
        var mobile  = $F("mobile").trim();
        var email = $F("email").trim();
        
        if(guestusername=="" || guestusername.length < 4 || !ValidateS(guestusername)){
            return alertmsg(false,'请输入正确的用户名！');
        }
        
        if(guestuserpwd == "" || guestuserpwd.length < 6){
            return alertmsg(false,'请输入正确的密码！');
        }
    
        if(unitname=="" || unitname.length<2) return alertmsg(false,'请输入企业名称(用户名称)！');
        
        if(linkman=="" || linkman.length < 2) return alertmsg(false,'请输入联系人姓名！');
        
        if(telephone == "") return alertmsg(false,'请输入联系电话！');
        
        telephone = ReplaceAll(telephone,'，',',');
        
        var teles = telephone.split(",");
        
        for(var i=0;i<teles.length;i++){
            if(!ValidateTel(teles[i])){
                return alertmsg(false,'固定电话号码格式不正确！');    
                break;
            }
        }
        
        if(telephone ==""){
            mobile = ReplaceAll(mobile,'，',',');
            var mobs = mobile.split(",");
            for(var i=0;i<mobs.length;i++){
                if(!ValidateMobileTel(mobs[i])){
                    return alertmsg(false,'手机号码格式不正确！');    
                    break;
                }
            }
        }
        
        if(email == "")return alertmsg(false,'请输入电子邮箱地址！');  
        
        if(!ValidateEmail(email))return alertmsg(false,'电子邮箱格式不正确！'); 

        $("step_msg").innerHTML =XY_LOADING_SMALL + "  正在验证用户名，请稍候...";
        
	    var ajax = new Ajax("XY016","&name="+guestusername);
        ajax.onSuccess = function(){
            if(ajax.state.result ==0)
            {
                $("step_msg").innerHTML = "此用户用已经被使用";
                return false;
            }
            else
            {
                $("step_msg").innerHTML =XY_LOADING_SMALL + "  正在验证邮箱，请稍候...";
        
                ajax = new Ajax("XY017","&email="+email);
                ajax.onSuccess = function(){
                    if(ajax.state.result ==0)
                    {
                        $("step_msg").innerHTML = "邮箱已经被注册，请选用其他邮箱";
                        return false;
                    }else{
                        $("frmQuickPostInfo").submit();
                        return true;
                    }
                }
            }
        }
    }
    
    return false;
}

//验证供求信息
function checkofferinfo()
{
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    if(content=="")
    {
        return alertmsg(false,'详细说明为必填项，请检查！');
    }

    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
        return alertmsg(false,'请选择信息有效时间！');
        }
    }
    if($("txtsprice").value == "")
    {
       return alertmsg(false,"请输入单价！");
    }
    if($("txtsprice").value != "" && $("txtsprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) 
    {
        return alertmsg(false,'单价输入有误，请检查！');
    }            
    if($("txtssmallnum").value != "" && $("txtssmallnum").value.search(/^[-\+]?\d+$/) == -1)
    {
        return alertmsg(false,'最小起定量必须为整数，请检查！');
    }
    
    if($("txtscountnum").value != "" && $("txtscountnum").value.search(/^[-\+]?\d+$/) == -1)
    {
        return alertmsg(false,'货物总量必须为整数，请检查！');
    }
    return true;
}

//验证加工信息
function checkmachininginfo()
{
    try{
	if($F("hidTypeId")=="" || $F("hidTypeId")=="0")
	{
		return alertmsg(false,'请选择信息类别！');
	}}catch(e){}
	
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    
    if(content=="")
    {
        return alertmsg(false,'详细说明为必填项，请检查！');
    }

    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
        return alertmsg(false,'请选择信息有效时间！');
        }
    }
    if($("txtcprice").value != "" && $("txtcprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) 
    {
        return alertmsg(false,'单价输入有误，请检查！');
    }  
     if($("txtcsmallnum").value != "" &&　$("txtcsmallnum").value.search(/^[-\+]?\d+$/) == -1)
    {
    return alertmsg(false,'最小起定量必须为整数，请检查！');
    }
    if($("txtccountnum").value != "" && $("txtccountnum").value.search(/^[-\+]?\d+$/) == -1)
    {
    return alertmsg(false,'货物总量必须为整数，请检查！');
    }
    return true;
}
//验证招商信息
function checkinvestmentinfo()
{
    try{
	if($F("hidTypeId")=="" || $F("hidTypeId")=="0")
	{
		return alertmsg(false,'请选择信息类别！');
	}}catch(e){}
	
	    
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    if(content=="")
    {
        return alertmsg(false,'详细说明为必填项，请检查！');
    }
    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
            return alertmsg(false,'请选择信息有效时间！');
        }
    }
    if($("txtsupport").value.length>4000)
    {
    return alertmsg(false,'招商支持内容过长，请检查！');
    }
   if($("txtdemand").value.length>4000)
    {
    return alertmsg(false,'招商要求内容过长，请检查！');
    }
  
   if($("pageurl").value!="")
    {
         if($("pageurl").value.search(/^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&amp;_~`@[\]\’:+!]*([^&lt;&gt;\"\"])*$/) == -1 && $("pageurl").value !="http:\/\/")
	    {
	    return alertmsg(false,'输入网址格式错误！\n http://www.xmusix.com');
	    }
    }
    return true;
}

//验证代理信息
function checksurrogateinfo()
{
    try{
	if($F("hidTypeId")=="" || $F("hidTypeId")=="0")
	{
		return alertmsg(false,'请选择信息类别！');
	}}catch(e){}
	
	
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    
    if(content=="")
    {
        return alertmsg(false,'详细说明为必填项，请检查！');
    }
    
    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
        return alertmsg(false,'请选择信息有效时间！');
        }
    }
    return true;
}


function SelectUser(usertype){
    if(usertype=="guest"){
        $("step_msg").innerHTML ="请输入以下信息，完成会员快速注册";
        $("tab_user_info").style.display="none";
        $("tab_guest_info").style.display="";
    }
    
    if(usertype=="user"){
        $("step_msg").innerHTML ="";
        $("tab_user_info").style.display="";
        $("tab_guest_info").style.display="none";
    }
}