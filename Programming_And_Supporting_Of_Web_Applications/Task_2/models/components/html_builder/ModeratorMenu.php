<?php

class ModeratorMenu
{
    // FIELDS
    private $menuNames;
    
    // CONSTRUCTORS
    public function __construct()
    {
        $this->menuNames = array
        (
            'messages',
            'orders',
            'brands',
            'categories',
            'products',
            'comments',
            'subjects'
        );
    }
    
    // METHODS 
    public function get()
    {
        return "<div id='mySidenav' class='sidenav'>\n" . $this->generateLinks() . "\t</div>";
    }
    private function getURI()
    {
        return rawurldecode(trim($_SERVER['REQUEST_URI'], '/'));
    }
    private function generateLinks()
    {
        $links = null;
        foreach ($this->menuNames as $menu_item)
        {
            $uppercase_first_letter_menu = ucfirst($menu_item);

            $active_link = $this->isActive($menu_item) ? "class='selected'" : "";
            
            $links .= "\t\t<a href='/moderator/{$menu_item}/' {$active_link}>{$uppercase_first_letter_menu}</a>\n";
        }
        return $links;
    }
    private function isActive($menu_item)
    {
        $uri = $this->getURI();
        return preg_match("/{$menu_item}/i", $uri);
    }

}