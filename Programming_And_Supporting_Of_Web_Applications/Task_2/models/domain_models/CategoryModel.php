<?php

class CategoryModel extends ModelBase
{
    public function GetFromPost()
    {      
        $category = new Category();
        $category->id = isset($_POST['id']) ? $_POST['id'] : null;
        $category->name = $_POST['name'];
        $category->is_available = $_POST['is_available'] === 'true' ? 1 : 0;
        $category->sort_order = $_POST['sort_order'];
        return $category;
    }
}