<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\DB;
use Config;

class unity extends Controller
{
    //
    public function index()
    {
        return view('unity');
    }

    public function record(Request $request)
    {
    	if (Auth::check())
    	{
    		try 
    		{
    			// assemble hash
    			$inputHash = md5($request->input('player_id') . $request->input('opponent_id') . $request->input('result') . Config::get('app.dbkey'));
    			echo ($request->input('player_id') . $request->input('opponent_id') . $request->input('result') . Config::get('app.dbkey'));
    			echo "<br>";
    			echo $inputHash;
    			// if hash matches secret key, then allow database insertion
	    		if ($inputHash == $request->input('hash'))
	    		{
	    			//record match
	    			DB::table('match_history')->insert([
					    ['player_id' => $request->input('player_id'), 'opponent_id' => $request->input('opponent_id'), 'result' => $request->input('result'), 'created_at'=>now()]
					]);
	    		}
	            else
	            {
	            	return "Secret key does not match!";
	            }
	        } 
	        catch (Exception $e) {
	            return $e;
	        }
    	}
    	else
    	{
    		echo "fail";
    	}
        
    }
}
