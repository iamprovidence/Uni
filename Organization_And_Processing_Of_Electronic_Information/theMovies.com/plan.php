<!doctype html>
<html>
<head>
	<?php require "parts/head.php"; ?>
    <title>План (кінематограф)</title>
</head>

<body>
	<div id="wrapper">
    	<div id="content">
            <?php require "parts/header.php"; ?>
            <?php require "parts/nav.php"; ?> 
            
            <div id="main">
	            <div id="news">
                    <h2 class="heading">План</h2>
                    <div style="clear:both"><br></div>
                        <table>
                            <tr>
                                <th colspan="9">План</th>
                            </tr>
                            <tr>
                                <td rowspan="3" class="pz">Поділ за</td>
                                <td class="tdpz">розміром</td>
                                <td>Деталь </td>
                                <td>Середній план </td>
                                <td>Великий план </td>
                                <td>Широкий план </td>
                                <td>Загальний план</td>
                                <td>Оглядовий план </td>
                                <td>Дальній план</td>
                            </tr>
                            <tr>
                                <td class="tdpz">розміщенням</td>
                                <td colspan="2">Передній план </td>
                                <td colspan="3">Середній план </td>
                                <td colspan="2">Задній план</td>
                            </tr>
                            <tr>
                                <td class="tdpz">змістом</td>
                                <td colspan="3">Основний план</td>
                                <td colspan="4">Другорядний план</td>
                            </tr>
                        </table>
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
