<?php
    $name = test_input($_POST["name"]);
    $to = "kizlo.taras@mail.ru";
    $from = test_input($_POST["email"]);
    $subject = "Повідомлення від сайту theMovies";
    $message = "Повідомлення від — ".$name.". Вміст повідомлення — ".test_input($_POST["message"]);     

    $subject = "=?utf-8?B?".base64_encode($subject)."?=";
    $headers = "From: $from\r\nReply-to: $from\r\nContent-type: text/plain; charset: utf-8\r\n";
    mail($to, $subject,$message,$headers);

    function test_input($data)
    {
        $data = trim($data);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);
        return $data;
    }
?>
<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; ?>
	<title>Зворотній зв'язок</title>
	<script>
        $(document).ready(function()
        {
            $("div.btn").click(function()
            {
                var name = $("#name").val();
                var email = $("#email").val();
                var message = $("#message").val();
                var fail = "";
            alert(name);
                if(name.length < 3)
                {
                    fail = "Ім'я надто коротке";
                }
                else if(email.split('@').length - 1 == 0 || email.split('.').length - 1 == 0)
                {
                    fail = "Некоректний емейл";
                }
                else if(message.length < 10)
                {
                    fail = "Надто коротке повідомлення";
                }
                
                if(fail != "")
                {
                    alert (fail);
                    return false;
                }
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
                    <h2 class="heading">Зворотній зв'язок</h2>
                    <div style="clear:both"><br></div>
                    <div class="kontakt">
                        Щоб відправити нам своє повідомлення, заповніть форму нижче
                        <form action="" method="post">
                            <div>
                                <input type="text" name="name" id="name" placeholder="Ваше ім'я...">
                                <input type="email" name="email" id="email" placeholder="Email...">
                            </div>
                            <div>
                                <textarea id="message" name="message" placeholder="Введіть ваше повідомлення..."></textarea>
                            </div>
                            <a>
                            <div class="btn">
                                <p id="send">Відправити</p>
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