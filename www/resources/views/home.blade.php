@extends('layouts.app')

@section('content')
<link href="{{ asset('css/home.css') }}" rel="stylesheet">
<div class="bg">
	<div class="container">
	    <div class="row justify-content-center">
	        <div class="col-md-8">
	        	<img src="{{URL::asset('/images/logo_text.png')}}" class="center-block" style="width:100%; height=auto">
	        </div>
	    </div>
	</div>

</div>
<div class=categories style="margin-top:20px">
	<ul>
		<li><a class="active" href="/about">ABOUT</a></li>
		<li><a href="/tutorial">GAME GUIDE</a></li>
		<li><a id="navPlayButton" href="/">PLAY NOW</a></li>
	</ul>
</div>
@endsection
