<?php 

class CategoryRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Category");
    }
    
    // METHODS
    public function GetWithAmount()
    {
        // SQL
        $sql = "SELECT C.id, C.name, COUNT(P.id) AS amount
                FROM category AS C
                LEFT JOIN product AS P ON P.category_id = C.id
                WHERE C.is_available = 1 AND P.is_available = 1
                GROUP BY C.id
                ORDER BY C.sort_order";
        
        // QUERY
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
}