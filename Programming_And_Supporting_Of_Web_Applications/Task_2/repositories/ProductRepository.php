<?php 

class ProductRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Product");
    }
    
    // METHODS
    public function GetBestProducts($count)
    {
        // SQL
        $sql = "SELECT P.id, P.name AS name, P.price, B.name AS brand_name, P.is_new, SUM(PO.product_count) AS product_bought
                 FROM product AS P
                 LEFT JOIN brand AS B ON P.brand_id = B.id
                 LEFT JOIN product_order AS PO ON PO.product_id = P.id
                 WHERE P.is_available = 1
                 GROUP BY P.id
                 ORDER BY product_bought DESC
                 LIMIT :count";

        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':count', $count, PDO::PARAM_INT);

        // FETCH
        $result->setFetchMode(PDO::FETCH_CLASS, "ViewModel");
        $result->execute();

        $entities_array = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entities_array[$i] = $row;
        }        
        return $entities_array;
    }
    // @param $filter_column_array = array({column name => value})
    // @param $order_by_column = array({column_name => ASC})
    public function GetList($filter_column_array = null, $order_by_column = null, $limit, $offset)
    {
        // SQL
        $sql = "SELECT P.id, P.name AS name, P.price, B.name AS brand_name, P.is_new
                 FROM product AS P
                 LEFT JOIN brand AS B ON P.brand_id = B.id
                 WHERE P.is_available = 1";
        
        
        if (!is_null($filter_column_array))
        {
            $table_columns = array_keys($filter_column_array);
            // column_name =:column_name AND column_name =: column_name..
            $separated_columns = implode(" AND ", array_map(function($column) 
                                                             { 
                                                                 return $column.' = :'.$column; 
                                                             }, $table_columns)); 
            
            $sql .= ' AND ' . $separated_columns;
        }
        
        // ordering
        if (!is_null($order_by_column))
        {            
            $separated_columns = array();
            foreach ($order_by_column as $column => &$order)
            {
                $column_name = $column;
                $separated_columns[] = "{$column_name} {$order}";
                unset($column_name);
            }
            $orders = implode(' , ', $separated_columns);
            $sql .= " ORDER BY {$orders} ";
        }
        
        $sql .= ' LIMIT :limit
                  OFFSET :offset';

        // PREPARE
        $result = $this->db->prepare($sql);
        
        if (!is_null($filter_column_array))
        {
            // filtering
            foreach ($filter_column_array as $column => &$value)
            {
                $result->bindParam(":{$column}", $value, PDO::PARAM_STR);
            }
        }
        
        
        // ordering
        //if (!is_null($order_by_column)) $result->bindParam(":order_column", $order_by_column, PDO::PARAM_STR);
        
        $result->bindParam(':limit', $limit, PDO::PARAM_INT);
        $result->bindParam(':offset', $offset, PDO::PARAM_INT);

        // FETCH
        $result->setFetchMode(PDO::FETCH_CLASS, "ViewModel");
        $result->execute();

        $entities_array = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entities_array[$i] = $row;
        }       
        return $entities_array;
    }
    public function GetProductsByIds($product_ids)
    {        
        // SQL
        $ids_str = implode(',', $product_ids);
        $sql = "SELECT * FROM product WHERE is_available='1' AND id IN ($ids_str)";
        $result = $this->db->query($sql);
        
        // FETCH
        $result->setFetchMode(PDO::FETCH_CLASS, "ViewModel");
        $result->execute();
        
        $entities_array = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entities_array[$i] = $row;
        }
        
        return $entities_array;
    }
    
    // @return bool
    public function DoUserBuyProduct($user_id, $product_id)
    {
        // SQL
        $sql = 'SELECT P.id
                FROM product AS P 
                LEFT JOIN comment AS C ON C.product_id = P.id
                LEFT JOIN product_order AS PO ON PO.product_id = P.id
                LEFT JOIN orders AS O ON O.id = PO.order_id
                LEFT JOIN user AS U ON U.email = O.user_email
                WHERE P.id = :product_id AND U.id = :user_id
                GROUP BY P.id, U.id';
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':product_id', $product_id, PDO::PARAM_INT);
        $result->bindParam(':user_id', $user_id, PDO::PARAM_INT);
        
        // EXECUTE
        $result->execute();
        
        return $result->rowCount() > 0;
    }
}