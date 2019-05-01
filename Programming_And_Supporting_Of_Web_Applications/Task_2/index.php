<?php

// FRONT CONTROLLER
// опрацьовує всі запити

// Загальні налаштування
// відображення помилок
ini_set( 'display_errors' , 1 );
error_reporting(E_ALL);


// глобальні константи 
define('ROOT', dirname(__FILE__));
// визначені в JSON
foreach (json_decode(file_get_contents("settings.json"), true) as $key => $value) 
{
    define($key, $value);
}


// підключення файлів, autoload
require_once(ROOT.'/components/Autoload.php');



// запускаємо сесію
session_start();


// опрацьовуємо запит, викликаємо Router
$router = new Router();

try
{ 
    $router->run();   
}
catch (WrongRouteException $e) // 404
{
    (new ErrorController())->
        actionErrorPage($e->getMessage(), $e->getMessage(), "Sorry, there is no page that you are looking for");
}
catch (Exception $e)
{    
    // $title, $contentTitle, $contentText
    (new ErrorController())->
        actionErrorPage($e->getMessage(), $e->getMessage(), "Unhandled exception");
}