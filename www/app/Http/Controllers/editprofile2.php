<?php

namespace App\Http\Controllers;
use Illuminate\Support\Facades\Auth;
use DB;

use Illuminate\Http\Request;

class editprofile2 extends Controller
{
	
	public function index()
    {
        return view('editprofile');
    }
	
	public function __construct()
    {
        $this->middleware('auth');
        $this->user =  \Auth::user();
    }
	
	
    function editpw(Request $request){
		$pw1 = $request->input('password');
		$pw2 = $request->input('password2');
	    $user=auth()->user();
		if($pw1==$pw2) {
			$sql = "UPDATE users SET password='" .  password_hash($pw2,PASSWORD_DEFAULT) . "' WHERE " . "id=" . $user->id;
			$affected = DB::update($sql);
			return view('profile');
		}
		else {
			echo "<script type='text/javascript'>alert('Passwords do not match.');</script>";
			return view('editprofile');
		}
		
	}
}
