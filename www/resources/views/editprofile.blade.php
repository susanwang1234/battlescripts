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
		                    <h4>Edit Profile</h4>
		                    <hr>
		                </div>
		            </div>
		            <div class="row">
		                <div class="col-md-12">
		                    <form method="post" action="{{ action('editprofile@edit') }}">
							   @csrf
                              <div class="form-group row">
                                <label for="email" class="col-4 col-form-label"><strong>Current Email</strong></label> 
                                <div class="col-8" style="margin-top:5px;">  
                                    {{ Auth::user()->email }}
                                </div>
                              </div>
							  
                                <div class="form-group row">
                                <label for="username" class="col-4 col-form-label"><strong>New Email</strong></label> 
                                <div class="col-8" style="margin-top:5px;">  
								<input type="email" name="email" value="">
								</div>
                                </div>
								
							    <button type="submit" class="btn btn-primary">
                                    {{ __('Submit') }}
                                </button>
								
                            </form>
		                </div>
		            </div>
		            
		        </div>
		    </div>
		</div>
	</div>
</div>
@endsection