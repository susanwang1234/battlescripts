@extends('layouts.app')

@section('content')
<link href="{{ asset('css/home.css') }}" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet">
<div class="bg">
	<div class="container">
	    <div class="row justify-content-center">
	        <div class="col-md-8">
	        	<img src="{{URL::asset('/images/logo_text.png')}}" class="center-block" style="width:100%; height=auto">
	        </div>
	    </div>
	</div>
</div>

<div class="content-bg">
<div class=categories style="margin-top:20px;">
	<ul>
	    <li><a id="active" href="/index.php">HOME</a></li>
		<li><a href="/about">ABOUT</a></li>
		<li><a href="/tutorial">TUTORIAL</a></li>
		<li><a href="/start">GETTING STARTED</a></li>
		<li><a id="navPlayButton" href="/unity">PLAY NOW</a></li>
	</ul>
	<table>
		<tr>
			<th><h1>Opponent</h1></th>
			<th><h1>Result</h1></th>
		</tr>
		@foreach ($record as $r)
		<tr>
			<td><h1>{{$r->opponent}}</h1></td>
			<td><h1>{{$r->result}}<h1></td>
		</tr>
		@endforeach
	</table>
</div>

@endsection

