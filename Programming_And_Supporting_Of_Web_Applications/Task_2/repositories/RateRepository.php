<?php 

class RateRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Rating");
    }
    
    // METHODS
    public function AddOrReplace($rate)
    {
        if ($this->DoUserRateProduct($rate->user_id, $rate->product_id))
        {
            return $this->UpdateMark($rate);
        }
        return $this->Add($rate);
    }
    public function DoUserRateProduct($user_id, $product_id)
    {
        // SQL
        $sql = 'SELECT R.rate_mark
                FROM rating AS R 
                WHERE R.user_id = :user_id AND R.product_id = :product_id';
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':product_id', $product_id, PDO::PARAM_INT);
        $result->bindParam(':user_id', $user_id, PDO::PARAM_INT);
        
        // EXECUTE
        $result->execute();        
        return $result->rowCount() > 0;
    }
    public function Add($rate)
    {
        // SQL
        $sql = 'INSERT INTO rating (user_id, product_id, rate_mark) 
                VALUES (:user_id, :product_id, :rate_mark)';
        
        // PREPARE
        $result = $this->db->prepare($sql);      
        $result->bindParam(":user_id", $rate->user_id, PDO::PARAM_INT);
        $result->bindParam(":product_id", $rate->product_id, PDO::PARAM_INT);
        $result->bindParam(":rate_mark", $rate->rate_mark, PDO::PARAM_INT);
        
        // EXECUTE
        return $result->execute();
    }
    public function UpdateMark($rate)
    {
        // SQL
        $sql = 'UPDATE rating
                    SET rate_mark = :rate_mark 
                WHERE user_id = :user_id AND product_id = :product_id;';
            
        // PREPARE
        $result = $this->db->prepare($sql);     
        $result->bindParam(":user_id", $rate->user_id, PDO::PARAM_INT);
        $result->bindParam(":product_id", $rate->product_id, PDO::PARAM_INT);
        $result->bindParam(":rate_mark", $rate->rate_mark, PDO::PARAM_INT);
        
        // RETURN
        return $result->execute();
    }
    public function GetAverageMark($product_id)
    {
        // SQL
        $sql = 'SELECT ROUND(AVG(rate_mark)) AS mark
                FROM rating 
                WHERE product_id = :product_id';
        
        // PREPARE
        $result = $this->db->prepare($sql);     
        $result->bindParam(":product_id", $product_id, PDO::PARAM_INT);
        
        // RETURN
        $result->execute();  
        $mark = $result->fetch()['mark'];
        return is_null($mark) ? 0: $mark; 
    }
    public function GetUserMark($user_id, $product_id)
    {
        // SQL
        $sql = 'SELECT R.rate_mark AS mark
                FROM rating AS R 
                WHERE R.user_id = :user_id AND R.product_id = :product_id';
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':product_id', $product_id, PDO::PARAM_INT);
        $result->bindParam(':user_id', $user_id, PDO::PARAM_INT);
        
        // EXECUTE
        $result->execute();        
        return $result->rowCount() > 0 ? $mark = $result->fetch()['mark'] : 0;
    }
}