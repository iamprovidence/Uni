<?php
    require_once "../functions/connect.php";
    $name = htmlspecialchars($_POST['name']);
    $email = htmlspecialchars($_POST['email']);
    $login = htmlspecialchars($_POST['login']);
    $password = htmlspecialchars($_POST['password']);

    if(!empty($name) || !empty($email) || !empty($login) || !empty($password))
    {
        global $mysqli;
        connectDB();
        $result = $mysqli->query("INSERT INTO  `dynamicbase`.`users` (
        `id` ,
        `email` ,
        `login` ,
        `password`
        )
        VALUES (
        NULL ,  '$email',  '$login',  '$password'
        );");
        closeDB();
        echo "Ви зареєстровані";
    }
    else
    {
        echo "Відбулась помилка під час реєстрування";
    }
?>