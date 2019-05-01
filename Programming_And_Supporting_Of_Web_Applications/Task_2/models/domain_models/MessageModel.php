<?php

class MessageModel extends ModelBase
{
    // METHODS
    public function SendMessageEmail()
    {
        if (isset($_POST['submit']))
        {
            $params = include(ROOT . '/config/email_params.php');
            $user_text = $_POST['message'];

            // відправляємо лист адміністратору
            $message = "Тема: {$_POST['subject']}. Текст: {$user_text}. Від {$_POST['user_email']}";
            $subject = $params['subject_for_mail'];
            return mail($params['admin_email'], $subject, $message);
        }
        return false;
    }
    public function SendCheckoutEmail()
    {
        if (isset($_POST['submit']))
        {
            $params = include(ROOT . '/config/email_params.php');
            $user_text = isset($_POST['user_message']) ? $_POST['user_message'] : '';

            // відправляємо лист адміністратору
            $message = "Тема: Нове замовлення. Адреса: {$_POST['user_address']} Текст: {$user_text}.";
            $subject = $params['subject_for_mail'];
            return mail($params['admin_email'], $subject, $message);
        }
        return false;
    }
    // @return MessageEntities
    public function GetFromPost()
    {
        $message = new Message();
        $message->text = $_POST['message'];
        $message->date = date("Y-m-d");
        $message->user_email = $_POST['user_email'];
        $message->subject_id = $_POST['subject_id'];

        return $message;
    }
}
