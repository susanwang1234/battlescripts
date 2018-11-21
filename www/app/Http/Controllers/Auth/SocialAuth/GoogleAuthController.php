<?php

namespace App\Http\Controllers\Auth\SocialAuth;

use App\Http\Controllers\Controller;
use Illuminate\Foundation\Auth\AuthenticatesUsers;
use Socialite;
use Auth;
use Exception;
use App\User;

class GoogleAuthController extends Controller
{
    // Call up google's authentication page
    public function redirect()
    {
        return Socialite::driver('google')->redirect();
    }

    // This is technically the 'redirect' portion; the function below is executed when a google authentication is successful
    public function handleCallback()
    {
        try {
            $googleUser = Socialite::driver('google')->user();
            $existUser = User::where('email',$googleUser->email)->first();
            
            if($existUser) {
                Auth::loginUsingId($existUser->id);
            }
            else {
                $user = new User;
                $user->name = $googleUser->name;
                $user->email = $googleUser->email;
                $user->provider_id = $googleUser->id;
                $user->provider = 'google';
                $user->password = md5(rand(1,10000)); //Since password is not nullable just make a random string?
                $user->email_verified_at = now();
                $user->save();
                Auth::loginUsingId($user->id);
            }
            // return to home page
            return redirect()->to('/');
        } 
        catch (Exception $e) {
            return $e;
        }
    }
}