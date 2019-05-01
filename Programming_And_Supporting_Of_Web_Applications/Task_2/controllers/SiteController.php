<?php

class SiteController extends ControllerBase
{            
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
    }
    
    // METHODS
    public function actionIndex()
    {
        $isLanding = true;
        
        $title = "Payknife";        
        
        $best_products = $this->GetRepository(Models::Product)->getBestProducts(LANDING_PAGE_PRODUCT_AMOUNT);
                
        require_once (ROOT . '/view/user/index.php');
        return true;
    }
    public function actionContact()
    {
        $title = "Contact";
        
        $subjects = $this->GetRepository(Models::Subject)->Get();  
        
        // якщо користувач залогінений, email вже введений
        $user = $this->GetModel(Models::User)->GetUser();
        $user_email = is_null($user) ? '' : $user->email;
                
        require_once (ROOT . '/view/user/contact.php');
        return true;
    }
    
    public function actionCheckout()
    {
        $title = "Checkout";
        
        // якщо нема товарів, перенаправляємо користувача на головну
        if ($this->GetModel(Models::Cart)->IsEmpty()) header("Location: \\");
        
        // якщо користувач залогінений, email вже введений
        $user = $this->GetModel(Models::User)->GetUser();
        $user_email = !is_null($user) ? $user->email : '';
        
        require_once(ROOT . '/view/user/checkout.php');
        return true;            
    }
    
    public function actionAbout()
    {
        $title = "About";        
        
        $contentTitle = "About";
        
        $contentText= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        <br/><br/>
        Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. ";
        
        require_once(ROOT . '/view/user/template.php');
        return true;
    }
    public function actionPrivacy()
    {
        $title = "Privacy";
        
        $contentTitle = "Privacy";
        
        $contentText= "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
        <br/><br/>
        Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. ";
        
        require_once (ROOT . '/view/user/template.php');
        
        return true;
    }
    
    public function actionModerator()
    {               
        $this->SafeRole(Role::Moderator); 
        require_once (ROOT . '/view/moderator/index.php');
        return true;
    }

    
    
    // AJAX
    public function actionSend()
    {   
        // обробка форми        
        if (!$this->GetModel(Models::Message)->SendMessageEmail()) 
        {
            echo (new OperationStatus(false, "Could not send message"))->JSON(); 
            return true;
        }        
        
        $this->GetRepository(Models::Message)->Insert($this->GetModel(Models::Message)->GetFromPost());
        
        echo (new OperationStatus(true, "Your message has been sent"))->JSON();
        return true;
    }
}