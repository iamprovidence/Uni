<?php 

class SubjectRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Subject");
    }
    
    // METHODS    
    public function AddSubject($name)
    {        
        $amount = $this->CountWhere(array($name));
        
        if ($amount > 0) return true;
        
        // запит
        $sql = 'INSERT INTO '. $this->tableName  
                . '(name)'
                . 'VALUES '
                . '(:name)';
        
        // Підготуємо запит
        $result = $this->db->prepare($sql);
        $result->bindParam(':name', $name, PDO::PARAM_STR);
             
        return $result->execute();
    }
    
}