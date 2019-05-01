<?php

class UserMenu
{
    // FIELDS
    private $menuNames;
    
    // CONSTRUCTORS
    public function __construct()
    {
        // menu names => uri in which menu is highlighted
        $this->menuNames = array
        (
            'home' => 'home, index',
            'shop' => 'shop, product',
            'about' => 'about',
            'contact' => 'contact',
        );
    }
    
    // METHODS 
    public function get()
    {
        return "<ul class='navbar-nav mr-auto'>\n" . $this->generateLinks() . "\t\t</ul>\n";
    }
    private function getURI()
    {
        return rawurldecode(trim($_SERVER['REQUEST_URI'], '/'));
    }
    private function generateLinks()
    {
        $links = null;
        foreach (array_keys($this->menuNames) as $menu_item)
        {
            $uppercase_first_letter_menu = ucfirst($menu_item);

            $active_link = $this->isActive($menu_item) ? "active" : "";

            $links .= "
                        <li class='nav-item'>
                            <a class='nav-link font-weight-bold {$active_link}' href='/{$menu_item}/'>{$uppercase_first_letter_menu}</a>
                        </li>
            ";
        }
        return $links;
    }
    private function isActive($menu_item)
    {
        $uri = $this->getURI();
        $menu_uri = explode(', ', $this->menuNames[$menu_item]);
        
        if (empty($uri) && $menu_item == 'home') return true;
        foreach ($menu_uri as $menu_uri_item)
        {
            if (preg_match("/{$menu_uri_item}/i", $uri)) return true;
        }
        return false;
    }

}