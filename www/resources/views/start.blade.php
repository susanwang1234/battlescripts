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
		<li><a href="/tutorial">TUTORIAL</a></li>
		<li><a id="active" href="/start">GETTING STARTED</a></li>
		<li><a id="navPlayButton" href="/unity">PLAY NOW</a></li>
	</ul>
</div>
<div class="textbox">
	  <h1>Sounds hard, eh? Here are some tips to get you started.</h1>
	  <ul class="list">
		  <li>Try to keep your points in the middle to be safe, not too low, not to high, to avoid being overflown by your opponent.</li>
		  <li>Only have some small combos? You don't have to execute right away; build onto it for a couple turns, and attack your opponent all at once!</li>
		  <li>Sometimes it is important to boost your own life, rather then decrement your opponents. Be careful!</li>
		  <li>Take advantage of your memory. Store good card blocks inside memory to use later.</li>
		  <li>Calculations matter: overflow your opponents or make your score exactly to zero.</li>
	  </ul>
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
          <li class="item"><a class="active" href="/start">GETTING STARTED</a></li>
      </ul>
    </nav>
		</header>
        <div class="tips">
		  <h1>Sounds hard, eh? Here are some tips to get you started.</h1>
		  <ul class="list">
	          <li>Try to keep your points in the middle to be safe, not too low, not to high, to avoid being overflown by your opponent.</li>
	          <li>Only have some small combos? You don't have to execute right away; build onto it for a couple turns, and attack your opponent all at once!</li>
	          <li>Sometimes it is important to boost your own life, rather then decrement your opponents. Be careful!</li>
	          <li>Take advantage of your memory. Store good card blocks inside memory to use later.</li>
	          <li>Calculations matter: overflow your opponents or make your score exactly to zero.</li>
	      </ul>

		</div>

</body>

@endsection--}}
