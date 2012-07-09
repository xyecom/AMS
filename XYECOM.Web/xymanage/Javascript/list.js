
/** 选项卡相关  **/
function setCurTab(m,n){
    var tli=document.getElementById("mainMenus"+m).getElementsByTagName("li"); 
    for(i=0;i<tli.length;i++){
        tli[i].className=i==n?"hover":""; 
    }
}

