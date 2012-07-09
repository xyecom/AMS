
//��ȡ�Զ����ֶ���Ϣ
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
//��֤�Ƿ�������
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
        return alertmsg(false, '�������󹺱��⣡');
    }
    if (keyword == "") {
        return alertmsg(false, '�������Ʒ�ؼ���');
    }

    if (!IsNum(num)) return alertmsg(false, '��Ʒ����Ϊ���֣�');

    if (contents == "") return alertmsg(false, '��ƷҪ����Ϊ�գ�');

    if (linkman == "") return alertmsg(false, '��������ϵ��������');

    if (tel == "") return alertmsg(false, '��������ϵ�绰��');
    return true;
}
//��ʼ����Ϣ����ҳ��
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
        $("city").value="ȫ��";
    }
    else
    {
        $("cityls").style.display="block";
        $("cityl").checked=true;
        $("citys").checked=false;
        $("city").value="";
   }
}


//��Ϣ������֤
//tc 08-11-6
function InfoBaseCheck(){
    var title = $("infotitle").value.trim();
    var infoType = $F("hidInfoType");
    var typeId = $F("hidTypeId");
   

    if(title=="" || title ==infoType )
    {
        return alertmsg(false,'��������Ϣ���⣡');
    }    
    
    if(typeId=="" || typeId==0)
    {
        return alertmsg(false,'��ѡ����Ϣ���');
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
            return alertmsg(false,'��������ȷ����֤�룡');
        }
    }

    $("frmQuickPostInfo").submit();
    
    return false;
}

//�û���Ϣ��֤
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
        if(code=="")return alertmsg(false,'��������ȷ����֤�룡');
    }
   
    if(usertype=="user"){

        var username = $F("username").trim();
        var userpwd = $F("userpwd").trim();
        var issave = "true";        
            
        if(username=="" || username.length < 4 || !ValidateS(username)){
            return alertmsg(false,'��������ȷ���û�����');
        }
        
        if(userpwd == "" || userpwd.length < 6){
            return alertmsg(false,'��������ȷ�����룡');
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
            return alertmsg(false,'��������ȷ���û�����');
        }
        
        if(guestuserpwd == "" || guestuserpwd.length < 6){
            return alertmsg(false,'��������ȷ�����룡');
        }
    
        if(unitname=="" || unitname.length<2) return alertmsg(false,'��������ҵ����(�û�����)��');
        
        if(linkman=="" || linkman.length < 2) return alertmsg(false,'��������ϵ��������');
        
        if(telephone == "") return alertmsg(false,'��������ϵ�绰��');
        
        telephone = ReplaceAll(telephone,'��',',');
        
        var teles = telephone.split(",");
        
        for(var i=0;i<teles.length;i++){
            if(!ValidateTel(teles[i])){
                return alertmsg(false,'�̶��绰�����ʽ����ȷ��');    
                break;
            }
        }
        
        if(telephone ==""){
            mobile = ReplaceAll(mobile,'��',',');
            var mobs = mobile.split(",");
            for(var i=0;i<mobs.length;i++){
                if(!ValidateMobileTel(mobs[i])){
                    return alertmsg(false,'�ֻ������ʽ����ȷ��');    
                    break;
                }
            }
        }
        
        if(email == "")return alertmsg(false,'��������������ַ��');  
        
        if(!ValidateEmail(email))return alertmsg(false,'���������ʽ����ȷ��'); 

        $("step_msg").innerHTML =XY_LOADING_SMALL + "  ������֤�û��������Ժ�...";
        
	    var ajax = new Ajax("XY016","&name="+guestusername);
        ajax.onSuccess = function(){
            if(ajax.state.result ==0)
            {
                $("step_msg").innerHTML = "���û����Ѿ���ʹ��";
                return false;
            }
            else
            {
                $("step_msg").innerHTML =XY_LOADING_SMALL + "  ������֤���䣬���Ժ�...";
        
                ajax = new Ajax("XY017","&email="+email);
                ajax.onSuccess = function(){
                    if(ajax.state.result ==0)
                    {
                        $("step_msg").innerHTML = "�����Ѿ���ע�ᣬ��ѡ����������";
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

//��֤������Ϣ
function checkofferinfo()
{
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    if(content=="")
    {
        return alertmsg(false,'��ϸ˵��Ϊ��������飡');
    }

    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
        return alertmsg(false,'��ѡ����Ϣ��Чʱ�䣡');
        }
    }
    if($("txtsprice").value == "")
    {
       return alertmsg(false,"�����뵥�ۣ�");
    }
    if($("txtsprice").value != "" && $("txtsprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) 
    {
        return alertmsg(false,'���������������飡');
    }            
    if($("txtssmallnum").value != "" && $("txtssmallnum").value.search(/^[-\+]?\d+$/) == -1)
    {
        return alertmsg(false,'��С��������Ϊ���������飡');
    }
    
    if($("txtscountnum").value != "" && $("txtscountnum").value.search(/^[-\+]?\d+$/) == -1)
    {
        return alertmsg(false,'������������Ϊ���������飡');
    }
    return true;
}

//��֤�ӹ���Ϣ
function checkmachininginfo()
{
    try{
	if($F("hidTypeId")=="" || $F("hidTypeId")=="0")
	{
		return alertmsg(false,'��ѡ����Ϣ���');
	}}catch(e){}
	
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    
    if(content=="")
    {
        return alertmsg(false,'��ϸ˵��Ϊ��������飡');
    }

    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
        return alertmsg(false,'��ѡ����Ϣ��Чʱ�䣡');
        }
    }
    if($("txtcprice").value != "" && $("txtcprice").value.search(/^(\d|-)?(\d|,)*\.?\d{0,4}$/) == -1) 
    {
        return alertmsg(false,'���������������飡');
    }  
     if($("txtcsmallnum").value != "" &&��$("txtcsmallnum").value.search(/^[-\+]?\d+$/) == -1)
    {
    return alertmsg(false,'��С��������Ϊ���������飡');
    }
    if($("txtccountnum").value != "" && $("txtccountnum").value.search(/^[-\+]?\d+$/) == -1)
    {
    return alertmsg(false,'������������Ϊ���������飡');
    }
    return true;
}
//��֤������Ϣ
function checkinvestmentinfo()
{
    try{
	if($F("hidTypeId")=="" || $F("hidTypeId")=="0")
	{
		return alertmsg(false,'��ѡ����Ϣ���');
	}}catch(e){}
	
	    
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    if(content=="")
    {
        return alertmsg(false,'��ϸ˵��Ϊ��������飡');
    }
    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
            return alertmsg(false,'��ѡ����Ϣ��Чʱ�䣡');
        }
    }
    if($("txtsupport").value.length>4000)
    {
    return alertmsg(false,'����֧�����ݹ��������飡');
    }
   if($("txtdemand").value.length>4000)
    {
    return alertmsg(false,'����Ҫ�����ݹ��������飡');
    }
  
   if($("pageurl").value!="")
    {
         if($("pageurl").value.search(/^http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&amp;_~`@[\]\��:+!]*([^&lt;&gt;\"\"])*$/) == -1 && $("pageurl").value !="http:\/\/")
	    {
	    return alertmsg(false,'������ַ��ʽ����\n http://www.xmusix.com');
	    }
    }
    return true;
}

//��֤������Ϣ
function checksurrogateinfo()
{
    try{
	if($F("hidTypeId")=="" || $F("hidTypeId")=="0")
	{
		return alertmsg(false,'��ѡ����Ϣ���');
	}}catch(e){}
	
	
    var content = FCKeditorAPI.GetInstance('xyecom').GetXHTML(true); 
    
    if(content=="")
    {
        return alertmsg(false,'��ϸ˵��Ϊ��������飡');
    }
    
    if($("datetype").value != "True")
    {
        if($("EndDate").value=="")
        {
        return alertmsg(false,'��ѡ����Ϣ��Чʱ�䣡');
        }
    }
    return true;
}


function SelectUser(usertype){
    if(usertype=="guest"){
        $("step_msg").innerHTML ="������������Ϣ����ɻ�Ա����ע��";
        $("tab_user_info").style.display="none";
        $("tab_guest_info").style.display="";
    }
    
    if(usertype=="user"){
        $("step_msg").innerHTML ="";
        $("tab_user_info").style.display="";
        $("tab_guest_info").style.display="none";
    }
}