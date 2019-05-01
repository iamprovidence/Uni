<?php

abstract class ImgFileFolder
{
    const User      = 0;
    const Product   = 1;
    
    public static function GetPath($fileFolderType)
    {
        if ($fileFolderType == self::User)    return '/uploads/images/users/';
        if ($fileFolderType == self::Product) return '/uploads/images/products/';
    }
}