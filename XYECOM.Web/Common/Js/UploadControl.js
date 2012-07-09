function UploadImage(objName) {
    this.index = 1;
    this.maxAmount = 0;
    
    this.imageWidth = 100;
    this.imageHeight =100;
    
    var defaultImg = "/Common/Images/DefaultImg.gif";    
    var obj = objName;    
    var ids,files;    
    var uploaddiv;    
    var dWidth = 400;//�Ի�����
    var dHeight = 300;//�Ի���߶�
    var addIndex = 0;//�����ļ���divλ������
    var editIndex = 0;//�޸��ļ���divλ������
    var ac = 0;//��ǰ�Ĳ������� 0 ��� 1 �޸�
    
    
    this.Init = function() {
        this._Init();
    }
    
    this.InitPicSize = function(width,height){
        
        if(!isNaN(width)) this.imageWidth = width;
        
        if(!isNaN(height))this.imageHeight = height;
        
        this._Init();
    }
    
    this._Init = function(){
        uploaddiv = $("UploadFile");
        ids = $F("Upload_IDs");
        files = $F("Upload_Files");

        this.maxAmount = parseInt($F("Upload_MaxAmount"));
        
        //���õ������͸������
        var uploadbg = document.createElement("div");
        uploadbg.id="uploadbg";
        uploadbg.className="upload_bg";    
        
        
        var page = new getPageSize();

        uploadbg.style.width=page.width;       

        //uploadbg.style.filter:alpha(opacity=80);
        uploaddiv.appendChild(uploadbg);
        //���õ�����
        var uploadfrm = document.createElement("iframe");
        uploadfrm.id="uploadfrm";
        uploadfrm.className="upload_frm";
        uploadfrm.frameBorder = 0;
        uploaddiv.appendChild(uploadfrm);
        
        if("" != ids) {
            var arrid = ids.split("|");
            var arrFile = files.split("|");
            for(var i = 0;i<arrid.length;i++) {
                this.AddItem(arrid[i],arrFile[i]);
            }
        }
        this.AddItem("","");
    }
    
    this.AddItem = function(id,filePath) {
        if("" == id && this.index > this.maxAmount) return;
        if(0 != addIndex) return;
        if("" == id) addIndex = this.index;
        var uploaditem = document.createElement("div");
        uploaditem.id = "uploadFileItem" + this.index;
        uploaditem.className = "upload_fileitem";
        var htmlcode = "<ul><li id=\"Img" + this.index + "\" class=\"Upload_img\">"
        htmlcode += this.GetImgHtml(filePath);
        htmlcode += "</li><li>";
        if("" == id) {
            htmlcode += "<a class=\"Upload_btn\" href=\"javascript:" + obj + ".Show('" + id + "'," + this.index + ");\">[�ϴ�]</a>";
        }
        else {
            htmlcode += "<a class=\"Upload_btn\" href=\"javascript:" + obj + ".Show('" + id + "'," + this.index + ");\">[�޸�]</a>&nbsp;";
        }
        htmlcode += "<a class=\"Upload_btn\" href=\"javascript:" + obj + ".DelItem(" + this.index + ",'" + id + "');\"" + (("" == id || "0" == id) ? " style=\"display:none;\"" : "") + ">[ɾ��]</a>"
        htmlcode += "</li></ul>";
        uploaditem.innerHTML = htmlcode;
        uploaddiv.appendChild(uploaditem);
        this.index++;
    }
    this.DelItem = function(objIndex,id) {
        uploaddiv.removeChild($("uploadFileItem" + objIndex));
        this.maxAmount++;
        if("" != id) {//ɾ�����ļ�����Ŀ
            $("Upload_DelIDs").value = "" == $F("Upload_DelIDs") ? id : $F("Upload_DelIDs") + "," + id;
            this.AddItem("","");
        }
        else {//ɾ�������ļ� ����������ļ���divλ������
            addIndex = 0;
        }
    }
    this.Show = function(id,objIndex) {
        var scrollPos	= new getScrollPos();				
        var pageSize	= new getPageSize();
        if("" == id) {
            ac = 0;
            addIndex = objIndex;
        }
        else {
            ac = 1;
            editIndex = objIndex;
        }
        
        $("uploadbg").style.display = "block";
        $("uploadbg").style.height = pageSize.docheight + "px";
        $("uploadfrm").style.display = "block";
        
        var x = Math.round(pageSize.width/2) - (dWidth /2) + scrollPos.scrollX;
	    var y = Math.round(pageSize.height/2) - (dHeight /2) + scrollPos.scrollY;        
        $("uploadfrm").src = "/upload/UploadImage." + config.Suffix + "?TabName=" + $F("Upload_TabName") + "&iswatermark=" + $F("Upload_IsWaterMark") + "&AtID=" + id + "&tmp=" + Math.random();
        $("uploadfrm").style.width = dWidth + "px";
        $("uploadfrm").style.height = dHeight + "px";
	    $("uploadfrm").style.left	= x+'px';			
	    $("uploadfrm").style.top= y+'px';
    }
    this.Save = function(msg,filelist) {
        if(filelist.length > 0) {
            if(0 == ac) {
                this.DelItem(addIndex,"");
                for(var ifile = 0; ifile < filelist.length; ifile++) {
                    $("Upload_UpIDs").value = "" == $F("Upload_UpIDs") ? filelist[ifile].id : $F("Upload_UpIDs") + "," + filelist[ifile].id;
                    this.AddItem(filelist[ifile].id,filelist[ifile].url);
                }
                this.AddItem("","");
            }
            else {
                $("Img" + editIndex).innerHTML = this.GetImgHtml(filelist[0].url);
            }
        }
        if("" != msg) sAlert(msg);
    }
    this.IsUploadFile = function() {
        var upids = $F("Upload_UpIDs");
        var delids = $F("Upload_DelIDs");
        var oldids = $F("Upload_IDs");
        if("" != oldids) {
            var arr = oldids.split("|");
            for(var iid = 0; iid < arr.length; iid++) {
                if(delids.indexOf(arr[iid]) == -1)
                    return true;
            }
        }
        if("" != upids) {
            var arr = upids.split("|");
            for(var iid = 0; iid < arr.length; iid++) {
                if(delids.indexOf(arr[iid]) == -1)
                    return true;
            }
        }
        return false;
    }
    this.Close = function() {
        $("uploadbg").style.display = "none";
        $("uploadfrm").style.display = "none";
        $("uploadfrm").src = "";
    }
    
    this.GetImgHtml = function(filepath) {
        if(filepath == "")
            return "<img src=\"" + (defaultImg) + "\" alt=\"\" onload=\"SetImgSize(this,"+this.imageWidth+","+this.imageHeight+");\" />";
        else
            return "<a href='"+filepath+"' target='_blank'><img src=\"" + (filepath) + "\" alt=\"\" onload=\"SetImgSize(this,"+this.imageWidth+","+this.imageHeight+");\" border='0'/></a>";
    }
}

var objUpload = new UploadImage("objUpload");

//ͼƬ�ϴ���ʼ��
function UploadInit() {
    objUpload.Init();
}
//ͼƬ�ϴ���ʼ������ָ��ͼƬ�߶ȺͿ��
function UploadInitPicSize(width,height) {
    objUpload.InitPicSize(width,height);
}

//�Ƿ����ļ�
function IsUploadFile() {
    return objUpload.IsUploadFile();
}


//�ϴ��ļ�ҳ����Ҫ����
function UploadFileForFile(objName) {
    this.index = 1;
    this.maxAmount = 0;
    var obj = objName;    
    var uploadfilefrm;
    var dWidth = 300;//�Ի�����
    var dHeight = 80;//�Ի���߶�
    var uploadingImg = "/Common/Images/ajax-loader.gif";
    
    this.Init = function() {
        uploadfilefrm = $("uploadfilefrm");

        this.AddFileItem(this.index);
        //�ϴ��еȴ�Ч����͸������
        var uploadingbg = document.createElement("div");
        uploadingbg.id="uploadingbg";
        uploadingbg.className="upload_bg";    
        uploadfilefrm.appendChild(uploadingbg);
        //�ϴ��еȴ�Ч��
        var uploading = document.createElement("div");
        uploading.id="uploading";
        uploading.className="upload_ing";
        uploading.innerHTML = "�ϴ��У����Ե�...<br /><img src=\"" + uploadingImg + "\" alt=\"\" />";
        uploadfilefrm.appendChild(uploading);
    }
    this.AddFile = function(objindex) {
        //����ɾ����ť
        this.AddDeleteBtn(objindex);
        //����пյ��ļ����˳�
        var lastindex = this.LastFileIndex(objindex);
        if(0 != lastindex) {
            if("" != $F("file" + lastindex))
               this.AddFileItem();
        }
        else
            this.AddFileItem();
    }
    this.AddDeleteBtn = function(objindex) {
        if(!$("btnDel" + objindex) && $("uploadfileitemfrm" + objindex)) {
            var btndel = "<input type=\"button\" id=\"" + "btnDel" + objindex + "\" onclick=\"" + obj + ".DelFile(" + objindex + ");\" />";
            insertHtml("beforeend",$("uploadfileitemfrm" + objindex),btndel);
        }
    }
    this.LastFileIndex = function(objindex) {
        for(var i = this.maxAmount; i > objindex; i--) {
            if($("uploadfileitemfrm" + i))
                return i;
        }
        return 0;
    }
    this.Uploading = function() {
        var scrollPos	= new getScrollPos();				
        var pageSize	= new getPageSize();
        
        $("uploadingbg").style.display = "block";
        $("uploadingbg").style.height=(pageSize.height + scrollPos.scrollY) + "px";
        $("uploading").style.display = "block";
        
        var x = Math.round(pageSize.width/2) - (dWidth /2) + scrollPos.scrollX;
	    var y = Math.round(pageSize.height/2) - (dHeight /2) + scrollPos.scrollY;        
        
        $("uploading").style.width = dWidth + "px";
        $("uploading").style.height = dHeight + "px";
	    $("uploading").style.left	= x+'px';			
	    $("uploading").style.top= y+'px';
    }
    this.AddFileItem = function() {
        if(this.index > this.maxAmount) return;
        var uploadfileitem = document.createElement("div");
        uploadfileitem.id = "uploadfileitemfrm" + this.index;
        var tmphtml = "";
        //��������޸Ĳ���û�г�������ļ��� ������¼�
        if("" == GetQueryString("AtID"))
            tmphtml = "onchange=\"" + obj + ".AddFile(" + this.index + ")\"";

        uploadfileitem.innerHTML = "<input type=\"file\" id=\"file" + this.index + "\" name=\"file" + this.index + "\" " + tmphtml + " />";
        uploadfilefrm.appendChild(uploadfileitem);
        
        this.index++;
    }
    this.DelFile = function(objIndex) {
        uploadfilefrm.removeChild($("uploadfileitemfrm" + objIndex));
        this.maxAmount++;
        this.AddFile(objIndex);
    }
}

var objuploadfile = new UploadFileForFile("objuploadfile");

function UploadImageInitForAspx(){
    objuploadfile.maxAmount = (parent.objUpload.maxAmount - parent.objUpload.index) + 2;
    if(objuploadfile.maxAmount <= 0) {
        parent.sAlert("�Ѿ������ϴ��ļ����������ߣ������ٴ��ļ���");
        UploadClose();
    }
    objuploadfile.Init();
}

//ͼƬ�ϴ����
function UploadImageSave(msg,filelist) {
    parent.objUpload.Save(msg,filelist);
    UploadImageClose();
}

//ͼƬ�ϴ����ڹر�
function UploadImageClose() {
    parent.objUpload.Close();
}

//ͼƬ�ϴ�������
function uploadImageing() {
    objuploadfile.Uploading();
}


/*************************************/
/*     �����ϴ����js                */
/*************************************/


function UploadFile(objName) {
    this.index = 1;
    this.maxAmount = 0;
    
    //var defaultImg = "/Common/Images/DefaultImg.gif";    
    var obj = objName;    
    var ids,files;    
    var uploaddiv;    
    var dWidth = 400;//�Ի�����
    var dHeight = 300;//�Ի���߶�
    var addIndex = 0;//�����ļ���divλ������
    //var editIndex = 0;//�޸��ļ���divλ������
    //var ac = 0;//��ǰ�Ĳ������� 0 ��� 1 �޸�
    
    this.Init = function() {
        uploaddiv = $("_UploadFile");
        ids = $F("_Upload_IDs");
        files = $F("_Upload_Files");

        this.maxAmount = parseInt($F("_Upload_MaxAmount"));
        
        //���õ������͸������
        var uploadbg = document.createElement("div");
        uploadbg.id="_uploadbg";
        uploadbg.className="upload_bg";    
        uploaddiv.appendChild(uploadbg);
        //���õ�����
        var uploadfrm = document.createElement("iframe");
        uploadfrm.id="_uploadfrm";
        uploadfrm.className="upload_frm";
        uploadfrm.frameBorder = 0;
        uploaddiv.appendChild(uploadfrm);
        
        if("" != ids) {
            var arrid = ids.split("|");
            var arrFile = files.split("|");
            for(var i = 0;i<arrid.length;i++) {
                this.AddItem(arrid[i],arrFile[i]);
            }
        }
        this.AddItem("","");
    }
    this.AddItem = function(id,filePath) {
        if("" == id && this.index > this.maxAmount) return;
        if(0 != addIndex) return;
        if("" == id) addIndex = this.index;
        var uploaditem = document.createElement("div");
        uploaditem.id = "_uploadFileItem" + this.index;
        uploaditem.className = "upload_fileitem_byfile";
        var htmlcode = "<ul class='Upload_File'><li id=\"File" + this.index + "\">"
        htmlcode +="<em>" + filePath + "</em>";
        if("" == id) {
            htmlcode += "<a class=\"Upload_btn\" href=\"javascript:" + obj + ".Show('" + id + "'," + this.index + ");\">[�ϴ�]</a>";
        }
        else {
            //htmlcode += "<a class=\"Upload_btn\" href=\"javascript:" + obj + ".Show('" + id + "'," + this.index + ");\">[�޸�]</a>&nbsp;";
        }
        htmlcode += "<span><a class=\"Upload_btn\" href=\"javascript:" + obj + ".DelItem(" + this.index + ",'" + id + "');\"" + (("" == id || "0" == id) ? " style=\"display:none;\"" : "") + ">[ɾ��]</a></span>"
        htmlcode += "</li></ul>";

        uploaditem.innerHTML = htmlcode;
        uploaddiv.appendChild(uploaditem);
        this.index++;
    }
    this.DelItem = function(objIndex,id) {
        uploaddiv.removeChild($("_uploadFileItem" + objIndex));
        this.maxAmount++;
        if("" != id) {//ɾ�����ļ�����Ŀ
            $("_Upload_DelIDs").value = "" == $F("_Upload_DelIDs") ? id : $F("_Upload_DelIDs") + "," + id;
            this.AddItem("","");
        }
        else {//ɾ�������ļ� ����������ļ���divλ������
            addIndex = 0;
        }
    }
    this.Show = function(id,objIndex) {
        var scrollPos	= new getScrollPos();				
        var pageSize	= new getPageSize();
        if("" == id) {
            ac = 0;
            addIndex = objIndex;
        }
        else {
            ac = 1;
            editIndex = objIndex;
        }
        
        $("_uploadbg").style.display = "block";
        $("_uploadbg").style.height = pageSize.docheight + "px";
        $("_uploadfrm").style.display = "block";
        
        var x = Math.round(pageSize.width/2) - (dWidth /2) + scrollPos.scrollX;
	    var y = Math.round(pageSize.height/2) - (dHeight /2) + scrollPos.scrollY;        
        $("_uploadfrm").src = "/upload/UploadImage." + config.Suffix + "?filetype=file&TabName=" + $F("_Upload_TabName") + "&AtID=" + id + "&tmp=" + Math.random();
        $("_uploadfrm").style.width = dWidth + "px";
        $("_uploadfrm").style.height = dHeight + "px";
	    $("_uploadfrm").style.left	= x+'px';			
	    $("_uploadfrm").style.top= y+'px';
    }
    this.Save = function(msg,filelist) {
        if(filelist.length > 0) {
            if(0 == ac) {
                this.DelItem(addIndex,"");
                for(var ifile = 0; ifile < filelist.length; ifile++) {
                    $("_Upload_UpIDs").value = "" == $F("_Upload_UpIDs") ? filelist[ifile].id : $F("_Upload_UpIDs") + "," + filelist[ifile].id;
                    this.AddItem(filelist[ifile].id,filelist[ifile].url);
                }
                this.AddItem("","");
            }
            else {
                $("File" + editIndex).innerHTML = filelist[0].url;
            }
        }
        if("" != msg) sAlert(msg);
    }
    this.IsUploadFile = function() {
        var upids = $F("_Upload_UpIDs");
        var delids = $F("_Upload_DelIDs");
        var oldids = $F("_Upload_IDs");
        if("" != oldids) {
            var arr = oldids.split("|");
            for(var iid = 0; iid < arr.length; iid++) {
                if(delids.indexOf(arr[iid]) == -1)
                    return true;
            }
        }
        if("" != upids) {
            var arr = upids.split("|");
            for(var iid = 0; iid < arr.length; iid++) {
                if(delids.indexOf(arr[iid]) == -1)
                    return true;
            }
        }
        return false;
    }
    this.Close = function() {
        $("_uploadbg").style.display = "none";
        $("_uploadfrm").style.display = "none";
        $("_uploadfrm").src = "";
    }
    /*this.GetHtml = function(filepath) {
        return "<img src=\"" + ("" == filepath ? defaultImg : filepath) + "\" alt=\"\" width=\"100\" onload=\"SetImgSize(this,100,100);\" />";
    }*/
}


var objUploadFile = new UploadFile("objUploadFile");

//�����ϴ���ʼ��
function _UploadFileInit() {
    objUploadFile.Init();
}



//�Ƿ����ļ�
function _IsUploadFile() {
    return objUploadFile.IsUploadFile();
}

//�ϴ��ļ�ҳ����Ҫ����
function UploadFileForAspx(objName) {
    this.index = 1;
    this.maxAmount = 0;
    var obj = objName;    
    var uploadfilefrm;
    var dWidth = 300;//�Ի�����
    var dHeight = 80;//�Ի���߶�
    var uploadingImg = "/Common/Images/ajax-loader.gif";
    
    this.Init = function() {
        uploadfilefrm = $("uploadfilefrm");

        this.AddFileItem(this.index);
        //�ϴ��еȴ�Ч����͸������
        var uploadingbg = document.createElement("div");
        uploadingbg.id="_uploadingbg";
        uploadingbg.className="upload_bg";    
        uploadfilefrm.appendChild(uploadingbg);
        //�ϴ��еȴ�Ч��
        var uploading = document.createElement("div");
        uploading.id="_uploading";
        uploading.className="upload_ing";
        uploading.innerHTML = "�ϴ��У����Ե�...<br /><img src=\"" + uploadingImg + "\" alt=\"\" />";
        uploadfilefrm.appendChild(uploading);
    }
    this.AddFile = function(objindex) {
        //����ɾ����ť
        this.AddDeleteBtn(objindex);
        //����пյ��ļ����˳�
        var lastindex = this.LastFileIndex(objindex);
        if(0 != lastindex) {
            if("" != $F("_file" + lastindex))
               this.AddFileItem();
        }
        else
            this.AddFileItem();
    }
    this.AddDeleteBtn = function(objindex) {
        if(!$("_btnDel" + objindex) && $("_uploadfileitemfrm" + objindex)) {
            var btndel = "<input type=\"button\" id=\"" + "_btnDel" + objindex + "\" onclick=\"" + obj + ".DelFile(" + objindex + ");\" />";
            insertHtml("beforeend",$("_uploadfileitemfrm" + objindex),btndel);
        }
    }
    this.LastFileIndex = function(objindex) {
        for(var i = this.maxAmount; i > objindex; i--) {
            if($("_uploadfileitemfrm" + i))
                return i;
        }
        return 0;
    }
    this.Uploading = function() {
        var scrollPos	= new getScrollPos();				
        var pageSize	= new getPageSize();
        
        $("_uploadingbg").style.display = "block";
        $("_uploadingbg").style.height=(pageSize.height + scrollPos.scrollY) + "px";
        $("_uploading").style.display = "block";
        
        var x = Math.round(pageSize.width/2) - (dWidth /2) + scrollPos.scrollX;
	    var y = Math.round(pageSize.height/2) - (dHeight /2) + scrollPos.scrollY;        
        
        $("_uploading").style.width = dWidth + "px";
        $("_uploading").style.height = dHeight + "px";
	    $("_uploading").style.left	= x+'px';			
	    $("_uploading").style.top= y+'px';
    }
    this.AddFileItem = function() {
        if(this.index > this.maxAmount) return;
        var uploadfileitem = document.createElement("div");
        uploadfileitem.id = "_uploadfileitemfrm" + this.index;
        var tmphtml = "";

        //��������޸Ĳ���û�г�������ļ��� ������¼�
        if("" == GetQueryString("AtID"))
            tmphtml = "onchange=\"" + obj + ".AddFile(" + this.index + ")\"";

        uploadfileitem.innerHTML = "<input type=\"file\" id=\"_file" + this.index + "\" name=\"_file" + this.index + "\" " + tmphtml + "/>";
        
        uploadfilefrm.appendChild(uploadfileitem);
        
        this.index++;
    }
    this.DelFile = function(objIndex) {
        uploadfilefrm.removeChild($("_uploadfileitemfrm" + objIndex));
        this.maxAmount++;
        this.AddFile(objIndex);
    }
}

var objuploadfileForAspx = new UploadFileForAspx("objuploadfileForAspx");

function UploadFileInitForAspx(){

    objuploadfileForAspx.maxAmount = (parent.objUploadFile.maxAmount - parent.objUploadFile.index) + 2;

    if(objuploadfileForAspx.maxAmount <= 0) {
        parent.sAlert("�Ѿ������ϴ��ļ����������ߣ������ٴ��ļ���");
        UploadFileClose();
    }
    objuploadfileForAspx.Init();
}

function _UploadFileSave(msg,filelist) {
    parent.objUploadFile.Save(msg,filelist);
    UploadFileClose();
}

//�ر��ļ��ϴ�����
function UploadFileClose() {
    parent.objUploadFile.Close();
}

//�ļ��ϴ�������
function uploadFileing() {
    objuploadfileForAspx.Uploading();
}


/***************��������(UploadImage.aspxҳ�����)*********************/
function uploading() {
    var fileType =GetQueryString("fileType");
    
    if(fileType=="file")
        uploadFileing();
    else
        uploadImageing();
}


function UploadFileInit() {
    var fileType =GetQueryString("fileType");
    
    if(fileType=="file")
        UploadFileInitForAspx();
    else
        UploadImageInitForAspx();
}

function UploadClose() {
    var fileType =GetQueryString("filetype");
    if(fileType=="file")
        UploadFileClose();
    else
        UploadImageClose();
}

function UploadFileSave(msg,filelist) {
    var fileType =GetQueryString("filetype");
    if(fileType=="file")  
        _UploadFileSave(msg,filelist);
    else
        UploadImageSave(msg,filelist); 
}
/************************************************/