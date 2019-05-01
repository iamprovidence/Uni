<?php

class RateController extends ControllerBase
{
    // CONSTRUCTORS
    public function __construct()
    {
        parent::__construct();
    }
    
    // METHODS
    // AJAX
    public function actionAdd()
    {
        if ($_POST['submit'])
        {            
            if (!$this->GetModel(Models::Rate)->IsRatingAvailable($_POST['product_id']))
            {                
                echo (new OperationStatus(false, "Rating is not available"))->JSON();
                return true;
            }
            
            $rate_mark = $this->GetModel(Models::Rate)->GetFromPost();            
            
            if ($this->GetRepository(Models::Rate)->AddOrReplace($rate_mark))
            {                  
                $operation_status = new OperationStatus(true, "Your mark is taken into account");
                $operation_status->data = array("newMark" => $this->GetRepository(Models::Rate)->GetAverageMark($_POST['product_id']));
                echo $operation_status->JSON();
            }
            else
            {
                echo (new OperationStatus(false, "Something went wrong"))->JSON();
            }
        }
        return true;
    }
}