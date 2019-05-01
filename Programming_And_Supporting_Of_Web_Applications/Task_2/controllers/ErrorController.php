<?php

class ErrorController extends ControllerBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
    }    
    
    // METHODS
    public function actionErrorPage($title, $contentTitle, $contentText)
    {
        require_once(ROOT . '/view/user/template.php');
        return true;
    }
}