<?php

// CONVENTION
// "uri" => "controller/action/parameters" 
// "" => "site/index" // actionIndex в SiteController

return array(
    
    // admin part
    'administrator' => 'administratorUser/list',
    'administrator/page-([0-9]+)' => 'administratorUser/list/$1',
    'administrator/update' => 'administratorUser/update', // AJAX
    'administrator/delete' => 'administratorUser/delete', // AJAX
    
    // moderator part
    'moderator/messages' => 'message/list',
    'moderator/messages/page-([0-9]+)' => 'message/list/$1',
    'moderator/messages/([0-9]+)' => 'message/single/$1',
    'moderator/messages/delete' => 'message/delete', // AJAX
    
    'moderator/brands' => 'brand/list',
    'moderator/brands/page-([0-9]+)' => 'brand/list/$1',
    'moderator/brands/add' => 'brand/add', // AJAX
    'moderator/brands/delete' => 'brand/delete', // AJAX
    'moderator/brands/update' => 'brand/update', // AJAX
    
    'moderator/categories' => 'category/list',
    'moderator/categories/page-([0-9]+)' => 'category/list/$1',
    'moderator/categories/add' => 'category/add',// AJAX
    'moderator/categories/delete' => 'category/delete',// AJAX
    'moderator/categories/update' => 'category/update', // AJAX
    
    'moderator/products' => 'moderatorProduct/list',
    'moderator/products/page-([0-9]+)' => 'moderatorProduct/list/$1',
    'moderator/products/create' => 'moderatorProduct/single/$1',
    'moderator/products/(read|update)/([0-9]+)' => 'moderatorProduct/single/$1/$2',
    'moderator/products/add' => 'moderatorProduct/add',// AJAX
    'moderator/products/delete' => 'moderatorProduct/delete',// AJAX
    'moderator/products/update' => 'moderatorProduct/update',// AJAX
    
    'moderator/comments' => 'moderatorComment/list',
    'moderator/comments/page-([0-9]+)' => 'moderatorComment/list/$1',
    'moderator/comments/([0-9]+)' => 'moderatorComment/single/$1',
    'moderator/comments/delete' => 'moderatorComment/delete',// AJAX
    
    'moderator/subjects' => 'subject/list',
    'moderator/subjects/page-([0-9]+)' => 'subject/list/$1',
    'moderator/subjects/add/([a-zA-z ]+)' => 'subject/add/$1', // AJAX
    'moderator/subjects/delete/([0-9]+)' => 'subject/delete/$1', // AJAX
    'moderator/subjects/update' => 'subject/update', // AJAX
    
    'moderator/orders' => 'order/list',
    'moderator/orders/page-([0-9]+)' => 'order/list/$1',
    'moderator/orders/(read|update)/([0-9]+)' => 'order/single/$1/$2',
    'moderator/orders/update' => 'order/update',// AJAX
    
    'moderator' => 'site/moderator',
    
    // user part
    'cabinet' => 'user/cabinet',
    'login' => 'user/login', // AJAX
    'logout' => 'user/logout',
    'signup' => 'user/signup',
    'edit' => 'user/edit', // AJAX
    'google-login(\?code=[\s\S]+)' => 'user/google', // log in with google
    
    // guest part    
    'checkout' => 'site/checkout',
    'product/([0-9]+)' => 'product/index/$1',    
    'privacy' => 'site/privacy', 
    'contact' => 'site/contact', 
    'message' => 'site/send', // AJAX
    'about' => 'site/about', 
    
    // product    
    'shop/brand/([0-9]+)/page-([0-9]+)' => 'product/brand/$1/$2',   
    'shop/brand/([0-9]+)' => 'product/brand/$1', 
    'shop/category/([0-9]+)/page-([0-9]+)' => 'product/category/$1/$2',    
    'shop/category/([0-9]+)' => 'product/category/$1', 
    'shop/sort/([0-9]+)/page-([0-9]+)' => 'product/sort/$1/$2', 
    'shop/sort/([0-9]+)' => 'product/sort/$1', 
    'shop' => 'product/shop', 
    'shop/page-([0-9]+)' => 'product/shop/$1', 
    
    // comment
    'comment/view' => 'comment/view', // AJAX
    'comment/add' => 'comment/add', // AJAX
    
    // rate
    'rating/add' => 'rate/add', // AJAX
    
    // cart    
    'cart/add' => 'cart/add', // AJAX
    'cart/view' => 'cart/view', // AJAX
    'cart/amount' => 'cart/amount', // AJAX
    'cart/delete' => 'cart/delete', // AJAX
    'cart/checkout' => 'cart/checkout', // AJAX
    
    'home' => 'site/index',
    'index' => 'site/index',
    '' => 'site/index',
);