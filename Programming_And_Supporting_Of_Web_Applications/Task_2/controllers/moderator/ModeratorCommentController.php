<?php

class ModeratorCommentController extends ModeratorControllerBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Comment);
    }
    
    // METHODS    
    public function actionList($page = 1)
    {          
        $this->SetOffset($page, $this->limit);
        
        $comments = $this->GetRepository(Models::Comment)->GetShortInfo(100, $this->limit, $this->offset);
        
        $total = $this->GetRepository(Models::Comment)->Count();
        $pagination = new Pagination($total, $page, $this->limit, 'page-');
        
        require_once(ROOT . '/view/moderator/comments/index.php');
        return true;
    }
    public function actionSingle($comment_id)
    {           
        $comment = $this->GetRepository(Models::Comment)->GetFullInfoById($comment_id);
        
        require_once(ROOT . '/view/moderator/comments/view.php');
        return true;
    }
    
}