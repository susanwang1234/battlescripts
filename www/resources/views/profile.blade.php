@extends('layouts.app')
@section('content')

<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<div class="container">
	<div class="row">
		<div class="col-md-12">
		    <div class="card">
		        <div class="card-body">
		            <div class="row">
		                <div class="col-md-12">
		                    <h4>Your Profile 
                          @if (!empty(Auth::user()->isAdmin))
                            (Administrator Account)
                          @endif
                        </h4>
		                    <hr>
		                </div>
		            </div>
		            <div class="row">
		                <div class="col-md-12">
		                    <form>
                              <div class="form-group row">
                                <label for="username" class="col-4 col-form-label"><strong>User Name</strong></label> 
                                <div class="col-8" style="margin-top:5px;">  
                                    {{ Auth::user()->name }}
                                </div>
                              </div>
                          
                              <div class="form-group row">
                                <label for="email" class="col-4 col-form-label"><strong>Email</strong></label> 
                                <div class="col-8" style="margin-top:5px;">
                                  {{ Auth::user()->email }}
                                </div>
                              </div>
                              <div class="form-group row">
                                <label for="date" class="col-4 col-form-label"><strong>Date Joined</strong></label> 
                                <div class="col-8" style="margin-top:5px;">
                                  {{ Auth::user()->created_at }}
                                </div>
                              </div> 
                              <div class="form-group row">
                                <label for="Number of Wins" class="col-4 col-form-label"><strong>Number of Wins</strong></label> 
                                <div class="col-8" style="margin-top:5px;">
                                  {{ DB::table('match_history')->where('player_id', '=', Auth::user()->id)->where('result', '=', 'win')->count() }}
                                </div>
                              </div> 
                              <div class="form-group row">
                                <label for="Number of Losses" class="col-4 col-form-label"><strong>Number of Losses</strong></label> 
                                <div class="col-8" style="margin-top:5px;">
                                  {{ DB::table('match_history')->where('player_id', '=', Auth::user()->id)->where('result', '=', 'loss')->count() }}
                                </div>
                              </div> 
                            </form>
		                </div>
		            </div>
		            
		        </div>
		    </div>
		</div>
	</div>
</div>
@endsection