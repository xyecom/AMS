function SetURLValue()
{
    var templatePath = $F("txtTemplatePath");
    var pointIndex  = templatePath.indexOf(".");
    
    if(pointIndex ==-1)
    {
        var lastChar = templatePath.substr(templatePath.length-1,1);
        if(lastChar == "/")
        {
            templatePath = templatePath+"index.htm";
        }
        else
        {
            templatePath = templatePath+".htm";
        }
        $("txtTemplatePath").value = templatePath;
    }
    else
    {
        var suffix = templatePath.substr(pointIndex,templatePath.length - pointIndex);
        
        if(suffix != ".htm")
        {
            templatePath = templatePath.substr(0,pointIndex)+".htm";
            $("txtTemplatePath").value = templatePath;
        }
    }
    
    var url = templatePath.replace("htm","aspx");
    $("txtURL").value = "/cp/" + url;
}

// JS验证图片后缀名 
function GetPicType(varpic)
{
    if(varpic != "" && varpic != null)
    {
        var temp = varpic.split('.');
        var len = temp.length;
        var fileExt = temp[len-1].toLowerCase();
        var type = new Array();
        
        
        if(document.getElementById("txtImageType").value != "")
        {
            type = document.getElementById("txtImageType").value.split(';');
            for (var i = 0; i <　type.length; i++)
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
    else
        return false;
}