<?php

namespace App\Http\Controllers;
use Illuminate\Support\Facades\Auth;
use DB;

use Illuminate\Http\Request;

class editprofile extends Controller
{
    //
	public function index()
    {
        return view('editprofile');
    }
	
	public function __construct()
    {
        $this->middleware('auth');
        $this->user =  \Auth::user();
    }
	
	function edit(Request $request){
		$email = $request->input('email');
	    $user=auth()->user();
		$user->email=$email;
		$myuser = DB::select('select * from users where id="' . $user->id . '"', [1]);
		foreach ($myuser as $u) {
			//echo $u->email;
			$u->email=$email;
		}
		//echo $user->id;
		return $myuser;
	}
}
