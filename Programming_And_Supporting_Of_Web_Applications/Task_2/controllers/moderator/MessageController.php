<?php

class MessageController extends ModeratorControllerBase
{    
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Message);
    }
    
    // METHODS
    public function actionList($page = 1)
    {          
        $this->SetOffset($page, $this->limit);
        
        $messages = $this->GetRepository(Models::Message)->GetShortMessageInfo($this->limit, $this->offset);
                
        $total = $this->GetRepository(Models::Message)->Count();
        $pagination = new Pagination($total, $page, $this->limit, 'page-');
        
        require_once(ROOT . '/view/moderator/messages/index.php');
        return true;
    }
    public function actionSingle($message_id)
    {                   
        $message = $this->GetRepository(Models::Message)->GetById($message_id);
        
        // get subject name
        $subject = $this->GetRepository(Models::Subject)->GetById($message->subject_id);
        if ($subject) $message->subject_name = $subject->name;
        else $message->subject_name = null;
        
        require_once(ROOT . '/view/moderator/messages/view.php');
        return true;
    }
}