## PAYKNIFE

#### run

I run this in ``openserver`` with domain ``www.payknife.com``

#### config

* if you add additional folder, be aware to regisrtate it in ``components/Autoload.php``
* all database configuration in `congig/db_params.php`
* email parameters are in `config/email_params.php`
* all routes are in ``config/routes.php``
* all global constants are in ``settings.json``
* google authentication settings are in ``components/GoogleClient.php``
* for live chat I have used ``tawk.to``

### convention used:

* for URL: ``"url" => "controller/action/parameters"`` 
* controllers' name starts with uppercase letter and ends with ``___Controller``
* controllers action' name starts with ``action___`` and action name with uppercase 
* entities has the same name as table. Entitie's properties has the same names as table's columns
* domain models' names are the same as entities name and ends with ``___Models``
* repositories' names are the same as entities name and ends with ``___Repository``
* models and repositories are created through factory which take arguments from ``Models`` enum