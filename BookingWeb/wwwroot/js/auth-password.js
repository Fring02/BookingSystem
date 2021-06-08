$(document).ready(function() {

    $('#password').blur(function(){
          if($('#repassword').val() == ''){

            $('.msg').css({"color":"orange"});
            $('.msg').html('Do not forget to retype password');
            $("#regBtn").attr("disabled", true);
            $("#regBtn").css({"background-color":"gray"});

          }

          if($(this).val().length <= 6){
            $('.msg').css({"color":"orange"});
            $('.msg').html('Password should be more than 6 characters');
            $("#regBtn").attr("disabled", true);
            $("#regBtn").css({"background-color":"gray"});
          }
    });

    $('#repassword').blur(function(){

            if($('#password').val() == $('#repassword').val()){
              $("#regBtn").attr("disabled", false);
              $("#regBtn").css({"background-color":"rgba(41, 89, 124, 0.9)"});
              $('.msg').css({"color":"green"});
              $('.msg').html('Passwords matches!');


            } else {

              $('.msg').css({"color":"orange"});
              $('.msg').html('Passwords not match! Retype again!');
              $("#regBtn").attr("disabled", true);
              $("#regBtn").css({"background-color":"gray"});

            }

    });

  });
