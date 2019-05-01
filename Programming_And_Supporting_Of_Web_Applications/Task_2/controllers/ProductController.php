<?php

class ProductController extends ControllerBase
{
    // FIELDS
    private $fileManager;
    
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
                
        $this->fileManager = new FileManager();
        
        $this->SetLimit(USER_SHOWN_ITEM_PER_PAGE);
    }
    
    // METHODS
    public function actionIndex($product_id)
    {        
        $title = "Payknife";
        
        // info
        $selected_product = $this->GetRepository(Models::Product)->GetById($product_id);
        
        $brand = $this->GetRepository(Models::Brand)->GetById($selected_product->brand_id);
        $category = $this->GetRepository(Models::Category)->GetById($selected_product->category_id);
        
        // comment
        $is_comment_available = $this->GetModel(Models::Comment)->IsCommentAvailable($product_id);
        
        // mark        
        $is_rating_available = $this->GetModel(Models::Rate)->IsRatingAvailable($product_id);
        $current_mark = $this->GetRepository(Models::Rate)->GetAverageMark($product_id);
        $user = $this->GetModel(Models::User)->GetUser();
        $user_mark = $this->GetRepository(Models::Rate)->GetUserMark($user ? $user->id : -1, $product_id);
        
        require_once(ROOT . '/view/user/product.php');
        return true;
    }
    
    public function actionShop($page = 1)
    {              
        $title = "Shop";        
        
        $this->SetOffset($page, $this->limit);        

        // brands and categories in left menu
        $brand_id = -1;
        $category_id = -1;
        $order_id = 0;
        
        $brands = $this->GetRepository(Models::Brand)->GetWithAmount();
        $categories = $this->GetRepository(Models::Category)->GetWithAmount();
        
        // products
        $products_shop = $this->GetRepository(Models::Product)->GetList(null, null, $this->limit, $this->offset);
        $total = $this->GetRepository(Models::Product)->CountWhere(array('is_available' => '1'));
        
        // pagination
        $pagination = new Pagination($total, $page, USER_SHOWN_ITEM_PER_PAGE, 'page-');
        
        $end_product_number = count($products_shop) + ($page-1) * USER_SHOWN_ITEM_PER_PAGE; 
        $start_product_number = $end_product_number == 0 ? 0 : ($page-1) * USER_SHOWN_ITEM_PER_PAGE + 1;
        
        // add view
        require_once (ROOT . '/view/user/shop.php');
        
        return true;
    }
    public function actionBrand($brand_id, $page = 1)
    {              
        $title = "Shop";        
        
        $this->SetOffset($page, $this->limit);        

        // brands and categories in left menu
        $category_id = -1;
        $order_id = -1;
        
        $brands = $this->GetRepository(Models::Brand)->GetWithAmount();
        $categories = $this->GetRepository(Models::Category)->GetWithAmount();
        
        // products
        $products_shop = $this->GetRepository(Models::Product)->GetList(array('brand_id' => $brand_id), null, $this->limit, $this->offset);
        $total = $this->GetRepository(Models::Product)->CountWhere(array('brand_id' => $brand_id, 'is_available' => '1'));
        
        // pagination
        $pagination = new Pagination($total, $page, USER_SHOWN_ITEM_PER_PAGE, 'page-');
        
        $end_product_number = count($products_shop) + ($page-1) * USER_SHOWN_ITEM_PER_PAGE; 
        $start_product_number = $end_product_number == 0 ? 0 : ($page-1) * USER_SHOWN_ITEM_PER_PAGE + 1;
        
        // add view
        require_once (ROOT . '/view/user/shop.php');
        
        return true;
    }
    
    public function actionCategory($category_id, $page = 1)
    {              
        $title = "Shop";        
        
        $this->SetOffset($page, $this->limit);        

        // brands and categories in left menu
        $brand_id = -1;
        $order_id = -1;
        
        $brands = $this->GetRepository(Models::Brand)->GetWithAmount();
        $categories = $this->GetRepository(Models::Category)->GetWithAmount();
        
        // products
        $products_shop = $this->GetRepository(Models::Product)->GetList(array('category_id' => $category_id), null, $this->limit, $this->offset);
        $total = $this->GetRepository(Models::Product)->CountWhere(array('category_id' => $category_id, 'is_available' => '1'));
        
        // pagination
        $pagination = new Pagination($total, $page, USER_SHOWN_ITEM_PER_PAGE, 'page-');
        
        $end_product_number = count($products_shop) + ($page-1) * USER_SHOWN_ITEM_PER_PAGE; 
        $start_product_number = $end_product_number == 0 ? 0 : ($page-1) * USER_SHOWN_ITEM_PER_PAGE + 1;
        
        // add view
        require_once (ROOT . '/view/user/shop.php');
        
        return true;
    }
    
    public function actionSort($order_id, $page = 1)
    {              
        $title = "Shop";        
        
        $this->SetOffset($page, $this->limit);        

        // brands and categories in left menu
        $category_id = -1;
        $brand_id = -1;
        $sort_array = [null, array('id' => 'DESC'), array('price' => 'ASC'), array('price' => 'DESC')];
        
        $brands = $this->GetRepository(Models::Brand)->GetWithAmount();
        $categories = $this->GetRepository(Models::Category)->GetWithAmount();
        
        // products
        $products_shop = $this->GetRepository(Models::Product)->GetList(null, $sort_array[$order_id], $this->limit, $this->offset);
        $total = $this->GetRepository(Models::Product)->CountWhere(array('is_available' => '1'));
        
        // pagination
        $pagination = new Pagination($total, $page, USER_SHOWN_ITEM_PER_PAGE, 'page-');
        $start_product_number = ($page-1) * USER_SHOWN_ITEM_PER_PAGE + 1;
        $end_product_number = count($products_shop) + ($page-1) * USER_SHOWN_ITEM_PER_PAGE; 
        
        // add view
        require_once (ROOT . '/view/user/shop.php');
        
        return true;
    }
    
    /*
    public function actionShop($page = 1)
    {      
        ob_start();
        
        $title = "Shop";        
        
        $this->limit = USER_SHOWN_ITEM_PER_PAGE;
        $this->SetOffset($page, $this->limit);        

        // brands and categories in left menu
        $brands = $this->brandRepository->GetWithAmount();
        $categories = $this->categoryRepository->GetWithAmount();
        
        
        if (isset($_POST['submit']))
        {
            $products_shop = $this->productRepository->GetList(null, null, $this->limit, $this->offset);
            $total = $this->productRepository->Count();      
        }   
        else
        {
            $products_shop = $this->productRepository->GetList(null, null, $this->limit, $this->offset);
            $total = $this->productRepository->Count();        
        }
        
        // pagination
        $pagination = new Pagination($total, $page, USER_SHOWN_ITEM_PER_PAGE, 'page-');
        $start_product_number = ($page-1) * USER_SHOWN_ITEM_PER_PAGE + 1;
        $end_product_number = count($products_shop) + ($page-1) * USER_SHOWN_ITEM_PER_PAGE; 
        
        // add view
        if (isset($_POST['submit'])) require_once (ROOT . "/view/user/layout/shop.php");
        else                         require_once (ROOT . '/view/user/shop.php');
        
        echo ob_get_clean();
        return true;
    }
    */
    
    
}