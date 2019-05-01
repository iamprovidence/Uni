<?php

class ProductModel extends ModelBase
{
    // FIELDS
    private $fileManager;
    
    // CONSTRUCTORS
    public function __construct()
    {
        $this->fileManager = new FileManager();
    }
    
    // METHODS
    public function GetFromPost()
    {       
        $product = new Product();
        $product->id                    = isset($_POST['product_id']) ? $_POST['product_id'] : null;
        $product->name                  = $_POST['product_name'];
        $product->price                 = $_POST['product_price'];
        $product->description           = $_POST['product_description'];
        $product->is_available          = $_POST['is_product_available'] === 'true' ? 1 : 0;
        $product->is_new                = $_POST['is_product_new'] === 'true' ? 1 : 0;
        $product->is_comments_available = $_POST['is_comments_available'] === 'true' ? 1 : 0;
        $product->category_id           = $_POST['category_id'];
        $product->brand_id              = $_POST['brand_id'];
        
        return $product;
    }
    public function GetImage($id)
    {
        return $this->fileManager->GetImage(ImgFileFolder::Product, $id);
    }
}