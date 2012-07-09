var collapsed = getcookie('cdb_collapse');
function collapse_change(menucount) {
    var i = 1;
    for(i=1;i<=14;i++)
    {
        var menu = $('menu_' + i);
        var img = $('menuimg_' + i);
        if(menu!=null && img !=null)
        {
            if(i==menucount && menu.style.display == 'none')
            {
	            menu.style.display = '';
                collapsed = collapsed.replace('[' + menucount + ']' , '');
                img.src = 'images/menu_reduce.gif'; 
	        }
	        else
	        {   
                menu.style.display = 'none';
	            collapsed += '[' + i + ']';
	            img.src = 'images/menu_add.gif';
	        }
	    }
    } 
	setcookie('cdb_collapse', collapsed, 2592000);
}