<?php

interface IRepository
{
    public function Count();
    public function CountWhere($columnArray);
    public function GetById($entityId);
    // @param $include = string, "name, surname"
    // @param $filterKeyValueArray = array({column name = value})
    // @param $orderByColumn = string, column name
    // @param $limit = int
    // @param $offset = int
    //
    // @retrun entities array
    public function Get($include, $filterKeyValueArray, $orderByColumn, $limit, $offset);
    public function Insert($entity);
    public function Delete($entityId);
    public function Update($newEntityState);
}