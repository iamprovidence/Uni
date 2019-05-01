<?php

class SubjectModel extends ModelBase
{
    public function GetFromPost()
    {        
        $subject = new Subject();
        $subject->id = isset($_POST['id']) ? $_POST['id'] : null;
        $subject->name = $_POST['name'];
        return $subject;
    }
}