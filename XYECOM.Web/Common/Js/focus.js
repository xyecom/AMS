/*2010*/
    function FOCUS(widths,heights,Url,Links,Title)
    {
		
		var width = widths;
		var height = heights;
		var picUrl = '';
		var picLink = '';
		var picTitle = '';

		picUrl = Url.substring(0,Url.length-1);
		picLink = Links.substring(0,Links.length-1);
		picTitle = Title.substring(0,Title.length-1);		
		
		document.write('<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" id=scriptmain name=scriptmain codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="'+ width +'" height="'+ height +'">');
		document.write('<param name="movie" value="/templates/default/js/focus.swf?bcastr_flie='+picUrl+'&bcastr_link='+picLink+'&bcastr_title='+picTitle+'">');
		document.write('<param name="quality" value="high">');
		document.write('<param name="scale" value=noscale>');
		document.write('<param name="LOOP" value="false">');
		document.write('<param name="menu" value="false">');
		document.write('<param name="wmode" value="transparent">');
		document.write('<embed src="/templates/default/js/focus.swf?bcastr_flie='+picUrl+'&bcastr_link='+picLink+'&bcastr_title='+picTitle+'" width="'+ width +'" height="'+ height +'" loop="false" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" salign="T" name="scriptmain" menu="false" wmode="transparent"></embed>');
		document.write('</object>');
		
		var div = document.getElementById("news_slide");
		if(!document.all){
			div.innerHTML += '';
		}
	}
