// JScript 文件
//网站基本设置上传图片JS
function setpicid()
{
   var obj = window.dialogArguments;
   if(obj.name != "0")
      document.getElementById("hdpicid").value = obj.name;
   else
      document.getElementById("hdpicid").value = 0;    
}

function addinput()
{
    if(document.getElementById("FileUpload").value == "" || document.getElementById("FileUpload").value == null)
    {
        alert('请上传要设为水印的图片；或者取消本次操作');
        return false;
    }    
}
  function getwatermark()
  {
     if(document.getElementById("rbWatermarkChar").checked == true)
     {
         document.getElementById("th1").innerHTML = "添加文字水印";
         document.getElementById("tab1").style.display = "block";
         document.getElementById("tab2").style.display = "none";
     }
     if(document.getElementById("rbWatermarkpic").checked == true)
     {
         document.getElementById("th1").innerHTML = "添加图片水印<span>请上传几种常见的图片格式,如:gif;png;jpg;bmp等</span>";
         document.getElementById("tab2").style.display = "block";
         document.getElementById("tab1").style.display = "none";
     }
  }
  function WebInfoInput()
  {
     if(document.getElementById("tbwebname").value == "")
       return alertmsg('请输入网站名称！','',false);
        
     if(document.getElementById("tbweburl").value == "")
       return alertmsg('请输入网站域名！','',false);
     else
     {
        if(document.getElementById("tbweburl").value.lastIndexOf('/') != document.getElementById("tbweburl").value.length-1)
           return alertmsg("请在网站域名后加'/'符号!",'',false);
     }
     if(document.getElementById("tbwebsuffix").value == ""){
         return alertmsg('请输入伪后缀名！','',false);
     }
     
//     if(document.getElementById("lbmessage").value == "")
//       return  alertmsg('请输入系统留言条数！','',false);
//     else
//     {
//        var numb = document.getElementById("lbmessage").value;
//        if( false == IsInt(numb))
//          return alertmsg('系统留言条数应为整数,请重新输入','',false);
//     }  
     
//     if(document.getElementById("txtype").value == "")
//       return  alertmsg('请输入用户可以选择产品类别的数量！','',false);
//     else
//     {
//        var number = document.getElementById("txtype").value;
//        if( false == IsInt(number))
//          return alertmsg('请输入用户可以选择产品类别的数量应为整数,请重新输入','',false);
//     }  
//       
//         
//	 if(document.getElementById("rbdummymoney").checked != true && document.getElementById("rbcashmoney").checked != true)
//       return  alertmsg('请选择是否允许注册！','',false);   
     
      if(document.getElementById("webmoney").value == ""){
         return alertmsg('请输入虚拟货币名称！','',false);
        }
      
       if(document.getElementById("txtSiteCloseTips").value == ""){
         return alertmsg('请输入网站关闭的原因！','',false);
        }

   }
   
   function chkfunctioninput() {
     if("" == $F("tbUploadThumbnailImgFolder")) return alertmsg('请输入缩略图的文件夹名称','',false);
     if(!chkImgSizeFormart($F("tbUploadImg"))) return alertmsg('图片的最大尺寸格式错误，例如1027*768','',false);
     if(!chkImgSizeFormart($F("tbUploadThumbnailImg1"))) return alertmsg('缩略图1的尺寸格式错误，例如1027*768','',false);
     if(!chkImgSizeFormart($F("tbUploadThumbnailImg2"))) return alertmsg('缩略图2的尺寸格式错误，例如1027*768','',false);
     if(!chkImgSizeFormart($F("tbUploadThumbnailImg3"))) return alertmsg('缩略图3的尺寸格式错误，例如1027*768','',false);
     if(document.getElementById("tbUploadFileType").value == "")
       return alertmsg('请输入上传图片文件类型，用，号隔开','',false);
     
     if(document.getElementById("tbUploadFileSize").value == "")
       return alertmsg('请输入允许上传图片文件大小','',false);
     else
     {
        var num = document.getElementById("tbUploadFileSize").value;
        if(!ValidateNum(num))
          return alertmsg('许上传图片文件大小应为整数,请重新输入','',false);
     } 

//     if(document.getElementById("tbUploadAdjunctType").value == "")
//       return alertmsg('请输入上传附件类型，用，号隔开','',false);
//     
//     if(document.getElementById("tbUploadAdjunctSize").value == "")
//       return alertmsg('请输入允许上传附件大小','',false);
//     else
//     {
//        var num = document.getElementById("tbUploadAdjunctSize").value;
//        if(!ValidateNum(num))
//          return alertmsg('许上传附件大小应为整数,请重新输入','',false);
//     }  
     
       if(document.getElementById("tbWaterMarkContent").value == ""){
         return alertmsg('请输入文字水印的内容！','',false);
        }
     
     if(document.getElementById("txtAboutNewsNum").value == "")
       return  alertmsg('请输入新闻调用的数量！','',false);
     else
     {
        var newsnumber = document.getElementById("txtAboutNewsNum").value;
        if( false == IsInt(newsnumber))
          return alertmsg('数量应为整数,请重新输入','',false);
     } 
   }
   function chkImgSizeFormart(source) {
        var patrn = /^\d{1,4}\*\d{1,4}$/;
        return patrn.exec(source);
   }
  
  function IsInt(name)//输入为整数
  {  
	 var lette = "1234567890";
	 var c;
	 var retvalue = true;
	 for(var i = 0; i < name.length; i++)
	 {
	    c = name.charAt(i);
	    if(lette.indexOf(c) == -1)
	    {
	       retvalue = false;
	       break;
	    }  
	 }
	 return retvalue;
   }

//网站基本设置JS结束


// 商业信息基本设置JS开始
function BussinessInput()
{
      if(document.getElementById("autoadtms").checked != true && document.getElementById("manadtms").checked != true)
     return  alertmsg('请选择是否允许注册！','',false);

   if(document.getElementById("autonewadt").checked != true && document.getElementById("mannewadt").checked != true)
     return  alertmsg('请选择是否允许注册！','',false);

   if(document.getElementById("tbuseraddinfo").value != "")
   {
       var number = document.getElementById("tbuseraddinfo").value;
       if( false == IsInt(number))
          return alertmsg('用户发布信息奖励应为整数,请重新输入','',false);
   }
   
   if(document.getElementById("tbrefurbishinfo").value != "")
   {
       var num = document.getElementById("tbrefurbishinfo").value;
       if( false == IsInt(num))
          return alertmsg('用户刷新一次信息奖励应为整数,请重新输入','',false);
   }
   
   if(document.getElementById("enddate").checked != true && document.getElementById("endtime").checked != true) 
       return alertmsg('请选择商业信息有效期的时间选择方式','',false);

}
// 商业信息基本设置JS结束


// 用户基本信息设置JS开始
function UserInput()
{
   if(document.getElementById("isusert").checked != true && document.getElementById("isuserf").checked != true)
     return  alertmsg('请选择是否允许注册！','',false);

   if(document.getElementById("atuoadtuser").checked != true && document.getElementById("manadtuser").checked != true)
     return alertmsg('请选择用户注册审核方式！','',false)
   
   if(document.getElementById("yke").checked != true && document.getElementById("yk").checked != true)
     return  alertmsg('请选择游客是否可以查看联系方式!','',false);
   
   if(document.getElementById("tbuserhortation").value != "")
   {
       var num = document.getElementById("tbuserhortation").value;
       if( false == IsInt(num))
          return alertmsg('用户注册成功奖励数应为整数,请重新输入','',false);
   }
   
   if(document.getElementById("tbloginhortation").value != "")
   {
       var number = document.getElementById("tbloginhortation").value;
       if( false == IsInt(number))
          return alertmsg('登录一次奖励数应为整数,请重新输入','',false);
   }
      if(document.getElementById("txtScores").value != "")
   {
       var number = document.getElementById("txtScores").value;
       if( false == IsInt(number))
          return alertmsg('登录奖励(积分)应为整数,请重新输入','',false);
   }
   if(document.getElementById("webnotet").checked != true && document.getElementById("webnotef").checked != true)
      return  alertmsg('请选择是否启用注册成功短信!','',false);
   
   if(document.getElementById("webnotet").checked == true)
   {
      if(document.getElementById("tbnotetitle").value == "")
        return  alertmsg('你已选择启用短信，请输入短信标题!','',false);
    
      if(document.getElementById("tbnotetext").value == "")
        return  alertmsg('你已选择启用短信，请输入短信内容！','',false);
    }
    
	if(document.getElementById("tbregist").value == "")
       return alertmsg('请输入注册成功资料后完善度增加值','',false);  
    else
    {
       var name = document.getElementById("tbregist").value;
       if( false == IsInt(name))
		{
          document.getElementById("tbregist").value = ""; 
          return alertmsg('注册成功资料完善度增加值应为整数,请重新输入','',false);
		}
    }

    if(document.getElementById("tbbase").value == "")
       return alertmsg('请输入完成基本资料必填后完善度增加值','',false);  
    else
    {
       var name = document.getElementById("tbbase").value;
       if( false == IsInt(name))
		{
          document.getElementById("tbbase").value = "";
          return alertmsg('完成基本资料必填选项完善度增加值应为整数,请重新输入','',false);
		}
    }

	if(document.getElementById("tbmobile").value == "")
       return alertmsg('请输入添加手机号码后完善度增加值','',false);  
    else
    {
       var name = document.getElementById("tbmobile").value;
       if( false == IsInt(name))
		{
          document.getElementById("tbmobile").value = "";
          return alertmsg('添加手机号码后增加值应为整数,请重新输入','',false);
		}
    }

	if(document.getElementById("tbbranch").value == "")
       return alertmsg('请输入添加所在部门后完善度增加值','',false);  
    else
    {
       var name = document.getElementById("tbbranch").value;
       if( false == IsInt(name))
		{
          document.getElementById("tbbranch").value = ""; 
          return alertmsg('添加所在部门后完善度增加值应为整数,请重新输入','',false);
		}
    }
       
    if(document.getElementById("tbcomple").value == "")
       return alertmsg('请输入完成高级资料必填项后完善度增加值','',false);
    else
    {
       var hotname = document.getElementById("tbcomple").value;
       if( false == IsInt(hotname))
		{
          document.getElementById("tbcomple").value = "";
          return alertmsg('完成高级资料必填选项完善度增加值应为整数,请重新输入','',false);
		}
    }
       
    if(document.getElementById("tbcapital").value == "")
       return alertmsg('请输入添加注册资本后完善度增加值','',false);
    else
    {
       var hotname = document.getElementById("tbcapital").value;
       if( false == IsInt(hotname))
		{
          document.getElementById("tbcapital").value = "";  
          return alertmsg('完成输入添加注册资本后完善度增加值应为整数,请重新输入','',false);
		}
    }

    if(document.getElementById("tblicence").value == "")
       return alertmsg('请输入完成营业执照上传或传真后完善度增加值','',false);
    else
    {
       var licname = document.getElementById("tblicence").value;
       if( false == IsInt(licname))
		{
           document.getElementById("tblicence").value = "";
          return alertmsg('完成营业执照上传或传真后完善度增加值应为整数,请重新输入','',false);
		}
    }
    
    if(document.getElementById("tbcertificate").value == "")
       return alertmsg('请输入完成其他资质证书上传或传真后完善度增加值','',false);
    else
    {
       var cername = document.getElementById("tbcertificate").value;
       if( false == IsInt(cername))
		{
           document.getElementById("tbcertificate").value = "";
           return alertmsg('完成其他资质证书上传或传真后完善度增加值应为整数,请重新输入','',false);
		}
    }
	
	var sum = 0;
	sum = Number(document.getElementById("tbregist").value) + Number(document.getElementById("tbbase").value) + Number(document.getElementById("tbmobile").value) + Number(document.getElementById("tbbranch").value) + Number(document.getElementById("tbcomple").value) + Number(document.getElementById("tbcapital").value) + Number(document.getElementById("tblicence").value) + Number((document.getElementById("tbcertificate").value*5));

	if(Number(sum) != 100)
		return alertmsg('资料完善度之和必须为100分,请重新设置.','',false);
}
// 用户基本信息设置JS结束