<?php 

class RepositoryBase implements IRepository
{
    // FIELDS
    protected $tableName;
    protected $db;
    
    // CONSTRUCTORS
    public function __construct($tableName)
    {
        $this->tableName = $tableName;
        $this->db = DataBase::getConnection();
    }
        
    // METHODS
    public function Count()
    {        
        $sql = "SELECT COUNT(*) AS Count FROM {$this->tableName}";
        $result = $this->db->prepare($sql);
        $result->execute();        
        return $result->fetch()['Count']; 
    }    
    //  @param $columnArray = array({column name = value})
    public function CountWhere($column_array)
    {        
        // BUILD SQL
        $table_columns = array_keys($column_array);
        // column_name =:column_name AND column_name =: column_name..
        $separated_columns = implode(" AND ", array_map(function($column) 
                                                         { 
                                                             return $column.' = :'.$column; 
                                                         }, $table_columns)); 
        
        $sql = "SELECT COUNT(*) AS Count FROM {$this->tableName} WHERE {$separated_columns}";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        foreach ($column_array as $column => &$value)
        {
            $result->bindParam(":{$column}", $value, PDO::PARAM_STR);
        }
        
        // FETCH
        $result->execute();        
        return $result->fetch()['Count'];        
    }
    // @return mixed : Entity or Boolean
    public function GetById($entity_id)
    {        
        $sql = "SELECT * FROM {$this->tableName} WHERE id = :id;";

        // підготуємо запит
        $result = $this->db->prepare($sql);
        $result->bindParam(':id', $entity_id, PDO::PARAM_INT);

        // витягуємо дані у вигляді масиву
        $result->setFetchMode(PDO::FETCH_CLASS, ucfirst($this->tableName));
        $result->execute();        

        return $result->fetch();
    }    
    // @param $include = string, "name, surname"
    // @param $filterKeyValueArray = array({column name = value})
    // @param $orderByColumn = string, column name
    //
    // @retrun entities array
    public function Get($include = "*", $filterKeyValueArray = null, $orderByColumn = null, $limit = null, $offset = null)
    {           
        // BUILD SQL
        $sql = "SELECT {$include} FROM {$this->tableName} "; 
        
        // filtering
        if (!is_null($filterKeyValueArray))
        {            
            $table_columns = array_keys($filterKeyValueArray);
            // column_name =:column_name AND column_name =: column_name..
            $separated_columns = implode(" AND ", array_map(function($column) 
                                                             { 
                                                                 return $column.' = :'.$column; 
                                                             }, $table_columns)); 
            
            $sql .= ' WHERE ' . $separated_columns;
        }
        // ordering
        if (!is_null($orderByColumn))
        {
            $sql .= "ORDER BY :order_column ";
        }
        // limit
        if (!is_null($limit)) $sql .= "LIMIT :limit ";
        
        // offset
        if (!is_null($offset)) $sql .= "OFFSET :offset ";
        
                
        // PREPARE
        $result = $this->db->prepare($sql);
        // filtering
        if (!is_null($filterKeyValueArray))
        {
            foreach ($filterKeyValueArray as $keyColumnName => &$value)
            {
                $result->bindParam(":{$keyColumnName}", $value, PDO::PARAM_STR);
            }
        }
        
        // ordering
        if (!is_null($orderByColumn)) $result->bindParam(":order_column", $orderByColumn, PDO::PARAM_STR);
        
        // limit
        if (!is_null($limit)) $result->bindParam(':limit', $limit, PDO::PARAM_INT);
        
        // offset
        if (!is_null($offset)) $result->bindParam(':offset', $offset, PDO::PARAM_INT);
        
        
        // FETCH
        $result->setFetchMode(PDO::FETCH_CLASS, ucfirst($this->tableName));
        $result->execute();

        $entitiesArray = array();         
        for ($i = 0; $row = $result->fetch(); ++$i)
        {
            $entitiesArray[$i] = $row;
        }
        return $entitiesArray;
    }
    // @return id or -1
    public function Insert($entity)
    {        
        // BUILD SQL
        $entity_data = (array) $entity;
        array_shift($entity_data); // skip id
        
        $table_columns = array_keys ($entity_data);
        $separated_columns = implode(", ", $table_columns); // column_name, column_name..
        $prepared_values = implode(", ", array_map(function($column) { return ':'.$column; }, $table_columns)); // :col, :col, ..         
                
        $sql = "INSERT INTO {$this->tableName} ({$separated_columns}) VALUES ({$prepared_values})";
        
        // PREPARE
        $result = $this->db->prepare($sql);
        
        foreach ($entity_data as $column => &$value)
        {            
            $result->bindParam(":{$column}", $value, PDO::PARAM_STR);
        }
        
        // EXECUTE
        if ($result->execute()) return $this->db->lastInsertId();
        return -1;        
    }
    // @return bool
    public function Delete($entity_id)
    {        
        $sql = "DELETE FROM {$this->tableName} WHERE id = :id";

        $result = $this->db->prepare($sql);
        $result->bindParam(':id', $entity_id, PDO::PARAM_INT);
        return $result->execute();    
    }
    // @return bool
    public function Update($newEntityState)
    {
        // BUILD SQL
        $entity_data = (array) $newEntityState;
        $entity_id = array_shift($entity_data); // skip id
        $table_columns = array_keys ($entity_data);
        // col = :marker
        $separated_markers = implode(", ", array_map(function($column) 
                                                     { 
                                                         return $column.' = :'.$column;
                                                     }, $table_columns));
        
        $sql = "UPDATE {$this->tableName}
                SET 
                    {$separated_markers}
                WHERE id = :id";

        // PREPARE
        $result = $this->db->prepare($sql);
        $result->bindParam(':id', $entity_id, PDO::PARAM_INT);
        foreach ($entity_data as $column_name => &$value)
        {            
            $result->bindParam(':'.$column_name, $value, PDO::PARAM_STR);
        }
        
        // RETURN
        return $result->execute();
    }
}