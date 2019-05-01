<?php

class UserModel extends ModelBase
{
    // CONST
    const KEY = "USER";
    
    // FIELDS
    private $fileManager;
    
    // CONSTRUCTORS
    public function __construct()
    {
        $this->fileManager = new FileManager();
    }
    
    // METHODS
    public function GetFromPost() 
    {
        $user = new User();
        $user->nickname = $_POST['user_nickname'];
        $user->email    = $_POST['user_email'];
        $user->password = $_POST['user_password'];
        return $user;
    }
    public function GetImage($id)
    {
        return $this->fileManager->GetImage(ImgFileFolder::User, $id);
    }
    public function Authorize($user)
    {
        $_SESSION[self::KEY] = $user;
    }
    public function IsLogged()
    {
        if (isset($_SESSION[self::KEY])) return true;
        return false;
    }
    public function GetUser()
    {
        if (isset($_SESSION[self::KEY])) return $_SESSION[self::KEY];
        return null;
    }
    public function LogOut()
    {
        if (isset($_SESSION[self::KEY])) unset($_SESSION[self::KEY]);
    }
    public function Is($role)
    {
        if (isset($_SESSION[self::KEY])) return $_SESSION[self::KEY]->role == $role;
        return false;
    }
    public function HasRights($role)
    {
        if (isset($_SESSION[self::KEY])) return $_SESSION[self::KEY]->role >= $role;
        return false;
    }
}