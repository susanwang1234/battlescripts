<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\Auth;

class admin extends Controller
{
    //
    public function index()
    {
    	if (Auth::user()->isAdmin)
    	{
		    $users = DB::table('users')->get();
		    $match_history = DB::table('match_history')->get();
		    return view('admin', ['userlist' => $users, 'match_history' => $match_history]);
    	}
    	else
    	{
    		abort(401, "Unauthorized action!");
    	}

    }


}
