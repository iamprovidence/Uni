<?php

class CommentRepository extends RepositoryBase
{
     // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Comment");
    }
    
    // METHODS
    public function GetCommentForProducts($product_id)
    {
        // SQl
        $sql = "SELECT C.subject, C.text, U.nickname AS user_nickname, U.id AS user_id
                FROM comment AS C
                LEFT JOIN user AS U ON C.user_id = U.id
                WHERE C.product_id = :product_id";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(":product_id", $product_id, PDO::PARAM_INT);
        
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
    public function GetShortInfo($text_length, $limit, $offset)
    {
        // SQL
        $sql = "SELECT comment.id, LEFT(comment.text, :text_length) AS short_text, user.nickname AS user_nickname, comment.date, comment.product_id
                FROM comment
                LEFT JOIN user ON comment.user_id = user.id
                LIMIT :limit
                OFFSET :offset";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(":text_length", $text_length, PDO::PARAM_INT);        
        $result->bindParam(":limit", $limit, PDO::PARAM_INT);
        $result->bindParam(":offset", $offset, PDO::PARAM_INT);
        
        // EXECUTE
        $result->setFetchMode(PDO::FETCH_CLASS, "ViewModel");
        $result->execute();

        $entities_array = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entities_array[$i] = $row;
        }
        return $entities_array;
    }
    public function GetFullInfoById($comment_id)
    {
        // SQL
        $sql = "SELECT comment.*, user.nickname AS user_nickname, product.name AS product_name
                FROM comment
                LEFT JOIN user ON comment.user_id = user.id
                LEFT JOIN product ON comment.product_id = product.id
                WHERE comment.id = :id;";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':id', $comment_id, PDO::PARAM_INT);
        
        // EXECUTE
        $result->setFetchMode(PDO::FETCH_CLASS, "ViewModel");
        $result->execute();
        return $result->fetch();
    }
    // @return mixed: object or false
    public function IsCommentAvailable($user_id, $product_id)
    {
        // SQL
        $sql = 'SELECT P.is_comments_available
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
        $result->setFetchMode(PDO::FETCH_CLASS, "ViewModel");
        $result->execute();
        return $result->fetch();
    }
}