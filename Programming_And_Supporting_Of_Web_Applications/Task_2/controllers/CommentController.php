<?php

class CommentController extends ControllerBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
        
        $this->SetLimit(MODERATOR_SHOWN_ITEM_PER_PAGE);
    }
    
    // METHODS    
    public function actionView()
    {
        if (isset($_POST['submit']))
        {
            echo $this->GetCommentView($_POST['product_id']);
        }
        return true;
    }
    private function GetCommentView($product_id)
    {
        ob_start();
        
        $comments = $this->GetRepository(Models::Comment)->GetCommentForProducts($product_id);
                
        include (ROOT . "/view/user/layout/comments.php");

        return ob_get_clean();
    }
    // AJAX
    public function actionAdd()
    {
        if ($_POST['submit'])
        {
            $comment = $this->GetModel(Models::Comment)->GetFromPost();
            
            if ($this->GetRepository(Models::Comment)->Insert($comment) != -1)
            {                                
                echo (new OperationStatus(true, "Successfully added new comment"))->JSON();
            }
            else
            {
                echo (new OperationStatus(false, "Something went wrong"))->JSON();
            }
        }
        return true;
    }
    
}