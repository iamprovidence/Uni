<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; ?>
	<title>Реєстрація</title>
	<script>
            $(document).ready(function()
        {
            $("#registr").click(function()
            {
                $('#messageshow').hide();
                var name = $("#name").val();
                var email = $("#email").val();
                var login = $("#login").val();
                var password = $("#password").val();
                var fail = "";
            
                if(name.length < 3)
                    {
                        fail = "Ім'я надто коротке";
                    }
                else if(email.split('@').length - 1 == 0 || email.split('.').length - 1 == 0)
                    {
                        fail = "Некоректний емейл";
                    }
                else if(login.length < 5)
                    {
                        fail = "Надто короткий логін";
                    }
                else if(password.length < 3)
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
                    url: '/ajax/reg.php',
                    type: 'POST',
                    cache: false,
                    data: {'name': name, 'email':email, 'login': login, 'password':password},
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
                    <h2 class="heading">Реєстрація</h2>
                    <div style="clear:both"><br></div>
                    <div class="kontakt">
                        Щоб зареєструватись, заповніть форму нижче
                        <form>
                            <div>
                                <input type="text" id="name" placeholder="Ваше ім'я">
                                <input type="email" id="email" placeholder="Email...">
                            </div>
                            <div>
                                <input type="password" id="password" placeholder="Ваш пароль">
                                <input type="checkbox" id="checkbox">
                                <label for="subscribe-field">Я погоджуюсь із правилами</label>
                            </div>
                            <a href="">
                            <div class="btn">
                                <p id="send">Реєстрація</p>
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