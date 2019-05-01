<?php

class AdministratorUserController extends ControllerBase
{    
    // FIELDS
    private $fileManager;
    
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
        
        $this->SafeRole(Role::Administrator);
        
        $this->SetLimit(MODERATOR_SHOWN_ITEM_PER_PAGE);
        
        $this->fileManager = new FileManager();
    }
    
    // METHODS
    public function actionList($page = 1)
    {                
        $this->SetOffset($page, $this->limit);
        
        $users = $this->GetRepository(Models::User)->
                            Get("id, nickname, email, role", null, null, $this->limit, $this->offset);
        
        $roles = Role::GetArray();
                
        $total = $this->GetRepository(Models::User)->Count();
        
        $pagination = new Pagination($total, $page, $this->limit, 'page-');
        
        require_once(ROOT . '/view/administrator/index.php');
        return true;
    }
    // AJAX
    public function actionUpdate()
    {        
        if (isset($_POST['submit']))
        {             
            // update
            if ($this->GetRepository(Models::User)->UpdateRole($_POST['user_id'], $_POST['new_user_role']))
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
            $user_id = $_POST['user_id'];
            // delete
            if ($this->GetRepository(Models::User)->Delete($user_id))
            {
                $this->fileManager->DeleteImage(ImgFileFolder::User, $user_id);
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