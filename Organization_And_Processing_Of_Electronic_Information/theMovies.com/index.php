<!DOCTYPE html>
<html>
<head>
	<?php require "parts/head.php"; 
    require_once "functions/function.php";
    $article = getNews (6);
    ?>
	<title>theMovies | Головна сторінка</title>
</head>
<body>
	<div id="wrapper">
    	<div id="content">
            <?php require "parts/header.php"; ?>
            <?php require "parts/nav.php"; ?>  
            <div id="main">
            	<div id="news">
                	<h2 class="heading">Новини кіно</h2>
                    <div style="clear:both"><br></div>
                    <!--стаття--> 
                    <?php
                        for($i=0;$i<count($article);$i++)
                        {
                            echo 
                            '<a href="article.php?id='.$article[$i]["id"].'" title="'.$article[$i]["title"].'">
                                <div class="article">
                                    <img src="'.$article[$i]["picture"].'" alt="'.$article[$i]["title"].'" title="'.$article[$i]["title"].'">
                                    <span>'.$article[$i]["title"].'</span>
                                    <span>'.$article[$i]["short_text"].'</span>
                                </div>
                            </a>';
                        }
                    ?>
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