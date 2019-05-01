<?php

class CartModel
{
    // CONST
    const KEY = 'products';
    
    // METHODS
    public function AddProduct($id, $amount)
    {
        // товари зберігаються в асоціативному масиву
        // [ід продукту] => "кількість продукту"
        $id = intval($id);
        
        $products_in_cart = array();
        
        if (isset($_SESSION[self::KEY])) 
        {
            $products_in_cart = $_SESSION[self::KEY];
        }
        
        if (array_key_exists($id, $products_in_cart)) $products_in_cart[$id] += $amount;
        else $products_in_cart[$id] = $amount;
        
        $_SESSION[self::KEY] = $products_in_cart;        
    }
    public function CountItems()
    {
        if (isset($_SESSION[self::KEY])) return array_sum($_SESSION[self::KEY]);
        else return 0;
    }
    public function GetProducts()
    {
        if (isset($_SESSION[self::KEY]) && !empty($_SESSION[self::KEY])) return $_SESSION[self::KEY];
        return null;
    }
    public function IsEmpty()
    {
        return !isset($_SESSION[self::KEY]) || empty($_SESSION[self::KEY]);
    }
    
    // @param $products масив продуктів
    public function GetTotalPrice($products)
    {
        $products_in_cart = $this->GetProducts();
        
        $total = 0;
        if ($products_in_cart) 
        {
            foreach ($products as $product) 
            {
                // загальну сума: ціна * кількість
                $total += $product->price * $products_in_cart[$product->id];
            }
        }
        return $total;
    }
    public function Clear()
    {
        if (isset($_SESSION[self::KEY])) unset($_SESSION[self::KEY]);
    }
    public function DeleteProduct($id)
    {
        $products_in_cart = $this->getProducts();
        unset($products_in_cart[$id]);
        
        $_SESSION[self::KEY] = $products_in_cart;
    }
}