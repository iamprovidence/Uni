<?php
    session_start();
    require_once "../functions/connect.php";
    $login = htmlspecialchars($_POST['login']);
    $password = htmlspecialchars($_POST['password']);

    global $mysqli;
    connectDB();
    $user = $mysqli->query("SELECT id FROM users WHERE login='".$login."' AND password='".$password."'");
    $id_user = fetch_array($user);
    if($id_user['id'])
    {
        $_SESSION['password'] = $password; 
        $_SESSION['login'] = $login; 
        $_SESSION['id'] = $id_user['id']; 
        echo "Ви увійшли як ".$login;
    }
    else
    {
        echo "Відбулась помилка";
    }
?>