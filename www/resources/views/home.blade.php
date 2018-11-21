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
</div>

<div class="textboxhome">
<br />
<div class="flex-container">
	<div class="box"><h1 style="color:lime; text-shadow: 0px 0px 50px yellow; font-size: 70px; font-variant: small-caps; font-family: 'VT323', monospace;">Defeat your enemies in this battle coding simulator!</h1></div>
	<div class="box"><img src="/images/battle.png" width="90%"/></div>
</div>

<br />
<br />
<br />
<h2 class="review">Strategize and plan your moves. <br>Outsmart, outplay, and outcode your opponent!</h2>
<br />
<br />
<br />

<div class="flex-container">
	<div class="box"><img src="/images/screenshot1.png" width="90%"/></div>
	<div class="box"><h1 style="color:lime; text-shadow: 0px 0px 50px yellow; font-size: 70px; font-variant: small-caps; font-family: 'VT323', monospace;">Are you up for the challenge?</h1></div>
</div>
<br />
<div style="margin:20px">
	<h2 class="review">This is the most interesting game in 2018!</h2>
	<h3 class="review">- FakeGameReviews.com</h3>
	<br/>
	<h2 class="review">I used to struggle with programming, until I found this game! Now I am an expert!</h2>
	<h3 class="review">- Anonymous</h3>
	<br/>
	<h2 class="review">BattleScripts is a fun and addictive game that can introduce people into coding in a very creative and interesting way!</h2>
	<h3 class="review">- 1337GameReviews</h3>
	<br/>
	<h2 class="review">BattleScripts makes programming fun and taught me to love programming!</h2>
	<h3 class="review">- A random SFU student.</h3>
	<br/>
	<h2 class="review">10/10</h2>
	<h3 class="review">- 31337CMPTH4X0R Magazine</h3>
</div>
</div>

<div class="footer">
	<div id="footertext">Team 404 &copy; 2018</div>
</div>

</div>
@endsection
