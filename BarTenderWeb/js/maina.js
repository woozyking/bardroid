$(document).ready(function() {
	// initial state
	$("#instrA").hide();
	$("#discA").hide();
	
	// for left case
	$("#drink-1").click(function() {	
		var id = 0 ; // evaluation of the populated drink id
		$.ajax({
              type: "POST",
              url: "./Default.aspx/TestCom",
              contentType: "application/json; charset=utf-8",
              data: "{1}",
              dataType: "json",
              success: AjaxSucceeded,
              error: AjaxFailed
        }); 
	});
	
	$("#ledOff").click(function() {
		// hide #discA
		$("#discA").fadeOut("normal", function(){
			// show #selA
			$("#selA").fadeIn();
		});
		
		$.ajax({
              type: "POST",
              url: "./Default.aspx/PumpOff",
              contentType: "application/json; charset=utf-8",
              data: "{}",
              dataType: "json",
              success: null,
              error: AjaxFailed
        }); 
	});
	
	// for right case
	
});

function AjaxSucceeded(result) {
    if (result == "\0")
    {
        // get content from #instrA
        var content = $("#instrA").html();
		
        // hid #selA
        $("#selA").fadeOut("normal", function(){
            // load to the target div
            $("#right").html(content);
			
            // show #discA
            $("#discA").fadeIn();
        });
    }
    else
    {
        alert("Fuck");
    }
}

function AjaxFailed(result) {
    alert('failed' + result.status + ' ' + result.statusText);
}  

$("#TriggerEvent").click(function(){

});