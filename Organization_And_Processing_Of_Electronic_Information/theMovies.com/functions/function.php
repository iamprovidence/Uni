<?php
    require_once "connect.php";

    function getNews ($limit, $id=0 )
    {
        global $mysqli;
        connectDB();
        if($id)
        {
            $where = "WHERE `id` = ".$id;
        }
        $result = $mysqli->query("SELECT * FROM `articles`$where ORDER BY `id` DESC LIMIT $limit");
        closeDB();
        if(!$id)
        {
            return resultToArray ($result);
        }
        else
        {
            return $result->fetch_assoc();
        }
    }
    function getAside ($limit, $id=0 )
    {
        global $mysqli;
        connectDB();
        if($id)
        {
            $where = "WHERE `id` = ".$id;
        }
        $result = $mysqli->query("SELECT * FROM `treilers`$where ORDER BY `id` DESC LIMIT $limit");
        closeDB();
        if(!$id)
        {
            return resultToArray ($result);
        }
        else
        {
            return $result->fetch_assoc();
        }
    }
    
    function resultToArray($result)
    {
        $array = array();
        while(($row = $result->fetch_assoc()) != false)
        {
            $array[] = $row;
        }
        return $array;
    }
?>