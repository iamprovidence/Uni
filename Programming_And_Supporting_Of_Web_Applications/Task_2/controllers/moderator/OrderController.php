<?php

class OrderController extends ModeratorControllerBase
{            
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct(Models::Order);
    }
    
    // METHODS
    public function actionList($page = 1)
    {
        $this->SetOffset($page, $this->limit);
        
        $orders = $this->GetRepository(Models::Order)->GetShortInfo($this->limit, $this->offset);
        
        $total = $this->GetRepository(Models::Order)->Count();
        $pagination = new Pagination($total, $page, MODERATOR_SHOWN_ITEM_PER_PAGE, 'page-');
        require_once(ROOT . '/view/moderator/orders/index.php');
        return true;
    }
    public function actionSingle($crud_mode, $order_id = null)
    {         
        // order info
        $order_info = $this->GetRepository(Models::Order)->GetById($order_id);
        
        // product info
        $product_order = $this->GetRepository(Models::Order)->GetProductFromOrder($order_info->id);
        $total_sum = $this->GetRepository(Models::Order)->GetTotalSum($order_info->id);
        
        $is_disabled = CrudMode::Parse($crud_mode) == CrudMode::Read;
        
        require_once(ROOT . '/view/moderator/orders/view.php');
        return true;
    }
    // AJAX
    public function actionUpdate()
    {                
        if (isset($_POST['submit']))
        {
            if ($this->GetRepository(Models::Order)->UpdateStatus($_POST['order_id'], $_POST['order_new_status']))
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