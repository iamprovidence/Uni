<?php

abstract class ControllerBase
{
    // FIELDS
    private $repositoryFactory;
    private $modelFactory;

    protected $limit;
    protected $offset;
    
    // CONSTRUCTORS
    public function __construct()
    {
        $this->repositoryFactory = array();
        $this->modelFactory = array();
        
        $this->menu = null;
        $this->limit = null;
        $this->offset = null;
    }
    protected function SetOffset($page, $item_amount)
    {        
        $this->offset = ($page - 1) * $item_amount;
    }
    protected function SetLimit($limit)
    {
        $this->limit = $limit;
    }
    
    // METHODS   
    public function GetRepository($repository_name)
    {
        if (!array_key_exists($repository_name, $this->repositoryFactory))
        {
            $repository_full_name = $repository_name . 'Repository';
            $this->repositoryFactory[$repository_name] = new $repository_full_name;
        }
        
        return $this->repositoryFactory[$repository_name];
    }
    public function GetModel($model_name)
    {
        if (!array_key_exists($model_name, $this->modelFactory))
        {
            $model_full_name = $model_name . 'Model';
            $this->modelFactory[$model_name] = new $model_full_name;
        }
        
        return $this->modelFactory[$model_name];        
    }
    
    public function GetMenuComponent($menu_generator_type)
    {
        if ($menu_generator_type == MenuGeneratorType::ForUser)           return new UserMenu();
        else if ($menu_generator_type == MenuGeneratorType::ForModerator) return new ModeratorMenu();
    }
    public function GetGoogleClient()
    {
        return GoogleClient::GetGoogleClient();
    }
    public function SafeRole($role)
    {        
        if (!$this->GetModel(Models::User)->IsLogged() || !$this->GetModel(Models::User)->HasRights($role))
        {
            header('Location: /');
            return true;
        }
    }
}