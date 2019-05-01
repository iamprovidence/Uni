<?php

class RateModel extends ModelBase
{
    // FIELDS
    private $userModel;
    private $productRepository;
    
    // CONSTRUCTORS
    public function __construct()
    {
        $this->userModel = new UserModel();
        $this->productRepository = new ProductRepository();
    }
    
    // METHODS
    public function IsRatingAvailable($product_id)
    {
        $user = $this->userModel->GetUser();
        if (is_null($user)) return false;
        
        return $this->productRepository->DoUserBuyProduct($user->id, $product_id);
    }
    public function GetFromPost()
    {
        $rating = new Rating();
        $rating->rate_mark = $_POST['user_mark'];
        $rating->user_id = $this->userModel->GetUser()->id;
        $rating->product_id = $_POST['product_id'];
        
        return $rating;
    }
}