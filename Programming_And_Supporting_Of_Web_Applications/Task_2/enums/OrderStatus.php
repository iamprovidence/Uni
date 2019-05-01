<?php

abstract class OrderStatus
{
    const NewOrder   = 0;
    const InProgress = 1;
    const Delivering = 2;
    const Done       = 3;
    
    public static function GetStatusText($status)
    {        
        if ($status == self::NewOrder)   return 'New Order';        
        if ($status == self::InProgress) return 'In Progress';
        if ($status == self::Delivering) return 'Delivering';
        if ($status == self::Done)       return 'Closed';
    }
    public static function GetArray()
    {
        return array(self::NewOrder, self::InProgress, self::Delivering, self::Done);
    }
}