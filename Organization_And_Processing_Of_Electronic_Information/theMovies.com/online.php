<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; ?>
	<title>Фільм дня</title>
</head>
<body>
	<div id="wrapper">
    	<div id="content">
            <?php require "parts/header.php"; ?>
            <?php require "parts/nav.php"; ?> 
            
            <div id="main">
	            <div id="news">
                <h3 class="heading"> Фільм дня</h3>
                    <div style="clear:both"><br></div>
                    <div class="block"> 
                    <h1>Warcraft</h1> 

                        <iframe width="560" height="315" src="https://www.youtube.com/embed/3VB_xg9rgII" allowfullscreen></iframe>

                        <h2>Інформація про фільм:</h2>
                        <ol>
                            <li><b>Країна:</b> <em>США</em></li>
                            <li><b>Режисер:</b> <em>Дункан Джонс</em></li> 
                            <li><b>Студія:</b> <em>Universal Pictures</em></li>
                            <li><b>Жанр:</b> <em>пригоди, фентезі, екшн</em></li>
                            <li><b>У ролях:</b> Бен Фостер, Тобі Кеббелл, Домінік Купер, Тревіс Фіммел, Пола Петтон, Раян Роббінс, Роберт Казінськи та інші.</li>
                        </ol>
                        <p>Культова гра Warcraft оживає на великому екрані у масштабному і величному фентезі! Дія відбувається в Азероті, перед нами перші зіткнення орків з людьми і вся історія їхнього тривалого конфлікту. Чи вдасться людям стримати навалу ворога, який володіє надпотужною силою та на боці якого виступають демонічні сили?! Дивовижний всесвіт Варкрафрт, який вже має мільйонну армію шанувальників, приголомшить надсучасними візуальними ефектами, а епічне протистояння ватажків обох рас перенесе глядача в самий епіцентр подій!</p>
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