mergeInto(LibraryManager.library, {


  PlayVideo: function (str){
		document.getElementById("ig-videoArea").style.display = "block";
		 var vid = document.getElementById("ig-videoPlayer");
		 console.log(Pointer_stringify(str));
		 // use below line if using Vimeo
		 vid.innerHTML = "<iframe src=\""+ Pointer_stringify(str) +"\" scrolling=\"no\" style=\"overflow: hidden;\" width=\"960\" height=\"540\" frameborder=\"0\" allow=\"autoplay; fullscreen\" allowfullscreen></iframe>";

	  /*
		// use if using locally stored videos
		vid.innerHTML = "<source src=\""+ Pointer_stringify(str) +"\" type=\"video/mp4\">Your browser does not support the video tag."; 
	  */

	},
});
