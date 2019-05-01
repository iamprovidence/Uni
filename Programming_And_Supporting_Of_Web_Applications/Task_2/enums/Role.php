<?php

// higher value = higer rights
abstract class Role
{
    const User = 0;
    const Moderator = 1;
    const Administrator = 2;
    
    public static function GetArray()
    {
        return array(
            self::User => 'User', 
            self::Moderator => 'Moderator', 
            self::Administrator => 'Administrator');
    }
}