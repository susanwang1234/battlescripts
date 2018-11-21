<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use App\Http\Controllers\Controller;
use Illuminate\Support\Facades\Auth;

class matchPlayed extends Controller
{
    //
    public function index()
    {
        $records = DB::table('record')->where('userName', Auth::user()->name)->get();
        return view('matchPlayed', ['record' => $records]);
    }


}
