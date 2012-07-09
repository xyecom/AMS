
function xy_TopLogin(){
    var username = $("top_username").value.trim();
    var password = $("top_password").value.trim();
    var vcode ="";
    try{vcode = $F("top_vcode")}catch(e){}

    _UserLogin(username,password,vcode,false);
}

function xy_BoxLogin(){
    var username = $("_lbox_username").value.trim();
    var password = $("_lbox_password").value.trim();
    var vcode ="";
    try{vcode = $F("_lbox_vcode")}catch(e){}

    _UserLogin(username,password,vcode,false);
}

//登陆信息
function UserLogin(isgo)
{
    var username = $("username").value.trim();
    var password = $("password").value.trim();
    var vcode ="";
    try{vcode = $F("vcode")}catch(e){}
    
    _UserLogin(username,password,vcode,isgo);
}

//信息页面右侧登录
function InfoLogin()
{
    var username = $("username").value.trim();
    var password = $("password").value.trim();
    var vcode ="";

    try{vcode = $F("vcode")}catch(e){}
        
    _UserLogin(username,password,vcode,"infoLogin");
}

//通用会员登录程序
function _UserLogin(username,password,vcode,isgo)
{
    var str_url=window.location.href;
    var str_pos=str_url.indexOf("=");
    var str_surl=str_url.substring(str_pos+1);

    
    if(username=="" || password=="")
    {
        sAlert("请输入用户名和密码");
        return false;
    }
        
    
    var url ="&Name="+username+"&pwd="+password+"&code="+vcode;
    //是否保存登录信息
    try
    {
        if($("saveinfo").checked==true) url+="&save=true";
    }catch(e){}
    
    //是否有其他参数(主要用来区分信息页面)
    if(arguments.length)url+="&Page="+arguments[0];
    
    sAlert("<img src =\"/common/images/ajax-loader.gif\"/><br/>正在登录，请稍候.....");
    
    var ajax = new Ajax("xy014",url);
    
    ajax.onSuccess = function(){
        if(ajax.state.result ==0 || ajax.state.result ==-1)
        {
            sAlert(ajax.state.message);
            ClearObjectValue("username","password","vcode");return false;
        }
        else
        {   
            //如果是信息页面登录并登录成功以后，更新页面信息
            if(ajax.state.message =="ok")
            {
                try{LoginUpdate();}catch(e){}
                try{sClose();}catch(e){}
                
                return;
            }
                        
            if(undefined == isgo) isgo = true;

            if(isgo) {
                //如果是通过登录页面登录，则导航到相应会员中心
                var folderName ="person";
                if(ajax.data.userinfo[0].usertype=="user")folderName="user";
        
                if(str_pos>0)
                    window.location.href=unescape(str_surl);
                else
                    window.location.href =config.WebURL + folderName + "/index." + config.Suffix;	
            }
            else {
                Login2();
                sClose();
            }
            return true;
        }
    }
}

/*function KeyDown()
{
    var gk=event.keyCode;
    if(gk==13) 
    {
        event.keyCode = 9;
        return; 
    }
}
function KeyDown2()
{
	var gk=event.keyCode;
	if(gk==13) 
	{
		UserLogin();
	}
}*/
//登陆获得的焦点
 function loginfocus()
{
	var UserName=getCookie("U_Name");
    $("username").value=UserName;
	if(UserName!="")
	{
	  $("password").focus();
	  $("saveinfo").checked='checked';
	}
	else
	{
	  $("username").focus();
	}
}


/***********************************************************************************/
/*                        找回密码相关                                             */
/***********************************************************************************/

function checkpassword()
{
	if($F("username")==""){return alertmsg(false,'请输入您注册的用户名！');}
	if($F("question")==""){return alertmsg(false,'请输入密码提示问题！');}
	if($F("answer")==""){return alertmsg(false,'请输入密码提示问题答案');}
	if($F("newpwd")==""){return alertmsg(false,'请输入新的密码')}
	
	if($F("npassword")==""){return alertmsg(false,'请再此输入密码');}
	else{getuserpassword();}
}

function getuserpassword()
{
    var url ="&userName="+$F("username")+"&question="+$F("question")+"&answer="+$F("answer")+"&newPwd="+$F("newPwd");
    var ajax = new Ajax("XY020",url);
    ajax.onSuccess = function(){
        sAlert(ajax.state.message);
        
        if(ajax.state.result ==0 || ajax.state.result ==-1){
           }
        else{
            GoTo(config.WebURL +"login."+config.Suffix);
        }
    }
}	




 var txtobjm = new Array("username","question","answer","newpwd","npassword");
    // 获取焦点时显示的文字
    var tm = new Array(5);
    tm[0] = "请输入注册时的用户名！";
    tm[1] = "您注册时填写的密码提示问题！";
    tm[2] = "输入您注册时填写的密码提示问题答案！"
    tm[3] = "6-20位(不能包含汉字), 不能与用户名相同";//密码问题
    tm[4] = "请再输入一遍上面填写的密码！";//密码答案
    // 所填信息正确时显示的文字
    var t2 = "正确！请继续！";
    // 所填信息错误时显示的文字
    var txm = new Array(5);
    txm[0] = "输入注册时填写的用户名";
    txm[1] = "您注册时填写的密码提示问题";
    txm[2] = "输入您注册时填写的密码提示问题答案";
    txm[3] = "6-20位(不能包含汉字), 不能与用户名相同";
    txm[4] = "请再输入一遍上面填写的密码。 ";



    // 样式
    var cm = new Array(4);
    cm[0] = "three";	// 默认
    cm[1] = "write";	// 获得焦点
    cm[2] = "right";	// 正确
    cm[3] = "wrong";	// 错误


    function getobjm(objName)
    {
        if ($) {return eval('$("'+ objName +'")');}
        else {return eval('document.all["'+ objName +'"]');}
    }
    // 获得焦点
    function fsm(num)
    {
        var obj = "txt"+num;
        getobjm(obj).setAttribute("className",cm[1]);
        getobjm(obj).innerHTML =tm[num];
    }
    // 正确
    function okm(num)
    {   	     
        var obj = "txt"+num;
        getobjm(obj).setAttribute("className",cm[2]);
        getobjm(obj).innerHTML =  t2;
    }
    // 错误
    function errm(num)
    {
        var obj = "txt"+num;
        getobjm(obj).setAttribute("className",cm[3]);
        getobjm(obj).innerHTML =  txm[num];
    }

    function okum(num,ms)
    {   	     
        var obj = "txt"+num;
        getobjm(obj).setAttribute("className",cm[2]);
        getobjm(obj).innerHTML =ms;
    }


    // 错误
    function errum(num,ms)
    {
        var obj = "txt"+num;
        getobjm(obj).setAttribute("className",cm[3]);
        getobjm(obj).innerHTML =ms;
    }
	function chktxtPassword(num)
		{
		   var obj = "txt" + num;
		   var val = getobjm(txtobjm[num]).value;	// 获取文本框的值	
			switch (num)
			{		
				case "0":	//用户名
				  var j = 0;		
					for (var l=0;l<val.length;l++)
					{
						if (val.charCodeAt(l) > 127 || val.charCodeAt(l) < 0) j = j + 2
						else j = j + 1
					}
					if (val == "" || val.length <= 0) errm(num);
					else if (val.indexOf(" ") >= 0 ) errm(num);
					else if (j > 20) errm(num);
					else if (j < 4) errm(num);
				   else {okm(num);checkusername('a',val);}
				break;				    
				case "1":	// //密码提示问题
					 if(val=="") errm(num);
				   else okm(num)
					break;
				case "2":	//密码提示答案
				   if(val=="") errm(num);
				   else  okm(num);
					break;
			   case "3": //新密码
				 if(val=="") errm(num);
				   else if(val.length<6) errm(num);
				   else   okm(num);
					break;
				case "4":	//确认新密码
					if(val==""||val.length>20) errm(num);
				   else if(val.length<6) errm(num);
				   else if (getobjm("newpwd").value != val) errm(num);
				   else  okm(num);
					break;
			
			}
	}
	
	
	
// 验证用户名的有效性
function checkusername(Obj,Name){
	var ajax = new Ajax("XY016","&name="+Name);

    ajax.onSuccess = function(){
        if(ajax.state.result ==0 || ajax.state.result ==-1){
            okum(0,"用户信息存在，请继续！");
            $("question").value = ajax.data.question;
            $("btnResetPwd").disabled = false;
            return true;
        }
        else{
            $("btnResetPwd").disabled = true;
            errum(0,"此用户名不存在");return false;
        }
    }
    return false;
}

//通过Email找回密码
//Tc 081110 add
function RetakePasswordByEmail(){
    var email = $F("email");
    
    if(!ValidateEmail(email)){
        sAlert("邮箱格式不正确");
        return false;
    }
    
    $("btnFindPwd").disabled = true;
	var ajax = new Ajax("xy029","&email="+email);
    ajax.onSuccess = function(){
        if(ajax.state.result ==0 || ajax.state.result ==-1){
            sAlert(ajax.state.message);
        }
        else{
        
            sAlert("密码已发送到邮箱");;
        }
        $("btnFindPwd").disabled = false;
    }    
}

function GetUserInfo() {
    return {
        UserID:getCookie("UserId"),
        UserName:getCookie("UserName"),
        UserType:getCookie("UserType"),
        UserLevel:getCookie("UserLevel"),
        UserLevelImg:getCookie("UserLevelImg")
    }
}

function Islogin() {
    return "" != GetUserInfo().UserName
}

function UserStatus() {
    var userinfo = GetUserInfo();
    var html = '';
    if(Islogin()) {
        html += '<a href="' + config.WebURL + 'Logout.' + config.Suffix + '">退出系统</a>|';
        html += '<a href="' + config.WebURL + '' + userinfo.UserType + '/index.' + config.Suffix + '">我的用户中心</a>';
    }
    else {
        html += '<a href="' + config.WebURL + 'Register.' + config.Suffix + '">现在注册</a>|';
        html += '<a href="' + config.WebURL + 'Login.' + config.Suffix + '">登录系统</a>';
    }
    document.write(html);
}

function Login() {
    var userinfo = GetUserInfo();
    if(Islogin()) {
        $("login").style.display = "none";
        $("logined").style.display = "";
        
        if("" == userinfo.UserLevelImg) userinfo.UserLevelImg = "Default.gif";
        
        var ulevel = "";
        var ulevelimg = "";
        if("user" == userinfo.UserType.toLowerCase()) {
            ulevel = userinfo.UserLevel;
            ulevelimg = config.WebURL + 'Icon/' + userinfo.UserLevelImg;
            $("logined_user").style.display = "";
        }
        else {
            ulevel = '个人会员';
            $("ulevelimg").style.display = "none";
            $("logined_person").style.display = "";
        }
            
        
        
        $("uname").innerHTML = userinfo.UserName;
        $("ulevel").innerHTML = ulevel;
        $("ulevelimg").src = ulevelimg;
        
        $("ucenter").href = config.WebURL + '' + userinfo.UserType + '/index.' + config.Suffix;
        $("loginout").href = config.WebURL + 'Logout.' + config.Suffix ;
        
        
        html += '<li><a href="' + config.WebURL + '' + userinfo.UserType + '/index.' + config.Suffix + '">我的用户中心</a></li>';
        html += '<a href="' + config.WebURL + 'Logout.' + config.Suffix + '">退出系统</a>';
        html += '</ul>';
    }
    else {
        $("login").style.display = "";
        $("logined").style.display = "none";
    }
}

function Login2() {
    var userinfo = GetUserInfo();
    var html = '';
    if(Islogin()) {

        try{$("login").style.display = "none";}catch(e){}
        try{$("logined").style.display = "";}catch(e){}
        
        try{$("xy_login_nologin").style.display = "none";}catch(e){}
        try{$("xy_login_logined").style.display = "";}catch(e){}
        
        if("user" == userinfo.UserType.toLowerCase()) {
            $("logined_user").style.display = "";
        }
        else {
            $("logined_person").style.display = "";
        }

        if($("ulevelimg")) {
	        if("" == userinfo.UserLevelImg) userinfo.UserLevelImg = "Default.gif";
	        
	        var ulevelimg = "";
	        if("user" == userinfo.UserType.toLowerCase()) {
	            $("ulevelimg").src = config.WebURL + 'Icon/' + userinfo.UserLevelImg;
	        }else{
	            $("ulevelimg").style.display = "none";
	        }
        }
        
        try{$("uname").innerHTML = userinfo.UserName;}catch(e){}
        try{$("ucenter").href = config.WebURL + '' + userinfo.UserType + '/index.' + config.Suffix;}catch(e){}
        
        try{$("_lbox_uname").innerHTML = userinfo.UserName;}catch(e){}
        try{$("_lbox_ucenter").href = config.WebURL + '' + userinfo.UserType + '/index.' + config.Suffix;}catch(e){}
    }else {

        try{$("login").style.display = "";}catch(e){}
        try{$("logined").style.display = "none";}catch(e){}
        
        try{$("xy_login_nologin").style.display = "";}catch(e){}
        try{$("xy_login_logined").style.display = "none";}catch(e){} 
    }
}

