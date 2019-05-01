<?php 

class MessageRepository extends RepositoryBase
{
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("Message");
    }
    
    // METHODS
    public function GetShortMessageInfo($limit, $offset)
    {
        $sql = "SELECT message.id, message.date, message.user_email, subject.name AS subject_name
                FROM message 
                LEFT JOIN subject ON message.subject_id = subject.id
                LIMIT :limit
                OFFSET :offset";
        
        $result = $this->db->prepare($sql);
        $result->bindParam(":limit", $limit, PDO::PARAM_INT);
        $result->bindParam(":offset", $offset, PDO::PARAM_INT);
        
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