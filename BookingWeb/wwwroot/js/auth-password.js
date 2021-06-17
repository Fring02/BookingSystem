$(document).ready(function() {

    $('#password').blur(function(){
          if($('#repassword').val() == ''){
            $('.msg').css({"color":"orange"});
            $('.msg').html('Do not forget to retype password');
            $("#regBtn").attr("disabled", true);
            $("#regBtn").addClass('disabled');
          }

          if($(this).val().length <= 6){
            $('.msg').addClass('text-danger');
            $('.msg').html('Password should be more than 6 characters');
            $("#regBtn").attr("disabled", true);
            $("#regBtn").addClass('disabled');
          }
    });

    $('#repassword').blur(function(){

            if($('#password').val() == $('#repassword').val()){
              $("#regBtn").attr("disabled", false);
              $("#regBtn").removeClass('disabled');
              $('.msg').removeClass('text-danger');
              $('.msg').addClass('text-success');
              $('.msg').html('Passwords matches!');


            } else {

              $('.msg').removeClass('text-success');
              $('.msg').addClass('text-danger');
              $('.msg').html('Passwords not match! Retype again!');
              $("#regBtn").attr("disabled", true);
              $("#regBtn").addClass('disabled');

            }

    });

  });
