<?php

class SubjectController extends ModeratorControllerBase
{        
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Subject);
    }
    
    // METHODS    
    public function actionList($page = 1)
    {    
        $this->SetOffset($page, $this->limit);
        
        $subjects = $this->GetRepository(Models::Subject)->Get("*", null, null, $this->limit, $this->offset);
        
        $total = $this->GetRepository(Models::Subject)->Count();
        $pagination = new Pagination($total, $page, MODERATOR_SHOWN_ITEM_PER_PAGE, 'page-');
        
        require_once(ROOT . '/view/moderator/subjects/index.php');
        return true;
    }
}