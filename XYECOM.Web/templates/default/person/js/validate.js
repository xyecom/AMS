
////==========================================================================
////
////  公共方法 开始
////
////==========================================================================
//商业信息
function businessinfo() {
    addMouseEvent(2);

}

function IsNum(str) {

    var re = /^[\d]+$/
    return re.test(str);

}
function CheckValuebuy() {
    var title = document.getElementById("title").value;
    var keyword = document.getElementById("keyword").value;
    var num = document.getElementById("num").value;

    var contents = document.getElementById("contents").value;
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
function selectBox(k) {
		for (i=1;i<=2;i++ )
		{
			if (i!=k) { 
				document.getElementById("contentBox"+i).style.display = "none";
				
			}
		}
		document.getElementById("contentBox"+k).style.display = "block";
		for (i=1;i<=2;i++)	{
			if (k==i) {
				document.getElementById("tab"+i).className = "on";
			}else {
				document.getElementById("tab"+i).className = "off";
			}
		}

	}


//给输入框和多选框加样式的js    
var isIE = navigator.userAgent.toLowerCase().indexOf('ie');


//添加Select选项
function addoption(obj) {
	if (obj.value=='addoption') {
		var newOption=prompt('请输入:','');
		if (newOption!=null && newOption!='') {
			var newOptionTag=document.createElement('option');
			newOptionTag.text=newOption;
			newOptionTag.value=newOption;
			try {
				obj.add(newOptionTag, obj.options[0]); // doesn't work in IE
			}
			catch(ex) {
				obj.add(newOptionTag, obj.selecedIndex); // IE only
			}
			obj.value=newOption;
		} else {
			obj.value=obj.options[0].value;
		}
	}
}

//getElementsByTagNameS
function getElementsByTagNames(list,obj) {
	if (!obj) var obj = document;
	var tagNames = list.split(',');
	var resultArray = new Array();
	for (var i=0;i<tagNames.length;i++) {
		var tags = obj.getElementsByTagName(tagNames[i]);
		for (var j=0;j<tags.length;j++) {
			resultArray.push(tags[j]);
		}
	}
	var testNode = resultArray[0];
	if (!testNode) return [];
	if (testNode.sourceIndex) {
		resultArray.sort(function (a,b) {
				return a.sourceIndex - b.sourceIndex;
		});
	}
	else if (testNode.compareDocumentPosition) {
		resultArray.sort(function (a,b) {
				return 3 - (a.compareDocumentPosition(b) & 6);
		});
	}
	return resultArray;
}

//function addMouseEvent(num) {
//	//为输入框添加焦点效果
//	var inputs=getElementsByTagNames('input,textarea');
//	for (i=0;i<inputs.length;i++) {
//		var inputtype = inputs[i].type.toLowerCase();
//		if(inputtype == 'checkbox' || inputtype == 'radio' || inputtype == 'button'|| inputtype == 'submit') continue;
//		inputs[i].onfocus=function() {
//			this.className='focus';
//			var temptips=document.getElementById(this.id+'tips');
//			if (temptips && GetCookie('spTips')==1) {
//				temptips.style.display='block';
//				//temptips.style.width=this.offsetWidth-10+'px';
//				temptips.style.top=findPosY(this)-4+'px';
//				temptips.style.left=findPosX(this)+this.offsetWidth+3+'px';
//				//alert(findPosY(this));
//			}
//		}
//		inputs[i].onblur=function() {
//			this.className='';
//			var temptips=document.getElementById(this.id+'tips');
//			if (temptips) {
//				myTimeout = window.setTimeout(function() {temptips.style.display='none';}, 0); 
//				//temptips.style.display='none';
//			}
//		}
//	}

//	//为IE下的Checkbox和Radio去处背景色
//	if (isIE>-1)
//	 {
//		minputs=document.getElementsByTagName('input');
//		for(i=0;i<minputs.length;i++)
//		{
//			
//			if(minputs[i].type=='checkbox'||minputs[i].type=='radio')
//			{
//				minputs[i].style.backgroundColor='transparent';
//				minputs[i].style.backgroundImage='none';
//				minputs[i].style.border='none';
//			}
//		}
//	}
//}

//刷新
function resh()
{    
   var num = 0;
   var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
			if(chkother[i].name.indexOf('sd_id')>-1)
			{
				if(chkother[i].checked == true)
				{
				    
					num++;
				}
			}
		}
	}
    if(num==0)
    {    
        return alertmsg(false,"至少要选择一条记录才能刷新！");
    }
    else if(document.getElementById("audting").value=="False")
    {
    return alertmsg(false,"该信息尚未通过审核，不能刷新！");  
    }
    else 
    {
     document.getElementById("resh").value="resh";
    }

}	
//暂停

//删除
function bntDelete()
{
    var num = 0;
    var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
			if(chkother[i].name.indexOf('sd_id')>-1)
			{
				if(chkother[i].checked == true)
				{
					num++;
				}
			}
		}
	}
    if(num==0)
    {
        return alertmsg(false,"至少要选择一条记录才能删除！");
    }
   else 
    {
        document.getElementById("isDelete").value="Delete";
       
    }
}
 function CheckedAll()
{
　　var chkall= document.all["chkAll"];
	var j=0;
	var chkother= document.getElementsByTagName("input");
	for (var i=0;i<chkother.length;i++)
	{
		if( chkother[i].type=='checkbox')
		{
			if(chkother[i].id.indexOf('sd_id')>-1)
			{
				if(chkall.checked==true)
				{
					chkother[i].checked=true;
				}
				else
				{
					chkother[i].checked=false;
				}
			}
		}
	}
}	


////==========================================================================
////  公共方法 结束
////==========================================================================


////==========================================================================
////  基本设置 开始
////==========================================================================


//加载个人信息
function loadpersontype(Province_ID,Province_Name,C_ID,C_Name,Mode)
{
  var ms=Mode.split(',');
  var num = 0;
   var chkother= document.getElementsByName("modetype");
	for (var i=0;i<chkother.length;i++)
	{
		for(var j=0;j<ms.length;j++)
		{
		    if(chkother[i].type=='checkbox')
		    {	
		      if(chkother[i].value==ms[j])
			    {				    
			     chkother[i].checked=true;
			    }	
		    }			
		}
	}
//addMouseEvent(1);

}


//修改密码	
	function ispasswore()
	{
	if(document.getElementById("oldpad").value=="")
	{
	 return alertmsg(false,'请输入原密码！');
	}
	else if(document.getElementById("oldpad").value.length<6)
	{
	 return alertmsg(false,'原密码长度为6-15位的数字或字母');
	}
	else if(document.getElementById("pwd").value=="")
	{
	 return alertmsg(false,'请输入新密码！');
	}
	else if(document.getElementById("pwd").value.length<6)
	{
	 return alertmsg(false,'新密码长度为6-15位的数字或字母！');
	}
	else if(document.getElementById("pwd1").value=="")
	{
	 return alertmsg(false,'请输入确认新密码！');
	}
	else if(document.getElementById("pwd1").value.length<6)
	{
	 return alertmsg(false,'确认密码长度为6-15位的数字或字母！');
	}
    else if(document.getElementById("pwd").value!=document.getElementById("pwd1").value)
    {
     return alertmsg(false,'两次输入的密码不一至，请重新输入两次密码！');
    }	
		
 }
 function shousex(num)
{
	if(num==1)
	{
		document.getElementById("sexy").checked=true;
		document.getElementById("sexn").checked=false;
		document.getElementById("sext").value=document.getElementById("sexy").value;
	}
	else
	{
		document.getElementById("sexn").checked=true;
		document.getElementById("sexy").checked=false;
		document.getElementById("sext").value=document.getElementById("sexn").value;
	}

}
////==========================================================================
////
////  用户是否可以查看留言  开始
////
////==========================================================================
function IsMessage()
{
if(document.getElementById("ismessage").value=="1")
{
 return alertmsg(false,'对不起，您当前身份不能查看留言，请联系管理员！',document.getElementById("txtweburl").value+"person/index."+document.getElementById("txtsuffix").value+"");
}
}

function usermessageinfo()
{
IsMessage();
}
////==========================================================================
////
////  用户是否可以查看留言  结束
////
////==========================================================================



////==========================================================================
////  基本设置 结束
////==========================================================================

////==========================================================================
////  留言信息 开始
////==========================================================================
//留言信息
function Message()
{
    document.getElementById("lbtitle").value="";
    document.getElementById("lbcontent").value="";
}
//判断留言信息是否为空
function GetMessage()
{
    if(document.getElementById("lbtitle").value=="")
    {
    return alertmsg(false,'留言主题必须填写！');
    }
    if(document.getElementById("lbcontent").value=="")
    {
    return alertmsg(false,'留言内容必须填写！');
    }
}


function getpostadministrator()
{
    if(document.getElementById("content").value=="")
    {
    return alertmsg(false,'留言内容必须填写！');
    }
}


////==========================================================================
////
////  留言信息 结束
////
////==========================================================================

	 //判断输入页数
	 function getNO()
	 {
	 if(document.getElementById("lbpage").value=="")
	 {
	return alertmsg(false,'请输入页数！');
	 }
	 
	 }

	/****************************结束************************************************/

////==========================================================================
////
////  个人会员 基本信息 开始
////
////==========================================================================
//邮箱验证
function validateemail(obj)
{
	
	email=obj.value;	
	oldemail=$F("oldEmail");
	
	if(email!="")
	{
		
		if(!ValidateEmail(email))
		{  
		   // if(email!=oldemail)
			//{ 
			//	var XMLDoc1 = new XMLHttpObject(document.getElementById("txtweburl").value+"getUserName."+document.getElementById("txtsuffix").value+"?email="+email,false);
			//	XMLDoc1.sendData();
			//	var msg = XMLDoc1.getText();
			//	if(msg>0)
			//	{
			//		obj.value=oldemail;
			//		return alertmsg(false,"此邮件地址已被注册！请您选择合适的邮件地址！");
			//		obj.focus();					
			//	}		       
			//}
			return ;
		}
		//else
		//{
		//	return alertmsg(false,"邮件地址格式不正确！");
		//	obj.focus();
		//}
	}
}
function IndividualLoad(sex)
{   
    document.getElementById("sext").value=sex;   

    if(sex=="1")
    {
       document.getElementById("sexy").checked=true;
    }
    else 
    {
       document.getElementById("sexn").checked=true;
    }  
    document.getElementById("type").value="update"
}
function RegForm(FormValue, FormType)
{
	var reg = new RegExp(FormType);
	if(!reg.test(FormValue))
		return false;
	else
		return true;
}
function Individualinfo()
{
    // 验证身份证
    var ID = "^([0-9]{15}|[0-9]{18})$";
    // 验证邮政编码
    var CODE = "^[0-9]{6}$";
		//邮箱验证
	var EMAIL = "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
     if(document.getElementById("txtName").value=="" )
     {
         alertmsg(false,"请输入姓名！");
         return false;
     }
     if(document.getElementById("sex")=="")
     {
        alertmsg(false,"请选择性别！");
        return false;
     }	 
     
     if($F("txtMobile").trim()=="")
     {
        alertmsg(false,'手机号码为必填项！');
        return false;
     } 
     
     if(!ValidateMobileTels($F("txtMobile")))
     {
        alertmsg(false,"您输入正确的手机号码！");
        return false;
     }
     
     if($F("txtphone") != "" && !ValidateTels($F("txtphone"))){
        alertmsg(false,"您输入正确的联系电话！");
        return false;
     }
     
     if(document.getElementById("areatypeid").value=="" || document.getElementById("areatypeid").value=="0")
     {
        alertmsg(false,"请选择所在地区！");
        return false;    
     }
        if(document.getElementById("txtaddress").value=="")
     {
        alertmsg(false,"请输入联系地址！");
        return false;    
     }
     if($F("txtcode").trim() != "" && !RegForm($F("txtcode").trim(),ID))
     {
        alertmsg(false,"请输入身份证号码！");
        return false;    
     }
     if(document.getElementById("txtpostcard").value=="")
     {
        alertmsg(false,"请输入邮政编码！");
        return false;    
     }
     if(!RegForm(document.getElementById("txtpostcard").value,CODE))
     {
        alertmsg(false,"请输入邮政编码！");
        return false;    
     }
	  if(document.getElementById("email").value=="")
     {
        alertmsg(false,"请输入邮箱！");
        return false;    
     }
	 if(!ValidateEmail($F("email")))
     {
        alertmsg(false,"你的输入的邮箱格式不正确！");
        return false;    
     }
	 else
	 {
	        var ajax = new Ajax("XY017","&email="+document.getElementById("email").value);
            ajax.onSuccess = function(){
                
                document.getElementById("email").innerHTML = (ajax.state.message);
                document.getElementById("email").style.color="red";
                if(ajax.state.result ==0)
                {
                    return alertmsg(false,"此邮件地址已被注册！请您选择合适的邮件地址！");
                    return false;
                }
                else
                {
                    return true;
                }
            }
     }
     return true;   
}
////==========================================================================
////
////  个人会员 基本信息 结束
////
////==========================================================================
////==========================================================================
////
////  简历信息 开始
////
////==========================================================================

///初始化简历信息
// sex性别
//  Bmonth 生日月
//  Bday  生日天
//  ProveType 证件类型
//  Schoolage  学历
//期望城市
//期望城市id
function Loadresume(Gyear,Schoolage,JobYear,citytypename,areaid)
{
    if(Schoolage!='')document.getElementById("Schoolage").value=Schoolage;
    
    if(Gyear!='') document.getElementById("Gyear").value=Gyear;
    
    if(JobYear!='')document.getElementById("JobYear").value=JobYear;
       
    document.getElementById("Type").value="update"    
}

function Addresume()
{
    var schoolname=document.getElementById("schoolname");
    var Speciality=document.getElementById("Speciality");
    var Gyear=document.getElementById("Gyear");
    var Intentadd=document.getElementById("areatypeid");
    var Intentjob=document.getElementById("Intentjob");
    var Intentpay=document.getElementById("Intentpay");
    var Experience=document.getElementById("Experience");
    var txtResume=document.getElementById("txtResume"); 
    var areaId = document.getElementById("areatypeid").value; 
   
   
    if(schoolname.value=="")
    { return alertmsg(false,"请输入毕业学校！");}
    
    if(Speciality.value=="")
    {return alertmsg(false,"请输入专业！");}
    
    if(Gyear.value=="")
    {return alertmsg(false,"请输入毕业时间！");}
    
    if(Intentjob.value=="")
    { return   alertmsg(false,"请输入工作职位！");}
    
    if(Intentpay.value=="")
    {return  alertmsg(false,"请输入工资待遇！");}
    
    if(areaId=="" || areaId=="0")
    {return  alertmsg(false,"请选择期望所在城市！");}
    
    if(Experience.value=="")
    { return   alertmsg(false,"请添写工作经验！");}
    
    if(Experience.value=="")
    { return  alertmsg(false,"请添写工作经验！");}
    
    if(txtResume.value=="")
    {return  alertmsg(false,"请添写自我描述！");}         
}
function setType(type)
{
  if(type!='')
  {
  document.getElementById("Type").value=type;
  return true
  }
  else
  {
  return false
  }
   
}
////==========================================================================
////  简历信息 结束
////==========================================================================
////==========================================================================
////  财务信息 开始
////==========================================================================
//发票信息 
function InvoiceAdd()
{
    if(document.getElementById("I_Name").value=="")
    {
    return alertmsg(false,'请输入申请发票人的姓名！');
    }
    if(document.getElementById("I_Address").value=="")
    {
    return alertmsg(false,'请输入申请发票人的地址！');
    }
    if(document.getElementById("I_PostCode").value=="")
    {
    return alertmsg(false,'请输入申请发票人的邮编！');
    }
    if(document.getElementById("I_PostCode").value.search(/^\d{6}$/)==-1)
    {
    return alertmsg(false,'输入邮编格式错误! \n 例：710000');
    }
    if(document.getElementById("I_Money").value=="")
    {
    return alertmsg(false,'请输入申请发票的金额！');
    }
    if(document.getElementById("I_Title").value=="")
    {
    return alertmsg(false,'请输入申请发票的标题信息！');
    }
    if(document.getElementById("I_Product").value=="")
    {
    return alertmsg(false,'请输入产品名称！');
    }
    if(document.getElementById("I_Content").value=="")
    {
    return alertmsg(false,'请输入申请发票的内容信息');
    }
    if (document.getElementById("I_Money").value.search(/^[0-9]+$/)!=-1 || document.getElementById("I_Money").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/)!=-1) 
    {
    document.getElementById("I_Money").value= Math.round(parseFloat(document.getElementById("I_Money").value)*100)/100
    return true;
    }
    else
    {   
    return alertmsg(false,'输入格式错误！\n 例：88.88')
    }      

}

//汇款确认信息
function remitadd()
{
    if(document.getElementById("R_Name").value=="")
    {
    return alertmsg(false,'请输入收款人姓名！');
    }
    if(document.getElementById("R_Email").value=="")
    {
    return alertmsg(false,'请输入联系Email！');
    }
    if (document.getElementById("R_Email").value.search(/^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$/)==-1)
    {
    return alertmsg(false,'邮件地址错误! \n 例：email@sohu.com');
    }
    if(document.getElementById ("guohao").value=="")
    {
    return alertmsg(false,'联系电话必须填写！');
    }
    if(document.getElementById("R_Time").value=="")
    {
    return alertmsg(false,'请输入汇款时间！');
    }
    if(document.getElementById("R_Bank").value=="")
    {
    return alertmsg(false,'请输入汇入银行！');
    }
    if(document.getElementById("R_Account").value=="")
    {
    return alertmsg(false,'请输入汇入卡号！');
    }
    if(document.getElementById("R_Account").value.search(/^[-\+]?\d+$/) == -1)
    {
    return alertmsg(false,'请输入整数!');
    }
    if(document.getElementById("R_CAccount").value!="" &&document.getElementById("R_CAccount").value.search(/^[-\+]?\d+$/) == -1)
    {
    return alertmsg(false,'请输入整数!');
    }
    if(document.getElementById("R_CName").value=="")
    {
    return alertmsg(false,'请输入收款人姓名！');
    }
    if(document.getElementById("R_Money").value=="")
    {
    return alertmsg(false,'请输入汇款金额！');
    }
    if (document.getElementById("R_Money").value.search(/^[0-9]+$/)!=-1 || document.getElementById("R_Money").value.search(/^([0-9]+)|([0-9]+\.[0-9]*)|([0-9]*\.[0-9]+)$/)!=-1) 
    {
    document.getElementById("R_Money").value= Math.round(parseFloat(document.getElementById("R_Money").value)*100)/100
    return true;
    }
    else
    {   
    return alertmsg(false,'输入格式错误！\n 例：88.88')
    } 
}
////==========================================================================
////  财务信息 结束
////==========================================================================
//整合
function activebbs()
{
    var url = document.getElementById("txtweburl").value+"GetValues."+document.getElementById("txtSuffix").value+"?flag=acticebbs";
    
    var XMLDoc1=new XMLHttpObject(url,false);
	XMLDoc1.sendData();
	var msg = XMLDoc1.getText(); 
	if(msg == "err")
	{
	    alertmsg(false,"系统繁忙！请稍候再试！");
	}	
	else if(msg == "no")
	{
	    alertmsg(false,"激活失败！请稍候再试！");
	}
	else if(msg == "nouser")
	{
	    alertmsg(false,"未登录！请登录后再激活");
	    loginout();
	}
	else if(msg == "ok")
	{
	    alertmsg(false,"激活成功！请重新登陆");
	    var url = document.getElementById("txtweburl").value +"getloginout."+document.getElementById("txtSuffix").value;
	    var XMLDoc1=new XMLHttpObject(url,false);
	    XMLDoc1.sendData();
    	
	    var msg = XMLDoc1.getText();
       
   	    if (msg == "loginout")
	    {
		    window.location.href=document.getElementById("txtweburl").value+"login."+document.getElementById("txtSuffix").value;
	    }
	    else
	    {
	        return alertmsg(false,'系统错误！');
	    }	
	}
}

//快速搜索
function searchClick()
{
    
    if(document.getElementById("txtsearchkey").value == "")
    {
        alertmsg(false,"请输入查询条件！");
    }
    else if(isNull(document.getElementById("txtsearchkey").value))
    {
        alertmsg(false,"输入查询条件不合法！");
    }
    else if(!isTrueKeyWord(document.getElementById("txtsearchkey").value))
    {
        alertmsg(false,"输入查询条件不合法！");
    }
    else if(!isNVarchar(document.getElementById("txtsearchkey").value))
    {
        alertmsg(false,"输入查询条件不合法！");
    }
    else 
    {
//        if(document.getElementById("bogusstatic").value == "True")
//            window.location.href = document.getElementById("weburl").value + "search/seller_search-"+document.getElementById("s").value+"-0-"+document.getElementById("txtsearchkey").value+"."+document.getElementById("suffix").value; 
//        else
            window.parent.location.href = document.getElementById("txtweburl").value + "search/seller_search."+document.getElementById("txtsuffix").value+"?flag=offer&keyword="+document.getElementById("txtsearchkey").value; 
    }
}

/*
字符串验证
*/
//是否为空白字符
function isNull(obj)
{
    var reg =/^\s/;
    if(reg.test(obj))return true;
    return false; 
}
//是否为字母和数字
function isTrueKeyWord(obj)
{
    var reg1 =/[^\uFF00-\uFFFF]/;

    if(reg1.test(obj))return true;

    return false;
}
//是否为汉字
function isNVarchar(obj)
{
    var reg =/\w|^[\u0391-\uFFE5]+$/;
    if(reg.test(obj))return true;
    return false;
}


/****** 在线充值相关开始 *********/

function CheckAccountRecharge(Flag) {
    var amount = $F("txtAmount").trim();

    if (amount == "" || amount == "0") {
        return alertmsg(false, "请输入充值金额！");
    }
    
    if (amount.search(/^[-\+]?\d+$/) == -1) {
        return alertmsg(false, '充值金额必须为整数！');
    }
    showid(Flag);
    return true;
}

/****************************** 弹出层 ************************************/

function showid(idname) {
    var isIE = (document.all) ? true : false;
    var isIE6 = isIE && ([/MSIE (\d)\.0/i.exec(navigator.userAgent)][0][1] == 6);
    var newbox = document.getElementById(idname);
    newbox.style.zIndex = "9999";
    newbox.style.display = "block"
    newbox.style.position = !isIE6 ? "fixed" : "absolute";
    newbox.style.top = newbox.style.left = "50%";
    newbox.style.marginTop = -newbox.offsetHeight / 2 + "px";
    newbox.style.marginLeft = -newbox.offsetWidth / 2 + "px";
    var layer = document.createElement("div");
    var close = document.getElementById("close_pay");
    layer.id = "layer";
    layer.style.width = layer.style.height = "100%";
    layer.style.position = !isIE6 ? "fixed" : "absolute";
    layer.style.top = layer.style.left = 0;
    layer.style.backgroundColor = "#000";
    layer.style.zIndex = "9998";
    layer.style.opacity = "0.6";
    document.body.appendChild(layer);

    if (isIE) { layer.style.filter = "alpha(opacity=60)"; }
    if (isIE6) {
        layer_iestyle()
        newbox_iestyle();
        window.attachEvent("onscroll", function () {
            newbox_iestyle();
        })
        window.attachEvent("onresize", layer_iestyle)
    }
    close.onclick = function () {
        newbox.style.display = "none";
        layer.style.display = "none";
        window.parent.location.href = config.WebURL + "person/accountrecharge." + config.Suffix;
    }

    return false;
}

function layer_iestyle() {
    layer.style.width = Math.max(document.documentElement.scrollWidth, document.documentElement.clientWidth)
+ "px";
    layer.style.height = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight) +
"px";
}

function newbox_iestyle() {
    newbox.style.marginTop = document.documentElement.scrollTop - newbox.offsetHeight / 2 + "px";
    newbox.style.marginLeft = document.documentElement.scrollLeft - newbox.offsetWidth / 2 + "px";
}

/****** 在线充值相关结束 *********/