<?php

class BrandRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct("Brand");
    }

    // METHODS
    public function GetWithAmount()
    {
        // SQL
        $sql = "SELECT B.id, B.name, COUNT(P.id) AS amount
                FROM brand AS B
                LEFT JOIN product AS P ON P.brand_id = B.id
                WHERE B.is_available = 1 AND P.is_available = 1
                GROUP BY B.id
                ORDER BY B.sort_order";

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
    public function GetBestBrands($limit)
    {
        // SQL
        $sql = 'SELECT B.id, B.name, SUM(PO.product_count) AS product_sum
                FROM brand AS B
                LEFT JOIN product AS P ON P.brand_id = B.id
                LEFT JOIN product_order AS PO ON PO.product_id = P.id
                WHERE B.is_available = 1
                GROUP BY B.id
                ORDER BY product_sum DESC
                LIMIT :limit';
        
        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':limit', $limit, PDO::PARAM_INT);

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
