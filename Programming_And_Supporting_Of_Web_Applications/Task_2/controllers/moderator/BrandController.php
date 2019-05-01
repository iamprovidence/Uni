<?php

class BrandController extends ModeratorControllerBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Brand);
    }    
    
    // METHODS
    public function actionList($page = 1)
    {                
        $this->SetOffset($page, $this->limit);
        
        $brands = $this->GetRepository(Models::Brand)->
                            Get("*", null, null, $this->limit, $this->offset);
                
        $total = $this->GetRepository(Models::Brand)->Count();
        $pagination = new Pagination($total, $page, $this->limit, 'page-');
        
        require_once (ROOT . '/view/moderator/brands/index.php');
        return true;
    }
}