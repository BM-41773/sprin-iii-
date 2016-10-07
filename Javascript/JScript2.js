$(document).ready(function(){
    $("#login").click(function(){
        var username = $(".username").val();
        var password = $(".password").val();
        $.ajax({
        url : "http://api.baabtra.com/LoginService/login.php",
        data : { email : username , password : password},
        success:function(result){
        console.log(result);
        alert(result);
        }
            });
                });
                    });


