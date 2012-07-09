function ImageShow(objName,imgarr,docShow,docList) {
    var index = 0;
    this.Init = function() {
        if(imgarr.length <= 0) return;
        var listhtml = "";
        for(var i=0; i< imgarr.length; i++) {
            listhtml += "<img src=\"" + imgarr[i] + "\" onclick=\"" + objName + ".ShowImg('" + docShow + "'," + i + ");\" />";
        }
        $(docList).innerHTML = listhtml;
        
        this.ShowImg(docShow,index);
    }
    
    this.ShowImg = function(docShow,imgindex) {
        index = imgindex;
        $(docShow).innerHTML = "<img src=\"" + imgarr[imgindex] + "\" onclick=\"" + objName + ".SelectImg()\" onload=\"SetImgSize(this,900)\" />";
    }
    
    this.SelectImg = function() {
        if(index>=imgarr.length) index = 0;
        this.ShowImg(docShow,index);
        index++;
    }
}
