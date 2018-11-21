<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('home');
});


Auth::routes(['verify' => true]);
Route::get('/home', 'HomeController@index')->name('home');

Route::get('/tutorial', function () {
    return view('tutorial');
});
Route::get('/about', function () {
    return view('about');
});
Route::get('/start', function () {
    return view('start');
});
Route::group(['middleware' => ['auth', 'user']], function () {
    Route::get('/profile', 'profile@index')->name('profile');
});
Route::group(['middleware' => ['auth', 'user']], function () {
    Route::get('/admin', 'admin@index')->name('admin');
});
Route::group(['middleware' => ['auth', 'user']], function() {
    Route::get('/unity', 'unity@index')->name('unity');
});

// Google routing 
Route::get('/user/login/google/redirect', 'Auth\SocialAuth\GoogleAuthController@redirect');
Route::get('/user/login/google/callback', 'Auth\SocialAuth\GoogleAuthController@handleCallback');

Auth::routes(['verify' => true]);

Route::get('/home', 'HomeController@index')->name('home');

Route::get('/unity/record/', 'unity@record');