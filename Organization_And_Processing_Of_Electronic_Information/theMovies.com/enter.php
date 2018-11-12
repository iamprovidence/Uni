<?php session_start();?>
<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; ?>
	<title>Вхід</title>
	<script>
        $(document).ready(function()
        {
            $("div.btn").click(function()
            {
                $('#messageshow').hide();
                var login = $("#login").val();
                var password = $("#password").val();
                var fail = "";
            
                if(login.length < 3)
                    {
                        fail = "Ім'я надто коротке";
                    }
                else if(password.length < 5)
                    {
                        fail = "Надто короткий пароль";
                    }
    
            if(fail != "")
                {
                    $('#messageshow').html (fail + "<div class='clear'><br/></div>");
                    $('#messageshow').show();
                    return false;
                }
                $.ajax(
                {
                    url: '/ajax/enter.php',
                    type: 'POST',
                    cache: false,
                    data: {'login': login, 'password':password},
                    dataType: 'html',
                    success: function(data)
                    {
                        $('#messageshow').html (data + "<div class='clear'><br/></div>");
                        $('#messageshow').show();
                    }
                });
            });
        });
    </script>
</head>
<body>
	<div id="wrapper">
    	<div id="content">
            <?php require "parts/header.php"; ?>
            <?php require "parts/nav.php"; ?>     
             
            <div id="main">
	            <div id="news">
                    <h2 class="heading">Вхід на сайт</h2>
                    <div style="clear:both"><br></div>
                    <div class="kontakt">
                        Щоб увійти на сайт використайте свій email і пароль, які були вказані при реєстрації
                        <form>
                            <div>
                                <input type="email" id="email" placeholder="Email...">
                            </div>
                            <div>
                                <input type="password" id="password" placeholder="Ваш пароль">
                            </div>
                            <a href="">
                            <div class="btn">
                                <p id="send">Увійти</p>
                            </div>
                            </a>
                        </form>
                    </div>
				</div>
            </div>
            
            <?php require "parts/aside.php"; ?>
            <?php require "parts/start.php"; ?>
		</div>
        <?php require "parts/footer.php"; ?>
    </div>
<?php require "parts/jq.php"; ?>    
</body>
</html>