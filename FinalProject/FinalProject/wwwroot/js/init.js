(function($){
  $(function(){

    var showLogin = false;
    var showRefine = false;

    $('.sidenav').sidenav();
    $('.parallax').parallax();
    $('select').formSelect();

    $('.loginSection').hide();
    $('.loginSectionSmall').hide();
    $('.refineSearch').hide();

    $('.showLogin').click(function(){
      if ( showLogin ){
        $('.loginSection').slideUp();
        $('.loginSectionSmall').slideUp();
        showLogin = false;
      } else {
        $('.loginSection').slideDown();
        $('.loginSectionSmall').slideDown();
        showLogin = true;
      }
    });

    $('#refineBtn').click(function(){
      if ( showRefine ){
        $('.refineSearch').slideUp();
        showRefine = false;
      } else {
        $('.refineSearch').slideDown();
        showRefine = true;
      }
    });

    $('.studentListItem').children().css("background-color","#f5f5f5");

    $('.studentListItem').mouseover(function(){
      $(this).css("cursor","pointer");
      $(this).children().css("background-color","#eeeeee");
    });
    $('.studentListItem').mouseout(function(){
      $(this).children().css("background-color","#f5f5f5");
    });

    // Handle Messaging a teacher

    $(".messageContainer").hide();

      $(".messageTeacher").click(function () {
        $(".messageContainer").fadeIn();
      });

      $("#sendMessageButton").click(function () {
          $.post("/Messages/SendMessage", { "id": "1", "message": "hey" }, function (data) {
              alert(data);
          });
      });

    $(".closeButton").click(function(){
      $(".messageContainer").fadeOut();
    });

    $(".messageContainer").click(function(e){
      
      if ($(e.target).attr('class') == "messageContainer"){
      $(".messageTextArea").val('');
      $(".messageContainer").fadeOut();
      }
    });

    function plugin(holder,className,time){
      var name = className;
      var count = 0;
      var children = $(holder).children();

      var fade = function(){
        if ( count == children.length) {
          $(name+"1").fadeIn();
          for ( var i = 2; i < children.length+1; i ++){
            $(name+i).fadeIn();
          }
          count=1;
        } else {
        $(name+count).fadeOut();
        count++;
        }
        setTimeout(fade,time);
      }
      fade();
    }

    // ----------------------------------------------------------------- ADD A TEST FOR "IS IT THE MAIN PAGE" THEN ALLOW IT TO RUN
    var getPage = window.location.pathname.split("/");
    if ( getPage[getPage.length-1] == "index.html" ){

    plugin(".holdCards",".float-",3000);
    plugin(".holdCards2",".float2-",3000);
    plugin(".holdCards3",".float3-",3000);
    }

    // Handle Calendar

    function formatDate(date) {
      var monthNames = [
        "January", "February", "March",
        "April", "May", "June", "July",
        "August", "September", "October",
        "November", "December"
      ];
      var dayNames = ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"];
      var day = date.getDate();

      var monthIndex = date.getMonth();
      var year = date.getFullYear();
    
      return day+" (" + dayNames[date.getDay()] + ") " + ' ' + monthNames[monthIndex] + ' ' + year;
    }

    // Print The Entire Week From Today
    var day = new Date();
    console.log(formatDate(day));
    for ( var i = 0; i < 7; i ++){
      
      var nextDay = new Date(day);
      nextDay.setDate(day.getDate()+i);
      $("#test").append(formatDate(nextDay)+"<br />");
      
    }

    // Clicking Available Hour

    $(".calendarAvailable").click(function(){
      console.log("Available: "+$(this).parent().attr("date")+" " + ($(this).text()).split(" ").join(""));
    });

    // Clicking Taken Hour

    $(".calendarTaken").click(function(){
      console.log("Taken: "+$(this).parent().attr("date") +" "+ ($(this).text()).split(" ").join(""));
      });

  }); // end of document ready
})(jQuery); // end of jQuery name space
