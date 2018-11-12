<?php
    require_once "functions/function.php";
    $treilers = getAside (6);
?>
<aside>
            	<div id="treilers">
                	<h2 class="heading">Трейлери</h2>
                    <div style="clear:both"><br></div>
                <?php
                    for($i=0;$i<count($treilers);$i++)
                    {
                    echo 
                    '<div class="treilers">
                    	<a href="treilers.php?id='.$treilers[$i]["id"].'"><img src="img/t'.$treilers[$i]["id"].'.jpg" alt="'.$treilers[$i]["title"].'" title="'.$treilers[$i]["title"].'">
                        '.$treilers[$i]["short_text"].'</a>
                        <span>'.$treilers[$i]["title"].'</span>
                    </div>';
                    }
                ?>
                </div>
            </aside>