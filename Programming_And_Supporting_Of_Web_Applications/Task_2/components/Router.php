<?php

// Router
// визначає запит, передає керування контролеру
class Router
{
    // FIELDS
    private $routes;

    // CONSTRUCTORS
    public function __construct()
    {
        // отримуємо допустимі маршрути
        $this->routes = include(ROOT . '/config/routes.php');
    }

    // METHODS
    private function getURI()
    {
        return rawurldecode(trim($_SERVER['REQUEST_URI'], '/'));
    }
    public function run()
    {        
        $uri = $this->getURI();
        
        // перевіряємо наявність запиту в списку маршрутів
        foreach ($this->routes as $uriPattern => $path) 
        {  
            // Сравниваем $uriPattern и $uri
            if (preg_match("~^$uriPattern$~", $uri)) 
            {
                
                // отримуємо відповідний controller/action для запиту
                $internalRoute = preg_replace("~$uriPattern~", $path, $uri);

                // розбиваємо на сегменти, контролер, дію, відповідно до конвенції
                $segments = explode('/', $internalRoute);

                $controllerName = array_shift($segments) . 'Controller';
                $controllerName = ucfirst($controllerName);

                $actionName = 'action' . ucfirst(array_shift($segments));

                $parameters = $segments;
                
                // створюємо контроллер
                $controllerObject = new $controllerName;            
                
                // викликаємо метод у відповідідного контролера із відповідними параметрами
                $result = call_user_func_array(array($controllerObject, $actionName), $parameters);
                
                // якщо метод контроллера успішно виконано, завершуємо роботу роутера
                if ($result !== null) return;
                else throw new ActionCallException("Could not call action properly or it has no return value.");      
            }    
        }
        
        // не вдалось знайти співпадіння по заданих маршрутах 
        throw new WrongRouteException("404");
    }   
}