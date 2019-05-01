<?php

class ModeratorProductController extends ModeratorControllerBase
{
    // FIELDS
    private $fileManager;
    
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Product);
                
        $this->fileManager = new FileManager();
    }
    
    // METHODS
    
    public function actionList($page = 1)
    {                 
        $this->SetOffset($page, $this->limit);
        
        $products = $this->GetRepository(Models::Product)->Get("id, name, price, is_available, is_comments_available, is_new", 
                                                  null, null, $this->limit, $this->offset);
        
        $total = $this->GetRepository(Models::Product)->Count();
        $pagination = new Pagination($total, $page, MODERATOR_SHOWN_ITEM_PER_PAGE, 'page-');
                
        require_once(ROOT . '/view/moderator/products/index.php');
        return true;
    }
    public function actionSingle($crud_mode, $product_id = null)
    {                 
        $crud_mode = CrudMode::Parse($crud_mode);        
        
        // prepare view
        $view = new ViewModel();
        $view->title = $crud_mode == CrudMode::Create ? 'Create' : "Product №<span>{$product_id}</span>";
        $view->button_text = $this->GetButtonText($crud_mode);
        $view->button_css_class =  $this->GetButtonCssClass($crud_mode);
        $view->is_input_disabled = $crud_mode == CrudMode::Read;           
        
        
        // get data
        $product    = ($crud_mode == CrudMode::Create) ?
                        new Product() : 
                        $this->GetRepository(Models::Product)->GetById($product_id);
        $brands     = $this->GetRepository(Models::Brand)->Get("id, name", array("is_available" => "1"));
        $categories = $this->GetRepository(Models::Category)->Get("id, name", array("is_available" => "1"));
        
        require_once(ROOT . '/view/moderator/products/view.php');
        return true;
    }
    private function GetButtonText($crud_mode)
    {
        if ($crud_mode == CrudMode::Create) return 'Create';
        if ($crud_mode == CrudMode::Read  ) return 'Delete';
        if ($crud_mode == CrudMode::Update) return 'Update';
    }
    private function GetButtonCssClass($crud_mode)
    {
        if ($crud_mode == CrudMode::Create) return 'btn-info';
        if ($crud_mode == CrudMode::Read  ) return 'btn-danger';
        if ($crud_mode == CrudMode::Update) return 'btn-success';
    }
    
    // AJAX
    public function actionAdd()
    { 
        if (isset($_POST['submit']))
        {   
            $product = $this->GetModel(Models::Product)->GetFromPost();
            
            // insert
            $inserted_product_id = $this->GetRepository(Models::Product)->Insert($product);
            if ($inserted_product_id != -1)
            {                
                // image
                if (isset($_FILES['product_img']) &&
                    !$this->fileManager->UploadImage(ImgFileFolder::Product, 'product_img', $inserted_product_id))
                {
                    echo (new OperationStatus(false, "Could not upload image"))->JSON();
                    return true;                
                }            
                if ($_POST['do_reset_image'] === 'true')
                {
                    $this->fileManager->DeleteImage(ImgFileFolder::Product, $inserted_product_id);
                }
                
                echo (new OperationStatus(true, "Successfully added {$product->name}"))->JSON();
            }
            else
            {
                echo (new OperationStatus(false, "Something went wrong"))->JSON();
            }
        }
        return true;
    }
    // AJAX
    public function actionDelete()
    {
        if (isset($_POST['submit']))
        {
            parent::actionDelete();
            $this->fileManager->DeleteImage(ImgFileFolder::Product, $_POST['entity_id']);
        }
        return true;
    }
    // AJAX
    public function actionUpdate()
    {
        if (isset($_POST['submit']))
        {   
            $product = $this->GetModel(Models::Product)->GetFromPost();
            
            // image
            if (isset($_FILES['product_img']) &&
                !$this->fileManager->UploadImage(ImgFileFolder::Product, 'product_img', $product->id))
            {
                echo (new OperationStatus(false, "Could not upload image"))->JSON();
                return true;                
            }            
            if ($_POST['do_reset_image'] === 'true')
            {
                $this->fileManager->DeleteImage(ImgFileFolder::Product, $product->id);
            }
            
            // update
            if ($this->GetRepository(Models::Product)->Update($product))
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
}
