<?php

abstract class CrudMode
{
    const Create = 0;
    const Read   = 1;
    const Update = 2;
    const Delete = 3;
    
    public static function Parse($str)
    {
        if ($str == 'create') return self::Create;
        if ($str == 'read'  ) return self::Read;
        if ($str == 'update') return self::Update;
        if ($str == 'delete') return self::Delete;
    }
}