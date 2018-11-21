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

    // Insert wins into database (called by game)
    public function record(Request $request)
    {
    	// Check user is logged in first, and that the user logged in is the same person trying to record win
    	if (Auth::check() && ((string)Auth::user()->id == $request->input('player_id')))
    	{
    		try 
    		{
    			// assemble hash
    			$inputHash = md5($request->input('player_id') . $request->input('result') . Config::get('app.dbkey'));
    			echo ($request->input('player_id') . $request->input('result') . Config::get('app.dbkey'));
    			echo "<br>";
    			echo $inputHash;
    			// if hash matches secret key, then allow database insertion
	    		if ($inputHash == $request->input('hash'))
	    		{
	    			//record match
	    			DB::table('match_history')->insert([
					    ['player_id' => $request->input('player_id'), 'result' => $request->input('result'), 'created_at'=>now()]
					]);
	    		}
	            else
	            {
	            	// if request is invalid for whatever reason, add "invalid" result to match history using currently logged in user
		    		DB::table('match_history')->insert([
						    ['player_id' => Auth::user()->id, 'result' => "invalid", 'created_at'=>now()]
						]);
	            }
	        } 
	        catch (Exception $e) {
	            return $e;
	        }

    	}
    	else
    	{
    		try 
    		{
	    		// if request is invalid for whatever reason, add "invalid" result to match history using currently logged in user
	    		DB::table('match_history')->insert([
					    ['player_id' => Auth::user()->id, 'result' => "invalid", 'created_at'=>now()]
					]);
    		}
	        catch (Exception $e) {
	            return $e;
	        }
    	}
        
    }
}
