mergeInto(LibraryManager.library, {


 /* HelloString: function (str) {
    window.alert(Pointer_stringify(str));
  },
  */
  PlayVideo: function (str){
		document.getElementById("ig-videoArea").style.display = "block";
		 var vid = document.getElementById("ig-videoPlayer");
		 console.log(Pointer_stringify(str));
		 vid.currentTime = 0;
         vid.innerHTML = "<source src=\""+ Pointer_stringify(str) +"\" type=\"video/mp4\">Your browser does not support the video tag."; 
		 vid.play();
	},
});
