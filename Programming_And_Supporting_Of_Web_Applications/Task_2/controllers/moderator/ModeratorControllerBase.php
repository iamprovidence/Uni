<?php

abstract class ModeratorControllerBase extends ControllerBase
{
    // FIELDS
    private $modelName;
    
    // CONSTRUCTOR
    public function __construct($model_name)
    {        
        parent::__construct();
        
        $this->modelName = $model_name;
        
        $this->SafeRole(Role::Moderator);        
        
        $this->SetLimit(MODERATOR_SHOWN_ITEM_PER_PAGE);
    }
    
    // METHODS    
    public abstract function actionList($page = 1);
    
    // AJAX
    public function actionAdd()
    {     
        if (isset($_POST['submit']))
        {
            // create entity from post
            $entity_model = $this->GetModel($this->modelName)->GetFromPost();

            // insert
            if ($this->GetRepository($this->modelName)->Insert($entity_model))
            {
                echo (new OperationStatus(true, SERVER_ADD_MESSAGE))->JSON();
            }
            else
            {
                echo (new OperationStatus(false, SERVER_ERROR_MESSAGE))->JSON();
            }
        }
        return true;
    }
    
    // AJAX
    public function actionUpdate()
    {       
        if (isset($_POST['submit']))
        {
            // create entity from post
            $entity_model = $this->GetModel($this->modelName)->GetFromPost();            
                        
            // update and send response
            if ($this->GetRepository($this->modelName)->Update($entity_model))
            {                
                echo (new OperationStatus(true, SERVER_UPDATE_MESSAGE))->JSON();
            }
            else
            {
                echo (new OperationStatus(false, SERVER_ERROR_MESSAGE))->JSON();
            }
        }
            
        return true;
    }
    // AJAX
    public function actionDelete()
    {              
        if (isset($_POST['submit']))
        {     
            $entity_id = $_POST['entity_id'];
            
            // delete
            if ($this->GetRepository($this->modelName)->Delete($entity_id))
            {
                echo (new OperationStatus(true, SERVER_DELETE_MESSAGE))->JSON();
            }
            else
            {
                echo (new OperationStatus(false, SERVER_ERROR_MESSAGE))->JSON();
            }
        }
        return true;
    }
}