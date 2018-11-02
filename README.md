# BattleScript

http://battlescript.tk

Programming can be challenging and boring, but it doesn't have to be. Battlescripts makes programming concepts easy to grasp by playing cards to execute code. Engage and interact with other users to develop new skills and enjoy coding!

Our game introduces coding concepts to players and sharpen their ability to build programs using blocks of logic without having to worry about syntax or typing errors. Players will have to think strategically through the use of various different features: data types, loops, conditions, memory, and execution time, while keeping an eye on their own and their opponent's life points.

All of this happens live on a 2-player network connected game channel

# Directory Structure

The 'game' folder contains the Unity project hosting the actual game files.
The 'www' folder contains the Laravel web framework files

# Install Guide

**Installing Laravel**
=================================================================================================================
Laravel:
1. You need to download Composer online, and through it, install Laravel. Detailed installation guide found at https://laravel.com/docs/4.2/installation#configuration
2. For local development, it is recommended that you run "php artisan serve" in the root directory.
The website will be accessible from localhost:8000
3. Also install the socialite Laravel package using command "composer require laravel/socialite"

**For separate installations: (not complete either)**
=================================================================================================================
(Note: Highly recommend not downloading Apache and PHP separately. Huge pain in the ass.
Use something like XAMMP or WAMP that packages the entire stack for you pre-configured)

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


**Using preconfigured stack**
=================================================================================================================
Using XAMPP as example:

Local Database:
Good reference link for resetting default password https://stackoverflow.com/questions/24566453/resetting-mysql-root-password-with-xampp-on-localhost
1. Install MySql I recommend just installing XAMPP https://www.apachefriends.org/index.html
2. Go to xampp/phpMyAdmin/config.inc.php
3. under /*Authentication type and info*/
	- $cfg['Servers'][$i]['auth_type'] = 'cookie';
	- $cfg['Servers'][$i]['user'] = 'root';
	- $cfg['Servers'][$i]['password'] = '123456';
	- $cfg['Servers'][$i]['extension'] = 'mysqli';
	- $cfg['Servers'][$i]['AllowNoPassword'] = true;
	- $cfg['Lang'] = '';

confirm that you have the above setting.
4. In XAMPP Control Panel start MySql
5. In your browser type in localhost:8000/phpmyadmin
6. Login with the above "username" and "password"
7. On the most left side of the navigation bar click on Database
8. Create a new database "battlescript" *you do not need to create any table
9. Under /www/ directory open the ".env" file in a text editor and set the following(should be in line 12-14):
	- DB_DATABASE=battlescript
	- DB_USERNAME=root
	- DB_PASSWORD=123456
9. In the same directory "/www/" open a terminal and run "php artisan migrate"
10. refresh your browser and go in to your database
	"battlescript". You should see 3 tables "migrations", "password_resets", "users".
11. You should now be able to register a user and login with it, or alternatively create a user in the database and login form the web.

Access Routes:
1. About, Tutorial, and Getting Started pages are accessible by all users through connected routes or via page links.  
Routes:
	- localhost:8000/about
	- localhost:8000/tutorial
	- localhost:8000/start
2. Play Game link has been configured so users can only access the game after the user has logged in. If user is already logged in, they will be after to obtain access to the game, otherwise, they will be directed to the login screen.  
Route(after logging in):
	- localhost:8000/unity

# Unity Guide

Unity Primer:
1. For Unity installation, here is the link https://unity3d.com/get-unity/download.
2. The game is accessible under BattleScript/game/BattleScripts/Assets/_Scenes.
3. The .unity files are the game scenes, which are what the Unity editor opens and allows to be edited.
4. For our game networking, we are using Photon v2. When cloning the branch, if should be under the Assets folder.
5. When building the game to debug, create a folder called Debug. the path should be BattleScript/game/BattleScripts/Debug
6. The .gitignore file has been configured to ignore Debug folder.

Updating Release Build :
1. To build a production version of the game, you'll need to go to Unity and build a NON-DEVELOPEMENT build into a Release directory in game/BattleScripts/
2. It is possible to test the game without starting the server by just opening the index.html page in the Release directory
3. The next step is to replace the Build folder at "www/public/game/" with the one in  "game/BattleScripts/Release/"
4. To make changes to the styles, edit the style.css in the "www/public/game/TemplateData"
5. Changing the .html file will do nothing to the actual view, to make changes to the view on the site, modify the unity.blade.php file in www/resources/views
