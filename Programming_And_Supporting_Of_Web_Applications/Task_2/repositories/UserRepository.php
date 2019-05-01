<?php 

class UserRepository extends RepositoryBase
{ 
    // CONSTRUCTORS
    public function __construct()
    {        
        parent::__construct("User");
    }
    
    // METHODS
    // @return bool
    public function UpdateRole($user_id, $new_role)
    {
        $sql = "UPDATE user 
                    SET role = :role 
                WHERE id = :id;";
            
        $result = $this->db->prepare($sql);
        $result->bindParam(':id', $user_id, PDO::PARAM_INT);
        $result->bindParam(':role', $new_role, PDO::PARAM_INT);
        
        return $result->execute();
    }
    public function IsNicknameExist($nickname)
    {
        return $this->CountWhere(array("nickname" => $nickname)) > 0;
    }
    public function IsEmailExist($email)
    {
        return $this->CountWhere(array("email" => $email)) > 0;
    }
    
    public function IsPasswordRight($email, $password)
    {
        return $this->CountWhere(array("email" => $email, "password" => $password)) > 0;
    }
    public function GetUser($user_email, $user_password)
    {
        $sql = "SELECT * FROM user WHERE email = :email AND password = :password;";
        
        $result = $this->db->prepare($sql);
        $result->bindParam(':email', $user_email, PDO::PARAM_STR);
        $result->bindParam(':password', $user_password, PDO::PARAM_STR);
        
        $result->setFetchMode(PDO::FETCH_CLASS, ucfirst($this->tableName));
        $result->execute();        

        return $result->fetch();
    }
    
    public function GetUserByEmail($user_email)
    {
        $sql = "SELECT * FROM user WHERE email = :email;";
        
        $result = $this->db->prepare($sql);
        $result->bindParam(':email', $user_email, PDO::PARAM_STR);
        
        $result->setFetchMode(PDO::FETCH_CLASS, ucfirst($this->tableName));
        $result->execute();        

        return $result->fetch();
    }
}