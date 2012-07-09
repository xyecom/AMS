

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


function addMouseEvent() {
	//为输入框添加焦点效果
	var inputs=getElementsByTagNames('input,textarea');
	for (i=0;i<inputs.length;i++) {
		var inputtype = inputs[i].type.toLowerCase();
		if(inputtype == 'checkbox' || inputtype == 'radio' || inputtype == 'button'|| inputtype == 'submit') continue;
		inputs[i].onfocus=function() {
			this.className='focus';
			var temptips=document.getElementById(this.id+'tips');
			if (temptips && GetCookie('spTips')==1) {
				temptips.style.display='block';
				//temptips.style.width=this.offsetWidth-10+'px';
				temptips.style.top=findPosY(this)-4+'px';
				temptips.style.left=findPosX(this)+this.offsetWidth+3+'px';
				//alert(findPosY(this));
			}
		}
		inputs[i].onblur=function() {
			this.className='';
			var temptips=document.getElementById(this.id+'tips');
			if (temptips) {
				myTimeout = window.setTimeout(function() {temptips.style.display='none';}, 0); 
				//temptips.style.display='none';
			}
		}
	}

	
	//为IE下的Checkbox和Radio去处背景色
	if (isIE>-1) {
		minputs=document.getElementsByTagName('input');
		for(i=0;i<minputs.length;i++){
			
			if(minputs[i].type=='checkbox'||minputs[i].type=='radio'){
				minputs[i].style.backgroundColor='transparent';
				minputs[i].style.backgroundImage='none';
				minputs[i].style.border='none';
			}
		}
	}
}





