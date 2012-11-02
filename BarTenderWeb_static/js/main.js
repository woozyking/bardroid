$.ajaxSetup ({
	cache: false
});

// real meat starts
$( function() {
	// TODO: load this only if liquor-tos page is active
	$('#tos').load('static/tos.html');
	
	$("#breath-start").click(function() {
		$.mobile.changePage( "#test" );
		
		$.ajax({
			type: "POST",
			url: "./Default.aspx/TestComm",
            data: "{queryString:'interval=15000&pass=1'}",
            dataType: "json",
			// TODO: put a proper timeout
			success: function( result ) {
				// pass
				$.mobile.changePage("#pass");
			},
			error: function() {
				$.mobile.changePage("#pass", "pop");
				//$.mobile.changePage("#fail");
			}
        });
	});
} );