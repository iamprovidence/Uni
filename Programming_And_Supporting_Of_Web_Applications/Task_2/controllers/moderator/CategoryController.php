<?php

class CategoryController extends ModeratorControllerBase
{    
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Category);
    }    
    
    // METHODS
    public function actionList($page = 1)
    {                
        $this->SetOffset($page, $this->limit);
        
        $categories = $this->GetRepository(Models::Category)->
                                Get("*", null, null, $this->limit, $this->offset);
                
        $total = $this->GetRepository(Models::Category)->Count();
        $pagination = new Pagination($total, $page, $this->limit, 'page-');
        
        require_once(ROOT . '/view/moderator/categories/index.php');
        return true;
    }
    
}