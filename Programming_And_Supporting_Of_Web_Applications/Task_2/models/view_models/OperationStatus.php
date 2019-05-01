<?php

class OperationStatus
{
    // FIELDS
    public $isOperationSucceeded;
    public $message;
    public $data;
    
    // CONSTRUCTORS
    public function __construct($isOperationSucceeded, $message)
    {
        $this->isOperationSucceeded = $isOperationSucceeded;
        $this->message = $message;
        $this->data = null;
    }
    
    // METHODS
    public function JSON()
    {
        return json_encode($this);
    }
}