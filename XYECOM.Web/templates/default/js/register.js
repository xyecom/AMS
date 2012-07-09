// JScript 文件

function CheckRegForm()
{
    var userType = $R("usertype");

    if(userType =="enterprise")
    {    
        if($F("tradeid").trim()=="" || $F("tradeid").trim()=="0")
        {
            return alertmsg(false,'请选择企业所属行业！');
        } 
    } 
    
    if ($("loginname").value==""||$("loginname").value.length<4){
        $("loginname").focus();
        return false;
    }
    
    //判断是否包含有汉字
    if(!ValidateS($("loginname").value.trim())){
        $("loginname").select();
        return false; 
    }
    if ($("password").value == "" || $ ("password").value.length < 6){
        $ ("password").focus();
        return false;
    }
    
    if ($("repassword").value == "" || $("repassword").value.length < 6){
        $("repassword").focus();
        return false;
    }
    
    if ($("password").value != $("repassword").value){
        $("repassword").focus();
        return false;
    }
    
    if ($("question").value == ""||$("question").value.length< 6){
        $("question").focus();
        return false;
    }
    
    if ($("answer").value == "" || $("answer").value.length < 6){
        $("answer").focus();
        return false;
    }
    
    if($("vcode") && $F("vcode")=="")
    {
        $("vcode").focus();
        return false;
    }

    if (!LimitWord($("loginname"),"用户名",15)) return false;
    
    if (!LimitWord($("password"),"密码",15)) return false;
   
    
    if($("email").value=="") {
        $("email").focus();
        return false;
    }
	else if (!ValidateEmail($F("email"))) {
	    $("email").focus();
	    return false;
	}
	else if(!validateemail('spanemail',$F("email"))) {
	    $("email").focus();
	    return false;
	}
	
	var ajax = new Ajax("XY017","&email="+$("email").value);
    ajax.onSuccess = function(){
        if(ajax.state.result ==0)
        {
            $("email").focus();err(5);return false;
        }
    }
   
    if(!$("agreement").checked)
    {
        alertmsg(false,'请选择默认协议！',config.WebURL+"register."+config.Suffix); 
        return false;
    }
      
    return true;
}

//简洁模式注册新用户
function NormalModelRegUser()
{
    if(CheckRegForm())$("frmRegister").submit();
}

//完整模式注册新用户(企业用户)
function FullModelRegUser()
{
    if(!CheckRegForm())return false;
    
    var linkman = $F("linkman").trim();
    var telephone = $F("telephone").trim();
    var fax = $F("fax").trim();
    var mobile  = $F("mobile").trim();
    
    if(linkman=="" || linkman.length < 2) return alertmsg(false,'请输入联系人姓名');
        
    if(telephone == "") return alertmsg(false,'请输入联系电话');
    
    telephone = ReplaceAll(telephone,'，',',');
    
    var teles = telephone.split(",");
    
    for(var i=0;i<teles.length;i++){
        if(!ValidateTel(teles[i])){
            return alertmsg(false,'固定电话号码格式不正确');    
            break;
        }
    }
    
    if(fax.trim() != ""){
        fax = ReplaceAll(fax,'，',',');
        
        var faxs = fax.split(",");
        
        for(var i=0;i<faxs.length;i++){
            if(!ValidateTel(faxs[i])){
                return alertmsg(false,'传真号码格式不正确');    
                break;
            }
        }
    }

    if(mobile != ""){
        mobile = ReplaceAll(mobile,'，',',');
        var mobs = mobile.split(",");
        for(var i=0;i<mobs.length;i++){
            if(!ValidateMobileTel(mobs[i])){
                return alertmsg(false,'手机号码格式不正确');    
                break;
            }
        }
    }

    if($F("areaid").trim()=="" || $F("areaid").trim()=="0")
    {
        return alertmsg(false,'请选择所在区域');
    }
    
    
    if($F("zipcode").trim()!="")
    {
        if($F("zipcode").search(/^[-\+]?\d+$/) == -1)
        {
            return alertmsg(false,'邮政编码必须为整数！');
        }
        else if($F("zipcode").search(/^\d{6}$/)==-1)
        {
            return alertmsg(false,'邮政编码格式有误！');
        }
    }
        
    if($F("address").trim()=="")
    {
        return alertmsg(false,'请输入联系地址');
    }
    
    if($F("enterprisename").trim()=="")
    {
        return alertmsg(false,'请输入公司名称');
    }
    
    if($F("typeid").trim()=="" || $F("typeid").trim()=="0")
    {
        return alertmsg(false,'请选择企业类别！');
    } 
    
    $("frmRegister").submit();
}

function FullModelRegIndividual()
{
    if(!CheckRegForm())return false;
    
    var i_realname = $F("i_realname").trim();
    var i_idcard = $F("i_idcard").trim();
    var i_telephone = $F("i_telephone").trim();
    var i_mobile = $F("i_mobile").trim();
    var i_zipcode = $F("i_zipcode").trim();
    var i_address = $F("i_address").trim();
    
    if(i_realname=="" || i_realname.length < 2) return alertmsg(false,'请输入真实姓名');    
    
    if(i_idcard!="" && !ValidateIdCode(i_idcard)){
        return alertmsg(false,'身份证号码格式不正确');    
    }
    
    if(i_telephone == "") return alertmsg(false,'请输入联系电话');
    
    var teles = i_telephone.split(",");
    
    for(var i=0;i<teles.length;i++){
        if(!ValidateTel(teles[i])){
            return alertmsg(false,'固定电话号码格式不正确');    
            break;
        }
    }
    
    if(i_mobile != ""){
        i_mobile = ReplaceAll(i_mobile,'，',',');
        var mobs = i_mobile.split(",");
        for(var i=0;i<mobs.length;i++){
            if(!ValidateMobileTel(mobs[i])){
                return alertmsg(false,'手机号码格式不正确');    
                break;
            }
        }
    }
    
    if(i_zipcode!="")
    {
        if(!ValidateZipCode(i_zipcode))
        {
            return alertmsg(false,'邮政编码格式有误！');
        }
    }
    
    $("frmRegister").submit();
}

function isDigit(Field)
{
	var patrn=/^[0-9]{4}$/;
	if (!patrn.exec(Field.value)) 
	{
		Field.value = "";
		Field.focus();
		return false;
	}
	return true;
}
function LimitWord(Field,str,limit)
{
	if (Field.value.length > limit)
	{
		Field.select();
		return false;
	}
	return true;
}

var txtobj = new Array("loginname","password","repassword","question","answer","email","");
//var img1 = "<img src='images/write.gif'  align='absmiddle'>";	// 获得焦点
//	var img2 = "<img src='images/right.gif'  align='absmiddle'>";	// 所填信息正确
//var img3 = "<img src='images/mistake.gif'  align='absmiddle'>";	// 所填信息错误
// 获取焦点时显示的文字
var t1 = new Array(6);
t1[0] = "4-15位,数字(0-9)或英文(a-z),不支持中文。注册成功后不可修改";
t1[1] = "6-20位, 不能与用户名相同；建议为英文字母(a-z)和数字(0-9)结合";
t1[2] = "请再输入一遍上面填写的密码"
t1[3] = "请填写自己最熟悉的问题，最少输入6位";//密码问题
t1[4] = "密码提示答案不能与密码提示问题相同，最少输入6位";//密码答案
t1[5] = "请务必填写真实，并确认是您最常用的电子邮件";
t1[6] = "请选择注册会员类型";

// 所填信息正确时显示的文字
var t2 = "正确！请继续！";
// 所填信息错误时显示的文字
var t3 = new Array(6);
t3[0] = "4-15位,数字(0-9)或英文(a-z),不支持中文。注册成功后不可修改";
t3[1] = "6-20位，不能与用户名相同；建议为英文字母(a-z)和数字(0-9)结合";
t3[2] = "请再输入一遍上面填写的密码";
t3[3] = "请填写自己最熟悉的问题，最少6位";
t3[4] = "提示答案不能与提示问题或登录名相同，最少6位";
t3[5] = "邮件格式不正确或者已被注册";
t3[6] = "请选择注册会员类型";


// 样式
var c = new Array(4);
c[0] = "three";	// 默认
c[1] = "write";	// 获得焦点
c[2] = "right";	// 正确
c[3] = "wrong";	// 错误


function getobj(objName)
{
	if ($) 
	{
	    return eval('$("'+ objName +'")');
	}
	else 
	{
	    return eval('document.all["'+ objName +'"]');
	}
}
// 获得焦点
function f(num)
{
  	var obj = "txt"+num;
	//getobj(obj).setAttribute("className",c[1]);
	getobj(obj).className = c[1];
	getobj(obj).innerHTML =t1[num];
}
// 正确
function ok(num)
{   	     
	var obj = "txt"+num;
	//getobj(obj).setAttribute("className",c[2]);
	getobj(obj).className = c[2];
	getobj(obj).innerHTML =  t2;
}
// 错误
function err(num)
{
	var obj = "txt"+num;
	//getobj(obj).setAttribute("className",c[3]);
	getobj(obj).className = c[3];
	getobj(obj).innerHTML =  t3[num];
}

function chktxt(num)
{
   var obj = "txt" + num;

   var val = getobj(txtobj[num]).value;	// 获取文本框的值

	switch (num)
	{
		case "0":	//用户名
			var j = 0;		// 检查字符长度
			for (var l=0;l<val.length;l++)
			{
				if (val.charCodeAt(l) > 127 || val.charCodeAt(l) < 0) j = j + 2
				else j = j + 1
			}
			
			if (val == "" || val.length <= 0) err(num);
			else if (val.indexOf(" ") >= 0 ) err(num);
			else if (j > 20) err(num);
			else if (j < 4) err(num);
			else if (IsIncludeChinese(val))err(num);
			else {ok(num);chkname('a',val);}
			break;
		    
		case "1":	// 密码
			if (val == "" || val.length <6) err(num);
			else if (val.length > 15) err(num);
			else ok(num);
			break;
		case "2":	// 验证密码
			if (val == "" || val.length <= 5) err(num);
			else if (getobj("password").value != val) err(num);
			else ok(num);
			break;
		case "3":	//密码保护问题
			if (val == "" || val.length <6) err(num);
			else ok(num);
			break;
		case "4":	//密码提示答案
			if (val == "" || val.length < 6) err(num);
			else if($("question").value==$("answer").value) err(num);
			else ok(num);
			break;
		case "5"://电子邮件      
			if (!ValidateEmail(val))err(num);
			else {ok(num);validateemail('spanemail',val);}
			break;
//		case "6": //会员类型
//			if( $("rdcompany").checked==false&&$("rdindividual").checked==false)err(num) ;
//			 else ok(num);break;
//			break;
		 
	}
}
		

// 验证用户名的有效性
function chkname(Obj,Name)
{
	getobj(Obj).innerHTML = "检测中，请稍候……";
	
	var ajax = new Ajax("XY016","&name="+Name);
    ajax.onSuccess = function(){
        
        getobj(Obj).innerHTML = (ajax.state.message);
        getobj(Obj).style.color="red";
        if(ajax.state.result ==0)
        {
            $("loginname").focus();err(0);return false;
        }
        else
        {
            return true;
        }
    }
 
    return false;
}
//验证邮件
function validateemail(obj,email)
{
    getobj(obj).innerHTML = "检测中，请稍候……";
    
	var ajax = new Ajax("XY017","&email="+email);
    ajax.onSuccess = function(){
        
        getobj(obj).innerHTML = (ajax.state.message);
        getobj(obj).style.color="red";
        if(ajax.state.result ==0)
        {
            $("email").focus();err(5);return false;
        }
        else
        {
            return true;
        }
    }
   
    return true;    
}


function displayDiv(){
    var userType = $R("usertype");
    
    if(userType =="enterprise"){
        try{document.getElementById("company1").style.display ="block";}catch(e){}
        try{document.getElementById("person").style.display ="none";}catch(e){}
        try{document.getElementById("ulTrade").style.display ="block";}catch(e){}
    }
    if(userType =="individual"){
        try{document.getElementById("company1").style.display ="none";}catch(e){}
        try{document.getElementById("person").style.display ="block";}catch(e){}
        try{document.getElementById("ulTrade").style.display ="none";}catch(e){}
    }
    
}

function isAgreement(obj){
    
    if(!obj.checked){
        try{$("btnBasicSubmit").disabled = true;}catch(e){}
        try{$("btnInfoSubmit").disabled = true;}catch(e){}
        try{$("btnPersonSubmit").disabled = true;}catch(e){}
    }else{
        try{$("btnBasicSubmit").disabled = false;}catch(e){}
        try{$("btnInfoSubmit").disabled = false;}catch(e){}
        try{$("btnPersonSubmit").disabled = false;}catch(e){}
    }
}

function phone()
{
    $("fax").value=$("telephone").value;
}
