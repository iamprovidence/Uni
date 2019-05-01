<?php

class UserController extends ControllerBase
{
    // FIELDS 
    private $fileManager;
    
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
        
        $this->fileManager = new FileManager();
    }
    
    // METHODS
    public function actionCabinet()
    {     
        $title = 'Cabinet';
        $this->SafeRole(Role::User);
        
        $user = $this->GetModel(Models::User)->GetUser();       
        
        require_once(ROOT . '/view/user/cabinet.php');
        return true;
    }
    public function actionEdit()
    {
        $this->SafeRole(Role::User);
        
        if (isset($_POST['submit']))
        {
            // get data
            $user = $this->GetModel(Models::User)->GetUser();
            $user_nickname = $_POST['user_nickname'];
            $user_password = $_POST['user_password'];
            $user_new_password = $_POST['user_new_password'];
            
            // check
            if ($user->password != $user_password)
            {
                echo (new OperationStatus(false, "Wrong password"))->JSON();
                return true;
            }
            
            if ($user->nickname != $user_nickname && $this->GetRepository(Models::User)->IsNicknameExist($user_nickname))
            {                
                echo (new OperationStatus(false, "Current nickname already exist"))->JSON();
                return true;
            }
            
            // image
            if (isset($_FILES['user_new_avatar']) &&
                !$this->fileManager->UploadImage(ImgFileFolder::User, 'user_new_avatar', $user->id))
            {
                echo (new OperationStatus(false, "Could not upload image"))->JSON();
                return true;                
            }            
            if ($_POST['user_do_reset_avatar'] === 'true')
            {
                $this->fileManager->DeleteImage(ImgFileFolder::User, $user->id);
            }
            
            // edit
            $user->nickname = $user_nickname;
            if (!empty($user_new_password)) $user->password = $user_new_password;            
                   
            // update and send response
            if ($this->GetRepository(Models::User)->Update($user))
            {                
                echo (new OperationStatus(true, "Successfully updated"))->JSON();
            }
            else
            {
                echo (new OperationStatus(false, "Something went wrong"))->JSON();
            }
        }
        
        return true;
    }
    
    // AJAX
    public function actionLogin()
    {
        if (isset($_POST['submit']))
        {
            // get data
            $user_email = $_POST['user_email'];
            $user_password = $_POST['user_password'];
            
            // check data
            if (!$this->GetRepository(Models::User)->IsEmailExist($user_email))
            {
                echo (new OperationStatus(false, "Email is wrong"))->JSON();
                return true;
            }
            if (!$this->GetRepository(Models::User)->IsPasswordRight($user_email, $user_password))
            {                
                echo (new OperationStatus(false, "Password is wrong"))->JSON();
                return true;
            }
            
            // authorize            
            $user = $this->GetRepository(Models::User)->GetUser($user_email, $user_password);            
            $this->GetModel(Models::User)->Authorize($user);
            
            // result
            echo (new OperationStatus(true, "Everything is okay"))->JSON();
        }
        return true;
    }
    public function actionLogout()
    {
        $this->GetModel(Models::User)->LogOut();
        header('Location: /');
        return true;
    }
    // AJAX
    public function actionSignup()
    {
        if (isset($_POST['submit']))
        {
            // get data
            $user_nickname = $_POST['user_nickname'];
            $user_email = $_POST['user_email'];
            $user_password = $_POST['user_password'];
            
            // check data
            if ($this->GetRepository(Models::User)->IsNicknameExist($user_nickname))
            {
                echo (new OperationStatus(false, "Current nickname already exist"))->JSON();
                return true;
            }
            if ($this->GetRepository(Models::User)->IsEmailExist($user_email))
            {
                echo (new OperationStatus(false, "Current email already has been registered"))->JSON();
                return true;
            }
            
            // create
            $new_user = new User();
            $new_user->nickname = $user_nickname;
            $new_user->email = $user_email;
            $new_user->password = $user_password;
            
            // result
            if ($this->GetRepository(Models::User)->Insert($new_user) != -1)
            {               
                $this->GetModel(Models::User)->Authorize($new_user);
                echo (new OperationStatus(true, "New user has been successfully created"))->JSON();   
            }
            else
            {
                echo (new OperationStatus(false, "Something went wrong."))->JSON();
            }
            
        }
        return true;
    }
    public function actionGoogle()
    {        
        if(isset($_GET['code']))
        {
            $g_client = $this->GetGoogleClient();
            $token = $g_client->fetchAccessTokenWithAuthCode($_GET['code']);

            $o_auth = new Google_Service_Oauth2($g_client);

            $user_email = $o_auth->userinfo_v2_me->get()->email;

            // check data
            if (!$this->GetRepository(Models::User)->IsEmailExist($user_email))
            {                
                // $title, $contentTitle, $contentText
                (new ErrorController())->actionErrorPage("Error", "
                Can not logged in", "You can not logged in with current account. <br/>
                Please, make sure you have created account beforehand. <br/>
                Please, make sure you account email is the same as your google email.");
                return true;
            }
            
            // authorize            
            $user = $this->GetRepository(Models::User)->GetUserByEmail($user_email);            
            $this->GetModel(Models::User)->Authorize($user);
            
            // result
            header('Location: /');
	   }
        return true;
    }
    
}