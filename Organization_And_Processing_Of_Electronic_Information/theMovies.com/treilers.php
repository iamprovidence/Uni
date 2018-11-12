<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; 
    require_once "functions/function.php";
    $treilers = getAside (1,$_GET["id"]);?>
	<title><?=$treilers["title"];?></title>
</head>
<body>
	<div id="wrapper">
    	<div id="content">
            <?php require "parts/header.php"; ?>
            <?php require "parts/nav.php"; ?>  
            <div id="main">
	            <div id="news">
                <a href="/"><h3 class="heading"> ← назад</h3></a>
                    <div style="clear:both"><br></div>
                    <div class="block"> 
                    <?php
                    echo '<h1>'.$treilers["title"].'</h1> 
                    <iframe width="560" height="315" src="'.$treilers["video"].'" allowfullscreen></iframe>';
                    echo $treilers["full_text"];
                        ?>
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