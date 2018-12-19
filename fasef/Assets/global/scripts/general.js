var General = function() {
	var initDatatable = function(){
		var init = {};

		$('.dataTable').each(function () {
			init["order"] = [];
			if ($(this).hasClass('no-sort')) init["bSort"] = false;
			if ($(this).hasClass('scroll-horizontal')) init["scrollX"] = true;
			if ($(this).hasClass('no-search')) init["bFilter"] = false;

			init["pagingType"] = "bootstrap_full_number";
			// init["responsive"] = true;
			// init["columnDefs"] = [
   //              {  // set default column settings
   //                  'orderable': false,
   //                  'targets': [0]
   //              }, 
   //              {
   //                  "searchable": false,
   //                  "targets": [0]
   //              },
   //              {
   //                  "className": "dt-right", 
   //                  //"targets": [2]
   //              }
   //          ];

   if (!$.fn.dataTable.isDataTable(this)) {
   	try {
   		$(this).DataTable(
   		                  init
   		                  );
   	} catch (e) {
   		alert(e);
   	}
   }
});
	};

	var initActiveLink = function(){
		var path = location.href;
		$('.nav-item > a[href="' + path + '"]').closest('li').addClass('active');
	};

	var initSummernote = function(){
		$('.summerNote').each(function () { 
			$(this).summernote({height: 300});
		});
	};

	var initDatepicker = function(){
		if (jQuery().datepicker) {
			$('.date-picker').datepicker({
				rtl: App.isRTL(),
				orientation: "left",
				autoclose: true
			});
            //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
        }
    };

    var initTimepicker = function() {
    	if($('.timepicker').length){
    		$('.timepicker').timepicker({
    			autoclose: true,
    			minuteStep: 5,
    			showSeconds: false,
    			showMeridian: false,
    			defaultTime: 'value'
    		});
    	}
    };

    var initBootstrapSelect = function(){
    	if($('.bs-select').length){
    		$('.bs-select').selectpicker({
    			iconBase: 'fa',
    			tickIcon: 'fa-check'
    		});
    	}
    };

    return{
    	init: function() {		
    		initDatatable();
    		initSummernote();
    		initDatepicker();
    		initTimepicker();
    		initBootstrapSelect();
    		initActiveLink();
    	},

    	thousandSeparator: function(){
    		return "ini lho"
    	},

    	alert_delete: function(obj){
    		swal({
    			title: "Are you sure?",
    			text: "Your will not be able to recover this data!",
    			type: "warning",
    			showCancelButton: true,
    			confirmButtonClass: "btn-danger",
    			confirmButtonText: "Yes, delete it!"
    		},
    		function(){
    			location.href = $(obj).attr("href");
    		});
    	},

    	alert_disable: function(obj){
    		swal({
    			title: "Are you sure?",
    			text: "Selected user will be not able to access Intelli Outsource!",
    			type: "warning",
    			showCancelButton: true,
    			confirmButtonClass: "btn-danger",
    			confirmButtonText: "Yes, disable it!"
    		},
    		function(){
    			location.href = $(obj).attr("href");
    		});
    	},

    	alert_interview: function(obj){
    		swal({
    			title: "Are you sure?",
    			text: "Your will create iterview schedule",
    			type: "info",
    			showCancelButton: true,
    			confirmButtonClass: "btn-success",
    			confirmButtonText: "Yes, assign it!"
    		},
    		function(){
    			return true;
    		});	
    	},

    	alert_assign: function(obj, comp_name, job_name){
    		var tr = $(obj).parents("tr");
    		var td = $(tr).find("td").eq(0);
    		var name = td.data("candidate-name");

    		swal({
    			title: "Are you sure?",
    			text: "Your will assign "+name+" to "+comp_name+" as " + job_name,
    			type: "info",
    			showCancelButton: true,
    			confirmButtonClass: "btn-success",
    			confirmButtonText: "Yes, assign it!"
    		},
    		function(){
    			location.href = $(obj).attr("href");
    		});	
    	},

    	notification: function(options) {
    		ops = $.extend(true, {
    			container: "",
    			type: 'success',
    			message: "",
    			autoclose: false,
    			icon: ""


    		}, options);

    		var type = ops.type;
    		var closeInSeconds = ops.autoclose ? 5 : 0;
    		var icon = ops.type == "success" ? "check" : ops.type;

    		App.alert({
    			container: ops.container,
    			type: type,
    			message: ops.message,
    			closeInSeconds: closeInSeconds, 
    			icon: icon
    		});
    	}
    }
}();

jQuery(document).ready(function() {    
	General.init();
});

function pad(n, width, z) {
	z = z || '0';
	width = width || 2;
	n = n + '';
	return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
}

var Clock = 
{
    start: function (timeout) {
    	var totalSeconds = localStorage["timeout"] ? localStorage["timeout"] : timeout;
        var self = this;

        if(isNaN(totalSeconds)){
        	console.log("timer did not started");
        }else{
        	console.log("timer started");
	        this.interval = setInterval(function () {
				var min = pad(Math.floor((totalSeconds/60)%60));
				var sec = pad(parseInt(totalSeconds%60));
				console.log(min + ":" + sec);
				$("#timer").text(min + ":" + sec);
				localStorage["timeout"] = totalSeconds;

				if(totalSeconds == 0){
                    $("#next-btn").click();
					//self.stop();
				}else if(totalSeconds == 10){
					$("#timer").addClass("font-red");
				}

				totalSeconds -= 1;
	        }, 1000);

	        return totalSeconds;
        }
    },

    resume: function () {
    	this.start(localStorage["timeout"]);
    },

    pause: function () {
		clearInterval(this.interval);
		delete this.interval;
    },

    stop: function() {
    	clearInterval(this.interval);
    	delete this.interval;
    	localStorage.removeItem("timeout");
    }
};

function throttle(fn, delay) {
    var _this, args;
        var scheduled = false;
        var call = function () {
            scheduled = false;
            fn.apply(_this, args);
        };
        return function() {
            _this = this;
            args = arguments;
            if (scheduled) {
                return;
            }
            scheduled = true;
            setTimeout(call, delay || 66);
        }
}
var i = 0;
function scrollTo(a){
    console.log(++i);
    console.log(a);
}


//window.addEventListener('scroll', throttle(scrollTo, 1000));


function debounce(func, wait, immediate) {
    var timeout;
    return function() {
        var context = this, args = arguments;
        var later = function() {
            timeout = null;
            if (!immediate) func.apply(context, args);
        };
        var callNow = immediate && !timeout;
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
        if (callNow) func.apply(context, args);
    };
};

//window.addEventListener('scroll', debounce(scrollTo, 250));

var Pointer = {
    changePointer: function(direction, e) {
        var elem = $(".quest_list");
        var curr = $(".quest_list.active");
        var target = direction == "up" ? $(curr).prev() : $(curr).next();
        var input_trg = $(target).find(".input-text");

        if(curr.length > 0){
            e.preventDefault();
            if((direction == "up" && !$(curr).is(':first-child')) || (direction == "down" && !$(curr).is(':last-child'))){
                $(curr).removeClass("active");
                $(target).addClass("active");
                $(input_trg).focus();

                var offset = $(target).offset().top - (window.innerHeight/2) - ($(target).height()/2) + 50
                
                $('html, body').animate({
                    scrollTop: offset
                }, 100);
            }
        }else{

        }

    },

    handleArrow: function(e) {
        // e.preventDefault();
        switch(e.which) {
            // tab button
            case 9:
                this.changePointer("down", e);
                break;
            //move up
            case 38:
                this.changePointer("up", e);
                break;
            //move down
            case 40:
                this.changePointer("down", e);
                break;

            //right
            case 39:
                $("#next-btn").click();
                break;
            //left
            case 37:
                $("#prev-btn").click();
                break;            
        };
    },

    handleNumber: function(e) {
        var curr = $(".quest_list.active");
        var keyCode = e.which;
        
        if (keyCode >= 96 && keyCode <= 105) {
            // Numpad keys
            keyCode -= 48;
        }

        var number = String.fromCharCode(keyCode);
        
        if(number >= 1 && number <= 5){
            var target = $(curr).find("input[data-option='"+number+"']");
            $(target).iCheck('check');
        }
        
    }
};