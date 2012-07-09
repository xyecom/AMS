function switchShow(id){
var tObj = document.getElementById("div_"+id);
var iObj = document.getElementById("a_"+id);
if(tObj) tObj.style.display=(tObj.style.display=='none')?"block":"none";
if(iObj&&tObj)iObj.className=(tObj.style.display=='none')?"act":"";
//alert(tObj.style.display);
}
