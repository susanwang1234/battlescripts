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

<div class=categories style="margin-top:20px">
	<ul>
	    <li><a href="/index.php">HOME</a></li>
		<li><a href="/about">ABOUT</a></li>
		<li><a id="active" href="/tutorial">TUTORIAL</a></li>
		<li><a href="/start">GETTING STARTED</a></li>
		<li><a id="navPlayButton" href="/unity">PLAY NOW</a></li>
	</ul>
</div>
<div class="textbox">
	  <h1>How to Play</h1>
	  <p><i>Battlescripts</i> is a two-player coding card game. Each card is essentially blocks of code which will be added to that player's program. Players take turns drawing and playing cards from a deck, with the choice of executing, storing, or building on each turn. They may strengthen themself, powerup attacks on opponents, or have the option of storing useful blocks of code. <i>FOO</i> and <i>BAR</i> bars are the life points of each player. Each player starts with zero bugs and when one player overflows the other player's points (either over or under), then their bugs amount will increase by one. Win the game by overflowing your opponent until you get three bugs, or by setting your bars exactly to zero.</p>
</div>

<div class="footer">
	<div id="footertext">Team 404 &copy; 2018</div>
</div>

</div>

@endsection



{{--@extends('layouts.app')

@section('content')
<link href="{{ asset('css/info.css') }}" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet">
<body background="/images/background.png">
	<img src="{{URL::asset('/images/logo_text.png')}}" class="center" style="width:20%; height=auto">
    <nav>
      <ul class="group">
          <li class="item"><a href="/about">ABOUT</a></li>
          <li class="item"><a href="/tutorial">TUTORIAL</a></li>
          <li class="item"><a href="/start">GETTING STARTED</a></li>
      </ul>
    </nav>
		</header>
        <div class="textbox">
		  <h1>How to Play</h1>

		  <p><i>Battlescripts</i> is a two-player coding card game. Each card is essentially blocks of code which will be added to that player's program. Players take turns drawing and playing cards from a deck, with the choice of executing, storing, or building on each turn. They may strengthen themself, powerup attacks on opponents, or have the option of storing useful blocks of code. <i>FOO</i> and <i>BAR</i> bars are the life points of each player. Each player starts with zero bugs and when one player overflows the other player's points (either over or under), then their bugs amount will increase by one. Win the game by overflowing your opponent until you get three bugs, or by setting your bars exactly to zero.</p>

		</div>

</body>

@endsection--}}
