<?php

class DataBase
{
    // Встановлює зв'язок з БД
    // @return PDO <p>Об'єкт класу PDO для роботи з БД</p>
    public static function getConnection()
    {
        // отримуємо параметри підключення
        $params = include(ROOT . '/config/db_params.php');

        // встановлюємо з'єднання
        $dsn = "mysql:host={$params['host']};dbname={$params['dbname']}";
        $db = new PDO($dsn, $params['user'], $params['password']);
        $db->exec("set names utf8");

        return $db;
    }

}