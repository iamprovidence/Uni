<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; 
    require_once "functions/function.php";
    $article = getNews (1,$_GET["id"]);
    ?>
	<title><?=$article["title"];?></title>
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
                        echo 
                        '<h1>'.$article["title"].'</h1>
                        <img src="'.$article["picture"].'" alt="'.$article["title"].'" title="'.$news["title"].'">';

                        echo $article["full_text"];
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