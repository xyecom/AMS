var joinType = "user";
var claarea;

function joinInit() {

    if(!Islogin()) {
        SetUserState(1);
    }
    else {
        SetUserState(2);
    }
    
    var ajax = new Ajax("xy036","&module=investment");
    ajax.onSuccess = function() {        
        if(ajax.state.result == "1") {
            var html1 = "";
            for(var imsg = 0; imsg < ajax.data.msglist.length; imsg++) {
                html1 += "<input type =\"checkbox\"  value =\"" + ajax.data.msglist[imsg].title + "\"  name =\"symess\" onclick =\"SetMessage();\"/>" + ajax.data.msglist[imsg].title + "<br />";
            }
            $("ks").innerHTML = html1;
        }
    }
    
    //设置代理地区    
    var areas = $F("_param_onlinejoin_Areas");
    if("全国" == areas) areas = "";
    if("" != areas) {
        var ajaxarea = new Ajax("xy001","&module=area&Mode=GetInfos&strID=" + areas)
        ajaxarea.onSuccess = function() {
            if(ajaxarea.state.result ==0 || ajaxarea.state.result ==-1) {
                sAlert(ajaxarea.state.message);
            }
            else {
                var html = '';
                for(i=0;i<ajaxarea.data.Item.length;i++) {
                    html += '<input type="checkbox" name="cblareas" value="' + ajaxarea.data.Item[i].ID + '" onclick="SelectArea();" />' + unescape(ajaxarea.data.Item[i].Name);                   
                }
                $("areas").innerHTML = html;
            }
        }
    }
    else {
        claarea = new ClassTypes("claarea","area","areas","hidareas");
        claarea.Init();
    }
}

function SelectArea() {
    var info="";
    var chkother= document.getElementsByName("cblareas");
    for (var i=0;i<chkother.length;i++)
    {
	    if( chkother[i].type=='checkbox')
	    {
	        if(chkother[i].checked == true)
		    {
            	if("" == info)
            	    info = chkother[i].value;
            	else
            	    info += "," + chkother[i].value;
		    }
	    }
    }
    $("hidareas").value=info;
}

function SetMessage() {
    var info="";
    var chkother= document.getElementsByName("symess");
    for (var i=0;i<chkother.length;i++)
    {
	    if( chkother[i].type=='checkbox')
	    {
    		
	        if(chkother[i].checked == true)
		    {
            	     info+=chkother[i].value+'\n';  				
		    }
    		
	    }
    }
    $("txtcontent").value=info;
}

function SetUserState(ac) {
    if(1 == ac) {
        $("tab1").className = "now";
        $("tab2").className = "";
        $("_onlinejoin_guest").style.display = "";
        joinType = "guest";
    }
    else {
        $("tab1").className = "";
        $("tab2").className = "now";
        $("_onlinejoin_guest").style.display = "none";
        joinType = "user";
    }
}

function joinSend() {
    if("user" == joinType) {
        if(!Islogin()) {
            sAlert("您还没有登陆，请先登陆！",config.WebURL+'login.'+config.Suffix+'?surl='+escape(window.location.href));
        }
        else {
            if(chkMsg()) {
                
                sAlert(XY_LOADING);
                
                var ajax = new Ajax("xy039",GetValues(2));
                ajax.onSuccess = function() {
                    if(ajax.state.result == 0 || ajax.state.result ==-1) {
                        sAlert(ajax.state.message);
                    }
                    else {
                        if("1" == ajax.data.MsgState) {
                            sAlert("提交成功！");
                            $("frmjoin").reset();
                        }
                        else {
                            sAlert(ajax.state.message);
                        }
                    }
                }
            }
        }
    }
    else {
        if(chkGuestMsg()) {
            
            sAlert(XY_LOADING);
            
            var ajax = new Ajax("xy039",GetValues(1));
            ajax.onSuccess = function() {
                if(ajax.state.result == 0 || ajax.state.result ==-1) {
                    sAlert(ajax.state.message);
                }
                else {
                    if("1" == ajax.data.MsgState) {
                        sAlert("提交成功！系统为您新注册了账户。<br />用户名:" + ajax.data.UserName + "密码:" + $F("gpwd") + "<br />下次可直接登陆。");
                        $("frmjoin").reset();
                    }
                    else {
                        sAlert("提交信息失败，但注册成功！系统为您新注册了账户。<br />用户名:" + ajax.data.UserName + "密码:" + $F("gpwd") + "<br />下次可直接登陆。");
                    }
                }
            }
        }
    }
}

function GetValues(type) {
    var val = "";
    if(1 == type) {
        val += "&linkman=" + $F("glinkman") + "&email=" + $F("gemail") + "&telphone=" + $F("gtelphone");
        val += "&mobile" + $F("gmobile") + "&unitname=" + $F("gunitname") + "&pwd=" + $F("gpwd")
    }
    
    val += "&investmentid=" + $F("_param_onlinejoin_infoid") + "&quondamproduct=" + $F("quondamproduct") + "&areas=" + $F("hidareas") + "&title=" + $F("txttitle") + "&content=" + $F("txtcontent");
    
    if($("txtcode")) {
        val += "&code=" + $F("txtcode");
    }
    return val;
}

function chkGuestMsg() {
    var linkman = $F("glinkman");
    var email = $F("gemail");
    var telphone = $F("gtelphone");
    var mobile = $F("gmobile");
    var unitname = $F("gunitname");
    var pwd = $F("gpwd");
    
    if("" == linkman) {
        sAlert("请填写联系人！");
        return false;
    }
    
    if("" == email) {
        sAlert("请填写Email！");
        return false;
    }
    
    if(!ValidateEmail(email)) {
        sAlert("Email格式不正确，请重新填写！");
        return false;
    }
    
    if("" == telphone && "" == mobile) {
        sAlert("固定电话和手机必须填写一个！");
        return false;
    }
    
    if("" != telphone) {
        if(!ValidateTel(telphone)) {
            sAlert("固定电话格式不正确，请重新填写！");
            return false;
        }
    }
    
    if("" != mobile) {    
        if(!ValidateMobileTel(mobile)) {
            sAlert("手机号码格式不正确，请重新填写！");
            return false;
        }
    }
    
    if("" == unitname) {
        sAlert("请填写企业名称！");
        return false;
    }
    
    if("" == pwd) {
        sAlert("请填写密码，以便下次登陆！");
        return false;
    }
    
    if(pwd.length < 6) {
        sAlert("密码至少6位！");
        return false;
    }
    
    return chkMsg();
}

function chkMsg() {
    var infoid = $F("_param_onlinejoin_infoid")
    var areas = $F("hidareas");
    var title = $F("txttitle");
    var content = $F("txtcontent");
    
    if("" == infoid) {
        sAlert("信息ID不能为空，请检查参数是否正确！");
        return false;
    }
    
    if("" == areas) {
        sAlert("请选择您准备代理的地区！");
        return false;
    }
    if("" == title) {
        sAlert("请填写留言标题！");
        return false;
    }
    if("" == content) {
        sAlert("请填写留言内容！");
        return false;
    }
    
    if($("txtcode")) {
        if("" == $F("txtcode")) {
            sAlert("请填写验证码！");
            return false;
        }
    }
    return true;
}

