<?php

class CartController extends ControllerBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();     
    }
    
    // METHODS
    // AJAX
    public function actionAdd()
    {
        if (isset($_POST['submit']))
        {
            $product_id = $_POST['product_id'];
            $product_amount = $_POST['product_amount'];

            $this->GetModel(Models::Cart)->AddProduct($product_id, $product_amount);
            
            echo (new OperationStatus(true, "Successfully added product to cart"))->JSON();
        }
                
        return true;
    }
    // AJAX
    public function actionAmount()
    {
        if (isset($_POST['submit']))
        {
            echo $this->GetModel(Models::Cart)->CountItems();
        }
        return true;
    }
    // AJAX
    public function actionView()
    {
        if (isset($_POST['submit']))
        {
            echo $this->GetCartView();
        }
        return true;
    }
    private function GetCartView()
    {
        ob_start();
        
        $products_in_cart = $this->GetModel(Models::Cart)->GetProducts();
        
        if (!is_null($products_in_cart))
        {            
            $product_ids = array_keys($products_in_cart);
            $products = $this->GetRepository(Models::Product)->GetProductsByIds($product_ids);
            
            $total_price = $this->GetModel(Models::Cart)->GetTotalPrice($products);            
        }
        include (ROOT . "/view/user/layout/cart-modal.php");

        return ob_get_clean();
    }
    // AJAX
    public function actionDelete()
    {
        if (isset($_POST['submit']))
        {
            $this->GetModel(Models::Cart)->DeleteProduct($_POST['product_id']);
        }
        return true;
    }
    // AJAX
    public function actionCheckout()
    {                
        if (!$this->GetModel(Models::Message)->SendCheckoutEmail()) 
        {
            echo (new OperationStatus(false, "Could not send message"))->JSON(); 
            return true;
        }
        
        if ($this->GetModel(Models::Cart)->IsEmpty())
        {            
            echo (new OperationStatus(false, "Cart is empty"))->JSON();
            return true;
        }
        
        $this->GetRepository(Models::Order)->
            AddNewOrder($_POST['user_email'], 
                        $_POST['user_address'], 
                        $_POST['user_message'],
                        $this->GetModel(Models::Cart)->GetProducts());
        
        $this->GetModel(Models::Cart)->Clear();
        
        echo (new OperationStatus(true, "You order has been sent"))->JSON();
        return true;
    }
    
}