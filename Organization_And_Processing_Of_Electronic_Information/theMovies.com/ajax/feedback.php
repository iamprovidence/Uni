<?php
    $name = htmlspecialchars($_POST['name']);
    $email = htmlspecialchars($_POST['email']);
    $subject = htmlspecialchars($_POST['subject']);
    $message = htmlspecialchars($_POST['message']);

    if(empty($name) || empty($email) || empty($subject) || empty($message))
    {
        echo "Заповніть усі поля";
        exit;
    }
    //відправка
    $subject = "=?utf-8?B?".base64_encode($subject)."?=";
    $headers = "From: $email\r\n
                Reply-to: $email\r\n
                Content-type: text\html; charset: utf-8\r\n";
    if( mail("i.see@dead.peoples", $subject, $message, $headers) )
    {
        echo "Відправлено";
    }
    else
    {
        echo "Відбулась помилка під час відправлення";
    }
?>
