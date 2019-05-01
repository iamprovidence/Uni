<?php

class FileManager
{
    // CONST
    const ALLOWED = ["image/jpeg", "image/gif", "image/png"];
    
    // METHODS
    public function GetImage($folder_type, $entity_id)
    {
        $path = ImgFileFolder::GetPath($folder_type);        
        
        $no_image = 'no_image.jpg';
        $path_to_product_image = $path . $entity_id . '.jpg';

        if (file_exists($_SERVER['DOCUMENT_ROOT'].$path_to_product_image)) 
        {
            return $path_to_product_image;
        }

        return $path . $no_image;
    }
    public function UploadImage($folder_type, $image_key, $entity_id)
    {        
        $path = $_SERVER['DOCUMENT_ROOT'] . ImgFileFolder::GetPath($folder_type) . $entity_id . '.jpg';  
        
        if ($this->IsImageValid($image_key)) 
        {
            move_uploaded_file($_FILES[$image_key]["tmp_name"], $path);

            return true;
        }
        return false;   
    }
    private function IsImageValid($image_key)
    {
        return  isset($_FILES[$image_key]) && 
                is_uploaded_file($_FILES[$image_key]['tmp_name']) && 
                in_array($_FILES[$image_key]['type'], self::ALLOWED);
    }
    public function DeleteImage($folder_type, $entity_id)
    {
        $path = $_SERVER['DOCUMENT_ROOT'] . ImgFileFolder::GetPath($folder_type) . $entity_id . '.jpg';  
        
        if (file_exists($path)) unlink($path);
    }
}