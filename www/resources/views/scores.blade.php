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
			<li><a id="navPlayButton" href="/unity">GAME</a></li>
		</ul>
	</div>
	<div class="textbox">
		<h1>ScoreBoard</h1>
		<table>
			<tr>
				<th>Opponent</th>
				<th>Result</th>
			</tr>
			@foreach ($record as $r)
			<tr>
				<td>{{$r->opponent}}</td>
				<td>{{$r->result}}</td>
			</tr>
			@endforeach
		</table>
	</div>
</div>

<div class="footer">
  <div id="footertext">Team 404 &copy; 2018</div>
</div>


@endsection

