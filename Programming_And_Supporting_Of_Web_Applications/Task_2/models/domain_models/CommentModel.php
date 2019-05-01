<?php

class CommentModel extends ModelBase
{    
    // FIELDS
    private $commentRepository;
    private $userModel;
    
    // CONSTRUCTORS
    public function __construct()
    {
        $this->commentRepository = new CommentRepository();
        $this->userModel = new UserModel();
    }
    
    // METHODS
    public function IsCommentAvailable($product_id)
    {
        $user = $this->userModel->GetUser();
        if (is_null($user)) return false;
        
        $comment_availability =  $this->commentRepository->IsCommentAvailable($user->id, $product_id);
        if (!$comment_availability) return false;
        
        return boolval($comment_availability->is_comments_available);
    }    
    public function GetFromPost()
    {
        $comment = new Comment();
        $comment->subject = $_POST['comment_subject'];
        $comment->text = $_POST['comment_text'];
        $comment->date = date('Y-m-d');
        
        $comment->user_id = $this->userModel->GetUser()->id;
        $comment->product_id = $_POST['product_id'];
        
        return $comment;
    }
}