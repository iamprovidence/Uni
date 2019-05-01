<?php

class BrandModel extends ModelBase
{
    public function GetFromPost()
    {        
        $brand = new Brand();
        $brand->id = isset($_POST['id']) ? $_POST['id'] : null;
        $brand->name = $_POST['name'];
        $brand->is_available = $_POST['is_available'] === 'true' ? 1 : 0;
        $brand->sort_order = $_POST['sort_order'];
        return $brand;
    }
}