<?php

// Функція __autoload для автоматичного підключення файлів
function my_autoload($class_name)
{
    // масив папок де можуть знаходитись необхідні класи
    $array_paths = array(        
        
        '/controllers/administrator/',
        '/controllers/moderator/',
        '/controllers/',

        
        '/models/components/html_builder/',
        '/models/components/',
        '/models/entities/',
        '/models/domain_models/',
        '/models/view_models/',
        
        '/enums/',
        '/components/',
        '/exceptions/',
        '/interfaces/',
        '/repositories/',
    );

    foreach ($array_paths as $path) 
    {
        // формуємо шлях до файлі
        $full_path = ROOT . $path . $class_name . '.php';

        // підключаємо файл, якщо він існує
        if (is_file($full_path)) include_once $full_path;
    }
}
spl_autoload_register("my_autoload");