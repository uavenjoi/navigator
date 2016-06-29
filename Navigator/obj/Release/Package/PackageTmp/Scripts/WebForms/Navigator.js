function OnSelected() {
	document.getElementById("fileUpload").click();
}

function OnFileUploaded() {
	document.getElementById("fileName").value = document.getElementById("fileUpload").value;

}

function OnProcessClick() {
	var fileName = document.getElementById("fileUpload").value;
	PageMethods.ProcessFile(fileName);
}












//$("document").ready(function () {
//	document.getElementById("fileUpload").onchange = function () {
//		alert("Hello");
//		document.getElementById("fileName").value = document.getElementById("fileUpload").value;
//	};
//});