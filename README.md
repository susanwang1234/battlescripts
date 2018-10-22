# BattleScript

Coding card game

# Directory Structure

The 'game' folder contains the Unity project hosting the actual game files.
The 'www' folder contains the Laravel web framework files

# Install Guide

(Note: Highly recommend not downloading Apache and PHP separately. Huge pain in the ass. 
Use something like XAMMP or WAMP that packages the entire stack for you pre-configured)

Laravel:
1. You need to download Composer online, and through it, install Laravel. Detailed installation guide found at https://laravel.com/docs/4.2/installation#configuration
2. For local development, it is recommended that you run "php artisan serve" in the root directory. 
The website will be accessible from localhost:8000

(Highly recommend not downloading these manually. 
We can consider doing these individually for production but I really don't think that would be the best idea)
PHP:
1. When installing PHP manually, saw some things online about 
needing to download the "thread safe" versions when working with Apache

Apache:
1. As Administrator, run "httpd.exe -k install" in the /bin folder to install httpd as a Windows service. You can now control the service from Apache monitor, also located in the bin folder
2. Set DocumentRoot and Directory to your dev environment directory in /conf/httpd.conf
3. Find AddType in httpd.conf and add "AddType application/x-httpd-php .php" entry
4. Find LoadModule in httpd.conf and add "LoadModule php7_module C:/php/php7apache2_4.dll" (or wherever you installed php)
5. Laravel uses some OpenSSL module and it needs to be configured somewhere in either httpd.conf or php.ini? Couldn't resolve
