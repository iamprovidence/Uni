<?php

require_once(ROOT . '/libs/GoogleAPI/vendor/autoload.php');

class GoogleClient
{
    public static function GetGoogleClient()
    {
        $gClient = new Google_Client();
        $gClient->setClientId("202907600984-83cp5vm1b9t63d08b2751n10srtholmu.apps.googleusercontent.com");
        $gClient->setClientSecret("nCHGgjwDN1aemeETCb6DB59c");
        $gClient->setApplicationName("payknife");
        $gClient->setRedirectUri("http://www.payknife.com/google-login");
        $gClient->addScope("https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email");
        
        return $gClient;
    }
}