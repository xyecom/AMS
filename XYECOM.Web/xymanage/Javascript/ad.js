// JScript 文件

   function TypeChange ( num )
   {
       var arrall = new Array(1,2,3,4,5,6,7,8);
              
       var arr = new Array();
       arr[0] = new Array();
       arr[1] = new Array(1,6);
       arr[2] = new Array(2,3,5,7);
       arr[3] = new Array(2,3,5);
       arr[4] = new Array(2,4,5);
       arr[5] = new Array(2,3,5);
       arr[6] = new Array("8");
       
       for(var i = 0; i < arrall.length; i++) {
            $("TR" + arrall[i] + "1").style.display = "none";
            $("TR" + arrall[i] + "2").style.display = "none";
       }
       
       for(var i = 0; i < arr[num].length; i++) {
            $("TR" + arr[num][i] + "1").style.display = "block";
            $("TR" + arr[num][i] + "2").style.display = "block";
       }
   
      if(num == 1)
      {
        $("trLink1").style.display = "";
        $("trLink2").style.display = "";
        $("trOpenMode1").style.display = "";
        $("trOpenMode2").style.display = "";
        $("rbupload").checked = false;
        $("rburllink").checked = false;
      }
      else if(num == 2)
      {
       $("trLink1").style.display = "";
        $("trLink2").style.display = "";
        $("trOpenMode1").style.display = "";
        $("trOpenMode2").style.display = "";
        
         if(document.getElementById("rbupload").checked == false && document.getElementById("rburllink").checked == false)
         {
             document.getElementById("rbupload").checked = false;
             document.getElementById("rburllink").checked = true;
         }
      }
      else if(num == 3)
      {         
         if(document.getElementById("rbpic").checked == true)
         {
         $("TR71").style.display = "block";
         $("TR72").style.display = "block";
         }
      }
      else if(num == 4)
      {
         if(document.getElementById("rbpic").checked == true)
         {
         $("TR71").style.display = "block";
         $("TR72").style.display = "block";
         }
      }
      else if(num == 5)
      {
         $("trLink1").style.display = "none";
        $("trLink2").style.display = "none";
        $("trOpenMode1").style.display = "none";
        $("trOpenMode2").style.display = "none";
         document.getElementById("tbhladress").value ="http://";
      
         document.getElementById("rbupload").checked = false;
         document.getElementById("rburllink").checked = true;
      }
	   else if(num == 6)
      {
         $("trLink1").style.display = "none";
        $("trLink2").style.display = "none";
        $("trOpenMode1").style.display = "none";
        $("trOpenMode2").style.display = "none";
         document.getElementById("tbhladress").value ="http://";
            
         document.getElementById("rbupload").checked = false;
         document.getElementById("rburllink").checked = false;
      }
   }
   
   function Input()
   {
        //共有信息
       if(document.getElementById("tbadname").value == "")
       {
		   return alertmsg('广告名称不能为空！','',false);
       }
       if(document.getElementById("ddladplace").value == "")
       {
           return alertmsg('所在广告位不能为空,请选择广告位.','',false);
       }
       if(document.getElementById("tbhladress").value == "")
       {
           return alertmsg('广告链接地址不能为空','',false);     
       }     
       
       var regExpUrl=new RegExp("((^http)|(^https)|(^ftp)):\/\/(\\w)+\.(\\w)+");
    
       if(document.getElementById("tbhladress").value !="http:\/\/" && !regExpUrl.exec(document.getElementById("tbhladress").value))
	   {
		   return alertmsg('输入网址格式错误！\n 例如：http://www.google.com','',false);
	   }
       if(document.getElementById("rbnewwin").checked == false && document.getElementById("rboldwin").checked == false)
        {
           return alertmsg('广告弹出方式必须选一','',false);
        }
       if(document.getElementById("rbnote").checked == false &&  document.getElementById("rbpic").checked == false && document.getElementById("rbswf").checked == false && document.getElementById("rbcode").checked == false) 
        {
           return alertmsg('广告类型必须选一！','',false);
        }
       // 文字广告
       if(document.getElementById("rbnote").checked == true)
       {
         if(document.getElementById("tbadnote").value == "")
         {
           return alertmsg('纯文字广告，内容必须填写！','',false);
         }
       } 
	    //代码
        if(document.getElementById("rbcode").checked == true)
        {
           if(document.getElementById("txtcode").value == "")
            {
               return alertmsg('请填写代码广告内容','',false);
            }
        }
       //图片广告
       if(document.getElementById("rbpic").checked == true)
        {          
           
              if(document.getElementById("rburllink").checked == false && document.getElementById("rbupload").checked == false)
               {
                 return alertmsg('图片/动画输入方式必须选一','',false);
               }
               if(document.getElementById("txtwidth").value.search(/^[-\+]?\d+$/) == -1)
               {
                 return alertmsg('请输入图片的宽度','',false);
               }
                if(document.getElementById("txthigh").value.search(/^[-\+]?\d+$/) == -1)
               {
                 return alertmsg('请输入图片的高度','',false);
               }
               if(document.getElementById("txtletter").value=="")
               {
                 return alertmsg('请输入图片替换文字','',false);
               }
            
        }
        //flash广告
        if(document.getElementById("rbswf").checked == true)
        {
                   
           if(document.getElementById("rburllink").checked == false && document.getElementById("rbupload").checked == false)
            {
               return alertmsg('图片/动画输入方式必须选一','',false);
            }
           if(document.getElementById("txtwidth").value.search(/^[-\+]?\d+$/) == -1)
           {
             return alertmsg('请输入图片的宽度','',false);
           }
            if(document.getElementById("txthigh").value.search(/^[-\+]?\d+$/) == -1)
           {
             return alertmsg('请输入图片的高度','',false);
           }
           
        }
		 
        // url连接
        if(document.getElementById("rburllink").checked == true)
        {
        
             if(document.getElementById("tbpicaddress").value == "")
               {
		          return alertmsg('你已选择URL方式，请输入URL地址','',false);
               }
              if(document.getElementById("tbpicaddress").value.search(/^http:\/\//) == -1)
               {
                  return alertmsg('图片链接URL错误! \n http://cn.yimg.com/pho/imghp/lb062202.jpg','',false)
               }
               if(document.getElementById("rbpic").checked == true)
               {
                  var value = GetPicType(document.getElementById("tbpicaddress").value, 1)
                  if(value == false)
                  {
                     return alertmsg('图片格式错误,只能链接:'+ document.getElementById("imagetype").value +'格式的图片','',false);
                  }
               }
               if(document.getElementById("rbswf").checked == true)
               {
                  var value = GetPicType(document.getElementById("tbpicaddress").value,2)
                  if(value == false)
                  {
                     return alertmsg('动画格式错误,只能链接swf格式的动画','',false);
                  }
               }
           
           
        }
        //本地上传
        if(document.getElementById("rbupload").checked == true)
        {     
            if(document.getElementById("FileAddress"))
            {
                
            }
            else
            {
               if(document.getElementById("Fileload").value == "")
               { 
                  return alertmsg('你已选择上传方式,请上传图片','',false);
               }
               if(document.getElementById("rbpic").checked == true)
               {
                 var value = GetPicType(document.getElementById("Fileload").value,1)
                 if(value == false)
                 {
                    return alertmsg('图片格式错误,只能上传:'+ document.getElementById('imagetype').value +'格式的图片','',false);
                 }
               }
               if(document.getElementById("rbswf").checked == true)
               {
                  var value = GetPicType(document.getElementById("Fileload").value,2)
                  if(value == false)
                  {
                    return alertmsg('动画格式错误,只能上传swf格式的动画.','',false);
                  }
               } 
            }          
        }  
   }  
   
   function GetPicType(var1,var2)
   {
      if(var1 != null && var1 != "")
      {
          var temp = var1.split('.');
          var len = temp.length;
          var fileExt = temp[len-1].toLowerCase();
          if(var2 == 1)
          {
            var type = new Array();
            if(document.getElementById("imagetype").value != null && document.getElementById("imagetype").value != "")
            {
               type = document.getElementById("imagetype").value.split(';');
               for (var i = 0; i < type.length; i++)
               {
                  var j = 0;
                  j = fileExt.indexOf(type[i]);
                  if( j >= 0)
                  {
                     return true;
                     continue;
                  }
               }
               return false;
            }
            return true;
          }
          if(var2 == 2)
          {
             if((fileExt.indexOf('swf') >= 0))
                return true;
             else
                return false;   
          }
      }
      else
        return false;
   }
   
   function GetAd()
   {
     if(document.getElementById("rbnote").checked == true)
     {
         TypeChange(1);
     }
     else if(document.getElementById("rbpic").checked == true )
     {
        TypeChange(2);
     }else if( document.getElementById("rbswf").checked == true)
     {
       TypeChange(5);
      }else if( document.getElementById("rbcode").checked == true)
     {
       TypeChange(6);
     }     
     if(document.getElementById("rburllink").checked == true)
     {
        TypeChange(3);
     }
     else if(document.getElementById("rbupload").checked == true)
     {
        TypeChange(4);
     }
   } 
   

   function Kongzhidate()
   {
        if(document.getElementById("datetype").checked == true)
        {
            document.getElementById("Label2").innerHTML=" ";
            document.getElementById("txtpanduan").value="2";
            document.getElementById("danweishijian").style.display = "none";
            document.getElementById("shijianduan").style.display = "block";
        }
        else
        {
            document.getElementById("txtpanduan").value="1";
            document.getElementById("Label2").innerHTML="  ";
            document.getElementById("danweishijian").style.display = "block";
            document.getElementById("shijianduan").style.display = "none";
        }
   }
   
   function getdateurl()
   {
        var str=window.location.href;
        var es=/id=/;
        es.exec(str);
        var add=RegExp.rightContext;
        if(add !="")
        {
            document.getElementById("danweishijian").style.display = "none";
            document.getElementById("shijianduan").style.display = "block";
            document.getElementById("qiehuan").style.display = "none";
        }
   }
   
  
    
   function yanzhengshuzi()
   {
        var source = document.getElementById("txtDateduan");
        if(source.value!="" &&source !=undefined )
        {
            if(!ValidateNum(source.value))
            {
                document.getElementById("txtDateduan").value="";
               document.getElementById("Label2").innerHTML="只能输入数字！请重新输入";
            }
            else
            {
                document.getElementById("Label2").innerHTML="";
            }
        }
        
       
   }
   
   