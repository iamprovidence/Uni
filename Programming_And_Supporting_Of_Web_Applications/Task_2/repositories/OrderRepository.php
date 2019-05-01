<?php 

class OrderRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Orders");
    }
    
    // METHODS
    public function GetShortInfo($limit, $offset)
    {
        // SQL
        $sql = "SELECT O.id, O.user_email, O.status, O.date, SUM(P.price * PO.product_count) AS total_price
                FROM orders AS O
                LEFT JOIN product_order AS PO ON O.id = PO.order_id
                LEFT JOIN product AS P ON P.id = PO.product_id
                GROUP BY O.id
                ORDER BY O.status ASC, O.date DESC
                LIMIT :limit
                OFFSET :offset";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':limit', $limit, PDO::PARAM_INT); 
        $result->bindParam(':offset', $offset, PDO::PARAM_INT);
        
        // EXECUTE
        $result->setFetchMode(PDO::FETCH_CLASS, 'ViewModel');
        $result->execute();

        $entitiesArray = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entitiesArray[$i] = $row;
        }
        return $entitiesArray;
    }
    public function GetProductFromOrder($order_id)
    {
        // SQL
        $sql = "SELECT P.id, P.name, P.price, PO.product_count, P.price * PO.product_count AS current_price
                FROM product_order AS PO
                LEFT JOIN product AS P ON P.id = PO.product_id
                WHERE PO.order_id = :order_id";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':order_id', $order_id, PDO::PARAM_INT);
        
        // EXECUTE
        $result->setFetchMode(PDO::FETCH_CLASS, 'ViewModel');
        $result->execute();

        $entitiesArray = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entitiesArray[$i] = $row;
        }
        return $entitiesArray;
    }
    public function UpdateStatus($order_id, $order_status)
    {
        // SQL
        $sql = "UPDATE orders 
                SET status = :status 
                WHERE id = :id;";
            
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':status', $order_status, PDO::PARAM_INT);
        $result->bindParam(':id', $order_id, PDO::PARAM_INT);
        
        // EXECUTE
        return $result->execute();      
    }
    public function GetTotalSum($order_id)
    {
        // SQl
        $sql = "SELECT SUM(P.price * PO.product_count) AS total_price 
                FROM product_order AS PO 
                LEFT JOIN product AS P ON P.id = PO.product_id 
                WHERE PO.order_id = :order_id";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':order_id', $order_id, PDO::PARAM_INT);
        
        // EXECUTE
        $result->execute();        
        return $result->fetch()['total_price']; 
    }
    // @param $products - array([product id] => "product amount")
    public function AddNewOrder($user_email, $user_address, $user_message, $products)
    {
        $order_id = $this->InsertOrder($user_email, $user_address, $user_message);
        
        $this->InsertOrderProduct($order_id, $products);
        
        return true;        
    }
    private function InsertOrder($user_email, $user_address, $user_message)
    {
        // SQL
        $sql = "INSERT INTO orders (status, user_email, user_address, user_message, date) 
                VALUES (0, :email, :address, :message, CURDATE())";        
        
        // PREPARE
        $result = $this->db->prepare($sql);        
        $result->bindParam(":email", $user_email, PDO::PARAM_STR);
        $result->bindParam(":address", $user_address, PDO::PARAM_STR);
        $result->bindParam(":message", $user_message, PDO::PARAM_STR);
        
        // EXECUTE
        $result->execute();
        return $this->db->lastInsertId();
    }
    private function InsertOrderProduct($order_id, $products)
    {
        // SQL
        $sql = "INSERT INTO product_order (order_id, product_id, product_count) VALUES ";
        
        $amount = count($products);
        $inserted_values = array();
        for ($i = 0; $i < $amount; ++$i)
        {         
            $inserted_values[$i] = "(:order_id, :product_id{$i}, :product_amount{$i})";
        }
        $sql .= implode(',', $inserted_values);     
        
        // PREPARE
        $result = $this->db->prepare($sql);    
        $result->bindParam(":order_id", $order_id, PDO::PARAM_INT); 
        
        $count = 0;
        foreach ($products as $product_id => &$product_amount)
        {         
            $var_product_id = intval($product_id);
            $result->bindParam(":product_id{$count}", $var_product_id, PDO::PARAM_INT);  
            $result->bindParam(":product_amount{$count}", $product_amount, PDO::PARAM_INT);   
            unset($var_product_id);
            
            ++$count;
        }
        
        // EXECUTE
        return $result->execute();
    }
}